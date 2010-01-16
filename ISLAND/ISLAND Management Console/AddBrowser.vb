Public Class AddBrowser

	Public ReadOnly Property GetBrowserName() As String
		Get
			Return BrowserName.Text
		End Get
	End Property

	Public ReadOnly Property GetBrowserCommand() As String
		Get
			Return CommandTextBox.Text
		End Get
	End Property

	Private Sub AddNewBrowserButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewBrowserButton.Click
		If GetBrowserCommand.Trim.Equals(String.Empty) OrElse GetBrowserName.Trim.Equals(String.Empty) Then
			MessageBox.Show("You must enter both a name and a command to add a browser")
			Return
		End If
		Me.DialogResult = Windows.Forms.DialogResult.OK
		If Not Me.Modal Then
			Me.Close()
		End If
	End Sub

	Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
		Me.DialogResult = Windows.Forms.DialogResult.Cancel
		If Not Me.Modal Then
			Me.Close()
		End If
	End Sub
End Class