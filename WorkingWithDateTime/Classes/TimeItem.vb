Namespace Classes
    Public Class TimeItem
        ''' <summary>
        ''' Displays time with AM/PM
        ''' </summary>
        ''' <returns></returns>
        Public Property DisplayName() As String
        ''' <summary>
        ''' TimeSpan for item
        ''' </summary>
        ''' <returns></returns>
        Public Property TimeSpan() As TimeSpan
        ''' <summary>
        ''' Used for DisplayMember of ComboBox or ListBox
        ''' </summary>
        ''' <returns>DisplayName</returns>
        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class
End Namespace