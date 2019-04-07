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
    ''' <summary>
    ''' Ask to lose changes, if Yes is pressed the form will close,
    ''' if No is selected the form stays open.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If My.Dialogs.Question("Lose changes?") Then
            CausesValidation = False
            e.Cancel = False
        End If
    End Sub
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Close()
    End Sub
End Class





