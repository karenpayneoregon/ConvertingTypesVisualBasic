Public Class Form1
    ''' <summary>
    ''' In this case a developer assumed the operator would never enter anything
    ''' other than a integer, in this case they entered a string which can not be
    ''' converted to an integer. Also note many time the cast is done without 
    ''' a try/catch statement but after the first time they gravitate to a try/catch
    ''' which is incorrect.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub assumesIntegerTryItButton_Click(sender As Object, e As EventArgs) Handles assumesIntegerTryItButton.Click
        Try
            Dim value As Integer = CInt(assumesIntegerTextBox.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ActiveControl = closeButton
    End Sub
End Class
