# How To: Type conversions in VB.NET
Developers will always have a need to convert from one type to another type such as String to Date, String to Integer/Double/Decimal along with converting collections from one type to another.

**Note** This repository should be seen as an evolving code repository.




---

## Overview
There are solutions in this repository to common conversions broken down into [class projects](https://docs.microsoft.com/en-us/visualstudio/get-started/tutorial-projects-solutions?view=vs-2017) which by adding to a Visual Studio solution allow developers to have these solutions available without the need to remember how to do this or that conversion.

> These conversions are not limited to [ASP.NET](https://dotnet.microsoft.com/apps/aspnet), [WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/) or [Windows Forms](https://docs.microsoft.com/en-us/dotnet/framework/winforms/).

For novice developers, there will be conversions such as the example below that work for intended needs but not easy to understand. This should not cause avoidance, think of these no different than methods found in the .NET Framework, you don't have the source code which in many cases is more complex than the example below yet still use them. The complex methods should be seen the same way.

###### code sample description

Given a String array which needs to be converted to an Integer array there may be times when not all elements in the String array can be converted. Using conventional methods can be cumbersome while this one is not, if one or more elements can not be converted the result is an array of the elements which were converted. What about "which elements which could not be converted", there is an extension method for this and also an extension method which provides the indexes to the elements which could not be converted.

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
There are examples showing usage of the following, which is right for the task at hand.
```csharp
Public Sub Demo(pValue As String)
    Dim IntegerValue = 0

    If Integer.TryParse(pValue, IntegerValue) Then
        '
    Else
        '
    End If

    IntegerValue = System.Convert.ToInt32(pValue)

    IntegerValue = Integer.Parse(pValue)

End Sub
```


---
## Limitations
The majority of methods and language extensions depend 4x and higher .NET Framework. In some cases this can be resolved using methods and/or language extension methods to overcome this.

For example, .NET Framework does not have String.IsNullOrWhiteSpace. This can overcomed by writing a wrapper function implemented as a language extension method as shown below.

```csharp
Public Module StringExtensionMethods
    <Runtime.CompilerServices.Extension>
    Public Function IsNullOrWhiteSpace(value As String) As Boolean
        Return (value Is Nothing) OrElse String.IsNullOrEmpty(value.Trim())
    End Function
End Module
```
---
#### Unit Test

---

## Conversions
#### String to Numeric

#### String to Date

#### Data Readers

#### Entity Framework

---
### Requirements

- [Microsoft Visual Studio](http://example.com) targetting Framework 4x and higher

---


## Compile recommendations

All code presented in this repository have been done using [Option Strict On](https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/statements/option-strict-statement) and [Option Infer On](https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/statements/option-infer-statement).

Best practice is to compile with Option Strict On while Option Infer On is a personal choice. Using Option Infer On provide syntax similar to C#.
