<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewCustomerForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.companyNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.streetTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CityTextBox = New System.Windows.Forms.TextBox()
        Me.stateComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.activeCheckBox = New System.Windows.Forms.CheckBox()
        Me.AddCustomerButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company name"
        '
        'companyNameTextBox
        '
        Me.companyNameTextBox.Location = New System.Drawing.Point(125, 18)
        Me.companyNameTextBox.Name = "companyNameTextBox"
        Me.companyNameTextBox.Size = New System.Drawing.Size(163, 20)
        Me.companyNameTextBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Street"
        '
        'streetTextBox
        '
        Me.streetTextBox.Location = New System.Drawing.Point(125, 50)
        Me.streetTextBox.Name = "streetTextBox"
        Me.streetTextBox.Size = New System.Drawing.Size(163, 20)
        Me.streetTextBox.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City"
        '
        'CityTextBox
        '
        Me.CityTextBox.Location = New System.Drawing.Point(125, 82)
        Me.CityTextBox.Name = "CityTextBox"
        Me.CityTextBox.Size = New System.Drawing.Size(163, 20)
        Me.CityTextBox.TabIndex = 5
        '
        'stateComboBox
        '
        Me.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.stateComboBox.FormattingEnabled = True
        Me.stateComboBox.IntegralHeight = False
        Me.stateComboBox.Location = New System.Drawing.Point(125, 114)
        Me.stateComboBox.MaxDropDownItems = 10
        Me.stateComboBox.Name = "stateComboBox"
        Me.stateComboBox.Size = New System.Drawing.Size(163, 21)
        Me.stateComboBox.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "State"
        '
        'activeCheckBox
        '
        Me.activeCheckBox.AutoSize = True
        Me.activeCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.activeCheckBox.Location = New System.Drawing.Point(61, 152)
        Me.activeCheckBox.Name = "activeCheckBox"
        Me.activeCheckBox.Size = New System.Drawing.Size(56, 17)
        Me.activeCheckBox.TabIndex = 8
        Me.activeCheckBox.Text = "Active"
        Me.activeCheckBox.UseVisualStyleBackColor = True
        '
        'AddCustomerButton
        '
        Me.AddCustomerButton.Location = New System.Drawing.Point(25, 206)
        Me.AddCustomerButton.Name = "AddCustomerButton"
        Me.AddCustomerButton.Size = New System.Drawing.Size(75, 23)
        Me.AddCustomerButton.TabIndex = 9
        Me.AddCustomerButton.Text = "Add"
        Me.AddCustomerButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(213, 206)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 10
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewCustomerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 250)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.AddCustomerButton)
        Me.Controls.Add(Me.activeCheckBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.stateComboBox)
        Me.Controls.Add(Me.CityTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.streetTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.companyNameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NewCustomerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "String parsing code sample"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents companyNameTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents streetTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CityTextBox As TextBox
    Friend WithEvents stateComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents activeCheckBox As CheckBox
    Friend WithEvents AddCustomerButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
