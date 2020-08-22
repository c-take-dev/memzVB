Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Rnd() * Screen.PrimaryScreen.Bounds.Width, Rnd() * Screen.PrimaryScreen.Bounds.Height)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Rnd() * 10 < 1 Then

            Me.TopMost = True

        End If

    End Sub
End Class