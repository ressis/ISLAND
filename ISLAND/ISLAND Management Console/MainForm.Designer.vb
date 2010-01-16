<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
		Me.BrowserList = New System.Windows.Forms.ListBox
		Me.AddNewBrowser = New System.Windows.Forms.Button
		Me.DeleteBrowser = New System.Windows.Forms.Button
		Me.ManageBrowser = New System.Windows.Forms.Button
		Me.MainMenu = New System.Windows.Forms.MenuStrip
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.DetectBrowsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.MainMenu.SuspendLayout()
		Me.SuspendLayout()
		'
		'BrowserList
		'
		Me.BrowserList.FormattingEnabled = True
		Me.BrowserList.Location = New System.Drawing.Point(12, 25)
		Me.BrowserList.Name = "BrowserList"
		Me.BrowserList.Size = New System.Drawing.Size(332, 199)
		Me.BrowserList.TabIndex = 0
		'
		'AddNewBrowser
		'
		Me.AddNewBrowser.Location = New System.Drawing.Point(12, 230)
		Me.AddNewBrowser.Name = "AddNewBrowser"
		Me.AddNewBrowser.Size = New System.Drawing.Size(75, 23)
		Me.AddNewBrowser.TabIndex = 1
		Me.AddNewBrowser.Text = "Add Browser"
		Me.AddNewBrowser.UseVisualStyleBackColor = True
		'
		'DeleteBrowser
		'
		Me.DeleteBrowser.Location = New System.Drawing.Point(269, 230)
		Me.DeleteBrowser.Name = "DeleteBrowser"
		Me.DeleteBrowser.Size = New System.Drawing.Size(75, 23)
		Me.DeleteBrowser.TabIndex = 2
		Me.DeleteBrowser.Text = "Delete Browser"
		Me.DeleteBrowser.UseVisualStyleBackColor = True
		'
		'ManageBrowser
		'
		Me.ManageBrowser.Location = New System.Drawing.Point(93, 230)
		Me.ManageBrowser.Name = "ManageBrowser"
		Me.ManageBrowser.Size = New System.Drawing.Size(170, 23)
		Me.ManageBrowser.TabIndex = 3
		Me.ManageBrowser.Text = "Manage Browser"
		Me.ManageBrowser.UseVisualStyleBackColor = True
		'
		'MainMenu
		'
		Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
		Me.MainMenu.Location = New System.Drawing.Point(0, 0)
		Me.MainMenu.Name = "MainMenu"
		Me.MainMenu.Size = New System.Drawing.Size(356, 24)
		Me.MainMenu.TabIndex = 4
		Me.MainMenu.Text = "MainMenu"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetectBrowsersToolStripMenuItem, Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.FileToolStripMenuItem.Text = "&File"
		'
		'DetectBrowsersToolStripMenuItem
		'
		Me.DetectBrowsersToolStripMenuItem.Name = "DetectBrowsersToolStripMenuItem"
		Me.DetectBrowsersToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
		Me.DetectBrowsersToolStripMenuItem.Text = "Detect &Browsers"
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
		Me.ExitToolStripMenuItem.Text = "E&xit"
		'
		'MainForm
		'
		Me.AcceptButton = Me.ManageBrowser
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(356, 262)
		Me.Controls.Add(Me.ManageBrowser)
		Me.Controls.Add(Me.DeleteBrowser)
		Me.Controls.Add(Me.AddNewBrowser)
		Me.Controls.Add(Me.BrowserList)
		Me.Controls.Add(Me.MainMenu)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.MainMenuStrip = Me.MainMenu
		Me.MaximizeBox = False
		Me.Name = "MainForm"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ISLAND Management Console"
		Me.MainMenu.ResumeLayout(False)
		Me.MainMenu.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents BrowserList As System.Windows.Forms.ListBox
	Friend WithEvents AddNewBrowser As System.Windows.Forms.Button
	Friend WithEvents DeleteBrowser As System.Windows.Forms.Button
	Friend WithEvents ManageBrowser As System.Windows.Forms.Button
	Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DetectBrowsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
