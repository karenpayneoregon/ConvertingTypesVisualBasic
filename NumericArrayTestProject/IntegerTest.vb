Imports NumericArrayTestProject.BaseClasses
Imports NumericHelpers.LanguageExtensions

<TestClass()> Public Class IntegerTest
    Inherits TestBase
    ''' <summary>
    ''' Given a string array where some elements can be converted to 
    ''' Nullable Integer and some elements which can not be converted
    ''' validate the extension method ToNullable
    ''' </summary>
    <TestMethod>
    Public Sub StringToNullableInteger_Successful()

        Dim expected() As Integer? = {2, 6, -1}

        Dim nullableResults =
        (
            From item In StringArrayMixedTypesIntegers
            Select value = item.ToNullable(Of Integer)
            Where value.HasValue
        ).ToList()

        Assert.IsTrue(nullableResults.SequenceEqual(expected))

    End Sub
    ''' <summary>
    ''' Attempt to parse a string which can not be converted to an Integer.
    ''' No assertion requires pass ExpectedException attributive.
    ''' </summary>
    <TestMethod, ExpectedException(GetType(System.FormatException),
          "Integer.Parse expects an Integer, failed as expected.")>
    Public Sub WhatHappensWhenValueIsNotIntegerNoFormatting_Integer()
        Dim nonInteger = "A"
        Dim result = Integer.Parse(nonInteger)
    End Sub
    ''' <summary>
    ''' Proper parse operation, string value can be represented as an Integer
    ''' </summary>
    <TestMethod()>
    Public Sub ProperParseNoFormatting_Integer()
        Dim realInteger = "1"

        Dim result = Integer.Parse(realInteger)

        Assert.AreEqual(result, 1,
                        "Expected result to equal 1")
    End Sub
    ''' <summary>
    ''' Given a string array of nine elements test that
    ''' only three could be converted to of type Integer
    ''' </summary>
    <TestMethod()>
    Public Sub NotAllElementsCanBeConvertedShrinkArray_Integer()
        Dim results = stringArrayMixedTypesIntegers.ToIntegerArray()

        Dim expectedCount = 3

        Assert.AreEqual(results.Count(), expectedCount,
                        $"Expected only {expectedCount} elements could be converted")
    End Sub
    ''' <summary>
    ''' Given a string array of nine elements test that
    ''' only three could be converted to of type Integer
    ''' </summary>
    <TestMethod()>
    Public Sub NotAllElementsCanBeConvertedPreserveArray_Integer()
        Dim results = stringArrayMixedTypesIntegers.ToIntegerPreserveArray()

        Dim expectedCount = 9

        ' expected count
        Assert.AreEqual(results.Count(), expectedCount,
                        $"Expected only {expectedCount} elements could be converted")

        ' check if values are as expected
        Assert.IsTrue(integerArrayValidator.SequenceEqual(results))
    End Sub
    ''' <summary>
    ''' Given a string array with non-integer values, test obtaining
    ''' indices of non-integer values. Note the resulting array is zero base.
    ''' </summary>
    <TestMethod()>
    Public Sub GetNonIntegerValuesInMixedTypeArray()
        Dim results = stringArrayMixedTypesIntegers.GetNonIntegerIndexes()
        Dim expectedIndices = {1, 2, 4, 5, 6, 7}

        Assert.IsTrue(expectedIndices.SequenceEqual(results))
    End Sub
    ''' <summary>
    ''' Given a string array containing all valid Integers determine 
    ''' CanConvertToIntArray functions properly
    ''' </summary>
    <TestMethod()>
    Public Sub AllElementsCanBeConverted_Integer()
        Dim results = stringArrayAllIntegers.CanConvertToIntArray()

        Assert.IsTrue(results,
                      "Expected all elements to be valid Integers")
    End Sub
    ''' <summary>
    ''' Given a string array containing all valid Integers determine 
    ''' CanConvertToIntArray functions properly
    ''' </summary>
    <TestMethod()>
    Public Sub AllElementsCanNotBeConverted_Integer()
        Dim results = stringArrayMixedTypesIntegers.CanConvertToIntArray()

        Assert.IsFalse(results)
    End Sub
End Class