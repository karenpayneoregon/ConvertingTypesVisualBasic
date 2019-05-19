Imports System.Collections.ObjectModel
Imports System.IO

Namespace BaseClasses
    ''' <summary>
    ''' Arrays for validating unit test
    ''' </summary>
    ''' <remarks>
    ''' For a production solution assertion would be advised for
    ''' determining if the file exists and also ensuring the
    ''' date format is correct e.g. perhaps a solution is to read information
    ''' from a file where the file could be from multiple countries, the name 
    ''' of the file might contain a token indicating the country e.g.
    ''' English_Events.text, Spanish_Events.txt, German_Events.txt etc.
    ''' </remarks>
    Public Class TestBase
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
        Public Function GetAllTimeZones() As IEnumerable(Of String)
            Dim timeZones As IEnumerable(Of String) = TimeZoneInfo.GetSystemTimeZones().Select(Function(timeZoneInfo) timeZoneInfo.Id)
            Return timeZones
        End Function
    End Class
End Namespace