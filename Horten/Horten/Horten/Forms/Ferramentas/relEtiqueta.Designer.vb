<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class relEtiqueta
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Interleaved2of5Generator1 As DevExpress.XtraPrinting.BarCode.Interleaved2of5Generator = New DevExpress.XtraPrinting.BarCode.Interleaved2of5Generator
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.LBLEndereco = New DevExpress.XtraReports.UI.XRLabel
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox
        Me.XrBarCode1 = New DevExpress.XtraReports.UI.XRBarCode
        Me.XrLDescricao = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLCodigo = New DevExpress.XtraReports.UI.XRLabel
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LBLEndereco, Me.XrPictureBox1, Me.XrBarCode1, Me.XrLDescricao, Me.XrLCodigo})
        Me.Detail.Dpi = 254.0!
        Me.Detail.Height = 518
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LBLEndereco
        '
        Me.LBLEndereco.Dpi = 254.0!
        Me.LBLEndereco.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEndereco.Location = New System.Drawing.Point(42, 423)
        Me.LBLEndereco.Name = "LBLEndereco"
        Me.LBLEndereco.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.LBLEndereco.Size = New System.Drawing.Size(826, 64)
        Me.LBLEndereco.StylePriority.UseFont = False
        Me.LBLEndereco.StylePriority.UseTextAlignment = False
        Me.LBLEndereco.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Dpi = 254.0!
        Me.XrPictureBox1.ImageUrl = "C:\prisma\imagens\logoClassica.jpg"
        Me.XrPictureBox1.Location = New System.Drawing.Point(254, 0)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.Size = New System.Drawing.Size(339, 169)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrBarCode1
        '
        Me.XrBarCode1.Dpi = 254.0!
        Me.XrBarCode1.Location = New System.Drawing.Point(233, 318)
        Me.XrBarCode1.Module = 5.08!
        Me.XrBarCode1.Name = "XrBarCode1"
        Me.XrBarCode1.Padding = New DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254.0!)
        Me.XrBarCode1.ShowText = False
        Me.XrBarCode1.Size = New System.Drawing.Size(593, 106)
        Me.XrBarCode1.StylePriority.UseTextAlignment = False
        Interleaved2of5Generator1.CalcCheckSum = False
        Interleaved2of5Generator1.WideNarrowRatio = 3.0!
        Me.XrBarCode1.Symbology = Interleaved2of5Generator1
        Me.XrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLDescricao
        '
        Me.XrLDescricao.Dpi = 254.0!
        Me.XrLDescricao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLDescricao.Location = New System.Drawing.Point(21, 254)
        Me.XrLDescricao.Name = "XrLDescricao"
        Me.XrLDescricao.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLDescricao.Size = New System.Drawing.Size(847, 64)
        Me.XrLDescricao.StylePriority.UseFont = False
        Me.XrLDescricao.StylePriority.UseTextAlignment = False
        Me.XrLDescricao.Text = "Descricao"
        Me.XrLDescricao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLCodigo
        '
        Me.XrLCodigo.Dpi = 254.0!
        Me.XrLCodigo.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLCodigo.Location = New System.Drawing.Point(21, 190)
        Me.XrLCodigo.Name = "XrLCodigo"
        Me.XrLCodigo.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLCodigo.Size = New System.Drawing.Size(847, 64)
        Me.XrLCodigo.StylePriority.UseFont = False
        Me.XrLCodigo.StylePriority.UseTextAlignment = False
        Me.XrLCodigo.Text = "Código"
        Me.XrLCodigo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'relEtiqueta
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail})
        Me.Dpi = 254.0!
        Me.Margins = New System.Drawing.Printing.Margins(51, 51, 254, 254)
        Me.PageHeight = 599
        Me.PageWidth = 1001
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.Version = "8.3"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLDescricao As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLCodigo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrBarCode1 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents LBLEndereco As DevExpress.XtraReports.UI.XRLabel
End Class
