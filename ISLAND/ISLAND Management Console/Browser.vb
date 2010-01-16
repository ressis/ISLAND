Public Class Browser
	Private id As Nullable(Of Int64) = Nothing
	Private name As String = Nothing
	Private command As String = Nothing
	Private is_default As Boolean = False

	Public Property DB_ID() As Nullable(Of Int64)
		Get
			Return id
		End Get
		Set(ByVal value As Nullable(Of Int64))
			id = value
		End Set
	End Property

	Public Property FriendlyName() As String
		Get
			Return name
		End Get
		Set(ByVal value As String)
			name = value
		End Set
	End Property

	Public Property CommandString() As String
		Get
			Return command
		End Get
		Set(ByVal value As String)
			command = value
		End Set
	End Property

	Public Property isDefault() As Boolean
		Get
			Return is_default
		End Get
		Set(ByVal value As Boolean)
			is_default = value
		End Set
	End Property

	Public Sub New(ByVal _name As String, ByVal _command As String, Optional ByVal _id As Object = Nothing, Optional ByVal _default As Boolean = False)
		If TypeOf _id Is Nullable(Of Int64) Then
			id = _id
		End If
		name = _name
		command = """" + _command.Trim(""""c) + """"	' necessary because IE does not quote itself while others do
		is_default = _default

		'%1 will be replaced by the URL.
		If Not command.IndexOf("%1") > 0 Then
			command = command + " ""%1"""
		End If
	End Sub

	Public Function IsComplete() As Boolean
		Return (id IsNot Nothing AndAlso name IsNot Nothing AndAlso command IsNot Nothing)
	End Function

	Public Overloads Function Equals(ByVal other As Browser) As Boolean
		If Me.FriendlyName = other.FriendlyName AndAlso Me.CommandString = other.CommandString Then
			Return True
		Else
			Return False
		End If
	End Function
End Class
