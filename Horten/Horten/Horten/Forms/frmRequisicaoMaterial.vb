Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmRequisicaoMaterial
    Public ds, datPubsRep, datPubsRep2, dsREQ, dsReq2 As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        'gEmailAlmoxarife 
        Dim sMail As ClassMail = New ClassMail()
        Dim sBody = "Olá Almoxarife!<BR>O Usuario: " & txtRequisitante.Text & " fez uma requisição de material com número: " & txtCDRequisicao.Text & " - acesso o CONTROLE DE ESTOQUE para imprimí-la<br><br>Sem mais,<br><br>" & gNomeEmpresa
        sMail.SendMailMessage(gUsuario & "@" & gDominio, gEmailAlmoxarife, "", "", "Nova Requisição", sBody, "", "", gIDEmpresa, "alex@classicacom.br", "haunted")
        MessageBox.Show("Requisição Concluída com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.Close()
    End Sub

    Private Sub bt0IncluirEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Incluir.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQl.Connection = conSQL2

        Try
            querySQl.CommandText = "Select top 1 CDRequisicao from Requisicao order by CDRequisicao desc"
            Dim iUltima As Integer = querySQl.ExecuteScalar()
            Dim sUltima As String
            iUltima += 1
            sUltima = iUltima.ToString


            gVSQL = "Insert into Requisicao (CDRequisicao,DTRequisicao,HRRequisicao,Requisitante,Historico,setor) values "
            gVSQL &= "('" & sUltima.PadLeft(6, "0") & "',convert(datetime,'" & Date.Now.ToShortDateString() & "',103),'" & Date.Now.ToShortTimeString() & "','" & txtRequisitante.Text & "','" & txtObs.Text & "','" & txtSetor.Text & "')"
            querySQl.CommandText = gVSQL
            querySQl.ExecuteNonQuery()

            txtCDRequisicao.Text = sUltima.PadLeft(6, "0")
            MessageBox.Show("Cabeçalho da requisição criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            bt0NovoEndereco.Text = "Novo"
            bt0Incluir.Enabled = False

            txtData.Enabled = False
            txtObs.Enabled = False
            txtSetor.Enabled = False
            txtRequisitante.Enabled = False
            cbTipoEstoque.Enabled = False



        Catch
            MessageBox.Show("Erro ao incluir o cabeçalho da requisição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conSQL2.Close()
    End Sub

    Private Sub frmRequisicaoMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 1

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        'CARREGA Tipo de Endereco
        carregaGrid()

        ds.Clear()


        datPubsRep.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select CDProduto,Descricao,idle from estoque where idle=0 and Estoque <> 1 order by cdproduto", conSQL2)
        adaptSQL.Fill(datPubsRep, "sCP")
        RepositoryItemLookUpEdit1.DataSource = datPubsRep.Tables("sCP")

        datPubsRep2.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select CDProduto,Descricao,idle from estoque where idle=0 and Estoque <> 1 order by cdproduto", conSQL2)
        adaptSQL.Fill(datPubsRep2, "sCP")
        RepositoryItemLookUpEdit2.DataSource = datPubsRep2.Tables("sCP")

        cbCampo.Items.Add("Requisitante")
        cbCampo.Items.Add("Nº Requisição")
        cbCampo.SelectedIndex = 1

    End Sub
    Public Sub carregaGrid()
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        ds.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select * from ItemReq where CDRequisicao='" & txtCDRequisicao.Text & "'", conSQL2)
        adaptSQL.Fill(ds, "ItemReq")
        GridControl1.DataSource = ds.Tables("ItemReq")
        GridControl1.Select()
    End Sub
    Private Sub bt0NovoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0NovoEndereco.Click
        If bt0NovoEndereco.Text = "Novo" Then
            txtData.Text = Date.Now.ToShortDateString()
            cbTipoEstoque.Select()
            txtRequisitante.Text = gUsuario.ToUpper()
            txtSetor.Text = gSetor.ToUpper()
            bt0Incluir.Enabled = True
            bt0NovoEndereco.Text = "Cancelar"

            txtData.Enabled = True
            txtObs.Enabled = True
            txtSetor.Enabled = True
            txtRequisitante.Enabled = True
            cbTipoEstoque.Enabled = True
        Else
            bt0NovoEndereco.Text = "Novo"
            bt0Incluir.Enabled = False
            txtData.Enabled = False
            txtObs.Enabled = False
            txtRequisitante.Enabled = False
            txtSetor.Enabled = False
            cbTipoEstoque.Enabled = False
        End If
    End Sub



    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2
            Try
                querySQL2.CommandText = "delete from ItemReq where Item='" & row("Item") & "' and CDMaterial ='" & row("CDMaterial") & "' and CDRequisicao='" & txtCDRequisicao.Text & "'"
                querySQL2.ExecuteNonQuery()
                row.Delete()
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            conSQL2.Close()
        End If
    End Sub
    Private Sub GridView1_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.RowCountChanged
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim iItem As Integer
        Dim sItem As String
        Dim dSaldo As Decimal = 0
        Dim dQtde As Decimal
        Dim sUnidade As String
        '## CHECA SE ROW ESTA EM MODO DE INCLUSAO

        Try
            If row.RowState = DataRowState.Added Then
                Try
                    sUnidade = row("Unidade")
                Catch ex As Exception
                    sUnidade = ""
                End Try
                Try
                    dQtde = row("Qtde")
                Catch ex As Exception
                    dQtde = 0
                End Try
                If sUnidade <> "" And dQtde > 0 Then
                    If row.RowState = DataRowState.Added Then
                        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                        conSQL2.Open()
                        querySQL2.Connection = conSQL2
                        Try
                            querySQL2.CommandText = "select max(Item) as Codigo from ItemReq where CDRequisicao='" & txtCDRequisicao.Text & "'"
                            Try
                                iItem = querySQL2.ExecuteScalar()
                                iItem += 1
                            Catch
                                iItem = 1
                            End Try

                            Try
                                querySQL2.CommandText = "Select top 1 saldo from Kardex where CDProduto='" & row("CDMaterial") & "' order by data desc "
                                dSaldo = querySQL2.ExecuteScalar()
                            Catch
                                dSaldo = 0
                            End Try

                            If dSaldo <> 0 And dQtde <= dSaldo Then
                                querySQL2.CommandText = "Insert into ItemReq (CDRequisicao,CDMaterial,Qtde,Unidade,Item,Descricao) values ('" & txtCDRequisicao.Text & "','" & row("CDMaterial") & "'," & Replace(row("Qtde"), ",", ".") & ",'" & row("Unidade") & "','" & iItem & "','" & row("Descricao") & "')"
                                querySQL2.ExecuteNonQuery()
                            Else
                                MessageBox.Show("O Item " & row("CDMaterial") & " está sem saldo no estoque!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        conSQL2.Close()
                    End If
                End If
                carregaGrid()
            End If
        Catch
        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As GridView = sender
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        If e.Column.FieldName = "CDMaterial" Then
            Dim sCDProduto As String = View.EditingValue
            '#############CHECAR TODAS AS INCIDENCIAS QUE APARECEM NA CFOP DO CLIENTE


            querySQl.CommandText = "Select * from Estoque where CDProduto='" & sCDProduto & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "Unidade", datRead("Unidade"))
                View.SetRowCellValue(e.RowHandle, "Descricao", datRead("Descricao"))
            End If
            datRead.Close()
        End If
        If e.Column.FieldName = "Descricao" Then
            Dim sDescricao As String = View.EditingValue

            'Fazer select em Estoque
            '#############CHECAR TODAS AS INCIDENCIAS QUE APARECEM NA CFOP DO CLIENTE


            querySQl.CommandText = "Select * from Estoque where Descricao='" & sDescricao & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "Unidade", datRead("Unidade"))
                View.SetRowCellValue(e.RowHandle, "CDMaterial", datRead("CDProduto"))
            End If
            datRead.Close()
        End If
        conSQL.Close()
        conSQL2.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim xtra As XtraRequisicao = New XtraRequisicao(txtCDRequisicao.Text)
        xtra.ShowPreview()
    End Sub

    Private Sub btBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscar.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        If cbCampo.SelectedIndex = 0 Then
            gVSQL = "Select CDRequisicao,DTRequisicao,Requisitante from Requisicao where Requisitante like '%" & txtChave.Text & "%' order by CDRequisicao desc"
        ElseIf cbCampo.SelectedIndex = 1 Then
            gVSQL = "Select CDRequisicao,DTRequisicao,Requisitante from Requisicao where CDRequisicao like '%" & txtChave.Text & "%' order by CDRequisicao desc"
        End If
        dsREQ.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsREQ, "Busca")
        GridBusca.DataSource = dsREQ.Tables("Busca")
    End Sub

    Private Sub GridBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBusca.Click
        selBusca()
    End Sub
    Private Sub GridBusca_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridBusca.KeyUp
        selBusca()
    End Sub
    Public Sub selBusca()
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        querySQL2.CommandText = "Select * from Requisicao where CDRequisicao='" & row("CDRequisicao") & "'"
        datRead = querySQL2.ExecuteReader()
        If datRead.Read = True Then
            txtCDRequisicao.Text = datRead("CDRequisicao")
            txtData.Text = datRead("DTRequisicao")
            txtObs.Text = datRead("Historico")
            txtRequisitante.Text = datRead("Requisitante")
            txtSetor.Text = datRead("Setor")
        End If
        conSQL2.Close()
        selItensReq()
    End Sub
    Public Sub selItensReq()
        '## CASO NAO ENCONTRE NADA EM NENHUM DOS SELECTS ANTERIORES EU EXIBO A GRID EM BRANCO
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        dsReq2.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from ItemReq where CDRequisicao='" & txtCDRequisicao.Text & "' order by CDRequisicao", conSQL2)
        adaptSQL.Fill(dsReq2, "sItemSC")
        Dim dvManager2 As DataViewManager = New DataViewManager(dsReq2)
        Dim dv2 As DataView = dvManager2.CreateDataView(dsReq2.Tables("sItemSC"))
        GridControl1.DataSource = dv2
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Me.Close()
    End Sub
End Class