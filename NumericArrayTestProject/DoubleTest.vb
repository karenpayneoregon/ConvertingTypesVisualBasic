Imports NumericArrayTestProject.BaseClasses
Imports NumericHelpers.LanguageExtensions

<TestClass(), TestCategory("Numeric - Double")> Public Class DoubleTest
    Inherits TestBase

    ''' <summary>
    ''' Attempt to parse a string which can not be converted to an Double.
    ''' No assertion requires pass ExpectedException attributive.
    ''' </summary>
    <TestMethod, ExpectedException(GetType(System.FormatException),
          "Double.Parse expects an Integer, failed as expected.")>
    Public Sub WhatHappensWhenValueIsNotDoubleNoFormatting_Double()
        Dim nonInteger = "A"
        Dim result = Double.Parse(nonInteger)
    End Sub
    ''' <summary>
    ''' Proper parse operation, string value can be represented as an Double
    ''' </summary>
    <TestMethod()>
    Public Sub ProperParseNoFormatting_Double()
        Dim realDouble = "1.89"
        Dim expected = 1.89

        Dim result = Double.Parse(realDouble)

        Assert.AreEqual(result, expected,
                        $"Expected result to equal {expected}")
    End Sub
    ''' <summary>
    ''' Given a string array of nine elements test that
    ''' only three could be converted to of type Double
    ''' </summary>
    <TestMethod()>
    Public Sub NotAllElementsCanBeConvertedShrinkArray_Double()
        Dim results = stringArrayMixedTypesDouble.ToDoubleArray()

        Dim expectedCount = 4

        Assert.AreEqual(results.Count(), expectedCount,
                        $"Expected only {expectedCount} elements could be converted")
    End Sub
    ''' <summary>
    ''' Given a string array of nine elements test that
    ''' only three could be converted to of type Double
    ''' </summary>
    <TestMethod()>
    Public Sub NotAllElementsCanBeConvertedPreserveArray_Double()
        Dim results = stringArrayMixedTypesDouble.ToDoublePreserveArray()

        Dim expectedCount = 9

        ' expected count
        Assert.AreEqual(results.Count(), expectedCount,
                        $"Expected only {expectedCount} elements could be converted")


        ' check if values are as expected
        Assert.IsTrue(DoubleArrayValidator.SequenceEqual(results))
    End Sub
    ''' <summary>
    ''' Test converting from string array of currency values to
    ''' a pure double array discarding values which can not be 
    ''' converted.
    ''' </summary>
    <TestMethod()>
    Public Sub CurrencyStringArrayToDoubleArray()
        Dim expected = {2.4, 6.9, 1.3, 1}
        Dim results = StringArrayCurrencyDouble.FromCurrencyToDoubleArray()

        Assert.IsTrue(expected.SequenceEqual(results))
    End Sub
    ''' <summary>
    ''' Given a string array with non-Double values, test obtaining
    ''' indices of non-Double values. Note the resulting array is zero base.
    ''' </summary>
    <TestMethod()>
    Public Sub GetNonDoubleValuesInMixedTypeArray()
        Dim results = StringArrayMixedTypesDouble.GetNonDoubleIndexes()
        Dim expectedIndices = {1, 2, 4, 5, 7}

        Assert.IsTrue(expectedIndices.SequenceEqual(results))
    End Sub
    ''' <summary>
    ''' Given a string array containing all valid Doubles determine 
    ''' CanConvertToDoubleArray functions properly
    ''' </summary>
    <TestMethod()>
    Public Sub AllElementsCanBeConverted_Double()
        Dim results = StringArrayAllDoubles.CanConvertToDoubleArray()

        Assert.IsTrue(results,
                      "Expected all elements to be valid Integers")
    End Sub
    ''' <summary>
    ''' Given a string array containing all valid Doubles determine 
    ''' CanConvertToDoubleArray functions properly
    ''' </summary>
    <TestMethod()>
    Public Sub AllElementsCanNotBeConverted_Double()
        Dim results = StringArrayMixedTypesIntegers.CanConvertToDoubleArray()

        Assert.IsFalse(results)
    End Sub
End Class