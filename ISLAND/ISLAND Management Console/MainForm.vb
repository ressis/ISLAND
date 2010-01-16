Public Class MainForm

	Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		DatabaseHelpers.Validate_Database()
		
	End Sub
End Class
