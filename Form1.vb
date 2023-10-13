Imports System.Web.Security
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf


Public Class Form1

    Public Drag As Boolean
    Public Down As Integer
    Public Up As Integer

    Public Sub Gauge360Example()



        SolidGauge1.Uses360Mode = False
        SolidGauge1.From = 0
        SolidGauge1.To = 100
        SolidGauge1.Value = 50
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Gauge360Example()
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

    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs) Handles BindingNavigator1.RefreshItems

    End Sub

    Private Sub SolidGauge1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles SolidGauge1.ChildChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        SolidGauge1.Value = 69
    End Sub
End Class


