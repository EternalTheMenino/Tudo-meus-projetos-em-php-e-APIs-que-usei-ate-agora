Imports System.IO
Imports System.Net

Public Class LoginForm


    Public linkdosite As String = "http://localhost/teste/"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    
       

        If My.Settings.check Then
            lembra.Checked = My.Settings.check
            login.Text = My.Settings.login
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles logar.Click

        If lembra.Checked Then
            My.Settings.check = True
            My.Settings.login = login.Text
            My.Settings.Save()
        Else
            My.Settings.check = False
            My.Settings.login = ""
            My.Settings.Save()
        End If


        If login.Text = "" Or senha.Text = "" Then
            MessageBox.Show("Login ou senha em brancos.")
            Return
        End If
        Dim r As New Random(System.DateTime.Now.Millisecond)
        Dim Valx As Integer = r.Next(1, 5)
        Using Acessar As New Net.WebClient
            Dim Param As New Specialized.NameValueCollection
            Param.Add("login", base64_encode(encry(login.Text, 2)))
            Param.Add("senha", base64_encode(encry(senha.Text, 2)))
            Param.Add("hwid", base64_encode(encry(GetHDSerial(), 2)))
            '       Param.Add("versao", base64_encode(encry(versao.SelectedIndex.ToString, 2)))
            Acessar.Headers(HttpRequestHeader.Accept) = Valx.ToString
            Dim RespostaBytes As Byte() = Acessar.UploadValues(linkdosite & "_entrar.php", "POST", Param)
            Dim RespostaHTML As String = (New System.Text.UTF8Encoding).GetString(RespostaBytes)


            If RespostaHTML = base64_encode(encry(Valx.ToString, Valx)) Then

                Me.Hide()

                FormMain.Show()
            ElseIf RespostaHTML = "computerfail" Then
                MsgBox("Computador diferente do que foi cadastrado sua conta inicialmente.")
            ElseIf RespostaHTML = "endtime" Then
                MsgBox("Seu vip acabou, compre mais no site para ter acesso.")

            End If
        End Using
    End Sub
End Class
