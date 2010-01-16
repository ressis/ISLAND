Public Class DatabaseHelpers
	Private Shared conn_string As String = ""
	Private Shared conn As System.Data.SQLite.SQLiteConnection
	Private Shared newDB As Boolean = False

	Private Shared ReadOnly Property ConnectionString() As String
		Get
			If conn_string.Equals(String.Empty) Then
				Dim db_file As String = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("APPDATA"), "ISLAND\urls.sqlite3")
				Dim conn_string_builder As New System.Data.SQLite.SQLiteConnectionStringBuilder()
				conn_string_builder.DataSource = db_file

				conn_string = conn_string_builder.ToString

				If Not System.IO.File.Exists(db_file) Then
					newDB = True
					System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(db_file))
					System.Data.SQLite.SQLiteConnection.CreateFile(db_file)
				End If
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
		Try
			Initialize_Database(Connection)
		Finally
			If Connection.State = ConnectionState.Open Then
				Connection.Close()
			End If
		End Try
	End Sub

	Private Shared Sub Initialize_Database(ByVal conn As System.Data.SQLite.SQLiteConnection)
		If Not newDB Then
			Return
		End If
		Dim connectionState As ConnectionState = conn.State

		Dim browserTable As System.Data.SQLite.SQLiteCommand = conn.CreateCommand
		Dim urlTable As System.Data.SQLite.SQLiteCommand = conn.CreateCommand

		browserTable.CommandText = "CREATE TABLE IF NOT EXISTS browsers (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, command TEXT);"
		urlTable.CommandText = "CREATE TABLE IF NOT EXISTS urls (id INTEGER PRIMARY KEY AUTOINCREMENT, urlPattern TEXT, browser INTEGER CONSTRAINT browser_id_fkey REFERENCES browsers (id) ON DELETE CASCADE);"

		If connectionState = Data.ConnectionState.Closed Then
			conn.Open()
		End If

		browserTable.ExecuteNonQuery()
		urlTable.ExecuteNonQuery()

		If connectionState = Data.ConnectionState.Closed Then
			conn.Close()
		End If
	End Sub

	Private Shared Sub Discover_Browsers()

	End Sub
End Class
