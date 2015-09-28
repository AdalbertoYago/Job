Imports DevExpress.XtraReports.UI
Public Class frmImprimeEtiqueta
    Public datPubs1, datPubs2, datPubsKardex As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub txtCDProduto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCDProduto.LostFocus
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        Try
            querySQl.CommandText = "Select Descricao from Estoque where CDProduto='" & txtCDProduto.Text & "'"
            LBLDescricao.Text = querySQl.ExecuteScalar()
        Catch
            MessageBox.Show("Produto não encontrado!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conSQL.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        If txtCDProduto.Text <> "" Then
            Dim c As relEtiqueta = New relEtiqueta(txtCDProduto.Text, LBLDescricao.Text, "", "")
            c.Margins.Top = 40
            c.Margins.Bottom = 40
            c.ShowPreview()
        Else
            MessageBox.Show("Digite o código do Produto", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class