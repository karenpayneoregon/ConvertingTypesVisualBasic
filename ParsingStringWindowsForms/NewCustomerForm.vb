Imports System.ComponentModel
Imports ParsingStringWindowsForms.Classes

Public Class NewCustomerForm
    Public Property Customer() As Customer
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ' Without this set the user must enter information from top to 
        ' bottom control wise.
        AutoValidate = AutoValidate.EnableAllowFocusChange

        Dim ops = New UnitedStates
        Dim states = ops.AmericaStates()

        If ops.IsSuccessful Then
            stateComboBox.DataSource = states
        End If

    End Sub
    Private Sub companyNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles companyNameTextBox.Validating

        If String.IsNullOrWhiteSpace(companyNameTextBox.Text) Then
            ErrorProvider1.SetError(companyNameTextBox, "Company name is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(companyNameTextBox, "")
            e.Cancel = False
        End If

    End Sub
    ''' <summary>
    ''' Validate a street was entered
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub streetTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles streetTextBox.Validating

        If String.IsNullOrWhiteSpace(streetTextBox.Text) Then
            ErrorProvider1.SetError(streetTextBox, "street is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(streetTextBox, "")
            e.Cancel = False
        End If

    End Sub
    Private Sub CityTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles CityTextBox.Validating

        If String.IsNullOrWhiteSpace(CityTextBox.Text) Then
            ErrorProvider1.SetError(CityTextBox, "City is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(CityTextBox, "")
            e.Cancel = False
        End If

    End Sub
    ''' <summary>
    ''' Determine if a state has been selected. In this case the first item
    ''' is "Select" to prompt for a state
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub stateComboBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles stateComboBox.Validating

        If stateComboBox.SelectedIndex = 0 Then
            ErrorProvider1.SetError(stateComboBox, "State is required")
            e.Cancel = True
        Else
            ErrorProvider1.SetError(stateComboBox, "")
            e.Cancel = False
        End If

    End Sub
    ''' <summary>
    ''' Pressing add indicates a new customer will be added if validation passes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddCustomerButton_Click(sender As Object, e As EventArgs) Handles AddCustomerButton.Click
        If ValidateChildren() Then
            CreateCustomer()
            DialogResult = DialogResult.OK
        Else
            If My.Dialogs.Question("One or more required fields are required, Lose changes?") Then
                Close()
            End If
        End If

    End Sub
    Private Sub CreateCustomer()
        Customer = New Customer() With
            {
                .CompanyName = companyNameTextBox.Text,
                .Street = streetTextBox.Text,
                .City = CityTextBox.Text,
                .StateCode = CType(stateComboBox.SelectedItem, State).Code,
                .Active = activeCheckBox.Checked
            }
    End Sub
    ''' <summary>
    ''' CausesValidation must be set to False, otherwise the
    ''' validation in place will prevent closure of this form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        CausesValidation = False
        Close()
    End Sub
End Class
