Public Class Browser
	Implements System.Collections.Generic.IEqualityComparer(Of Browser)
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
		is_default = _default

		'%1 will be replaced by the URL.
		If Not _command.IndexOf("%1") > 0 Then
			command = """" + _command.Trim(""""c) + """ ""%1"""
			' necessary because IE does not quote itself while others do
			'also ensure that all commands have a %1 to replace.
		Else
			'if a %1 is present, take the command at face value
			command = _command
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

	Public Overrides Function toString() As String
		Return FriendlyName
	End Function

	Public Function AreEqual(ByVal x As Browser, ByVal y As Browser) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of Browser).Equals
		Return x.Equals(y)
	End Function

	Public Overloads Function GetHashCode(ByVal obj As Browser) As Integer Implements System.Collections.Generic.IEqualityComparer(Of Browser).GetHashCode
		Return (obj.FriendlyName + obj.CommandString).GetHashCode
	End Function

	Public Overrides Function GetHashCode() As Integer
		Return (FriendlyName + CommandString).GetHashCode
	End Function
End Class
