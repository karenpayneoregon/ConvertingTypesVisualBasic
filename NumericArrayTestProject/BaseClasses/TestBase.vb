Namespace BaseClasses
    ''' <summary>
    ''' Arrays for validating unit test
    ''' </summary>
    Public Class TestBase

        Protected ReadOnly StringArrayMixedTypesIntegers() As String =
                               {"2", "4B", Nothing, "6", "8A", "", "1.3", "Karen", "-1"}

        Protected ReadOnly IntegerArrayValidator() As Integer =
                               {2, 0, 0, 6, 0, 0, 0, 0, -1}

        Protected ReadOnly StringArrayAllIntegers() As String =
                               {"2", "4", "5", "6", "8", "12", "1", "99", "-1"}

        Protected ReadOnly StringArrayMixedTypesDouble() As String =
                               {"2.4", "4.8'", Nothing, "6.9", "[8.5]", "", "1.3", "Karen", "1"}

        Protected ReadOnly DoubleArrayValidator() As Double =
                               {2.4, 0, 0, 6.9, 0, 0, 1.3, 0, 1}

        Protected ReadOnly StringArrayAllDoubles() As String =
                               {"2.6", "4.7", "5", "6", "8.98", "12", "1", "99.2", "-1"}

    End Class
End Namespace