# String assertion

- [Basics assertion](#stringBasics1)

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

        Controls.OfType(Of TextBox).Any(Function(textBox) String.IsNullOrWhiteSpace(textBox.Text))

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
