<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemFornecidoRecebido
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemFornecidoRecebido))
        Me.bt0Sair = New DevExpress.XtraEditors.SimpleButton
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage
        Me.cbStatus2 = New System.Windows.Forms.ComboBox
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.txtCDCliente = New System.Windows.Forms.TextBox
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl
        Me.txtItens = New System.Windows.Forms.TextBox
        Me.ckContabiliza = New System.Windows.Forms.CheckBox
        Me.txtData = New System.Windows.Forms.MaskedTextBox
        Me.txtNF = New System.Windows.Forms.TextBox
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl
        Me.txtFornecedor = New System.Windows.Forms.TextBox
        Me.bt0Novo = New DevExpress.XtraEditors.SimpleButton
        Me.bt0Excluir = New DevExpress.XtraEditors.SimpleButton
        Me.bt0Alterar = New DevExpress.XtraEditors.SimpleButton
        Me.bt0Incluir = New DevExpress.XtraEditors.SimpleButton
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl
        Me.txtCDControle = New System.Windows.Forms.TextBox
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl
        Me.txtDescricao = New System.Windows.Forms.TextBox
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.txtUM = New System.Windows.Forms.TextBox
        Me.txtQtde = New System.Windows.Forms.TextBox
        Me.txtCDPedido = New System.Windows.Forms.TextBox
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt0Sair
        '
        Me.bt0Sair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Sair.Location = New System.Drawing.Point(1051, 566)
        Me.bt0Sair.LookAndFeel.SkinName = "The Asphalt World"
        Me.bt0Sair.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Sair.Name = "bt0Sair"
        Me.bt0Sair.Size = New System.Drawing.Size(75, 23)
        Me.bt0Sair.TabIndex = 158
        Me.bt0Sair.Text = "Sair"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList2.Images.SetKeyName(0, "")
        Me.ImageList2.Images.SetKeyName(1, "")
        Me.ImageList2.Images.SetKeyName(2, "")
        Me.ImageList2.Images.SetKeyName(3, "")
        Me.ImageList2.Images.SetKeyName(4, "")
        Me.ImageList2.Images.SetKeyName(5, "attach-16x16.gif")
        Me.ImageList2.Images.SetKeyName(6, "fcremovehot.gif")
        '
        'GridControl1
        '
        Me.GridControl1.AllowDrop = True
        Me.GridControl1.Location = New System.Drawing.Point(3, 46)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1105, 472)
        Me.GridControl1.TabIndex = 170
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView1.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.Empty.Options.UseBackColor = True
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.GridView1.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView1.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView1.Appearance.GroupRow.Options.UseFont = True
        Me.GridView1.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView1.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.GridView1.Appearance.Preview.Options.UseBackColor = True
        Me.GridView1.Appearance.Preview.Options.UseForeColor = True
        Me.GridView1.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView1.Appearance.Row.Options.UseBackColor = True
        Me.GridView1.Appearance.Row.Options.UseForeColor = True
        Me.GridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.GridView1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn14, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn12, Me.GridColumn13, Me.GridColumn15, Me.GridColumn4, Me.GridColumn5})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(889, 473, 216, 178)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Nº Controle"
        Me.GridColumn1.FieldName = "CDControle"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.SummaryItem.FieldName = "Id"
        Me.GridColumn1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Cliente"
        Me.GridColumn2.FieldName = "CDCliente"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        Me.GridColumn2.Width = 153
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Pedido"
        Me.GridColumn3.FieldName = "CDPedido"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 8
        Me.GridColumn3.Width = 55
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Qtde"
        Me.GridColumn14.FieldName = "Qtde"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        Me.GridColumn14.Width = 43
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "Data de Recebimento"
        Me.GridColumn6.DisplayFormat.FormatString = "d"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "Data"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        Me.GridColumn6.Width = 122
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "NF"
        Me.GridColumn7.FieldName = "NF"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        Me.GridColumn7.Width = 47
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Fornecedor"
        Me.GridColumn8.FieldName = "Fornecedor"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 115
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Descrição"
        Me.GridColumn9.FieldName = "Descricao"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 174
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "Status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Width = 86
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Observação"
        Me.GridColumn13.FieldName = "Obs"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 9
        Me.GridColumn13.Width = 178
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "UM"
        Me.GridColumn15.FieldName = "UM"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        Me.GridColumn15.Width = 39
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Itens do Pedido"
        Me.GridColumn4.FieldName = "ItensPedido"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 10
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Contabiliza"
        Me.GridColumn5.FieldName = "Contabiliza"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(6, 9)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1120, 551)
        Me.XtraTabControl1.TabIndex = 173
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.cbStatus2)
        Me.XtraTabPage1.Controls.Add(Me.LabelControl12)
        Me.XtraTabPage1.Controls.Add(Me.GridControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1111, 520)
        Me.XtraTabPage1.Text = "Lista de Itens Fornecidos Recebidos"
        '
        'cbStatus2
        '
        Me.cbStatus2.FormattingEnabled = True
        Me.cbStatus2.Location = New System.Drawing.Point(39, 9)
        Me.cbStatus2.Name = "cbStatus2"
        Me.cbStatus2.Size = New System.Drawing.Size(233, 21)
        Me.cbStatus2.TabIndex = 175
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(3, 14)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl12.TabIndex = 174
        Me.LabelControl12.Text = "Status"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GroupControl1)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1111, 520)
        Me.XtraTabPage2.Text = "Dados"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtCDCliente)
        Me.GroupControl1.Controls.Add(Me.LabelControl13)
        Me.GroupControl1.Controls.Add(Me.txtItens)
        Me.GroupControl1.Controls.Add(Me.ckContabiliza)
        Me.GroupControl1.Controls.Add(Me.txtData)
        Me.GroupControl1.Controls.Add(Me.txtNF)
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.txtFornecedor)
        Me.GroupControl1.Controls.Add(Me.bt0Novo)
        Me.GroupControl1.Controls.Add(Me.bt0Excluir)
        Me.GroupControl1.Controls.Add(Me.bt0Alterar)
        Me.GroupControl1.Controls.Add(Me.bt0Incluir)
        Me.GroupControl1.Controls.Add(Me.txtObs)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.txtCDControle)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.txtDescricao)
        Me.GroupControl1.Controls.Add(Me.cbStatus)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.txtUM)
        Me.GroupControl1.Controls.Add(Me.txtQtde)
        Me.GroupControl1.Controls.Add(Me.txtCDPedido)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(590, 500)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Dados do Item Fornecido"
        '
        'txtCDCliente
        '
        Me.txtCDCliente.Location = New System.Drawing.Point(17, 108)
        Me.txtCDCliente.Name = "txtCDCliente"
        Me.txtCDCliente.Size = New System.Drawing.Size(264, 20)
        Me.txtCDCliente.TabIndex = 174
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(445, 90)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl13.TabIndex = 173
        Me.LabelControl13.Text = "Itens do Pedido"
        '
        'txtItens
        '
        Me.txtItens.Location = New System.Drawing.Point(445, 109)
        Me.txtItens.Name = "txtItens"
        Me.txtItens.Size = New System.Drawing.Size(112, 20)
        Me.txtItens.TabIndex = 6
        '
        'ckContabiliza
        '
        Me.ckContabiliza.AutoSize = True
        Me.ckContabiliza.Location = New System.Drawing.Point(445, 162)
        Me.ckContabiliza.Name = "ckContabiliza"
        Me.ckContabiliza.Size = New System.Drawing.Size(77, 17)
        Me.ckContabiliza.TabIndex = 9
        Me.ckContabiliza.Text = "Contabiliza"
        Me.ckContabiliza.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(445, 54)
        Me.txtData.Mask = "00/00/0000"
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(112, 20)
        Me.txtData.TabIndex = 3
        Me.txtData.ValidatingType = GetType(Date)
        '
        'txtNF
        '
        Me.txtNF.Location = New System.Drawing.Point(287, 160)
        Me.txtNF.Name = "txtNF"
        Me.txtNF.Size = New System.Drawing.Size(152, 20)
        Me.txtNF.TabIndex = 8
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(287, 141)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl11.TabIndex = 170
        Me.LabelControl11.Text = "Nota Fiscal"
        '
        'txtFornecedor
        '
        Me.txtFornecedor.Location = New System.Drawing.Point(18, 160)
        Me.txtFornecedor.Name = "txtFornecedor"
        Me.txtFornecedor.Size = New System.Drawing.Size(263, 20)
        Me.txtFornecedor.TabIndex = 7
        '
        'bt0Novo
        '
        Me.bt0Novo.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.bt0Novo.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0Novo.Appearance.Options.UseBackColor = True
        Me.bt0Novo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Novo.Location = New System.Drawing.Point(17, 455)
        Me.bt0Novo.LookAndFeel.SkinName = "The Asphalt World"
        Me.bt0Novo.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Novo.Name = "bt0Novo"
        Me.bt0Novo.Size = New System.Drawing.Size(75, 25)
        Me.bt0Novo.TabIndex = 168
        Me.bt0Novo.Text = "Novo"
        '
        'bt0Excluir
        '
        Me.bt0Excluir.Appearance.BackColor = System.Drawing.Color.RosyBrown
        Me.bt0Excluir.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0Excluir.Appearance.Options.UseBackColor = True
        Me.bt0Excluir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Excluir.ImageIndex = 3
        Me.bt0Excluir.ImageList = Me.ImageList2
        Me.bt0Excluir.Location = New System.Drawing.Point(263, 456)
        Me.bt0Excluir.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Excluir.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Excluir.Name = "bt0Excluir"
        Me.bt0Excluir.Size = New System.Drawing.Size(75, 23)
        Me.bt0Excluir.TabIndex = 166
        Me.bt0Excluir.Text = "Excluir"
        '
        'bt0Alterar
        '
        Me.bt0Alterar.Appearance.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt0Alterar.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0Alterar.Appearance.Options.UseBackColor = True
        Me.bt0Alterar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Alterar.ImageIndex = 5
        Me.bt0Alterar.ImageList = Me.ImageList2
        Me.bt0Alterar.Location = New System.Drawing.Point(182, 456)
        Me.bt0Alterar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Alterar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Alterar.Name = "bt0Alterar"
        Me.bt0Alterar.Size = New System.Drawing.Size(75, 23)
        Me.bt0Alterar.TabIndex = 167
        Me.bt0Alterar.Text = "Alterar"
        '
        'bt0Incluir
        '
        Me.bt0Incluir.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.bt0Incluir.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0Incluir.Appearance.Options.UseBackColor = True
        Me.bt0Incluir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Incluir.Enabled = False
        Me.bt0Incluir.ImageIndex = 1
        Me.bt0Incluir.ImageList = Me.ImageList2
        Me.bt0Incluir.Location = New System.Drawing.Point(98, 456)
        Me.bt0Incluir.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Incluir.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Incluir.Name = "bt0Incluir"
        Me.bt0Incluir.Size = New System.Drawing.Size(75, 23)
        Me.bt0Incluir.TabIndex = 165
        Me.bt0Incluir.Text = "Incluir"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(17, 315)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(540, 125)
        Me.txtObs.TabIndex = 13
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(18, 296)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl10.TabIndex = 18
        Me.LabelControl10.Text = "Observação"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(18, 35)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl9.TabIndex = 17
        Me.LabelControl9.Text = "Nº de Controle"
        '
        'txtCDControle
        '
        Me.txtCDControle.BackColor = System.Drawing.Color.Linen
        Me.txtCDControle.Location = New System.Drawing.Point(18, 54)
        Me.txtCDControle.Name = "txtCDControle"
        Me.txtCDControle.Size = New System.Drawing.Size(78, 20)
        Me.txtCDControle.TabIndex = 1
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(107, 35)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl8.TabIndex = 15
        Me.LabelControl8.Text = "Descrição do item"
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(107, 54)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(332, 20)
        Me.txtDescricao.TabIndex = 2
        '
        'cbStatus
        '
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(18, 261)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(233, 21)
        Me.cbStatus.TabIndex = 12
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(18, 242)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl7.TabIndex = 12
        Me.LabelControl7.Text = "Status"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(107, 190)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "UM"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(18, 190)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "Quantidade"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(445, 35)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(103, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Data de Recebimento"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 141)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Fornecedor"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(287, 89)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Nº do Pedido"
        '
        'txtUM
        '
        Me.txtUM.Location = New System.Drawing.Point(107, 209)
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(67, 20)
        Me.txtUM.TabIndex = 11
        '
        'txtQtde
        '
        Me.txtQtde.Location = New System.Drawing.Point(18, 209)
        Me.txtQtde.Name = "txtQtde"
        Me.txtQtde.Size = New System.Drawing.Size(78, 20)
        Me.txtQtde.TabIndex = 10
        '
        'txtCDPedido
        '
        Me.txtCDPedido.Location = New System.Drawing.Point(287, 108)
        Me.txtCDPedido.Name = "txtCDPedido"
        Me.txtCDPedido.Size = New System.Drawing.Size(152, 20)
        Me.txtCDPedido.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 89)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Cliente"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.ImageIndex = 2
        Me.SimpleButton1.ImageList = Me.ImageList2
        Me.SimpleButton1.Location = New System.Drawing.Point(6, 566)
        Me.SimpleButton1.LookAndFeel.SkinName = "Money Twins"
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(119, 23)
        Me.SimpleButton1.TabIndex = 174
        Me.SimpleButton1.Text = "Imprimir Etiqueta"
        '
        'frmItemFornecidoRecebido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt0Sair
        Me.ClientSize = New System.Drawing.Size(1138, 601)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.bt0Sair)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmItemFornecidoRecebido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recebimento de Item Fornecido"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt0Sair As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents txtQtde As System.Windows.Forms.TextBox
    Friend WithEvents txtCDPedido As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCDControle As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bt0Excluir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0Alterar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0Incluir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0Novo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNF As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFornecedor As System.Windows.Forms.TextBox
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbStatus2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtData As System.Windows.Forms.MaskedTextBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckContabiliza As System.Windows.Forms.CheckBox
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtItens As System.Windows.Forms.TextBox
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCDCliente As System.Windows.Forms.TextBox
End Class
