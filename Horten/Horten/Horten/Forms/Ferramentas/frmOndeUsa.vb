Imports DevExpress.XtraReports.UI
Public Class frmOndeUsa
    Public datPubsEstoque, dsMP, dsSubCJ, datPubsComprador, datPubsFornec1, datPubsFornec2, datPubsFornec3, datPubsFornec4, datPubsFornec5, datPubsClassF, datPubsTribut, datPubsEstoqueEndereco As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Public sProduto As String


    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        sProduto = txtCDProduto.Text

        querySQL2.CommandText = "Select * From Estoque Where CDProduto = '" & sProduto.PadLeft(7, "0") & "'"
        datRead = querySQL2.ExecuteReader()
        If datRead.Read = True Then
            lblDescricao.Text = datRead("Descricao")
            carregaGrids(sProduto)
        Else
            MessageBox.Show("Código pai inexistente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
        datRead.Close()
    End Sub


    Public Sub carregaGrids(ByVal sCDProduto As String)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        'Produto
        If cbTipoEstoque.SelectedIndex <> 4 Then
            gVSQL = "Select Estrutura.*,Estoque.Descricao as Descricao2 From Estrutura Left Join Estoque On Estrutura.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where Cenario = 1 And CDMaterial = '" & sCDProduto & "' Order By Estrutura.CDProduto"
        Else
            gVSQL = "Select EstruturaSubCJ.*,Estoque.Descricao as Descricao2 From EstruturaSUBCJ Left Join Estoque On EstruturaSubCJ.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDItem = '" & sCDProduto & "' Order By EstruturaSubCJ.CDProduto"
        End If

        dsMP.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(dsMP, "MP")
        gridProduto.DataSource = dsMP.Tables("mp")

        'SubCJ
        Try
            gVSQL = "Select EstruturaMP.*,Estoque.Descricao  as Descricao2 From EstruturaMP Left Join Estoque On EstruturaMP.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDMaterial = '" & sCDProduto & "' Order By EstruturaMP.CDProduto"

            dsSubCJ.Clear()
            adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
            adaptSQL.Fill(dsSubCJ, "SubCJ")
            gridSubCJ.DataSource = dsSubCJ.Tables("SubCJ")
        Catch
        End Try

    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub frmOndeUsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbTipoEstoque.Items.Add("0 - Todos os Itens")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 2
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        If txtCDProduto.Text <> "" Then
            Dim rel As relOndeUsa = New relOndeUsa(txtCDProduto.Text, cbTipoEstoque.SelectedIndex(), lblDescricao.Text)
            rel.Margins.Left = 50
            rel.Margins.Right = 50
            rel.Margins.Top = 50
            rel.Margins.Bottom = 50
            rel.ShowPreview()
        Else
            MessageBox.Show("Selecione um item!", "Erro", MessageBoxButtons.OK)
        End If
    End Sub
End Class