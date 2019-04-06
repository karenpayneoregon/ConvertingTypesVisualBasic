Imports ParsingStringWindowsForms.Classes

Public Class Form1
    Private bsCustomers As BindingSource
    ''' <summary>
    ''' Setup DataGridView with a DataSource as a list of customer
    ''' set to the BindingSource.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bsCustomers = New BindingSource With {
            .DataSource = New List(Of Customer)
        }

        ' DataGridView columns have been set in the designer for the DataGridView
        DataGridView1.AutoGenerateColumns = False

        ' Set the DataSource to an empty list of customer
        DataGridView1.DataSource = bsCustomers
    End Sub

    Private Sub addNewCustomerButton_Click(sender As Object, e As EventArgs) _
        Handles addNewCustomerButton.Click

        ' Create the add new customer for
        Dim addForm = New NewCustomerForm

        ' determine if the customer is to be add by passing validation and 
        ' not canceled in the add new customer form.
        If addForm.ShowDialog() = DialogResult.OK Then
            bsCustomers.Add(addForm.Customer)
        Else
            MessageBox.Show("Add canceled, this message is not needed in a product application")
        End If
    End Sub
End Class