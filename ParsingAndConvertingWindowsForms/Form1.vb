''' <summary>
''' This is for showing how to work with casting, parsing and converting
''' numbers. More code samples will be added over time.
''' </summary>
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
        ActiveControl = keyPressAssertionOnIntegerTextBox
    End Sub
    ''' <summary>
    ''' Provides assertion to only permit Integers entered into the TextBox.
    ''' This is fine for UI assertion while in the next event using TryParse
    ''' which is good for both UI and classes/code modules yet in some cases
    ''' it's good to use both assertions.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AssertionOnInteger_KeyPressForOnlyIntegers(sender As Object, e As KeyPressEventArgs) _
        Handles keyPressAssertionOnIntegerTextBox.KeyPress

        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    ''' <summary>
    ''' Parse TextBox Text property to an Integer using assertion with Integer.TryParse.
    ''' Works for UI and in classes and/or code modules.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tryParseIntegerButton_Click(sender As Object, e As EventArgs) Handles tryParseIntegerButton.Click
        If Not String.IsNullOrWhiteSpace(tryParseIntegerTextBox.Text) Then
            Dim value As Integer = 0
            If Integer.TryParse(tryParseIntegerTextBox.Text, value) Then
                MessageBox.Show("Successfully parsed to Integer")
            Else
                MessageBox.Show($"'{tryParseIntegerTextBox.Text}' could not be converted to an integer")
            End If
        Else
            MessageBox.Show("Please enter a value")
        End If
    End Sub
End Class
