Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    'Global variables

    'Variable to track the current cycle
    'initialize variable to known value "0"
    Public vCycle As Integer = 1

    'variable to track current notification setting
    'initialize variable to known value "None"
    Public vNotice As String = "None"

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        'Error Handling
        Try

            'variable to capture result of MessageBox
            Dim vMsgBox As DialogResult
            'give the user a choice to cancel this action
            'Message box accepts [user input], OKCancel
            vMsgBox = MessageBox.Show("This action will erase the data you have." & vbCrLf & "Then it will pull in new data from Billmaster", "Billmaster Update...", MessageBoxButtons.OKCancel)

            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'OK [user input]

                '[TO DO] Once I figure out how to connect to a sql database I should set it up as a class. &_
                'but I won't worry about it until I get better at coding this stuff.

                'hold the filename from openFileDialog() 
                Dim fName As String = ""

                'Code modified from OpenFileDialog (http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx)
                'declare FileStream to access file I/O
                Dim myStream As FileStream

                'assign value to newly created FIlestream instance
                myStream = Nothing

                'declare OpenFileDialog
                Dim fOpen As New OpenFileDialog()

                '[TO DO] Before Build change Initial Directory to                                                                                       
                '[NOTES] The import file cannot have column headers. Currently the file has headers
                'Current Name of the Billmaster Export File - "F:\Tre Query Exports\Door Hanger DB\DoorHanger_v2_Export.TXT"                    
                'fOpen.InitialDirectory = "F:\Tre Query Exports\Door Hanger DB\DoorHanger_v2_Export.TXT"                                        
                fOpen.InitialDirectory = "D:\OneDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS DB Project\OLD_Access DB files\"

                'filter to txt or csv files
                fOpen.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*"

                'list starts at 1, this sets FilterIndex to "*.csv" files
                fOpen.FilterIndex = 2

                'Any changes to directory while dialog is open are reset to original state.
                fOpen.RestoreDirectory = True

                'Accept [user input] from dialog, OK or CANCEL
                If fOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                    'Open file, read data contained inside to filestream
                    myStream = fOpen.OpenFile()

                    'If filestream is NOT EMPTY proceed processing
                    If (myStream IsNot Nothing) Then

                        'capture selected filename, not the path
                        fName = fOpen.FileName

                        'declare variable to accept text from filestream
                        Dim TextLine As String

                        'declare variable for Split String function
                        Dim SplitLine() As String

                        'declares streamreader which inherits textreader for fName, allowing file to be read from the filestream (myStream)
                        Dim objReader As New System.IO.StreamReader(fName)

                        '===START - SQL OPEN CODE===
                        'open sql connection

                        'declare connectionstring as variable so it easier to work with
                        Dim connectionString As String = ""

                        'TEMP connection string, I don't know how to access this information from the correct object
                        '[TO DO] learn what object has this information so I can get it dynamically from the application
                        '[DEBUG] I need to find out if this is necessary. Since I am using a typed dataset this step might be superfluous. But it works now so I am going to leave it alone at the moment.
                        connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=""D:\OneDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS Project\FCLWD-DoorHangerApp\FCLWD-DoorHangerApp\DHA_sample.mdf"";Integrated Security=True;Connect Timeout=30"
                        'connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30"

                        'declare instance of sqlconnection= (connectionstring), Using will close the connection once code completes execution
                        Using vDhConn As SqlConnection = New SqlConnection(connectionString)

                            'open connection to sql, passing filename in connectionstring variable
                            vDhConn.Open()
                            '===END - SQL OPEN CODE===

                            '===START - Clear current tblShutOff Data===

                            'I don't understand the following code
                            'using this link to help me http://msdn.microsoft.com/en-us/library/ms233823.aspx
                            'delete all data in tblShutOff one row at a time
                            If DhA_sampleDataSet1.tblShutOff.Rows.Count = 0 Then

                                'Do nothing

                            Else

                                Do While Me.DhA_sampleDataSet1.tblShutOff.Rows.Count <> 0

                                    'define dataset
                                    Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblShutOff.Rows(0)

                                    'delete row
                                    vDeleteRow.Delete()

                                    'notify database of delete
                                    Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)

                                Loop

                            End If
                            '===END - clear current tblShutOff Data===

                            '===START - Clear current tblWorkingData data===

                            'I don't understand the following code
                            'using this link to help me http://msdn.microsoft.com/en-us/library/ms233823.aspx
                            'delete all data in tblWorkingData one row at a time
                            If DhA_sampleDataSet1.tblWorkingData.Rows.Count = 0 Then

                                'Do nothing

                            Else

                                Do While Me.DhA_sampleDataSet1.tblWorkingData.Rows.Count <> 0

                                    'define dataset
                                    Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                                    'delete row
                                    vDeleteRow.Delete()

                                    'notify database of delete
                                    Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)

                                Loop

                            End If
                            '===END - clear current tblWorkingData data===

                            Do While objReader.Peek() <> -1
                                '===START-Read CSV into tblShutOff===
                                'object to accept SplitLine variable data after it is converted
                                Dim v(24) As Object

                                'CSV file data, line by line
                                TextLine = objReader.ReadLine()

                                'CSV file data after parse
                                '[DEBUG]- this breaks on text data that has a comma. 
                                '[DEBUG continued]- Need to pull the data better. Look for quotes that separate text so it doesn't break.
                                SplitLine = Split(TextLine, ",")

                                Dim i As Integer = 0

                                Do While i < DhA_sampleDataSet1.tblShutOff.Columns.Count

                                    v(i) = SplitLine(i)

                                    Select Case i

                                        Case 1, 2, 3, 4, 5, 6, 7, 13, 18, 19
                                            '"System.Decimal", convert all decimals and assign to proper column
                                            'declare variable to accept converted Decimal data
                                            Dim vDecimal As Decimal
                                            'set variable to known value
                                            vDecimal = 1.0

                                            'pass string data and convert it for variable to accept
                                            vDecimal = System.Convert.ToDecimal(v(i))

                                            'end system.decimal conversion

                                            v(i) = vDecimal

                                        Case 0, 8, 9, 10, 20, 21, 22, 23, 24
                                            'No Conversion necessary at this time

                                            v(i) = SplitLine(i)

                                        Case 11, 14
                                            'declare variable to accept converted Int32 data
                                            Dim vInt32 As Int32
                                            'set variable to known value
                                            vInt32 = 0

                                            'pass string data and convert it for variable to accept
                                            vInt32 = System.Convert.ToInt32(v(i))

                                            v(i) = vInt32

                                        Case 12, 15, 16, 17
                                            'declare variable to accept converted date
                                            Dim vDate As Date

                                            'set variable to known value
                                            '[TO DO] BUT I am not sure how to type a value for this variable, Date = ??? 
                                            'pass string data and convert it for variable to accept
                                            vDate = Convert.ToDateTime(v(i))

                                            'end system.DateTime conversion
                                            v(i) = vDate

                                    End Select
                                    i = i + 1
                                Loop

                                'v(0) =  tblShutOff.[soAccount] VARCHAR(11) NOT NULL PRIMARY KEY,                  
                                'v(1) =  tblShutOff.[soAge0] SMALLMONEY NULL,                                     
                                'v(2) =  tblShutOff.[soAge1] SMALLMONEY NULL,                                    
                                'v(3) =  tblShutOff.[soAge2] SMALLMONEY NULL,                                       
                                'v(4) =  tblShutOff.[soAge3] SMALLMONEY NULL,                                     
                                'v(5) =  tblShutOff.[soAge4] SMALLMONEY NULL,                                     
                                'v(6) =  tblShutOff.[soAge5] SMALLMONEY NULL,                                    
                                'v(7) =  tblShutOff.[soBal] SMALLMONEY NULL,                                     
                                'v(8) =  tblShutOff.[soName] VARCHAR(MAX) NULL,                                  
                                'v(9) =  tblShutOff.[soAddr] VARCHAR(MAX) NULL, 
                                'v(10) = tblShutOff.[soLoc] VARCHAR(MAX) NULL, 
                                'v(11) = tblShutOff.[soCycle] INT NULL, 
                                'v(12) = tblShutOff.[soLstPayDte] DATETIME2 NULL, 
                                'v(13) = tblShutOff.[soLstPayAmt] SMALLMONEY NULL, 
                                'v(14) = tblShutOff.[soStCde] INT NULL, 
                                'v(15) = tblShutOff.[soStCdeDte] DATETIME2 NULL, 
                                'v(16) = tblShutOff.[soAgreeDue] DATETIME2 NULL, 
                                'v(17) = tblShutOff.[soAgreeMade] DATETIME2 NULL, 
                                'v(18) = tblShutOff.[soPmtAgreed] SMALLMONEY NULL, 
                                'v(19) = tblShutOff.[soUnPmt] SMALLMONEY NULL, 
                                'v(20) = tblShutOff.[soPriRte] VARCHAR(MAX) NULL, 
                                'v(21) = tblShutOff.[soSecRte] VARCHAR(MAX) NULL, 
                                'v(22) = tblShutOff.[soPnotes] VARCHAR(MAX) NULL, 
                                'v(23) = tblShutOff.[soANotes] VARCHAR(MAX) NULL, 
                                'v(24) = tblShutOff.[soMNotes] VARCHAR(MAX) NULL

                                DhA_sampleDataSet1.tblShutOff.Rows.Add(v)
                                '===END-Read CSV into tblShutOff===
                            Loop

                            '===START - update tblWorkingData with tblShutOff data===
                            '[TO DO] - Append tblWorking data with new information
                            'WAITING FOR HELP ON THIS FROM (http://social.msdn.microsoft.com/Forums/en-US/ac65e096-c5e0-402d-b40b-fa7ff6bc1dcf/typed-dataset-in-vs-2013-insert-query?forum=adodotnetdataset)
                            '[TESTING ANSWER] - Suggested answer from forums
                            'QueriesTableAdapter da = new QueriesTableAdapter();
                            'int affectrows = da.InsertQuery();
                            'Me.TblWorkingDataTableAdapter.InsertTblSO("tblWorkingData")
                            'Me.TblWorkingDataTableAdapter.InsertTblSO()

                            'THOUGHTS - This is the full logic for and UPDATE and not the simpler IMPORT 
                            '1 - Move through tblShutOff rows using For Each loop, making sure to read all lines in tblShutOff
                            '2 - after reading each tblShutOff.Row, update/insert tblWorkingData.column.DataValue 
                            '     if tblShutOff.Row.DataValue is <> to tblWorkingData.Row.DataValue
                            '3 - If soAccount = wdAccount and Row(#).DataValue not equal then Update, 
                            '     If soAccount doesn't exist on the table then Insert row to tblWorkingData

                            'For Each Loop reads every row in tblShutOff, which is my important data
                            For Each vDataRow As DataRow In DhA_sampleDataSet1.tblShutOff.Rows

                                'maybe, create variable for new row
                                Dim vTblWDNewRow As DataRow = DhA_sampleDataSet1.tblWorkingData.NewRow()

                                'My idea of mapping table rows, each vTblWDNewRow(#) takes data from the other table
                                vTblWDNewRow(0) = vDataRow(0)
                                vTblWDNewRow(1) = vDataRow(1)
                                vTblWDNewRow(2) = vDataRow(2)
                                vTblWDNewRow(3) = vDataRow(3)
                                vTblWDNewRow(4) = vDataRow(4)
                                vTblWDNewRow(5) = vDataRow(5)
                                vTblWDNewRow(6) = vDataRow(6)
                                vTblWDNewRow(7) = vDataRow(7)
                                vTblWDNewRow(8) = vDataRow(8)
                                vTblWDNewRow(9) = vDataRow(9)
                                vTblWDNewRow(10) = vDataRow(10)
                                vTblWDNewRow(11) = vDataRow(11)
                                vTblWDNewRow(12) = vDataRow(12)
                                vTblWDNewRow(13) = vDataRow(13)
                                vTblWDNewRow(14) = vDataRow(14)
                                vTblWDNewRow(15) = "None"
                                vTblWDNewRow(16) = vDataRow(22)
                                vTblWDNewRow(17) = vDataRow(23)
                                vTblWDNewRow(18) = vDataRow(24)
                                vTblWDNewRow(19) = 0
                                vTblWDNewRow(20) = 0
                                vTblWDNewRow(21) = #1/1/1900#
                                vTblWDNewRow(22) = #1/1/1900#
                                vTblWDNewRow(23) = #1/1/1900#
                                vTblWDNewRow(24) = vDataRow(16)
                                vTblWDNewRow(25) = vDataRow(18)
                                vTblWDNewRow(26) = vDataRow(19)
                                vTblWDNewRow(27) = vDataRow(20)
                                vTblWDNewRow(28) = vDataRow(21)
                                vTblWDNewRow(29) = vDataRow(15)
                                vTblWDNewRow(30) = vDataRow(17)

                                'wdAccount  := DhA_sampleDataSet1.tblShutOff.Rows(0)  , 
                                'wdAge0     := DhA_sampleDataSet1.tblShutOff.Rows(1)  , 
                                'wdAge1     := DhA_sampleDataSet1.tblShutOff.Rows(2)  , 
                                'wdAge2     := DhA_sampleDataSet1.tblShutOff.Rows(3)  , 
                                'wdAge3     := DhA_sampleDataSet1.tblShutOff.Rows(4)  , 
                                'wdAge4     := DhA_sampleDataSet1.tblShutOff.Rows(5)  , 
                                'wdAge5     := DhA_sampleDataSet1.tblShutOff.Rows(6)  , 
                                'wdBal      := DhA_sampleDataSet1.tblShutOff.Rows(7)  , 
                                'wdName     := DhA_sampleDataSet1.tblShutOff.Rows(8)  , 
                                'wdAddr     := DhA_sampleDataSet1.tblShutOff.Rows(9)  , 
                                'wdLoc      := DhA_sampleDataSet1.tblShutOff.Rows(10)  , 
                                'wdCycle    := DhA_sampleDataSet1.tblShutOff.Rows(11)  , 
                                'wdLstPayDte:= DhA_sampleDataSet1.tblShutOff.Rows(12)  , 
                                'wdLstPayAmt:= DhA_sampleDataSet1.tblShutOff.Rows(13)  , 
                                'wdStCde    := DhA_sampleDataSet1.tblShutOff.Rows(14)  , 
                                'wdStDesc   := "None"  , 
                                'wdPnotes   := DhA_sampleDataSet1.tblShutOff.Rows(22)  , 
                                'wdANotes   := DhA_sampleDataSet1.tblShutOff.Rows(23)  , 
                                'wdMNotes   := DhA_sampleDataSet1.tblShutOff.Rows(24)  , 
                                'wdTerm     := 0  , 
                                'wdHang     := 0  , 
                                'wdHangDte  := #1/1/1900#  , 
                                'wdCntDte   := #1/1/1900#  , 
                                'wdTermDte  := #1/1/1900#  , 
                                'wdAgreeDue := DhA_sampleDataSet1.tblShutOff.Rows(16)  , 
                                'wdPmtAgreed:= DhA_sampleDataSet1.tblShutOff.Rows(18)  , 
                                'wdUnPmt    := DhA_sampleDataSet1.tblShutOff.Rows(19)  , 
                                'wdPriRte   := DhA_sampleDataSet1.tblShutOff.Rows(20)  , 
                                'wdSecRte   := DhA_sampleDataSet1.tblShutOff.Rows(21)  , 
                                'wdStCdeDte := DhA_sampleDataSet1.tblShutOff.Rows(15)  , 
                                'wdAgreeMade:= DhA_sampleDataSet1.tblShutOff.Rows(17)  

                                'add new row to tblWorkingData, loop through until all data copied
                                DhA_sampleDataSet1.tblWorkingData.Rows.Add(vTblWDNewRow)

                            Next vDataRow

                            'v(0) =  tblWorkingData.[wdAccount] NCHAR(11) NOT NULL PRIMARY KEY,| v(0) =  tblShutOff.[soAccount] VARCHAR(11) NOT NULL PRIMARY KEY,
                            'v(1) =  tblWorkingData.[wdAge0] SMALLMONEY NULL,                  | v(1) =  tblShutOff.[soAge0] SMALLMONEY NULL,                    
                            'v(2) =  tblWorkingData.[wdAge1] SMALLMONEY NULL,                  | v(2) =  tblShutOff.[soAge1] SMALLMONEY NULL,                    
                            'v(3) =  tblWorkingData.[wdAge2] SMALLMONEY NULL,                  | v(3) =  tblShutOff.[soAge2] SMALLMONEY NULL,                    
                            'v(4) =  tblWorkingData.[wdAge3] SMALLMONEY NULL,                  | v(4) =  tblShutOff.[soAge3] SMALLMONEY NULL,                    
                            'v(5) =  tblWorkingData.[wdAge4] SMALLMONEY NULL,                  | v(5) =  tblShutOff.[soAge4] SMALLMONEY NULL,                    
                            'v(6) =  tblWorkingData.[wdAge5] SMALLMONEY NULL,                  | v(6) =  tblShutOff.[soAge5] SMALLMONEY NULL,                    
                            'v(7) =  tblWorkingData.[wdBal] SMALLMONEY NULL,                   | v(7) =  tblShutOff.[soBal] SMALLMONEY NULL,                     
                            'v(8) =  tblWorkingData.[wdName] VARCHAR(MAX) NULL,                | v(8) =  tblShutOff.[soName] VARCHAR(MAX) NULL,                  
                            'v(9) =  tblWorkingData.[wdAddr] VARCHAR(MAX) NULL,                | v(9) =  tblShutOff.[soAddr] VARCHAR(MAX) NULL,                  
                            'v(10) = tblWorkingData.[wdLoc] VARCHAR(MAX) NULL,                 | v(10) = tblShutOff.[soLoc] VARCHAR(MAX) NULL,                   
                            'v(11) = tblWorkingData.[wdCycle] INT NULL,                        | v(11) = tblShutOff.[soCycle] INT NULL,                          
                            'v(12) = tblWorkingData.[wdLstPayDte] DATETIME2 NULL,              | v(12) = tblShutOff.[soLstPayDte] DATETIME2 NULL,                
                            'v(13) = tblWorkingData.[wdLstPayAmt] SMALLMONEY NULL,             | v(13) = tblShutOff.[soLstPayAmt] SMALLMONEY NULL,               
                            'v(14) = tblWorkingData.[wdStCde] INT NULL,                        | v(14) = tblShutOff.[soStCde] INT NULL,                          
                            'v(15) = tblWorkingData.[wdStDesc] VARCHAR(30) NULL,               |                
                            'v(16) = tblWorkingData.[wdPnotes] VARCHAR(MAX) NULL,              | v(22) = tblShutOff.[soPnotes] VARCHAR(MAX) NULL,                
                            'v(17) = tblWorkingData.[wdANotes] VARCHAR(MAX) NULL,              | v(23) = tblShutOff.[soANotes] VARCHAR(MAX) NULL,                
                            'v(18) = tblWorkingData.[wdMNotes] VARCHAR(MAX) NULL,              | v(24) = tblShutOff.[soMNotes] VARCHAR(MAX) NULL                 
                            'v(19) = tblWorkingData.[wdTerm] BIT NOT NULL,                     |                
                            'v(20) = tblWorkingData.[wdHang] BIT NOT NULL,                     |                
                            'v(21) = tblWorkingData.[wdHangDte] DATETIME2 NULL,                |                
                            'v(22) = tblWorkingData.[wdCntDte] DATETIME2 NULL,                 |                
                            'v(23) = tblWorkingData.[wdTermDte] DATETIME2 NULL,                |                
                            'v(24) = tblWorkingData.[wdAgreeDue] DATETIME2 NULL,               | v(16) = tblShutOff.[soAgreeDue] DATETIME2 NULL,               
                            'v(25) = tblWorkingData.[wdPmtAgreed] SMALLMONEY NULL,             | v(18) = tblShutOff.[soPmtAgreed] SMALLMONEY NULL,
                            'v(26) = tblWorkingData.[wdUnPmt] SMALLMONEY NULL,                 | v(19) = tblShutOff.[soUnPmt] SMALLMONEY NULL, 
                            'v(27) = tblWorkingData.[wdPriRte] VARCHAR(30) NULL,               | v(20) = tblShutOff.[soPriRte] VARCHAR(MAX) NULL,
                            'v(28) = tblWorkingData.[wdSecRte] VARCHAR(30) NULL,               | v(21) = tblShutOff.[soSecRte] VARCHAR(MAX) NULL,
                            'v(29) = tblWorkingData.[wdStCdeDte] DATETIME2 NULL,               | v(15) = tblShutOff.[soStCdeDte] DATETIME2 NULL, 
                            'v(30) = tblWorkingData.[wdAgreedMade] Datetime2 null              | v(17) = tblShutOff.[soAgreeMade] DATETIME2 NULL,


                            'v(0) = [wdAccount] NCHAR(11) NOT NULL PRIMARY KEY, 
                            'v(1) = [wdAge0] SMALLMONEY NULL, 
                            'v(2) = [wdAge1] SMALLMONEY NULL, 
                            'v(3) = [wdAge2] SMALLMONEY NULL, 
                            'v(4) = [wdAge3] SMALLMONEY NULL, 
                            'v(5) = [wdAge4] SMALLMONEY NULL, 
                            'v(6) = [wdAge5] SMALLMONEY NULL, 
                            'v(7) = [wdBal] SMALLMONEY NULL, 
                            'v(8) = [wdName] VARCHAR(MAX) NULL, 
                            'v(9) = [wdAddr] VARCHAR(MAX) NULL, 
                            'v(10) = [wdLoc] VARCHAR(MAX) NULL, 
                            'v(11) = [wdCycle] INT NULL, 
                            'v(12) = [wdLstPayDte] DATETIME2 NULL, 
                            'v(13) = [wdLstPayAmt] SMALLMONEY NULL, 
                            'v(14) = [wdStCde] INT NULL, 
                            'v(15) = [wdStDesc] VARCHAR(30) NULL, 
                            'v(16) = [wdPnotes] VARCHAR(MAX) NULL, 
                            'v(17) = [wdANotes] VARCHAR(MAX) NULL, 
                            'v(18) = [wdMNotes] VARCHAR(MAX) NULL, 
                            'v(19) = [wdTerm] BIT NOT NULL, 
                            'v(20) = [wdHang] BIT NOT NULL, 
                            'v(21) = [wdHangDte] DATETIME2 NULL, 
                            'v(22) = [wdCntDte] DATETIME2 NULL, 
                            'v(23) = [wdTermDte] DATETIME2 NULL, 
                            'v(24) = [wdAgreeDue] DATETIME2 NULL, 
                            'v(25) = [wdPmtAgreed] SMALLMONEY NULL, 
                            'v(26) = [wdUnPmt] SMALLMONEY NULL, 
                            'v(27) = [wdPriRte] VARCHAR(30) NULL, 
                            'v(28) = [wdSecRte] VARCHAR(30) NULL, 
                            'v(29) = [wdStCdeDte] DATETIME2 NULL,
                            'v(30) = [wdAgreeMade] DATETIME2 NULL
                            '===END - update tblWorkingData with tblShutOff data===

                            '===START- UPDATE TBLWORKINGDATA WITH CODE DESCRIPTIONS===

                            'update tblWorkingData.wdStDesc where tblWorkingData.wdStCde is not null "IsNotNull"
                            'filling in descriptions for all the fields where there is a Code, 


                            'Loop through the table
                            For Each vDataRow As DataRow In DhA_sampleDataSet1.tblWorkingData.Rows()

                                'If the wdStCde is not Null then update the wdStDesc
                                If vDataRow(14) IsNot DBNull.Value Then

                                    'declare variable for CodeValue
                                    Dim vtblCodeValue As Integer

                                    'set value for CodeValue
                                    vtblCodeValue = vDataRow(14)

                                    'declare variable for StDesc
                                    Dim vTblCodesDescription As String

                                    'set variable to known value
                                    vTblCodesDescription = "Default"

                                    'declare datarow for query
                                    Dim vTblCdeRow As DataRow
                                    vTblCdeRow = DhA_sampleDataSet1.tblCodes.Rows(0)

                                    'get CodeDescription by CodeValue then load value into variable
                                    vTblCdeRow = DhA_sampleDataSet1.tblCodes.FindByCodeValue(vtblCodeValue)

                                    'Test for empty row with no value. The user needs to import new values if they get this error.
                                    If vTblCdeRow Is Nothing Then

                                        'set to a known value
                                        vTblCodesDescription = "Update Codes from Billmaster"

                                        'inform user they should update the tblCodes from Billmaster
                                        MessageBox.Show("Please update Status Codes from Billmaster." & vbCrLf & "Some newly added Status Codes are missing." & vbCrLf & "Contact Tre' Grisby (trewaters@hotmail.com) with any questions", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                    Else

                                        'set variable to CodeDescription
                                        vTblCodesDescription = vTblCdeRow("CodeDescription")

                                    End If

                                    'load tblWorkingData row/column with StDesc String
                                    vDataRow(15) = vTblCodesDescription

                                Else

                                    'Do nothing

                                End If

                            Next vDataRow

                            '===END===

                            '===START-UPDATE tblDateLog.dlNew with date===
                            'update tblDateLog with import date, marking all cycles
                            'Run update query adding current time
                            Me.TblDateLogTableAdapter.FillByUpdateNow("" & Now() & "")

                            'when following line of code is added txtdlUpdate shows the newly added date
                            'fill table with new data
                            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

                            '[NOTES] - not sure if I will change the lbldlUpdate field since ".bold" is a read only property and
                            'I have added text to  "lblUserNotification.Text" which notifies the user.
                            'highlight this field (lbldlUpdate) so the user knows it was updated. Maybe add Bold or change caption to "Update Completed"

                            '===END===

                            'Using closes the connection when it hits End Using
                            'vDhConn.

                            '===START - Update tblDateLog so information is saved to db table===
                            'Trying to update database when the import action is processed
                            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                            Me.Validate()
                            Me.TblDateLogBindingSource.EndEdit()
                            Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
                            '===END - Update tblDateLog so information is saved to db table===

                            '===START - Update tblShutOff so information is saved to db table===
                            'Trying to update database when the import action is processed
                            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                            Me.Validate()
                            Me.TblShutOffBindingSource.EndEdit()
                            Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
                            '===END - Update tblShutOff so information is saved to db table===


                            '===START - Update tblWorkingData so information is saved to db table===
                            'Trying to update database when the import action is processed
                            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                            Me.Validate()
                            Me.TblWorkingDataBindingSource.EndEdit()
                            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
                            '===END - Update tblWorkingData so information is saved to db table===

                        End Using

                        'update user that "Get Billmaster Data has completed"
                        MessageBox.Show("Finished updating from Billmaster. Please remember to save your data.")

                        '[TO DO]
                        'change (lblUserNotification.Text), message that informs user of last action
                        lblUserNotification.Text = "Billmaster data updated on " & Now()
                        'Bold text, I changed the color because bold is a READ ONLY property, not sure how to change it.
                        lblUserNotification.ForeColor = Color.Red
                        'Change borderStyle, trying to make the notification stand out more
                        lblUserNotification.BorderStyle = BorderStyle.Fixed3D

                    Else
                        'Notify user that file does not exist
                        MessageBox.Show("File is Empty. Please select another file.")

                    End If

                End If

            Else
                '[user input] Update Cancelled

                'msgBox to inform user
                MessageBox.Show("The Action has been cancelled!" & vbCrLf & "You have not changed anything.", "Billmaster Update Cancelled...", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'change (lblUserNotification.Text)
                lblUserNotification.Text = "Billmaster Update Cancelled..." & Now()

            End If

        Catch Ex As Exception
            MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)

        Finally

            ''[RESEARCH - Not sure if I need this. Having this commented out has not caused problems when I have errors.
            ''Check this again, since we need to make sure we didn't throw an exception on open. 
            'If (myStream IsNot Nothing) Then
            '    myStream.Close()
            'End If
            '[END RESEARCH]
        End Try

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click

        '===START-UPDATE CODE===
        '[NOTES] I changed the tableAdapter property ClearBeforeFill = False so I could keep the 2 lines of data I input and add the imported data to it. 
        'That could be changed programmatically depending on the action being executed. Like update should set that to false when starting.
        'First import should set that to True so all the data is erased and they can start over.


        '===END===

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'Error Handling
        Try

            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database before the user exits the program
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            Me.Validate()
            Me.TblWorkingDataBindingSource.EndEdit()
            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

        Catch ex As Exception

            MessageBox.Show("Unable to Close the form properly. (Form1_FormClosing) Original error: " & ex.Message)

        End Try
        
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblDateLog' table. You can move, or remove it, as needed.
            Me.TblDateLogTableAdapter.Fill(Me.DhA_sampleDataSet1.tblDateLog)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblWorkingData' table. You can move, or remove it, as needed.
            Me.TblWorkingDataTableAdapter.Fill(Me.DhA_sampleDataSet1.tblWorkingData)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblShutOff' table. You can move, or remove it, as needed.
            Me.TblShutOffTableAdapter.Fill(Me.DhA_sampleDataSet1.tblShutOff)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblCodes' table. You can move, or remove it, as needed.
            Me.TblCodesTableAdapter.Fill(Me.DhA_sampleDataSet1.tblCodes)

        Catch ex As Exception

            MessageBox.Show("Form1_Load error. Original error: " & ex.Message)

        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Try

            'Close or Exit the application
            Me.Close()

        Catch ex As Exception

            MessageBox.Show("Unable to exit application properly. (ExitToolStripMenuItem_Click) Original error: " & ex.Message)

        End Try

    End Sub


    Private Sub rdoBtnCycle1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle1.CheckedChanged
        'Error Handling
        Try
            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle1.Checked = True Then
                'Change the cycles value
                vCycle = 1


            End If

            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle1_CheckedChanged) Original error: " & ex.Message)

        End Try

    End Sub

    Private Sub rdoBtnCycle2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle2.CheckedChanged
        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle2.Checked = True Then
                'Change the cycles value
                vCycle = 2

            End If

            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle2_CheckedChanged) Original error: " & ex.Message)

        End Try

    End Sub

    Private Sub rdoBtnCycle3_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle3.CheckedChanged
        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle3.Checked = True Then
                'Change the cycles value
                vCycle = 3

            End If

            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle3_CheckedChanged) Original error: " & ex.Message)

        End Try

    End Sub

    Private Sub rdoBtnCycle4_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle4.CheckedChanged
        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle4.Checked = True Then
                'Change the cycles value
                vCycle = 4

            End If

            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle4_CheckedChanged) Original error: " & ex.Message)

        End Try

    End Sub

    Private Sub rdoBtnDH_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnDH.CheckedChanged
        'Error Handling
        Try


            'Filter tblWorking data results to show all Door Hangers for the checked Cycle
            If rdoBtnDH.Checked Then

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'when following line of code is added txtdlUpdate shows the newly added date
                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

                '===END - Filter DB per vCycle===

                'change label
                lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception
            MessageBox.Show("Unable to show correct Door Hanger results. (rdoBtnDH_CheckedChanged) Original error: " & ex.Message)

        End Try
    End Sub

    Private Sub rdoBtnTerm_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnTerm.CheckedChanged
        'Error Handling
        Try

            'get vCycle value and use to filter Termination results for that cycle
            'Filter tblWorking data results to show all Termination notices for the checked Cycle
            If rdoBtnTerm.Checked Then

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Termination results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'when following line of code is added txtdlUpdate shows the newly added date
                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

                '===END - Filter DB per vCycle===

                'change label
                lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception
            MessageBox.Show("Unable to show correct Termination/Shut Off results. (rdoBtnTerm_CheckedChanged) Original error: " & ex.Message)

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Try

            '===START - Update tblDateLog so information is saved to db table===
            'Trying to update database 
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            Me.Validate()
            Me.TblDateLogBindingSource.EndEdit()
            Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
            '===END - Update tblDateLog so information is saved to db table===

            '===START - Update tblShutOff so information is saved to db table===
            'Trying to update database 
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            Me.Validate()
            Me.TblShutOffBindingSource.EndEdit()
            Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
            '===END - Update tblShutOff so information is saved to db table===


            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            Me.Validate()
            Me.TblWorkingDataBindingSource.EndEdit()
            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===


        Catch ex As Exception
            MessageBox.Show("Unable to save data with Save Item button. (TblShutOffBindingNavigatorSaveItem_Click_1) Original error: " & ex.Message)
        End Try
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs)

        '[TO DO] Allow user to add another account to the table so they can be printed on this round of Notices
        'I know sometimes they give door hangers to people who are not in the current cycle

        '[TO DO - When application is completed] If I really want to make this slick...
        'Create an import for Billmaster Accounts
        'Use tbl Billmaster Accounts to help the user auto populate the data on the form
        'This is a future thought after the database is complete.

    End Sub

    Private Sub UpdateCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateCodesToolStripMenuItem.Click

        '[TO DO] Import and update tblCodes with new information from Billmaster.
        '2 fields in database, code value and code description
        Try

            'variable to capture result of MessageBox
            Dim vMsgBox As DialogResult
            'give the user a choice to cancel this action
            'Message box accepts [user input], OKCancel
            vMsgBox = MessageBox.Show("This action will erase the data you have." & vbCrLf & "Then it will add Codes from Billmaster", "Billmaster Code Update...", MessageBoxButtons.OKCancel)

            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'OK [user input]

                '[TO DO] Once I figure out how to connect to a sql database I should set it up as a class. &_
                'but I won't worry about it until I get better at coding this stuff.

                'hold the filename from openFileDialog() 
                Dim fName As String = ""

                'Code modified from OpenFileDialog (http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx)
                'declare FileStream to access file I/O
                Dim myStream As FileStream

                'assign value to newly created FIlestream instance
                myStream = Nothing

                'declare OpenFileDialog
                Dim fOpen As New OpenFileDialog()

                '[TO DO] Before Build change Initial Directory to                                                                                       
                '[NOTES] The import file cannot have column headers. Currently the file has headers
                'Current Name of the Billmaster Export File - "F:\Tre Query Exports\Door Hanger DB\DoorHanger_v2_Export.TXT"                    
                'fOpen.InitialDirectory = "F:\Tre Query Exports\Door Hanger DB\DoorHanger_v2_Export.TXT"                                        
                fOpen.InitialDirectory = "D:\OneDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS DB Project\OLD_Access DB files\"

                'filter to txt or csv files
                fOpen.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*"

                'list starts at 1, this sets FilterIndex to "*.txt" files
                fOpen.FilterIndex = 1

                'Any changes to directory while dialog is open are reset to original state.
                fOpen.RestoreDirectory = True

                'Accept [user input] from dialog, OK or CANCEL
                If fOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                    'Open file, read data contained inside to filestream
                    myStream = fOpen.OpenFile()

                    'If filestream is NOT EMPTY proceed processing
                    If (myStream IsNot Nothing) Then

                        'capture selected filename, not the path
                        fName = fOpen.FileName

                        'declare variable to accept text from filestream
                        Dim TextLine As String

                        'declare variable for Split String function
                        Dim SplitLine() As String

                        'declares streamreader which inherits textreader for fName, allowing file to be read from the filestream (myStream)
                        Dim objReader As New System.IO.StreamReader(fName)

                        '===START - SQL OPEN CODE===
                        'open sql connection

                        'declare connectionstring as variable so it easier to work with
                        Dim connectionString As String = ""

                        'TEMP connection string, I don't know how to access this information from the correct object
                        '[TO DO] learn what object has this information so I can get it dynamically from the application
                        '[DEBUG] I need to find out if this is necessary. Since I am using a typed dataset this step might be superfluous. But it works now so I am going to leave it alone at the moment.
                        connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=""D:\OneDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS Project\FCLWD-DoorHangerApp\FCLWD-DoorHangerApp\DHA_sample.mdf"";Integrated Security=True;Connect Timeout=30"
                        'connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30"

                        'declare instance of sqlconnection= (connectionstring), Using will close the connection once code completes execution
                        Using vDhConn As SqlConnection = New SqlConnection(connectionString)

                            'open connection to sql, passing filename in connectionstring variable
                            vDhConn.Open()
                            '===END - SQL OPEN CODE===

                            '===START - Clear current tblCodes ===

                            'I don't understand the following code
                            'using this link to help me http://msdn.microsoft.com/en-us/library/ms233823.aspx
                            'delete all data in tblShutOff one row at a time
                            If DhA_sampleDataSet1.tblCodes.Rows.Count = 0 Then

                                'Do nothing

                            Else

                                Do While Me.DhA_sampleDataSet1.tblCodes.Rows.Count <> 0

                                    'define dataset
                                    Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblCodes.Rows(0)

                                    'delete row
                                    vDeleteRow.Delete()

                                    'notify database of delete
                                    Me.TblCodesTableAdapter.Update(Me.DhA_sampleDataSet1.tblCodes)

                                Loop

                            End If
                            '===END - clear current tblCodes===

                            Do While objReader.Peek() <> -1
                                '===START-Read CSV into tblCodes ===
                                'object to accept SplitLine variable data after it is converted
                                Dim v(1) As Object

                                'CSV file data, line by line
                                TextLine = objReader.ReadLine()

                                'CSV file data after parse
                                '[DEBUG]- this breaks on text data that has a comma. 
                                '[DEBUG continued]- Need to pull the data better. Look for quotes that separate text so it doesn't break.
                                SplitLine = Split(TextLine, ",")

                                Dim i As Integer = 0

                                Do While i < DhA_sampleDataSet1.tblCodes.Columns.Count

                                    v(i) = SplitLine(i)

                                    Select Case i

                                        Case 0

                                            'declare variable to accept converted Int32 data
                                            Dim vInt32 As Int32
                                            'set variable to known value
                                            vInt32 = 0

                                            'pass string data and convert it for variable to accept
                                            vInt32 = System.Convert.ToInt32(v(i))

                                            v(i) = vInt32

                                        Case 1

                                            'No Conversion necessary at this time

                                            v(i) = SplitLine(i)

                                    End Select
                                    i = i + 1
                                Loop

                                DhA_sampleDataSet1.tblCodes.Rows.Add(v)

                                '===END - Read CSV into tblCodes  ===
                            Loop
                        End Using

                        '===START - Update tblCodes so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        Me.Validate()
                        Me.TblCodesBindingSource.EndEdit()
                        Me.TblCodesTableAdapter.Update(Me.DhA_sampleDataSet1.tblCodes)
                        '===END - Update tblCodes so information is saved to db table===

                    Else
                        MessageBox.Show("Error extracting file!")
                    End If

                Else
                    MessageBox.Show("Action cancelled. No File Selected.")
                End If

            Else
                MessageBox.Show("Action Cancelled. No Codes will be imported from Billmaster!")
            End If


        Catch ex As Exception

            MessageBox.Show("Unable to Import tblCodes data. (UpdateCodesToolStripMenuItem_Click) Original error: " & ex.Message)

        End Try
    End Sub

    Private Sub rdoBtnDH_Click(sender As Object, e As EventArgs) Handles rdoBtnDH.Click
        'Error Handling
        Try


            'Filter tblWorking data results to show all Door Hangers for the checked Cycle
            If rdoBtnDH.Checked Then
                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to show correct Door Hanger results. (rdoBtnDH_Click) Original error: " & ex.Message)

        End Try
    End Sub

    Private Sub rdoBtnTerm_Click(sender As Object, e As EventArgs) Handles rdoBtnTerm.Click
        'Error Handling
        Try

            'get vCycle value and use to filter Termination results for that cycle
            'Filter tblWorking data results to show all Termination notices for the checked Cycle
            If rdoBtnTerm.Checked Then

                '[TEST] - get vCycle value and use to filter Termination results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            End If

        Catch ex As Exception
            MessageBox.Show("Unable to show correct Termination/Shut Off results. (rdoBtnTerm_Click) Original error: " & ex.Message)

        End Try
    End Sub

End Class
