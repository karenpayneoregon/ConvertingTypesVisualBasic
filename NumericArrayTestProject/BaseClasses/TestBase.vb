Namespace BaseClasses
    Public Class TestBase
        Protected ReadOnly stringArrayMixedTypesIntegers() As String =
                               {"2", "4B", Nothing, "6", "8A", "", "1.3", "Karen", "-1"}

        Protected ReadOnly integergArrayValidator() As Integer =
                               {2, 0, 0, 6, 0, 0, 0, 0, -1}

        Protected ReadOnly stringArrayAllIntegers() As String =
                               {"2", "4", "5", "6", "8", "12", "1", "99", "-1"}


    End Class
End Namespace