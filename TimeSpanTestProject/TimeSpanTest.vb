Imports System.Text
Imports DateAndTimeHelpers.LanguageExtensions
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports TimeSpanTestProject.TestClasses

<TestClass()> Public Class TimeSpanTest
    Inherits TestBase

    ''' <summary>
    ''' Given a string array with both valid and invalid string elements for converting
    ''' to a TimeSpan this test validates that they all can not be converted.
    ''' </summary>
    <TestMethod()> Public Sub ValidateNotAllStringElementsCanBeConvertToTimeSpanTest()
        Assert.IsFalse(StringArrayForConvertingToTimeSpan.CanConvertToTimeSpanArray())
    End Sub
    ''' <summary>
    ''' Given a string array of 24 elements that only 16 elements can be converted validate
    ''' that only 16 elements can be converted by returning only 16 elements.
    ''' </summary>
    <TestMethod()> Public Sub ConvertOnlyValidTimeSpanArrayElementsTest()
        Dim test = StringArrayForConvertingToTimeSpan.ToTimeSpanArray()
        Assert.IsTrue(test.Length = 16)
    End Sub
    ''' <summary>
    ''' Given an array of 24 element ToTimeSpanPreserveArray will
    ''' return all 24 elements were those elements are not valid as TimeSpan
    ''' will return the default of 00:00:00
    ''' </summary>
    <TestMethod()> Public Sub PreserveTimeSpanArrayElementsTest()
        Dim test = StringArrayForConvertingToTimeSpan.ToTimeSpanPreserveArray()
        Assert.IsTrue(test.Length = 24)
        Console.WriteLine(test.TimeSpanArrayToString)
    End Sub
End Class