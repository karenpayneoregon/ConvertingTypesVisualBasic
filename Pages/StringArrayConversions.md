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

#### Assertion
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
#### Safely converting from String array to Integer array

There are two paths to take when converting a String array to an Integer array, perserve all elements by setting elements which can not be converted to Integer to a default value such as 0 while the other path is to create an Integer array with only the values which can be converted to Integers.

##### preserve all elements
The first path, preserve all elements where non-integer values will have a default value, in this case 0.

Rather than creating a function this will be done with a function setup as a language extension method. This is done by creating a code module as shown below.

```csharp
Public Module IntegerArrayExtensions
    <Runtime.CompilerServices.Extension>
    Public Function ToIntegerPreserveArray(sender() As String) As Integer()
        Return Array.ConvertAll(sender,
                Function(input)
                    Dim integerValue As Integer
                    Integer.TryParse(input, integerValue)
                    Return integerValue
                End Function)
    End Function
End Module
```
The magic happens using [Array.ConvertAll](https://docs.microsoft.com/en-us/dotnet/api/system.array.convertall?view=netframework-4.7.2), first parameter is the String array, second parameter is a function which uses [Integer.TryParse](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=netframework-4.7.2) where if an element can be converted the variable integerValue will contain the Integer value while on failure to convert a String element to Integer 0 is returned.

The follow code sample provides a string array with some elements which can not be converted to Integer values.

```csharp
Public Class Form1
    Private Sub exampleButton_Click(sender As Object, e As EventArgs) _
        Handles exampleButton.Click

        Dim stringArray As String() =
                {
                    "2",
                    "4B",
                    Nothing,
                    "6",
                    "8A",
                    "",
                    "1.3",
                    "Karen",
                    "-1"
                }
        Dim integerArray = stringArray.ToIntegerPreserveArray()

        For index As Integer = 0 To stringArray.Length - 1
            Console.WriteLine(
                $"Index: {index} String value: " &
                $"'{stringArray(index)}' Converted too: {integerArray(index)}")
        Next

    End Sub
End Class
```
The results show the index, original string value and the converted value.
<pre>
Index: 0 String value: '2' Converted too: 2
Index: 1 String value: '4B' Converted too: 0
Index: 2 String value: '' Converted too: 0
Index: 3 String value: '6' Converted too: 6
Index: 4 String value: '8A' Converted too: 0
Index: 5 String value: '' Converted too: 0
Index: 6 String value: '1.3' Converted too: 0
Index: 7 String value: 'Karen' Converted too: 0
Index: 8 String value: '-1' Converted too: -1
</pre>

Taking a slightly different path on obtaining output which has nothing to do with the conversion process but shows how developers can use chaining of statements together as done in ToIntegerPreserveArray.

```csharp
Dim integerArray = stringArray.ToIntegerPreserveArray()

integerArray.
	ToList().
	Select(Function(number, index) New With
		{
			.Index = index,
			.Value = number
		}).ToList().
	ForEach(Sub(data)
		Console.WriteLine(
			$"Index: {data.Index} " &
			$"Integer Value: {data.Value,2} " &
			$"Original Value: '{stringArray(data.Index)}'")
			End Sub)
```

Breaking down the code for displaying information on the converted array.

1. Use ToList extension method to gain access to Select extension method.
2. Using a function in the Select method use two parameters, the first parameter represents an Integer of a element in IntegerArray while the second parameter is the index of the element in the array.
3. Within this function create an anonymous type, .Index represents the element index in the array while .Value represents the element which is an Integer.
4. Using the language extension .ForEach iterate the anonymous type created in the function and display the same information shown in the prior code sample.

##### Shrink array to only true Integer values

In the prior example the resulting Integer array will be the exact size as the String array. In this section if a string element can not be converted to an Integer value those elements are discarded.

>TODO

##### determine indexes which do not represent Integers
>TODO

**Work in Progress**

[Back to main page](../readme.md)