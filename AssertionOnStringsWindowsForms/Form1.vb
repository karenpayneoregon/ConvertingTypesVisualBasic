Imports System.ComponentModel

Public Class Form1
    Private Sub addCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles addCustomerButton.Click

        If ValidateChildren() Then
            MessageBox.Show("Go to go")
        End If

    End Sub

    Private Sub firstNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles firstNameTextBox.Validating

        If String.IsNullOrWhiteSpace(firstNameTextBox.Text) Then
            ErrorProvider1.SetError(firstNameTextBox, "first name is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(firstNameTextBox, "")
            e.Cancel = False
        End If

    End Sub

End Class
Public Class Customer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property EmailAddress() As String
End Class

Public Class FileOperations

End Class


