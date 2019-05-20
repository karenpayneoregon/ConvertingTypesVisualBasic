Imports System.Globalization
Imports DateAndTimeHelpers.LanguageExtensions
Imports WorkingWithDateTime.Classes
Imports WorkingWithDateTime.LanguageExtensions

Public Class Form1
    Private Sub IsDateExamplesButton_Click(sender As Object, e As EventArgs) Handles IsDateExamplesButton.Click
        Dim dateValue As Date
        Dim dateStringValue = "May 18, 2019"
        If Date.TryParse(dateStringValue, dateValue) Then
            Console.WriteLine(dateValue)
        End If


        Console.WriteLine(IsDate(CDate("5/18/2019")))
        Console.WriteLine(IsDate(#05/18/2019#))
        Console.WriteLine(IsDate("May 18, 2019"))



        Dim separator = My.Culture.DateSeparator()

        If Date.TryParse(dateStringValue, dateValue) Then
            Console.WriteLine($"{dateStringValue} is a valid date {dateValue.Month}{separator}{dateValue.Day}{separator}{dateValue.Year}")
            Console.WriteLine($"{dateStringValue} is a valid date {dateValue.ToString("d")}")
        Else
            Console.WriteLine($"{dateStringValue} can not represent a date")
        End If

        If dateStringValue.IsValidDateFormat() Then
            Console.WriteLine($"{dateStringValue} is a valid date {dateValue.Month}{separator}{dateValue.Day}{separator}{dateValue.Year}")
            Console.WriteLine($"{dateStringValue} is a valid date {dateValue.ToString("d")}")
        Else
            Console.WriteLine($"{dateStringValue} can not represent a date")
        End If

    End Sub

    Private Sub IsTimeExamplesButton_Click(sender As Object, e As EventArgs) Handles IsTimeExamplesButton.Click

        Dim timeValue = "10:55 AM"
        If IsDate(timeValue) Then
            ' 1/1/0001 10:55:00 AM
            Console.WriteLine(CDate(timeValue))
            ' 10:55:00 AM
            Console.WriteLine(CDate(timeValue).ToString("hh:mm tt"))
        Else
            Console.WriteLine($"{timeValue} is not valid")
        End If

        ' this fails because of the AM/PM specifier
        If timeValue.IsValidTimeFormat() Then
            Console.WriteLine($"As TimeSpan: {timeValue.AsTimeSpan}")
        Else
            Console.WriteLine($"{timeValue} is not valid")
        End If

        ' this is successful because tt specifier was anticipated
        Console.WriteLine($"{timeValue} as TimeSpan1: {timeValue.AsTimeSpan1}")



        ' unlike the last example time value is not value so 00:00:00 is returned
        timeValue = "33:44"
        Console.WriteLine($"{timeValue} as TimeSpan1: {timeValue.AsTimeSpan1}")

        ' this succeeds without the AM/PM specifier
        timeValue = "10:55"

        If timeValue.IsValidTimeFormat() Then
            Console.WriteLine($"As TimeSpan: {timeValue.AsTimeSpan}")
        Else
            Console.WriteLine($"{timeValue} is not valid")
        End If

    End Sub
    Private dateTimePickerPreviousDate As Date
    Private dataTimePickerIsBusy As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hours As New Hours

        HoursComboBox.DataSource = hours.SpecialRange(TimeIncrement.Quarterly).ToList()
        HoursComboBox.SelectedIndex = 0

        ' set HoursComboBox selected index to the nearest quarter hour
        Dim finder = Now.RoundDown().ToString("hh:mm tt")
        HoursComboBox.SelectedIndex = HoursComboBox.FindString(finder)

        DateTimePicker1.Value = Date.Now.RoundDown()
        dateTimePickerPreviousDate = DateTimePicker1.Value


    End Sub

    Private Sub GetCurrentHoursComboBoxValueButton_Click(sender As Object, e As EventArgs) _
        Handles GetCurrentHoursComboBoxValueButton.Click

        Dim timeItem = CType(HoursComboBox.SelectedItem, TimeItem)

        MessageBox.Show($"{timeItem.DisplayName} - {timeItem.TimeSpan}")
    End Sub
    ''' <summary>
    ''' Logic to keep to quarter hour
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) _
        Handles DateTimePicker1.ValueChanged

        If Not dataTimePickerIsBusy Then

            dataTimePickerIsBusy = True

            Dim dt As Date = DateTimePicker1.Value

            If (dt.Minute * 60 + dt.Second) Mod 300 <> 0 Then

                Dim diff As TimeSpan = dt.Subtract(dateTimePickerPreviousDate)

                If diff.Ticks < 0 Then
                    DateTimePicker1.Value = dateTimePickerPreviousDate.AddMinutes(-15)
                Else
                    DateTimePicker1.Value = dateTimePickerPreviousDate.AddMinutes(15)
                End If

            End If

            dataTimePickerIsBusy = False

        End If

        dateTimePickerPreviousDate = DateTimePicker1.Value

    End Sub

    Private Sub parsingDateButton_Click(sender As Object, e As EventArgs) Handles parsingDateButton.Click

    End Sub


End Class
