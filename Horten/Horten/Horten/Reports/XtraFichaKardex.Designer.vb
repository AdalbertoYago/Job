<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class XtraFichaKardex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFichaKardex))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLSaldoInicial = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLDescricao = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLRegistro = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLDataKardex = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLEvento = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLEntrada = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLSaida = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLSaldo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLTotalEntrada = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLTotalSaida = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLData = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLEmpresa = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 558.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(717.0!, 558.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 0.1039426523297491R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLSaldoInicial, Me.XrLDescricao})
        Me.XrTableCell3.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.Text = "Periodo"
        Me.XrTableCell3.Weight = 1.0R
        '
        'XrLSaldoInicial
        '
        Me.XrLSaldoInicial.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLSaldoInicial.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLSaldoInicial.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 33.0!)
        Me.XrLSaldoInicial.Name = "XrLSaldoInicial"
        Me.XrLSaldoInicial.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLSaldoInicial.SizeF = New System.Drawing.SizeF(708.0!, 25.0!)
        Me.XrLSaldoInicial.StylePriority.UseBorders = False
        Me.XrLSaldoInicial.StylePriority.UseFont = False
        Me.XrLSaldoInicial.Text = "XrLCodigo"
        '
        'XrLDescricao
        '
        Me.XrLDescricao.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLDescricao.BorderWidth = 0.0!
        Me.XrLDescricao.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLDescricao.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 8.0!)
        Me.XrLDescricao.Name = "XrLDescricao"
        Me.XrLDescricao.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLDescricao.SizeF = New System.Drawing.SizeF(708.0!, 25.0!)
        Me.XrLDescricao.StylePriority.UseBorders = False
        Me.XrLDescricao.StylePriority.UseBorderWidth = False
        Me.XrLDescricao.StylePriority.UseFont = False
        Me.XrLDescricao.Text = "XrLCodigo"
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell10, Me.XrTableCell4, Me.XrTableCell12, Me.XrTableCell8, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 0.044802867383512544R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseBackColor = False
        Me.XrTableCell10.StylePriority.UseFont = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "Registro"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell10.Weight = 0.1394700139470014R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseBackColor = False
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "Data"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell4.Weight = 0.2914923291492329R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.StylePriority.UseBackColor = False
        Me.XrTableCell12.StylePriority.UseFont = False
        Me.XrTableCell12.StylePriority.UseTextAlignment = False
        Me.XrTableCell12.Text = "Evento"
        Me.XrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell12.Weight = 0.11576011157601115R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseBackColor = False
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "Entrada"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell8.Weight = 0.16317991631799164R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseBackColor = False
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = "Saída"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell5.Weight = 0.12133891213389121R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseBackColor = False
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = "Saldo"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell6.Weight = 0.16875871687587168R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell7, Me.XrTableCell9, Me.XrTableCell11, Me.XrTableCell13})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 0.80645161290322576R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLRegistro})
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell1.Weight = 0.1394700139470014R
        '
        'XrLRegistro
        '
        Me.XrLRegistro.BorderWidth = 0.0!
        Me.XrLRegistro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLRegistro.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLRegistro.Multiline = True
        Me.XrLRegistro.Name = "XrLRegistro"
        Me.XrLRegistro.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLRegistro.SizeF = New System.Drawing.SizeF(83.0!, 25.0!)
        Me.XrLRegistro.StylePriority.UseBorderWidth = False
        Me.XrLRegistro.StylePriority.UseFont = False
        Me.XrLRegistro.Text = "XrLRegistro"
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLDataKardex})
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell2.Weight = 0.2914923291492329R
        '
        'XrLDataKardex
        '
        Me.XrLDataKardex.BorderWidth = 0.0!
        Me.XrLDataKardex.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLDataKardex.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLDataKardex.Multiline = True
        Me.XrLDataKardex.Name = "XrLDataKardex"
        Me.XrLDataKardex.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLDataKardex.SizeF = New System.Drawing.SizeF(200.0!, 25.0!)
        Me.XrLDataKardex.StylePriority.UseBorderWidth = False
        Me.XrLDataKardex.StylePriority.UseFont = False
        Me.XrLDataKardex.Text = "XrLRegistro"
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLEvento})
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "XrTableCell7"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell7.Weight = 0.11576011157601115R
        '
        'XrLEvento
        '
        Me.XrLEvento.BorderWidth = 0.0!
        Me.XrLEvento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLEvento.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLEvento.Multiline = True
        Me.XrLEvento.Name = "XrLEvento"
        Me.XrLEvento.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLEvento.SizeF = New System.Drawing.SizeF(72.0!, 25.0!)
        Me.XrLEvento.StylePriority.UseBorderWidth = False
        Me.XrLEvento.StylePriority.UseFont = False
        Me.XrLEvento.Text = "XrLRegistro"
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLEntrada})
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "XrTableCell9"
        Me.XrTableCell9.Weight = 0.16317991631799164R
        '
        'XrLEntrada
        '
        Me.XrLEntrada.BorderWidth = 0.0!
        Me.XrLEntrada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLEntrada.LocationFloat = New DevExpress.Utils.PointFloat(33.0!, 0.0!)
        Me.XrLEntrada.Multiline = True
        Me.XrLEntrada.Name = "XrLEntrada"
        Me.XrLEntrada.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLEntrada.SizeF = New System.Drawing.SizeF(81.0!, 25.0!)
        Me.XrLEntrada.StylePriority.UseBorderWidth = False
        Me.XrLEntrada.StylePriority.UseFont = False
        Me.XrLEntrada.StylePriority.UseTextAlignment = False
        Me.XrLEntrada.Text = "XrLRegistro"
        Me.XrLEntrada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLSaida})
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "XrTableCell11"
        Me.XrTableCell11.Weight = 0.12133891213389121R
        '
        'XrLSaida
        '
        Me.XrLSaida.BorderWidth = 0.0!
        Me.XrLSaida.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLSaida.LocationFloat = New DevExpress.Utils.PointFloat(7.0!, 0.0!)
        Me.XrLSaida.Multiline = True
        Me.XrLSaida.Name = "XrLSaida"
        Me.XrLSaida.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLSaida.SizeF = New System.Drawing.SizeF(75.0!, 25.0!)
        Me.XrLSaida.StylePriority.UseBorderWidth = False
        Me.XrLSaida.StylePriority.UseFont = False
        Me.XrLSaida.StylePriority.UseTextAlignment = False
        Me.XrLSaida.Text = "XrLRegistro"
        Me.XrLSaida.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLSaldo})
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "XrTableCell13"
        Me.XrTableCell13.Weight = 0.16875871687587168R
        '
        'XrLSaldo
        '
        Me.XrLSaldo.BorderWidth = 0.0!
        Me.XrLSaldo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLSaldo.LocationFloat = New DevExpress.Utils.PointFloat(4.0!, 0.0!)
        Me.XrLSaldo.Multiline = True
        Me.XrLSaldo.Name = "XrLSaldo"
        Me.XrLSaldo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLSaldo.SizeF = New System.Drawing.SizeF(117.0!, 25.0!)
        Me.XrLSaldo.StylePriority.UseBorderWidth = False
        Me.XrLSaldo.StylePriority.UseFont = False
        Me.XrLSaldo.StylePriority.UseTextAlignment = False
        Me.XrLSaldo.Text = "XrLRegistro"
        Me.XrLSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell14, Me.XrTableCell15, Me.XrTableCell16, Me.XrTableCell17, Me.XrTableCell18, Me.XrTableCell19})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 0.044802867383512544R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Weight = 0.1394700139470014R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Weight = 0.2914923291492329R
        '
        'XrTableCell16
        '
        Me.XrTableCell16.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2})
        Me.XrTableCell16.Name = "XrTableCell16"
        Me.XrTableCell16.Weight = 0.11576011157601115R
        '
        'XrLabel2
        '
        Me.XrLabel2.BorderWidth = 0.0!
        Me.XrLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(81.0!, 25.0!)
        Me.XrLabel2.StylePriority.UseBorderWidth = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Totais:"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLTotalEntrada})
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.Text = "XrTableCell17"
        Me.XrTableCell17.Weight = 0.16178521617852162R
        '
        'XrLTotalEntrada
        '
        Me.XrLTotalEntrada.BorderWidth = 0.0!
        Me.XrLTotalEntrada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLTotalEntrada.LocationFloat = New DevExpress.Utils.PointFloat(33.0!, 0.0!)
        Me.XrLTotalEntrada.Multiline = True
        Me.XrLTotalEntrada.Name = "XrLTotalEntrada"
        Me.XrLTotalEntrada.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLTotalEntrada.SizeF = New System.Drawing.SizeF(81.0!, 25.0!)
        Me.XrLTotalEntrada.StylePriority.UseBorderWidth = False
        Me.XrLTotalEntrada.StylePriority.UseFont = False
        Me.XrLTotalEntrada.StylePriority.UseTextAlignment = False
        Me.XrLTotalEntrada.Text = "XrLRegistro"
        Me.XrLTotalEntrada.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLTotalSaida})
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.Text = "XrTableCell18"
        Me.XrTableCell18.Weight = 0.12273361227336123R
        '
        'XrLTotalSaida
        '
        Me.XrLTotalSaida.BorderWidth = 0.0!
        Me.XrLTotalSaida.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLTotalSaida.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 0.0!)
        Me.XrLTotalSaida.Multiline = True
        Me.XrLTotalSaida.Name = "XrLTotalSaida"
        Me.XrLTotalSaida.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLTotalSaida.SizeF = New System.Drawing.SizeF(75.0!, 25.0!)
        Me.XrLTotalSaida.StylePriority.UseBorderWidth = False
        Me.XrLTotalSaida.StylePriority.UseFont = False
        Me.XrLTotalSaida.StylePriority.UseTextAlignment = False
        Me.XrLTotalSaida.Text = "XrLRegistro"
        Me.XrLTotalSaida.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.Weight = 0.16875871687587168R
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1})
        Me.PageHeader.HeightF = 97.0!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLData, Me.XrLabel1, Me.XrLEmpresa, Me.XrPictureBox1})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(717.0!, 92.0!)
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'XrLData
        '
        Me.XrLData.BorderWidth = 0.0!
        Me.XrLData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLData.LocationFloat = New DevExpress.Utils.PointFloat(183.0!, 58.0!)
        Me.XrLData.Name = "XrLData"
        Me.XrLData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLData.SizeF = New System.Drawing.SizeF(333.0!, 25.0!)
        Me.XrLData.StylePriority.UseBorderWidth = False
        Me.XrLData.StylePriority.UseFont = False
        Me.XrLData.Text = "Data"
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(183.0!, 33.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(333.0!, 25.0!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Ficha Kardex"
        '
        'XrLEmpresa
        '
        Me.XrLEmpresa.BorderWidth = 0.0!
        Me.XrLEmpresa.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLEmpresa.LocationFloat = New DevExpress.Utils.PointFloat(183.0!, 8.0!)
        Me.XrLEmpresa.Multiline = True
        Me.XrLEmpresa.Name = "XrLEmpresa"
        Me.XrLEmpresa.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLEmpresa.SizeF = New System.Drawing.SizeF(333.0!, 33.0!)
        Me.XrLEmpresa.StylePriority.UseBorderWidth = False
        Me.XrLEmpresa.StylePriority.UseFont = False
        Me.XrLEmpresa.StylePriority.UsePadding = False
        Me.XrLEmpresa.StylePriority.UseTextAlignment = False
        Me.XrLEmpresa.Text = "XrLEmpresa"
        Me.XrLEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.BorderWidth = 0.0!
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 8.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(167.0!, 75.0!)
        Me.XrPictureBox1.StylePriority.UseBorderWidth = False
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.PageFooter.HeightF = 30.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 25.0!)
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 50.0!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 50.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'XtraFichaKardex
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter, Me.TopMarginBand1, Me.BottomMarginBand1})
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "13.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLData As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLEmpresa As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLDescricao As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLRegistro As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLDataKardex As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLEvento As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLEntrada As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLSaida As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLSaldo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLSaldoInicial As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLTotalEntrada As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLTotalSaida As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
End Class
