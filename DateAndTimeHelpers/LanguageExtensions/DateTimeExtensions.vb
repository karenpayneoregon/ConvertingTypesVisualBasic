Imports System.Globalization

Namespace LanguageExtensions
    Public Module DateTimeExtensions
        ''' <summary>
        ''' Compose date and time by providing values for each element
        ''' </summary>
        ''' <param name="day">Date to use</param>
        ''' <param name="time">Time to use</param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function At(day As Date, time As TimeSpan) As Date
            Return (New Date(day.Year, day.Month, day.Day, 0, 0, 0)).Add(time)
        End Function
        ''' <summary>
        ''' Convert string to date time using various formats
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function ToDate(sender As String) As Date
            Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "MM/dd/yyyy"}
            Dim dateValue As Date

            Date.TryParseExact(sender, format, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, dateValue)

            Return dateValue

        End Function
    End Module
End Namespace