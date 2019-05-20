Imports System.Globalization
Imports System.Text
Imports DateAndTimeHelpers.LanguageExtensions
Imports DateTimeTestProject.BaseClasses
Imports Microsoft.VisualStudio.TestTools.UnitTesting

''' <summary>
''' When working with Date and time conversions read and understand
''' the rules laid out in the following Microsoft documentation page.
''' https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime
''' 
''' For many, the million dollar question "Conversion from String to type Date is not valid."
''' </summary>
<TestClass(), TestCategory("Dates")> Public Class DateTimeTest
    Inherits TestBase

    ''' <summary>
    ''' Demonstrates how an expected conversion may fail because
    ''' the assumption is incorrect for the expected result in the
    ''' first assertion while the second assertion is correct.
    ''' </summary>
    <TestMethod()> Public Sub SimpleConversionFromStringToDateTest()

        Dim dateValueGerman = "05.11.2019"
        Dim dateValueUS = "05/11/2019"

        '
        ' Parse will convert to current culture
        '
        Dim resultDate As Date = Date.Parse(dateValueGerman)
        Dim test1 = resultDate.ToString("MM/dd/yyyy")

        '
        ' date string will not match as result1 has / as date separator 
        '
        Assert.IsFalse(test1 = dateValueGerman)

        '
        ' This time both values match as the right date separator is there.
        '
        Assert.IsTrue(test1 = dateValueUS)


    End Sub
    <TestMethod()> Public Sub OtherParsingTest()

        Dim dateTimeString As String = "201905180956"

        Dim dt As DateTime = DateTime.ParseExact(dateTimeString, "yyyyMMddhhmm", Nothing)

        Dim expectedDateTime As DateTime = New DateTime(2019, 5, 18, 9, 56, 0)
        Assert.IsTrue(dt = expectedDateTime)

        dateTimeString = "20190518"
        dt = DateTime.ParseExact(dateTimeString, "yyyyMMdd", Nothing)
    End Sub
    ''' <summary>
    ''' Demonstrates listing known time zone names
    ''' </summary>
    <TestMethod()> Public Sub KnowTimeZoneNamesMethod()
        GetAllTimeZones().ToList().ForEach(Sub(name) Console.WriteLine(name))
    End Sub
    ''' <summary>
    ''' Not a test but instead an example of converting local date time
    ''' to another time zone.
    ''' </summary>
    <TestMethod()> Public Sub ConvertDateTimeToAnotherTimeZoneMethod()
        Dim now As Date = Date.Now

        ' write the time, the date and the time converted to UTC

        Console.WriteLine($"Now -> Time:{now} " & vbTab &
                          $" Date:{now.Date.ToShortDateString()} " & vbTab &
                          $" Converted2UTC:{now.ToUniversalTime()}")

        ' convert our dateTime to "US Eastern Standard Time"
        Dim easternStandard As Date = TimeZoneInfo.ConvertTime(
            now, TimeZoneInfo.FindSystemTimeZoneById("US Eastern Standard Time"))

        ' write the time, the date and the time converted to UTC from our converted time
        Console.WriteLine($"Now In New Zealand -> Time:{easternStandard} " &
                          $" Date:{easternStandard.Date.ToShortDateString()} " & vbTab &
                          $" Converted2UTC:{easternStandard.ToUniversalTime()}")

    End Sub
    ''' <summary>
    ''' Demonstrates converting a string to a Date by providing
    ''' three different formats as possibilities rather than one
    ''' which is useful when there are culture differences and or
    ''' formats used when reading dates from a unknown source.
    ''' </summary>
    ''' <remarks>
    ''' The following works for valid dates only, if not a valid
    ''' date a FormatException is thrown.
    ''' </remarks>
    <TestMethod()> Public Sub ExampleForDateParseExactTest()

        ' each element is represents the same date
        Dim dateArray = {"01/11/2019", "1/11/2019", "01-11-2019"}

        ' each element represents a common date format
        Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}

        ' used to test whether the date matches in the conversion. 
        Dim matchDate = New DateTime(2019, 11, 1, 0, 0, 0)
        Dim dateValue As Date

        For index As Integer = 0 To dateArray.Length - 1

            Dim value = dateArray(index)

            Date.TryParseExact(value, format,
                               DateTimeFormatInfo.InvariantInfo,
                               DateTimeStyles.None, dateValue)

            Assert.AreEqual(dateValue, matchDate)
        Next

    End Sub
    ''' <summary>
    ''' Same test as above using a language extension method.
    ''' </summary>
    <TestMethod()> Public Sub ExampleForDateParseExactWithExtensionMethodTest()

        ' each element is represents the same date
        Dim dateArray = {"01/11/2019", "1/11/2019", "01-11-2019"}

        Dim dateValue As Date
        Dim matchDate = New DateTime(2019, 11, 1, 0, 0, 0)

        For index As Integer = 0 To dateArray.Length - 1
            dateValue = dateArray(index).ToDate
            Assert.AreEqual(dateValue, matchDate)
        Next

    End Sub
    ''' <summary>
    ''' Demonstrates converting string values to date time using specific
    ''' formatting.  In this case test data is from Germany, USA, Spanish.
    ''' </summary>
    <TestMethod()> Public Sub ExampleForDateParseExactWithWordsTest()

        Dim dictValues As New Dictionary(Of String, CultureInfo) From {
                    {"12 Mai 2019", New CultureInfo("de-DE")},
                    {"12 May 2019", New CultureInfo("en-US")},
                    {"12 mayo 2019", New CultureInfo("es-MX")}
                }

        Dim matchDate = New DateTime(2019, 5, 12, 0, 0, 0)

        For Each kvp In dictValues
            Dim dateResultValue As Date = Date.Parse(kvp.Key, kvp.Value)
            Assert.AreEqual(dateResultValue, matchDate)
        Next

    End Sub
    ''' <summary>
    ''' Given a date array for the current culture create a string array
    ''' to another culture.
    ''' </summary>
    <TestMethod()> Public Sub ConvertingDateCurrentCultureToAnotherCultureAsStringTest()

        Dim germanCulture = "de-DE"

        Dim dates = Enumerable.Range(1, 10).
                Select(Function(value) New Date(Now.Year, Now.Month, value)).ToArray()

        Dim expected =
                {
                    "05.01.2019", "05.02.2019", "05.03.2019", "05.04.2019",
                    "05.05.2019", "05.06.2019", "05.07.2019", "05.08.2019",
                    "05.09.2019", "05.10.2019"
                }

        Dim results = dates.Select(
            Function(value)
                Return value.ToString("MM/dd/yyyy", CultureInfo.CreateSpecificCulture(germanCulture))
            End Function).ToArray()

        Assert.IsTrue(results.SequenceEqual(expected))

    End Sub
    ''' <summary>
    ''' Given a string array in another culture convert to current culture
    ''' using the date format for the dates in the string array, if the format
    ''' is not correct ParseExact will throw an exception so the developer needs
    ''' to know what the culture is, in this case in the string array.
    ''' </summary>
    <TestMethod()> Public Sub ConvertingStringFromOneCultureToAnotherAsDateTest()

        Dim dateFormat = "MM.dd.yyyy"

        Dim stringDateArray =
                {
                    "05.01.2019", "05.02.2019", "05.03.2019", "05.04.2019",
                    "05.05.2019", "05.06.2019", "05.07.2019", "05.08.2019",
                    "05.09.2019", "05.10.2019"
                }

        Dim expectedResults =
                {
                    #05/01/2019#, #05/02/2019#, #05/03/2019#, #05/04/2019#,
                    #05/05/2019#, #05/06/2019#, #05/07/2019#, #05/08/2019#,
                    #05/09/2019#, #05/10/2019#
                }


        Dim resultDateArray(9) As Date

        For index As Integer = 0 To stringDateArray.Length - 1
            resultDateArray(index) = Date.ParseExact(stringDateArray(index), dateFormat, Nothing)
        Next

        Assert.IsTrue(resultDateArray.SequenceEqual(expectedResults))

    End Sub
    ''' <summary>
    ''' Using the same requirements of test above read dates from a text file.
    ''' </summary>
    <TestMethod()> Public Sub ConvertingFromFileStringFromOneCultureToAnotherAsDateTest()

        Dim expectedResults =
                {
                    #05/01/2019#, #05/02/2019#, #05/03/2019#, #05/04/2019#, #05/05/2019#
                }

        Dim resultDates = GetEventDates().Select(Function(item) item.DateOf).ToArray()

        Assert.IsTrue(expectedResults.SequenceEqual(resultDates))

    End Sub
End Class