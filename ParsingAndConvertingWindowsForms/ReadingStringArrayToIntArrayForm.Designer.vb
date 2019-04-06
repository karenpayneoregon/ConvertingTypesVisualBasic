<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadingStringArrayToIntArrayForm
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
        Me.stringArrayToIntegerArrayGoodButton = New System.Windows.Forms.Button()
        Me.stringArrayToIntegerArrayAssertPreserveButton = New System.Windows.Forms.Button()
        Me.stringArrayToIntegerArrayAssertAdjustButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'stringArrayToIntegerArrayGoodButton
        '
        Me.stringArrayToIntegerArrayGoodButton.Location = New System.Drawing.Point(12, 12)
        Me.stringArrayToIntegerArrayGoodButton.Name = "stringArrayToIntegerArrayGoodButton"
        Me.stringArrayToIntegerArrayGoodButton.Size = New System.Drawing.Size(407, 23)
        Me.stringArrayToIntegerArrayGoodButton.TabIndex = 0
        Me.stringArrayToIntegerArrayGoodButton.Text = "String array to Integer Array (Good)"
        Me.stringArrayToIntegerArrayGoodButton.UseVisualStyleBackColor = True
        '
        'stringArrayToIntegerArrayAssertPreserveButton
        '
        Me.stringArrayToIntegerArrayAssertPreserveButton.Location = New System.Drawing.Point(12, 52)
        Me.stringArrayToIntegerArrayAssertPreserveButton.Name = "stringArrayToIntegerArrayAssertPreserveButton"
        Me.stringArrayToIntegerArrayAssertPreserveButton.Size = New System.Drawing.Size(407, 23)
        Me.stringArrayToIntegerArrayAssertPreserveButton.TabIndex = 1
        Me.stringArrayToIntegerArrayAssertPreserveButton.Text = "String array to Integer Array (Assert/preserve)"
        Me.stringArrayToIntegerArrayAssertPreserveButton.UseVisualStyleBackColor = True
        '
        'stringArrayToIntegerArrayAssertAdjustButton
        '
        Me.stringArrayToIntegerArrayAssertAdjustButton.Location = New System.Drawing.Point(12, 92)
        Me.stringArrayToIntegerArrayAssertAdjustButton.Name = "stringArrayToIntegerArrayAssertAdjustButton"
        Me.stringArrayToIntegerArrayAssertAdjustButton.Size = New System.Drawing.Size(407, 23)
        Me.stringArrayToIntegerArrayAssertAdjustButton.TabIndex = 2
        Me.stringArrayToIntegerArrayAssertAdjustButton.Text = "String array to Integer Array (Assert/adjust)"
        Me.stringArrayToIntegerArrayAssertAdjustButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 135)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(407, 181)
        Me.TextBox1.TabIndex = 3
        '
        'ReadingStringArrayToIntArrayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 328)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.stringArrayToIntegerArrayAssertAdjustButton)
        Me.Controls.Add(Me.stringArrayToIntegerArrayAssertPreserveButton)
        Me.Controls.Add(Me.stringArrayToIntegerArrayGoodButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReadingStringArrayToIntArrayForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReadingStringArrayToIntArrayForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stringArrayToIntegerArrayGoodButton As Button
    Friend WithEvents stringArrayToIntegerArrayAssertPreserveButton As Button
    Friend WithEvents stringArrayToIntegerArrayAssertAdjustButton As Button
    Friend WithEvents TextBox1 As TextBox
End Class
