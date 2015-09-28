Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmHistoricoInventario
    Public datPubsKardex, datPubsTipoKardex As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub frmKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)

        Dim dHoje As Date = Date.Now.ToShortDateString()
        Dim dData As Date = dHoje.AddMonths(-1)
        txtDe.Text = dData
        txtAte.Text = dHoje.AddDays(1)

        busca()



        datPubsTipoKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from TipoKardex  order by Status", conSQL2)
        adaptSQL.Fill(datPubsTipoKardex, "TipoEnd")
        cbTipoKardex.DataSource = datPubsTipoKardex.Tables("TipoEnd")
        cbTipoKardex.DisplayMember = "Descricao"
        cbTipoKardex.ValueMember = "Status"
        cbTipoKardex.SelectedIndex = -1
    End Sub
    Public Sub busca()
        Dim sBusca As String = ""
        Dim sBusca2 As String = ""
        If cbTipoKardex.SelectedValue <> "" Then
            sBusca = " And Status='" & cbTipoKardex.SelectedValue() & "' "
            sBusca2 = " And Status<>'" & cbTipoKardex.SelectedValue() & "' "
        Else
            sBusca = " And Status='IMP' "
            sBusca2 = " And Status<>'IMP' "
        End If
        Dim sCDProduto As String
        Dim iRegistro As Integer
        Dim iRegistroEmpenho As Integer
        Dim dSaldoVelho As Decimal
        Dim dEmpenhoVelho As Decimal
        Dim dEmpenho As Decimal
        Dim dDataAte As Date
        dDataAte = txtAte.Text
        dDataAte = dDataAte.AddDays(1)


        conSQL2.Open()
        conSQL.Open()
        querySQL2.Connection = conSQL2
        querySQl.Connection = conSQL

        querySQL2.CommandText = "delete from KardexInventario"
        querySQL2.ExecuteNonQuery()
        querySQL2.CommandText = "Insert Into KardexInventario select Registro,CDProduto,Descricao,Qtde,Saldo,Saldo as SaldoVelho,0 as Empenho, 0 as EmpenhoVelho,Data,Status from Kardex where Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca & " order by Registro Desc"
        querySQL2.ExecuteNonQuery()

        querySQL2.CommandText = "Select * from KardexInventario"
        datRead2 = querySQL2.ExecuteReader()
        Do Until datRead2.Read = False
            sCDProduto = datRead2("CDProduto")
            iRegistro = datRead2("Registro")

            'Atualiza Saldo Anterior
            querySQl.CommandText = "select top 1 Saldo from kardex where cdproduto='" & sCDProduto & "' and Registro < " & iRegistro & " " & sBusca2 & " order by registro desc"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                dSaldoVelho = datRead("Saldo")
                datRead.Close()
                querySQl.CommandText = "update KardexInventario set SaldoVelho=" & Replace(dSaldoVelho, ",", ".") & " where registro=" & iRegistro & ""
                querySQl.ExecuteNonQuery()
            Else
                datRead.Close()
            End If


            'Atualiza Empenho 
            querySQl.CommandText = "select top 1 Saldo, Registro from kardex2 where cdproduto='" & sCDProduto & "' and Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca & " order by registro desc"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                dEmpenho = datRead("Saldo")
                iRegistroEmpenho = datRead("Registro")
                datRead.Close()
                querySQl.CommandText = "update KardexInventario set Empenho=" & Replace(dEmpenho, ",", ".") & " where CDProduto=" & sCDProduto & ""
                querySQl.ExecuteNonQuery()
            Else
                datRead.Close()
            End If


            'Atualiza Empenho Anterior
            querySQl.CommandText = "select top 1 Saldo from kardex2 where cdproduto='" & sCDProduto & "' and Registro < " & iRegistroEmpenho & " and Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca2 & " order by registro desc"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                dEmpenhoVelho = datRead("Saldo")
                datRead.Close()
                querySQl.CommandText = "update KardexInventario set EmpenhoVelho=" & Replace(dEmpenhoVelho, ",", ".") & " where CDProduto=" & sCDProduto & ""
                querySQl.ExecuteNonQuery()
            Else
                datRead.Close()
            End If
        Loop
        datRead2.Close()
        conSQL.Close()
        conSQL2.Close()


        'CARREGA Tipo de Endereco
        'Dim ds As New DataSet()
        'Dim adaptPai As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter("select * from Kardex where Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca & " order by Registro Desc", conSQL2)
        'Dim adaptFilho As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter("select * from Kardex where Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca2 & "  order by Registro Desc", conSQL2)

        'adaptPai.Fill(ds, "pai")
        'adaptFilho.Fill(ds, "filho")

        'Dim keyColumn As DataColumn = ds.Tables("pai").Columns("CDProduto")
        'Dim foreignKeyColumn As DataColumn = ds.Tables("filho").Columns("CDProduto")
        'ds.Relations.Add("PaiEFilho", keyColumn, foreignKeyColumn, False)
        'GridKardex.DataSource = ds.Tables("pai")

        'GridKardex.ForceInitialize()

        'Dim vView As GridView = New GridView(GridKardex)
        'GridKardex.LevelTree.Nodes.Add("PaiEFilho", GridView1)

        Dim ds As New DataSet()
        Dim adaptPai As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter("select a.*,(select b.ClassificacaoABC from Estoque b where a.cdproduto=b.cdproduto) as ABC from KardexInventario a order by a.Registro Desc", conSQL2)
        adaptPai.Fill(ds, "pai")
        GridKardex.DataSource = ds.Tables("pai")
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        busca()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With
        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView1.GridControl
        link.Margins.Left = 50
        link.Margins.Right = 50
        link.Landscape = False
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add(Date.Now.ToShortDateString())
        HeaderArea.Content.Add("Kardex - Histórico de Inventário")
        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center
        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        link.PageHeaderFooter = Header
        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dDataFim As Date = Date.Now.ToShortDateString()
        dDataFim = dDataFim.AddDays(1)
        Dim sMes As String = Date.Now.Month
        Dim dDataIni As String = "01/" & sMes.PadLeft(2, "0") & "/" & Date.Now.Year
        Dim cCDProduto As String = InputBox("Digite o codigo do produto", "Produto")
        Dim cCDInicio As String = InputBox("Digite a data inicial", "Data Inicial", dDataIni)
        Dim cCDFim As String = InputBox("Digite a data final", "Data Final", dDataFim)
        If cCDProduto <> "" And cCDFim <> "" And cCDInicio <> "" Then
            Dim x As New XtraFichaKardex(cCDProduto, cCDInicio, cCDFim)
            x.ShowPreview()
        End If
    End Sub
End Class