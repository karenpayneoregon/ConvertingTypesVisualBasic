Namespace Classes
    Public Class TimeSpanItem
        Public Property Id() As Integer
        Public Property TimeSpan() As TimeSpan

        Public Overrides Function ToString() As String
            Return $"{TimeSpan}"
        End Function
    End Class
End NameSpace