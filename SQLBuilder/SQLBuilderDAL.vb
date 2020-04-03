'**********************************************************************************************************
' DAL (Data Access Layer) Code Template
'**********************************************************************************************************
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class SQLBuilderDAL

    Function GetHeaderList(ConnectString As String) As DataTable
        Dim cn As New OdbcConnection(ConnectString)
        Dim SQLStatement As String

        GetHeaderList = Nothing
        SQLStatement = "SELECT " &
            "trim(DatasetName) as ""DataSet Name"", " &
            "trim(DataSetHeaderText) as ""DataSet Header Text"", " &
            "trim(Tablename) as ""Tablename"", " &
            "trim(AuthorityFlag) as ""Authority Flag"", " &
            "trim(CRTuserID) as ""CRT userID"", " &
            "CRTTIMESTAMP as ""CRT Timestamp"", " &
            "UPDUserID as ""UPD UserID"", " &
            "UPDTimestamp as ""UPD Timestamp"", " &
            "DatasetID " &
            "FROM ebi7020t " &
            "ORDER BY DatasetID"
        Try
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New OdbcDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try

    End Function

    Function GetColumns(ConnectString As String, DatasetID As Integer) As DataTable
        Dim cn As New OdbcConnection(ConnectString)
        Dim SQLStatement As String

        GetColumns = Nothing
        SQLStatement = "SELECT " &
            "trim(ColumnName) as ""Column Name"", " &
            "trim(ColumnText) as ""Column Text"" " &
            "FROM ebi7023t " &
            "Where DatasetID= " & DatasetID & " " &
            "ORDER BY Sequence"
        Try
            cn.Open()
            Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New OdbcDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try

    End Function

    Function GetColumnsMYSQL(DatasetID As Integer) As DataTable
        Dim ConnString As String
        Dim myDR As MySqlDataReader = Nothing
        Dim SQLStatement As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        GetColumnsMYSQL = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            SQLStatement = "SELECT " &
            "trim(ColumnName) as ""Column Name"", " &
            "trim(ColumnText) as ""Column Text"" " &
            "FROM ebi7023t " &
            "Where DatasetID= " & DatasetID & " " &
            "ORDER BY Sequence"

            Dim cmd As New MySqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try

    End Function

    Function GetHeaderListMYSQL() As DataTable
        Dim ConnString As String
        Dim SQLStatement As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        GetHeaderListMYSQL = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            SQLStatement = "SELECT " &
            "trim(DatasetName) as ""DataSet Name"", " &
            "trim(DataSetHeaderText) as ""DataSet Header Text"", " &
            "trim(Tablename) as ""Tablename"", " &
            "trim(AuthorityFlag) as ""Authority Flag"", " &
            "trim(CRTuserID) as ""CRT userID"", " &
            "trim(CRTTIMESTAMP) as ""CRT Timestamp"", " &
            "trim(UPDUserID) as ""UPD UserID"", " &
            "trim(UPDTimestamp) as ""UPD Timestamp"", " &
            "DatasetID " &
            "FROM ebi7020t " &
            "ORDER BY DatasetID"

            Dim cmd As New MySqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("DB ERROR: " & ex.Message)
        End Try

    End Function
End Class
