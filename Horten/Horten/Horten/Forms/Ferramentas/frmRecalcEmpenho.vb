
Public Class frmRecalcEmpenho
    Public datPubs1, datPubs2, datPubs3, datPubsKardex As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL3.Open()
        querySQL3.Connection = conSQL3

        querySQl.CommandText = "Delete From RecalculoTmp Where Terminal = '" & gTerminal & "'"
        querySQl.ExecuteNonQuery()

        querySQl.CommandText = "Delete From RecalculoTmp2 Where Terminal = '" & gTerminal & "'"
        querySQl.ExecuteNonQuery()


        'Produto acabado
        querySQl.CommandText = "Select CDProduto, Descricao, Sum(Qtde) As TQtde From ItemOPMA Where DTBaixa Is NULL And Empenho > 0 And CDProduto <> '0000000' AND Left(CDProduto,4) <> '1000' Group By CDProduto,Descricao Order By CDProduto"
        datRead = querySQl.ExecuteReader()

        'Seleciona os produtos
        Dim sCDProduto As String
        Dim dQtde As Decimal
        Dim dQtdeNovo As Decimal
        Dim VTotal As Decimal = 0
        Do Until datRead.Read = False
            Try
                sCDProduto = datRead("CDProduto")
            Catch ex As Exception
                sCDProduto = ""
            End Try
            Try
                dQtde = datRead("TQtde")
            Catch ex As Exception
                dQtde = 0
            End Try


            If sCDProduto <> "" And dQtde > 0 Then
                querySQL2.CommandText = "INSERT INTO RecalculoTMP (Terminal,Codigo,Descricao,Qtde) VALUES ('" & gTerminal & "','" & sCDProduto & "','" & datRead("Descricao") & "'," & Replace(dQtde, ",", ".") & ")"
                querySQL2.ExecuteNonQuery()
            End If
        Loop
        datRead.Close()



        'Seleciona os SubCJs
        querySQl.CommandText = "Select CDProduto, Descricao, Sum(Saldo) As TQtde From ItemOP Where Saldo > 0 And (Left(CDProduto,1) = '8' or  Left(CDProduto,1) = '7') Group By CDProduto,Descricao Order By CDProduto"
        datRead = querySQl.ExecuteReader()
        VTotal = 0
        Do Until datRead.Read = False
            Try
                sCDProduto = datRead("CDProduto")
            Catch ex As Exception
                sCDProduto = ""
            End Try
            Try
                dQtde = datRead("TQtde")
            Catch ex As Exception
                dQtde = 0
            End Try
            If sCDProduto = "8311013" Then
                MessageBox.Show("")
            End If
            If sCDProduto <> "" And dQtde > 0 Then
                querySQL2.CommandText = "INSERT INTO RecalculoTMP (Terminal,Codigo,Descricao,Qtde) VALUES ('" & gTerminal & "','" & sCDProduto & "','" & datRead("Descricao") & "'," & Replace(dQtde, ",", ".") & ")"
                querySQL2.ExecuteNonQuery()
            End If
        Loop
        datRead.Close()

        querySQl.CommandText = "Select * From RecalculoTmp Where Terminal = '" & gTerminal & "' Order By Codigo"
        datRead = querySQl.ExecuteReader()

        Do Until datRead.Read = False
            Try
                sCDProduto = datRead("Codigo")
            Catch ex As Exception
                sCDProduto = ""
            End Try
            If sCDProduto = "8311013" Then
                MessageBox.Show("")
            End If
            dQtde = datRead("Qtde")
            If sCDProduto.Substring(0, 1) <> "8" And sCDProduto.Substring(0, 1) <> "7" Then
                'Seleciona as MPS dos Produtos
                querySQL2.CommandText = "Select * From EstruturaEstoque Where CDProduto = '" & sCDProduto & "'"
                datRead2 = querySQL2.ExecuteReader
                Do Until datRead2.Read = False
                    'Atualiza o empenho no estoque de PÇ/JG/CJ
                    dQtdeNovo = dQtde * datRead2("Qtde")
                    querySQL3.CommandText = "INSERT INTO RecalculoTMP2 (Terminal,Codigo,Descricao,Qtde,CodigoPai) VALUES ('" & gTerminal & "','" & datRead2("CDMaterial") & "','" & tiraAcentos(datRead2("Descricao")) & "'," & Replace(dQtdeNovo, ",", ".") & ",'" & sCDProduto & "')"
                    querySQL3.ExecuteNonQuery()
                Loop
                datRead2.Close()
            ElseIf sCDProduto.Substring(0, 1) = "8" Or sCDProduto.Substring(0, 1) = "7" Then
                'Seleciona as MPS dos Produtos
                querySQL2.CommandText = "Select * From EstruturaMP Where CDProduto = '" & sCDProduto & "'"
                datRead2 = querySQL2.ExecuteReader()
                Do Until datRead2.Read = False
                    dQtdeNovo = dQtde * datRead2("Qtde")
                    'Atualiza o empenho no estoque de PÇ/JG/CJ
                    querySQL3.CommandText = "INSERT INTO RecalculoTMP2 (Terminal,Codigo,Descricao,Qtde,CodigoPai) VALUES ('" & gTerminal & "','" & datRead2("CDMaterial") & "','" & tiraAcentos(datRead2("Descricao")) & "'," & Replace(dQtdeNovo, ",", ".") & ",'" & sCDProduto & "')"
                    querySQL3.ExecuteNonQuery()
                Loop
                datRead2.Close()
            End If


            'Seleciona os SUBCJs dos produtos
            querySQL2.CommandText = "Select EstruturaSubCJ.*,Estoque.Descricao From EstruturaSubCJ Left Join Estoque ON EstruturaSubCJ.CDItem = Estoque.CDProduto Where EstruturaSUBCJ.CDProduto = '" & sCDProduto & "' Order By CDProduto"
            datRead2 = querySQL2.ExecuteReader()
            Do Until datRead2.Read = False
                dQtdeNovo = dQtde * datRead2("Qtde")
                querySQL3.CommandText = "INSERT INTO RecalculoTMP2 (Terminal,Codigo,Descricao,Qtde,CodigoPai) VALUES ('" & gTerminal & "','" & datRead2("CDItem") & "','" & tiraAcentos(datRead2("Descricao")) & "'," & Replace(dQtdeNovo, ",", ".") & ",'" & sCDProduto & "')"
                querySQL3.ExecuteNonQuery()
            Loop
            datRead2.Close()
            sCDProduto = ""
        Loop
        datRead.Close()
        conSQL.Close()
        conSQL2.Close()
        conSQL3.Close()
        datPubs1.Clear()

        datPubs2.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select a.Codigo, Sum(a.Qtde) As TQtde, (select b.descricao from Estoque b where b.CDProduto=a.Codigo) as Descricao From RecalculoTMP2 a Where a.Terminal = '" & gTerminal & "' Group By a.Codigo Order By a.Codigo", conSQL2)
        adaptSQL.Fill(datPubs2, "Emp")
        GridControl2.DataSource = datPubs2.Tables("Emp")

        Dim data As Date = Date.Now.ToShortDateString()
        data = data.AddDays(5)

        datPubsKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from Kardex2 where Data Between convert(datetime,'01/01/2010',103) and convert(datetime,'" & data & "',103)  order by Registro Desc", conSQL2)
        adaptSQL.Fill(datPubsKardex, "TipoEnd")
        GridKardex.DataSource = datPubsKardex.Tables("TipoEnd")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmRecalcEmpenho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        Dim i As Integer = 0
        Dim sCDProduto, sDescricao, sTipoKardex As String
        Dim dQtdeEntrada As Decimal

        For i = 0 To GridView2.RowCount - 1 Step 1
            sCDProduto = GridView2.GetDataRow(i).Item("Codigo")
            Try
                sDescricao = GridView2.GetDataRow(i).Item("Descricao")
            Catch
                sDescricao = "Sem Descrição"
            End Try
            dQtdeEntrada = GridView2.GetDataRow(i).Item("TQtde")

            If sCDProduto.Substring(0, 1) = "7" Or sCDProduto.Substring(0, 1) = "8" Then
                sTipoKardex = "ISJ"
            Else
                sTipoKardex = "IMP"
            End If

            conSQL4.Open()
            querySQLProc.Connection = conSQL4
            querySQLProc.CommandType = CommandType.StoredProcedure
            querySQLProc.CommandText = "sp_KardexMP"
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDProduto))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtdeEntrada, ",", ".")))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", sTipoKardex))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Recalculo de Empenho"))
            querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))

            querySQLProc.ExecuteNonQuery()
            querySQLProc.Parameters.Clear()
            conSQL4.Close()
        Next
        datPubsKardex.Clear()
        datPubs2.Clear()
        MessageBox.Show("Registros lançados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub GridView2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyUp
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        If e.KeyCode = Keys.Delete Then
            Try
                row.Delete()
            Catch
            End Try
        End If
    End Sub

    Private Sub GridControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl2.Click
        selPai()
    End Sub
    Public Sub selPai()
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        Dim sCodigo As String
        Try
            sCodigo = row("Codigo")
        Catch ex As Exception
            sCodigo = ""
        End Try
        If sCodigo <> "" Then
            datPubs3.Clear()
            adaptSQL = New SqlClient.SqlDataAdapter("Select distinct CodigoPai, Descricao, Qtde From RecalculoTMP2 Where Codigo='" & sCodigo & "' and Terminal='" & gTerminal & "' Order By CodigoPai", conSQL2)
            adaptSQL.Fill(datPubs3, "OP")
            GridControl1.DataSource = datPubs3.Tables("OP")
        End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        selOP()
    End Sub
    Public Sub selOP()
        Dim row As System.Data.DataRow = GridView3.GetDataRow(GridView3.FocusedRowHandle)
        Dim sCodigoPai As String
        Try
            sCodigoPai = row("CodigoPai")
        Catch ex As Exception
            sCodigoPai = ""
        End Try
        If sCodigoPai <> "" Then
            datPubs4.Clear()
            If sCodigoPai.Substring(0, 1) <> "7" And sCodigoPai.Substring(0, 1) <> "8" Then
                adaptSQL = New SqlClient.SqlDataAdapter("Select CDOP From ItemOPMA Where CDProduto='" & sCodigoPai & "' And DTBaixa Is NULL And CDProduto <> '0000000' AND Left(CDProduto,4) <> '1000' Order By CDOP", conSQL2)
            Else
                adaptSQL = New SqlClient.SqlDataAdapter("Select CDOP From ItemOP Where Saldo > 0 And Left(CDProduto,1) = '8' and CDProduto='" & sCodigoPai & "'  Order By CDOP", conSQL2)
            End If
            adaptSQL.Fill(datPubs4, "OPMA")
            GridControl3.DataSource = datPubs4.Tables("OPMA")
        End If
    End Sub

    Private Sub GridControl2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl2.KeyUp
        selPai()
    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        selOP()
    End Sub
End Class