Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmSolicitacaoCompra
    Public dsSC, dsSC2 As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Public datPubsFornecSC1, datPubsSCCC, datPubsSCPC, datPubsSCRep As New DataSet()
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0IncluirEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Incluir.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQl.Connection = conSQL2

        Try
            querySQl.CommandText = "Select top 1 CDSC from SC order by CDSC desc"
            Dim iUltima As Integer = querySQl.ExecuteScalar()
            Dim sUltima As String
            iUltima += 1
            sUltima = iUltima.ToString


            gVSQL = "Insert into SC (CDSC,DTSC,CDFornec,CDPC,CDCC,CDSolicitante,Prioridade,DTEntrega,Status,Obs) values "
            gVSQL &= "('" & sUltima.PadLeft(6, "0") & "',convert(datetime,'" & Date.Now.ToShortDateString() & "',103),'" & cbFornec.SelectedValue & "','" & cbCDPC.SelectedValue & "','"
            gVSQL &= cbCDCC.SelectedValue & "','" & txtRequisitante.Text & "','" & cbPrioridade.SelectedIndex & "',convert(datetime,'" & txtDTEntrega.Text & "',103),0,'" & txtObs.Text & "')"

            querySQl.CommandText = gVSQL
            querySQl.ExecuteNonQuery()

            txtCDSC.Text = sUltima.PadLeft(6, "0")
            MessageBox.Show("Cabeçalho da Solicitação criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Catch
            MessageBox.Show("Erro ao incluir o cabeçalho da requisição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conSQL2.Close()
    End Sub

    Private Sub frmRequisicaoMaterial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbPrioridade.Items.Add("Baixa")
        cbPrioridade.Items.Add("Media")
        cbPrioridade.Items.Add("Alta")
        cbPrioridade.SelectedIndex = 1

        cbCampo.Items.Add("Fornecedor")
        cbCampo.Items.Add("Nº Solicitação")
        cbCampo.Items.Add("Solicitante")
        cbCampo.SelectedIndex = 1

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        'CARREGA Tipo de Endereco
        dsSC.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select * from ItemSC where CDSC='" & txtCDSC.Text & "'", conSQL2)
        adaptSQL.Fill(dsSC, "ItemSC")
        GridControl1.DataSource = dsSC.Tables("ItemSC")
        GridControl1.Select()

        dsSC.Clear()

        datPubsFornecSC1.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Fantasia from Fornecedores order By Fantasia", conSQL2)
        adaptSQL.Fill(datPubsFornecSC1, "Fornecedor")
        cbFornec.DataSource = datPubsFornecSC1.Tables("Fornecedor")
        cbFornec.DisplayMember = "Fantasia"
        cbFornec.ValueMember = "CDFornec"

        datPubsSCCC.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select Descricao,CDCC from CentrosDeCustos order By Descricao", conSQL2)
        adaptSQL.Fill(datPubsSCCC, "sCC")
        cbCDCC.DataSource = datPubsSCCC.Tables("sCC")
        cbCDCC.DisplayMember = "Descricao"
        cbCDCC.ValueMember = "CDCC"

        datPubsSCPC.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select Descricao, CDPC from PlanoDeContas order By Descricao", conSQL2)
        adaptSQL.Fill(datPubsSCPC, "sCP")
        cbCDPC.DataSource = datPubsSCPC.Tables("sCP")
        cbCDPC.DisplayMember = "Descricao"
        cbCDPC.ValueMember = "CDPC"


    End Sub

    Private Sub bt0NovoEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0NovoEndereco.Click
        If bt0NovoEndereco.Text = "Novo" Then
            limpaCampos()
            txtData.Text = Date.Now.ToShortDateString()
            cbFornec.Select()
            txtRequisitante.Text = gUsuario.ToUpper()
            bt0Incluir.Enabled = True
            btAlterar.Enabled = False
            btExcluir.Enabled = False
            bt0NovoEndereco.Text = "Cancelar"
        Else
            bt0NovoEndereco.Text = "Novo"
            bt0Incluir.Enabled = False
        End If
    End Sub
    Public Sub limpaCampos()
        txtRequisitante.Text = ""
        txtObs.Text = ""
        txtCDSC.Text = ""
        cbCDCC.SelectedValue = 0
        cbCDPC.SelectedValue = 0
        txtDTEntrega.Text = ""
        cbFornec.SelectedValue = 0
    End Sub


    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2
            Try
                querySQL2.CommandText = "delete from ItemSC where CDMaterial ='" & row("CDMaterial") & "' and CDSC='" & txtCDSC.Text & "'"
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
        '## CHECA SE ROW ESTA EM MODO DE INCLUSAO
        Try
            If row.RowState = DataRowState.Added Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                Try
                    querySQL2.CommandText = "select max(CDItem) as Codigo from ItemSC where CDSC='" & txtCDSC.Text & "'"
                    Try
                        iItem = querySQL2.ExecuteScalar()
                        iItem += 1
                    Catch
                        iItem = 1
                    End Try

                    querySQL2.CommandText = "Insert into ItemSC (CDSC,CDMaterial,Qtde,Unidade,CDItem,Descricao) values ('" & txtCDSC.Text & "','" & row("CDMaterial") & "'," & Replace(row("Qtde"), ",", ".") & ",'" & row("Unidade") & "','" & iItem & "','" & row("Descricao") & "')"
                    querySQL2.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQL2.Close()
            End If
        Catch
        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As GridView = sender
        If e.Column.FieldName = "CDMaterial" Then
            Dim sCDProduto As String = View.EditingValue
            'Fazer select em Estoque
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL

            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2

            querySQl.CommandText = "Select * from Estoque where CDProduto='" & sCDProduto & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "Unidade", datRead("Unidade"))
                View.SetRowCellValue(e.RowHandle, "Descricao", datRead("Descricao"))
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim xtra As XtraSolicitacao = New XtraSolicitacao(txtCDSC.Text)
        xtra.ShowPreview()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscar.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        If cbCampo.SelectedIndex = 0 Then
            gVSQL = "Select a.CDSC,a.DTSC,b.Fantasia as Descricao from SC a, Fornecedores b where a.CDFornec=b.CDFornec and b.Fantasia like '%" & txtChave.Text & "%' order by a.CDSC desc"
        ElseIf cbCampo.SelectedIndex = 1 Then
            gVSQL = "Select CDSC,DTSC,CDSolicitante as Descricao from SC where CDSC like '%" & txtChave.Text & "%' order by CDSC desc"
        ElseIf cbCampo.SelectedIndex = 2 Then
            gVSQL = "Select CDSC,DTSC,CDSolicitante as Descricao from SC where CDSolicitante like '%" & txtChave.Text & "%'  order by CDSC desc "
        End If
        dsSC.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsSC, "Busca")
        GridBusca.DataSource = dsSC.Tables("Busca")
    End Sub

    Private Sub GridBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBusca.Click
        selBusca()
    End Sub
    Public Sub selBusca()
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        querySQL2.CommandText = "Select * from SC where CDSC='" & row("CDSC") & "'"
        datRead = querySQL2.ExecuteReader()
        If datRead.Read = True Then
            txtCDSC.Text = datRead("CDSC")
            txtData.Text = datRead("DTSC")
            txtObs.Text = datRead("Obs")
            txtDTEntrega.Text = datRead("DTEntrega")
            Try
                cbFornec.SelectedValue = datRead("CDFornec")
            Catch
            End Try
            Try
                cbCDCC.SelectedValue = datRead("CDCC")
            Catch
            End Try
            Try
                cbCDPC.SelectedValue = datRead("CDPC")
            Catch
            End Try
            txtRequisitante.Text = datRead("CDSolicitante")
        End If
        btAlterar.Enabled = True
        btExcluir.Enabled = True

        conSQL2.Close()
        selItensSC()
    End Sub
    Public Sub selItensSC()
        '## CASO NAO ENCONTRE NADA EM NENHUM DOS SELECTS ANTERIORES EU EXIBO A GRID EM BRANCO
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        dsSC2.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from ItemSC where CDSC='" & txtCDSC.Text & "' order by CDItem", conSQL2)
        adaptSQL.Fill(dsSC2, "sItemSC")
        Dim dvManager2 As DataViewManager = New DataViewManager(dsSC2)
        Dim dv2 As DataView = dvManager2.CreateDataView(dsSC2.Tables("sItemSC"))
        GridControl1.DataSource = dv2
    End Sub

    Private Sub GridBusca_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridBusca.KeyUp
        selBusca()
    End Sub

    Private Sub btAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAlterar.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQl.Connection = conSQL2

        Try
            gVSQL = "update SC set CDFornec='" & cbFornec.SelectedValue & "',CDPC='" & cbCDPC.SelectedValue & "',CDCC='" & cbCDCC.SelectedValue & "',Prioridade='" & cbPrioridade.SelectedIndex & "',DTEntrega=convert(datetime,'" & txtDTEntrega.Text & "',103),Obs='" & txtObs.Text & "' where CDSC='" & txtCDSC.Text & "'"
            querySQl.CommandText = gVSQL
            querySQl.ExecuteNonQuery()
            MessageBox.Show("Cabeçalho da Solicitação alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Catch
            MessageBox.Show("Erro ao alterar o cabeçalho da requisição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        limpaCampos()
        conSQL2.Close()
    End Sub

    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        If classParam.selPermissoes(349, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQl.Connection = conSQL2
            Try
                querySQl.CommandText = "delete from SC where CDSC='" & txtCDSC.Text & "'"
                querySQl.ExecuteNonQuery()
                querySQl.CommandText = "delete from itemSC where CDSC='" & txtCDSC.Text & "'"
                querySQl.ExecuteNonQuery()
                MessageBox.Show("Solicitação excluida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Catch
                MessageBox.Show("Erro ao excluir a requisição!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            conSQL2.Close()
            limpaCampos()
        Else
            MessageBox.Show("Você não tem autorização para excluir Solicitações, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        '## CHECA SE ROW ESTA EM MODO DE UPDATE
        If row.RowState = DataRowState.Modified Then
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQl.Connection = conSQL2
            Try
                gVSQL = "update ItemSC set CDMaterial='" & row("CDMaterial") & "',Qtde='" & Replace(row("Qtde"), ",", ".") & "',Unidade='" & row("Unidade") & "',Descricao='" & row("Descricao") & "' where CDSC='" & txtCDSC.Text & "' and CDItem='" & row("CDItem") & "'"
                querySQl.CommandText = gVSQL
                querySQl.ExecuteNonQuery()
            Catch
            End Try
            conSQL2.Close()
        End If
    End Sub
End Class