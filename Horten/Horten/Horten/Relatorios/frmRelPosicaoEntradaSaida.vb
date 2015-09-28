Imports DevExpress.XtraPrinting
Public Class frmRelPosicaoEntradaSaida
    Public datPubsEstoque, datPubsComprador, datPubsFornec1 As New DataSet()
    Public dsMP, dsSubCJ, datPubsFornec2, datPubsFornec3, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub frmRelPosicaoEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sDataAntes As Date = Date.Now.ToShortDateString()
        cbTipoEstoque.Items.Add("0 - Selecione")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.SelectedIndex = 1
        Dim sMes As String = Date.Now.Month()
        Dim sAno As String = Date.Now.Year()
        sDataAntes = "01/" & sMes & "/" & sAno
        tbDe.Text = sDataAntes
        tbAte.Text = Date.Now.ToShortDateString()

    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        Dim gTipoEstoque As String = ""
        If cbTipoEstoque.SelectedIndex = 1 Then
            gTipoEstoque = "EPA"
        ElseIf cbTipoEstoque.SelectedIndex = 2 Then
            gTipoEstoque = "EMP"
        End If
        Dim sBusca As String = " Where 1=1 "
        If cbTipoEstoque.SelectedIndex <> 0 Then
            sBusca &= " And a.Estoque='" & cbTipoEstoque.SelectedIndex & "' "
        End If
        Dim dData As Date = tbAte.Text
        'dData = dData.AddDays(1)

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        Try
            querySQl.CommandText = "Drop Table TMP_RelPosEst"
            querySQl.ExecuteNonQuery()
        Catch
        End Try

        If gTipoEstoque = "EPA" Then
            gVSQL = "Select a.CDProduto,a.Descricao,a.Unidade,a.Minimo,a.Maximo,"
            gVSQL &= " (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2009',103)  order by registro desc) as Qtde, "
            gVSQL &= " (select top 1 b.saldo from Kardex2 b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2009',103) order by registro desc) as Empenho, "


            'NF - tirando cfop de industrializacao
            gVSQL &= " (ISNULL((Select Sum(c.Qtde) From NF b, ItemNF c, NaturezaOperacao d where c.CDEmpresa = b.CDEmpresa And c.CDNF = b.CDNF and c.CFOP = d.CDNatOper And b.CDEmpresa=d.CDEmpresa And c.CDProduto = a.CDProduto And b.DIS BetWeen Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & dData & "',103) And b.STLan = 1 And b.STCan = 0 And d.Faturamento = 1 and d.BaixarEstoque=1 and c.CFOP<>'10' and c.CFOP<>'74'),0) + "
            gVSQL &= " ISNULL((Select Sum(c.Qtde) From Prisma2.dbo.NF b, Prisma2.dbo.ItemNF c where c.CDEmpresa = b.CDEmpresa And c.CDNF = b.CDNF and  c.CDProduto = a.CDProduto And b.DIS BetWeen Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & dData & "',103) And b.STLan = 1 And b.STCan = 0),0)) as SaldoNF, "


            'Entrada de PA
            gVSQL &= " (Select Sum(b.Qtde) As Entrada From Kardex b Where a.CDProduto=b.CDProduto And b.Data BetWeen Convert(datetime,'" & tbDe.Text & "',103) And Convert(datetime,'" & dData & " 20:00:00',103) And b.Status = '" & gTipoEstoque & "') as EntradaPA,"


            'Pedido em aberto
            gVSQL &= " (ISNULL((SELECT Sum(c.Saldo) FROM Prisma.dbo.Pedidos b, Prisma.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0) + "
            gVSQL &= "ISNULL((SELECT Sum(c.Saldo) FROM Prisma2.dbo.Pedidos b, Prisma2.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0)) as QtdePendente, "


            'Saldo Kardex - Pedido
            gVSQL &= "'qtdeProduzir' = Case when "
            gVSQL &= "((ISNULL((SELECT Sum(c.Saldo) FROM Prisma.dbo.Pedidos b, Prisma.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0) + "
            gVSQL &= "ISNULL((SELECT Sum(c.Saldo) FROM Prisma2.dbo.Pedidos b, Prisma2.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0))) - "
            gVSQL &= " (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2009',103)  order by registro desc) "
            gVSQL &= " < 0 then 0 else "
            gVSQL &= "((ISNULL((SELECT Sum(c.Saldo) FROM Prisma.dbo.Pedidos b, Prisma.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0) + "
            gVSQL &= "ISNULL((SELECT Sum(c.Saldo) FROM Prisma2.dbo.Pedidos b, Prisma2.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0))) - "
            gVSQL &= " (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2009',103)  order by registro desc)   "
            gVSQL &= "end"

            If ckRevenda.Checked = True Then
                sBusca &= " and ProdutoRevenda=1"
            End If

            'gVSQL &= " Into TMP_RelPosEst From Estoque a " & sBusca & " and a.Descricao <> 'Livre' "
            gVSQL &= " From Estoque a " & sBusca & " and a.Descricao <> 'Livre' And Idle = 0"
            gVSQL &= " order by cdproduto"

        ElseIf gTipoEstoque = "EMP" Then
            gVSQL = "select a.CDProduto,a.Descricao,a.Unidade,a.Minimo,a.Maximo,"
            gVSQL &= "isnull((Select Top 1 Saldo From Kardex Where CDProduto = Estoque.CDProduto and Data >= convert(datetime,'01/01/2009',103) Order By Registro Desc),0) As Qtde,"
            gVSQL &= "isnull((Select Top 1 Saldo From Kardex2 Where CDProduto = Estoque.CDProduto and Data >= convert(datetime,'01/01/2009',103) order by registro desc),0) As Empenho,"
            gVSQL &= "isnull((Select Sum(Qtde) From ItemOC Left Join OC On ItemOC.CDEmpresa = OC.CDEmpresa And ItemOC.CDOC = OC.CDOC Where CDCodigo = Estoque.CDProduto And Dis BetWeen Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & dData & "',103) ,0) As EntradaPA,"
            gVSQL &= "(isnull((Select Sum(ItemPed.Qtde * Estrutura.Qtde) From ItemPed Left Join Pedidos On ItemPed.CDEmpresa = Pedidos.CDEmpresa And ItemPed.CDPedido = Pedidos.CDPedido Left Join Estrutura On Estoque.CDProduto = Estrutura.CDMaterial Where ItemPed.CDProduto = Estrutura.CDProduto and Dis BetWeen Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & dData & "',103),0) +"
            gVSQL &= " isnull((Select Sum(ItemPed.Qtde * Estrutura.Qtde) From Prisma2.dbo.ItemPed Left Join Prisma2.dbo.Pedidos On ItemPed.CDEmpresa = Pedidos.CDEmpresa And ItemPed.CDPedido = Pedidos.CDPedido Left Join Estrutura On Estoque.CDProduto = Estrutura.CDMaterial Where ItemPed.CDProduto = Estrutura.CDProduto and Dis BetWeen Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & dData & "',103),0)) as qtdePendente "
            gVSQL &= "from estoque where estoque = '" & cbTipoEstoque.SelectedIndex & "' order by cdproduto"
        End If


        'If CheckBox1.Checked = True Then
        '    querySQl.CommandText = gVSQL
        '    querySQl.CommandTimeout = 1000
        '    querySQl.ExecuteNonQuery()
        '    VSQL = "Select * From TMP_RelPosEst Where QtdeProduzir > 0 Order By CDProduto"
        'Else
        '    VSQL = gVSQL
        'End If
        datPubsEstoque.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.SelectCommand.CommandTimeout = 1000
        adaptSQL.Fill(datPubsEstoque, "Estoque")
        GridControl1.DataSource = datPubsEstoque.Tables("Estoque")
        conSQL1.Close()
        conSQL2.Close()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub imprimir()
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With

        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView1.GridControl
        link.PaperKind = Printing.PaperKind.A4
        link.Margins.Left = 30
        link.Margins.Right = 30
        link.Margins.Bottom = 30
        link.Margins.Top = 100
        link.Landscape = False
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        Dim sData As String = Date.Now.ToShortDateString()
        HeaderArea.Content.Add(sData)

        HeaderArea.Content.Add("Posição de Estoque - Entrada X Saída")

        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 13.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center

        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        Header.Header.LineAlignment = BrickAlignment.Center
        link.PageHeaderFooter = Header

        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub
End Class