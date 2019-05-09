Namespace LanguageExtensions
    Public Module GeneralHelperExtensions
        <Runtime.CompilerServices.Extension>
        Public Function IntegerArrayToString(sender() As Integer) As String
            Return String.Join(",", sender)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function TimeSpanArrayToString(sender() As Integer) As String
            Return String.Join(",", sender)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function DecimalArrayToString(sender() As Decimal) As String
            Return String.Join(",", sender)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function DoubleArrayToString(sender() As Double) As String
            Return String.Join(",", sender)
        End Function
        <Runtime.CompilerServices.Extension>
        Public Function ToStringArray(sender As String,
            Optional separator As Char = ","c) As String()
            Return sender.Split(separator)
        End Function
    End Module

End Namespace