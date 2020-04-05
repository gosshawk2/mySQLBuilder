'**********************************************************************************************************
' DAL (Data Access Layer) Code Template
'**********************************************************************************************************
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class SQLBuilderDAL

    Function setupMySQLconnection(ByVal Server As String, ByVal DbaseName As String, ByVal USERNAME As String,
                                    ByVal password As String, ByVal port As String, ByRef Message As String) As String
        'Dim DatabaseName As String = "assetregister"
        'Dim server As String = "localhost"
        'Dim Port As String = "6080"
        'Dim User as String = "root"
        'Dim Values(,) As String
        Dim conn As MySqlConnection
        Dim myCMD As MySqlCommand
        Dim myDR As MySqlDataReader
        Dim Output As String
        Dim ZeroDatetime As Boolean

        Output = ""
        conn = New MySqlConnection()
        If Not conn Is Nothing Then conn.Close()
        ZeroDatetime = True
        'Output = String.Format("server={0}; user id={1}; password={2}; database={3}; port={4}; pooling=false; Convert Zero Datetime=True; Allow Zero Datetime=True;", Server, USERNAME, password, DbaseName, port)
        'Output = String.Format("server={0}; user id={1}; password={2}; database={3}; port={4}; pooling=false; convert zero datetime=True", Server, USERNAME, password, DbaseName, port)
        Output = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
        conn.ConnectionString = Output
        Try
            conn.Open()
            'myCMD = New MySqlCommand(SQLstr, conn)
            'myDR = myCMD.ExecuteReader()
            'While myDR.Read
            'values() = myDR(fieldname).ToString()
            'End While
            'MsgBox("Connected")
        Catch ex As Exception
            'MsgBox("Error in setupMySQLconnection: " & ex.Message)
            Message = "Error in setupMySQLconnection: " & ex.Message
            'frmMain.logger.LogError("AR_Error_v2_7.log", Application.StartupPath, Message, "setupMySQLconnection()", frmMain.GetComputerName() & "," & frmMain.GetIPv4Address() & "," & frmMain.GetIPv6Address() & ", OPERATOR Logged in:" & frmMain.myUsername)
            'frmMain.logger.logmessage("AR_messages_v2.7.log", Application.StartupPath, Message, "CONNECTION to DB NOT SUCCESSFUL, Server=" & Server & ",DB Name= " & DbaseName & ", Username: " & USERNAME & ", Port= " & port)
        End Try
        conn.Close()

        setupMySQLconnection = Output

    End Function

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
            "trim(ColumnName) as ""Column_Name"", " &
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

    Function Get_Total_Rows_From_CSVFile(CSVFilename As String, Optional ByRef TotalFields As Long = 0) As Long
        Dim rownum As Long
        Dim TotalRows As Long
        Dim wholeRows As String()

        Using csvReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CSVFilename)
            csvReader.TextFieldType = FileIO.FieldType.Delimited
            csvReader.SetDelimiters(",")
            TotalRows = 0
            rownum = 0
            While Not csvReader.EndOfData
                Try
                    wholeRows = csvReader.ReadFields()

                    TotalFields = wholeRows.Length
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is NOT valid and will be skipped.")
                End Try
                rownum = rownum + 1
            End While

        End Using
        TotalRows = rownum
        Get_Total_Rows_From_CSVFile = TotalRows
    End Function

    Function CSVFileToArray(ByRef NewstrArray As String(,), ByVal CSVFilename As String, ByRef TotalFields As Long,
                            ByRef Message As String) As Long
        '****************************************************
        '
        'AUTHOR : DANIEL GOSS . COPYRIGHT 24-FEB-2017. V1.2
        'MODIFIED: DANIEL GOSS . COPYRIGHT 01-SEP-2017. v1.3
        ' - added extra parameter - Messages
        'MODIFIED: DANIEL GOSS . COPYRIGHT 03-SEP-2017. v1.4 now.
        ' - removed extra parameter - Messages
        ' - removed reference to GetFieldValue_From_Index below.
        ' - added error logging and message logging 12-09-2017 01:50
        '*****************************************************

        Dim wholeRows As String()
        Dim numRowsRead As Long
        Dim colnum As Long
        Dim RowNum As Long
        Dim currentFields As String
        Dim Percentage As Long
        Dim TotalRows As Long
        Dim RowMessage As String
        Dim messages As String

        ReDim NewstrArray(1, 1)
        CSVFileToArray = 0
        numRowsRead = 0
        colnum = 0
        RowNum = 0
        messages = ""
        ReDim wholeRows(1)
        wholeRows(0) = ""
        'ProgressBarControl.Maximum = 100
        'ProgressBarControl.Value = 0
        'ProgressLabel.Text = "0%"
        'Import from CSV File TEXT field and check validity:
        Try
            Using csvReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CSVFilename)
                csvReader.TextFieldType = FileIO.FieldType.Delimited
                csvReader.SetDelimiters(",")
                TotalRows = Get_Total_Rows_From_CSVFile(CSVFilename, TotalFields)
                ReDim NewstrArray(TotalFields, TotalRows)
                'frmProgressBar.Show()
                While Not csvReader.EndOfData
                    Try
                        wholeRows = csvReader.ReadFields()
                        colnum = 0
                        For Each currentFields In wholeRows
                            If TotalRows > 0 Then
                                Percentage = CLng((RowNum / TotalRows) * 100)
                            Else
                                Percentage = 0
                            End If
                            RowMessage = "Read " & CStr(RowNum) & " ROW / " & CStr(TotalRows) & " ROWS"
                            NewstrArray(colnum, RowNum) = currentFields

                            Application.DoEvents()

                            colnum = colnum + 1
                        Next
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        If Len(messages) > 0 Then
                            messages = messages & ","
                        End If
                        messages = messages & " Line " & ex.Message & "is NOT valid and will be skipped."
                        Message = messages
                        'frmMain.logger.LogMessage("NMS_" & frmMain.myVersion & ".log", Application.StartupPath, Message, frmMain.GetComputerName() & "," & frmMain.GetIPv4Address() & "," & frmMain.GetIPv6Address() & ", OPERATOR Logged in:" & frmMain.myUsername)
                    End Try
                    RowNum = RowNum + 1
                End While
            End Using
        Catch ex As Exception
            Message = "Error In CSVFileToArray: " & ex.Message.ToString
            'frmMain.logger.LogError("NMS_" & frmMain.myVersion & ".log", Application.StartupPath, Message, "GetFieldValue_From_Index()", frmMain.GetComputerName() & "," & frmMain.GetIPv4Address() & "," & frmMain.GetIPv6Address() & ", OPERATOR Logged in:" & frmMain.myUsername)
        End Try
        numRowsRead = RowNum
        'currentRow is an array containing all the data now.
        'Me.rtbOutput.Text = ""
        'frmProgressBar.Hide()
        CSVFileToArray = numRowsRead
    End Function

    Function GetTablesFromDB(DBName As String) As DataTable
        Dim SQLStatement As String
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        GetTablesFromDB = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()

            SQLStatement = "SELECT DISTINCT TABLE_NAME " &
            "FROM INFORMATION_SCHEMA.COLUMNS " &
            "WHERE  TABLE_SCHEMA='" & DBName & "';"

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
            MsgBox("DB ERROR in GetTablesFromDB: " & ex.Message)
        End Try

    End Function

    Function GetFieldsFromTable(Tablename As String) As DataTable
        Dim SQLStatement As String
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        GetFieldsFromTable = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()

            SQLStatement = "SELECT DISTINCT COLUMN_NAME " &
            "FROM INFORMATION_SCHEMA.COLUMNS " &
            "WHERE  TABLE_NAME='" & Tablename & "';"

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
            MsgBox("DB ERROR in GetTablesFromDB: " & ex.Message)
        End Try

    End Function

    Function ExecuteQuery(DBName As String, SQLStatement As String) As DataTable
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "simplequerybuilder"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        ExecuteQuery = Nothing
        Try
            'ConnString = setupMySQLconnection("localhost", "simplequerybuilder", "root", "root", "3306", ErrMessage)
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            SQLStatement = "Use " & DBName & "; " & SQLStatement
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
            MsgBox("DB ERROR in ExecuteQuery: " & ex.Message)
        End Try

    End Function

End Class
