Namespace Classes
    Public Class Hours
        ''' <summary>
        ''' Return a list where the display value is a formatted time ready to use
        ''' in a ListBox or ComboBox.
        ''' </summary>
        ''' <param name="pTimeIncrement"></param>
        ''' <returns></returns>
        Public Function SpecialRange(Optional ByVal pTimeIncrement As TimeIncrement = TimeIncrement.Hourly) As List(Of TimeItem)

            Dim timeItemList As New List(Of TimeItem)
            Const timeHhMmTtformat = "hh:mm tt"

            Dim hours As IEnumerable(Of Date) = Enumerable.Range(0, 24).Select(Function(index) (Date.MinValue.AddHours(index)))


            For Each dateTime In hours

                ' this is the hour
                timeItemList.Add(New TimeItem With {.DisplayName = dateTime.ToString(timeHhMmTtformat), .TimeSpan = dateTime.TimeOfDay})

                If pTimeIncrement = TimeIncrement.Quarterly Then

                    timeItemList.Add(New TimeItem With
                                        {
                                        .DisplayName = dateTime.AddMinutes(15).ToString(timeHhMmTtformat),
                                        .TimeSpan = dateTime.AddMinutes(15).TimeOfDay
                                        })

                    timeItemList.Add(New TimeItem With
                                        {
                                        .DisplayName = dateTime.AddMinutes(30).ToString(timeHhMmTtformat),
                                        .TimeSpan = dateTime.AddMinutes(30).TimeOfDay
                                        })

                    timeItemList.Add(New TimeItem With
                                        {
                                        .DisplayName = dateTime.AddMinutes(45).ToString(timeHhMmTtformat),
                                        .TimeSpan = dateTime.AddMinutes(45).TimeOfDay
                                        })

                ElseIf pTimeIncrement = TimeIncrement.HalfHour Then

                    timeItemList.Add(New TimeItem With
                                        {
                                        .DisplayName = dateTime.AddMinutes(30).ToString(timeHhMmTtformat),
                                        .TimeSpan = dateTime.AddMinutes(30).TimeOfDay
                                        })

                End If
            Next

            Return timeItemList

        End Function
    End Class
End Namespace