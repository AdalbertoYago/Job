<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RelItemFornecidoRecebido
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.XrLTransportadora = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLEndereco = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLNome = New DevExpress.XtraReports.UI.XRLabel
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLTransportadora, Me.XrLEndereco, Me.XrLNome})
        Me.Detail.Dpi = 254.0!
        Me.Detail.Height = 471
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLTransportadora
        '
        Me.XrLTransportadora.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLTransportadora.BorderWidth = 0
        Me.XrLTransportadora.Dpi = 254.0!
        Me.XrLTransportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLTransportadora.Location = New System.Drawing.Point(85, 254)
        Me.XrLTransportadora.Name = "XrLTransportadora"
        Me.XrLTransportadora.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLTransportadora.Size = New System.Drawing.Size(826, 85)
        Me.XrLTransportadora.StylePriority.UseBorders = False
        Me.XrLTransportadora.StylePriority.UseBorderWidth = False
        Me.XrLTransportadora.StylePriority.UseFont = False
        Me.XrLTransportadora.StylePriority.UseTextAlignment = False
        Me.XrLTransportadora.Text = "XrLTransportadora"
        Me.XrLTransportadora.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLEndereco
        '
        Me.XrLEndereco.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLEndereco.BorderWidth = 0
        Me.XrLEndereco.Dpi = 254.0!
        Me.XrLEndereco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLEndereco.Location = New System.Drawing.Point(85, 127)
        Me.XrLEndereco.Multiline = True
        Me.XrLEndereco.Name = "XrLEndereco"
        Me.XrLEndereco.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLEndereco.Size = New System.Drawing.Size(826, 127)
        Me.XrLEndereco.StylePriority.UseBorders = False
        Me.XrLEndereco.StylePriority.UseBorderWidth = False
        Me.XrLEndereco.StylePriority.UseFont = False
        Me.XrLEndereco.StylePriority.UseTextAlignment = False
        Me.XrLEndereco.Text = "XrLEndereco"
        Me.XrLEndereco.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLNome
        '
        Me.XrLNome.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLNome.BorderWidth = 0
        Me.XrLNome.Dpi = 254.0!
        Me.XrLNome.Font = New System.Drawing.Font("Arial", 13.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLNome.Location = New System.Drawing.Point(64, 42)
        Me.XrLNome.Name = "XrLNome"
        Me.XrLNome.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLNome.Size = New System.Drawing.Size(868, 85)
        Me.XrLNome.StylePriority.UseBorders = False
        Me.XrLNome.StylePriority.UseBorderWidth = False
        Me.XrLNome.StylePriority.UseFont = False
        Me.XrLNome.StylePriority.UseTextAlignment = False
        Me.XrLNome.Text = "XrLNome"
        Me.XrLNome.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'RelItemFornecidoRecebido
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail})
        Me.Dpi = 254.0!
        Me.Margins = New System.Drawing.Printing.Margins(10, 10, 40, 40)
        Me.PageHeight = 600
        Me.PageWidth = 1000
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.Version = "8.3"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLTransportadora As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLEndereco As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLNome As DevExpress.XtraReports.UI.XRLabel
End Class
