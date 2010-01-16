Public Class Browser
	Private id As Nullable(Of Int64) = Nothing
	Private name As String = Nothing
	Private command As String = Nothing

	Public Sub New(ByVal _id As Int64, ByVal _name As String, ByVal _command As String)
		id = _id
		name = _name
		command = _command
	End Sub

	Public Function IsComplete() As Boolean
		Return (id IsNot Nothing AndAlso name IsNot Nothing AndAlso command IsNot Nothing)
	End Function
End Class
