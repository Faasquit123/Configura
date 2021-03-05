Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        About.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SplashScreen1.Show()
        Threading.Thread.Sleep(4000)
        SplashScreen1.Hide()
        Editor.Show()
        Me.Hide()
    End Sub
End Class