Imports BindingData.Classes
''' <summary>
''' Demonstrates Date formatting with Binding class
''' </summary>
Public Class Form1
    Private bsPeople As BindingSource
    Private ReadOnly dataOperations As New DataOperations
    Private birthDateColumnIndex As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' load mocked data
        bsPeople = New BindingSource With {
            .DataSource = dataOperations.LoadData
        }

        BindingNavigator1.BindingSource = bsPeople
        DataGridView1.DataSource = bsPeople

        firstNameTextbox.DataBindings.Add("Text", bsPeople, "FirstName")
        lastNameTextBox.DataBindings.Add("Text", bsPeople, "LastName")

        SetupBirthDateBinding()

        ' Provides the column index to use in CellFormatting event
        birthDateColumnIndex = DataGridView1.Columns("BirthDate").Index

        firstNameTextbox.SelectionStart = firstNameTextbox.Text.Length

    End Sub
    ''' <summary>
    ''' Called from Form Load event to create a Binding object for
    ''' controlling how the BirthDate property is presented to the
    ''' user interface. This code could had been in form load, the reason
    ''' for separating this code from form load is to push focus to this
    ''' code.
    ''' </summary>
    Private Sub SetupBirthDateBinding()
        Dim binding As Binding = New Binding("Text", bsPeople, "BirthDate")
        AddHandler binding.Parse, AddressOf BindingParser
        AddHandler binding.Format, AddressOf BindingFormatting
        birthdayTextBox.DataBindings.Add(binding)
    End Sub
    ''' <summary>
    ''' Responsible for formatting the date as a long date if
    ''' the value is a valid date.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingFormatting(sender As Object, e As ConvertEventArgs)

        If Not Date.TryParse(e.Value.ToString(), Nothing) Then
            ' we have a value that can not represent a date
            Exit Sub
        End If

        e.Value = CDate(e.Value).ToLongDateString

    End Sub
    ''' <summary>
    ''' Since a Date control is not being used this event will
    ''' determine if a valid Date has been entered, if the string
    ''' entered can not represent a date reset the value.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingParser(sender As Object, e As ConvertEventArgs)

        If Not Date.TryParse(e.Value.ToString(), Nothing) Then
            MessageBox.Show("Sorry but you entered a invalid date, resetting date.")

            Dim person = dataOperations.LoadData().
                    FirstOrDefault(Function(p) p.Id = CType(bsPeople.Current, Person).Id)

            If person IsNot Nothing Then
                e.Value = person.BirthDate
            End If

        End If

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles DataGridView1.CellFormatting

        If e.ColumnIndex = BirthDateColumnIndex Then
            Dim d As Date
            If Date.TryParse(e.Value.ToString, d) Then
                e.Value = d.ToString("MM-dd-yyyy")
                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class