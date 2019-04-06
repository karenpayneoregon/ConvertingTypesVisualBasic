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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tryParseIntegerButton = New System.Windows.Forms.Button()
        Me.tryParseIntegerTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.keyPressAssertIntegerButton = New System.Windows.Forms.Button()
        Me.keyPressAssertionOnIntegerTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.assumesIntegerTryItButton = New System.Windows.Forms.Button()
        Me.assumesIntegerTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.genericConvertStringToDecimalTextBox = New System.Windows.Forms.TextBox()
        Me.genericConvertStringToDecimalButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToNullableFailGracefullyTextBox = New System.Windows.Forms.TextBox()
        Me.ToNullableFailGracefullyButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tryParseIntegerButton)
        Me.GroupBox1.Controls.Add(Me.tryParseIntegerTextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.keyPressAssertIntegerButton)
        Me.GroupBox1.Controls.Add(Me.keyPressAssertionOnIntegerTextBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.assumesIntegerTryItButton)
        Me.GroupBox1.Controls.Add(Me.assumesIntegerTextBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 115)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parsing Integers"
        '
        'tryParseIntegerButton
        '
        Me.tryParseIntegerButton.Location = New System.Drawing.Point(233, 78)
        Me.tryParseIntegerButton.Name = "tryParseIntegerButton"
        Me.tryParseIntegerButton.Size = New System.Drawing.Size(75, 23)
        Me.tryParseIntegerButton.TabIndex = 8
        Me.tryParseIntegerButton.Text = "Try it"
        Me.tryParseIntegerButton.UseVisualStyleBackColor = True
        '
        'tryParseIntegerTextBox
        '
        Me.tryParseIntegerTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.tryParseIntegerTextBox.ForeColor = System.Drawing.Color.Black
        Me.tryParseIntegerTextBox.Location = New System.Drawing.Point(108, 81)
        Me.tryParseIntegerTextBox.Name = "tryParseIntegerTextBox"
        Me.tryParseIntegerTextBox.Size = New System.Drawing.Size(100, 20)
        Me.tryParseIntegerTextBox.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TryParse Integer"
        '
        'keyPressAssertIntegerButton
        '
        Me.keyPressAssertIntegerButton.Location = New System.Drawing.Point(233, 48)
        Me.keyPressAssertIntegerButton.Name = "keyPressAssertIntegerButton"
        Me.keyPressAssertIntegerButton.Size = New System.Drawing.Size(75, 23)
        Me.keyPressAssertIntegerButton.TabIndex = 5
        Me.keyPressAssertIntegerButton.Text = "Try it"
        Me.keyPressAssertIntegerButton.UseVisualStyleBackColor = True
        '
        'keyPressAssertionOnIntegerTextBox
        '
        Me.keyPressAssertionOnIntegerTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.keyPressAssertionOnIntegerTextBox.ForeColor = System.Drawing.Color.Black
        Me.keyPressAssertionOnIntegerTextBox.Location = New System.Drawing.Point(108, 50)
        Me.keyPressAssertionOnIntegerTextBox.Name = "keyPressAssertionOnIntegerTextBox"
        Me.keyPressAssertionOnIntegerTextBox.Size = New System.Drawing.Size(100, 20)
        Me.keyPressAssertionOnIntegerTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Event assertion"
        '
        'assumesIntegerTryItButton
        '
        Me.assumesIntegerTryItButton.Location = New System.Drawing.Point(233, 19)
        Me.assumesIntegerTryItButton.Name = "assumesIntegerTryItButton"
        Me.assumesIntegerTryItButton.Size = New System.Drawing.Size(75, 23)
        Me.assumesIntegerTryItButton.TabIndex = 2
        Me.assumesIntegerTryItButton.Text = "Try it"
        Me.assumesIntegerTryItButton.UseVisualStyleBackColor = True
        '
        'assumesIntegerTextBox
        '
        Me.assumesIntegerTextBox.BackColor = System.Drawing.Color.Black
        Me.assumesIntegerTextBox.ForeColor = System.Drawing.Color.White
        Me.assumesIntegerTextBox.Location = New System.Drawing.Point(108, 22)
        Me.assumesIntegerTextBox.Name = "assumesIntegerTextBox"
        Me.assumesIntegerTextBox.ReadOnly = True
        Me.assumesIntegerTextBox.Size = New System.Drawing.Size(100, 20)
        Me.assumesIntegerTextBox.TabIndex = 1
        Me.assumesIntegerTextBox.Text = "One"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assumes integer"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.closeButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 278)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 44)
        Me.Panel1.TabIndex = 1
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(269, 9)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.genericConvertStringToDecimalButton)
        Me.GroupBox2.Controls.Add(Me.genericConvertStringToDecimalTextBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(329, 65)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parsing Decimal using generics"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Generic parse"
        '
        'genericConvertStringToDecimalTextBox
        '
        Me.genericConvertStringToDecimalTextBox.BackColor = System.Drawing.Color.Black
        Me.genericConvertStringToDecimalTextBox.ForeColor = System.Drawing.Color.White
        Me.genericConvertStringToDecimalTextBox.Location = New System.Drawing.Point(104, 24)
        Me.genericConvertStringToDecimalTextBox.Name = "genericConvertStringToDecimalTextBox"
        Me.genericConvertStringToDecimalTextBox.ReadOnly = True
        Me.genericConvertStringToDecimalTextBox.Size = New System.Drawing.Size(100, 20)
        Me.genericConvertStringToDecimalTextBox.TabIndex = 9
        Me.genericConvertStringToDecimalTextBox.Text = "1.56"
        '
        'genericConvertStringToDecimalButton
        '
        Me.genericConvertStringToDecimalButton.Location = New System.Drawing.Point(229, 21)
        Me.genericConvertStringToDecimalButton.Name = "genericConvertStringToDecimalButton"
        Me.genericConvertStringToDecimalButton.Size = New System.Drawing.Size(75, 23)
        Me.genericConvertStringToDecimalButton.TabIndex = 9
        Me.genericConvertStringToDecimalButton.Text = "Try it"
        Me.genericConvertStringToDecimalButton.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ToNullableFailGracefullyButton)
        Me.GroupBox3.Controls.Add(Me.ToNullableFailGracefullyTextBox)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 202)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(326, 64)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ToNullable"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Assumes integer"
        '
        'ToNullableFailGracefullyTextBox
        '
        Me.ToNullableFailGracefullyTextBox.BackColor = System.Drawing.Color.Black
        Me.ToNullableFailGracefullyTextBox.ForeColor = System.Drawing.Color.White
        Me.ToNullableFailGracefullyTextBox.Location = New System.Drawing.Point(102, 25)
        Me.ToNullableFailGracefullyTextBox.Name = "ToNullableFailGracefullyTextBox"
        Me.ToNullableFailGracefullyTextBox.ReadOnly = True
        Me.ToNullableFailGracefullyTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ToNullableFailGracefullyTextBox.TabIndex = 9
        Me.ToNullableFailGracefullyTextBox.Text = "One"
        '
        'ToNullableFailGracefullyButton
        '
        Me.ToNullableFailGracefullyButton.Location = New System.Drawing.Point(227, 23)
        Me.ToNullableFailGracefullyButton.Name = "ToNullableFailGracefullyButton"
        Me.ToNullableFailGracefullyButton.Size = New System.Drawing.Size(75, 23)
        Me.ToNullableFailGracefullyButton.TabIndex = 10
        Me.ToNullableFailGracefullyButton.Text = "Try it"
        Me.ToNullableFailGracefullyButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 322)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parsing and converting code sample"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents assumesIntegerTryItButton As Button
    Friend WithEvents assumesIntegerTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents closeButton As Button
    Friend WithEvents keyPressAssertIntegerButton As Button
    Friend WithEvents keyPressAssertionOnIntegerTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tryParseIntegerButton As Button
    Friend WithEvents tryParseIntegerTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents genericConvertStringToDecimalButton As Button
    Friend WithEvents genericConvertStringToDecimalTextBox As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ToNullableFailGracefullyButton As Button
    Friend WithEvents ToNullableFailGracefullyTextBox As TextBox
    Friend WithEvents Label5 As Label
End Class
