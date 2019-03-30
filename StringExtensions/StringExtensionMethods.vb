Public Module StringExtensionMethods
    ''' <summary>
    ''' Indicates whether a specified string is null, empty, or consists only of white-space characters.
    ''' </summary>
    ''' <param name="value">The string to test.</param>
    ''' <returns>true if the value parameter is null or Empty, or if value consists exclusively of white-space characters.</returns>
    ''' <remarks>
    ''' This is for projects written in Framework 3.5 to use IsNullOrWhiteSpace as an extension method
    ''' </remarks>
    <Runtime.CompilerServices.Extension>
    Public Function IsNullOrWhiteSpace(value As String) As Boolean
        Return (value Is Nothing) OrElse String.IsNullOrEmpty(value.Trim())
    End Function
End Module
