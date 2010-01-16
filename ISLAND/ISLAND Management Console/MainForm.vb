Public Class MainForm
	Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		DatabaseHelpers.Validate_Database()
		RefreshBrowserList()
	End Sub

	Private Sub RefreshBrowserList()
		BrowserList.DataSource = DatabaseHelpers.GetInstalledBrowsersFromDatabase
	End Sub

	Private Sub DetectBrowsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetectBrowsersToolStripMenuItem.Click
		Dim browsersInDatabase As List(Of Browser) = DatabaseHelpers.GetInstalledBrowsersFromDatabase
		Dim browsersInRegistry As List(Of Browser) = RegistryHelpers.GetInstalledBrowsersFromRegistry

		For Each entry As Browser In browsersInRegistry
			If Not browsersInDatabase.Contains(entry, entry) Then
				DatabaseHelpers.AddBrowser(entry)
			End If
		Next

		RefreshBrowserList()
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		System.Environment.Exit(0)
	End Sub

	Private Sub AddNewBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewBrowser.Click
		Dim AddBrowserDialog As New AddBrowser
		If AddBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
			Dim name As String = AddBrowserDialog.GetBrowserName
			Dim command As String = AddBrowserDialog.GetBrowserCommand

			DatabaseHelpers.AddBrowser(New Browser(name, command))

			RefreshBrowserList()
		End If
	End Sub

	Private Sub DeleteBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBrowser.Click
		If BrowserList.SelectedItem Is Nothing Then
			Return
		End If

		If MessageBox.Show("Are you sure you wish to delete this browser?", "Confirm", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
			DatabaseHelpers.DeleteBrowser(BrowserList.SelectedItem)
			RefreshBrowserList()
		End If
	End Sub
End Class
