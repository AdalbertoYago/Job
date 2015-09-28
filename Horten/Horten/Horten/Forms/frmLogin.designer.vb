<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt0Sair = New DevExpress.XtraEditors.SimpleButton()
        Me.bt0Entrar = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblSelEmpresa = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PicturePrisma = New System.Windows.Forms.PictureBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PicturePrisma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(148, 169)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(272, 279)
        Me.Panel2.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Digite seu usuário e senha para efetuar o login"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Seja bem-vindo"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bt0Sair)
        Me.Panel1.Controls.Add(Me.bt0Entrar)
        Me.Panel1.Controls.Add(Me.lblLogin)
        Me.Panel1.Controls.Add(Me.lblSelEmpresa)
        Me.Panel1.Controls.Add(Me.txtEmpresa)
        Me.Panel1.Controls.Add(Me.txtLogin)
        Me.Panel1.Controls.Add(Me.lblSenha)
        Me.Panel1.Controls.Add(Me.txtSenha)
        Me.Panel1.Location = New System.Drawing.Point(1, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(258, 179)
        Me.Panel1.TabIndex = 12
        '
        'bt0Sair
        '
        Me.bt0Sair.Appearance.ForeColor = System.Drawing.Color.Black
        Me.bt0Sair.Appearance.Options.UseForeColor = True
        Me.bt0Sair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt0Sair.Location = New System.Drawing.Point(163, 137)
        Me.bt0Sair.LookAndFeel.SkinName = "Black"
        Me.bt0Sair.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Sair.Name = "bt0Sair"
        Me.bt0Sair.Size = New System.Drawing.Size(75, 23)
        Me.bt0Sair.TabIndex = 18
        Me.bt0Sair.Text = "Sair"
        '
        'bt0Entrar
        '
        Me.bt0Entrar.Appearance.ForeColor = System.Drawing.Color.Black
        Me.bt0Entrar.Appearance.Options.UseForeColor = True
        Me.bt0Entrar.Location = New System.Drawing.Point(18, 137)
        Me.bt0Entrar.LookAndFeel.SkinName = "Black"
        Me.bt0Entrar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.bt0Entrar.Name = "bt0Entrar"
        Me.bt0Entrar.Size = New System.Drawing.Size(75, 23)
        Me.bt0Entrar.TabIndex = 17
        Me.bt0Entrar.Text = "Entrar"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(15, 48)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(36, 13)
        Me.lblLogin.TabIndex = 0
        Me.lblLogin.Text = "Login:"
        '
        'lblSelEmpresa
        '
        Me.lblSelEmpresa.AutoSize = True
        Me.lblSelEmpresa.Location = New System.Drawing.Point(14, 7)
        Me.lblSelEmpresa.Name = "lblSelEmpresa"
        Me.lblSelEmpresa.Size = New System.Drawing.Size(51, 13)
        Me.lblSelEmpresa.TabIndex = 8
        Me.lblSelEmpresa.Text = "Empresa:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.FormattingEnabled = True
        Me.txtEmpresa.Location = New System.Drawing.Point(18, 23)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(220, 21)
        Me.txtEmpresa.TabIndex = 1
        '
        'txtLogin
        '
        Me.txtLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtLogin.Location = New System.Drawing.Point(18, 64)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(220, 20)
        Me.txtLogin.TabIndex = 2
        '
        'lblSenha
        '
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Location = New System.Drawing.Point(15, 89)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(41, 13)
        Me.lblSenha.TabIndex = 1
        Me.lblSenha.Text = "Senha:"
        '
        'txtSenha
        '
        Me.txtSenha.Location = New System.Drawing.Point(18, 105)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(124)
        Me.txtSenha.Size = New System.Drawing.Size(220, 20)
        Me.txtSenha.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.PicturePrisma)
        Me.Panel3.Controls.Add(Me.LabelControl1)
        Me.Panel3.Location = New System.Drawing.Point(414, 169)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(315, 279)
        Me.Panel3.TabIndex = 15
        '
        'PicturePrisma
        '
        Me.PicturePrisma.BackColor = System.Drawing.Color.Transparent
        Me.PicturePrisma.BackgroundImage = Global.Horten.My.Resources.Resources.logo1
        Me.PicturePrisma.Location = New System.Drawing.Point(21, 91)
        Me.PicturePrisma.Name = "PicturePrisma"
        Me.PicturePrisma.Size = New System.Drawing.Size(266, 68)
        Me.PicturePrisma.TabIndex = 17
        Me.PicturePrisma.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(208, 261)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "LabelControl1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(148, 448)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(273, 20)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.bt0Entrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CancelButton = Me.bt0Sair
        Me.ClientSize = New System.Drawing.Size(880, 600)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1200)
        Me.MinimumSize = New System.Drawing.Size(880, 600)
        Me.Name = "frmLogin"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prisma - Login"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PicturePrisma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblSelEmpresa As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents bt0Sair As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bt0Entrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PicturePrisma As System.Windows.Forms.PictureBox

End Class
