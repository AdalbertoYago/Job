<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprimeEtiqueta
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCDProduto = New System.Windows.Forms.TextBox
        Me.LBLDescricao = New System.Windows.Forms.Label
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.bt0Buscar = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Digite o Código do Produto:"
        '
        'txtCDProduto
        '
        Me.txtCDProduto.Location = New System.Drawing.Point(15, 45)
        Me.txtCDProduto.Name = "txtCDProduto"
        Me.txtCDProduto.Size = New System.Drawing.Size(159, 20)
        Me.txtCDProduto.TabIndex = 1
        '
        'LBLDescricao
        '
        Me.LBLDescricao.AutoSize = True
        Me.LBLDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDescricao.ForeColor = System.Drawing.Color.SteelBlue
        Me.LBLDescricao.Location = New System.Drawing.Point(13, 81)
        Me.LBLDescricao.Name = "LBLDescricao"
        Me.LBLDescricao.Size = New System.Drawing.Size(64, 13)
        Me.LBLDescricao.TabIndex = 2
        Me.LBLDescricao.Text = "Descrição"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(303, 135)
        Me.SimpleButton2.LookAndFeel.SkinName = "The Asphalt World"
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 24)
        Me.SimpleButton2.TabIndex = 160
        Me.SimpleButton2.Text = "Sair"
        '
        'bt0Buscar
        '
        Me.bt0Buscar.ImageIndex = 0
        Me.bt0Buscar.Location = New System.Drawing.Point(15, 135)
        Me.bt0Buscar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Buscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Buscar.Name = "bt0Buscar"
        Me.bt0Buscar.Size = New System.Drawing.Size(67, 24)
        Me.bt0Buscar.TabIndex = 161
        Me.bt0Buscar.Text = "Imprimir"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtCDProduto)
        Me.GroupControl1.Controls.Add(Me.bt0Buscar)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.LBLDescricao)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(392, 175)
        Me.GroupControl1.TabIndex = 162
        '
        'frmImprimeEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 512)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmImprimeEtiqueta"
        Me.Text = "Imprimir Etiqueta"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCDProduto As System.Windows.Forms.TextBox
    Friend WithEvents LBLDescricao As System.Windows.Forms.Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0Buscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
End Class
