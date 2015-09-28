<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBalanco
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
        Me.components = New System.ComponentModel.Container
        Me.bt0Buscar = New DevExpress.XtraEditors.SimpleButton
        Me.cbTipoEstoque = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbAte = New DevExpress.XtraEditors.DateEdit
        Me.cbDe = New DevExpress.XtraEditors.DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gridBalanco = New DevExpress.XtraPivotGrid.PivotGridControl
        Me.PivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField2 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField3 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField4 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField5 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField6 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField7 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.PivotGridField8 = New DevExpress.XtraPivotGrid.PivotGridField
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer
        Me.ckKardex2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbAte.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDe.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridBalanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt0Buscar
        '
        Me.bt0Buscar.ImageIndex = 0
        Me.bt0Buscar.Location = New System.Drawing.Point(630, 45)
        Me.bt0Buscar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Buscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Buscar.Name = "bt0Buscar"
        Me.bt0Buscar.Size = New System.Drawing.Size(85, 23)
        Me.bt0Buscar.TabIndex = 65
        Me.bt0Buscar.Text = "Fechar Periodo"
        '
        'cbTipoEstoque
        '
        Me.cbTipoEstoque.FormattingEnabled = True
        Me.cbTipoEstoque.Location = New System.Drawing.Point(274, 42)
        Me.cbTipoEstoque.Name = "cbTipoEstoque"
        Me.cbTipoEstoque.Size = New System.Drawing.Size(146, 21)
        Me.cbTipoEstoque.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(271, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo de Estoque"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cbAte)
        Me.GroupBox2.Controls.Add(Me.cbDe)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(244, 67)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo"
        '
        'cbAte
        '
        Me.cbAte.EditValue = Nothing
        Me.cbAte.Location = New System.Drawing.Point(125, 33)
        Me.cbAte.Name = "cbAte"
        Me.cbAte.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbAte.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.cbAte.Size = New System.Drawing.Size(100, 20)
        Me.cbAte.TabIndex = 5
        '
        'cbDe
        '
        Me.cbDe.EditValue = Nothing
        Me.cbDe.Location = New System.Drawing.Point(9, 34)
        Me.cbDe.Name = "cbDe"
        Me.cbDe.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbDe.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.cbDe.Size = New System.Drawing.Size(100, 20)
        Me.cbDe.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(122, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Até"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "De"
        '
        'gridBalanco
        '
        Me.gridBalanco.Cursor = System.Windows.Forms.Cursors.Default
        Me.gridBalanco.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBalanco.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.PivotGridField1, Me.PivotGridField2, Me.PivotGridField3, Me.PivotGridField4, Me.PivotGridField5, Me.PivotGridField6, Me.PivotGridField7, Me.PivotGridField8})
        Me.gridBalanco.Location = New System.Drawing.Point(0, 117)
        Me.gridBalanco.Name = "gridBalanco"
        Me.gridBalanco.Size = New System.Drawing.Size(1211, 559)
        Me.gridBalanco.TabIndex = 158
        '
        'PivotGridField1
        '
        Me.PivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.PivotGridField1.AreaIndex = 1
        Me.PivotGridField1.Caption = "Mês"
        Me.PivotGridField1.FieldName = "Mes"
        Me.PivotGridField1.Name = "PivotGridField1"
        Me.PivotGridField1.Options.ShowCustomTotals = False
        Me.PivotGridField1.Options.ShowGrandTotal = False
        Me.PivotGridField1.Options.ShowTotals = False
        '
        'PivotGridField2
        '
        Me.PivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.PivotGridField2.AreaIndex = 0
        Me.PivotGridField2.Caption = "Ano"
        Me.PivotGridField2.FieldName = "Ano"
        Me.PivotGridField2.Name = "PivotGridField2"
        Me.PivotGridField2.Options.ShowCustomTotals = False
        Me.PivotGridField2.Options.ShowGrandTotal = False
        Me.PivotGridField2.Options.ShowTotals = False
        '
        'PivotGridField3
        '
        Me.PivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField3.AreaIndex = 0
        Me.PivotGridField3.Caption = "Código"
        Me.PivotGridField3.FieldName = "CDProduto"
        Me.PivotGridField3.Name = "PivotGridField3"
        '
        'PivotGridField4
        '
        Me.PivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField4.AreaIndex = 1
        Me.PivotGridField4.Caption = "Descrição"
        Me.PivotGridField4.FieldName = "Descricao"
        Me.PivotGridField4.MinWidth = 100
        Me.PivotGridField4.Name = "PivotGridField4"
        Me.PivotGridField4.Width = 200
        '
        'PivotGridField5
        '
        Me.PivotGridField5.Appearance.Value.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PivotGridField5.Appearance.Value.Options.UseBackColor = True
        Me.PivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField5.AreaIndex = 0
        Me.PivotGridField5.Caption = "Qtde Inicial"
        Me.PivotGridField5.CellFormat.FormatString = "n"
        Me.PivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField5.FieldName = "QtdeInicial"
        Me.PivotGridField5.Name = "PivotGridField5"
        Me.PivotGridField5.Options.ShowCustomTotals = False
        Me.PivotGridField5.Width = 68
        '
        'PivotGridField6
        '
        Me.PivotGridField6.Appearance.Value.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PivotGridField6.Appearance.Value.Options.UseBackColor = True
        Me.PivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField6.AreaIndex = 2
        Me.PivotGridField6.Caption = "Qtde Final"
        Me.PivotGridField6.CellFormat.FormatString = "n"
        Me.PivotGridField6.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField6.FieldName = "QtdeFinal"
        Me.PivotGridField6.Name = "PivotGridField6"
        Me.PivotGridField6.Options.ShowCustomTotals = False
        Me.PivotGridField6.Width = 69
        '
        'PivotGridField7
        '
        Me.PivotGridField7.Appearance.Value.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridField7.Appearance.Value.Options.UseBackColor = True
        Me.PivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField7.AreaIndex = 1
        Me.PivotGridField7.Caption = "VL. Inicial"
        Me.PivotGridField7.CellFormat.FormatString = "n"
        Me.PivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField7.FieldName = "VLInicial"
        Me.PivotGridField7.Name = "PivotGridField7"
        Me.PivotGridField7.Options.ShowCustomTotals = False
        Me.PivotGridField7.Width = 64
        '
        'PivotGridField8
        '
        Me.PivotGridField8.Appearance.Value.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PivotGridField8.Appearance.Value.Options.UseBackColor = True
        Me.PivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField8.AreaIndex = 3
        Me.PivotGridField8.Caption = "VL. Final"
        Me.PivotGridField8.CellFormat.FormatString = "n"
        Me.PivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField8.FieldName = "VLFinal"
        Me.PivotGridField8.Name = "PivotGridField8"
        Me.PivotGridField8.Options.ShowCustomTotals = False
        Me.PivotGridField8.Width = 64
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top
        Me.DockPanel1.ID = New System.Guid("dc73b13f-f3a5-49a2-b025-7d91178c3615")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Size = New System.Drawing.Size(1211, 117)
        Me.DockPanel1.Text = "Filtros"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.ckKardex2)
        Me.DockPanel1_Container.Controls.Add(Me.CheckBox1)
        Me.DockPanel1_Container.Controls.Add(Me.GroupBox2)
        Me.DockPanel1_Container.Controls.Add(Me.bt0Buscar)
        Me.DockPanel1_Container.Controls.Add(Me.Label4)
        Me.DockPanel1_Container.Controls.Add(Me.cbTipoEstoque)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 25)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1205, 89)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'ckKardex2
        '
        Me.ckKardex2.AutoSize = True
        Me.ckKardex2.BackColor = System.Drawing.Color.Transparent
        Me.ckKardex2.Location = New System.Drawing.Point(448, 28)
        Me.ckKardex2.Name = "ckKardex2"
        Me.ckKardex2.Size = New System.Drawing.Size(156, 17)
        Me.ckKardex2.TabIndex = 160
        Me.ckKardex2.Text = "Utilizar Kardex de Empenho"
        Me.ckKardex2.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Location = New System.Drawing.Point(448, 51)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox1.TabIndex = 68
        Me.CheckBox1.Text = "Ocultar Valores"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'frmBalanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 676)
        Me.Controls.Add(Me.gridBalanco)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "frmBalanco"
        Me.Text = "Balanço"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbAte.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDe.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridBalanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.DockPanel1_Container.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbTipoEstoque As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bt0Buscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbAte As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbDe As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gridBalanco As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents PivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField2 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField3 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField4 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField5 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField6 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField7 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField8 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ckKardex2 As System.Windows.Forms.CheckBox
End Class
