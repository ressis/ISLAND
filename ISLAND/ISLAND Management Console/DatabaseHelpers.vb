Public Class DatabaseHelpers
	Private Shared db_Loc As String = ""
	Private Shared conn_string As String = ""
	Private Shared conn As System.Data.SQLite.SQLiteConnection

	Private Shared ReadOnly Property DBFileLocation() As String
		Get
			If db_Loc = String.Empty Then
				db_Loc = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("APPDATA"), "ISLAND\urls.db3")
			End If
			Return db_Loc
		End Get
	End Property

	Private Shared ReadOnly Property ConnectionString() As String
		Get
			If conn_string.Equals(String.Empty) Then
				Dim conn_string_builder As New System.Data.SQLite.SQLiteConnectionStringBuilder()
				conn_string_builder.DataSource = dbfilelocation

				conn_string = conn_string_builder.ToString
			End If
			Return conn_string
		End Get
	End Property

	Private Shared ReadOnly Property Connection() As System.Data.SQLite.SQLiteConnection
		Get
			If conn Is Nothing Then
				conn = New System.Data.SQLite.SQLiteConnection(ConnectionString)
			End If
			Return conn
		End Get
	End Property

	Public Shared Sub Validate_Database()
		If Not System.IO.File.Exists(DBFileLocation) Then
			System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(DBFileLocation))
			System.Data.SQLite.SQLiteConnection.CreateFile(DBFileLocation)
		Else
			Try
				Initialize_Database()
			Finally
				If Connection.State = ConnectionState.Open Then
					Connection.Close()
				End If
			End Try
		End If
	End Sub

	Private Shared Sub Initialize_Database()
		If Connection.State = ConnectionState.Closed Then
			Connection.Open()
		End If

		Dim browserTable As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand
		Dim urlTable As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		browserTable.CommandText = "CREATE TABLE IF NOT EXISTS browsers (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, command TEXT, isDefault INTEGER);"
		urlTable.CommandText = "CREATE TABLE IF NOT EXISTS urls (id INTEGER PRIMARY KEY AUTOINCREMENT, urlPattern TEXT, browser INTEGER CONSTRAINT browser_id_fkey REFERENCES browsers (id) ON DELETE CASCADE);"

		browserTable.ExecuteNonQuery()
		urlTable.ExecuteNonQuery()

		For Each newBrowser As Browser In RegistryHelpers.GetInstalledBrowsersFromRegistry
			Add_Browser(newBrowser)
		Next
	End Sub

	Public Shared Function Add_Browser(ByVal newBrowser As Browser) As Boolean
		If Connection.State = ConnectionState.Closed Then
			Connection.Open()
		End If

		Dim insertBrowser As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		insertBrowser.CommandText = "INSERT INTO browsers (name,command,isDefault) VALUES (@name,@command,@default);"
		insertBrowser.Parameters.AddWithValue("@name", newBrowser.FriendlyName)
		insertBrowser.Parameters.AddWithValue("@command", newBrowser.CommandString)
		insertBrowser.Parameters.AddWithValue("@default", newBrowser.isDefault)

		Return insertBrowser.ExecuteNonQuery() > 0
	End Function
End Class
