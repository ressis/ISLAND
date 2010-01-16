Public Class URL
	Private id As Nullable(Of Int64) = Nothing
	Private owningBrowser As Int64
	Private pattern As String

	Public Property DB_ID() As Nullable(Of Int64)
		Get
			Return id
		End Get
		Set(ByVal value As Nullable(Of Int64))
			id = value
		End Set
	End Property

	Public Property Browser() As Int64
		Get
			Return owningBrowser
		End Get
		Set(ByVal value As Int64)
			owningBrowser = value
		End Set
	End Property

	Public Property URLPattern() As String
		Get
			Return pattern
		End Get
		Set(ByVal value As String)
			pattern = value
		End Set
	End Property

	Public Sub New(ByVal brow As Int64, ByVal _pattern As String, Optional ByVal _id As Object = Nothing)
		id = _id
		owningBrowser = brow
		pattern = _pattern
	End Sub

	Public Function Match(ByVal address As Uri) As Boolean
		If URLPattern Is Nothing Then
			Return False
		End If

		Dim matchPattern As String = "^" + System.Text.RegularExpressions.Regex.Escape(URLPattern).Replace("\*", ".*").Replace("\?", ".") + "$"
		'match against everything EXCEPT query string.
		'This allows you to set different browsers to sites hosted on the same domain, like geocities
		Return System.Text.RegularExpressions.Regex.Match(address.GetLeftPart(UriPartial.Path), matchPattern).Success
	End Function

End Class
