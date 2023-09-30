Imports System.Web.Security
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf

Public Class Form1

    Public Drag As Boolean
    Public Down As Integer
    Public Up As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Application.ExitThread()

    End Sub

    Private Sub minButton_Click(sender As Object, e As EventArgs) Handles minButton.Click
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub topPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles topPanel.MouseDown
        If e.Button = MouseButtons.Left Then
            Drag = True
            Down = e.X
            Up = e.Y

        End If
    End Sub

    Private Sub topPanel_MouseUp(sender As Object, e As MouseEventArgs) Handles topPanel.MouseUp
        If e.Button = MouseButtons.Left Then
            Drag = False
        End If
    End Sub

    Private Sub topPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles topPanel.MouseMove
        If Drag Then
            Dim temp As Point = New Point
            temp.X = Location.X + (e.X - Down)
            temp.Y = Location.Y + (e.Y - Up)
            Location = temp
            temp = Nothing
        End If
    End Sub
End Class
