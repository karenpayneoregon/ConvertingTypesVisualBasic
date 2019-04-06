Imports System.IO
Imports NumericHelpers.LanguageExtensions
Imports ParsingAndConvertingWindowsForms.LanguageExtensions

Public Class ReadingStringArrayToIntArrayForm
    ''' <summary>
    ''' Given each line in a text file are valid integers display each
    ''' line as an array of integers.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub stringArrayToIntegerArrayGoodButton_Click(sender As Object, e As EventArgs) _
        Handles stringArrayToIntegerArrayGoodButton.Click

        TextBox1.Text = ""

        Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    "StringArrayToIntegerArrayGood.txt")

        Dim lines = File.ReadAllLines(fileName)

        For Each line As String In lines
            Dim integerArray = line.ToStringArray().ToIntegerArray()
            For Each integerValue As Integer In integerArray
                Console.WriteLine(integerValue)
                TextBox1.AddLine(integerValue)
            Next

            TextBox1.AddSpacer()

        Next
    End Sub
    ''' <summary>
    ''' Given each line in a text file may or may not contain elements that
    ''' can be converted to integers when these are encountered return 0 for 
    ''' those elements which can not be converted.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub stringArrayToIntegerArrayPreserveAssertButton_Click(sender As Object, e As EventArgs) _
        Handles stringArrayToIntegerArrayAssertPreserveButton.Click

        TextBox1.Text = ""

        Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    "StringArrayToIntegerArrayQuestionable.txt")

        Dim lines = File.ReadAllLines(fileName)
        Dim checkArray As String()

        For lineIndex As Integer = 0 To lines.Count() - 1

            checkArray = lines(lineIndex).ToStringArray()

            If checkArray.CanConvertToIntArray Then
                TextBox1.AddLine($"Line {lineIndex} is valid")
            Else
                Dim getSomeIntegers = checkArray.ToIntegerPreserveArray()
                TextBox1.AddLine($"Line {lineIndex} -> Original: {checkArray.FlattenToString(",")} " &
                                  $"Perserved array: {getSomeIntegers.IntegerArrayToString}")
            End If

            TextBox1.AddSpacer()

        Next
    End Sub
    ''' <summary>
    ''' Given each line in a text file may or may not contain elements that
    ''' can be converted to integers when these are encountered these elements
    ''' are ignored and the returning array is shorter then the original array.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub stringArrayToIntegerArrayAssertAdjustButton_Click(sender As Object, e As EventArgs) _
        Handles stringArrayToIntegerArrayAssertAdjustButton.Click

        TextBox1.Text = ""

        Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    "StringArrayToIntegerArrayQuestionable.txt")

        Dim lines = File.ReadAllLines(fileName)
        For Each line As String In lines

            Dim integerArray = line.ToStringArray().ToIntegerArray()

            TextBox1.AddLine($"Element count {line.ToStringArray().Count()} " &
                             $"Converted count: {integerArray.Count()}")

            For Each integerValue As Integer In integerArray
                TextBox1.AddLine(integerValue)
            Next

            TextBox1.AddSpacer()
        Next
    End Sub
End Class