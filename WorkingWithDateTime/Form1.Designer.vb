<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.IsDateExamplesButton = New System.Windows.Forms.Button()
        Me.IsTimeExamplesButton = New System.Windows.Forms.Button()
        Me.HoursComboBox = New System.Windows.Forms.ComboBox()
        Me.GetCurrentHoursComboBoxValueButton = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'IsDateExamplesButton
        '
        Me.IsDateExamplesButton.Location = New System.Drawing.Point(18, 14)
        Me.IsDateExamplesButton.Name = "IsDateExamplesButton"
        Me.IsDateExamplesButton.Size = New System.Drawing.Size(179, 23)
        Me.IsDateExamplesButton.TabIndex = 0
        Me.IsDateExamplesButton.Text = "IsDate"
        Me.IsDateExamplesButton.UseVisualStyleBackColor = True
        '
        'IsTimeExamplesButton
        '
        Me.IsTimeExamplesButton.Location = New System.Drawing.Point(18, 52)
        Me.IsTimeExamplesButton.Name = "IsTimeExamplesButton"
        Me.IsTimeExamplesButton.Size = New System.Drawing.Size(179, 23)
        Me.IsTimeExamplesButton.TabIndex = 1
        Me.IsTimeExamplesButton.Text = "IsDate (with time)"
        Me.IsTimeExamplesButton.UseVisualStyleBackColor = True
        '
        'HoursComboBox
        '
        Me.HoursComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HoursComboBox.FormattingEnabled = True
        Me.HoursComboBox.Location = New System.Drawing.Point(244, 16)
        Me.HoursComboBox.Name = "HoursComboBox"
        Me.HoursComboBox.Size = New System.Drawing.Size(93, 21)
        Me.HoursComboBox.TabIndex = 3
        '
        'GetCurrentHoursComboBoxValueButton
        '
        Me.GetCurrentHoursComboBoxValueButton.Location = New System.Drawing.Point(343, 14)
        Me.GetCurrentHoursComboBoxValueButton.Name = "GetCurrentHoursComboBoxValueButton"
        Me.GetCurrentHoursComboBoxValueButton.Size = New System.Drawing.Size(179, 23)
        Me.GetCurrentHoursComboBoxValueButton.TabIndex = 4
        Me.GetCurrentHoursComboBoxValueButton.Text = "Get current combobox value"
        Me.GetCurrentHoursComboBoxValueButton.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(244, 58)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 189)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GetCurrentHoursComboBoxValueButton)
        Me.Controls.Add(Me.HoursComboBox)
        Me.Controls.Add(Me.IsTimeExamplesButton)
        Me.Controls.Add(Me.IsDateExamplesButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code samples"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents IsDateExamplesButton As Button
    Friend WithEvents IsTimeExamplesButton As Button
    Friend WithEvents HoursComboBox As ComboBox
    Friend WithEvents GetCurrentHoursComboBoxValueButton As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
