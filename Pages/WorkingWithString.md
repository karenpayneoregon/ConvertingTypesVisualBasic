# String assertion

- [Basics assertion](#stringBasics1)
- [String to numerics](#stringToNumerics)

[Back to main page](../readme.md)

### Basics assertion <a name="stringBasics1"></a>
Anytime required input is required for instance to create an object always assume one or more inputs do not have values. For instance, adding a new customer which requires first and last name along with an email address using TextBox controls for input and a button to create the new customer.

First attempt which asserts each TextBox, if even one is empty the requirement for all inputs to be entered has not been meant.
```csharp
Public Class Form1
    Private Sub addCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles addCustomerButton.Click

        If String.IsNullOrWhiteSpace(firstNameTextBox.Text) OrElse
           String.IsNullOrWhiteSpace(lastNameTextBox.Text) OrElse
           String.IsNullOrWhiteSpace(personalEmailAddressTextBox.Text) Then

            MessageBox.Show("All fields are required")

        Else

            Dim customer As New Customer With
                {
                    .FirstName = firstNameTextBox.Text,
                    .LastName = lastNameTextBox.Text,
                    .EmailAddress = personalEmailAddressTextBox.Text
                }

        End If
    End Sub
End Class
```

Second attempt validates all inputs (TextBox controls) are populated using [Enumerable.Any method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2). Which works well when all inputs are required.

```csharp
Public Class Form1
    Private Sub addCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles addCustomerButton.Click

        If Controls.OfType(Of TextBox).Any(Function(textBox) String.IsNullOrWhiteSpace(textBox.Text)) Then

            MessageBox.Show("All fields are required")

        Else

            Dim customer As New Customer With
                {
                    .FirstName = firstNameTextBox.Text,
                    .LastName = lastNameTextBox.Text,
                    .EmailAddress = personalEmailAddressTextBox.Text
                }

        End If
    End Sub
End Class
``````
Third attempt, using control validation. In the code sample below
[Control.Validated event](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.validated?view=netframework-4.7.2) is used along 
with [ContainerControl.ValidateChildren](http://example.com) Method to cause in this case the firstNameTextBox to perform validation.

For a complete working example is [the following project](http://example.com) in this repository.

```csharp
Public Class Form1
    Private Sub addCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles addCustomerButton.Click

        If ValidateChildren() Then
            MessageBox.Show("Go to go")
        End If

    End Sub

    Private Sub firstNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles firstNameTextBox.Validating

        If String.IsNullOrWhiteSpace(firstNameTextBox.Text) Then
            ErrorProvider1.SetError(firstNameTextBox, "first name is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(firstNameTextBox, "")
            e.Cancel = False
        End If

    End Sub

End Class
```
---
### String to numerics <a name="stringToNumerics"></a>

Once a required string has been established to have content usually the value will be stored as a string or converted to another type. In the following WPF window there are three TextBox controls.

![Screen](../Images/WPF_StringToIntegerExamples.jpg)

The first TextBox assertion is done by setting up an event for [PreviewTextInput](https://docs.microsoft.com/en-us/dotnet/api/system.windows.uielement.previewtextinput?view=netframework-4.7.2). In the code behind
a Regular Expression is used to determine if the text entered can be represented as an Integer.

```csharp
Private Shared ReadOnly _regex As New Regex("[^0-9.-]+")
Private Shared Function IsTextAllowed(ByVal text As String) As Boolean
    Return _regex.IsMatch(text)
End Function
''' <summary>
''' Used to prevent information entered to be non-integer values
''' </summary>
''' <param name="sender"></param>
''' <param name="e"></param>
Private Sub AssertIntegerTextBox_OnPreviewTextInput(
    sender As Object,
    e As TextCompositionEventArgs)

    e.Handled = _regex.IsMatch(e.Text)

End Sub
```
There is still a need to determine if there has been a value entered which in this case is done using [String.IsNullOrWhiteSpace](https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=netframework-4.7.2) as in examples done above.

```csharp
Private Sub IntegerOnlyTextBox_OnClick(
    sender As Object,
    e As RoutedEventArgs)

    If String.IsNullOrWhiteSpace(assertIntegerTextBox.Text) Then
        MessageBox.Show("No value")
    Else
        MessageBox.Show($"Value is {assertIntegerTextBox.Text}")
    End If

End Sub
```
In the middle TextBox control a conversion is performed without checking to see if the value can be represented as an Integer. Novice developers tend to do this at least once without a try/catch.
Then not knowing any better will not only surround this code with a try/catch they will have an empty catch. About the only time it is okay to have an empty catch is when traversing a folder structure were the operator does not have permissions to one or more folders.

In the bottom TextBox a decimal has been entered were an Integer was expected. An option is to use [Decimal.TryParse](https://docs.microsoft.com/en-us/dotnet/api/system.decimal.truncate?view=netframework-4.7.2), use Decimal.Truncate to get the Integer value 
which may be okay in some task while others this may not be okay dependent on business requirements along with operator thinking what happen to the decimal entered?

```csharp
Private Sub tryParseAssertionButton_Click(
    sender As Object,
    e As RoutedEventArgs) Handles tryParseAssertionButton.Click

    If Not String.IsNullOrWhiteSpace(tryparseIntegerTextBox.Text) Then

        Dim value As Integer = 0

        If Integer.TryParse(tryparseIntegerTextBox.Text, value) Then
            MessageBox.Show($"You entered a valid integer: {value}")
        Else
            MessageBox.Show($"'{tryparseIntegerTextBox.Text}' could not be converted to an integer")
        End If

    Else
        MessageBox.Show("Please enter a value")
    End If

End Sub
``````

In a Windows Form project one method to assert that a input in a TextBox is an Integer is using [KeyPress event](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.keypress?view=netframework-4.7.2) of the TextBox.

```csharp
Private Sub AssertionOnInteger_KeyPressForOnlyIntegers(
    sender As Object,
    e As KeyPressEventArgs) _
    Handles keyPressAssertionOnIntegerTextBox.KeyPress

    '97 - 122 = Ascii codes for simple letters
    '65 - 90  = Ascii codes for capital letters
    '48 - 57  = Ascii codes for numbers

    If Asc(e.KeyChar) <> 8 Then
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
        End If
    End If

End Sub
```
> Note there are other ways to perform assertion on string and converting to numbers using custom validator components and by implementing a component with [IExtenderProvider Interface](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.iextenderprovider?view=netframework-4.7.2).
---
