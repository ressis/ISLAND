Public Class Browser
	Private id As Nullable(Of Int64) = Nothing
	Private name As String = Nothing
	Private command As String = Nothing
	Private is_default As Boolean = False

	Private Shared nextID As Int64 = 0

	Public ReadOnly Property DB_ID() As Nullable(Of Int64)
		Get
			Return id
		End Get
	End Property

	Public ReadOnly Property FriendlyName() As String
		Get
			Return name
		End Get
	End Property

	Public ReadOnly Property CommandString() As String
		Get
			Return command
		End Get
	End Property

	Public ReadOnly Property isDefault() As Boolean
		Get
			Return is_default
		End Get
	End Property

	Public Shared ReadOnly Property GetUniqueID() As Int64
		Get
			Dim tmp_id As Int64 = nextID
			nextID += 1
			Return tmp_id
		End Get
	End Property

	Public Sub New(ByVal _name As String, ByVal _command As String, Optional ByVal _id As Object = Nothing, Optional ByVal _default As Boolean = False)
		If TypeOf _id Is Nullable(Of Int64) Then
			id = _id
		End If
		name = _name
		command = _command
		is_default = _default

		If id IsNot Nothing AndAlso id > nextID Then
			nextID = id + 1
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
