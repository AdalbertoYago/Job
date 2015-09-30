Imports DevExpress.XtraPrinting
Public Class frmRelPosicaoEstoque
    Public datPubsEstoque, datPubsComprador, datPubsFornec1 As New DataSet()
    Public dsMP, dsSubCJ, datPubsFornec2, datPubsFornec3, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub frmRelPosicaoEstoque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.GridControl1.FocusedView.RestoreLayoutFromXml("c:\Prisma\xml\Layouts\LayoutRelPosicaoEstoque.xml")
        Catch
        End Try
        cbTipoEstoque.Items.Add("0 - Todos os Itens")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 2

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        datPubsComprador.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDVendedor as CDComprador, NMFantasia from Vendedores order By NMFantasia", conSQL2)
        adaptSQL.Fill(datPubsComprador, "Comprador")
        RepositoryItemLookUpEdit1.DataSource = datPubsComprador.Tables("Comprador")

        datPubsFornec1.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select CDFornec as CDFornec1,Nome from Fornecedores order By Nome", conSQL2)
        adaptSQL.Fill(datPubsFornec1, "Fornecedor")
        RepositoryItemLookUpEdit2.DataSource = datPubsFornec1.Tables("Fornecedor")

    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor
        If cbTipoEstoque.SelectedIndex = 2 Or cbTipoEstoque.SelectedIndex = 3 Or cbTipoEstoque.SelectedIndex = 4 Then
            GridColumn24.Visible = False
            GridColumn6.Visible = True
            GridColumn8.Visible = True
            GridColumn9.Visible = True
            GridColumn18.Visible = True
            GridColumn19.Visible = True
            GridColumn20.Visible = True
            GridColumn21.Visible = True
        Else
            GridColumn24.Visible = True
            GridColumn6.Visible = False
            GridColumn8.Visible = False
            GridColumn9.Visible = False
            GridColumn18.Visible = False
            GridColumn19.Visible = False
            GridColumn20.Visible = False
            GridColumn21.Visible = False
        End If
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        Dim sBusca As String = " Where 1=1 "
        Dim sDataAntes As Date = Date.Now.ToShortDateString()
        Dim sDataAtual As Date = Date.Now.ToShortDateString()
        sDataAtual = sDataAtual.AddDays(1)
        sDataAntes = sDataAntes.AddMonths(-12)
        If cbTipoEstoque.SelectedIndex <> 0 Then
            sBusca &= " And a.Estoque='" & cbTipoEstoque.SelectedIndex & "' "
        End If
        If cbTipoEstoque.SelectedIndex = 3 Then
            gVSQL = "select a.CDProduto,a.Descricao,a.Unidade,a.Minimo,a.Maximo,a.LeadTime,a.CDComprador, a.CDFornec1, a.ClassificacaoABC, "
            gVSQL &= " (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2012',103)  order by registro desc) as Qtde, "
            gVSQL &= " (select top 1 b.imp from Kardex b where a.CDProduto=b.CDProduto) as Imp, "

            gVSQL &= " (select sum(e.saldo) from itemOC e where e.saldo>0 and e.CDCodigo=a.CDProduto) as SaldoOCA,"
            gVSQL &= " (select top 1 CDOC from itemOC f where f.saldo>0 and f.CDCodigo=a.CDProduto ) as OCA,"
            gVSQL &= " (select sum(g.saldo) from Prisma2.dbo.itemOC g where g.saldo>0 and g.CDCodigo=a.CDProduto) as SaldoOCB,"
            gVSQL &= " (select Top 1 Endereco from Prisma.dbo.EstoqueEndereco where CDProduto = a.CDProduto) As EnderecoEstoque,"
            gVSQL &= " (select Top 1 Sum(QTde) From Prisma.dbo.Estrutura where CDProduto = a.CDProduto) As EnderecoEstoque,"
            gVSQL &= " (select top 1 CDOC from Prisma2.dbo.itemOC h where h.saldo>0 and h.CDCodigo=a.CDProduto ) as OCB "
        Else
            gVSQL = "select a.CDProduto,a.Descricao,a.Unidade,a.Minimo,a.Maximo,a.LeadTime,a.CDComprador, a.CDFornec1, a.ClassificacaoABC, "
            gVSQL &= " (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2012',103)  order by registro desc) as Qtde, "
            gVSQL &= " (select top 1 b.imp from Kardex b where a.CDProduto=b.CDProduto) as Imp, "
            If cbTipoEstoque.SelectedIndex <> 3 Then
                gVSQL &= " (select top 1 b.saldo from Kardex2 b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/06/2009',103) order by registro desc) as Empenho, "
                gVSQL &= " (select sum(d.saldo) from itemOP d where d.saldo>0 and d.CDProduto=a.CDProduto) as SaldoOF, "
            End If

            gVSQL &= " (select sum(e.saldo) from itemOC e where e.saldo>0 and e.CDCodigo=a.CDProduto) as SaldoOCA,"
            gVSQL &= " (select top 1 CDOC from itemOC f where f.saldo>0 and f.CDCodigo=a.CDProduto ) as OCA,"
            gVSQL &= " (select sum(g.saldo) from Prisma2.dbo.itemOC g where g.saldo>0 and g.CDCodigo=a.CDProduto) as SaldoOCB,"
            gVSQL &= " (select Top 1 Endereco from Prisma.dbo.EstoqueEndereco where CDProduto = a.CDProduto) As EnderecoEstoque,"
            gVSQL &= " (select Top 1 Sum(QTde) From Prisma.dbo.Estrutura where CDProduto = a.CDProduto) As EnderecoEstoque,"
            gVSQL &= " (select top 1 CDOC from Prisma2.dbo.itemOC h where h.saldo>0 and h.CDCodigo=a.CDProduto ) as OCB "
        End If

        If gFantasia = "ALADO" Then
            '##### Soma quantidade pendente de pedidos
            '            gVSQL &= ", (ISNULL((select Sum(ItemPed.Saldo) FROM Prisma.dbo.Pedidos LEFT JOIN Prisma.dbo.ItemPed ON Pedidos.CDEmpresa = ItemPed.CDEmpresa And Pedidos.CDPedido = ItemPed.CDPedido LEFT JOIN Clientes ON Clientes.CDCliente=Pedidos.CDCliente WHERE Pedidos.Dis BETWEEN Convert(datetime,'" & sDataAntes & "',103) And Convert(dateTime,'" & sDataAtual & "',103) And ItemPed.CDProduto=a.CDProduto and Clientes.ComporFaturamento=1),0) + "
            '           gVSQL &= " ISNULL((select Sum(ItemPed.Saldo) FROM Prisma2.dbo.Pedidos LEFT JOIN Prisma2.dbo.ItemPed ON Pedidos.CDEmpresa = ItemPed.CDEmpresa And Pedidos.CDPedido = ItemPed.CDPedido LEFT JOIN Clientes ON Clientes.CDCliente=Pedidos.CDCliente WHERE Pedidos.Dis BETWEEN Convert(datetime,'" & sDataAntes & "',103) And Convert(dateTime,'" & sDataAtual & "',103) And ItemPed.CDProduto=a.CDProduto and Clientes.ComporFaturamento=1),0)) as QtdePendente "

            '--and b.Dis BETWEEN Convert(datetime,'" & sDataAntes.ToShortDateString() & "',103) And Convert(dateTime,'" & sDataAtual.ToShortDateString() & "',103) 
            If cbTipoEstoque.SelectedIndex <> 3 Then
                gVSQL &= ", (ISNULL((SELECT Sum(c.Saldo) FROM Prisma.dbo.Pedidos b, Prisma.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0) + "
                gVSQL &= "ISNULL((SELECT Sum(c.Saldo) FROM Prisma2.dbo.Pedidos b, Prisma2.dbo.ItemPed c, Prisma.dbo.Clientes d where b.CDEmpresa = c.CDEmpresa And b.CDPedido = c.CDPedido and b.CDCliente=d.CDCliente and d.ComporFaturamento=1 And c.CDProduto = a.CDProduto And c.Situacao=0),0)) as QtdePendente "
            End If
            '#####
        End If

        'TODO: Tirar isso o mais rapido possivel
        Dim sQuery As String = ""
        If gFantasia = "ALADO" Then
            sQuery = ""
        Else
            sQuery = " and Left(a.CDProduto,4) <> '1001' and Left(a.CDProduto,4) <> '1002' and Left(a.CDProduto,4) <> '1004' "
        End If

        gVSQL &= " from Estoque a " & sBusca & sQuery & "  and a.Descricao <> 'Livre' "
        If RadioAtivos.Checked = True Then
            gVSQL &= " and Idle=0 "
        Else
            gVSQL &= " and Idle<>0 "
        End If

        If txtGrupoDescricao.Text <> "" Then
            If IsNumeric(txtGrupoDescricao.Text) Then
                gVSQL &= " and CDProduto like '" & txtGrupoDescricao.Text & "%'"
            Else
                gVSQL &= " and Descricao like '%" & txtGrupoDescricao.Text & "%'"
            End If
        End If

        If ck20Perc.Checked = True Then
            gVSQL &= " and (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2012',103) order by registro desc) <= (a.Minimo * 1.2)  "
        ElseIf ckNegativo.Checked = True Then
            gVSQL &= " and (select top 1 b.saldo from Kardex b where a.CDProduto=b.CDProduto and b.Data >= convert(datetime,'01/01/2012',103) order by registro desc) < 0  "
        End If
        gVSQL &= " order by cdproduto"


        'CARREGA Tipo de Endereco

        datPubsEstoque.Clear()
        'adaptSQL.SelectCommand.CommandTimeout = 1000
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.SelectCommand.CommandTimeout = 1000
        adaptSQL.Fill(datPubsEstoque, "Estoque")
        GridControl1.DataSource = datPubsEstoque.Tables("Estoque")
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDProduto As String
        Try
            sCDProduto = row("CDProduto")
            carregaGrids(sCDProduto)
        Catch ex As Exception
            sCDProduto = ""
        End Try
    End Sub
    Public Sub carregaGrids(ByVal sCDProduto As String)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        'OCs
        Dim dsSubOCA As New DataSet()
        gVSQL = "select a.DTEntrega,a.CDOC,b.Saldo from OC a, ItemOC b where a.CDOC=b.CDOC and a.CDEmpresa=b.CDEmpresa and b.CDCodigo='" & sCDProduto & "' and b.saldo>0"
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsSubOCA, "SubCJ")
        GridControl2.DataSource = dsSubOCA.Tables("SubCJ")

        Dim dsSubOCB As New DataSet()
        gVSQL = "select a.DTEntrega,a.CDOC,b.Saldo from Prisma2.dbo.OC a, Prisma2.dbo.ItemOC b where a.CDOC=b.CDOC and a.CDEmpresa=b.CDEmpresa and b.CDCodigo='" & sCDProduto & "' and b.saldo>0"
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsSubOCB, "SubCJ")
        GridControl3.DataSource = dsSubOCB.Tables("SubCJ")

        'Produto
        If cbTipoEstoque.SelectedIndex <> 4 Then
            gVSQL = "Select EstruturaMPC.*,Estoque.Descricao as Descricao2 From EstruturaMPC Left Join Estoque On EstruturaMPC.CDComponente = Estoque.CDProduto "
            gVSQL &= "Where CDMaterial = '" & sCDProduto & "' Order By EstruturaMPC.CDComponente"
        Else
            gVSQL = "Select EstruturaSubCJ.*,Estoque.Descricao as Descricao2 From EstruturaSUBCJ Left Join Estoque On EstruturaSubCJ.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDItem = '" & sCDProduto & "' Order By EstruturaSubCJ.CDProduto"
        End If

        dsMP.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsMP, "MP")
        gridProduto.DataSource = dsMP.Tables("mp")

        'SubCJ
        dsSubCJ.Clear()
        Try
            gVSQL = "Select EstruturaMPC.*,Estoque.Descricao  as Descricao2,Estoque.Minimo,"
            gVSQL &= "(Select Top 1 B.Saldo From Kardex B Where B.CDProduto = EstruturaMPC.CDComponente Order By Registro Desc) As TotEstoque  "
            gVSQL &= "From EstruturaMPC Left Join Estoque On EstruturaMPC.CDComponente = Estoque.CDProduto "
            gVSQL &= "Where CDMaterial = '" & sCDProduto & "' Order By EstruturaMPC.CDComponente"

            'gVSQL = "Select EstruturaMP.*,Estoque.Descricao  as Descricao2, (select top 1 b.saldo from kardex b where b.cdproduto=Estoque.cdproduto order by registro desc) as TotEstoque From EstruturaMP Left Join Estoque On EstruturaMP.CDProduto = Estoque.CDProduto "
            'gVSQL &= "Where CDMaterial = '" & sCDProduto & "' Order By EstruturaMP.CDProduto"
            adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
            adaptSQL.Fill(dsSubCJ, "SubCJ")
            gridSubCJ.DataSource = dsSubCJ.Tables("SubCJ")
        Catch
        End Try

        conSQL2.Open()
        querySQL2.Connection = conSQL2
        Try
            querySQL2.CommandText = "Select Especificacao from Estoque where cdproduto='" & sCDProduto & "'"
            txtEspecificacao.Text = querySQL2.ExecuteScalar()
        Catch
            txtEspecificacao.Text = ""
        End Try

        Try
            querySQL2.CommandText = "Select Observacao from Estoque where cdproduto='" & sCDProduto & "'"
            txtObservacao.Text = querySQL2.ExecuteScalar()
        Catch ex As Exception
            txtObservacao.Text = ""
        End Try

        conSQL2.Close()


    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick


    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDProduto As String
        If e.KeyCode = Keys.Enter Then
            Try
                sCDProduto = row("CDProduto")
                carregaGrids(sCDProduto)
            Catch ex As Exception
                sCDProduto = ""
            End Try
        End If
        If e.KeyCode = Keys.Delete Then
            Try
                row.Delete()
            Catch
            End Try
        End If

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
        link.Landscape = True
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        Dim sData As String = Date.Now.ToShortDateString()
        HeaderArea.Content.Add(sData)

        HeaderArea.Content.Add("Posição de Estoque")

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
        Try
            Me.GridControl1.FocusedView.SaveLayoutToXml("c:\Prisma\xml\Layouts\LayoutRelPosicaoEstoque.xml")
        Catch
        End Try
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ShowPrintPreview()

    End Sub
End Class
