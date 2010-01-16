<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class URLManager
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
		Me.URLList = New System.Windows.Forms.ListBox
		Me.AddPatternButton = New System.Windows.Forms.Button
		Me.DeletePatternButton = New System.Windows.Forms.Button
		Me.Button3 = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'URLList
		'
		Me.URLList.FormattingEnabled = True
		Me.URLList.Location = New System.Drawing.Point(12, 12)
		Me.URLList.Name = "URLList"
		Me.URLList.Size = New System.Drawing.Size(312, 212)
		Me.URLList.TabIndex = 0
		'
		'AddPatternButton
		'
		Me.AddPatternButton.Location = New System.Drawing.Point(12, 227)
		Me.AddPatternButton.Name = "AddPatternButton"
		Me.AddPatternButton.Size = New System.Drawing.Size(100, 23)
		Me.AddPatternButton.TabIndex = 1
		Me.AddPatternButton.Text = "Add Pattern"
		Me.AddPatternButton.UseVisualStyleBackColor = True
		'
		'DeletePatternButton
		'
		Me.DeletePatternButton.Location = New System.Drawing.Point(118, 227)
		Me.DeletePatternButton.Name = "DeletePatternButton"
		Me.DeletePatternButton.Size = New System.Drawing.Size(100, 23)
		Me.DeletePatternButton.TabIndex = 2
		Me.DeletePatternButton.Text = "Delete Pattern"
		Me.DeletePatternButton.UseVisualStyleBackColor = True
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(224, 227)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(100, 23)
		Me.Button3.TabIndex = 3
		Me.Button3.Text = "Move Pattern"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'URLManager
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(336, 262)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.DeletePatternButton)
		Me.Controls.Add(Me.AddPatternButton)
		Me.Controls.Add(Me.URLList)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.MaximizeBox = False
		Me.Name = "URLManager"
		Me.Text = "URLManager"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents URLList As System.Windows.Forms.ListBox
	Friend WithEvents AddPatternButton As System.Windows.Forms.Button
	Friend WithEvents DeletePatternButton As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
