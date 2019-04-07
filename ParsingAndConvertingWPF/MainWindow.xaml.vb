Imports System.Text.RegularExpressions
Class MainWindow
    ''' <summary>
    ''' Pattern match for determining if a string can be 
    ''' represented as a integer
    ''' </summary>
    Private Shared ReadOnly _regex As New Regex("[^0-9.-]+")
    Private Shared Function IsTextAllowed(ByVal text As String) As Boolean
        Return _regex.IsMatch(text)
    End Function
    ''' <summary>
    ''' Used to prevent information entered to be non-integer values
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AssertIntegerTextBox_OnPreviewTextInput(
        sender As Object,
        e As TextCompositionEventArgs)

        e.Handled = _regex.IsMatch(e.Text)

    End Sub
    ''' <summary>
    ''' Show value of Text property as an integer or report no value.
    ''' Does not handle paste from the Windows Clipboard which can be
    ''' done but this is a simple example not on all possible things that
    ''' can happen.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub IntegerOnlyTextBox_OnClick(
        sender As Object,
        e As RoutedEventArgs)

        If String.IsNullOrWhiteSpace(assertIntegerTextBox.Text) Then
            MessageBox.Show("No value")
        Else
            MessageBox.Show($"Value is {assertIntegerTextBox.Text}")
        End If

    End Sub
    ''' <summary>
    ''' In a real application the novice developer will not use 
    ''' assertion but instead
    ''' do the cast or use a try/catch rather than perform assertion first.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NoAssertionToCheckIfIntegerButton_OnClick(
        sender As Object,
        e As RoutedEventArgs)

        Try
            Dim value = CInt(doesNoAssertionForValueAsIntegerTextBox.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Assert that text entered is a valid integer. Alternates are
    ''' to see if the text can be converted to Double and then use as Double
    ''' or truncate to Integer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub tryParseAssertionButton_Click(
        sender As Object,
        e As RoutedEventArgs) Handles tryParseAssertionButton.Click

        If Not String.IsNullOrWhiteSpace(tryparseIntegerTextBox.Text) Then

            Dim value As Integer = 0

            If Integer.TryParse(tryparseIntegerTextBox.Text, value) Then
                MessageBox.Show($"You entered a valid integer: {value}")
            Else
                MessageBox.Show($"'{tryparseIntegerTextBox.Text}' could not be converted to an integer")
            End If

        Else
            MessageBox.Show("Please enter a value")
        End If

    End Sub
End Class
