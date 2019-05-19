Namespace Classes
    Public Class TimeItem
        Public Property DisplayName() As String
        Public Property TimeSpan() As TimeSpan

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class
End Namespace