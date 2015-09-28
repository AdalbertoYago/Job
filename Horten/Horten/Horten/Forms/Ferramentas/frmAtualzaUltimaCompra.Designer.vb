<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtualzaUltimaCompra
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
        Me.bt0Buscar = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.SuspendLayout()
        '
        'bt0Buscar
        '
        Me.bt0Buscar.ImageIndex = 0
        Me.bt0Buscar.Location = New System.Drawing.Point(12, 27)
        Me.bt0Buscar.LookAndFeel.SkinName = "Money Twins"
        Me.bt0Buscar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Buscar.Name = "bt0Buscar"
        Me.bt0Buscar.Size = New System.Drawing.Size(71, 47)
        Me.bt0Buscar.TabIndex = 164
        Me.bt0Buscar.Text = "Processar"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.SimpleButton2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(231, 27)
        Me.SimpleButton2.LookAndFeel.SkinName = "The Asphalt World"
        Me.SimpleButton2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 47)
        Me.SimpleButton2.TabIndex = 163
        Me.SimpleButton2.Text = "Sair"
        '
        'frmAtualzaUltimaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 96)
        Me.Controls.Add(Me.bt0Buscar)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Name = "frmAtualzaUltimaCompra"
        Me.Text = "Atualizar Valor da última Compra"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt0Buscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
