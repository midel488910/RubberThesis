Imports System.Web.Security
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient
Imports Mysqlx


Public Class Form1

    Public Drag As Boolean
    Public Down As Integer
    Public Up As Integer

    Public Sub Gauge360Example()
        SolidGauge1.Uses360Mode = False
        SolidGauge1.From = 0
        SolidGauge1.To = 100
        SolidGauge1.Value = GetCurrentPercentage()

    End Sub

    Public Function GetCurrentPercentage() As Integer
        Dim percentage As Integer = 0
        Try
            Connect()
            Dim query As String = "SELECT percentage FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
            'Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
            command = New MySqlCommand(query, conn)
            Dim reader = command.ExecuteReader()


            While reader.Read()
                query = "SELECT percentage FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
                percentage = Convert.ToInt32(reader("percentage"))
            End While
            'percentageGauge.Value = percentage

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return percentage
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim timer As New Timer()
        timer.Interval = 2000 ' 5000 milliseconds (5 seconds)
        timer.Start()
        Gauge360Example()
        AddHandler timer.Tick, AddressOf Gauge360Example
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

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged

    End Sub
End Class


