Namespace LanguageExtensions
    Public Module GeneralHelperExtensions
        <Runtime.CompilerServices.Extension>
        Public Function IntegerArrayToString(sender() As Integer) As String
            Return String.Join(",", sender)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function DecimalArrayToString(sender() As Decimal) As String
            Return String.Join(",", sender)
        End Function
    End Module
End Namespace