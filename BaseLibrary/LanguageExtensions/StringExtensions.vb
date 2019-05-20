Namespace LanguageExtensions
    Public Module StringExtensions
        ''' <summary>
        ''' Provides functionality for Framework 3.5 available in Framework 4x
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function IsNullOrWhiteSpace(sender As String) As Boolean
            Return (sender Is Nothing) OrElse String.IsNullOrEmpty(sender.Trim())
        End Function
    End Module
End Namespace