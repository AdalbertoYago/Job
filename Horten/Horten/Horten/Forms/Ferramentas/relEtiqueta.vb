Public Class relEtiqueta
    Public sCDProduto, sDescricao As String
    Public Sub New(ByVal ssCDProduto As String, ByVal ssDescricao As String, ByVal PBairro As String, ByVal PRua As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        XrLCodigo.Text = "CODIGO: " & ssCDProduto
        XrLDescricao.Text = ssDescricao
        XrBarCode1.Text = "0" & ssCDProduto
        LBLEndereco.Text = PBairro & " - " & PRua
        ' Add any initialization after the InitializeComponent() call.
        XrPictureBox1.ImageUrl = gLogoDanfe
    End Sub
End Class