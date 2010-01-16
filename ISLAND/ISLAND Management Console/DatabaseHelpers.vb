Public Class DatabaseHelpers
	Private Shared conn_string As String = ""
	Private Shared conn As System.Data.SQLite.SQLiteConnection

	Private Shared ReadOnly Property ConnectionString() As String
		Get
			If conn_string.Equals(String.Empty) Then
				Dim conn_string_builder As New System.Data.SQLite.SQLiteConnectionStringBuilder()
				conn_string_builder.DataSource = System.IO.Path.Combine(System.Environment.GetEnvironmentVariable("APPDATA"), "ISLAND\urls.sqlite3")

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
		Try
			Initialize_Database(Connection)
		Finally
			If Connection.State = ConnectionState.Open Then
				Connection.Close()
			End If
		End Try
	End Sub

	Private Shared Sub Initialize_Database(ByVal conn As System.Data.SQLite.SQLiteConnection)
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
End Class
