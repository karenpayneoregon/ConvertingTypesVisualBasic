Imports System.IO

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
        '2.4,6.9,1.3,1
        Protected ReadOnly StringArrayCurrencyDouble() As String =
                               {"2.4", "4.8'", Nothing, "6.9", "[8.5]", "", "1.3", "Karen", "1"}
        Protected ReadOnly DoubleArrayValidator() As Double =
                               {2.4, 0, 0, 6.9, 0, 0, 1.3, 0, 1}

        Protected ReadOnly StringArrayAllDoubles() As String =
                               {"2.6", "4.7", "5", "6", "8.98", "12", "1", "99.2", "-1"}


        Public Function GetEventDates(Optional dateFormat As String = "MM.dd.yyyy") As List(Of EventDate)
            Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WithDatesFromAnotherCulture.txt")
            Dim eventList = New List(Of EventDate)

            Using reader As New FileIO.TextFieldParser(fileName) With {.Delimiters = New String() {","}, .TextFieldType = FileIO.FieldType.Delimited}
                Dim line As String()
                While Not reader.EndOfData
                    line = reader.ReadFields()
                    eventList.Add(New EventDate() With
                                     {
                                         .Id = CInt(line(0)),
                                         .DateOf = Date.ParseExact(line(1), dateFormat, Nothing)
                                     })
                End While
            End Using

            Return eventList
        End Function
    End Class
    Public Class EventDate
        Public Property Id() As Integer
        Public Property DateOf() As Date
    End Class
End Namespace