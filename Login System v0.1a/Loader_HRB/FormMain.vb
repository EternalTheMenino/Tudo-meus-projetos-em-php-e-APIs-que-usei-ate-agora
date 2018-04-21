Imports System.Net

Public Class FormMain
 

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
        LoginForm.Close()

    End Sub


End Class