Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1

    Private mainGraphics As Graphics
    Private PlayerImage As Bitmap

    Dim mouseX As Integer = System.Windows.Forms.Cursor.Position.X
    Dim mouseY As Integer = System.Windows.Forms.Cursor.Position.Y

    Dim h As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
    Dim w As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.None
        Me.Size = New Size(w, h)
        Me.TransparencyKey = Me.BackColor
        Me.DoubleBuffered = True
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2

        Init()

        Timer2.Enabled = True
        Timer1.Enabled = True
    End Sub
    Private Sub Init()

        If mainGraphics Is Nothing Then

            Dim bmp As New Bitmap(Me.ClientRectangle.Width, Me.ClientRectangle.Height)
            Me.BackgroundImage = bmp
            mainGraphics = Graphics.FromImage(bmp)
        End If

        PlayerImage = My.Resources.win7_ico_imageres_dll_094.ToBitmap()

    End Sub
    Dim x As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        Dim mouseX As Integer = System.Windows.Forms.Cursor.Position.X
        Dim mouseY As Integer = System.Windows.Forms.Cursor.Position.Y

        mainGraphics.DrawImage(PlayerImage, mouseX, mouseY)

        If Rnd() * 10 < 1 Then

            If Rnd() * 100 < 40 Then

                PlayerImage = My.Resources.win7_ico_imageres_dll_080.ToBitmap()

            End If

            If Rnd() * 5 < 1 Then

                Me.TopMost = True
                Dim f2 = New Form2
                f2.Show()

            End If
        End If

        If Rnd() * 10 < 5 Then
            mainGraphics.DrawImage(PlayerImage, Rnd() * Screen.PrimaryScreen.Bounds.Width, Rnd() * Screen.PrimaryScreen.Bounds.Height)
        End If

        PlayerImage = My.Resources.win7_ico_imageres_dll_094.ToBitmap()

        If Rnd() * 2000 < 15 Then
            Dim canvas As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

            Dim g As Graphics = Graphics.FromImage(canvas)
            Dim b As New SolidBrush(Me.BackColor)

            g.FillRectangle(b, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

            b.Dispose()
            g.Dispose()

            mainGraphics.DrawImage(canvas, 0, 0)
        End If

        Me.Invalidate()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Dim bmp As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        'copy scr
        g.CopyFromScreen(New Point(0, 0), New Point(0, 0), bmp.Size)
        g.Dispose()

        mainGraphics.DrawImage(CType(bmp, Image), CInt((Screen.PrimaryScreen.Bounds.Width * (1 - 0.8)) / 2), CInt((Screen.PrimaryScreen.Bounds.Height * (1 - 0.8)) / 2), CInt(Screen.PrimaryScreen.Bounds.Width * 0.8), CInt(Screen.PrimaryScreen.Bounds.Height * 0.8))

    End Sub
End Class
