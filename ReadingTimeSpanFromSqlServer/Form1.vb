Imports BaseLibrary.Classes
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        Dim timeOperations As New TimeDataOperations
        ListBox1.DataSource = timeOperations.ReadHours()

    End Sub
End Class
