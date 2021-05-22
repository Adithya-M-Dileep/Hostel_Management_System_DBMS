Public Class LoginPage
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        Dim user As String = logUser.Text
        Dim pass As String = logPass.Text

        If user = "admin" And pass = "pass" Then
            MainPage.Show()
            logUser.Clear()
            logPass.Clear()


        Else
            MessageBox.Show("Wrong user name or Password", "Incorrect")
            logUser.Clear()
            logPass.Clear()

        End If
    End Sub

    Private Sub exitl_Click(sender As Object, e As EventArgs) Handles exitl.Click
        Me.Close()

    End Sub
End Class
