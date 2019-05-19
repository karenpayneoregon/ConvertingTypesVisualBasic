Namespace LanguageExtensions
    Public Module DateTimeExtensions
        ''' <summary>
        ''' Determine if a string represents a time
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Will fail if tt specifier is included.
        ''' </remarks>
        <Runtime.CompilerServices.Extension>
        Public Function IsValidTimeFormat(sender As String) As Boolean

            Return TimeSpan.TryParse(sender, Nothing)

        End Function
        ''' <summary>
        ''' Determine if a string represents a date.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function IsValidDateFormat(sender As String) As Boolean

            Return Date.TryParse(sender, Nothing)

        End Function
        ''' <summary>
        ''' Convert string in the format of HH:MM to a timespan
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function AsTimeSpan(sender As String) As TimeSpan
            Dim timeSpan As TimeSpan

            TimeSpan.TryParse(sender, timeSpan)

            Return timeSpan

        End Function
        ''' <summary>
        ''' Sanitizes time string of HH:MM tt to HH:MM and return a TimeSpan
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function AsTimeSpan1(sender As String) As TimeSpan

            sender = sender.ToUpper().Replace(" AM", "").Replace(" PM", "")

            Dim timeSpan As TimeSpan

            TimeSpan.TryParse(sender, timeSpan)

            Return timeSpan

        End Function
        ''' <summary>
        ''' Return the nearest quarter hour in reverse.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function RoundDown(sender As Date) As Date
            Return New Date(sender.Year, sender.Month, sender.Day, sender.Hour, (sender.Minute \ 15) * 15, 0)
        End Function

    End Module
End Namespace