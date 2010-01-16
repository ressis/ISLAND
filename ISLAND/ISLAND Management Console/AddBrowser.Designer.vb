<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddBrowser
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddBrowser))
		Me.Apology = New System.Windows.Forms.Label
		Me.BrowserNameLabel = New System.Windows.Forms.Label
		Me.BrowserName = New System.Windows.Forms.TextBox
		Me.CommandLabel = New System.Windows.Forms.Label
		Me.CommandTextBox = New System.Windows.Forms.TextBox
		Me.AddBrowserTooltip = New System.Windows.Forms.ToolTip(Me.components)
		Me.AddNewBrowserButton = New System.Windows.Forms.Button
		Me.Cancel = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'Apology
		'
		Me.Apology.Location = New System.Drawing.Point(12, 9)
		Me.Apology.Name = "Apology"
		Me.Apology.Size = New System.Drawing.Size(260, 56)
		Me.Apology.TabIndex = 0
		Me.Apology.Text = "I'm sorry I did not detect the browser you wanted." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Newly Installed Browser?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " " & _
			 "    Try File->Detect Browsers"
		'
		'BrowserNameLabel
		'
		Me.BrowserNameLabel.AutoSize = True
		Me.BrowserNameLabel.Location = New System.Drawing.Point(8, 71)
		Me.BrowserNameLabel.Name = "BrowserNameLabel"
		Me.BrowserNameLabel.Size = New System.Drawing.Size(38, 13)
		Me.BrowserNameLabel.TabIndex = 1
		Me.BrowserNameLabel.Text = "Name:"
		Me.AddBrowserTooltip.SetToolTip(Me.BrowserNameLabel, resources.GetString("BrowserNameLabel.ToolTip"))
		'
		'BrowserName
		'
		Me.BrowserName.Location = New System.Drawing.Point(77, 68)
		Me.BrowserName.Name = "BrowserName"
		Me.BrowserName.Size = New System.Drawing.Size(224, 20)
		Me.BrowserName.TabIndex = 2
		Me.AddBrowserTooltip.SetToolTip(Me.BrowserName, resources.GetString("BrowserName.ToolTip"))
		'
		'CommandLabel
		'
		Me.CommandLabel.AutoSize = True
		Me.CommandLabel.Location = New System.Drawing.Point(8, 97)
		Me.CommandLabel.Name = "CommandLabel"
		Me.CommandLabel.Size = New System.Drawing.Size(57, 13)
		Me.CommandLabel.TabIndex = 3
		Me.CommandLabel.Text = "Command:"
		Me.AddBrowserTooltip.SetToolTip(Me.CommandLabel, resources.GetString("CommandLabel.ToolTip"))
		'
		'CommandTextBox
		'
		Me.CommandTextBox.Location = New System.Drawing.Point(77, 94)
		Me.CommandTextBox.Name = "CommandTextBox"
		Me.CommandTextBox.Size = New System.Drawing.Size(224, 20)
		Me.CommandTextBox.TabIndex = 4
		Me.AddBrowserTooltip.SetToolTip(Me.CommandTextBox, resources.GetString("CommandTextBox.ToolTip"))
		'
		'AddBrowserTooltip
		'
		Me.AddBrowserTooltip.IsBalloon = True
		Me.AddBrowserTooltip.ToolTipTitle = "Example"
		'
		'AddNewBrowserButton
		'
		Me.AddNewBrowserButton.Location = New System.Drawing.Point(12, 120)
		Me.AddNewBrowserButton.Name = "AddNewBrowserButton"
		Me.AddNewBrowserButton.Size = New System.Drawing.Size(75, 23)
		Me.AddNewBrowserButton.TabIndex = 5
		Me.AddNewBrowserButton.Text = "Ok"
		Me.AddNewBrowserButton.UseVisualStyleBackColor = True
		'
		'Cancel
		'
		Me.Cancel.Location = New System.Drawing.Point(226, 120)
		Me.Cancel.Name = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(75, 23)
		Me.Cancel.TabIndex = 6
		Me.Cancel.Text = "Cancel"
		Me.Cancel.UseVisualStyleBackColor = True
		'
		'AddBrowser
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(313, 153)
		Me.Controls.Add(Me.Cancel)
		Me.Controls.Add(Me.AddNewBrowserButton)
		Me.Controls.Add(Me.CommandTextBox)
		Me.Controls.Add(Me.CommandLabel)
		Me.Controls.Add(Me.BrowserName)
		Me.Controls.Add(Me.BrowserNameLabel)
		Me.Controls.Add(Me.Apology)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AddBrowser"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Add Custom Browser"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Apology As System.Windows.Forms.Label
	Friend WithEvents BrowserNameLabel As System.Windows.Forms.Label
	Friend WithEvents BrowserName As System.Windows.Forms.TextBox
	Friend WithEvents CommandLabel As System.Windows.Forms.Label
	Friend WithEvents CommandTextBox As System.Windows.Forms.TextBox
	Friend WithEvents AddBrowserTooltip As System.Windows.Forms.ToolTip
	Friend WithEvents AddNewBrowserButton As System.Windows.Forms.Button
	Friend WithEvents Cancel As System.Windows.Forms.Button
End Class
