<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitacaoCompra
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
        Me.btExcluir = New DevExpress.XtraEditors.SimpleButton
        Me.btAlterar = New DevExpress.XtraEditors.SimpleButton
        Me.txtDTEntrega = New DevExpress.XtraEditors.DateEdit
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbPrioridade = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbCDCC = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbCDPC = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbFornec = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.bt0Incluir = New DevExpress.XtraEditors.SimpleButton
        Me.bt0NovoEndereco = New DevExpress.XtraEditors.SimpleButton
        Me.txtData = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtObs = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRequisitante = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCDSC = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.cbCampo = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GridBusca = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.btBuscar = New DevExpress.XtraEditors.SimpleButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtChave = New System.Windows.Forms.TextBox
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtDTEntrega.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDTEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GridBusca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btExcluir)
        Me.GroupControl1.Controls.Add(Me.btAlterar)
        Me.GroupControl1.Controls.Add(Me.txtDTEntrega)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.cbPrioridade)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.cbCDCC)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.cbCDPC)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.cbFornec)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.bt0Incluir)
        Me.GroupControl1.Controls.Add(Me.bt0NovoEndereco)
        Me.GroupControl1.Controls.Add(Me.txtData)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.txtObs)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.txtRequisitante)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.txtCDSC)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(685, 205)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Dados da Solicitação"
        '
        'btExcluir
        '
        Me.btExcluir.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btExcluir.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btExcluir.Appearance.Options.UseBackColor = True
        Me.btExcluir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btExcluir.Enabled = False
        Me.btExcluir.Location = New System.Drawing.Point(248, 172)
        Me.btExcluir.LookAndFeel.SkinName = "Money Twins"
        Me.btExcluir.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btExcluir.Name = "btExcluir"
        Me.btExcluir.Size = New System.Drawing.Size(75, 23)
        Me.btExcluir.TabIndex = 200
        Me.btExcluir.Text = "Excluir"
        '
        'btAlterar
        '
        Me.btAlterar.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btAlterar.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btAlterar.Appearance.Options.UseBackColor = True
        Me.btAlterar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btAlterar.Enabled = False
        Me.btAlterar.Location = New System.Drawing.Point(167, 172)
        Me.btAlterar.LookAndFeel.SkinName = "Money Twins"
        Me.btAlterar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btAlterar.Name = "btAlterar"
        Me.btAlterar.Size = New System.Drawing.Size(75, 23)
        Me.btAlterar.TabIndex = 199
        Me.btAlterar.Text = "Alterar"
        '
        'txtDTEntrega
        '
        Me.txtDTEntrega.EditValue = Nothing
        Me.txtDTEntrega.Location = New System.Drawing.Point(184, 138)
        Me.txtDTEntrega.Name = "txtDTEntrega"
        Me.txtDTEntrega.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.txtDTEntrega.Properties.Appearance.Options.UseBackColor = True
        Me.txtDTEntrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDTEntrega.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.txtDTEntrega.Size = New System.Drawing.Size(177, 20)
        Me.txtDTEntrega.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(181, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "Entrega Prevista"
        '
        'cbPrioridade
        '
        Me.cbPrioridade.FormattingEnabled = True
        Me.cbPrioridade.Location = New System.Drawing.Point(8, 138)
        Me.cbPrioridade.Name = "cbPrioridade"
        Me.cbPrioridade.Size = New System.Drawing.Size(170, 21)
        Me.cbPrioridade.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "Prioridade"
        '
        'cbCDCC
        '
        Me.cbCDCC.FormattingEnabled = True
        Me.cbCDCC.Location = New System.Drawing.Point(184, 89)
        Me.cbCDCC.Name = "cbCDCC"
        Me.cbCDCC.Size = New System.Drawing.Size(180, 21)
        Me.cbCDCC.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(181, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 194
        Me.Label6.Text = "Centro de Custo"
        '
        'cbCDPC
        '
        Me.cbCDPC.FormattingEnabled = True
        Me.cbCDPC.Location = New System.Drawing.Point(8, 89)
        Me.cbCDPC.Name = "cbCDPC"
        Me.cbCDPC.Size = New System.Drawing.Size(170, 21)
        Me.cbCDPC.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Plano de Conta"
        '
        'cbFornec
        '
        Me.cbFornec.FormattingEnabled = True
        Me.cbFornec.Location = New System.Drawing.Point(370, 47)
        Me.cbFornec.Name = "cbFornec"
        Me.cbFornec.Size = New System.Drawing.Size(304, 21)
        Me.cbFornec.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(367, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "Fornecedor"
        '
        'bt0Incluir
        '
        Me.bt0Incluir.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.bt0Incluir.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0Incluir.Appearance.Options.UseBackColor = True
        Me.bt0Incluir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Incluir.Enabled = False
        Me.bt0Incluir.Location = New System.Drawing.Point(86, 172)
        Me.bt0Incluir.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Incluir.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Incluir.Name = "bt0Incluir"
        Me.bt0Incluir.Size = New System.Drawing.Size(75, 23)
        Me.bt0Incluir.TabIndex = 191
        Me.bt0Incluir.Text = "Incluir"
        '
        'bt0NovoEndereco
        '
        Me.bt0NovoEndereco.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.bt0NovoEndereco.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.bt0NovoEndereco.Appearance.Options.UseBackColor = True
        Me.bt0NovoEndereco.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0NovoEndereco.Location = New System.Drawing.Point(5, 172)
        Me.bt0NovoEndereco.LookAndFeel.SkinName = "The Asphalt World"
        Me.bt0NovoEndereco.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0NovoEndereco.Name = "bt0NovoEndereco"
        Me.bt0NovoEndereco.Size = New System.Drawing.Size(75, 23)
        Me.bt0NovoEndereco.TabIndex = 185
        Me.bt0NovoEndereco.Text = "Novo"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(96, 48)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(82, 20)
        Me.txtData.TabIndex = 182
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(93, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Data"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(370, 89)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(303, 70)
        Me.txtObs.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Observação"
        '
        'txtRequisitante
        '
        Me.txtRequisitante.Location = New System.Drawing.Point(184, 48)
        Me.txtRequisitante.Name = "txtRequisitante"
        Me.txtRequisitante.Size = New System.Drawing.Size(180, 20)
        Me.txtRequisitante.TabIndex = 176
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(181, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Requisitante"
        '
        'txtCDSC
        '
        Me.txtCDSC.BackColor = System.Drawing.SystemColors.Info
        Me.txtCDSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCDSC.Location = New System.Drawing.Point(8, 48)
        Me.txtCDSC.Name = "txtCDSC"
        Me.txtCDSC.Size = New System.Drawing.Size(84, 20)
        Me.txtCDSC.TabIndex = 170
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Nº Solicitação"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 223)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(685, 390)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Itens da Requisição"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(8, 23)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemLookUpEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(669, 362)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Item"
        Me.GridColumn2.FieldName = "CDItem"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Width = 47
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Código"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn3.FieldName = "CDMaterial"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 54
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.MaxLength = 7
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "Descrição"
        Me.GridColumn4.FieldName = "Descricao"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 259
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.Caption = "Qtde"
        Me.GridColumn5.FieldName = "Qtde"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 64
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "UM"
        Me.GridColumn6.FieldName = "Unidade"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 66
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CDProduto", "Código", 20, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descricao", "Descrição", 100)})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "CDProduto"
        Me.RepositoryItemLookUpEdit1.MaxLength = 7
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = ""
        Me.RepositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.RepositoryItemLookUpEdit1.ValueMember = "CDProduto"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(860, 619)
        Me.SimpleButton2.LookAndFeel.SkinName = "The Asphalt World"
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 157
        Me.SimpleButton2.Text = "Sair"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(17, 619)
        Me.SimpleButton1.LookAndFeel.SkinName = "Money Twins"
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 192
        Me.SimpleButton1.Text = "Imprimir"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.cbCampo)
        Me.GroupControl3.Controls.Add(Me.Label11)
        Me.GroupControl3.Controls.Add(Me.GridBusca)
        Me.GroupControl3.Controls.Add(Me.btBuscar)
        Me.GroupControl3.Controls.Add(Me.Label10)
        Me.GroupControl3.Controls.Add(Me.txtChave)
        Me.GroupControl3.Location = New System.Drawing.Point(704, 12)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(272, 601)
        Me.GroupControl3.TabIndex = 193
        Me.GroupControl3.Text = "Consulta Solicitações"
        '
        'cbCampo
        '
        Me.cbCampo.FormattingEnabled = True
        Me.cbCampo.Location = New System.Drawing.Point(51, 26)
        Me.cbCampo.Name = "cbCampo"
        Me.cbCampo.Size = New System.Drawing.Size(216, 21)
        Me.cbCampo.TabIndex = 196
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 195
        Me.Label11.Text = "Campo"
        '
        'GridBusca
        '
        Me.GridBusca.Location = New System.Drawing.Point(7, 81)
        Me.GridBusca.MainView = Me.GridView2
        Me.GridBusca.Name = "GridBusca"
        Me.GridBusca.Size = New System.Drawing.Size(260, 514)
        Me.GridBusca.TabIndex = 194
        Me.GridBusca.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridBusca
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'btBuscar
        '
        Me.btBuscar.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btBuscar.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btBuscar.Appearance.Options.UseBackColor = True
        Me.btBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btBuscar.Location = New System.Drawing.Point(210, 52)
        Me.btBuscar.LookAndFeel.SkinName = "Money Twins"
        Me.btBuscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(57, 23)
        Me.btBuscar.TabIndex = 193
        Me.btBuscar.Text = "Buscar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Filtro"
        '
        'txtChave
        '
        Me.txtChave.Location = New System.Drawing.Point(51, 53)
        Me.txtChave.Name = "txtChave"
        Me.txtChave.Size = New System.Drawing.Size(153, 20)
        Me.txtChave.TabIndex = 0
        '
        'frmSolicitacaoCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 654)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmSolicitacaoCompra"
        Me.Text = "Solicitação de Compra"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtDTEntrega.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDTEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GridBusca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCDSC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRequisitante As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt0Incluir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0NovoEndereco As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbFornec As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbCDCC As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCDPC As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbPrioridade As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDTEntrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridBusca As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtChave As System.Windows.Forms.TextBox
    Friend WithEvents cbCampo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btExcluir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btAlterar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
