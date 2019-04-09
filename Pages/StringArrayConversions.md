# String array to numeric array

Working with arrays can prove challenging when first starting out having to convert a string array which should contain only Integer, Decimal or Double values in each element of an array. A common practice is to use code shown below.

```csharp
Dim stringArray = {"123", "456", "789"}
Dim intList = stringArray.
        ToList().
        ConvertAll(Function(stringValue) Integer.Parse(stringValue))
```
Which will convert each element in the string array by first accessing th
e array using .ToList then using [ConvertAll](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.convertall?view=netframework-4.7.2) to 
parse using [Integer.Parse](http://example.com) each element into an Integer.

Since each element can represent Integers the conversion is successful. If an element can not be converted a runtime exception is thrown. In the following code sample one element can not be converted because there is a space in between two numbers in the middle element.

```csharp
Dim stringArray = {"123", "45 6", "789"}
Dim intList = stringArray.
        ToList().
        ConvertAll(Function(stringValue) Integer.Parse(stringValue))
```

Anytime there is a possible chance something is not as expected, in this case if one or more elements can not be converted this is were assertion comes in.

In the following example rather than using Integer.Parse Integer.TryParse is used where if a element can not be converted [Integer.TryParse](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.7.2) returns False. Also note TryParse can be used in other numeric types along with DateTime.

[Enumerable.All](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all?view=netframework-4.7.2) determines whether all elements of a sequence satisfy a condition. In this case all string values can be converted to Integer. If one or more can not be converted then All returns False.


```csharp
Dim testValue As Integer
Dim stringArray = {"123", "45 6", "789"}

If stringArray.All(Function(input) Integer.TryParse(input, testValue)) Then
    Console.WriteLine("Safe to perform conversion")
Else
    Console.WriteLine("Not safe to perform conversion")
End If
```
If this type of assertion is needed often a function can be created and placed in a common code module.

```csharp
Public Module ArrayHelpers
    Public Function CanConvertToIntegerArray(sender() As String) As Boolean
        Dim testValue As Integer
        Return sender.All(Function(input) Integer.TryParse(input, testValue))
    End Function
End Module
```

Working example

```csharp
Dim stringArray = {"123", "45 6", "789"}

If CanConvertToIntegerArray(stringArray) Then
    Console.WriteLine("Safe to perform conversion")
Else
    Console.WriteLine("Not safe to perform conversion")
End If
```

The function could also be written as a Language Extension

```csharp
Public Module ArrayHelpers
    <Runtime.CompilerServices.Extension>
    Public Function CanConvertToIntArray(sender() As String) As Boolean
        Dim testValue As Integer
        Return sender.All(Function(input) Integer.TryParse(input, testValue))
    End Function
End Module
```

Then used as shown here.

```csharp
Dim stringArray = {"123", "45 6", "789"}

If stringArray.CanConvertToIntArray() Then
    Console.WriteLine("Safe to perform conversion")
Else
    Console.WriteLine("Not safe to perform conversion")
End If
```

Since Integer is not the only type that may be in an array language extensions can be created for all other numeric types a developer may work with, example, Decimal.

```csharp
Public Module ArrayHelpers
    <Runtime.CompilerServices.Extension>
    Public Function CanConvertToDecimalArray(sender() As String) As Boolean
        Dim testValue As Decimal
        Return sender.All(Function(input) Decimal.TryParse(input, testValue))
    End Function
End Module
```

**Work in Progress**

[Back to main page](../readme.md)