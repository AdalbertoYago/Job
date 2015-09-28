Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmQtdeMP
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub




    Private Sub bt0Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Imprimir.Click
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With
        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView1.GridControl
        link.Margins.Left = 25
        link.Margins.Right = 25

        link.Landscape = True
        link.PaperKind = Printing.PaperKind.A4
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add(Date.Now.ToShortDateString())
        HeaderArea.Content.Add("Previsão de Compra de Materia-Prima ")
        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center
        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        link.PageHeaderFooter = Header
        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bt0Buscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor()
        GridView1.ExpandAllGroups()
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL3.Open()
        querySQL3.Connection = conSQL3
        Dim dDataDe As String = tbDe.Text
        Dim dDataAte As String = tbAte.Text

        Dim ddataSubtract As TimeSpan = Convert.ToDateTime(dDataAte) - Convert.ToDateTime(dDataDe)

        Dim gPeriodo As Integer = (ddataSubtract.Days / 30)
        Dim ds As New DataSet()


        ' MEDIA DE MP X PRODUTOS VENDIDOS
        'Pega a media de produtos vendidos no periodo selecionado
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "delete from  TMP_PivotMediaMP"
        querySQL2.ExecuteNonQuery()


        gVSQL = "insert into TMP_PivotPedidoMP select sum(b.qtde) as Soma, b.CDProduto, "
        gVSQL &= "(select c.descricao from estoque c where b.cdproduto=c.cdproduto) as descricao "
        gVSQL &= "from Prisma.dbo.NF a, Prisma.dbo.ItemNF b, NaturezaOperacao d  "
        gVSQL &= "where a.CDNF=b.CDNF and a.dis >= convert(datetime,'" & tbDe.Text & "',103) and a.dis <= convert(datetime,'" & tbAte.Text & "',103) "
        gVSQL &= "and a.CDEmpresa='01' and left(b.cdproduto,1)='7' " 'and b.CDProduto<>'7111115' and b.CDProduto<>'7111114' and b.CDProduto<>'7111116' "
        gVSQL &= "and b.CFOP = d.CDNatOper and d.CDEmpresa='01' and d.BaixarEstoque=1 and d.Faturamento=1 And a.STLan = 1 And a.STCan = 0 group by b.CDProduto order by b.CDProduto "
        querySQL2.CommandText = gVSQL
        querySQL2.ExecuteNonQuery()

        gVSQL = "insert into TMP_PivotPedidoMP select sum(b.qtde) as Soma, b.CDProduto, "
        gVSQL &= "(select c.descricao from estoque c where b.cdproduto=c.cdproduto) as descricao "
        gVSQL &= "from Prisma2.dbo.NF a, Prisma2.dbo.ItemNF b "
        gVSQL &= "where a.CDNF=b.CDNF and a.dis >= convert(datetime,'" & tbDe.Text & "',103) and a.dis <= convert(datetime,'" & tbAte.Text & "',103) "
        gVSQL &= "and a.CDEmpresa='01' and left(b.cdproduto,1)='7' " ' and b.CDProduto<>'7111115' and b.CDProduto<>'7111114' and b.CDProduto<>'7111116' "
        gVSQL &= " And a.STLan = 1 And a.STCan = 0 group by b.CDProduto order by b.CDProduto "
        querySQL2.CommandText = gVSQL
        querySQL2.ExecuteNonQuery()


        gVSQL = "insert into TMP_PivotPedidoMP2 select sum(qtde) as Soma, CDProduto, Descricao, '' as CDMaterial, '' as DescricaoMP, 0 as QtdeUsada, 0 as TotalUsado, 0 as QtdeTotal, 0 as ValorTotal from TMP_PivotPedidoMP Group by CDProduto,Descricao"

        querySQL2.CommandText = gVSQL
        querySQL2.ExecuteNonQuery()

        querySQL2.CommandText = "delete from  TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "insert into TMP_PivotPedidoMP select Qtde, CDProduto, Descricao from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "delete from  TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()

        querySQl.CommandText = "Select * from TMP_PivotPedidoMP order by CDProduto"
        datRead = querySQl.ExecuteReader()
        Dim dQtde As Decimal
        Dim sCDProduto, sDescricao As String
        Do Until datRead.Read = False
            dQtde = datRead("Qtde")
            sCDProduto = datRead("CDProduto")
            Try
                sDescricao = datRead("Descricao")
            Catch
                sDescricao = "Sem Descricao"
            End Try

            '# 
            extraiEstrutura(sCDProduto, sDescricao, dQtde)

        Loop
        datRead.Close()

        querySQl.CommandText = "Select sum(QtdeTotal) as QtdeTotal,CDMaterial from TMP_PivotPedidoMP2 Group By CDMaterial"
        datRead = querySQl.ExecuteReader()
        Dim dQtdeMaterial As Decimal
        Do Until datRead.Read = False
            dQtdeMaterial = datRead("QtdeTotal")
            dQtdeMaterial = dQtdeMaterial / gPeriodo
            If datRead("CDMaterial") = "1902003" Then
                'MessageBox.Show("")
            End If
            querySQL2.CommandText = "insert into TMP_PivotMediaMP (QtdeMediaVendido,CDMaterial,Terminal) values (" & Replace(dQtdeMaterial, ",", ".") & ",'" & datRead("CDMaterial") & "','" & gTerminal & "')"
            querySQL2.ExecuteNonQuery()
        Loop
        datRead.Close()
        '#####


        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()






        '#selecionando quantidade de produto acabado em estoque em multiplica pela estrutura de custo
        querySQl.CommandText = "select a.CDProduto,(select top 1 b.saldo from kardex b  where a.CDProduto=b.CDProduto order by registro desc) as Saldo from estoque a where a.estoque=1 and left(a.cdproduto,1)='7'"
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            Try
                dQtde = datRead("saldo")
            Catch
                dQtde = 0
            End Try
            sCDProduto = datRead("CDProduto")
            Try
                sDescricao = datRead("Descricao")
            Catch
                sDescricao = "Sem Descricao"
            End Try

            '# 
            If sCDProduto = "7111116" Then
                'MessageBox.Show("")
            End If
            If dQtde <> 0 Then
                extraiEstrutura(sCDProduto, sDescricao, dQtde)
            End If
        Loop
        datRead.Close()

        querySQl.CommandText = "Select sum(QtdeTotal) as QtdeTotal,CDMaterial from TMP_PivotPedidoMP2 Group By CDMaterial"
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            dQtdeMaterial = datRead("QtdeTotal")
            If datRead("CDMaterial") = "1902003" Then
                'MessageBox.Show("")
            End If
            querySQL2.CommandText = "update TMP_PivotMediaMP set QtdeProdutoEstoque=" & Replace(dQtdeMaterial, ",", ".") & " where CDMaterial='" & datRead("CDMaterial") & "' and Terminal='" & gTerminal & "'"
            querySQL2.ExecuteNonQuery()
        Loop
        datRead.Close()

        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()






        '#Saldo da Materia Prima no estoque
        querySQl.CommandText = "select a.CDMaterial,(select top 1 b.saldo from kardex b  where a.CDMaterial=b.CDProduto order by registro desc) as Saldo from TMP_PivotMediaMP a"
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            Try
                dQtde = datRead("saldo")
            Catch
                dQtde = 0
            End Try
            If datRead("CDMaterial") = "1902003" Then
                'MessageBox.Show("")
            End If
            querySQL2.CommandText = "update TMP_PivotMediaMP set QtdeMPEstoque=" & Replace(dQtde, ",", ".") & " where CDMaterial='" & datRead("CDMaterial") & "' and Terminal='" & gTerminal & "'"
            querySQL2.ExecuteNonQuery()
        Loop
        datRead.Close()


        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()





        '#Saldo da Materia Prima em produtos pendentes para fabricar
        gVSQL = "select a.CDProduto, a.Descricao, "
        gVSQL &= "(ISNULL((SELECT Sum(c.Saldo) FROM Prisma.dbo.Pedidos b, Prisma.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0) + "
        gVSQL &= "ISNULL((SELECT Sum(c.Saldo) FROM Prisma2.dbo.Pedidos b, Prisma2.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0)) as QtdePendente"
        gVSQL &= " from Estoque a where a.Estoque=1  and left(cdproduto,1)='7' "
        querySQl.CommandText = gVSQL

        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            Try
                dQtde = datRead("QtdePendente")
            Catch
                dQtde = 0
            End Try
            If dQtde <> 0 Then
                extraiEstrutura(datRead("CDProduto"), datRead("Descricao"), dQtde)
            End If
        Loop
        datRead.Close()
        querySQl.CommandText = "Select sum(QtdeTotal) as QtdeTotal,CDMaterial from TMP_PivotPedidoMP2 group by CDMaterial"
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            querySQL2.CommandText = "update TMP_PivotMediaMP set QtdeProdutoPendente=" & Replace(datRead("QtdeTotal"), ",", ".") & " where CDMaterial='" & datRead("CDMaterial") & "' and Terminal='" & gTerminal & "'"
            querySQL2.ExecuteNonQuery()
        Loop
        datRead.Close()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()


        querySQL2.CommandText = "update TMP_PivotMediaMP set QtdeAComprar=(QtdeMPEstoque-QtdeProdutoPendente+QtdeProdutoEstoque-QtdeMediaVendido) where Terminal='" & gTerminal & "'"
        querySQL2.ExecuteNonQuery()


        '###se a quantidade a comprar for maior que o minimo, zera a quantidade a comprar
        querySQl.CommandText = "Select a.QtdeAComprar,a.CDMaterial, b.Minimo from TMP_PivotMediaMP a, Estoque b where a.CDMaterial=b.CDProduto"
        datRead = querySQl.ExecuteReader()
        Dim ddQtdeAComprar, ddMinimo As Decimal
        Do Until datRead.Read = False
            Try
                ddQtdeAComprar = datRead("QtdeAComprar")
            Catch
                ddQtdeAComprar = 0
            End Try
            ddMinimo = datRead("Minimo")
            If ddQtdeAComprar > ddMinimo Then
                ddQtdeAComprar = 0
            End If
            If datRead("CDMaterial") = "1902003" Then
                ''MessageBox.Show("")
            End If
            querySQL2.CommandText = "update TMP_PivotMediaMP set QtdeAComprar=" & Replace(ddQtdeAComprar, ",", ".") & " where CDMaterial='" & datRead("CDMaterial") & "' and Terminal='" & gTerminal & "'"
            querySQL2.ExecuteNonQuery()
        Loop
        datRead.Close()


        conSQL.Close()
        conSQL2.Close()
        conSQL3.Close()




        ds.Clear()
        gVSQL = "Select a.QtdeMediaVendido,a.QtdeProdutoEstoque,a.QtdeProdutoPendente,a.QtdeMPEstoque,ABS(a.QtdeAComprar) as QtdeAComprar,a.CDMaterial, b.Descricao,b.Minimo,b.Maximo,b.LeadTime, "
        gVSQL &= " 'status' = Case when a.QtdeAComprar>0 then 'Normal' when a.QtdeAComprar<0 then 'Imediato' else '-'  end, "
        gVSQL &= " (isnull((select sum(e.saldo) from itemOC e where e.saldo>0 and e.CDCodigo=b.CDProduto),0) "
        gVSQL &= " + isnull((select sum(g.saldo) from Prisma2.dbo.itemOC g where g.saldo>0 and g.CDCodigo=b.CDProduto),0)) as SaldoOC "
        gVSQL &= " from TMP_PivotMediaMP a, Estoque b where a.CDMaterial=b.CDProduto Order By CDMaterial"

        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(ds, "Estoque")
        GridControl1.DataSource = ds.Tables("Estoque")

        'Dim vView As GridView = New GridView(GridControl1)
        'GridControl1.LevelTree.Nodes.Add("PaiEFilho", GridView1)

        Me.Cursor = Cursors.Default()
    End Sub
    Private Sub extraiEstrutura(ByVal sCDProduto As String, ByVal sDescricaoProduto As String, ByVal dQtdeProdutoPai As Decimal)
        Dim dQtde, dQtdeMP, dTotalMP, dQtdeTotalMP, dValorTotalMP As Decimal
        Dim sCDMaterial, sDescricaoMP As String
        Dim gVSQLF As String
        conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL4.Open()
        querySQL4.Connection = conSQL4
        conSQL5 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL5.Open()
        querySQL5.Connection = conSQL5

        'Pega da Estrutura
        gVSQLF = "select CDProduto,CDMaterial,Descricao,Qtde from estrutura "
        gVSQLF &= "where CDProduto='" & sCDProduto & "' and cenario='1' and left(CDMaterial,1)<> 'A' and left(CDMaterial,1)<> 'B' and left(CDMaterial,1)<> 'C'"

        querySQL4.CommandText = gVSQLF
        datRead4 = querySQL4.ExecuteReader()
        Do Until datRead4.Read = False
            dQtdeMP = datRead4("Qtde")
            sCDMaterial = datRead4("CDMaterial")
            sDescricaoMP = datRead4("Descricao")
            If sCDMaterial = "1902003" Then
                MessageBox.Show("1001001")
            End If
            dQtdeTotalMP = dQtdeProdutoPai * dQtdeMP

            gVSQL = "insert into TMP_PivotPedidoMP2 (Qtde,CDProduto,Descricao,CDMaterial,DescricaoMP,QtdeUsada,TotalUsado,QtdeTotal, ValorTotal) Values ("
            gVSQL &= Replace(dQtdeProdutoPai, ",", ".") & ",'" & sCDProduto & "','" & sDescricaoProduto & "','" & sCDMaterial & "','" & sDescricaoMP & "'"
            gVSQL &= "," & Replace(dQtdeMP, ",", ".") & "," & Replace(dTotalMP, ",", ".") & "," & Replace(dQtdeTotalMP, ",", ".") & "," & Replace(dValorTotalMP, ",", ".") & ")"
            querySQL5.CommandText = gVSQL
            querySQL5.ExecuteNonQuery()
        Loop
        datRead4.Close()
        conSQL4.Close()
        conSQL5.Close()
    End Sub
    Private Sub frmProdutoMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sDataAntes, sDataAtual As String

        Dim dDataInicial As Date = Date.Now()
        dDataInicial = dDataInicial.AddMonths(-6)
        Dim sMesInicial, sMesAtual As String
        sMesInicial = dDataInicial.Month()
        sDataAntes = "01/" & sMesInicial.PadLeft(2, "0") & "/" & dDataInicial.Year.ToString()

        Dim dDataAtual As Date = Date.Now()
        sMesAtual = dDataAtual.Month()
        sDataAtual = "01/" & sMesAtual.PadLeft(2, "0") & "/" & dDataAtual.Year


        tbDe.Text = sDataAntes
        tbAte.Text = sDataAtual
    End Sub
End Class