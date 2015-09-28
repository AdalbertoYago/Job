<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaEstoque
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAte = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbDe = New DevExpress.XtraEditors.DateEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BTSelecionar = New DevExpress.XtraEditors.SimpleButton()
        Me.BTSair = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.BTImpFicha = New DevExpress.XtraEditors.SimpleButton()
        Me.cbEmpresas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.tbAte.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDe.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(117, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Até"
        '
        'tbAte
        '
        Me.tbAte.EditValue = Nothing
        Me.tbAte.Location = New System.Drawing.Point(114, 18)
        Me.tbAte.Name = "tbAte"
        Me.tbAte.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tbAte.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.tbAte.Size = New System.Drawing.Size(100, 20)
        Me.tbAte.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "De"
        '
        'tbDe
        '
        Me.tbDe.EditValue = Nothing
        Me.tbDe.Location = New System.Drawing.Point(8, 17)
        Me.tbDe.Name = "tbDe"
        Me.tbDe.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tbDe.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.tbDe.Size = New System.Drawing.Size(100, 20)
        Me.tbDe.TabIndex = 78
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 64)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(544, 328)
        Me.GridControl1.TabIndex = 80
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DarkOrange
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkOrange
        Me.GridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView1.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.SkyBlue
        Me.GridView1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView1.Appearance.Empty.Options.UseBackColor = True
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Linen
        Me.GridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.AntiqueWhite
        Me.GridView1.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.Orange
        Me.GridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView1.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Wheat
        Me.GridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Wheat
        Me.GridView1.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Wheat
        Me.GridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Wheat
        Me.GridView1.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Wheat
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupRow.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray
        Me.GridView1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Tan
        Me.GridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.Appearance.Preview.BackColor = System.Drawing.Color.Khaki
        Me.GridView1.Appearance.Preview.BackColor2 = System.Drawing.Color.Cornsilk
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 7.5!)
        Me.GridView1.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView1.Appearance.Preview.Options.UseBackColor = True
        Me.GridView1.Appearance.Preview.Options.UseFont = True
        Me.GridView1.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.Row.Options.UseBackColor = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Tan
        Me.GridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridView1.AppearancePrint.Row.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(980, 511, 216, 178)
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition1.Appearance.Options.UseBackColor = True
        StyleFormatCondition1.Appearance.Options.UseForeColor = True
        StyleFormatCondition1.ApplyToRow = True
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = "Imediato"
        StyleFormatCondition1.Value2 = "Imediato"
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValorTotal", Nothing, "{0:c2}")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Nº NF"
        Me.GridColumn14.FieldName = "CDNF"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 55
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Código"
        Me.GridColumn4.FieldName = "CDProduto"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.AllowFilter = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 93
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Produtos"
        Me.GridColumn5.FieldName = "Descricao"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn5.OptionsFilter.AllowFilter = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 288
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn6.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn6.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Total"
        Me.GridColumn6.DisplayFormat.FormatString = "n"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "Total"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn6.OptionsFilter.AllowFilter = False
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n2}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 81
        '
        'BTSelecionar
        '
        Me.BTSelecionar.ImageIndex = 0
        Me.BTSelecionar.Location = New System.Drawing.Point(512, 8)
        Me.BTSelecionar.LookAndFeel.SkinName = "Money Twins"
        Me.BTSelecionar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BTSelecionar.Name = "BTSelecionar"
        Me.BTSelecionar.Size = New System.Drawing.Size(80, 32)
        Me.BTSelecionar.TabIndex = 81
        Me.BTSelecionar.Text = "Selecionar"
        '
        'BTSair
        '
        Me.BTSair.ImageIndex = 0
        Me.BTSair.Location = New System.Drawing.Point(1008, 8)
        Me.BTSair.LookAndFeel.SkinName = "Money Twins"
        Me.BTSair.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BTSair.Name = "BTSair"
        Me.BTSair.Size = New System.Drawing.Size(80, 39)
        Me.BTSair.TabIndex = 82
        Me.BTSair.Text = "Sair"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(552, 64)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(544, 328)
        Me.GridControl2.TabIndex = 83
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DarkOrange
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkOrange
        Me.GridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView2.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.SkyBlue
        Me.GridView2.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView2.Appearance.Empty.Options.UseBackColor = True
        Me.GridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.Linen
        Me.GridView2.Appearance.EvenRow.BackColor2 = System.Drawing.Color.AntiqueWhite
        Me.GridView2.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.GridView2.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.Orange
        Me.GridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView2.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.Wheat
        Me.GridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.Wheat
        Me.GridView2.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.Wheat
        Me.GridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Wheat
        Me.GridView2.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.Wheat
        Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView2.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupRow.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView2.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray
        Me.GridView2.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Tan
        Me.GridView2.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView2.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView2.Appearance.Preview.BackColor = System.Drawing.Color.Khaki
        Me.GridView2.Appearance.Preview.BackColor2 = System.Drawing.Color.Cornsilk
        Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 7.5!)
        Me.GridView2.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView2.Appearance.Preview.Options.UseBackColor = True
        Me.GridView2.Appearance.Preview.Options.UseFont = True
        Me.GridView2.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.Row.Options.UseBackColor = True
        Me.GridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Tan
        Me.GridView2.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridView2.AppearancePrint.Row.Options.UseFont = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GridView2.CustomizationFormBounds = New System.Drawing.Rectangle(980, 511, 216, 178)
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition2.Appearance.Options.UseBackColor = True
        StyleFormatCondition2.Appearance.Options.UseForeColor = True
        StyleFormatCondition2.ApplyToRow = True
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Value1 = "Imediato"
        StyleFormatCondition2.Value2 = "Imediato"
        Me.GridView2.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition2})
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValorTotal", Nothing, "{0:c2}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView2.OptionsView.EnableAppearanceOddRow = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.Caption = "Produto"
        Me.GridColumn10.FieldName = "CDProduto"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 85
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Código"
        Me.GridColumn1.FieldName = "CDMaterial"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsFilter.AllowFilter = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 69
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Matéria Prima"
        Me.GridColumn2.FieldName = "Descricao"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsFilter.AllowFilter = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 276
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn3.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn3.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Total"
        Me.GridColumn3.DisplayFormat.FormatString = "n"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "Total"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsFilter.AllowFilter = False
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n2}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 72
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(0, 400)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(1096, 216)
        Me.GridControl3.TabIndex = 84
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DarkOrange
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView3.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkOrange
        Me.GridView3.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView3.Appearance.Empty.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView3.Appearance.Empty.BackColor2 = System.Drawing.Color.SkyBlue
        Me.GridView3.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView3.Appearance.Empty.Options.UseBackColor = True
        Me.GridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.Linen
        Me.GridView3.Appearance.EvenRow.BackColor2 = System.Drawing.Color.AntiqueWhite
        Me.GridView3.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.GridView3.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.FilterPanel.BackColor = System.Drawing.Color.DarkOrange
        Me.GridView3.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.Orange
        Me.GridView3.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView3.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView3.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView3.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView3.Appearance.FooterPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupButton.BackColor = System.Drawing.Color.Wheat
        Me.GridView3.Appearance.GroupButton.BorderColor = System.Drawing.Color.Wheat
        Me.GridView3.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.Wheat
        Me.GridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Wheat
        Me.GridView3.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.RoyalBlue
        Me.GridView3.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.Wheat
        Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupRow.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Orange
        Me.GridView3.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray
        Me.GridView3.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Tan
        Me.GridView3.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView3.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView3.Appearance.Preview.BackColor = System.Drawing.Color.Khaki
        Me.GridView3.Appearance.Preview.BackColor2 = System.Drawing.Color.Cornsilk
        Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 7.5!)
        Me.GridView3.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView3.Appearance.Preview.Options.UseBackColor = True
        Me.GridView3.Appearance.Preview.Options.UseFont = True
        Me.GridView3.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.Row.Options.UseBackColor = True
        Me.GridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Tan
        Me.GridView3.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridView3.AppearancePrint.Row.Options.UseFont = True
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridView3.CustomizationFormBounds = New System.Drawing.Rectangle(980, 511, 216, 178)
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        StyleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Black
        StyleFormatCondition3.Appearance.Options.UseBackColor = True
        StyleFormatCondition3.Appearance.Options.UseForeColor = True
        StyleFormatCondition3.ApplyToRow = True
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition3.Value1 = "Imediato"
        StyleFormatCondition3.Value2 = "Imediato"
        Me.GridView3.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition3})
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValorTotal", Nothing, "{0:c2}")})
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView3.OptionsView.EnableAppearanceOddRow = True
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "Código"
        Me.GridColumn7.FieldName = "CDMaterial"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn7.OptionsFilter.AllowFilter = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 107
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Matéria Prima"
        Me.GridColumn8.FieldName = "Descricao"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn8.OptionsFilter.AllowFilter = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 359
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn9.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridColumn9.AppearanceCell.Options.UseBackColor = True
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Qtde Vendida"
        Me.GridColumn9.DisplayFormat.FormatString = "n"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "Total"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn9.OptionsFilter.AllowFilter = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 118
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.Caption = "Qtde Comprada"
        Me.GridColumn11.DisplayFormat.FormatString = "n"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "Compras"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 3
        Me.GridColumn11.Width = 120
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Estoque"
        Me.GridColumn12.DisplayFormat.FormatString = "n"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "Estoque"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 4
        Me.GridColumn12.Width = 100
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Saldo"
        Me.GridColumn13.DisplayFormat.FormatString = "n"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 120
        '
        'CheckEdit1
        '
        Me.CheckEdit1.EditValue = True
        Me.CheckEdit1.Location = New System.Drawing.Point(552, 40)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "MP Agrupada"
        Me.CheckEdit1.Size = New System.Drawing.Size(87, 19)
        Me.CheckEdit1.TabIndex = 85
        '
        'CheckEdit2
        '
        Me.CheckEdit2.EditValue = True
        Me.CheckEdit2.Location = New System.Drawing.Point(0, 40)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Properties.Caption = "Produto Agrupado"
        Me.CheckEdit2.Size = New System.Drawing.Size(112, 19)
        Me.CheckEdit2.TabIndex = 86
        '
        'BTImpFicha
        '
        Me.BTImpFicha.ImageIndex = 0
        Me.BTImpFicha.Location = New System.Drawing.Point(624, 8)
        Me.BTImpFicha.LookAndFeel.SkinName = "Money Twins"
        Me.BTImpFicha.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BTImpFicha.Name = "BTImpFicha"
        Me.BTImpFicha.Size = New System.Drawing.Size(80, 32)
        Me.BTImpFicha.TabIndex = 87
        Me.BTImpFicha.Text = "Imprimir Ficha"
        '
        'cbEmpresas
        '
        Me.cbEmpresas.FormattingEnabled = True
        Me.cbEmpresas.Location = New System.Drawing.Point(224, 17)
        Me.cbEmpresas.Name = "cbEmpresas"
        Me.cbEmpresas.Size = New System.Drawing.Size(279, 21)
        Me.cbEmpresas.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(225, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Empresa"
        '
        'frmFichaEstoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 615)
        Me.Controls.Add(Me.cbEmpresas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTImpFicha)
        Me.Controls.Add(Me.CheckEdit2)
        Me.Controls.Add(Me.CheckEdit1)
        Me.Controls.Add(Me.GridControl3)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.BTSair)
        Me.Controls.Add(Me.BTSelecionar)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbAte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbDe)
        Me.Name = "frmFichaEstoque"
        Me.Text = "frmFichaEstoque"
        CType(Me.tbAte.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDe.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbAte As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbDe As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BTSelecionar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BTSair As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BTImpFicha As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
End Class
