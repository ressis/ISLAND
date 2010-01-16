Public Class URLManager

	Private browserObj As Browser
	Private Shared URLManagers As New Dictionary(Of String, URLManager)

	Public Sub New(ByVal _browserObj As Browser)
		InitializeComponent()
		browserObj = _browserObj

		If URLManagers.ContainsKey(browserObj.GetHashCode) Then
			URLManagers(browserObj.GetHashCode).Focus()
			Me.Close()
		Else
			URLManagers(browserObj.GetHashCode) = Me
		End If

		Me.Text = String.Format("URL Manager for {0}", browserObj.FriendlyName)

		AddHandler Me.Activated, AddressOf ConsistencyCheck

		RefreshURLList()
	End Sub

	Private Sub RefreshURLList()
		URLList.DataSource = DatabaseHelpers.GetListOfURLPatternsByBrowser(browserObj)
	End Sub

	Private Sub ConsistencyCheck(ByVal sender As Object, ByVal e As System.EventArgs)
		If Not DatabaseHelpers.DoesBrowserExist(browserObj) Then
			RemoveHandler Me.Activated, AddressOf ConsistencyCheck
			MessageBox.Show("This Browser has been deleted")
			URLManagers(browserObj.GetHashCode) = Nothing
			Me.Close()
		End If
	End Sub

	Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePatternButton.Click

	End Sub
End Class