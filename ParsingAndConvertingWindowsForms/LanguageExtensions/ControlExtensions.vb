Namespace LanguageExtensions
    Public Module ControlExtensions
        ''' <summary>
        ''' Add text with a new line
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="text"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub AddLine(sender As TextBox, text As String)
            sender.AppendText($"{text}{Environment.NewLine}")
        End Sub
        ''' <summary>
        ''' Add a Integer with a new line
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="integerValue"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub AddLine(sender As TextBox, integerValue As Integer)
            sender.AppendText($"{integerValue}{Environment.NewLine}")
        End Sub
        ''' <summary>
        ''' Add a new line
        ''' </summary>
        ''' <param name="sender"></param>
        <Runtime.CompilerServices.Extension>
        Public Sub AddSpacer(sender As TextBox)
            sender.AppendText(Environment.NewLine)
        End Sub
    End Module
End Namespace