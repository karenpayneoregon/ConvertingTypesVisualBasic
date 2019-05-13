Imports BindingData.Classes
''' <summary>
''' Demonstrates Date formatting with Binding class
''' </summary>
Public Class Form1
    Private bsPeople As BindingSource
    Private ops As New DataOperations
    Private BirthDateColumnIndex As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        bsPeople = New BindingSource With {
            .DataSource = ops.LoadData
        }

        BindingNavigator1.BindingSource = bsPeople
        DataGridView1.DataSource = bsPeople

        Dim binding As Binding = New Binding("Text", bsPeople, "BirthDate")

        AddHandler binding.Parse, AddressOf BindingParser
        AddHandler binding.Format, AddressOf BindingFormatting

        birthdayTextBox.DataBindings.Add(binding)
        BirthDateColumnIndex = DataGridView1.Columns("BirthDate").Index
    End Sub

    Private Sub BindingFormatting(sender As Object, e As ConvertEventArgs)

        If Not Date.TryParse(e.Value.ToString(), Nothing) Then
            ' we have a value that can not represent a date
            Exit Sub
        End If

        e.Value = CDate(e.Value).ToLongDateString

    End Sub

    Private Sub BindingParser(sender As Object, e As ConvertEventArgs)

        If Not Date.TryParse(e.Value.ToString(), Nothing) Then
            MessageBox.Show("Sorry but you entered a invalid date, resetting date.")

            Dim person = ops.LoadData().
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