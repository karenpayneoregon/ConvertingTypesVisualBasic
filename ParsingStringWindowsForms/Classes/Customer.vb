Namespace Classes
    Public Class Customer
        Public Property Identifier() As Integer
        Public Property CompanyName() As String
        Public Property Street() As String
        Public Property City() As String
        Public Property StateCode() As String
        Public Property Active() As Boolean = False

        Public Overrides Function ToString() As String
            Return CompanyName
        End Function
    End Class
End Namespace