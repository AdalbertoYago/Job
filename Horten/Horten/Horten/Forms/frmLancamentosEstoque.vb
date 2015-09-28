Imports DevExpress.XtraGrid.Views.Grid
Public Class frmLancamentosEstoque
    Public datPubsTipoKardex, datPubsEstoque, datPubsComprador, datPubsSetor, datPubsFornec1, datPubsFornec2, datPubsP13, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub frmLancamentosEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        datPubsFornec1.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec1, "Fornecedor")
        RepositoryItemLookUpEdit2.DataSource = datPubsFornec1.Tables("Fornecedor")

        datPubsTipoKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select Status,Descricao From TipoKardex Order By Descricao", conSQL2)
        adaptSQL.Fill(datPubsTipoKardex, "TipoKar")
        ComboBox1.DataSource = datPubsTipoKardex.Tables("TipoKar")
        ComboBox1.DisplayMember = "Descricao"
        ComboBox1.ValueMember = "Status"

        '## CASO NAO ENCONTRE NADA EM NENHUM DOS SELECTS ANTERIORES EU EXIBO A GRID EM BRANCO
        datPubsP13.Clear()
        gVSQL = "select CDProduto,Descricao,'01/01/1900' as Data,'0' as Requisitante,Unidade,0.00 as SaldoEmpenho, 0.00 as SaldoEstoque, 0.00 as Qtde, Valor,CDFornec1,'' as TipoKardex, '' As Obs "
        gVSQL &= " from Estoque where 1<>1"
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(datPubsP13, "sItem")
        Dim dvManager2 As DataViewManager = New DataViewManager(datPubsP13)
        Dim dv2 As DataView = dvManager2.CreateDataView(datPubsP13.Tables("sItem"))
        GridControl1.DataSource = dv2

        carregaRepositorio()
    End Sub

    Public Sub carregaRepositorio()
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        'If rdEntrada.Checked = True Then
        '    gVSQL = " Where Tipo='E' "
        'ElseIf rdInventario.Checked = True Then
        '    gVSQL = " Where Tipo='I'"
        'ElseIf rdSaida.Checked = True Then
        '    gVSQL = " Where Tipo='S'"
        'End If


        'datPubsComprador.Clear()
        'adaptSQL = New SqlClient.SqlDataAdapter("select Status,Descricao from TipoKardex order By Descricao", conSQL2)
        'adaptSQL.Fill(datPubsComprador, "Tp")
        'RepositoryItemLookUpEdit1.DataSource = datPubsComprador.Tables("Tp")

        datPubsSetor.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from TabSetor order By Descricao", conSQL2)
        adaptSQL.Fill(datPubsSetor, "Setor")
        RepositoryItemLookUpEdit3.DataSource = datPubsSetor.Tables("Setor")
    End Sub

    Private Sub rdEntrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        carregaRepositorio()
    End Sub

    Private Sub rdSaida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        carregaRepositorio()
    End Sub

    Private Sub rdInventario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        carregaRepositorio()
    End Sub


    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim View As GridView = sender
        If e.Column.FieldName = "CDProduto" Then
            Dim sCDProduto As String = View.EditingValue

            'Fazer select em Estoque
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL

            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2

            '#############CHECAR TODAS AS INCIDENCIAS QUE APARECEM NA CFOP DO CLIENTE


            querySQl.CommandText = "Select * from Estoque where CDProduto='" & sCDProduto & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "Unidade", datRead("Unidade"))
                View.SetRowCellValue(e.RowHandle, "Descricao", datRead("Descricao"))
                View.SetRowCellValue(e.RowHandle, "Data", Date.Now.ToShortDateString())
                View.SetRowCellValue(e.RowHandle, "Requisitante", gUsuario)
                'If sCDProduto.Substring(0, 1) = "7" Or sCDProduto.Substring(0, 1) = "8" Then
                View.SetRowCellValue(e.RowHandle, "TipoKardex", ComboBox1.SelectedValue)
                'Else
                '    View.SetRowCellValue(e.RowHandle, "TipoKardex", "IMP")
                'End If
                Try
                    View.SetRowCellValue(e.RowHandle, "Valor", datRead("Valor"))
                Catch
                    View.SetRowCellValue(e.RowHandle, "Valor", 0)
                End Try

                querySQL2.CommandText = "Select top 1 * from Kardex2 where CDProduto='" & sCDProduto & "' order by registro desc"
                datRead2 = querySQL2.ExecuteReader()
                If datRead2.Read = True Then
                    Try
                        View.SetRowCellValue(e.RowHandle, "SaldoEmpenho", datRead2("Saldo"))
                    Catch
                        View.SetRowCellValue(e.RowHandle, "SaldoEmpenho", 0)
                    End Try
                End If
                datRead2.Close()

                querySQL2.CommandText = "Select top 1 * from Kardex where CDProduto='" & sCDProduto & "' order by registro desc"
                datRead2 = querySQL2.ExecuteReader()
                If datRead2.Read = True Then
                    Try
                        View.SetRowCellValue(e.RowHandle, "SaldoEstoque", datRead2("Saldo"))
                    Catch
                        View.SetRowCellValue(e.RowHandle, "SaldoEstoque", 0)
                    End Try
                End If
                datRead2.Close()
                MessageBox.Show("Atenção! a unidade de medida do item " & sCDProduto & " é [" & datRead("Unidade") & "]")
            End If
            datRead.Close()
            conSQL.Close()
            conSQL2.Close()
        End If
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        Dim i As Integer = 0
        Dim sCDProduto, sDescricao, sTipoKardex, sTipoKardexDescricao, sObs As String
        Dim dQtde, dQtdeNova As Decimal
        Dim dQtdeEntrada As Decimal
        Dim dQtdeEmpenho As Decimal

        For i = 0 To GridView1.RowCount - 1 Step 1
            sCDProduto = GridView1.GetDataRow(i).Item("CDProduto")
            Try
                sObs = GridView1.GetDataRow(i).Item("Obs")
            Catch
                sObs = ""
            End Try

            Try
                sDescricao = GridView1.GetDataRow(i).Item("Descricao")
            Catch
                sDescricao = "Sem Descrição"
            End Try
            sTipoKardex = GridView1.GetDataRow(i).Item("TipoKardex")

            querySQL2.CommandText = "Select Top 1 Saldo From Kardex Where CDProduto = '" & sCDProduto & "' Order By Registro Desc"
            Try
                dQtde = querySQL2.ExecuteScalar()
            Catch
                dQtde = 0
            End Try
            Try
                dQtdeEntrada = GridView1.GetDataRow(i).Item("Qtde")
            Catch
                dQtdeEntrada = 0
            End Try

            Dim sUsuario As String


            Try
                sUsuario = GridView1.GetDataRow(i).Item("Requisitante")
            Catch
                sUsuario = ""
            End Try


            '#### Faco um ElseIF soh pra montar a descricao
            If sTipoKardex = "EMC" Then
                sTipoKardexDescricao = "Entrada de MC"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "EMP" Then
                sTipoKardexDescricao = "Entrada de MP"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "ESC" Then
                sTipoKardexDescricao = "Entrada de Sub-CJ"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "EPA" Then
                sTipoKardexDescricao = "Entrada de PA"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "ETM" Then
                sTipoKardexDescricao = "Estorno de MP"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "ETP" Then
                sTipoKardexDescricao = "Estorno de PA"
                dQtdeNova = dQtde + dQtdeEntrada
            ElseIf sTipoKardex = "IMC" Then
                sTipoKardexDescricao = "Inventário de MC"
                dQtdeNova = dQtdeEntrada
            ElseIf sTipoKardex = "IMP" Then
                sTipoKardexDescricao = "Inventário de MP"
                dQtdeNova = dQtdeEntrada
            ElseIf sTipoKardex = "IPA" Then
                sTipoKardexDescricao = "Inventário de PA"
                dQtdeNova = dQtdeEntrada
            ElseIf sTipoKardex = "ISJ" Then
                sTipoKardexDescricao = "Inventário de Sub-CJ"
                dQtdeNova = dQtdeEntrada
            ElseIf sTipoKardex = "SMC" Then
                sTipoKardexDescricao = "Saída de MC"
                dQtdeNova = dQtde - dQtdeEntrada
            ElseIf sTipoKardex = "SMP" Then
                sTipoKardexDescricao = "Saída de MP"
                dQtdeNova = dQtde - dQtdeEntrada
            ElseIf sTipoKardex = "SPA" Then
                sTipoKardexDescricao = "Saída de PA"
                dQtdeNova = dQtde - dQtdeEntrada
            ElseIf sTipoKardex = "SSC" Then
                sTipoKardexDescricao = "Saída de Sub-CJ"
                dQtdeNova = dQtde - dQtdeEntrada
            Else
                sTipoKardexDescricao = ""
            End If


            querySQL2.CommandText = "Update Estoque Set Qtde=" & Replace(dQtdeNova, ",", ".") & " where CDProduto='" & sCDProduto & "'"
            querySQL2.ExecuteNonQuery()

            If RadioEstoque.Checked = True Then
                If sTipoKardex = "ISJ" Or sTipoKardex = "IMP" Then
                    Try
                        querySQL2.CommandText = "select saldo from Kardex2 where cdproduto='" & sCDProduto & "' order by Registro desc "
                        dQtdeEmpenho = querySQL2.ExecuteScalar()
                    Catch
                        dQtdeEmpenho = 0
                    End Try
                    dQtdeEntrada = dQtdeEntrada - dQtdeEmpenho
                End If


                '#### Saida de Sub-CJ do Kardex
                conSQL4.Open()
                querySQLProc.Connection = conSQL4
                querySQLProc.CommandType = CommandType.StoredProcedure
                querySQLProc.CommandText = "sp_Kardex"
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDProduto))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtdeEntrada, ",", ".")))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", sTipoKardex))
                If sObs <> "" Then
                    querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Lanç. Manual " & sTipoKardexDescricao & " | " & sObs & " | " & sUsuario.ToUpper()))
                Else
                    querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Lanç. Manual " & sTipoKardexDescricao & " | " & sUsuario.ToUpper()))
                End If
                querySQLProc.ExecuteNonQuery()
                querySQLProc.Parameters.Clear()
                conSQL4.Close()
            Else
                '#### Saida de Sub-CJ do Kardex
                conSQL4.Open()
                querySQLProc.Connection = conSQL4
                querySQLProc.CommandType = CommandType.StoredProcedure
                querySQLProc.CommandText = "sp_KardexMP"
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDProduto))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtdeEntrada, ",", ".")))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", sTipoKardex))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Lanç. Manual " & sTipoKardexDescricao & " | " & sUsuario.ToUpper()))
                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))

                querySQLProc.ExecuteNonQuery()
                querySQLProc.Parameters.Clear()
                conSQL4.Close()
            End If

        Next
        'Limpa Grid
        datPubsP13.Clear()
        conSQL2.Close()
        MessageBox.Show("Registros lançados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        datPubsP13.Clear()

    End Sub

    Private Sub GridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = Keys.Delete Then
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            row.Delete()
        End If
    End Sub
End Class