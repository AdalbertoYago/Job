Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmEstruturaProdutos
    Public datPubsEstoque, datPubsComprador, datPubsFornec1, datPubsFornec2, datPubsFornec3, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Public sProduto As String

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        sProduto = txtCDProduto.Text

        querySQL2.CommandText = "Select * From Estoque Where CDProduto = '" & sProduto.PadLeft(7, "0") & "' and Estoque = '1'"
        datRead = querySQL2.ExecuteReader()
        If datRead.Read = True Then
            lblDescricao.Text = datRead("Descricao")
            carregaGrid()
        Else
            MessageBox.Show("Código pai inexistente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        datRead.Close()
    End Sub
    Public Sub carregaGrid()
        datRead.Close()
        datPubsEstoque.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select * From Estrutura Where CDProduto = '" & sProduto.PadLeft(7, "0") & "' and Cenario=1", conSQL2)
        adaptSQL.Fill(datPubsEstoque, "Estrutura")
        GridControl1.DataSource = datPubsEstoque.Tables("Estrutura")
    End Sub
    Private Sub bt0Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Imprimir.Click
        If sProduto <> "" Then
            Dim ps As New PrintingSystem
            With ps
                .ShowPrintStatusDialog = False
                .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
                .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
            End With
            Dim link As New PrintableComponentLink(ps)
            link.Component = GridView1.GridControl
            link.Margins.Left = 50
            link.Margins.Right = 50
            link.Landscape = False
            link.EnablePageDialog = True

            Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
            HeaderArea.Content.Add(Date.Now.ToShortDateString())
            Dim sNomeProd As String = lblDescricao.Text
            If sNomeProd.Length > 32 Then
                sNomeProd = sNomeProd.Substring(0, 32)
            End If
            HeaderArea.Content.Add("Estrutura de Prod.: " & sProduto & " - " & sNomeProd)
            HeaderArea.Content.Add("Pagina[Page # of Pages #]")
            HeaderArea.Font = New Font("Arial", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            HeaderArea.LineAlignment = BrickAlignment.Center
            Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
            link.PageHeaderFooter = Header
            link.CreateDocument()
            link.ShowPreviewDialog()
        Else
            MessageBox.Show("Selecione um produto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub bt0Copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Copiar.Click
        If classParam.selPermissoes(297, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            Dim VCodPai As String, VCodFilho As String
            VCodPai = InputBox("Digite o código Pai a ser copiado", "Copiar estruturas")

            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2

            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL

            Dim sProduto As String = txtCDProduto.Text

            querySQL2.CommandText = "Select * From Estoque Where CDProduto = '" & VCodPai.PadLeft(7, "0") & "'"
            datRead = querySQL2.ExecuteReader()
            If datRead.Read = True Then
                lblDescricao.Text = datRead("Descricao")
                datRead.Close()

                VCodFilho = InputBox("Digite o código Pai que receberá a estrutura", "Copiar estruturas")
                querySQL2.CommandText = "Select * From Estoque Where CDProduto = '" & VCodFilho.PadLeft(7, "0") & "'"
                datRead = querySQL2.ExecuteReader()
                If datRead.Read = True Then
                    datRead.Close()
                    If MessageBox.Show("Confirma a cópia da estrutra?" & vbCrLf & "Lembre-se que a estrutura filho será apagada e recriada de acordo com a estrutura pai!", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then


                        '### CHECA SE JA NAO EXISTE A ESTRUTURA FILHO
                        querySQL2.CommandText = "Select * from Estrutura where CDProduto='" & VCodFilho.PadLeft(7, "0") & "' and Cenario=1"
                        querySQL2.ExecuteNonQuery()

                        '#PEGA DADOS DA ESTRUTURA PAI
                        querySQL2.CommandText = "Select * from Estrutura where CDProduto='" & VCodPai.PadLeft(7, "0") & "' and Cenario=1"
                        datRead2 = querySQL2.ExecuteReader()
                        Do Until datRead2.Read = False
                            'JOGA DADOS NA ESTRUTURA FILHA
                            querySQl.CommandText = "Insert into Estrutura (Cenario,CDProduto,CDMaterial,Qtde,Unidade,Descricao) values ('1','" & VCodFilho.PadLeft(7, "0") & "','" & datRead2("CDMaterial") & "'," & Replace(datRead2("Qtde"), ",", ".") & ",'" & datRead2("Unidade") & "','" & datRead2("Descricao") & "')"
                            querySQl.ExecuteNonQuery()
                        Loop
                        datRead2.Close()
                        MessageBox.Show("Estrutura copiado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                Else
                    datRead.Close()
                    MessageBox.Show("O Código [" & VCodFilho & "] ainda não foi criado no estoque...verifique", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Código pai inexistente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
            datRead.Close()
            conSQL.Close()
            conSQL2.Close()
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If classParam.selPermissoes(296, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                Try
                    querySQL2.CommandText = "delete from Estrutura where CDProduto='" & txtCDProduto.Text & "' and CDMaterial ='" & row("CDMaterial") & "' and Cenario=1"
                    querySQL2.ExecuteNonQuery()
                    row.Delete()
                Catch ex As Exception
                    MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQL2.Close()
            Else
                MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
    Private Sub GridView1_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.RowCountChanged
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        '## CHECA SE ROW ESTA EM MODO DE INCLUSAO
        Try
            If row.RowState = DataRowState.Added Then
                If classParam.selPermissoes(294, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2
                    Try
                        querySQL2.CommandText = "Insert into Estrutura (Cenario,CDProduto,CDMaterial,Qtde,Unidade,Descricao) values ('1','" & txtCDProduto.Text & "','" & row("CDMaterial") & "'," & Replace(row("Qtde"), ",", ".") & ",'" & row("Unidade") & "','" & row("Descricao") & "')"
                        querySQL2.ExecuteNonQuery()
                        carregaGrid()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    conSQL2.Close()
                Else
                    MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        '## CHECA SE ROW ESTA EM MODO DE UPDATE
        If row.RowState = DataRowState.Modified Then
            If classParam.selPermissoes(295, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                Try
                    querySQL2.CommandText = "update Estrutura set Qtde=" & Replace(row("Qtde"), ",", ".") & ",Unidade='" & row("Unidade") & "',Descricao='" & row("Descricao") & "' where CDProduto='" & txtCDProduto.Text & "' and CDMaterial ='" & row("CDMaterial") & "' and Cenario=1"
                    querySQL2.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQL2.Close()
            Else
                MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As GridView = sender
        Dim sCDCB As String = ""


        If e.Column.FieldName = "CDMaterial" Then
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL

            Dim sCDProduto As String = View.EditingValue
            querySQl.CommandText = "Select * from Estoque where CDProduto='" & sCDProduto & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "Descricao", datRead("Descricao"))
                View.SetRowCellValue(e.RowHandle, "Unidade", datRead("Unidade"))
            End If
            datRead.Close()
            conSQL.Close()
        End If
    End Sub
End Class


