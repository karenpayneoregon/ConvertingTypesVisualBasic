# String array to numeric array

> In this section conversion from string array to Integer arrays are discussed, in the repository there are mirror method for Long, Decimal and Double in [NumericHelpers project](https://github.com/karenpayneoregon/ConvertingTypesVisualBasic/tree/master/NumericHelpers/LanguageExtensions).
> 
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

##### Preserve all elements
The first path, preserve all elements where non-integer values will have a 
default value, in this case 0.

Rather than creating a function this will be done with a function setup as a 
language extension method. This is done by creating a code module as shown below.

[ToIntegerPreserveArray()](https://github.com/karenpayneoregon/ConvertingTypesVisualBasic/blob/master/NumericHelpers/LanguageExtensions/IntegerArrayExtensions.vb#L59)

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

Consider reading a String array which has elements which are not Integer type and are consistant e.g. reading lines from a file.

<pre>
1,Karen,Payne,1956
2,Bob,Jones,1977
3,Mary,Adams,1984
</pre>

The task is to obtain the first element and the last element. In the code sample below the program reads a file named TextFile1.txt which resides in the same folder as the program's executable with the content shown above.

Using File.ReadAllLines which returns a string array of lines in the file where each item to read is delimited by a comma.

With a For-Each on each iteration a extension method, ToStringArray converts the string representing a line in the string array to a string array. This is followed by invoking ToIntegerArray which will return only integer values.

```csharp
Public Class Form2
    Private Sub exampleButton_Click(sender As Object, e As EventArgs) _
        Handles exampleButton.Click

        Dim fileName = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "TextFile1.txt")

        Dim linesFromFile = File.ReadAllLines(fileName)

        For Each line As String In linesFromFile
            Dim items = line.ToStringArray().ToIntegerArray
            Console.WriteLine($"Id: {items(0)}, Birth Year {items(1)}")
        Next
    End Sub
End Class
```
Here is the definition for ToStringArray which is a simple function which by default accepts a string which is split into a string array delimited by a comma which is defined as Optional meaning if the string is delimited by a comma the parameter need not be passed while if the string is delimited by another delimitor other than a comma the delimitor needs to be passed.

```csharp
<Runtime.CompilerServices.Extension>
Public Function ToStringArray(
    sender As String,
    Optional separator As Char = ","c) As String()

    Return sender.Split(separator)
End Function
```

Moving on to the language extension [ToIntegerArray](https://github.com/karenpayneoregon/ConvertingTypesVisualBasic/blob/master/NumericHelpers/LanguageExtensions/IntegerArrayExtensions.vb#L37), to determine if an element can represent an Integer Integer.TryParse checks if the string can be converted when creating an instance of an anonymous type, .IsInteger stored the result of Integer.TryParse while .Value contains the result, if "Amy" is parsed .Value will contain 0 and .IsInteger will be False while a value of 12 will set .Value to 12 and .IsInteger to True.

In turn .Where condition specifies .IsInteger = True which in turn using .Select returns only Integer values.

```csharp
<Runtime.CompilerServices.Extension>
Public Function ToIntegerArray(sender() As String) As Integer()
	Return Array.ConvertAll(sender,
	Function(input)
		Dim value As Integer
		Return New With
		{
			.IsInteger = Integer.TryParse(input, value),
			.Value = value
		}
	End Function).
	Where(Function(result) result.IsInteger).
	Select(Function(result) result.Value).
	ToArray()
End Function
```

##### Determine indexes which do not represent Integers

The following is an inversion of the above where the condition was .IsInteger = True this method 
does .IsInteger = False along with asking for the index rather than the actual value using [GetNonIntegerIndexes](https://github.com/karenpayneoregon/ConvertingTypesVisualBasic/blob/master/NumericHelpers/LanguageExtensions/IntegerArrayExtensions.vb#L78).

```csharp
<Runtime.CompilerServices.Extension>
Public Function GetNonIntegerIndexes(sender() As String) As Integer()
	Return sender.Select(
	Function(item, index)

		Dim integerValue As Integer
		Return If(Integer.TryParse(item, integerValue),
			New With
				{
				    .IsInteger = True,
				    .Index = index
				},
			New With
				{
				    .IsInteger = False,
				    .Index = index
				}
			)
	End Function).
	ToArray().
	Where(Function(item) item.IsInteger = False).
	Select(Function(item) item.Index).
	ToArray()

End Function
```
Code sample which rather than obtaining values for the first and last element will return the 
two middle elements which are first and last name indexes.

```csharp
Public Class Form2
    Private Sub exampleButton_Click(sender As Object, e As EventArgs) _
        Handles exampleButton.Click

        Dim fileName = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "TextFile1.txt")

        Dim linesFromFile = File.ReadAllLines(fileName)

        For Each line As String In linesFromFile
            Dim items = line.ToStringArray().GetNonIntegerIndexes
            Console.WriteLine($"First name: {items(0)}, Last name {items(1)}")
        Next
    End Sub
End Class
```



[Back to main page](../readme.md)