<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.addNewCustomerButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StreetColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'addNewCustomerButton
        '
        Me.addNewCustomerButton.Location = New System.Drawing.Point(12, 14)
        Me.addNewCustomerButton.Name = "addNewCustomerButton"
        Me.addNewCustomerButton.Size = New System.Drawing.Size(75, 23)
        Me.addNewCustomerButton.TabIndex = 0
        Me.addNewCustomerButton.Text = "Add new customer"
        Me.addNewCustomerButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.addNewCustomerButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 182)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 49)
        Me.Panel1.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyNameColumn, Me.StreetColumn, Me.CityColumn, Me.StateColumn, Me.ActiveColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(584, 182)
        Me.DataGridView1.TabIndex = 2
        '
        'CompanyNameColumn
        '
        Me.CompanyNameColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameColumn.HeaderText = "Company"
        Me.CompanyNameColumn.Name = "CompanyNameColumn"
        '
        'StreetColumn
        '
        Me.StreetColumn.DataPropertyName = "Street"
        Me.StreetColumn.HeaderText = "Street"
        Me.StreetColumn.Name = "StreetColumn"
        '
        'CityColumn
        '
        Me.CityColumn.DataPropertyName = "City"
        Me.CityColumn.HeaderText = "City"
        Me.CityColumn.Name = "CityColumn"
        '
        'StateColumn
        '
        Me.StateColumn.DataPropertyName = "StateCode"
        Me.StateColumn.HeaderText = "State"
        Me.StateColumn.Name = "StateColumn"
        '
        'ActiveColumn
        '
        Me.ActiveColumn.DataPropertyName = "Active"
        Me.ActiveColumn.HeaderText = "Active"
        Me.ActiveColumn.Name = "ActiveColumn"
        Me.ActiveColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActiveColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 231)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Working with string validation"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents addNewCustomerButton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CompanyNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents StreetColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As DataGridViewTextBoxColumn
    Friend WithEvents StateColumn As DataGridViewTextBoxColumn
    Friend WithEvents ActiveColumn As DataGridViewCheckBoxColumn
End Class
