<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOndeUsa
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.gridSubCJ = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gridProduto = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Filtros = New DevExpress.XtraEditors.GroupControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbTipoEstoque = New System.Windows.Forms.ComboBox
        Me.lblDescricao = New System.Windows.Forms.Label
        Me.txtCDProduto = New System.Windows.Forms.TextBox
        Me.bt0Buscar = New DevExpress.XtraEditors.SimpleButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridSubCJ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProduto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Filtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Filtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gridSubCJ)
        Me.GroupControl1.Controls.Add(Me.gridProduto)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 100)
        Me.GroupControl1.LookAndFeel.SkinName = "Black"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1112, 387)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Onde Usa (Produtos / Subconjuntos)"
        '
        'gridSubCJ
        '
        Me.gridSubCJ.Location = New System.Drawing.Point(562, 23)
        Me.gridSubCJ.LookAndFeel.SkinName = "Blue"
        Me.gridSubCJ.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridSubCJ.MainView = Me.GridView3
        Me.gridSubCJ.Name = "gridSubCJ"
        Me.gridSubCJ.Size = New System.Drawing.Size(545, 359)
        Me.gridSubCJ.TabIndex = 3
        Me.gridSubCJ.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView3.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView3.Appearance.Empty.BackColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView3.Appearance.Empty.Options.UseBackColor = True
        Me.GridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray
        Me.GridView3.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray
        Me.GridView3.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black
        Me.GridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView3.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver
        Me.GridView3.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver
        Me.GridView3.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver
        Me.GridView3.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver
        Me.GridView3.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridView3.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver
        Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView3.Appearance.GroupRow.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView3.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray
        Me.GridView3.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray
        Me.GridView3.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView3.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridView3.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView3.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro
        Me.GridView3.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.Preview.Options.UseBackColor = True
        Me.GridView3.Appearance.Preview.Options.UseForeColor = True
        Me.GridView3.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView3.Appearance.Row.Options.UseBackColor = True
        Me.GridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray
        Me.GridView3.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView3.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray
        Me.GridView3.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17})
        Me.GridView3.GridControl = Me.gridSubCJ
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView3.OptionsView.EnableAppearanceOddRow = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Código"
        Me.GridColumn14.FieldName = "CDProduto"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 84
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "UM"
        Me.GridColumn15.FieldName = "Unidade"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 60
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Qtde"
        Me.GridColumn16.FieldName = "Qtde"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 65
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Descrição"
        Me.GridColumn17.FieldName = "Descricao2"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        Me.GridColumn17.Width = 340
        '
        'gridProduto
        '
        Me.gridProduto.Location = New System.Drawing.Point(7, 23)
        Me.gridProduto.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridProduto.MainView = Me.GridView2
        Me.gridProduto.Name = "gridProduto"
        Me.gridProduto.Size = New System.Drawing.Size(549, 359)
        Me.gridProduto.TabIndex = 0
        Me.gridProduto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView2.Appearance.Empty.BackColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.GridView2.Appearance.Empty.Options.UseBackColor = True
        Me.GridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray
        Me.GridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray
        Me.GridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black
        Me.GridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver
        Me.GridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver
        Me.GridView2.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver
        Me.GridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver
        Me.GridView2.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridView2.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver
        Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GridView2.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView2.Appearance.GroupRow.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray
        Me.GridView2.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray
        Me.GridView2.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray
        Me.GridView2.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView2.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridView2.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView2.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro
        Me.GridView2.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.Preview.Options.UseBackColor = True
        Me.GridView2.Appearance.Preview.Options.UseForeColor = True
        Me.GridView2.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridView2.Appearance.Row.Options.UseBackColor = True
        Me.GridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray
        Me.GridView2.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray
        Me.GridView2.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridView2.GridControl = Me.gridProduto
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView2.OptionsView.EnableAppearanceOddRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Código"
        Me.GridColumn10.FieldName = "CDProduto"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 87
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "UM"
        Me.GridColumn11.FieldName = "Unidade"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 64
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Qtde"
        Me.GridColumn12.FieldName = "Qtde"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Descrição"
        Me.GridColumn13.FieldName = "Descricao2"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        Me.GridColumn13.Width = 302
        '
        'Filtros
        '
        Me.Filtros.Controls.Add(Me.Label1)
        Me.Filtros.Controls.Add(Me.cbTipoEstoque)
        Me.Filtros.Controls.Add(Me.lblDescricao)
        Me.Filtros.Controls.Add(Me.txtCDProduto)
        Me.Filtros.Controls.Add(Me.bt0Buscar)
        Me.Filtros.Controls.Add(Me.Label4)
        Me.Filtros.Location = New System.Drawing.Point(5, 11)
        Me.Filtros.LookAndFeel.SkinName = "Black"
        Me.Filtros.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Filtros.Name = "Filtros"
        Me.Filtros.Size = New System.Drawing.Size(1112, 83)
        Me.Filtros.TabIndex = 8
        Me.Filtros.Text = "Filtros"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(160, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Tipo de Estoque"
        '
        'cbTipoEstoque
        '
        Me.cbTipoEstoque.FormattingEnabled = True
        Me.cbTipoEstoque.Location = New System.Drawing.Point(251, 26)
        Me.cbTipoEstoque.Name = "cbTipoEstoque"
        Me.cbTipoEstoque.Size = New System.Drawing.Size(146, 21)
        Me.cbTipoEstoque.TabIndex = 71
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescricao.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblDescricao.Location = New System.Drawing.Point(7, 59)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(64, 13)
        Me.lblDescricao.TabIndex = 69
        Me.lblDescricao.Text = "Descrição"
        '
        'txtCDProduto
        '
        Me.txtCDProduto.Location = New System.Drawing.Point(51, 26)
        Me.txtCDProduto.Name = "txtCDProduto"
        Me.txtCDProduto.Size = New System.Drawing.Size(100, 20)
        Me.txtCDProduto.TabIndex = 68
        '
        'bt0Buscar
        '
        Me.bt0Buscar.ImageIndex = 0
        Me.bt0Buscar.Location = New System.Drawing.Point(403, 26)
        Me.bt0Buscar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Buscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Buscar.Name = "bt0Buscar"
        Me.bt0Buscar.Size = New System.Drawing.Size(62, 21)
        Me.bt0Buscar.TabIndex = 66
        Me.bt0Buscar.Text = "Buscar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Código"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(1042, 493)
        Me.SimpleButton2.LookAndFeel.SkinName = "The Asphalt World"
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 24)
        Me.SimpleButton2.TabIndex = 159
        Me.SimpleButton2.Text = "Sair"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(5, 494)
        Me.SimpleButton1.LookAndFeel.SkinName = "Money Twins"
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 193
        Me.SimpleButton1.Text = "Imprimir"
        '
        'frmOndeUsa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 520)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.Filtros)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmOndeUsa"
        Me.Text = "Onde Usa"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gridSubCJ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProduto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Filtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Filtros.ResumeLayout(False)
        Me.Filtros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridSubCJ As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gridProduto As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Filtros As DevExpress.XtraEditors.GroupControl
    Friend WithEvents bt0Buscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCDProduto As System.Windows.Forms.TextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbTipoEstoque As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
