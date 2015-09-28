Imports DevExpress.XtraReports.UI
Public Class frmManutencaoEstoque
    Public datPubsEstoque, datPubsComprador, datPubsFornec1, datPubsFornec2, datPubsFornec3, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub frmManutencaoEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbTipoEstoque.Items.Add("0 - Todos os Itens")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 2

        cbTipoEstoque2.Items.Add("0 - Todos os Itens")
        cbTipoEstoque2.Items.Add("1 - Material Acabado")
        cbTipoEstoque2.Items.Add("2 - Matéria Prima")
        cbTipoEstoque2.Items.Add("3 - Material de Consumo")
        cbTipoEstoque2.Items.Add("4 - Subconjunto")
        cbTipoEstoque2.Items.Add("5 - Embalagem")

        cbBuscarPor.Items.Add("Código")
        cbBuscarPor.Items.Add("Descrição")
        cbBuscarPor.Items.Add("Endereço")
        cbBuscarPor.SelectedIndex = 0

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        datPubsComprador.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDVendedor,NMFantasia from Vendedores order By NMFantasia", conSQL2)
        adaptSQL.Fill(datPubsComprador, "Comprador")
        cbCDComprador.DataSource = datPubsComprador.Tables("Comprador")
        cbCDComprador.DisplayMember = "NMFantasia"
        cbCDComprador.ValueMember = "CDVendedor"

        datPubsFornec1.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec1, "Fornecedor")
        cbFornec1.DataSource = datPubsFornec1.Tables("Fornecedor")
        cbFornec1.DisplayMember = "Nome"
        cbFornec1.ValueMember = "CDFornec"

        datPubsFornec2.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec2, "Fornecedor")
        cbFornec2.DataSource = datPubsFornec2.Tables("Fornecedor")
        cbFornec2.DisplayMember = "Nome"
        cbFornec2.ValueMember = "CDFornec"

        datPubsFornec3.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec3, "Fornecedor")
        cbFornec3.DataSource = datPubsFornec3.Tables("Fornecedor")
        cbFornec3.DisplayMember = "Nome"
        cbFornec3.ValueMember = "CDFornec"

        datPubsFornec4.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec4, "Fornecedor")
        cbFornec4.DataSource = datPubsFornec4.Tables("Fornecedor")
        cbFornec4.DisplayMember = "Nome"
        cbFornec4.ValueMember = "CDFornec"

        datPubsFornec5.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec5, "Fornecedor")
        cbFornec5.DataSource = datPubsFornec5.Tables("Fornecedor")
        cbFornec5.DisplayMember = "Nome"
        cbFornec5.ValueMember = "CDFornec"

        datPubsClassF.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from ClassificacaoFiscal order By Descricao", conSQL2)
        adaptSQL.Fill(datPubsClassF, "ClassF")
        cbCDClasf.DataSource = datPubsClassF.Tables("ClassF")
        cbCDClasf.DisplayMember = "Descricao"
        cbCDClasf.ValueMember = "CDClasf"

        txtFiltro.Select()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Public Sub busca()
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        Dim sBusca As String = ""
        Dim sEstoque As String = ""

        sBusca = "Where 1=1 "
        If cbBuscarPor.SelectedIndex = 0 Then
            sBusca &= " and Estoque.CDProduto like '%" & txtFiltro.Text & "%' "
        ElseIf cbBuscarPor.SelectedIndex = 1 Then
            sBusca &= " and Descricao like '%" & txtFiltro.Text & "%' "
        ElseIf cbBuscarPor.SelectedIndex = 2 Then
            sBusca &= " And Endereco like '%" & txtFiltro.Text & "%' "
        End If
        If cbTipoEstoque.SelectedItem() <> "" Then
            sEstoque = cbTipoEstoque.SelectedItem()
            sBusca &= " And Estoque='" & sEstoque.Substring(0, 1) & "' "
        End If

        If radioCodigo.Checked = True Then
            sBusca &= " Order By CDProduto "
        Else
            sBusca &= " Order By Descricao "
        End If
        'CARREGA Tipo de Endereco
        datPubsEstoque.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select Estoque.CDProduto,Descricao,Endereco From Estoque Left Join EstoqueEndereco On Estoque.CDProduto = EstoqueEndereco.CDProduto " & sBusca, conSQL2)
        adaptSQL.Fill(datPubsEstoque, "TipoEnd")
        GridBusca.DataSource = datPubsEstoque.Tables("TipoEnd")
        GridBusca.Select()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        busca()
    End Sub

    Public Sub selDados()
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDProduto As String
        Try
            sCDProduto = row("CDProduto")
        Catch ex As Exception
            sCDProduto = ""
        End Try
        If sCDProduto <> "" Then
            Dim dMinimo, dMaximo, dQtde As Decimal
            Dim sTipoCalculo As String = "N"
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandText = "Select * from Estoque where CDProduto='" & sCDProduto & "'"

            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2

            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                txtCDProduto.Text = datRead("CDProduto")
                Try
                    txtCDVelho.Text = datRead("CDVelho")
                Catch
                    txtCDVelho.Text = ""
                End Try
                txtDescricao.Text = datRead("Descricao")
                Try
                    txtCoeficiente.Text = datRead("Coeficiente")
                Catch
                    txtCoeficiente.Text = "0"
                End Try
                Try
                    txtLeadTime.Text = datRead("LeadTime")
                Catch
                    txtLeadTime.Text = "0"
                End Try

                Try
                    txtDua.Text = datRead("DUA")
                Catch ex As Exception
                End Try


                Try
                    querySQL2.CommandText = "Select Top 1 Saldo From Kardex Where CDProduto = '" & datRead("CDProduto") & "' Order By Registro Desc"
                    txtQtde.Text = querySQL2.ExecuteScalar()
                    If txtQtde.Text = "" Then
                        txtQtde.Text = "0"
                    End If
                Catch
                    txtQtde.Text = "0"
                End Try
                Try
                    querySQL2.CommandText = "Select Top 1 Saldo From Kardex2 Where CDProduto = '" & datRead("CDProduto") & "' Order By Registro Desc"
                    txtEmpenho.Text = querySQL2.ExecuteScalar()
                    If txtEmpenho.Text = "" Then
                        txtEmpenho.Text = "0"
                    End If
                Catch
                    txtEmpenho.Text = "0"
                End Try



                Try
                    dMaximo = datRead("Maximo")
                    txtMaximo.Text = dMaximo.ToString("#####0.00")
                Catch
                    txtMaximo.Text = "0"
                End Try
                Try
                    txtQtdeMin.Text = datRead("QtdeMin")
                Catch
                    txtQtdeMin.Text = "0"
                End Try
                Try
                    dMinimo = datRead("Minimo")
                    txtMinimo.Text = dMinimo.ToString("#####0.00")
                Catch
                    txtMinimo.Text = "0"
                End Try
                Try
                    txtQtdeMax.Text = datRead("QtdeMax")
                Catch
                    txtQtdeMax.Text = "0"
                End Try

                Try
                    txtUnidade.Text = datRead("Unidade")
                Catch
                    txtUnidade.Text = ""
                End Try
                Try
                    txtValor.Text = datRead("Valor")
                Catch
                    txtValor.Text = "0"
                End Try
                Try
                    cbCDClasf.SelectedValue = datRead("CDClasf")
                Catch
                    cbCDClasf.SelectedItem = -1
                End Try
                Try
                    cbFornec1.SelectedValue = datRead("CDFornec1")
                Catch
                    cbFornec1.SelectedIndex = -1
                End Try
                Try
                    cbFornec2.SelectedValue = datRead("CDFornec2")
                Catch
                    cbFornec2.SelectedIndex = -1
                End Try
                Try
                    cbFornec3.SelectedValue = datRead("CDFornec3")
                Catch
                    cbFornec3.SelectedIndex = -1
                End Try
                Try
                    cbFornec4.SelectedValue = datRead("CDFornec4")
                Catch
                    cbFornec4.SelectedIndex = -1
                End Try
                Try
                    cbFornec5.SelectedValue = datRead("CDFornec5")
                Catch
                    cbFornec5.SelectedIndex = -1
                End Try
                Try
                    txtEspecificacao.Text = datRead("Especificacao")
                Catch ex As Exception
                    txtEspecificacao.Text = ""
                End Try
                Try
                    cbCDComprador.SelectedValue = datRead("CDComprador")
                Catch ex As Exception
                    cbCDComprador.SelectedItem = -1
                End Try
                Try
                    txtDTCalculo.Text = datRead("DTCalculo")
                Catch ex As Exception
                    txtDTCalculo.Text = ""
                End Try
                Try
                    txtValidade.Text = datRead("Validade")
                Catch ex As Exception
                    txtValidade.Text = "0"
                End Try
                Try
                    sTipoCalculo = datRead("TipoCalculo")
                Catch ex As Exception
                    sTipoCalculo = "N"
                End Try
                If sTipoCalculo = "S" Then
                    ckEstoqueMin.Checked = True
                Else
                    ckEstoqueMin.Checked = False
                End If
                Try
                    txtDTUltCom.Text = datRead("DTUltCom")
                Catch ex As Exception
                    txtDTUltCom.Text = ""
                End Try
                Try
                    txtQtdeUltCom.Text = datRead("QTUltCom")
                Catch ex As Exception
                    txtQtdeUltCom.Text = "0"
                End Try

                Try
                    txtTara.Text = datRead("Tara")
                Catch ex As Exception
                    txtTara.Text = "0"
                End Try
                Try
                    txtMultiplicador.Text = datRead("Multiplicador")
                Catch ex As Exception
                    txtMultiplicador.Text = "0"
                End Try

                Try
                    txtVLUnitUltCom.Text = datRead("VLUltCom")
                Catch ex As Exception
                    txtVLUnitUltCom.Text = "0"
                End Try
                Try
                    cbTipoEstoque2.SelectedIndex = datRead("Estoque")
                Catch ex As Exception
                    cbTipoEstoque2.SelectedIndex = -1
                End Try
                Try
                    txtObservacao.Text = datRead("Observacao")
                Catch ex As Exception
                    txtObservacao.Text = ""
                End Try

                Dim bIdle As Boolean
                Try
                    bIdle = datRead("Idle")
                    ckCodigoDesativado.Checked = bIdle
                Catch ex As Exception
                    ckCodigoDesativado.Checked = True
                End Try
                Try
                    txtCurvaAbc.Text = datRead("ClassificacaoABC")
                    If txtCurvaAbc.Text = "A" Then
                        txtCurvaAbc.BackColor = Color.LightBlue
                    ElseIf txtCurvaAbc.Text = "B" Then
                        txtCurvaAbc.BackColor = Color.Gold
                    ElseIf txtCurvaAbc.Text = "C" Then
                        txtCurvaAbc.BackColor = Color.LightPink
                    Else
                        txtCurvaAbc.BackColor = Color.LightGray
                    End If
                Catch ex As Exception
                    txtCurvaAbc.Text = ""
                End Try
            End If
            datRead.Close()
            datPubsEstoqueEndereco.Clear()
            Try
                adaptSQL = New SqlClient.SqlDataAdapter("Select * from EstoqueEndereco where CDProduto='" & txtCDProduto.Text & "'", conSQL2)
                adaptSQL.Fill(datPubsEstoqueEndereco, "TipoEnd")
                GridEndereco.DataSource = datPubsEstoqueEndereco.Tables("TipoEnd")
            Catch
            End Try
            conSQL.Close()
            conSQL2.Close()
        End If
    End Sub
    Private Sub GridBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBusca.Click
        selDados()
    End Sub

    Private Sub GridBusca_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridBusca.KeyUp
        selDados()
    End Sub

    Private Sub bt0Novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Novo.Click
        If bt0Novo.Text = "Novo" Then
            txtCDProduto.Enabled = True
            txtCDProduto.Select()
            txtCDVelho.Enabled = True
            bt0Incluir.Enabled = True
            bt0Novo.Text = "Cancelar"

            limpaForm()
        ElseIf bt0Novo.Text = "Cancelar" Then
            txtCDProduto.Enabled = False
            txtCDVelho.Enabled = False
            bt0Incluir.Enabled = False
            bt0Novo.Text = "Novo"
        End If
    End Sub
    Public Sub limpaForm()
        txtCDProduto.Text = ""
        txtCDVelho.Text = ""
        txtDescricao.Text = ""
        txtCoeficiente.Text = "0"
        txtCustoMedio.Text = "0"
        txtEspecificacao.Text = ""
        txtLeadTime.Text = "0"
        txtMaximo.Text = "0"
        txtMinimo.Text = "0"
        txtEmpenho.Text = "0"
        txtQtde.Text = "0"
        txtQtdeMax.Text = "0"
        txtQtdeMin.Text = "0"
        txtUnidade.Text = ""
        txtValidade.Text = "0"
        txtValor.Text = "0"
        txtDTCalculo.Text = ""
        cbFornec1.SelectedIndex = -1
        cbFornec2.SelectedIndex = -1
        cbFornec3.SelectedIndex = -1
        cbFornec4.SelectedIndex = -1
        cbFornec5.SelectedIndex = -1
        cbCDClasf.SelectedIndex = -1
        cbCDComprador.SelectedIndex = -1
        ckCodigoDesativado.Checked = False
        datPubsEstoqueEndereco.Clear()
        txtTara.Text = "0"
        txtMultiplicador.Text = "0"
    End Sub

    Private Sub bt0Incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Incluir.Click
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        Dim sTipoCalculo As String = "N"
        Dim bIncluir As Boolean = True
        Try
            If txtUnidade.Text = "" Then
                MessageBox.Show("Preencha o campo UNIDADE", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bIncluir = False
            ElseIf txtCDProduto.Text = "" Then
                MessageBox.Show("Preencha o campo CODIGO", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bIncluir = False
            ElseIf txtDescricao.Text = "" Then
                MessageBox.Show("Preencha o campo DESCRIÇÃO", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bIncluir = False
            ElseIf cbTipoEstoque2.SelectedIndex = 0 Or cbTipoEstoque2.SelectedIndex = -1 Then
                MessageBox.Show("Selecione o TIPO DE ESTOQUE", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bIncluir = False
            End If
            If bIncluir = True Then
                If ckEstoqueMin.Checked = True Then
                    sTipoCalculo = "S"
                End If
                Dim iProdutoRevenda As Integer = 0
                If ckProdutoRevenda.Checked = True Then
                    iProdutoRevenda = 1
                End If
                '## Insere Itens no Estoque
                gVSQL = "INSERT INTO Prisma.dbo.Estoque (CDProduto,CDVelho,Estoque,Descricao,Unidade,Qtde,Empenho,Valor,Validade,CDComprador,CustoMedio,Coeficiente,Tara,Multiplicador,CDFornec1,CDFornec2,CDFornec3"
                gVSQL &= ",CDFornec4,CDFornec5,DTUltCom,QTUltCom,VLUltCom,ClassificacaoABC,CDClasf,CDCTB,Maximo,Minimo,QtdeMax,QtdeMin,DTBase,LeadTime,Dua,VLFrete,Total,ExibirInternet,Foto,"
                gVSQL &= "Lancamento,Idle,TipoCalculo,DTCalculo,Especificacao,Observacao,ProdutoRevenda) VALUES ('" & txtCDProduto.Text & "','" & txtCDVelho.Text & "','" & cbTipoEstoque2.SelectedIndex & "','" & txtDescricao.Text & "',"
                gVSQL &= "'" & txtUnidade.Text & "'," & Replace(txtQtde.Text, ",", ".") & "," & Replace(txtEmpenho.Text, ",", ".") & "," & Replace(txtValor.Text, ",", ".") & ",'" & txtValidade.Text & "','" & cbCDComprador.SelectedValue & "',"
                gVSQL &= Replace(txtCustoMedio.Text, ",", ".") & "," & Replace(txtCoeficiente.Text, ",", ".") & "," & Replace(txtTara.Text, ",", ".") & "," & Replace(txtMultiplicador.Text, ",", ".") & ",'" & cbFornec1.SelectedValue & "','" & cbFornec2.SelectedValue & "','" & cbFornec3.SelectedValue & "',"
                gVSQL &= "'" & cbFornec4.SelectedValue & "','" & cbFornec5.SelectedValue & "',NULL,0,NULL,'','" & cbCDClasf.SelectedValue & "',NULL," & Replace(txtMaximo.Text, ",", ".") & "," & Replace(txtMinimo.Text, ",", ".") & "," & Replace(txtQtdeMax.Text, ",", ".") & "," & Replace(txtQtdeMin.Text, ",", ".") & ",NULL,"
                gVSQL &= "'" & txtLeadTime.Text & "',NULL,0,0,0,NULL,0,0,'" & sTipoCalculo & "',NULL,'" & txtEspecificacao.Text & "','" & txtObservacao.Text & "'," & iProdutoRevenda & ")"

                querySQl.CommandText = gVSQL
                querySQl.ExecuteNonQuery()


                '#### Saida de Sub-CJ do Kardex
                conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL4.Open()
                querySQLProc.Connection = conSQL4
                querySQLProc.CommandType = CommandType.StoredProcedure
                querySQLProc.CommandText = "sp_Kardex"
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", txtCDProduto.Text))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(0, ",", ".")))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", txtDescricao.Text))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", "IPA"))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Lanç. Automatico, Cadastro no sistema "))
                querySQLProc.ExecuteNonQuery()
                querySQLProc.Parameters.Clear()
                conSQL4.Close()


                MessageBox.Show("Registro incluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                bt0Novo.Text = "Novo"
            End If
        Catch ex As Exception
            MessageBox.Show("Houve um erro na inclusão: " & ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conSQL.Close()
    End Sub


    Private Sub GridView2_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.RowCountChanged
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        Dim sCDProduto, sBairro, sEndereco, sObservacao As String
        '## CHECA SE ROW ESTA EM MODO DE INCLUSAO
        Try
            If row.RowState = DataRowState.Added Then
                Try
                    sObservacao = row("Observacao")
                Catch
                    sObservacao = ""
                End Try
                Try
                    sCDProduto = txtCDProduto.Text
                Catch ex As Exception
                    sCDProduto = ""
                End Try
                Try
                    sBairro = row("Bairro")
                Catch ex As Exception
                    sBairro = ""
                End Try
                Try
                    sEndereco = row("Endereco")
                Catch ex As Exception
                    sEndereco = ""
                End Try
                querySQl.CommandText = "Insert Into Prisma.dbo.EstoqueEndereco (CDProduto,Bairro,Endereco,Observacao) values ('" & sCDProduto & "','" & sBairro & "','" & sEndereco & "','" & sObservacao & "')"
                querySQl.ExecuteNonQuery()
            End If
        Catch ex As Exception
            'MessageBox.Show("Houve um erro na inclusão do endereço do estoque: " & ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conSQL.Close()
    End Sub

    Private Sub bt0Alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Alterar.Click
        If classParam.selPermissoes(257, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            If txtCDProduto.Text <> "" Then
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                querySQl.Connection = conSQL
                Try
                    If txtEmpenho.Text = "" Then
                        txtEmpenho.Text = "0"
                    End If
                    gVSQL = "UPDATE Estoque SET CDVelho='" & txtCDVelho.Text & "', Estoque = '" & cbTipoEstoque2.SelectedIndex & "', Descricao='" & txtDescricao.Text & "',Unidade='" & txtUnidade.Text & "'"
                    gVSQL &= ",Qtde=" & Replace(txtQtde.Text, ",", ".") & ",Empenho=" & Replace(txtEmpenho.Text, ",", ".") & ",Valor=" & Replace(txtValor.Text, ",", ".") & ",Validade=" & txtValidade.Text & ",CDComprador='" & cbCDComprador.SelectedValue & "'"
                    gVSQL &= ",CustoMedio='" & Replace(txtCustoMedio.Text, ",", ".") & "',Coeficiente='" & Replace(txtCoeficiente.Text, ",", ".") & "',Tara='" & Replace(txtTara.Text, ",", ".") & "',Multiplicador='" & Replace(txtMultiplicador.Text, ",", ".") & "',CDFornec1='" & cbFornec1.SelectedValue & "'"
                    gVSQL &= ",CDFornec2='" & cbFornec2.SelectedValue & "',CDFornec3='" & cbFornec3.SelectedValue & "',CDFornec4='" & cbFornec4.SelectedValue & "',CDFornec5='" & cbFornec5.SelectedValue & "'"
                    If txtDTUltCom.Text <> "" Then
                        gVSQL &= ",DTUltCom=convert(datetime,'" & txtDTUltCom.Text & "',103)"
                    End If
                    gVSQL &= ",QTUltCom='" & Replace(txtQtdeUltCom.Text, ",", ".") & "',VLUltCom='" & Replace(txtVLUnitUltCom.Text, ",", ".") & "',CDClasf='" & cbCDClasf.SelectedValue & "'"
                    gVSQL &= ",Maximo='" & Replace(txtMaximo.Text, ",", ".") & "',QtdeMax='" & Replace(txtQtdeMax.Text, ",", ".") & "',Minimo=" & Replace(txtMinimo.Text, ",", ".") & ",QtdeMin='" & Replace(txtQtdeMin.Text, ",", ".") & "'"
                    gVSQL &= ",LeadTime='" & txtLeadTime.Text & "',Dua=convert(datetime,'" & Date.Now.ToShortDateString() & "',103)"


                    If ckCodigoDesativado.Checked = True Then
                        If classParam.selPermissoes(256, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                            gVSQL &= ",Idle=1"

                        Else
                            MessageBox.Show("Você não tem permissão para desativar o codigo do item. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        gVSQL &= ",Idle=0"
                    End If

                    If ckEstoqueMin.Checked = True Then
                        gVSQL &= ",TipoCalculo='S'"
                    Else
                        gVSQL &= ",TipoCalculo='N'"
                    End If

                    If ckProdutoRevenda.Checked = True Then
                        gVSQL &= ",ProdutoRevenda=1 "
                    Else
                        gVSQL &= ",ProdutoRevenda=0 "
                    End If

                    gVSQL &= ",Especificacao='" & txtEspecificacao.Text & "', Observacao='" & txtObservacao.Text & "' WHERE CDProduto='" & txtCDProduto.Text & "'"


                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()
                    MessageBox.Show("Registro alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    limpaForm()
                Catch ex As Exception
                    MessageBox.Show("Houve um erro na alteração: " & ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQL.Close()
            Else
                MessageBox.Show("Selecione um registro antes de alterar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub bt0Excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Excluir.Click
        If classParam.selPermissoes(255, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            If txtCDProduto.Text <> "" Then
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                querySQl.Connection = conSQL
                Try
                    gVSQL = "Delete from Estoque Where CDProduto='" & txtCDProduto.Text & "' and Estoque='" & cbTipoEstoque2.SelectedIndex & "'"
                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()

                    querySQl.CommandText = "Delete from Prisma.dbo.EstoqueEndereco where CDProduto='" & txtCDProduto.Text & "'"
                    querySQl.ExecuteNonQuery()

                    MessageBox.Show("Registro Excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    limpaForm()
                Catch ex As Exception
                    MessageBox.Show("Houve um erro na Exclusão: " & ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQL.Close()
                busca()

            Else
                MessageBox.Show("Selecione um registro!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub GridEndereco_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEndereco.KeyUp
        If e.KeyCode = Keys.Delete Then
            Try
                Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
                conSQL = conn.sqlConnect(gDataSourceAux, gUserIDAux, gPWDAux, gInitialCatalogAux)
                conSQL.Open()
                querySQl.Connection = conSQL
                querySQl.CommandText = "delete from Prisma.dbo.EstoqueEndereco where Id ='" & row("Id") & "'"
                querySQl.ExecuteNonQuery()
                row.Delete()
            Catch
            End Try
            conSQL.Close()
        End If
    End Sub

    Private Sub txtCDProduto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCDProduto.LostFocus
        conSQL = conn.sqlConnect(gDataSourceAux, gUserIDAux, gPWDAux, gInitialCatalogAux)
        conSQL.Open()
        querySQl.Connection = conSQL
        querySQl.CommandText = "Select Max(CDProduto) as CDProduto from Prisma.dbo.Estoque where CDProduto like '" & txtCDProduto.Text & "%'"
        Try
            Dim iCDProduto As Integer = querySQl.ExecuteScalar()
            iCDProduto += 1
            Dim sCDProduto As String
            sCDProduto = iCDProduto.ToString()
            txtCDProduto.Text = sCDProduto.PadLeft(6, "0")
            conSQL.Close()
        Catch
            MessageBox.Show("Nenhum código foi encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            conSQL.Close()
        End Try
    End Sub
    Private Sub btImpEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpEtiq.Click
        If txtCDProduto.Text <> "" Then
            Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
            Dim VBairro As String = ""
            Dim VRua As String = ""
            Try
                VBairro = row("Bairro")
            Catch
                VBairro = ""
            End Try
            Try
                VRua = row("Endereco")
            Catch
                VRua = ""
            End Try
            Dim c As relEtiqueta = New relEtiqueta(txtCDProduto.Text, txtDescricao.Text, VBairro, VRua)
            c.Margins.Top = 40
            c.Margins.Bottom = 40
            c.ShowPreview()
        Else
            MessageBox.Show("Digite o código do Produto", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class