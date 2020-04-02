Public Class myGlobals
    Private _WhereConditions As String

    Public Property GetMyWhereCondtions As String
        Get
            Return _WhereConditions
        End Get
        Set(value As String)
            _WhereConditions = value
        End Set
    End Property
End Class
