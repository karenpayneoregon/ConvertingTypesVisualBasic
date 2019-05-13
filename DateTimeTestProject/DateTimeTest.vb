Imports System.Globalization
Imports System.Text
Imports DateAndTimeHelpers.LanguageExtensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

''' <summary>
''' When working with Date and time conversions read and understand
''' the rules laid out in the following Microsoft documentation page.
''' https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime
''' 
''' For many, the million dollar question "Conversion from String to type Date is not valid."
''' </summary>
<TestClass()> Public Class DateTimeTest
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
    <TestMethod()> Public Sub TestMethod1()

    End Sub
End Class