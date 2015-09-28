<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpressoras
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
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.CBImpressoraEtiqueta = New System.Windows.Forms.ComboBox
        Me.lbls = New System.Windows.Forms.Label
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBImpressoraRelatorio = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBImpressoraDanfe = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 165)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Sair"
        '
        'CBImpressoraEtiqueta
        '
        Me.CBImpressoraEtiqueta.FormattingEnabled = True
        Me.CBImpressoraEtiqueta.Location = New System.Drawing.Point(12, 37)
        Me.CBImpressoraEtiqueta.Name = "CBImpressoraEtiqueta"
        Me.CBImpressoraEtiqueta.Size = New System.Drawing.Size(369, 21)
        Me.CBImpressoraEtiqueta.TabIndex = 1
        '
        'lbls
        '
        Me.lbls.AutoSize = True
        Me.lbls.Location = New System.Drawing.Point(9, 21)
        Me.lbls.Name = "lbls"
        Me.lbls.Size = New System.Drawing.Size(301, 13)
        Me.lbls.TabIndex = 2
        Me.lbls.Text = "Selecione uma impressora padrão para impressão de etiquetas"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(309, 165)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "Gravar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selecione uma impressora padrão para impressão de relatórios"
        '
        'CBImpressoraRelatorio
        '
        Me.CBImpressoraRelatorio.FormattingEnabled = True
        Me.CBImpressoraRelatorio.Location = New System.Drawing.Point(12, 87)
        Me.CBImpressoraRelatorio.Name = "CBImpressoraRelatorio"
        Me.CBImpressoraRelatorio.Size = New System.Drawing.Size(369, 21)
        Me.CBImpressoraRelatorio.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(299, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Selecione uma impressora padrão para impressão de DANFEs"
        '
        'CBImpressoraDanfe
        '
        Me.CBImpressoraDanfe.FormattingEnabled = True
        Me.CBImpressoraDanfe.Location = New System.Drawing.Point(15, 138)
        Me.CBImpressoraDanfe.Name = "CBImpressoraDanfe"
        Me.CBImpressoraDanfe.Size = New System.Drawing.Size(369, 21)
        Me.CBImpressoraDanfe.TabIndex = 7
        '
        'frmImpressoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.SimpleButton1
        Me.ClientSize = New System.Drawing.Size(401, 198)
        Me.Controls.Add(Me.CBImpressoraDanfe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBImpressoraRelatorio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.lbls)
        Me.Controls.Add(Me.CBImpressoraEtiqueta)
        Me.Controls.Add(Me.SimpleButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmImpressoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressoras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CBImpressoraEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents lbls As System.Windows.Forms.Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBImpressoraRelatorio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBImpressoraDanfe As System.Windows.Forms.ComboBox
End Class
