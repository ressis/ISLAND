Public Class RegistryHelpers
	Public Shared Function GetInstalledBrowsersFromRegistry() As List(Of Browser)
		Dim browsers As New List(Of Browser)

		Dim localMachine_browsers As Microsoft.Win32.RegistryKey
		Dim currentUser_browsers As Microsoft.Win32.RegistryKey

		localMachine_browsers = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Clients\StartMenuInternet")
		currentUser_browsers = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Clients\StartMenuInternet")

		For Each entry As String In localMachine_browsers.GetSubKeyNames
			Dim name As String
			Dim command As String

			Dim browser_key As Microsoft.Win32.RegistryKey = localMachine_browsers.OpenSubKey(entry)
			name = browser_key.GetValue("")
			command = browser_key.OpenSubKey("shell\open\command").GetValue("")
			browsers.Add(New Browser(name, command))
		Next

		'Most browsers will be installed to the machine... but just in case...
		For Each entry As String In currentUser_browsers.GetSubKeyNames
			Dim name As String
			Dim command As String

			Dim browser_key As Microsoft.Win32.RegistryKey = currentUser_browsers.OpenSubKey(entry)
			name = browser_key.GetValue("")
			command = browser_key.OpenSubKey("shell\open\command").GetValue("")
			browsers.Add(New Browser(name, command))
		Next

		'I'm fairly certain that there won't be any duplicates because of: http://msdn.microsoft.com/en-us/library/dd203067(VS.85).aspx
		Return browsers
	End Function

	Public Shared Sub RegisterAsDefaultBrowser()
		'TODO: Figure out how to get the Launcher's path here.
		'... might as well use the registry!
		Microsoft.Win32.Registry.SetValue("HKEY_CLASSES_ROOT\http\shell\open\command", "", String.Format("""{0}"" ""%1""", System.Reflection.Assembly.GetExecutingAssembly.Location))
		'Don't do https until testing is complete
		'Microsoft.Win32.Registry.SetValue("HKEY_CLASSES_ROOT\https\shell\open\command", "", String.Format("""{0}"" ""%1""", System.Reflection.Assembly.GetExecutingAssembly.Location))
	End Sub
End Class
