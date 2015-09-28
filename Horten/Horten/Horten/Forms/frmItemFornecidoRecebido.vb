Imports System.Drawing.Printing
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmItemFornecidoRecebido

    Public datPubsP, datPubsP2, datPubsP3, datPubsP4, datPubsP5, datPubsP6, datPubsP7, datPubsP8, datPubsP9, datPubsP10, datPubsP11 As New DataSet()
    Public datPubsP12, datPubsP13, datPubsP14, datPubsP15 As New DataSet()

    Public conn As PrismaLibrary.ClassSqlConnection = New PrismaLibrary.ClassSqlConnection()
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()


    Private Sub bt0Sair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Sair.Click
        Me.Close()
    End Sub

    Private Sub frmTecidoFornecido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'selItemFor()
        If gB = True Then
            ckContabiliza.Visible = True
        Else
            ckContabiliza.Visible = False
        End If
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        cbStatus.Items.Add("Selecione")
        cbStatus.Items.Add("1 - Aguardando Complemento")
        cbStatus.Items.Add("2 - Aguardando Pagamento")
        cbStatus.Items.Add("3 - Aguardando Tecidos de Outros Itens")
        cbStatus.Items.Add("4 - Identificar Lado Correto")
        cbStatus.Items.Add("5 - Liberado")
        cbStatus.Items.Add("6 - Pendente")
        cbStatus.Items.Add("7 - Aguardando Pedido")
        cbStatus.Items.Add("8 - Reprovado - Aguardando Posição")
        cbStatus.Items.Add("9 - Todos")
        cbStatus.SelectedIndex = 0


        cbStatus2.Items.Add("Selecione")
        cbStatus2.Items.Add("1 - Aguardando Complemento")
        cbStatus2.Items.Add("2 - Aguardando Pagamento")
        cbStatus2.Items.Add("3 - Aguardando Tecidos de Outros Itens")
        cbStatus2.Items.Add("4 - Identificar Lado Correto")
        cbStatus2.Items.Add("5 - Liberado")
        cbStatus2.Items.Add("6 - Pendente")
        cbStatus2.Items.Add("7 - Aguardando Pedido")
        cbStatus2.Items.Add("8 - Reprovado - Aguardando Posição")
        cbStatus2.Items.Add("9 - Todos")
        cbStatus2.SelectedIndex = 6

        desativaCampo()

    End Sub
    Private Sub selItemFor()
        selGrid()
    End Sub
    Private Sub selGrid()
        conSQL2.Open()
        datPubs14.Clear()
        If cbStatus2.SelectedIndex <> 9 Then
            adaptSQL = New SqlClient.SqlDataAdapter("Select * from ItemFornecidoRecebido where Status='" & cbStatus2.SelectedIndex & "'", conSQL2)
        Else
            adaptSQL = New SqlClient.SqlDataAdapter("Select * from ItemFornecidoRecebido ", conSQL2)
        End If
        adaptSQL.Fill(datPubs14, "sTecFor")
        GridControl1.DataSource = datPubs14.Tables("sTecFor")
        GridControl1.Select()
        conSQL2.Close()
    End Sub
    Private Sub bt0Email_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '       frmEmailTecidoFornecido.ShowDialog()
    End Sub

    Private Sub bt0Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Novo.Click
        If bt0Novo.Text = "Novo" Then
            bt0Novo.Text = "Cancelar"
            limpaCampos()
            ativaCampos()
            bt0Incluir.Enabled = True
            txtDescricao.Select()
        Else
            desativaCampo()
            bt0Novo.Text = "Novo"
            bt0Incluir.Enabled = False
        End If
    End Sub
    Public Sub limpaCampos()
        LimpaForm(Me)
        txtDescricao.Select()
        txtData.Text = Date.Now.ToShortDateString()
        cbStatus.SelectedIndex = 6
    End Sub
    Public Sub ativaCampos()
        txtCDControle.Enabled = True
        txtCDPedido.Enabled = True
        txtData.Enabled = True
        txtDescricao.Enabled = True
        txtFornecedor.Enabled = True
        txtItens.Enabled = True
        txtNF.Enabled = True
        txtObs.Enabled = True
        txtQtde.Enabled = True
        txtUM.Enabled = True
        cbStatus.Enabled = True
        txtCDCliente.Enabled = True
        ckContabiliza.Enabled = True
    End Sub
    Public Sub desativaCampo()
        txtCDControle.Enabled = False
        txtCDPedido.Enabled = False
        txtData.Enabled = False
        txtDescricao.Enabled = False
        txtFornecedor.Enabled = False
        txtItens.Enabled = False
        txtNF.Enabled = False
        txtObs.Enabled = False
        txtQtde.Enabled = False
        txtUM.Enabled = False
        cbStatus.Enabled = False
        txtCDCliente.Enabled = False
        ckContabiliza.Enabled = False
    End Sub

    Private Sub bt0Incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Incluir.Click
        '## CHECA SE ROW ESTA EM MODO DE INCLUSAO
        Dim iContabiliza As Integer
        If classParam.selPermissoes(372, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then

            Try
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                If ckContabiliza.Checked = True Then
                    iContabiliza = 1
                Else
                    iContabiliza = 0
                End If
                querySQL2.CommandText = "insert into ItemFornecidoRecebido (CDEmpresa,CDPedido,ItensPedido,Qtde,UM,CDCliente,Data,NF,Fornecedor,Descricao,Obs,Status,Contabiliza) values ('" & _
                                        gEmpresa & "','" & txtCDPedido.Text & "','" & txtItens.Text & "'," & Replace(txtQtde.Text, ",", ".") & ",'" & txtUM.Text & "','" & txtCDCliente.Text & "'," & _
                                        "convert(datetime,'" & txtData.Text & "',103),'" & txtNF.Text & "','" & txtFornecedor.Text & "','" & txtDescricao.Text & "','" & txtObs.Text & "','" & cbStatus.SelectedIndex & "'," & iContabiliza & ")"
                querySQL2.ExecuteNonQuery()
                conSQL2.Close()
                MessageBox.Show("Registro inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                bt0Incluir.Enabled = False

                limpaCampos()
                selGrid()
                XtraTabControl1.SelectedTabPage = XtraTabPage1
                bt0Novo.Text = "Novo"

                '###Envia Email Para o departamento comercial
                'Dim sMail As PrismaLibrary.ClassMail = New PrismaLibrary.ClassMail()
                'Dim sBody, sAssunto As String
                'If iReprovado = 1 Then
                '    '#mandar email para o pcp
                '    sBody = "Olá PCP!<br>Você está recebendo um aviso de REPROVAÇÃO de Tecido: <br>Pedido Nº: " & sCDPedido & "<br>Produto: " & sCDProduto & " - " & sDescricao & "<br>Fornecedor: " & sFornecedor
                '    sAssunto = "Reprovação de Tecido Fornecido - Pedido Nº: " & sCDPedido
                'Else
                '    sBody = "Olá PCP!<br>Você está recebendo um aviso de APROVAÇÃO de Tecido: <br>Pedido Nº: " & sCDPedido & "<br>Produto: " & sCDProduto & " - " & sDescricao & "<br>Fornecedor: " & sFornecedor
                '    sAssunto = "Aprovação de Tecido Fornecido - Pedido Nº: " & sCDPedido
                'End If
                'sMail.SendMailMessage(gUsuario & "@" & gDominio, "rodrigo@classica.com.br,bruno@classica.com.br", "", "", sAssunto, sBody, "", "")
                desativaCampo()
            Catch ex As Exception
                MessageBox.Show("Houve um erro na inclusão. Erro: " & ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        Else
            MessageBox.Show("Você não tem acesso a essa opção, contacte o administrador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub cbStatus2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStatus2.SelectedIndexChanged
        selGrid()
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        ativaCampos()
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        XtraTabControl1.SelectedTabPage = XtraTabPage2
        Try
            txtCDControle.Text = row("CDControle")
        Catch
        End Try
        Try
            txtDescricao.Text = row("Descricao")
        Catch
        End Try
        Try
            txtData.Text = row("Data")
        Catch
        End Try
        Try
            txtFornecedor.Text = row("Fornecedor")
        Catch
        End Try
        Try
            txtNF.Text = row("NF")
        Catch
        End Try
        Try
            txtObs.Text = row("Obs")
        Catch
        End Try
        Try
            txtQtde.Text = row("Qtde")
        Catch
        End Try
        Try
            txtUM.Text = row("UM")
        Catch
        End Try
        Try
            txtCDCliente.Text = row("CDCliente")
        Catch
        End Try
        Try
            cbStatus.SelectedIndex = row("Status")
        Catch
        End Try
        Try
            txtCDPedido.Text = row("CDPedido")
        Catch ex As Exception
        End Try
        Try
            txtItens.Text = row("ItensPedido")
        Catch ex As Exception
        End Try
        Try
            If row("Contabiliza") = True Then
                ckContabiliza.Checked = True
            Else
                ckContabiliza.Checked = False
            End If
        Catch ex As Exception
            ckContabiliza.Checked = False
        End Try

    End Sub

    Private Sub bt0Alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Alterar.Click
        If classParam.selPermissoes(373, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            If txtCDControle.Text <> "" Then
                '## CHECA SE ROW ESTA EM MODO DE INCLUSAO
                Dim iContabiliza As Integer
                Try
                    If ckContabiliza.Checked = True Then
                        iContabiliza = 1
                    Else
                        iContabiliza = 0
                    End If
                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2
                    querySQL2.CommandText = "Update ItemFornecidoRecebido SET ItensPedido='" & txtItens.Text & "', Contabiliza=" & iContabiliza & ", Qtde=" & Replace(txtQtde.Text, ",", ".") & ",CDPedido='" & txtCDPedido.Text & "',CDCliente='" & txtCDCliente.Text & "',NF='" & txtNF.Text & "',Fornecedor='" & txtFornecedor.Text & "',Descricao='" & txtDescricao.Text & "',Obs='" & txtObs.Text & "', Status='" & cbStatus.SelectedIndex() & "',Data=convert(datetime,'" & txtData.Text & "',103) where CDControle='" & txtCDControle.Text & "'"
                    querySQL2.ExecuteNonQuery()
                    conSQL2.Close()
                    MessageBox.Show("Registro alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    selGrid()
                    limpaCampos()
                    XtraTabControl1.SelectedTabPage = XtraTabPage1
                    desativaCampo()
                Catch ex As Exception
                    MessageBox.Show("Houve um erro na atualização. Erro: " & ex.Message(), "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                End Try
            Else
                MessageBox.Show("Selecione um Registro para ser Alterado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção, contacte o administrador!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub bt0Excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Excluir.Click
        If classParam.selPermissoes(374, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            If txtCDControle.Text <> "" Then
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                Try
                    Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                    querySQl.Connection = conSQL
                    querySQl.CommandText = "delete from ItemFornecidoRecebido where CDControle ='" & txtCDControle.Text & "' and CDEmpresa='" & gEmpresa & "'"
                    querySQl.ExecuteNonQuery()
                    MessageBox.Show("Registro excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    selGrid()
                    limpaCampos()
                    XtraTabControl1.SelectedTabPage = XtraTabPage1
                    desativaCampo()
                Catch
                    MessageBox.Show("Houve um erro ao deletar o item!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
                conSQL.Close()
            Else
                MessageBox.Show("Selecione um Registro para ser Excluído.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção, contacte o administrador!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtCDControle.Text <> "" Then
            Dim r As RelItemFornecidoRecebido = New RelItemFornecidoRecebido(txtCDControle.Text)
            r.Print()
            r.Print()
        Else
            MessageBox.Show("Selecione um tecido para imprimir a etiqueta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class