Public Class myGlobals
    Private _myConnectionString As String
    Private _WhereConditions As String
    Private _myServer As String
    Private _myDatabase As String
    Private _myUsername As String
    Private _myPassword As String
    Private _myPort As String

    Public Property myConnectionString As String
        Get
            Return _myConnectionString
        End Get
        Set(value As String)
            _myConnectionString = value
        End Set
    End Property

    Public Property GetMyWhereCondtions As String
        Get
            Return _WhereConditions
        End Get
        Set(value As String)
            _WhereConditions = value
        End Set
    End Property

    Public Property myServer As String
        Get
            Return _myServer
        End Get
        Set(value As String)
            _myServer = value
        End Set
    End Property

    Public Property myDatabase As String
        Get
            Return _myDatabase
        End Get
        Set(value As String)
            _myDatabase = value
        End Set
    End Property

    Public Property myUsername As String
        Get
            Return _myUsername
        End Get
        Set(value As String)
            _myUsername = value
        End Set
    End Property

    Public Property myPassword As String
        Get
            Return _myPassword
        End Get
        Set(value As String)
            _myPassword = value
        End Set
    End Property

    Public Property myPort As String
        Get
            Return _myPort
        End Get
        Set(value As String)
            _myPort = value
        End Set
    End Property

End Class
