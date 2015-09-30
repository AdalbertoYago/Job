Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmProdutoMP
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
        link.Margins.Left = 40
        link.Margins.Right = 40
        link.Landscape = False
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add(Date.Now.ToShortDateString())
        HeaderArea.Content.Add("Produtos X Matéria Prima ")
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

        Dim ds As New DataSet()
        Dim gVSQLF As String

        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Delete from TMP_PivotPedidoMP2"
        querySQL2.ExecuteNonQuery()


        gVSQL = "insert into TMP_PivotPedidoMP select sum(b.qtde) as Soma, b.CDProduto, "
        gVSQL &= "(select c.descricao from estoque c where b.cdproduto=c.cdproduto) as descricao "
        gVSQL &= "from Prisma.dbo.NF a, Prisma.dbo.ItemNF b, NaturezaOperacao d  "
        gVSQL &= "where a.CDNF=b.CDNF and a.dis >= convert(datetime,'" & tbDe.Text & "',103) and a.dis <= convert(datetime,'" & tbAte.Text & "',103) "
        gVSQL &= "and a.CDEmpresa=b.cdempresa and left(b.cdproduto,1)='7' and b.CDProduto<>'7111115' and b.CDProduto<>'7111114' and b.CDProduto<>'7111116' "
        gVSQL &= "and b.CFOP = d.CDNatOper and d.CDEmpresa='01' and d.BaixarEstoque=1 and d.Faturamento=1 And a.STLan = 1 And a.STCan = 0 group by b.CDProduto order by b.CDProduto "
        querySQL2.CommandText = gVSQL
        querySQL2.ExecuteNonQuery()

        gVSQL = "insert into TMP_PivotPedidoMP select sum(b.qtde) as Soma, b.CDProduto, "
        gVSQL &= "(select c.descricao from estoque c where b.cdproduto=c.cdproduto) as descricao "
        gVSQL &= "from Prisma2.dbo.NF a, Prisma2.dbo.ItemNF b "
        gVSQL &= "where a.CDNF=b.CDNF and a.dis >= convert(datetime,'" & tbDe.Text & "',103) and a.dis <= convert(datetime,'" & tbAte.Text & "',103) "
        gVSQL &= "and a.CDEmpresa=b.cdempresa and left(b.cdproduto,1)='7' and b.CDProduto<>'7111115' and b.CDProduto<>'7111114' and b.CDProduto<>'7111116' And a.STLan = 1 And a.STCan = 0"
        gVSQL &= " group by b.CDProduto order by b.CDProduto "
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
        Dim dQtde, dQtdeMP, dTotalMP, dQtdeTotalMP, dValorTotalMP As Decimal
        Dim sCDProduto, sCDMaterial, sDescricaoMP, sDescricao As String
        Do Until datRead.Read = False
            dQtde = datRead("Qtde")
            sCDProduto = datRead("CDProduto")
            Try
                sDescricao = datRead("Descricao")
            Catch
                sDescricao = "Sem Descricao"
            End Try
            gVSQLF = "select CDProduto,CDMaterial,Descricao,Qtde,Total from estrutura "
            Dim sMaterial As String = cbCDMaterial.Text
            If cbCDMaterial.Text = "" Then
                gVSQLF &= "where CDProduto='" & sCDProduto & "' and cenario='1' and left(CDMaterial,1)<> 'A' and left(CDMaterial,1)<> 'B' and left(CDMaterial,1)<> 'C'"
            Else
                gVSQLF &= "where CDProduto='" & sCDProduto & "' and CDMaterial = '" & sMaterial.Substring(0, 7) & "'and cenario='1' "

            End If
            querySQL2.CommandText = gVSQLF
            datRead2 = querySQL2.ExecuteReader()
            Do Until datRead2.Read = False
                dQtdeMP = datRead2("Qtde")
                dTotalMP = datRead2("Total")
                sCDMaterial = datRead2("CDMaterial")
                sDescricaoMP = datRead2("Descricao")

                dQtdeTotalMP = dQtde * dQtdeMP
                dValorTotalMP = dQtde * dTotalMP

                gVSQL = "insert into TMP_PivotPedidoMP2 (Qtde,CDProduto,Descricao,CDMaterial,DescricaoMP,QtdeUsada,TotalUsado,QtdeTotal, ValorTotal) Values ("
                gVSQL &= Replace(dQtde, ",", ".") & ",'" & sCDProduto & "','" & sDescricao & "','" & sCDMaterial & "','" & sDescricaoMP & "'"
                gVSQL &= "," & Replace(dQtdeMP, ",", ".") & "," & Replace(dTotalMP, ",", ".") & "," & Replace(dQtdeTotalMP, ",", ".") & "," & Replace(dValorTotalMP, ",", ".") & ")"
                querySQL3.CommandText = gVSQL
                querySQL3.ExecuteNonQuery()
            Loop
            datRead2.Close()

        Loop
        datRead.Close()





        conSQL.Close()
        conSQL2.Close()
        conSQL3.Close()


        ds.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select * from TMP_PivotPedidoMP2 Order By CDProduto", conSQL2)
        adaptSQL.Fill(ds, "Estoque")
        GridControl1.DataSource = ds.Tables("Estoque")

        'Dim vView As GridView = New GridView(GridControl1)
        'GridControl1.LevelTree.Nodes.Add("PaiEFilho", GridView1)
    End Sub

    Private Sub frmProdutoMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sMes As String = Date.Now.Month()
        Dim sAno As String = Date.Now.Year()
        Dim sDataAntes As String
        sDataAntes = "01/" & sMes & "/" & sAno
        tbDe.Text = sDataAntes
        tbAte.Text = Date.Now.ToShortDateString()

        cbCDMaterial.Items.Add("AAAAAAA - MOD")
        cbCDMaterial.Items.Add("BBBBBBB - Depreciação")
        cbCDMaterial.Items.Add("CCCCCCC - GGF")
    End Sub
End Class