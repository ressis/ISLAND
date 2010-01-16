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
			If conn.State = ConnectionState.Closed Then
				conn.Open()
			End If
			Return conn
		End Get
	End Property

	Public Shared Sub Validate_Database()
		If Not System.IO.File.Exists(DBFileLocation) Then
			System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(DBFileLocation))
			System.Data.SQLite.SQLiteConnection.CreateFile(DBFileLocation)
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
		Dim browserTable As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand
		Dim urlTable As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		browserTable.CommandText = "CREATE TABLE IF NOT EXISTS browsers (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, command TEXT, isDefault INTEGER);"
		urlTable.CommandText = "CREATE TABLE IF NOT EXISTS urls (id INTEGER PRIMARY KEY AUTOINCREMENT, urlPattern TEXT, browser INTEGER CONSTRAINT browser_id_fkey REFERENCES browsers (id) ON DELETE CASCADE);"

		browserTable.ExecuteNonQuery()
		urlTable.ExecuteNonQuery()

		For Each newBrowser As Browser In RegistryHelpers.GetInstalledBrowsersFromRegistry
			AddBrowser(newBrowser)
		Next
	End Sub

	Public Shared Function AddBrowser(ByVal newBrowser As Browser) As Boolean
		Dim insertBrowser As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		insertBrowser.CommandText = "INSERT INTO browsers (name,command,isDefault) VALUES (@name,@command,@default);"
		insertBrowser.Parameters.AddWithValue("@name", newBrowser.FriendlyName)
		insertBrowser.Parameters.AddWithValue("@command", newBrowser.CommandString)
		insertBrowser.Parameters.AddWithValue("@default", newBrowser.isDefault)

		Return insertBrowser.ExecuteNonQuery() > 0
	End Function

	Public Shared Function DeleteBrowser(ByVal browserToDelete As Browser) As Boolean
		If browserToDelete.DB_ID Is Nothing Then
			Return False
		End If

		Dim deleteBrowserSQL As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand
		Dim deleteUrlsForBrowser As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		deleteUrlsForBrowser.CommandText = "DELETE FROM urls WHERE browser=@id"
		deleteBrowserSQL.CommandText = "DELETE FROM browsers WHERE id=@id"
		deleteBrowserSQL.Parameters.AddWithValue("@id", browserToDelete.DB_ID)
		deleteUrlsForBrowser.Parameters.AddWithValue("@id", browserToDelete.DB_ID)

		Return (deleteBrowserSQL.ExecuteNonQuery > 0) AndAlso (deleteUrlsForBrowser.ExecuteNonQuery >= 0)
	End Function

	Public Shared Function SetDefaultBrowser(ByVal browserID As Int64) As Boolean
		Dim setDefault As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		setDefault.CommandText = "UPDATE browsers SET isDefault = CASE WHEN (id = @id) THEN @true ELSE @false END"
		setDefault.Parameters.AddWithValue("@id", browserID)
		setDefault.Parameters.AddWithValue("@true", True)
		setDefault.Parameters.AddWithValue("@false", False)

		Return setDefault.ExecuteNonQuery > 0
	End Function

	Public Shared Function GetInstalledBrowsersFromDatabase() As List(Of Browser)
		Dim list As New List(Of Browser)

		Dim selectBrowsers As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		selectBrowsers.CommandText = "SELECT * FROM browsers"

		Dim reader As System.Data.SQLite.SQLiteDataReader = selectBrowsers.ExecuteReader
		While reader.Read
			list.Add(New Browser(reader("name"), reader("command"), reader("id"), reader("isDefault")))
		End While
		reader.Close()
		Return list
	End Function

	Public Shared Function GetListOfURLPatternsByBrowser(ByVal browserObj As Browser)
		Return GetListOfURLPatternsByBrowserID(browserObj.DB_ID)
	End Function

	Public Shared Function GetListOfURLPatternsByBrowserID(ByVal id As Int64) As List(Of URL)
		Dim list As New List(Of URL)

		Dim selectURLs As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		selectURLs.CommandText = "SELECT * FROM urls WHERE browser = @browser"
		selectURLs.Parameters.AddWithValue("@browser", id)

		Dim reader As System.Data.SQLite.SQLiteDataReader = selectURLs.ExecuteReader
		While reader.Read
			list.Add(New URL(reader("browser"), reader("urlPattern"), reader("id")))
		End While
		reader.Close()
		Return list
	End Function

	Public Shared Function GetListOfURLPatterns() As List(Of URL)
		Dim list As New List(Of URL)

		Dim selectURLs As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		selectURLs.CommandText = "SELECT * FROM urls"

		Dim reader As System.Data.SQLite.SQLiteDataReader = selectURLs.ExecuteReader
		While reader.Read
			list.Add(New URL(reader("browser"), reader("urlPattern"), reader("id")))
		End While
		reader.Close()
		Return list
	End Function

	Public Shared Function DoesBrowserExist(ByVal browserObj As Browser)
		Return DoesBrowserExist(browserObj.DB_ID)
	End Function

	Public Shared Function DoesBrowserExist(ByVal id As Nullable(Of Int64))
		If id Is Nothing Then
			Return False
		End If

		Dim sql As System.Data.SQLite.SQLiteCommand = Connection.CreateCommand

		sql.CommandText = "SELECT * FROM browsers WHERE id = @id"
		sql.Parameters.AddWithValue("@id", id)

		Return sql.ExecuteScalar IsNot Nothing
	End Function
End Class
