<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.logar = New System.Windows.Forms.Button()
        Me.lembra = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.senha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.login = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.logar)
        Me.GroupBox1.Controls.Add(Me.lembra)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.senha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.login)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 168)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Autenticação"
        '
        'logar
        '
        Me.logar.Location = New System.Drawing.Point(116, 99)
        Me.logar.Name = "logar"
        Me.logar.Size = New System.Drawing.Size(140, 23)
        Me.logar.TabIndex = 8
        Me.logar.Text = "Login"
        Me.logar.UseVisualStyleBackColor = True
        '
        'lembra
        '
        Me.lembra.AutoSize = True
        Me.lembra.Location = New System.Drawing.Point(24, 103)
        Me.lembra.Name = "lembra"
        Me.lembra.Size = New System.Drawing.Size(86, 17)
        Me.lembra.TabIndex = 7
        Me.lembra.Text = "Lembra login"
        Me.lembra.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Senha:"
        '
        'senha
        '
        Me.senha.Location = New System.Drawing.Point(63, 73)
        Me.senha.Name = "senha"
        Me.senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.senha.Size = New System.Drawing.Size(193, 20)
        Me.senha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Login:"
        '
        'login
        '
        Me.login.Location = New System.Drawing.Point(63, 47)
        Me.login.Name = "login"
        Me.login.Size = New System.Drawing.Size(193, 20)
        Me.login.TabIndex = 1
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 190)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents senha As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents login As TextBox
    Friend WithEvents lembra As CheckBox
    Friend WithEvents logar As Button
End Class
