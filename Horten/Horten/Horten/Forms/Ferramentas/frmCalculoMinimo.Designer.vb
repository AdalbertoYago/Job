<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculoMinimo
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
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioUso = New System.Windows.Forms.RadioButton
        Me.RadioSubCJ = New System.Windows.Forms.RadioButton
        Me.RadioMP = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbMinimo = New System.Windows.Forms.TextBox
        Me.tbMaximo = New System.Windows.Forms.TextBox
        Me.tbMeses = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.bt0Buscar = New DevExpress.XtraEditors.SimpleButton
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(394, 155)
        Me.SimpleButton2.LookAndFeel.SkinName = "The Asphalt World"
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 24)
        Me.SimpleButton2.TabIndex = 160
        Me.SimpleButton2.Text = "Sair"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GroupBox1)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.tbMinimo)
        Me.GroupControl1.Controls.Add(Me.tbMaximo)
        Me.GroupControl1.Controls.Add(Me.tbMeses)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.LookAndFeel.SkinName = "Black"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(457, 137)
        Me.GroupControl1.TabIndex = 161
        Me.GroupControl1.Text = "Dados para cálculo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioUso)
        Me.GroupBox1.Controls.Add(Me.RadioSubCJ)
        Me.GroupBox1.Controls.Add(Me.RadioMP)
        Me.GroupBox1.Location = New System.Drawing.Point(249, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 94)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'RadioUso
        '
        Me.RadioUso.AutoSize = True
        Me.RadioUso.Location = New System.Drawing.Point(16, 68)
        Me.RadioUso.Name = "RadioUso"
        Me.RadioUso.Size = New System.Drawing.Size(100, 17)
        Me.RadioUso.TabIndex = 2
        Me.RadioUso.Text = "Uso e Consumo"
        Me.RadioUso.UseVisualStyleBackColor = True
        '
        'RadioSubCJ
        '
        Me.RadioSubCJ.AutoSize = True
        Me.RadioSubCJ.Location = New System.Drawing.Point(16, 43)
        Me.RadioSubCJ.Name = "RadioSubCJ"
        Me.RadioSubCJ.Size = New System.Drawing.Size(85, 17)
        Me.RadioSubCJ.TabIndex = 1
        Me.RadioSubCJ.Text = "Subconjunto"
        Me.RadioSubCJ.UseVisualStyleBackColor = True
        '
        'RadioMP
        '
        Me.RadioMP.AutoSize = True
        Me.RadioMP.Checked = True
        Me.RadioMP.Location = New System.Drawing.Point(16, 18)
        Me.RadioMP.Name = "RadioMP"
        Me.RadioMP.Size = New System.Drawing.Size(88, 17)
        Me.RadioMP.TabIndex = 0
        Me.RadioMP.TabStop = True
        Me.RadioMP.Text = "Matéria-prima"
        Me.RadioMP.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(162, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Meses"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(163, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Meses"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(189, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Meses"
        '
        'tbMinimo
        '
        Me.tbMinimo.Location = New System.Drawing.Point(112, 97)
        Me.tbMinimo.Name = "tbMinimo"
        Me.tbMinimo.Size = New System.Drawing.Size(45, 20)
        Me.tbMinimo.TabIndex = 5
        '
        'tbMaximo
        '
        Me.tbMaximo.Location = New System.Drawing.Point(113, 61)
        Me.tbMaximo.Name = "tbMaximo"
        Me.tbMaximo.Size = New System.Drawing.Size(45, 20)
        Me.tbMaximo.TabIndex = 4
        '
        'tbMeses
        '
        Me.tbMeses.Location = New System.Drawing.Point(139, 28)
        Me.tbMeses.Name = "tbMeses"
        Me.tbMeses.Size = New System.Drawing.Size(45, 20)
        Me.tbMeses.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estoque Mínimo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Estoque Máximo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quantidade de Meses:"
        '
        'bt0Buscar
        '
        Me.bt0Buscar.ImageIndex = 0
        Me.bt0Buscar.Location = New System.Drawing.Point(12, 155)
        Me.bt0Buscar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Buscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Buscar.Name = "bt0Buscar"
        Me.bt0Buscar.Size = New System.Drawing.Size(62, 22)
        Me.bt0Buscar.TabIndex = 162
        Me.bt0Buscar.Text = "Processar"
        '
        'frmCalculoMinimo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 198)
        Me.Controls.Add(Me.bt0Buscar)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Name = "frmCalculoMinimo"
        Me.Text = "Cálculo de Estoque Mínimo e Máximo"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents tbMeses As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMinimo As System.Windows.Forms.TextBox
    Friend WithEvents tbMaximo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioUso As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSubCJ As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMP As System.Windows.Forms.RadioButton
    Friend WithEvents bt0Buscar As DevExpress.XtraEditors.SimpleButton
End Class
