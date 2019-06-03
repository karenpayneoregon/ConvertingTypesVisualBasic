# VB.NET Type conversions part 1
## Table of Contents
1. [Overview](#Overview)
2. [Conventions](#ConventionsOverview)
    1. [Naming conventions](#namingConventions)
2. [Asserting data](#Asserting1)
   1. [Strings](#Strings1)
   2. [Strings to numerics](#StringsNumerics)
   3. [Strings array to numeric array](./Pages/StringArrayConversions.md)



## Overview
Developers work with various types of data, ranging from displaying information collected from user input which is then stored in a container, reading information from various sources such as web services, native files to databases. One thing is common, at one point the data is represented as an `Object` and usually a `String`. In this article, developers will learn how to work with raw data to convert to a type suitable for tasks in Visual Studio solutions using defensive programming. In most tasks, data read or written may not be in the expected format to be stored in designated containers like databases, json, xml or another format.

Information and code samples are geared towards both novice and intermediate skill level which are demonstrated in unit test, Windows Forms and WPF projects. In some cases, there will be class projects which can be used in a Visual Studio solution by copying one of the class projects into an existing Visual Studio solution. Followed by (if needed) changing the .NET Framework version in the class project to match the .NET Framework used in an existing Visual Studio solution. The base .NET Framework used in code in this article is 4.7.2. If a Framework below 3.5 is used code presented may not work, for example `String.IsNullOrWhiteSpace` was first introduced in Framework 3.5.

Language extension methods are utilized in many operations which, in some cases, utilize LINQ or Lambda. When reviewing these methods do not get hung up on the complexity, instead, if the method(s) work simply use them. 

> The code presented should not be considered as belonging only to the platform presented in - [ASP.NET](https://dotnet.microsoft.com/apps/aspnet), [WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/) or [Windows Forms](https://docs.microsoft.com/en-us/dotnet/framework/winforms/). For example, exploring code in a WPF project may reveal a useful regular expression pattern or a unit test may lead to a method useful in a Windows Form project

## Conventions <a name="ConventionsOverview"></a>
All code presented uses the following directives, [Option Strict](https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference//statements/option-strict-statement) On, [Option Infer](https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference//statements/option-infer-statement) On. Using these directives assist with having quality code.

A common practice with novice developers or programmers who have coded in perhaps JavaScript and are not use to strong typing is shown in the code below.

```vb
Option Strict Off
Option Infer Off
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click

        Dim someInteger = CInt("Does not represent an Integer")

    End Sub
End Class
```

In the code above, the `someInteger` variable is an `Object`, not a `String` which compiles but will throw a runtime exception because there was no type checking.

In the following code sample `Option Strict On` will not compile as Visual Studio wants a type.

```vb
Option Strict On
Option Infer Off
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click

        Dim someInteger = CInt("Does not represent an Integer")

    End Sub
End Class
```
Adding the type.

```vb
Option Strict On
Option Infer Off
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click

        Dim someInteger As Integer = CInt("Does not represent an Integer")

    End Sub
End Class
```
Visual Studio will allow this code to compile even though the conversion will fail as "Does not represent an Integer" can not be represented as an `Integer`. 

Setting `Option Strict On` provides a decent base for writing quality code. Later, assertion will be taught to protect against runtime exceptions when a value can not be converted from one type to another type without any runtime exceptions.

The following code example shows the basics for testing if a `String` can be converted to an `Integer`.

```vb
Option Strict On
Option Infer On
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click

        Dim userInput As String = "Does not represent an Integer"

        If Not String.IsNullOrWhiteSpace(userInput) Then
            Dim someInteger As Integer = 0
            If Integer.TryParse(userInput, someInteger) Then
                ' converted
            Else
                ' failed to convert
            End If
        Else
            ' variable has no content
        End If
    End Sub
End Class
```

**Naming variables and controls** <a name="namingConventions"></a>

Common practice for novice developers is to provide meaningless names for variables and controls. This does not lend to easily reading code later on which leads to code that is difficult or impossible to maintain. Code presented in this article uses a simple convention, name variables and controls so that a non-developer can read your code and have an idea what variables and controls represent. For example for an input used to obtain a customer's first name, use `firstNameTextBox` rather than `TextBox1`.

```vb
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) _
        Handles Button1.Click

        Dim firstName As String = firstNameTextBox.Text

    End Sub
End Class
```
Note: In the last code example the button has a generic name, does not describe what the button is for. Naming controls and events are both important so here the button Click event has a meaningful name.
```vb
Public Class Form1
    Private Sub processCustomerInputButton_Click(sender As Object, e As EventArgs) _
        Handles processCustomerInputButton.Click

        Dim firstName As String = firstNameTextBox.Text
        Dim lastName As String = lastNameTextBox.Text

    End Sub
End Class
```
When naming variables in general, use names that make it apparent the data type. Some developers prefer a prefix e.g. for a `String` strFirstName. When defining a variable today in Visual Studio, hovering over a variable will indicate it's type so rather than strFirstName use firstName, which 99 percent of the time is a `String`. In short lose the three-character prefix, give variables meaningful names. 

Naming variables can change dependent on scope e.g. a private variable with a leading underscore quickly indicates you are working with a privately scoped variable e.g. `_firstName`, while `firstName` would be in scope of the current method. When passing arguments/parameters to a method consider a consistent naming convention.

The following code sample shows using an underscore for a Private class level variable which is set by a parameter passed in via the new constructor which is available to methods within this class.

```vb
Public Class DataOperations
    Public Sub New()

    End Sub
    Private _customerIdentifer As Integer
    ''' <summary>
    ''' Setup for working with a specific customer
    ''' </summary>
    ''' <param name="pCustomerIdentifier">Existing Customer primary key</param>
    Public Sub New(pCustomerIdentifier As Integer)
        _customerIdentifer = pCustomerIdentifier
    End Sub
End Class
```


### Strings <a name="Strings1"></a>

- [Asserting](https://github.com/karenpayneoregon/ConvertingTypesVisualBasic/blob/master/Pages/WorkingWithString.md).
- [Strings to numerics](./Pages/WorkingWithString.md)<a name="StringsNumerics"></a>

