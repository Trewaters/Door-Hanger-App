Imports System.Data.SqlClient

'I needed the following 3 imports for Filestream to read and write
Imports System
Imports System.IO
Imports System.Text

Imports System.Globalization ' currency formatting

Imports Microsoft.Office.Interop 'Line allows me to use Microsoft Word commands
'Imports System.Runtime.InteropServices 'allows me access to Marshal class
Imports System.Diagnostics 'allow access to GetProcessesByName Method and use of Kill method
Imports System.ComponentModel 'allow use of winException

Public Class Form1

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        Try 'Error Handling

            'User Decision - give the user a choice to cancel import
            vMsgBox = MessageBox.Show("Are you sure you want to import new data," & vbCrLf & "and erase current data in this application?" & vbCrLf & vbCrLf & "Click OK to proceed, or CANCEL to stop.", "Billmaster Import?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            'check for [User Input] Ok or Cancel
            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'OK [user input]

                'hold the filename from openFileDialog() 
                Dim fName As String = ""

                'Code modified from OpenFileDialog (http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx)
                'declare FileStream to access file I/O
                Dim myStream As FileStream

                'assign value to newly created FIlestream instance
                myStream = Nothing

                'declare OpenFileDialog
                Dim fOpen As New OpenFileDialog()

                '[TO DO - Future Feature] - Allow user to select the folder that should be used for (fOpen.InitialDirectory).
                '[TO DO - Future Feature] - I am sure I could use a OpenFileDialog method to capture that information.
                '[TO DO - Future Feature] - Save that choice to a table of user preferences.
                'fOpen.InitialDirectory = "C:\Users\Tre'\SkyDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS DB Project\OLD_Access DB files\"
                fOpen.InitialDirectory = vImportDirectoryPath

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

                        'User Notification - Application Processing
                        frmBusyImport.Show()

                        'capture selected filename, not the path
                        fName = fOpen.FileName

                        'declare variable to accept text from filestream
                        Dim TextLine As String

                        'declare variable for Split String function
                        Dim SplitLine() As String

                        'declares streamreader which inherits textreader for fName, allowing file to be read from the filestream (myStream)
                        Dim objReader As New System.IO.StreamReader(fName, Encoding.Default)

                        '[TO DO - Future Feature] Once I figure out how to connect to a sql database I should set it up as a class. 
                        'but I won't worry about it until I get better at coding this stuff.

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

                        '===START - Read "DoorHanger_v2_Export" into tblShutOff===
                        Do While objReader.Peek() <> -1

                            'object to accept SplitLine variable data after it is converted
                            Dim v(24) As Object

                            'CSV file data, line by line
                            TextLine = objReader.ReadLine()

                            'check for line = empty "", this is different then Null. ReadLine = Null is the end of document, but an empty line will no throw an error
                            If String.IsNullOrEmpty(TextLine) = True Then

                                Do

                                    'CSV file data, line by line
                                    TextLine = objReader.ReadLine()

                                Loop Until String.IsNullOrEmpty(TextLine) = False

                            End If

                            'SplitLine variable contains a line of data read from the file
                            'the current import file is a (.txt) which has Tab delimiter and no Quotes around text
                            'Split is set to look for Tabs since the import file uses Tabs as its delimiter
                            SplitLine = Split(TextLine, vbTab)

                            '===START - Count SplitLine CODE===
                            '[VALIDATION] - It doesn't look good if this Import breaks
                            ' searches for and deals with- too many fields in the data row
                            ' searches for and deals with- too few fields in the data row

                            '[TO DO - Future Feature] - Make this a public shared sub that will validate import data.
                            ' Pass the following values - Expected index(#) for SplitLine, SplitLine() array, 

                            'variable to count SplitLine() array index
                            Dim a As Integer = 0

                            'get SplitLine index (#)
                            a = SplitLine.GetUpperBound(0)

                            'I know the table has an index of 24
                            'Test for exactly the correct amount of fields
                            If a <> 24 Then
                                'Something is wrong

                                'Trip Silent error so I can display message later
                                vSilentErr = "1"

                                If a < 24 Then 'SplitLine() array is smaller than expected index read nextline to repair data

                                    ReDim Preserve SplitLine(24) 'increase array size to what is expected

                                    Dim NextLine As String = Nothing 'variable for following line

                                    NextLine = objReader.ReadLine() 'get following line of the file

                                    'check for an empty line
                                    If String.IsNullOrEmpty(NextLine) = True Then

                                        'read through the empty lines until NextLine has data in it.
                                        Do

                                            NextLine = objReader.ReadLine() 'get following line of the file

                                        Loop Until String.IsNullOrEmpty(NextLine) = False

                                    End If

                                    Dim vIndCnt As Integer = 0 'variable for NextSplit index
                                    vIndCnt = CountCharacter(NextLine, vbTab) 'get new index number based on delimiter character count in string

                                    Dim NextSplit(vIndCnt) As Object 'new array variable for following line
                                    NextSplit = Split(NextLine, vbTab) 'split NextLine into an array

                                    If a + vIndCnt + 1 = 24 Then 'check if SplitLine + NextLine have enough fields to overcome the file corruption
                                        'the import file was split by a vbLf and I will attempt to repair that with the for loop
                                        For vIndCnt = 0 To NextSplit.GetUpperBound(0)
                                            a += 1
                                            'SplitLine(a) = NextLine(vIndCnt)
                                            SplitLine(a) = NextSplit(vIndCnt)

                                        Next

                                        'reset silent error to false. This issue was dealt with
                                        vSilentErr = "1"

                                    Else 'Not set up to repair this level of data corruption

                                        For vIndCnt = 0 To NextSplit.GetUpperBound(0)

                                            SplitLine(24) = "CORRUPT DATA-Missing fields" & NextSplit(vIndCnt) & SplitLine(24)

                                        Next

                                        '[DEBUG] - I might want to throw an exception instead so the corruption doesn't make this import do something strange
                                        'Throw New System.Exception("Import Data Corrupted")

                                        'load the end of the array with note
                                        SplitLine(24) = SplitLine(0) & " HAS CORRUPT DATA"

                                    End If
                                Else 'SplitLine() array is larger than expected, line has too many fields

                                    Dim b As Integer = 0

                                    ' combine the NextLine together into SplitLine(24)
                                    For b = 25 To a

                                        SplitLine(24) = SplitLine(24) & ", CORRUPT DATA-Too many fields " & SplitLine(b)
                                    Next

                                    ReDim Preserve SplitLine(24) 'decrease array size to what is expected

                                End If

                            End If
                            '===END - Count SplitLine CODE===

                            Dim i As Integer = 0


                            'Do Loop validates all String data coming in from import file
                            'Converts fields based on their known position in the array index
                            '[TO DO - Future Feature] - This could be fancier and more dynamic, but I don't know how.
                            '[TO DO - Future Feature] - Make this Do Loop fancier so it can dynamicaly read what data the field is expecting and convert the data it reads to that data type.
                            Do While i < DhA_sampleDataSet1.tblShutOff.Columns.Count

                                'added this to avoid null field errors
                                If SplitLine(i) Is Nothing Then

                                    v(i) = 0

                                Else

                                    v(i) = SplitLine(i)

                                End If


                                Select Case i

                                    Case 1, 2, 3, 4, 5, 6, 7, 13, 18, 19

                                        '"System.Decimal", convert all decimals and assign to proper column
                                        'declare variable to accept converted Decimal data
                                        Dim vDecimal As Decimal

                                        'set variable to known value
                                        vDecimal = 1.0

                                        'dim string variable, try does not accept an array
                                        Dim vStringDecimal As String = v(i).ToString

                                        If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

                                            v(i) = 0.0

                                        Else

                                            'end system.Decimal conversion
                                            v(i) = vDecimal.ToString("F2")

                                            'convert to decimal
                                            v(i) = System.Convert.ToDecimal(vDecimal)

                                        End If


                                    Case 0, 8, 9, 10, 20, 21, 22, 23, 24 'String data type expected

                                        'Check For invalid strings like empty control
                                        If v(i).ToString = "" Or v(i).ToString Is Nothing Then

                                            'Set to known variable amount
                                            v(i) = "NONE"

                                        Else

                                            'String data is valid
                                            v(i) = SplitLine(i)

                                        End If

                                    Case 11, 14
                                        'declare variable to accept converted Int32 data
                                        Dim vInt32 As Int32

                                        'set variable to known value
                                        vInt32 = 1

                                        'dim string variable, try does not accept an array
                                        Dim vStringInt As String = v(i).ToString

                                        If Int32.TryParse(vStringInt, vInt32) = False Then

                                            'pass string data and convert it for variable to accept
                                            'vInt32 = System.Convert.ToInt32(v(i))

                                            v(i) = 1

                                        Else

                                            'nothing happens
                                            'end System.Integer conversion
                                            v(i) = vInt32

                                        End If

                                    Case 12, 15, 16, 17
                                        'declare variable to accept converted date
                                        Dim vDate As Date

                                        'set variable to known value
                                        vDate = #1/1/1900#

                                        'dim string variable, try does not accept an array
                                        Dim vStringDate As String = v(i).ToString

                                        If vStringDate = "" Then

                                            vStringDate = #1/1/1900#

                                        End If

                                        If DateTime.TryParse(vStringDate, vDate) = False Then

                                            'pass string data and convert it for variable to accept
                                            'vDate = Convert.ToDateTime(v(i))

                                            v(i) = #1/1/1900#

                                        Else

                                            'nothing happens
                                            'end system.DateTime conversion
                                            v(i) = vDate

                                        End If

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

                        Loop
                        '===END - Read "DoorHanger_v2_Export" into tblShutOff===

                        '===START - update tblWorkingData with tblShutOff data===

                        '[NOTES] - The code in this section inserts data inot tblWorkingData
                        ' tblWorkingData and tblShutOff have had data deleted earlier in this sub

                        'For Each reads every row in tblShutOff
                        For Each vDataRow As DataRow In DhA_sampleDataSet1.tblShutOff.Rows

                            'create variable for NewRow, this will accept data
                            Dim vTblWDNewRow As DataRow = DhA_sampleDataSet1.tblWorkingData.NewRow()

                            'Poor way of mapping table rows, comments show mapping
                            'each vTblWDNewRow(#) copies data from tblShutOff
                            vTblWDNewRow(0) = vDataRow(0)   'wdAccount  := DhA_sampleDataSet1.tblShutOff.Rows(0)
                            vTblWDNewRow(1) = vDataRow(1)   'wdAge0     := DhA_sampleDataSet1.tblShutOff.Rows(1)
                            vTblWDNewRow(2) = vDataRow(2)   'wdAge1     := DhA_sampleDataSet1.tblShutOff.Rows(2)
                            vTblWDNewRow(3) = vDataRow(3)   'wdAge2     := DhA_sampleDataSet1.tblShutOff.Rows(3)
                            vTblWDNewRow(4) = vDataRow(4)   'wdAge3     := DhA_sampleDataSet1.tblShutOff.Rows(4)
                            vTblWDNewRow(5) = vDataRow(5)   'wdAge4     := DhA_sampleDataSet1.tblShutOff.Rows(5)   
                            vTblWDNewRow(6) = vDataRow(6)   'wdAge5     := DhA_sampleDataSet1.tblShutOff.Rows(6)   
                            vTblWDNewRow(7) = vDataRow(7)   'wdBal      := DhA_sampleDataSet1.tblShutOff.Rows(7)  
                            vTblWDNewRow(8) = vDataRow(8)   'wdName     := DhA_sampleDataSet1.tblShutOff.Rows(8)   
                            vTblWDNewRow(9) = vDataRow(9)   'wdAddr     := DhA_sampleDataSet1.tblShutOff.Rows(9)  
                            vTblWDNewRow(10) = vDataRow(10) 'wdLoc      := DhA_sampleDataSet1.tblShutOff.Rows(10)  
                            vTblWDNewRow(11) = vDataRow(11) 'wdCycle    := DhA_sampleDataSet1.tblShutOff.Rows(11)   
                            vTblWDNewRow(12) = vDataRow(12) 'wdLstPayDte:= DhA_sampleDataSet1.tblShutOff.Rows(12)   
                            vTblWDNewRow(13) = vDataRow(13) 'wdLstPayAmt:= DhA_sampleDataSet1.tblShutOff.Rows(13)   
                            vTblWDNewRow(14) = vDataRow(14) 'wdStCde    := DhA_sampleDataSet1.tblShutOff.Rows(14)   
                            vTblWDNewRow(15) = "None"       'wdStDesc   := "None"   
                            vTblWDNewRow(16) = vDataRow(22) 'wdPnotes   := DhA_sampleDataSet1.tblShutOff.Rows(22)   
                            vTblWDNewRow(17) = vDataRow(23) 'wdANotes   := DhA_sampleDataSet1.tblShutOff.Rows(23)   
                            vTblWDNewRow(18) = vDataRow(24) 'wdMNotes   := DhA_sampleDataSet1.tblShutOff.Rows(24)   
                            vTblWDNewRow(19) = 0            'wdTerm     := 0   
                            vTblWDNewRow(20) = 0            'wdHang     := 0   
                            vTblWDNewRow(21) = #1/1/1900#   'wdHangDte  := #1/1/1900#   
                            vTblWDNewRow(22) = #1/1/1900#   'wdCntDte   := #1/1/1900#   
                            vTblWDNewRow(23) = #1/1/1900#   'wdTermDte  := #1/1/1900#   
                            vTblWDNewRow(24) = vDataRow(16) 'wdAgreeDue := DhA_sampleDataSet1.tblShutOff.Rows(16)   
                            vTblWDNewRow(25) = vDataRow(18) 'wdPmtAgreed:= DhA_sampleDataSet1.tblShutOff.Rows(18)   
                            vTblWDNewRow(26) = vDataRow(19) 'wdUnPmt    := DhA_sampleDataSet1.tblShutOff.Rows(19)   
                            vTblWDNewRow(27) = vDataRow(20) 'wdPriRte   := DhA_sampleDataSet1.tblShutOff.Rows(20)   
                            vTblWDNewRow(28) = vDataRow(21) 'wdSecRte   := DhA_sampleDataSet1.tblShutOff.Rows(21)   
                            vTblWDNewRow(29) = vDataRow(15) 'wdStCdeDte := DhA_sampleDataSet1.tblShutOff.Rows(15)   
                            vTblWDNewRow(30) = vDataRow(17) 'wdAgreeMade:= DhA_sampleDataSet1.tblShutOff.Rows(17)  
                            vTblWDNewRow(31) = vDataRow(3) + vDataRow(4) + vDataRow(5) + vDataRow(6) 'wdMinDue:= DhA_sampleDataSet1.tblShutoff.Rows(3 + 4 + 5 + 6)

                            'add new row with copied data to tblWorkingData
                            DhA_sampleDataSet1.tblWorkingData.Rows.Add(vTblWDNewRow)

                            'loop through until all data copied
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
                        'v(30) = tblWorkingData.[wdAgreedMade] DATETIME2 NULL,             | v(17) = tblShutOff.[soAgreeMade] DATETIME2 NULL,
                        'v(31) = tblWorkingData.[wdMinDue] SMALLMONEY NULL                 | v(3) + v(4) + v(5) + v(6) = tblShutOff.[soAge3+4+5+6] SMALLMONEY NULL

                        '===END - update tblWorkingData with tblShutOff data===

                        '===START- UPDATE TBLWORKINGDATA WITH CODE DESCRIPTIONS===
                        'Check if tblCodes is empty before working
                        If DhA_sampleDataSet1.tblCodes.Rows.Count() <> 0 Then
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

                                        'set silent error to display message about needing table description codes
                                        vSilentErr = "2"

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
                        End If
                        '===END===

                        '===START-UPDATE tblDateLog.dlNew with date===
                        'update tblDateLog with New data import date, marks all cycles
                        'Run update query adding current time
                        Me.TblDateLogTableAdapter.FillByUpdateNew("" & Now().ToShortDateString & "")

                        'fill table with new data
                        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                        '===END===

                        '===START - Update tblDateLog so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblDateLogBindingSource.EndEdit()
                        Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
                        '===END - Update tblDateLog so information is saved to db table===

                        '===START - Update tblShutOff so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblShutOffBindingSource.EndEdit()
                        Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
                        '===END - Update tblShutOff so information is saved to db table===


                        '===START - Update tblWorkingData so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblWorkingDataBindingSource.EndEdit()
                        Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
                        '===END - Update tblWorkingData so information is saved to db table===

                        'User Notification - Application finished processing
                        frmBusyImport.Close()

                        'User Notification - update user that "Get Billmaster Data has completed"
                        MessageBox.Show("Finished importing data from Billmaster.", "Notification: Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'change (lblUserNotification.Text), message that informs user of last action
                        lblUserNotification.Text = "Billmaster data updated on " & Now()
                        'Bold text, I changed the color because bold is a READ ONLY property, not sure how to change it.
                        lblUserNotification.ForeColor = Color.Red
                        'Change borderStyle, trying to make the notification stand out more
                        lblUserNotification.BorderStyle = BorderStyle.Fixed3D

                    Else

                        'Error - Invalid Data Entry, Notify user that file does not exist
                        MessageBox.Show("File is Empty. Please select another file.", "Data Error: Empty File", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                End If

            Else

                '[user input] was to Cancel Import

                'User Notification - msgBox to inform user
                MessageBox.Show("The Action has been cancelled!" & vbCrLf & "You have not changed anything.", "Notification: Billmaster Import Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'change (lblUserNotification.Text)
                lblUserNotification.Text = "Billmaster Import Cancelled! " & Now()

            End If

            'Silent Error message and variable reset to false/0
            'Select Case vSilentErr
            '    Case "1"
            '        'Silent Error - Notify user Import is corrupted and they need to check the file
            '        MessageBox.Show("Import file is corrupt. Please verify data." & vbCrLf & "The import completed but it might have errors or could be missing data." & vbCrLf & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Corrupted", MessageBoxButtons.OK, MessageBoxIcon.Error)


            '    Case "2"

            '        'User Notification - inform user they should update the tblCodes from Billmaster
            '        MessageBox.Show("Please update Status Codes from Billmaster." & vbCrLf & "Some newly added Status Codes are missing." & vbCrLf & "Contact Tre' Grisby (trewaters@hotmail.com) with any questions", "Notification: Update Billmaster Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '        'Not sure how to make both message show up.
            '    Case "12" Or "21" Or "11"
            '        '[DEBUG] - this error notification isn't set up to work properly

            '        'Error - Invalid Data Entry, Notify user Import is corrupted and they need to check the file
            '        MessageBox.Show("Import file is corrupt. Please verify data." & vbCrLf & "The import completed but it might have errors or could be missing data." & vbCrLf & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Corrupted", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '        'User Notification - inform user they should update the tblCodes from Billmaster
            '        MessageBox.Show("Please update Status Codes from Billmaster." & vbCrLf & "Some newly added Status Codes are missing." & vbCrLf & "Contact Tre' Grisby (trewaters@hotmail.com) with any questions", "Notification: Update Billmaster Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'End Select

            'reset silentError variable
            vSilentErr = "False"

        Catch Ex As Exception

            'keep a log file in a log folder
            SaveLogFs(Ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to read file from drive." & vbCrLf & "Check file ( " & vImportDirectoryPath & " ) for errors" & vbCrLf & "(ImportToolStripMenuItem_Click) Original error: " & Ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click

        '[NOTES] - logic for an UPDATE
        ' 1 - Move through tblShutOff rows using For Each loop, making sure to read all lines in tblShutOff
        ' 2 - after reading each tblShutOff.Row, update/insert tblWorkingData.column.DataValue 
        '     if tblShutOff.Row.DataValue is <> to tblWorkingData.Row.DataValue
        ' 3 - If soAccount = wdAccount and Row(#). DataValue not equal then Update, 
        '     If soAccount doesn't exist on the table then Insert row to tblWorkingData

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        Try 'Error Handling

            'User Decision - give the user a choice to cancel import
            vMsgBox = MessageBox.Show("Updating with current Billmaster information." & vbCrLf & vbCrLf & "Click OK to proceed, or CANCEL to stop.", "Update Billmaster?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            'check for [User Input] Ok or Cancel
            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'User Notification - Application Processing
                frmBusyImport.Show()

                'OK [user input]

                'hold the filename from openFileDialog() 
                Dim fName As String = ""

                'Code modified from OpenFileDialog (http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx)
                'declare FileStream to access file I/O
                Dim myStream As FileStream

                'assign value to newly created FIlestream instance
                myStream = Nothing

                'declare OpenFileDialog
                Dim fOpen As New OpenFileDialog()

                '[TO DO - Future Feature] - Allow user to select the folder that should be used for (fOpen.InitialDirectory).
                '[TO DO - Future Feature] - I am sure I could use a OpenFileDialog method to capture that information.
                '[TO DO - Future Feature] - Save that choice to a table of user preferences.
                'fOpen.InitialDirectory = "C:\Users\Tre'\SkyDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS DB Project\OLD_Access DB files\"
                fOpen.InitialDirectory = vImportDirectoryPath

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

                        '===START - Clear current tblShutOff Data===

                        'I don't understand the following code
                        'using this link to help me http://msdn.microsoft.com/en-us/library/ms233823.aspx

                        'delete all data in tblShutOff one row at a time
                        Do While Me.DhA_sampleDataSet1.tblShutOff.Rows.Count <> 0

                            'define dataset
                            Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblShutOff.Rows(0)

                            'delete row
                            vDeleteRow.Delete()

                            'notify database of delete
                            Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)

                        Loop

                        '===END - clear current tblShutOff Data===

                        '===START - Read "DoorHanger_v2_Export" into tblShutOff===
                        Do While objReader.Peek() <> -1

                            'object to accept SplitLine variable data after it is converted
                            Dim v(24) As Object

                            'CSV file data, line by line
                            TextLine = objReader.ReadLine()

                            'check for line = empty "", this is different then Null. ReadLine = Null is the end of document, but an empty line will no throw an error
                            If TextLine = "" Then


                                'CSV file data, line by line
                                TextLine = objReader.ReadLine()

                                Do While TextLine = ""

                                    'CSV file data, line by line
                                    TextLine = objReader.ReadLine()

                                Loop

                            End If

                            'Remove the Quotes around text
                            TextLine = TextLine.Replace("""", " ")

                            'The import file uses Tabs as its delimiter, so Split is set to read for Tabs also
                            SplitLine = Split(TextLine, vbTab)

                            '===START - Count SplitLine CODE===
                            '[VALIDATION] - It doesn't look good if this Import breaks
                            ' searches for and deals with- too many fields in the data row
                            ' searches for and deals with- too few fields in the data row

                            '[TO DO - Future Feature] - Make this a public shared sub that will validate import data.
                            ' Pass the following values - Expected index(#) for SplitLine, SplitLine() array, 

                            'variable to count SplitLine() array index
                            Dim a As Integer = 0

                            'get SplitLine index (#)
                            a = SplitLine.GetUpperBound(0)

                            'I know the table has an index of 24
                            'Test for exactly the correct amount of fields
                            If a <> 24 Then
                                'Something is wrong

                                'Trip Silent error so I can display message later
                                vSilentErr = "1"

                                If a < 24 Then 'SplitLine() array is smaller than expected index read nextline to repair data

                                    ReDim Preserve SplitLine(24) 'increase array size to what is expected

                                    Dim NextLine As String = Nothing 'variable for following line
                                    NextLine = objReader.ReadLine() 'get following line of the file

                                    Dim vIndCnt As Integer = 0 'variable for NextSplit index
                                    vIndCnt = CountCharacter(NextLine, vbTab) 'get new index number based on delimiter character count in string

                                    Dim NextSplit(vIndCnt) As Object 'new array variable for following line
                                    NextSplit = Split(NextLine, vbTab) 'split NextLine into an array

                                    If a + vIndCnt + 1 = 24 Then 'check if SplitLine + NextLine have enough fields to overcome the file corruption
                                        'the import file was split by a vbLf and I will attempt to repair that with the for loop
                                        For vIndCnt = 0 To NextSplit.GetUpperBound(0)
                                            a += 1
                                            SplitLine(a) = NextLine(vIndCnt)
                                        Next

                                        'reset silent error to false. This issue was dealt with
                                        vSilentErr = "False"

                                    Else 'Not set up to repair this level of data corruption

                                        For vIndCnt = 0 To NextSplit.GetUpperBound(0)
                                            SplitLine(24) = "CORRUPT DATA-Missing fields" & NextLine(vIndCnt) & SplitLine(24)
                                        Next

                                        '[DEBUG] - I might want to throw an exception instead so the corruption doesn't make this import do something strange
                                        'Throw New System.Exception("Import Data Corrupted at " & SplitLine(0).ToString)

                                        ReDim Preserve SplitLine(24) 'decrease array size to what is expected

                                        SplitLine(24) = SplitLine(0) & " HAS CORRUPT DATA"


                                    End If
                                Else 'SplitLine() array is larger than expected, line has too many fields

                                    Dim b As Integer = 0

                                    ReDim Preserve SplitLine(24) 'decrease array size to what is expected

                                    ' combine the NextLine(vIndCnt) together into SplitLine(24)
                                    For b = 24 To a

                                        SplitLine(24) = SplitLine(24) & ", CORRUPT DATA-Too many fields " & SplitLine(b)
                                    Next

                                End If

                            End If
                            '===END - Count SplitLine CODE===

                            Dim i As Integer = 0

                            'Do Loop validates all String data coming in from import file
                            'Converts fields based on their known position in the array index
                            '[TO DO - Future Feature] - This could be fancier and more dynamic, but I don't know how.
                            '[TO DO - Future Feature] - Make this Do Loop fancier so it can dynamicaly read what data the field is expecting and convert the data it reads to that data type.
                            Do While i < DhA_sampleDataSet1.tblShutOff.Columns.Count


                                'added this to avoid null field errors
                                If SplitLine(i) Is Nothing Then

                                    v(i) = 0

                                Else

                                    v(i) = SplitLine(i)

                                End If

                                Select Case i

                                    Case 1, 2, 3, 4, 5, 6, 7, 13, 18, 19
                                        '"System.Decimal", convert all decimals and assign to proper column
                                        'declare variable to accept converted Decimal data
                                        Dim vDecimal As Decimal
                                        'set variable to known value
                                        vDecimal = 1.0

                                        'pass string data and convert it for variable to accept
                                        'vDecimal = System.Convert.ToDecimal(v(i))

                                        'dim string variable, try does not accept an array
                                        Dim vStringDecimal As String = v(i).ToString

                                        If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

                                            'pass string data and convert it for variable to accept
                                            'vDate = Convert.ToDateTime(v(i))

                                            v(i) = 0.0

                                        Else

                                            'end system.Decimal conversion
                                            v(i) = vDecimal.ToString("F2")

                                            'convert to decimal
                                            v(i) = System.Convert.ToDecimal(vDecimal)

                                        End If

                                        'nothing happens
                                        'end system.decimal conversion
                                        'v(i) = vDecimal.ToString("f2")

                                    Case 0, 8, 9, 10, 20, 21, 22, 23, 24
                                        'Check For invalid strings like empty control
                                        If v(i).ToString = "" Or v(i).ToString Is Nothing Then

                                            'Set to known variable amount
                                            v(i) = "NONE"

                                        Else

                                            'String data is valid
                                            v(i) = SplitLine(i)

                                        End If

                                    Case 11, 14
                                        'declare variable to accept converted Int32 data
                                        Dim vInt32 As Int32

                                        'set variable to known value
                                        vInt32 = 1

                                        'dim string variable, try does not accept an array
                                        Dim vStringInt As String = v(i).ToString

                                        If Int32.TryParse(vStringInt, vInt32) = False Then

                                            'pass string data and convert it for variable to accept
                                            'vInt32 = System.Convert.ToInt32(v(i))

                                            v(i) = 1

                                        Else

                                            'nothing happens
                                            'end System.Integer conversion
                                            v(i) = vInt32

                                        End If

                                    Case 12, 15, 16, 17
                                        'declare variable to accept converted date
                                        Dim vDate As Date

                                        'set variable to known value
                                        vDate = #1/1/1900#

                                        'dim string variable, try does not accept an array
                                        Dim vStringDate As String = v(i).ToString

                                        If DateTime.TryParse(vStringDate, vDate) = False Then

                                            'pass string data and convert it for variable to accept
                                            'vDate = Convert.ToDateTime(v(i))

                                            v(i) = #1/1/1900#

                                        Else

                                            'nothing happens
                                            'end system.DateTime conversion
                                            v(i) = vDate

                                        End If

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

                        Loop

                        'close filestream
                        objReader.Close()

                        '===END - Read "DoorHanger_v2_Export" into tblShutOff===

                        '===START - update tblWorkingData with tblShutOff data===
                        If Me.DhA_sampleDataSet1.tblWorkingData.Rows.Count() = 0 Then

                            'table is empty move one

                        Else

                            'Account number is in tblWorkingData
                            Dim z As Boolean = False

                            'ForEach reads every row in tblShutOff
                            For Each vDataRow As DataRow In DhA_sampleDataSet1.tblShutOff.Rows

                                For Each vTblWDDataRow As DataRow In DhA_sampleDataSet1.tblWorkingData.Rows

                                    'reset variable
                                    z = False

                                    'Search tblWorkingData for vTblWDNewRow(0).value? = DhA_sampleDataSet1.tblWorkingData.Rows(0).value? 
                                    'wdAccount = vDataRow(0), looking for a matching account number. 
                                    If vDataRow(0) = vTblWDDataRow(0) Then

                                        'true, Account # exist in ShutOff table
                                        z = True

                                        'Update vTblWDNewRow(#)

                                        'Poor way of mapping table rows, comments show mapping
                                        'each vTblWDNewRow(#) copies data from tblShutOff

                                        '[DEBUG] -removed the account field because I am not sure it is needed since that won't really change
                                        'vTblWDDataRow(0) = vDataRow(0)   'wdAccount  := DhA_sampleDataSet1.tblShutOff.Rows(0)

                                        vTblWDDataRow(1) = vDataRow(1)   'wdAge0     := DhA_sampleDataSet1.tblShutOff.Rows(1)
                                        vTblWDDataRow(2) = vDataRow(2)   'wdAge1     := DhA_sampleDataSet1.tblShutOff.Rows(2)
                                        vTblWDDataRow(3) = vDataRow(3)   'wdAge2     := DhA_sampleDataSet1.tblShutOff.Rows(3)
                                        vTblWDDataRow(4) = vDataRow(4)   'wdAge3     := DhA_sampleDataSet1.tblShutOff.Rows(4)
                                        vTblWDDataRow(5) = vDataRow(5)   'wdAge4     := DhA_sampleDataSet1.tblShutOff.Rows(5)   
                                        vTblWDDataRow(6) = vDataRow(6)   'wdAge5     := DhA_sampleDataSet1.tblShutOff.Rows(6)   
                                        vTblWDDataRow(7) = vDataRow(7)   'wdBal      := DhA_sampleDataSet1.tblShutOff.Rows(7)  
                                        vTblWDDataRow(8) = vDataRow(8)   'wdName     := DhA_sampleDataSet1.tblShutOff.Rows(8)   
                                        vTblWDDataRow(9) = vDataRow(9)   'wdAddr     := DhA_sampleDataSet1.tblShutOff.Rows(9)  
                                        vTblWDDataRow(10) = vDataRow(10) 'wdLoc      := DhA_sampleDataSet1.tblShutOff.Rows(10)  

                                        'removing wdCycle from the update to preserve "Save to New Cycle" feature
                                        'if the user changes the cycle I don't want the import changing that to the Billmaster default
                                        'vTblWDDataRow(11) = vDataRow(11) 'wdCycle    := DhA_sampleDataSet1.tblShutOff.Rows(11)   

                                        vTblWDDataRow(12) = vDataRow(12) 'wdLstPayDte:= DhA_sampleDataSet1.tblShutOff.Rows(12)   
                                        vTblWDDataRow(13) = vDataRow(13) 'wdLstPayAmt:= DhA_sampleDataSet1.tblShutOff.Rows(13)   
                                        vTblWDDataRow(14) = vDataRow(14) 'wdStCde    := DhA_sampleDataSet1.tblShutOff.Rows(14)   
                                        vTblWDDataRow(16) = vDataRow(22) 'wdPnotes   := DhA_sampleDataSet1.tblShutOff.Rows(22)   
                                        vTblWDDataRow(17) = vDataRow(23) 'wdANotes   := DhA_sampleDataSet1.tblShutOff.Rows(23)   
                                        vTblWDDataRow(18) = vDataRow(24) 'wdMNotes   := DhA_sampleDataSet1.tblShutOff.Rows(24)   
                                        vTblWDDataRow(24) = vDataRow(16) 'wdAgreeDue := DhA_sampleDataSet1.tblShutOff.Rows(16)   
                                        vTblWDDataRow(25) = vDataRow(18) 'wdPmtAgreed:= DhA_sampleDataSet1.tblShutOff.Rows(18)   
                                        vTblWDDataRow(26) = vDataRow(19) 'wdUnPmt    := DhA_sampleDataSet1.tblShutOff.Rows(19)   
                                        vTblWDDataRow(27) = vDataRow(20) 'wdPriRte   := DhA_sampleDataSet1.tblShutOff.Rows(20)   
                                        vTblWDDataRow(28) = vDataRow(21) 'wdSecRte   := DhA_sampleDataSet1.tblShutOff.Rows(21)   
                                        vTblWDDataRow(29) = vDataRow(15) 'wdStCdeDte := DhA_sampleDataSet1.tblShutOff.Rows(15)   
                                        vTblWDDataRow(30) = vDataRow(17) 'wdAgreeMade:= DhA_sampleDataSet1.tblShutOff.Rows(17)
                                        vTblWDDataRow(31) = vDataRow(3) + vDataRow(4) + vDataRow(5) + vDataRow(6) 'wdMinDue:= DhA_sampleDataSet1.tblShutoff.Rows(3 + 4 + 5 + 6)

                                        'exit loop, the account has been updated
                                        Exit For

                                    End If

                                Next

                                '[DEBUG] -PUlling this out because something is causing an update error

                                ''z = False, ShutOff Data is not in table
                                'If z = False Then

                                '    ' ADD a NEW ROW to tblWorkingData with all the data in this vDataRow(#)

                                '    ' important for when they want to add a one off type Door Hanger/Termination notice.
                                '    ' or if someone moves between Door Hangers

                                '    'create variable for NewRow, that will accept data
                                '    Dim vTblWDNewRow As DataRow = DhA_sampleDataSet1.tblWorkingData.NewRow()

                                '    'Poor way of mapping table rows, comments show mapping
                                '    'each vTblWDNewRow(#) copies data from tblShutOff
                                '    vTblWDNewRow(0) = vDataRow(0)   'wdAccount  := DhA_sampleDataSet1.tblShutOff.Rows(0)
                                '    vTblWDNewRow(1) = vDataRow(1)   'wdAge0     := DhA_sampleDataSet1.tblShutOff.Rows(1)
                                '    vTblWDNewRow(2) = vDataRow(2)   'wdAge1     := DhA_sampleDataSet1.tblShutOff.Rows(2)
                                '    vTblWDNewRow(3) = vDataRow(3)   'wdAge2     := DhA_sampleDataSet1.tblShutOff.Rows(3)
                                '    vTblWDNewRow(4) = vDataRow(4)   'wdAge3     := DhA_sampleDataSet1.tblShutOff.Rows(4)
                                '    vTblWDNewRow(5) = vDataRow(5)   'wdAge4     := DhA_sampleDataSet1.tblShutOff.Rows(5)   
                                '    vTblWDNewRow(6) = vDataRow(6)   'wdAge5     := DhA_sampleDataSet1.tblShutOff.Rows(6)   
                                '    vTblWDNewRow(7) = vDataRow(7)   'wdBal      := DhA_sampleDataSet1.tblShutOff.Rows(7)  
                                '    vTblWDNewRow(8) = vDataRow(8)   'wdName     := DhA_sampleDataSet1.tblShutOff.Rows(8)   
                                '    vTblWDNewRow(9) = vDataRow(9)   'wdAddr     := DhA_sampleDataSet1.tblShutOff.Rows(9)  
                                '    vTblWDNewRow(10) = vDataRow(10) 'wdLoc      := DhA_sampleDataSet1.tblShutOff.Rows(10)  
                                '    vTblWDNewRow(11) = vDataRow(11) 'wdCycle    := DhA_sampleDataSet1.tblShutOff.Rows(11)   
                                '    vTblWDNewRow(12) = vDataRow(12) 'wdLstPayDte:= DhA_sampleDataSet1.tblShutOff.Rows(12)   
                                '    vTblWDNewRow(13) = vDataRow(13) 'wdLstPayAmt:= DhA_sampleDataSet1.tblShutOff.Rows(13)   
                                '    vTblWDNewRow(14) = vDataRow(14) 'wdStCde    := DhA_sampleDataSet1.tblShutOff.Rows(14)   
                                '    vTblWDNewRow(15) = "None"       'wdStDesc   := "None"   
                                '    vTblWDNewRow(16) = vDataRow(22) 'wdPnotes   := DhA_sampleDataSet1.tblShutOff.Rows(22)   
                                '    vTblWDNewRow(17) = vDataRow(23) 'wdANotes   := DhA_sampleDataSet1.tblShutOff.Rows(23)   
                                '    vTblWDNewRow(18) = vDataRow(24) 'wdMNotes   := DhA_sampleDataSet1.tblShutOff.Rows(24)   
                                '    vTblWDNewRow(19) = 0            'wdTerm     := 0   
                                '    vTblWDNewRow(20) = 0            'wdHang     := 0   
                                '    vTblWDNewRow(21) = #1/1/1900#   'wdHangDte  := #1/1/1900#   
                                '    vTblWDNewRow(22) = #1/1/1900#   'wdCntDte   := #1/1/1900#   
                                '    vTblWDNewRow(23) = #1/1/1900#   'wdTermDte  := #1/1/1900#   
                                '    vTblWDNewRow(24) = vDataRow(16) 'wdAgreeDue := DhA_sampleDataSet1.tblShutOff.Rows(16)   
                                '    vTblWDNewRow(25) = vDataRow(18) 'wdPmtAgreed:= DhA_sampleDataSet1.tblShutOff.Rows(18)   
                                '    vTblWDNewRow(26) = vDataRow(19) 'wdUnPmt    := DhA_sampleDataSet1.tblShutOff.Rows(19)   
                                '    vTblWDNewRow(27) = vDataRow(20) 'wdPriRte   := DhA_sampleDataSet1.tblShutOff.Rows(20)   
                                '    vTblWDNewRow(28) = vDataRow(21) 'wdSecRte   := DhA_sampleDataSet1.tblShutOff.Rows(21)   
                                '    vTblWDNewRow(29) = vDataRow(15) 'wdStCdeDte := DhA_sampleDataSet1.tblShutOff.Rows(15)   
                                '    vTblWDNewRow(30) = vDataRow(17) 'wdAgreeMade:= DhA_sampleDataSet1.tblShutOff.Rows(17)  
                                '    vTblWDNewRow(31) = vDataRow(3) + vDataRow(4) + vDataRow(5) + vDataRow(6) 'wdMinDue:= DhA_sampleDataSet1.tblShutoff.Rows(3 + 4 + 5 + 6)

                                '    'add new row with copied data to tblWorkingData
                                '    DhA_sampleDataSet1.tblWorkingData.Rows.Add(vTblWDNewRow)

                                'End If

                                'loop through until all data copied
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
                            'v(30) = tblWorkingData.[wdAgreedMade] DATETIME2 NULL,             | v(17) = tblShutOff.[soAgreeMade] DATETIME2 NULL,
                            'v(31) = tblWorkingData.[wdMinDue] SMALLMONEY NULL                 |       = tblShutoff.[soAge3 + 4 + 5 + 6] 

                            '===END - update tblWorkingData with tblShutOff data===

                            '===START- UPDATE TBLWORKINGDATA WITH CODE DESCRIPTIONS===
                            If Me.DhA_sampleDataSet1.tblCodes.Rows.Count() = 0 Then
                                'Table is empty move on

                            Else

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

                                            'User Notification - inform user they should update the tblCodes from Billmaster
                                            MessageBox.Show("Please update Status Codes from Billmaster." & vbCrLf & "Some newly added Status Codes are missing." & vbCrLf & "Contact Tre' Grisby (trewaters@hotmail.com) with any questions", "Notification: Update Billmaster Codes", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                            End If

                            '===END===

                        End If

                        '===END - update tblWorkingData with tblShutOff data===

                        '===START-UPDATE tblDateLog.dlUpdate with date===
                        'update tblDateLog with file data Update date, marks all cycles
                        'Run update query adding current time
                        Me.TblDateLogTableAdapter.FillByUpdateNow("" & Now().ToShortDateString & "")

                        'fill table with new data
                        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                        '===END===

                        '===START - Update tblDateLog so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblDateLogBindingSource.EndEdit()
                        Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
                        '===END - Update tblDateLog so information is saved to db table===

                        '===START - Update tblShutOff so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblShutOffBindingSource.EndEdit()
                        Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
                        '===END - Update tblShutOff so information is saved to db table===

                        '[DEBUG] - Moved this directly after the initial update to tblworkingData
                        '===START - Update tblWorkingData so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                        '[DEBUG] - Me.Validate()
                        Me.TblWorkingDataBindingSource.EndEdit()
                        Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
                        '===END - Update tblWorkingData so information is saved to db table===

                        '[TO DO - Future Feature] - check for account numbers changing between reports. Not sure how I was doing this before

                        '[TO DO - Future Feature] - print report of accounts that have paid since the last list was printed. "Paid Before Termination Report", this never worked in Access

                        'User Notification - Application finished processing
                        frmBusyImport.Close()

                        'User Notification - update user that "Get Billmaster Data has completed"
                        MessageBox.Show("Finished updating from Billmaster.", "Notification: Billmaster Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'change (lblUserNotification.Text), message that informs user of last action
                        lblUserNotification.Text = "Billmaster data updated on " & Now()
                        'Bold text, I changed the color because bold is a READ ONLY property, not sure how to change it.
                        lblUserNotification.ForeColor = Color.Red
                        'Change borderStyle, trying to make the notification stand out more
                        lblUserNotification.BorderStyle = BorderStyle.Fixed3D

                    Else

                        'Error - Notify user that file does not exist
                        MessageBox.Show("File is Empty. Please select another file.", "Data Error: Empty File", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                Else

                    '[user input] Cancelled

                    'User Notification - Application finished processing
                    frmBusyImport.Close()

                    'User Notification - msgBox to inform user
                    MessageBox.Show("File selection cancelled!" & vbCrLf & "You have not changed anything.", "Notification: Application Update Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'change (lblUserNotification.Text)
                    lblUserNotification.Text = "Application Update Cancelled! " & Now()

                End If

            Else

                '[user input] Update Cancelled

                'User Notification - Application finished processing
                frmBusyImport.Close()

                'User Notification - msgBox to inform user
                MessageBox.Show("The Action has been cancelled!" & vbCrLf & "You have not changed anything.", "Notification: Application Update Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'change (lblUserNotification.Text)
                lblUserNotification.Text = "Application Update Cancelled! " & Now()

            End If

        Catch Ex As Exception

            'keep a log file in a log folder
            SaveLogFs(Ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to read file from drive." & vbCrLf & "Check file ( " & vImportDirectoryPath & " ) for errors" & vbCrLf & "(UpdateToolStripMenuItem_Click) Original error: " & Ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '[DEBUG] - verify this enough to save only the tblWorkingData

        'Error Handling
        Try

            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database before the user exits the program
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            '[DEBUG] - Me.Validate()

            Me.TblWorkingDataBindingSource.EndEdit()

            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to Close the form properly." & vbCrLf & "(Form1_FormClosing) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblExcelExport' table. You can move, or remove it, as needed.
            Me.TblExcelExportTableAdapter.Fill(Me.DhA_sampleDataSet1.tblExcelExport)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblDateLog' table. You can move, or remove it, as needed.
            Me.TblDateLogTableAdapter.Fill(Me.DhA_sampleDataSet1.tblDateLog)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblWorkingData' table. You can move, or remove it, as needed.
            Me.TblWorkingDataTableAdapter.Fill(Me.DhA_sampleDataSet1.tblWorkingData)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblShutOff' table. You can move, or remove it, as needed.
            Me.TblShutOffTableAdapter.Fill(Me.DhA_sampleDataSet1.tblShutOff)

            'TODO: This line of code loads data into the 'DhA_sampleDataSet1.tblCodes' table. You can move, or remove it, as needed.
            Me.TblCodesTableAdapter.Fill(Me.DhA_sampleDataSet1.tblCodes)

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to Load Form1." & vbCrLf & "(Form1_Load) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Try

            'Close or Exit the application
            Me.Close()

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to exit application properly." & vbCrLf & "(ExitToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub rdoBtnCycle1_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle1.CheckedChanged
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try
            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle1.Checked = True Then

                'Change the cycles value
                vCycle = 1

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - use vCycle value to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to select Cycle." & vbCrLf & "(rdoBtnCycle1_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub rdoBtnCycle2_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle2.CheckedChanged
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle2.Checked = True Then
                'Change the cycles value
                vCycle = 2

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to select Cycle." & vbCrLf & "(rdoBtnCycle2_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub rdoBtnCycle3_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle3.CheckedChanged
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle3.Checked = True Then
                'Change the cycles value
                vCycle = 3

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value


        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to select Cycle." & vbCrLf & "(rdoBtnCycle3_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub rdoBtnCycle4_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnCycle4.CheckedChanged
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle4.Checked = True Then
                'Change the cycles value
                vCycle = 4

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to select Cycle." & vbCrLf & "(rdoBtnCycle4_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub rdoBtnDH_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnDH.CheckedChanged

        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle
            If rdoBtnDH.Checked Then

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'Dates will display for current cycle
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

                'change label
                lbfrmDteLog.Text = "Dates forCycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results." & vbCrLf & "(rdoBtnDH_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnTerm_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBtnTerm.CheckedChanged
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'get vCycle value and use to filter Termination results for that cycle
            'Filter tblWorking data results to show all Termination notices for the checked Cycle
            If rdoBtnTerm.Checked Then

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Termination results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

                '[DEBUG] - I don't think this change is happening
                'change label
                lbfrmDteLog.Text = "Dates forCycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to show correct Termination results." & vbCrLf & "(rdoBtnTerm_CheckedChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Try

            '===START - Update tblDateLog so information is saved to db table===
            'Trying to update database 
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            '[DEBUG] - Me.Validate()
            Me.TblDateLogBindingSource.EndEdit()
            Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
            '===END - Update tblDateLog so information is saved to db table===

            '===START - Update tblShutOff so information is saved to db table===
            'Trying to update database 
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            '[DEBUG] - Me.Validate()
            Me.TblShutOffBindingSource.EndEdit()
            Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
            '===END - Update tblShutOff so information is saved to db table===

            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            '[DEBUG] - Me.Validate()
            Me.TblWorkingDataBindingSource.EndEdit()
            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to save data with Save Item button." & vbCrLf & "(TblShutOffBindingNavigatorSaveItem_Click_1) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub UpdateCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateCodesToolStripMenuItem.Click

        '[NOTES] - Import and update tblCodes with new information from Billmaster.

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        'frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        'frmBusyImport.Text = "Door Hanger Application Busy"

        Try

            'give the user a choice to cancel this action
            'User Decision - Message box accepts [user input], OKCancel
            vMsgBox = MessageBox.Show("This action will erase current Status Codes," & vbCrLf & "and update with new Status Codes" & vbCrLf & "added from Billmaster." & vbCrLf & vbCrLf & "Click OK to proceed, or CANCEL to stop.", "Update Codes?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'OK [user input]

                '[TO DO - Future Feature] Once I figure out how to connect to a sql database I should set it up as a class. 
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

                '[NOTES] The import file cannot have column headers.
                'fOpen.InitialDirectory = "C:\Users\Tre'\SkyDrive\Hunting\Freelancing\Clients\FCLWD\100-Door Hanger DB\VS DB Project\OLD_Access DB files\"
                fOpen.InitialDirectory = vTblCodesDirectoryPath

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

                        'User Notification - Application Processing
                        frmBusyImport.Show()

                        'capture selected filename, not the path
                        fName = fOpen.FileName

                        'declare variable to accept text from filestream
                        Dim TextLine As String

                        'declare variable for Split String function
                        Dim SplitLine() As String

                        'declares streamreader which inherits textreader for fName, allowing file to be read from the filestream (myStream)
                        Dim objReader As New System.IO.StreamReader(fName)

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

                            'check for line = empty "", this is different then Null. ReadLine = Null is the end of document, but an empty line will no throw an error
                            If TextLine = "" Then

                                'read next line
                                TextLine = objReader.ReadLine()

                                Do While TextLine <> ""

                                    TextLine = objReader.ReadLine()

                                Loop

                            End If

                            'textline search for quotes and replace with nothing
                            TextLine = TextLine.Replace("""", "")

                            'CSV file data after parsing out quotes
                            SplitLine = Split(TextLine, ",")

                            '===START - Count SplitLine CODE===
                            '[VALIDATION] - It doesn't look good if this Import breaks

                            'variable to count SplitLine
                            Dim a As Integer = 0

                            'Count SplitLine index
                            a = SplitLine.GetUpperBound(0)

                            'I know the table has an index of 1
                            'Test for exactly the correct amount of fields
                            If a <> 1 Then
                                'Something is wrong

                                'variable counts through the extra fields in the array
                                Dim d As Integer

                                'variable for combined string
                                Dim vCombinedField As String = Nothing

                                'combine remaining strings in the array
                                For d = 1 To a
                                    vCombinedField = vCombinedField & SplitLine(d) & ","
                                Next

                                'redim SplitLine as a 2 dimensional array, which is the correct size
                                ReDim Preserve SplitLine(1)

                                'set index (1) = to the result of the combined strings
                                SplitLine(1) = vCombinedField

                                'Trip Silent error so I can display message later outside of the loop
                                vSilentErr = "1"

                            End If
                            '===END - Count SplitLine CODE===

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
                                        'Check For invalid strings like empty control
                                        If v(i).ToString = "" Or v(i).ToString Is Nothing Then

                                            'Set to known variable amount
                                            v(i) = "NONE"

                                        Else

                                            'String data is valid
                                            v(i) = SplitLine(i)

                                        End If

                                End Select
                                i = i + 1
                            Loop

                            DhA_sampleDataSet1.tblCodes.Rows.Add(v)

                            '===END - Read CSV into tblCodes  ===
                        Loop

                        '===START - Update tblCodes so information is saved to db table===
                        'Trying to update database when the import action is processed
                        'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

                        'removed this because it causes issues with an empty txtAccount.TExt field
                        'Me.Validate()

                        Me.TblCodesBindingSource.EndEdit()
                        Me.TblCodesTableAdapter.Update(Me.DhA_sampleDataSet1.tblCodes)
                        '===END - Update tblCodes so information is saved to db table===

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

                                    'set silent error to display message about needing table description codes
                                    vSilentErr = "2"

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

                        'User Notification - Application finished processing
                        frmBusyImport.Close()

                        'User Notification
                        MessageBox.Show("Status Codes successfully updated.", "Notification: Status Code Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        'Error - My coding caused an issue, 
                        MessageBox.Show("Error extracting file!" & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Code Error: Import Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Else

                    'User Notification - update cancelled
                    MessageBox.Show("Action cancelled. No File Selected.", "Notification: Status Code Update Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                'User Notification - update cancelled
                MessageBox.Show("Action cancelled. No File Selected.", "Notification: Status Code Update Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If vSilentErr = "1" Then

                'Error - data is corrupt 
                MessageBox.Show("Code Description file is corrupt.Please verify data." & vbCrLf & "The import completed but it might have errors or could be missing data." & vbCrLf & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Corrupt!", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'reset silentError variable
                vSilentErr = "False"

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Application finished processing
            frmBusyImport.Close()

            'Error Handling - Exception Error
            'Standard Error 
            MessageBox.Show("Unable to Import tblCodes data." & vbCrLf & "Check file ( " & vTblCodesDirectoryPath & " ) for errors" & vbCrLf & "(UpdateCodesToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '

            '[DEBUG] - This is out of order. I should not have an error that says this in the Try...Catch. I don't know that the file imported.
            If vSilentErr = "1" Then

                'Silent Error - Notify user Import is corrupted and they need to check the file
                'MessageBox.Show("Import file is corrupt. Please verify data." & vbCrLf & "The import completed but it might have errors or could be missing data." & vbCrLf & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Corrupted", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'reset silentError variable
                vSilentErr = "False"

            End If

        End Try
    End Sub

    Private Sub rdoBtnDH_Click(sender As Object, e As EventArgs) Handles rdoBtnDH.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle
            If rdoBtnDH.Checked Then
                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

                '[DEBUG] - I don't think this change is happening
                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (rdoBtnDH_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnTerm_Click(sender As Object, e As EventArgs) Handles rdoBtnTerm.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'get vCycle value and use to filter Termination results for that cycle
            'Filter tblWorking data results to show all Termination notices for the checked Cycle
            If rdoBtnTerm.Checked Then

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

                '[DEBUG] - I don't think this change is happening
                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Termination/Shut Off results. (rdoBtnTerm_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnCycle1_Click(sender As Object, e As EventArgs) Handles rdoBtnCycle1.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try
            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle1.Checked = True Then
                'Change the cycles value
                vCycle = 1

                'Auto Select "Cycle_1" Radio Button
                rdoBtnCycle1.Checked = True

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle1_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnCycle2_Click(sender As Object, e As EventArgs) Handles rdoBtnCycle2.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking


        'Error Handling
        Try
            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle2.Checked = True Then
                'Change the cycles value
                vCycle = 2

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle2_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnCycle3_Click(sender As Object, e As EventArgs) Handles rdoBtnCycle3.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle3.Checked = True Then
                'Change the cycles value
                vCycle = 3

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle3_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub rdoBtnCycle4_Click(sender As Object, e As EventArgs) Handles rdoBtnCycle4.Click
        '[DEBUG] - update table immediately so the grid shows changes on clicking

        'Error Handling
        Try

            'verify radio button is selected before changing cycle variable
            If rdoBtnCycle4.Checked = True Then
                'Change the cycles value
                vCycle = 4

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

                '===START - Filter DB per vCycle===

                '[TEST] - get vCycle value and use to filter Door Hanger results for that cycle
                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

            End If

            '[TO DO] - 
            'Check vNotice value, 
            'if "None" show msgbox(Please select a Notification below)
            'ELSE filter result based on vNotice value

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to select Cycle. (rdoBtnCycle4_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        'Error Handling
        Try

            'Verify there is data to print. 
            'declare variable for DHCount
            Dim vWdHangCount As Integer

            'Count records with scalar variable
            vWdHangCount = CType(Me.TblWorkingDataTableAdapter.ScalarWdHangCount(vCycle), Integer)

            'If there are accounts selected to print then print else notify user there was an error.
            If vWdHangCount > 0 Then

                'User Decision - verify user wishes to continue
                vMsgBox = MessageBox.Show("Are you sure you want to print Door Hanger Report for Cycle #" & vCycle, "User Notification: " & vCycle & " Door Hanger Report.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                If vMsgBox = Windows.Forms.DialogResult.OK Then
                    '[User Input] DialogResult = OK

                    'User Notification - Application Processing
                    frmBusyImport.Show()

                    '===START - Write data to file for merge===
                    'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                    'variable for DH Report Path
                    Dim vDhRptPath As String

                    'path to DH Report text data file
                    vDhRptPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"

                    'Delete the file if it exist already
                    If File.Exists(vDhRptPath) Then
                        File.Delete(vDhRptPath)
                    End If

                    'Create the file
                    Dim fs As FileStream = File.Create(vDhRptPath)

                    'declare variable to read row
                    Dim vDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'data for file, Pulling all accounts that match (wdHang = TRUE and vCycle)
                    Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                    'First line of txt contains Header Source data
                    'create header for mailmerge
                    'header fields (wdAccount, wdName, wdAddr, Bal [wdBal + $20], Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], wdTermDte, wdHangDte, wdHang [check box], wdTerm [check box], wdPriRte/wdSecRte)
                    AddText(fs, "wdHangDte", 1)
                    AddText(fs, "wdName", 1)
                    AddText(fs, "wdAddr", 1)
                    AddText(fs, "wdTermDte", 1)
                    AddText(fs, "wdAccount", 1)
                    AddText(fs, "Min", 1)
                    AddText(fs, "Bal", 1)
                    AddText(fs, "wdHang", 1) 'added to report and not in the labels data
                    AddText(fs, "wdTerm", 1) 'added to report and not in the labels data
                    AddText(fs, "wdPriRte", 1) 'added to report and not in the labels data
                    '[TEST] - changed this field to 0 instead of 1. Hopefully my bug has been fixed because of the work I did checking my data at the SplitLine level
                    AddText(fs, "wdSecRte", 0) 'added to report and not in the labels data

                    'loop through dataset and write each line to file
                    For Each vDataRow In Me.DhA_sampleDataSet1.tblWorkingData.Rows()

                        'move to the next line for a new record
                        AddText(fs, Environment.NewLine, 0)

                        'write all the data to appropriate fields

                        'convert date to Short Date format
                        Dim vDate As Date = #2/2/2022#
                        vDate = vDataRow("wdHangDte")
                        vDate = vDate.ToShortDateString.Trim
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdName").ToString().Trim, 1)
                        AddText(fs, vDataRow("wdAddr").ToString().Trim, 1)

                        'convert date to Short Date format
                        vDate = vDataRow("wdTermDte")
                        vDate = vDate.ToShortDateString.Trim
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdAccount").ToString().Trim, 1)

                        'AddText(fs, (vDataRow("wdAge2") + vDataRow("wdAge3") + vDataRow("wdAge4") + vDataRow("wdAge5") + 20), 1) 'add all the fields that make up minimum amount due
                        AddText(fs, vDataRow("wdMinDue") + 20, 1) '[TO DO] - Ask question about this $20 fee. Is it per service (water and/or sewer)

                        AddText(fs, (vDataRow("wdBal") + 20), 1) '[TO DO] - Ask question about this $20 fee. Is it per service (water and/or sewer)
                        AddText(fs, vDataRow("wdHang"), 1) 'added to report and not in the labels data. Boolean
                        AddText(fs, vDataRow("wdTerm"), 1) 'added to report and not in the labels data. Boolean

                        AddText(fs, vDataRow("wdPriRte").ToString().Trim, 1) 'added to report and not in the labels data

                        AddText(fs, vDataRow("wdSecRte").ToString(), 0) 'added to report and not in the labels data

                    Next

                    'Complete, Save data to ".txt" file
                    fs.Close()
                    '===END - Write data to file for merge===

                    ''===START- WdMailMerge Call===

                    ''[NOTES] - Project File Paths and Names to save Merge files
                    '' Merge information for "DH Report (print to MS Word)"
                    '' Merge data File Path (My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt")
                    '' Merge Document to open (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx")
                    '' Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    '' Fields to print on Door Hanger Report (wdAccount, wdName, wdAddr, Bal [wdBal + $20], Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], wdTermDte, wdHangDte, wdHang [check box], wdTerm [check box], wdWater/wdSewer)

                    'Dim vWdDocOpen As String
                    'vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx"

                    ''Dim vPath As String
                    ''vPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"

                    'Dim vWdDocSave As String
                    'vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                    ''this calls the mail merge with appropriate variables
                    'WdMailMerge(vWdDocOpen, vDhRptPath, vWdDocSave)
                    ''===END - WdMailMerge Call===

                    '===START- WdMailMerge Call===

                    '[NOTES] - Project File Paths and Names to save Merge files
                    ' Merge information for "DH Report (print to MS Word)"
                    ' vPath = Merge data File Path (My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt")
                    ' vWdDocOpen = Merge Document to open (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx")
                    ' vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    ' Fields to print on Door Hanger Report (wdAccount, wdName, wdAddr, Bal [wdBal + $20], Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], wdTermDte, wdHangDte, wdHang [check box], wdTerm [check box], wdWater/wdSewer)

                    'Needed variables for this call to work are below


                    'Variable that deals with File Name and Path that the MailMerge should open
                    Dim vWdDocOpen As String = ""

                    'Variable deals with File Name and Path that the MailMerge should use as its datasource
                    Dim vPath As String = ""

                    'Variable deals with File Name and Path that the MailMerge should use to save the new document
                    Dim vWdDocSave As String = ""

                    '[DEBUG] - check that the file exist before adding it to the MailMerge
                    If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_Report.docx") = True Then

                        vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_Report.docx"

                        '[DEBUG] - check that the file exist before adding it to the MailMerge
                        If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt") = True Then

                            vPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"

                            vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                            'this calls the mail merge with appropriate variables
                            WdMailMerge(vWdDocOpen, vDhRptPath, vWdDocSave)

                        Else

                            'Error - File doesn't exist
                            MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    Else

                        'Error - File doesn't exist
                        MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                    '===END - WdMailMerge Call===

                    'User Notification - Application finished processing
                    frmBusyImport.Close()

                    'User Notification - Notify user Door Hanger Report is complete
                    MessageBox.Show("Finished printing Door Hanger Report.", "Notification: Door Hanger Report Printed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    '[User Input] was DialogResult = Cancel
                    'User Notification - Notify user Door Hanger Label Printing has been cancelled
                    MessageBox.Show("Report was not created.", "Notification: Printing is Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                'Error - Notify user there are no accounts to print
                MessageBox.Show("There are no addresses selected to print for Cycle #" & vCycle & "." & vbCrLf & "Please select addresses to print.", "Error: Empty list!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Standard Error 
            MessageBox.Show("Unable to Create Door Hanger Report." & vbCrLf & "(ReportToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'added this to update the date fields ASAP
        'fill table with new data
        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

        'Change the label for dates to match the current cycle
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

    End Sub

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function

    Private Shared Sub AddText(ByVal fs As FileStream, ByVal value As Object, ByVal vDelimiter As Integer)

        '[DEBUG] - validate text in this procedure. add quotes to text, add # to dates, format dates like mm/dd/yyyy only, and verify numbers are sans quotes

        '[DEBUG] - MUST DO- Check for Empty or null values here.
        '[DEBUG] - I think is done sometimes by the code calling AddText(fs, Object), but not sure and 
        '[DEBUG] - errors are created in mailmerge when empty fields are passed through
        'If = "" or 0 then, 
        'If Value Is Nothing Then assign a safe default value to variable

        'Get Object type
        ' Possible Object types in my code (Byte(),DataRow,Date,Decimal,FileStream,Int32,Integer,System.IO.StreamReader(fName),Object,OpenFileDialog(),String,Word._Document,Word.Application,Word.MailMerge,Word.MailMergeFields,Word.Selection,DHA_sampleDataSet.tblExcelExportRow)
        Dim vObjType As String
        vObjType = TypeName(value)


        Select Case vObjType 'TypeName(value) 

            Case "String"

                'declare variable to accept converted string data
                Dim vString As String

                'initialize variable
                vString = "none"

                'pass data and convert it
                vString = System.Convert.ToString(value)

                'check for nothing
                'prevents mailmerge from breaking
                If vString Is Nothing Or vString = "" Or vString = " " Then

                    'initialize variable
                    value = "None"

                Else

                    'end system.String conversion
                    value = vString

                End If

            Case "Decimal"

                '[NOTES] - check for nothing is not necessary. Decimal Nothing = 0 and that is valid for MailMerge
                'end system.decimal conversion

                '[DEBUG] - The code below wasn't really doing anything since a Null field is passed as 0
                'declare variable to accept converted Decimal data
                'Dim vDecimal As Decimal
                'set variable to known value
                'vDecimal = 1.1
                'Original code below
                'value = vDecimal.ToString("f2")
                'pass string data and convert it for variable to accept
                'value = System.Convert.ToDecimal(value)

            Case "Date"

                'declare variable to accept converted date
                Dim vDate As Date

                'set variable to known value
                vDate = Convert.ToDateTime(value)

                'check for nothing
                'prevents mailmerge from breaking
                If vDate = DateTime.MinValue Then
                    'initialize variable
                    vDate = #1/1/1900#
                Else
                    'end system.String conversion
                    value = vDate
                End If

            Case "Integer"

                'declare variable to accept converted Int32 data
                Dim vInt32 As Int32

                'set variable to known value
                vInt32 = 22

                '[NOTES] - check for nothing is not necessary. Decimal Nothing = 0 and that is valid for MailMerge

                'pass string data and convert it for variable to accept
                vInt32 = System.Convert.ToInt32(value)

                value = vInt32

            Case "Boolean"

                '[NOTES] - check for nothing is not necessary. Boolean default is False. It doesn't seem possible to have an empty Boolean

        End Select

        'search for vTab, If vTab = True then include a vbTab at the end of the fs.Write

        Select Case vDelimiter

            Case 0 'no delimiter added

                If vObjType = "String" Then

                    'eliminate the quotes by replacing with double quotes
                    value = value.replace("""", "")

                End If

                'Else use the normal fsWrite
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(value)

                fs.Write(info, 0, info.Length)

            Case 1 'vbTab delimiter

                If vObjType = "String" Then

                    'eliminate the quotes by replacing with double quotes
                    value = value.replace("""", "")
                    'value = value.replace("""", "inches")

                End If

                'add Tab as Bytes so it can read into the FileStream
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(value & vbTab)

                fs.Write(info, 0, info.Length)

            Case 2 'comma delimiter

                If vObjType = "String" Then

                    value = """" & value & """"

                End If

                'add Tab as Bytes so it can read into the FileStream
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(value & ",")

                fs.Write(info, 0, info.Length)

        End Select

    End Sub

    Private Sub LabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabelsToolStripMenuItem.Click
        '[NOTES] - printing Door Hanger Labels with a Word MailMerge
        ' Create Customer Service Charge file and save it to computer

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        'Error Handling
        Try

            'Verify there is data to print. 
            'declare variable for DHCount
            Dim vWdHangCount As Integer

            'Count records with scalar variable
            vWdHangCount = CType(Me.TblWorkingDataTableAdapter.ScalarWdHangCount(vCycle), Integer)

            'If there are accounts selected to print then print else notify user there was an error.
            If vWdHangCount > 0 Then

                'User Decision - Show Dates that will be saved and printed ("Hanging Date, Contact Office By Date,Termination Date")
                vMsgBox = MessageBox.Show("Date of Notification = " & dtpHangDte.Value.ToShortDateString & vbCrLf & vbCrLf & "Contact Office By Date = " & dtpCntDte.Value.ToShortDateString & vbCrLf & vbCrLf & "Service Termination Date = " & dtpTermDte.Value.ToShortDateString, "Accept Dates for Cycle #" & vCycle & " Door Hangers?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                If vMsgBox = Windows.Forms.DialogResult.OK Then
                    '[User Input] DialogResult = OK

                    'User Notification - Application Processing
                    frmBusyImport.Show()

                    'variables to hold dates
                    Dim vHangDte As Date
                    Dim vCntDte As Date
                    Dim vTermDte As Date

                    'initialize date variables
                    vHangDte = dtpHangDte.Value.ToShortDateString
                    vCntDte = dtpCntDte.Value.ToShortDateString
                    vTermDte = dtpTermDte.Value.ToShortDateString

                    'Update tblDateLog.dlDH with Door Hanger date
                    Me.TblDateLogTableAdapter.UpdateHangByCycle(vHangDte, vCycle)

                    'Update tblWorkingData.wdHangDte with Door Hanger Dates
                    Me.TblWorkingDataTableAdapter.UpdateHangByCycle(vHangDte, vCntDte, vTermDte, vCycle)

                    '===START - Update tblDateLog so information is saved to db table===
                    'Trying to update database when the import action is processed
                    'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                    '[DEBUG] - Me.Validate()
                    Me.TblDateLogBindingSource.EndEdit()
                    Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
                    '===END - Update tblDateLog so information is saved to db table===

                    '===START - Write data to file for merge===
                    'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                    'variable for DH Report Path
                    Dim vDhLblPath As String

                    'path to DH Report text data file
                    vDhLblPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhLabelData.txt"

                    'Delete the file if it exist already
                    If File.Exists(vDhLblPath) Then
                        File.Delete(vDhLblPath)
                    End If

                    'Create the file
                    Dim fs As FileStream = File.Create(vDhLblPath)

                    'declare variable to read row
                    Dim vDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'data for file
                    Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                    'create header for mailmerge(wdHangDte,	wdName,	wdAddr,	wdTermDte,	wdCntDte,	wdAccount,	Min + 20, Bal + 20)
                    AddText(fs, "wdHangDte", 1)
                    AddText(fs, "wdName", 1)
                    AddText(fs, "wdAddr", 1)
                    AddText(fs, "wdTermDte", 1)
                    AddText(fs, "wdCntDte", 1)
                    AddText(fs, "wdAccount", 1)
                    AddText(fs, "Min", 1)
                    AddText(fs, "Bal", 0)

                    'loop through dataset and write each line to file
                    For Each vDataRow In Me.DhA_sampleDataSet1.tblWorkingData.Rows()

                        '[DEBUG] - Dates and number types need to be converted or esle the merge breaks.

                        'move to the next line for a new record
                        AddText(fs, Environment.NewLine, 0)

                        'write all the data to appropriate fields

                        'convert date to Short Date format
                        Dim vDate As Date = #2/2/2022#
                        vDate = vDataRow("wdHangDte")
                        vDate = vDate.ToShortDateString
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdName").ToString(), 1)
                        AddText(fs, vDataRow("wdAddr").ToString(), 1)

                        'convert date to Short Date format
                        vDate = vDataRow("wdTermDte")
                        vDate = vDate.ToShortDateString
                        AddText(fs, vDate, 1)

                        'convert date to Short Date format
                        vDate = vDataRow("wdCntDte")
                        vDate = vDate.ToShortDateString
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdAccount").ToString(), 1)

                        'AddText(fs, (vDataRow("wdAge2") + vDataRow("wdAge3") + vDataRow("wdAge4") + vDataRow("wdAge5") + 20), 1) 'add all the fields that make up minimum amount due + 20 fee
                        AddText(fs, vDataRow("wdMinDue") + 20, 1) '[TO DO] - Ask question about this $20 fee. Is it per service (water and/or sewer)

                        AddText(fs, (vDataRow("wdBal") + 20), 0) '[TO DO] - Ask question about this $20 fee. Is it per service (water and/or sewer)

                    Next

                    fs.Close()
                    '===END - Write data to file for merge===

                    ''===START- WdMailMerge Call===

                    ''[NOTES] - Project File Paths and Names to save Merge files
                    '' Merge information for "DH Labels (print to MS Word)"
                    '' Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_1st_Notice.docx")
                    '' Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger 1st Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    '' Fields to print on Door Hanger labels (wdHangDte, wdName, wdAddr, wdTermDte, wdCntDte, wdAccount, Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], Bal [wdBal + $20])

                    'Dim vWdDocOpen As String
                    'vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_1st_Notice.docx"

                    ''Dim vPath As String
                    ''vPath = vDhLblPath

                    'Dim vWdDocSave As String
                    'vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger 1st Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                    ''this calls the mail merge with appropriate variables
                    'WdMailMerge(vWdDocOpen, vDhLblPath, vWdDocSave)
                    ''===END - WdMailMerge Call===

                    '===START- WdMailMerge Call===
                    '[NOTES] - Project File Paths and Names to save Merge files

                    '[NOTES] - Project File Paths and Names to save Merge files
                    ' vWdDocOpen = Merge information for "DH Labels (print to MS Word)"
                    ' vDhLblPath = Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_1st_Notice.docx")
                    ' vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger 1st Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    ' Fields to print on Door Hanger labels (wdHangDte, wdName, wdAddr, wdTermDte, wdCntDte, wdAccount, Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], Bal [wdBal + $20])

                    'Needed variables for this call to work are below

                    'Variable that deals with File Name and Path that the MailMerge should open
                    Dim vWdDocOpen As String = ""

                    'Variable deals with File Name and Path that the MailMerge should use as its datasource
                    'vPath = vDhLblPath

                    'Variable deals with File Name and Path that the MailMerge should use to save the new document
                    Dim vWdDocSave As String = ""

                    '[DEBUG] - check that the file exist before adding it to the MailMerge
                    If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_1st_Notice.docx") = True Then

                        vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_1st_Notice.docx"

                        '[DEBUG] - check that the file exist before adding it to the MailMerge
                        If File.Exists(vDhLblPath.ToString) = True Then

                            'path to DH Report text data file
                            'vDhLblPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhLabelData.txt"

                            vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger 1st Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                            'this calls the mail merge with appropriate variables
                            WdMailMerge(vWdDocOpen, vDhLblPath, vWdDocSave)

                            'User Notification - Notify user Door Hanger labels are complete
                            MessageBox.Show("Finished Printing Door Hanger Labels. " & vbCrLf & "Customer Services Charges have been saved to file.", "Notification: Door Hanger Labels Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else

                            'Error - File doesn't exist
                            MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\DhLabelData.txt"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    Else

                        'Error - File doesn't exist
                        MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_1st_Notice.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                    '===END - WdMailMerge Call===

                    '===START - Delete tblExcelExport===

                    'check for empty table
                    If DhA_sampleDataSet1.tblExcelExport.Rows.Count = 0 Then

                    Else

                        'Delete tblExcelExport before adding accounts
                        'This avoids duplicate record add errors
                        Dim vTblExcelExportRow As DHA_sampleDataSet.tblExcelExportRow

                        vTblExcelExportRow = Me.DhA_sampleDataSet1.tblExcelExport.Rows(0)

                        For Each vTblExcelExportRow In DhA_sampleDataSet1.tblExcelExport.Rows

                            vTblExcelExportRow.Delete()

                        Next vTblExcelExportRow

                        Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)
                    End If
                    '===END - - Delete tblExcelExport===

                    '===START- Fill tblExcelExport ===

                    'Insert records into tblExcelExport 
                    '(tblWorkingData.wdAccount, tblWorkingData.wdName, tblWorkingData.wdAddr, Water CSC = $10, Sewer CSC = $10, tblWorkingData.wdHangDte)
                    ' Where tblWorkingData.wdHang = -1 and tblWorkingData.wdCycle= vCycle

                    'declare variable to read row
                    Dim vTblWdDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'For Each Loop reads every row in tblWorkingData
                    For Each vTblWdDataRow In DhA_sampleDataSet1.tblWorkingData.Rows

                        'create variable for new row
                        Dim vTblExNewRow As DataRow = DhA_sampleDataSet1.tblExcelExport.NewRow()

                        'My idea of mapping table rows, each vTblExNewRow(#) takes data from the other table
                        vTblExNewRow(0) = vTblWdDataRow(0)
                        vTblExNewRow(1) = vTblWdDataRow(8)
                        vTblExNewRow(2) = vTblWdDataRow(9)

                        'check for service
                        'If Water service <> NONE at $10 to CSV
                        If vTblWdDataRow(27).ToString <> "NONE" Then

                            vTblExNewRow(3) = 10 'create a variable for the Water Service Charge in the future

                        Else

                            vTblExNewRow(3) = 0 'create a variable for the Water Service Charge in the future

                        End If

                        'check for service
                        'If Sewer service <> NONE at $10 to CSV
                        If vTblWdDataRow(28).ToString <> "NONE" Then

                            vTblExNewRow(4) = 10 'create a variable for the Sewer Service Charge in the future

                        Else

                            vTblExNewRow(4) = 0 'create a variable for the Sewer Service Charge in the future

                        End If

                        vTblExNewRow(5) = vTblWdDataRow(21)

                        'exAccount	:= DhA_sampleDataSet1.tblExcelExport.Rows(0), |VARCHAR(11) NOT NULL PRIMARY KEY,
                        'exName			:= DhA_sampleDataSet1.tblExcelExport.Rows(1), |VARCHAR (MAX) NOT NULL
                        'exAddr			:= DhA_sampleDataSet1.tblExcelExport.Rows(2), |VARCHAR (MAX) NOT NULL
                        'exWtr			:= DhA_sampleDataSet1.tblExcelExport.Rows(3), |SMALLMONEY    DEFAULT ((10)) NULL
                        'exSwr			:= DhA_sampleDataSet1.tblExcelExport.Rows(4), |SMALLMONEY    DEFAULT ((10)) NULL
                        'exChgDte		:= DhA_sampleDataSet1.tblExcelExport.Rows(5)  |DATETIME2 (7) NOT NULL

                        'add new row to vTblExNewRow, loop through until all data copied
                        DhA_sampleDataSet1.tblExcelExport.Rows.Add(vTblExNewRow)

                    Next vTblWdDataRow

                    'v(0) =  tblWorkingData.[wdAccount] NCHAR(11) NOT NULL PRIMARY KEY,| v(0) =  exAccount
                    'v(1) =  tblWorkingData.[wdAge0] SMALLMONEY NULL,                  |  
                    'v(2) =  tblWorkingData.[wdAge1] SMALLMONEY NULL,                  |  
                    'v(3) =  tblWorkingData.[wdAge2] SMALLMONEY NULL,                  |  
                    'v(4) =  tblWorkingData.[wdAge3] SMALLMONEY NULL,                  |  
                    'v(5) =  tblWorkingData.[wdAge4] SMALLMONEY NULL,                  |  
                    'v(6) =  tblWorkingData.[wdAge5] SMALLMONEY NULL,                  |  
                    'v(7) =  tblWorkingData.[wdBal] SMALLMONEY NULL,                   |  
                    'v(8) =  tblWorkingData.[wdName] VARCHAR(MAX) NULL,                | v(1) =  exName
                    'v(9) =  tblWorkingData.[wdAddr] VARCHAR(MAX) NULL,                | v(2) =  exAddr
                    'v(10) = tblWorkingData.[wdLoc] VARCHAR(MAX) NULL,                 | 
                    'v(11) = tblWorkingData.[wdCycle] INT NULL,                        | 
                    'v(12) = tblWorkingData.[wdLstPayDte] DATETIME2 NULL,              | 
                    'v(13) = tblWorkingData.[wdLstPayAmt] SMALLMONEY NULL,             | 
                    'v(14) = tblWorkingData.[wdStCde] INT NULL,                        | 
                    'v(15) = tblWorkingData.[wdStDesc] VARCHAR(30) NULL,               | 
                    'v(16) = tblWorkingData.[wdPnotes] VARCHAR(MAX) NULL,              | 
                    'v(17) = tblWorkingData.[wdANotes] VARCHAR(MAX) NULL,              | 
                    'v(18) = tblWorkingData.[wdMNotes] VARCHAR(MAX) NULL,              | 
                    'v(19) = tblWorkingData.[wdTerm] BIT NOT NULL,                     |         
                    'v(20) = tblWorkingData.[wdHang] BIT NOT NULL,                     |         
                    'v(21) = tblWorkingData.[wdHangDte] DATETIME2 NULL,                | v(5) = exChgDte
                    'v(22) = tblWorkingData.[wdCntDte] DATETIME2 NULL,                 |         
                    'v(23) = tblWorkingData.[wdTermDte] DATETIME2 NULL,                |         
                    'v(24) = tblWorkingData.[wdAgreeDue] DATETIME2 NULL,               | 
                    'v(25) = tblWorkingData.[wdPmtAgreed] SMALLMONEY NULL,             | 
                    'v(26) = tblWorkingData.[wdUnPmt] SMALLMONEY NULL,                 | 
                    'v(27) = tblWorkingData.[wdPriRte] VARCHAR(30) NULL,               | 
                    'v(28) = tblWorkingData.[wdSecRte] VARCHAR(30) NULL,               | 
                    'v(29) = tblWorkingData.[wdStCdeDte] DATETIME2 NULL,               | 
                    'v(30) = tblWorkingData.[wdAgreedMade] Datetime2 null,             | 
                    'v(31) = tblWorkingData.[wdMinDue] SMALLMONEY NULL

                    '===END - Fill tblExcelExport  ===

                    '===START - Update tblExcelExport so information is saved to db table===
                    'Trying to update database when the import action is processed
                    'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                    '[DEBUG] - Me.Validate()
                    Me.TblExcelExportBindingSource.EndEdit()
                    Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)
                    '===END - Update tblExcelExport so information is saved to db table===

                    '===START - Write data to file for Customer Service Charge ===
                    'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                    'This files contains all the customer accounts that received a CSC.
                    'Each time the Door Hanger labels are printed this file will be overwritten with new information, so save the file somewhere else as soon as possible.

                    '[TO DO - Future Feature] -Let the user choose what directory they want this file saved to

                    '[TO DO - Future Feature] -Automatically open the folder this is saved to, OR ask if they want the folder opened after saving it

                    '[DEBUG] - Check for empty record set before saving CSC File. The CSC code is in two spots of the application so far.

                    'variable for DH Report Path
                    Dim vCscPath As String

                    '[NOTES] - Export data to a Customer Service Charge file for Kathy. 
                    '[TO DO - Future Feature] - Current Path to Customer Service Charge file (), allow user to save this under preferences
                    vCscPath = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv"

                    'Delete the file if it exist already
                    If File.Exists(vCscPath) Then
                        File.Delete(vCscPath)
                    End If

                    'Create the file
                    Dim vCscFs As FileStream = File.Create(vCscPath)

                    'declare variable to read row
                    Dim vCscDataRow As DataRow = DhA_sampleDataSet1.tblExcelExport.Rows(0)

                    'data for file
                    Me.TblExcelExportTableAdapter.Fill(Me.DhA_sampleDataSet1.tblExcelExport)

                    '[TO DO - Future Feature] - validate for comma's. I don't have time now but that is a good thing to do.

                    'This is a comma delimiter instead of a Tab delimiter, there are no quotes expected in this data that's why the delimiter works
                    'create first row for file(exAccount,	exName,	exAddr,	exWtr,	exSwr,	exChgDte)
                    AddText(vCscFs, "exAccount", 2)
                    AddText(vCscFs, "exName", 2)
                    AddText(vCscFs, "exAddr", 2)
                    AddText(vCscFs, "exWtr", 2)
                    AddText(vCscFs, "exSwr", 2)
                    AddText(vCscFs, "exChgDte", 0)

                    'loop through dataset and write each line to file
                    For Each vCscDataRow In Me.DhA_sampleDataSet1.tblExcelExport.Rows()

                        '[DEBUG] - Dates and number types need to be converted or esle the merge breaks.

                        'move to the next line for a new record
                        AddText(vCscFs, Environment.NewLine, False)

                        'write all the data to appropriate fields
                        AddText(vCscFs, vCscDataRow("exAccount").ToString(), 2)
                        AddText(vCscFs, vCscDataRow("exName").ToString(), 2)
                        AddText(vCscFs, vCscDataRow("exAddr").ToString(), 2)
                        AddText(vCscFs, vCscDataRow("exWtr").ToString(), 2)
                        AddText(vCscFs, vCscDataRow("exSwr").ToString(), 2)
                        'convert date to Short Date format
                        Dim vDate As Date = #2/2/2022#
                        vDate = vCscDataRow("exChgDte")
                        vDate = vDate.ToShortDateString
                        AddText(vCscFs, vDate, 0)

                    Next

                    'close filestream
                    vCscFs.Close()

                    '[TO DO - Future Feature] - Make this a link that the user can click on to open the save folder. Make this a notification that ask the user
                    'MessageBox.Show with "Yes/No". If Yes "Labels have finished would you like to open CSC location?"
                    'Yes open CSC location automatically
                    'No Close the message and do nothing
                    '===END - Write data to file for Customer Service Charge ===

                    'User Notification - Application finished processing
                    frmBusyImport.Close()

                Else

                    '[User Input] was DialogResult = Cancel
                    'User Notification - Notify user Door Hanger Label Printing has been cancelled
                    MessageBox.Show("Please correct Door Hanger Dates," & vbCrLf & "and try again.", "Notification: Printing is Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                'Error - Notify user there are no accounts to print
                MessageBox.Show("There are no addresses selected to print for Cycle #" & vCycle & "." & vbCrLf & "Please select addresses to print.", "Data Error: Empty list!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Standard Error 
            MessageBox.Show("Unable to Merge data with documents in Microsoft Word." & vbCrLf & "(LabelsToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'added this to update the date fields ASAP
        'fill table with new data
        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

        'Change the label for dates to match the current cycle
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

    End Sub

    Private Sub ReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem1.Click
        '[NOTES] - Print Termination Report (Save and Print)
        ' so user can review termination list before printing labels
        ' doing a MailMerge with MS Word so the report looks better.

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        'Error Handling
        Try

            'Verify there is data to print. 
            'declare variable for label count
            Dim vWdTermCount As Integer

            'Count records with scalar variable
            vWdTermCount = CType(Me.TblWorkingDataTableAdapter.ScalarWdTermCount(vCycle), Integer)

            'If there are accounts selected to print then print else notify user there was an error.
            If vWdTermCount > 0 Then

                'User Decision - verify with user they are printing vCycle
                vMsgBox = MessageBox.Show("Termination Report " & vbCrLf & "Are you sure?", "Notification: Print Termination Report?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                If vMsgBox = Windows.Forms.DialogResult.OK Then
                    '[User Input] DialogResult = OK

                    'User Notification - Application Processing
                    frmBusyImport.Show()

                    '===START - Write data to file for merge===
                    'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                    'variable for DH Report Path
                    Dim vDhRptPath As String

                    'path to DH Report text data file
                    vDhRptPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermRptData.txt"

                    'Delete the file if it exist already
                    If File.Exists(vDhRptPath) Then
                        File.Delete(vDhRptPath)
                    End If

                    'Create the file
                    Dim fs As FileStream = File.Create(vDhRptPath)

                    'declare variable to read row
                    Dim vDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'data for file
                    Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                    'create header for mailmerge (*wdTermDte, *wdName, *wdAddr, *wdAccount, *Bal, *wdLoc)
                    AddText(fs, "wdTermDte", 1)
                    AddText(fs, "wdName", 1)
                    AddText(fs, "wdAddr", 1)
                    AddText(fs, "wdAccount", 1)
                    AddText(fs, "wdLoc", 1)
                    AddText(fs, "Bal", 0)

                    'loop through dataset and write each line to file
                    For Each vDataRow In Me.DhA_sampleDataSet1.tblWorkingData.Rows()

                        '[DEBUG] - Dates and number types need to be converted or esle the merge breaks.

                        'move to the next line for a new record
                        AddText(fs, Environment.NewLine, 0)

                        'write all the data to appropriate fields

                        'convert date to Short Date format
                        Dim vDate As Date = #2/2/2022#
                        vDate = vDataRow("wdTermDte")
                        vDate = vDate.ToShortDateString
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdName").ToString(), 1)
                        AddText(fs, vDataRow("wdAddr").ToString(), 1)

                        AddText(fs, vDataRow("wdAccount").ToString(), 1)

                        AddText(fs, vDataRow("wdLoc").ToString(), 1)
                        AddText(fs, vDataRow("wdBal") + 20, 0)

                    Next

                    fs.Close()
                    '===END - Write data to file for merge===

                    ''===START- WdMailMerge Call===

                    ''[NOTES] - Project File Paths and Names to save Merge files
                    '' Merge information for "Final Notice Labels (print to MS Word)"
                    '' Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Termination_Report.docx")
                    '' Merge data path (vDhRptPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermRptData.txt")
                    '' Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    '' Fields to print on Door Hanger labels (wdTermDte, wdAccount, wdName, wdAddr, Bal, wdLoc, wdWater/wdSewer)

                    'Dim vWdDocOpen As String

                    'vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Termination_Report.docx"

                    ''Dim vPath As String
                    ''vPath = vDhRptPath

                    'Dim vWdDocSave As String
                    'vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                    ''this calls the mail merge with appropriate variables
                    'WdMailMerge(vWdDocOpen, vDhRptPath, vWdDocSave)
                    ''===END - WdMailMerge Call===

                    '===START- WdMailMerge Call===

                    '[NOTES] - Project File Paths and Names to save Merge files
                    ' Merge information for "Final Notice Labels (print to MS Word)"
                    ' vWdDocOpen = Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Termination_Report.docx")
                    ' vPath = Merge data path (vDhRptPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermRptData.txt")
                    '  vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    ' Fields to print on Door Hanger labels (wdTermDte, wdAccount, wdName, wdAddr, Bal, wdLoc, wdWater/wdSewer)

                    'Needed variables for this call to work are below

                    'Variable that deals with File Name and Path that the MailMerge should open
                    Dim vWdDocOpen As String = ""

                    'Variable deals with File Name and Path that the MailMerge should use as its datasource
                    'vPath = vDhRptPath

                    'Variable deals with File Name and Path that the MailMerge should use to save the new document
                    Dim vWdDocSave As String = ""

                    '[DEBUG] - check that the file exist before adding it to the MailMerge
                    If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\Termination_Report.docx") = True Then

                        vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Termination_Report.docx"

                        '[DEBUG] - check that the file exist before adding it to the MailMerge
                        If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\TermRptData.txt") = True Then


                            vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Termination Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                            'this calls the mail merge with appropriate variables
                            WdMailMerge(vWdDocOpen, vDhRptPath, vWdDocSave)

                            'User Notification - Application finished processing
                            frmBusyImport.Close()

                            'User Notification - Notify user Door Hanger Labels are complete
                            MessageBox.Show("Finished printing Termination Report. ", "Notification: Termination Report Printed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else

                            'Error - File doesn't exist
                            MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\TermRptData.txt"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    Else

                        'Error - File doesn't exist
                        MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\Termination_Report.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If
                    '===END - WdMailMerge Call===

                    'User Notification - Application finished processing
                    frmBusyImport.Close()

                Else

                    '[User Input] was DialogResult = Cancel
                    'User Notification - Notify user Door Hanger Label Printing has been cancelled
                    MessageBox.Show("Please correct try again.", "Printing is Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                'User Notification - Application finished processing
                frmBusyImport.Close()

                'Error - Notify user there are no accounts to print
                MessageBox.Show("There are no addresses selected to print for Cycle #" & vCycle & "." & vbCrLf & "Please select addresses to print.", "Data Error: Empty list!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to Print Termination Report." & vbCrLf & "(ReportToolStripMenuItem1_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'added this to update the date fields ASAP
        'fill table with new data
        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

        'Change the label for dates to match the current cycle
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

    End Sub

    Private Sub Cycle1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Cycle1ToolStripMenuItem.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_1" Radio Button
        rdoBtnCycle1.Checked = True

        'Auto Select "Door_Hanger" Notification Button
        rdoBtnDH.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 1

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle1ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cycle2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Cycle2ToolStripMenuItem.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_2" Radio Button
        rdoBtnCycle2.Checked = True

        'Auto Select "Door_Hanger" Notification Button
        rdoBtnDH.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 2

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle2ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Cycle3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Cycle3ToolStripMenuItem.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_3" Radio Button
        rdoBtnCycle3.Checked = True

        'Auto Select "Door_Hanger" Notification Button
        rdoBtnDH.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 3

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle3ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cycle4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Cycle4ToolStripMenuItem.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_4" Radio Button
        rdoBtnCycle4.Checked = True

        'Auto Select "Door_Hanger" Notification Button
        rdoBtnDH.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 4

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle4ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cycle1ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Cycle1ToolStripMenuItem1.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_1" Radio Button
        rdoBtnCycle1.Checked = True

        'Select "Termination" Notification Button
        rdoBtnTerm.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Termination Notifications

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 1

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle4ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Cycle2ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Cycle2ToolStripMenuItem1.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_2" Radio Button
        rdoBtnCycle2.Checked = True

        'Select "Termination" Notification Button
        rdoBtnTerm.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Termination Notifications

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 2

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle4ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Cycle3ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Cycle3ToolStripMenuItem1.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_3" Radio Button
        rdoBtnCycle3.Checked = True

        'Select "Termination" Notification Button
        rdoBtnTerm.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Termination Notifications

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 3

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle4ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Cycle4ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Cycle4ToolStripMenuItem1.Click
        '[NOTES] - The user can do this manually, I am offering another way to do the same thing

        'Auto Select "Cycle_4" Radio Button
        rdoBtnCycle4.Checked = True

        'Select "Termination" Notification Button
        rdoBtnTerm.Checked = True

        'Error Handling
        Try

            'Filter tblWorking data results to show all Termination Notifications

            '===START - Filter DB per vCycle===
            'Change the cycles value
            vCycle = 4

            'set filter on tblWorkingData to show all accounts of a selected cycle
            Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

            'Dates will display for current cycle
            Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
            '===END - Filter DB per vCycle===

            'change label
            lbfrmDteLog.Text = "Dates forCycle #" & vCycle

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (Cycle4ToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub LabelsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LabelsToolStripMenuItem1.Click
        'Printing Termination Labels 

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        'Error Handling
        Try

            'Verify there is data to print. 
            'declare variable for label count
            Dim vWdTermCount As Integer

            'Count records with scalar variable
            vWdTermCount = CType(Me.TblWorkingDataTableAdapter.ScalarWdTermCount(vCycle), Integer)

            'If there are accounts selected to print then print else notify user there was an error.
            If vWdTermCount > 0 Then

                'User Decision - verify with user they are printing vCycle
                vMsgBox = MessageBox.Show("Termination Date " & dtpTermDte.Value.ToShortDateString & vbCrLf & "Are you sure?", "Notification: Accept Termination Dates?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                If vMsgBox = Windows.Forms.DialogResult.OK Then
                    '[User Input] DialogResult = OK

                    'User Notification - Application Processing
                    frmBusyImport.Show()

                    'variables to hold dates
                    Dim vTermDte As Date

                    'initialize date variables
                    vTermDte = dtpTermDte.Value.ToShortDateString

                    'Update tblDateLog.dlTerm with Door Hanger date
                    Me.TblDateLogTableAdapter.UpdateTermByCycle(vTermDte, vCycle)

                    'Update tblWorkingData.wdTermDte with Door Hanger Dates
                    Me.TblWorkingDataTableAdapter.UpdateTermByCycle(vTermDte, vCycle)

                    '===START - Update tblDateLog so information is saved to db table===
                    'Trying to update database when the import action is processed
                    'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                    '[DEBUG] - Me.Validate()
                    Me.TblDateLogBindingSource.EndEdit()
                    Me.TblDateLogTableAdapter.Update(Me.DhA_sampleDataSet1.tblDateLog)
                    '===END - Update tblDateLog so information is saved to db table===

                    '===START - Write data to file for merge===
                    'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                    'variable for DH Report Path
                    Dim vDhLblPath As String

                    'path to DH Report text data file
                    vDhLblPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermLabelData.txt"

                    'Delete the file if it exist already
                    If File.Exists(vDhLblPath) Then
                        File.Delete(vDhLblPath)
                    End If

                    'Create the file
                    Dim fs As FileStream = File.Create(vDhLblPath)

                    'declare variable to read row
                    Dim vDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'data for file
                    Me.TblWorkingDataTableAdapter.FillByTermCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                    'create header for mailmerge (*wdTermDte, *wdName, *wdAddr, *wdAccount, *Bal, *wdLoc)
                    AddText(fs, "wdTermDte", 1)
                    AddText(fs, "wdName", 1)
                    AddText(fs, "wdAddr", 1)
                    AddText(fs, "wdAccount", 1)
                    AddText(fs, "wdLoc", 1)
                    AddText(fs, "Bal", 0)

                    'loop through dataset and write each line to file
                    For Each vDataRow In Me.DhA_sampleDataSet1.tblWorkingData.Rows()

                        '[DEBUG] - Dates and number types need to be converted or esle the merge breaks.

                        'move to the next line for a new record
                        AddText(fs, Environment.NewLine, 0)

                        'write all the data to appropriate fields

                        'convert date to Short Date format
                        Dim vDate As Date = #2/2/2022#
                        vDate = vDataRow("wdTermDte")
                        vDate = vDate.ToShortDateString
                        AddText(fs, vDate, 1)

                        AddText(fs, vDataRow("wdName").ToString(), 1)
                        AddText(fs, vDataRow("wdAddr").ToString(), 1)

                        AddText(fs, vDataRow("wdAccount").ToString(), 1)

                        AddText(fs, vDataRow("wdLoc").ToString(), 1)
                        AddText(fs, (vDataRow("wdBal") + 20), 0) '[TO DO] - Ask question about this $20 fee. Is it per service (water and/or sewer)

                    Next

                    fs.Close()
                    '===END - Write data to file for merge===

                    ''===START- WdMailMerge Call===

                    ''[NOTES] - Project File Paths and Names to save Merge files
                    '' Merge information for "Final Notice Labels (print to MS Word)"
                    '' Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Termination_Notice.docx")
                    '' Merge data path (vDhLblPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermLabelData.txt")
                    '' Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    '' Fields to print on Door Hanger labels (*wdTermDte, *wdName, *wdAddr, *wdAccount, *Bal, *wdLoc)
                    'Dim vWdDocOpen As String
                    'vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_Termination_Notice.docx"

                    ''Dim vPath As String
                    ''vPath = vDhLblPath

                    'Dim vWdDocSave As String
                    'vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                    ''this calls the mail merge with appropriate variables
                    'WdMailMerge(vWdDocOpen, vDhLblPath, vWdDocSave)
                    ''===END - WdMailMerge Call===

                    '===START- WdMailMerge Call===

                    '[NOTES] - Project File Paths and Names to save Merge files
                    ' Merge information for "Final Notice Labels (print to MS Word)"
                    ' vPath = Merge data path (vDhLblPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\TermLabelData.txt")
                    ' vWdDocOpen = Merge File Path (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Termination_Notice.docx")
                    ' vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
                    ' Fields to print on Door Hanger labels (*wdTermDte, *wdName, *wdAddr, *wdAccount, *Bal, *wdLoc)

                    'Needed variables for this call to work are below

                    'Variable that deals with File Name and Path that the MailMerge should open
                    Dim vWdDocOpen As String

                    'Variable deals with File Name and Path that the MailMerge should use as its datasource
                    'vPath = vDhLblPath

                    'Variable deals with File Name and Path that the MailMerge should use to save the new document
                    Dim vWdDocSave As String


                    '[DEBUG] - check that the file exist before adding it to the MailMerge
                    If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_Termination_Notice.docx") = True Then

                        vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\Merge\Door_Hanger_Termination_Notice.docx"

                        '[DEBUG] - check that the file exist before adding it to the MailMerge
                        If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\TermLabelData.txt") = True Then

                            vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Termination Notice Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                            'this calls the mail merge with appropriate variables
                            WdMailMerge(vWdDocOpen, vDhLblPath, vWdDocSave)

                            'User Notification - Application finished processing
                            frmBusyImport.Close()

                            'User Notification - Notify user Door Hanger Labels are complete
                            MessageBox.Show("Finished printing Termination Labels. ", "Notification: Termination Labels Printed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Else

                            'Error - File doesn't exist
                            MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\TermLabelData.txt"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        End If

                    Else

                        'Error - File doesn't exist
                        MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Termination_Notice.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                    '===END - WdMailMerge Call===

                Else

                    '[User Input] was DialogResult = Cancel
                    'User Notification - Notify user Door Hanger Label Printing has been cancelled
                    MessageBox.Show("Please correct Termination Dates," & vbCrLf & "and try again.", "Printing is Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            Else

                'Error - Notify user there are no accounts to print
                MessageBox.Show("There are no addresses selected to print for Cycle #" & vCycle & "." & vbCrLf & "Please select addresses to print.", "Data Error: Empty list!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            'User Notification - Application finished processing
            frmBusyImport.Close()

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Standard Error 
            MessageBox.Show("Unable to Print Termination Labels." & vbCrLf & "(LabelsToolStripMenuItem1_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'added this to update the date fields ASAP
        'fill table with new data
        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

        'Change the label for dates to match the current cycle
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

    End Sub

    Private Sub RdoBtnAll_Click(sender As Object, e As EventArgs) Handles RdoBtnAll.Click

        'Error Handling
        Try

            'Filter tblWorking data results to show all Door Hangers for the checked Cycle
            If RdoBtnAll.Checked Then

                '===START - Filter DB per vCycle===

                'set filter on tblWorkingData to show all accounts of a selected cycle
                Me.TblWorkingDataTableAdapter.Fill(Me.DhA_sampleDataSet1.tblWorkingData)

                'Dates will display for current cycle
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)
                '===END - Filter DB per vCycle===

                'change label
                'lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to show correct Door Hanger results. (RdoBtnAll_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub CSCReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSCReportToolStripMenuItem.Click
        '[DEBUG] - This didn't work. It just printed the data that was already in the table

        '[TO DO - Future Feature] - Turn the whole deleting and saving a CSC as a public shared sub that can be called by other parts of the program
        ' This would really work in a sub because it does all the work without passing any variables or values
        ' The only one that is passed is a public variable vCycle

        'Error Handling
        Try

            If CycleInput() = "Cancel" Then

                'Exit Sub because the vCycle wasn't successful

                'User Notification - Notify user CSC is complete
                MessageBox.Show("Customer Service Charges were not saved to file.", "Notification: Customer Service Charges Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                '===START - Delete tblExcelExport===

                'check for empty table
                If DhA_sampleDataSet1.tblExcelExport.Rows.Count <> 0 Then

                    'Delete tblExcelExport before adding accounts
                    'This avoids duplicate record add errors
                    Dim vTblExcelExportRow As DHA_sampleDataSet.tblExcelExportRow

                    vTblExcelExportRow = Me.DhA_sampleDataSet1.tblExcelExport.Rows(0)

                    For Each vTblExcelExportRow In DhA_sampleDataSet1.tblExcelExport.Rows

                        vTblExcelExportRow.Delete()

                    Next vTblExcelExportRow

                    Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)
                End If

                '===END - - Delete tblExcelExport===

                'Customer Accounts data for CSC file
                Me.TblWorkingDataTableAdapter.FillByHangCycle(Me.DhA_sampleDataSet1.tblWorkingData, vCycle)

                '===START- Fill tblExcelExport ===

                'Insert records into tblExcelExport 
                '(tblWorkingData.wdAccount, tblWorkingData.wdName, tblWorkingData.wdAddr, Water CSC = $10, Sewer CSC = $10, tblWorkingData.wdHangDte)
                ' Where tblWorkingData.wdHang = -1 and tblWorkingData.wdCycle= vCycle

                'declare variable to read row
                Dim vTblWdDataRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                'For Each Loop reads every row in tblWorkingData
                For Each vTblWdDataRow In DhA_sampleDataSet1.tblWorkingData.Rows

                    'create variable for new row
                    Dim vTblExNewRow As DataRow = DhA_sampleDataSet1.tblExcelExport.NewRow()

                    'My idea of mapping table rows, each vTblExNewRow(#) takes data from the other table
                    vTblExNewRow(0) = vTblWdDataRow(0)
                    vTblExNewRow(1) = vTblWdDataRow(8)
                    vTblExNewRow(2) = vTblWdDataRow(9)

                    'check for service
                    'If Water service <> NONE at $10 to CSV
                    If vTblWdDataRow(27).ToString <> "NONE" Then

                        vTblExNewRow(3) = 10 'create a variable for the Water Service Charge in the future

                    Else

                        vTblExNewRow(3) = 0 'create a variable for the Water Service Charge in the future

                    End If

                    'check for service
                    'If Sewer service <> NONE at $10 to CSV
                    If vTblWdDataRow(28).ToString <> "NONE" Then

                        vTblExNewRow(4) = 10 'create a variable for the Sewer Service Charge in the future

                    Else

                        vTblExNewRow(4) = 0 'create a variable for the Sewer Service Charge in the future

                    End If

                    vTblExNewRow(5) = vTblWdDataRow(21)

                    'exAccount	:= DhA_sampleDataSet1.tblExcelExport.Rows(0), |VARCHAR(11) NOT NULL PRIMARY KEY,
                    'exName			:= DhA_sampleDataSet1.tblExcelExport.Rows(1), |VARCHAR (MAX) NOT NULL
                    'exAddr			:= DhA_sampleDataSet1.tblExcelExport.Rows(2), |VARCHAR (MAX) NOT NULL
                    'exWtr			:= DhA_sampleDataSet1.tblExcelExport.Rows(3), |SMALLMONEY    DEFAULT ((10)) NULL
                    'exSwr			:= DhA_sampleDataSet1.tblExcelExport.Rows(4), |SMALLMONEY    DEFAULT ((10)) NULL
                    'exChgDte		:= DhA_sampleDataSet1.tblExcelExport.Rows(5)  |DATETIME2 (7) NOT NULL

                    'add new row to vTblExNewRow, loop through until all data copied
                    DhA_sampleDataSet1.tblExcelExport.Rows.Add(vTblExNewRow)

                Next vTblWdDataRow

                'v(0) =  tblWorkingData.[wdAccount] NCHAR(11) NOT NULL PRIMARY KEY,| v(0) =  exAccount
                'v(1) =  tblWorkingData.[wdAge0] SMALLMONEY NULL,                  |  
                'v(2) =  tblWorkingData.[wdAge1] SMALLMONEY NULL,                  |  
                'v(3) =  tblWorkingData.[wdAge2] SMALLMONEY NULL,                  |  
                'v(4) =  tblWorkingData.[wdAge3] SMALLMONEY NULL,                  |  
                'v(5) =  tblWorkingData.[wdAge4] SMALLMONEY NULL,                  |  
                'v(6) =  tblWorkingData.[wdAge5] SMALLMONEY NULL,                  |  
                'v(7) =  tblWorkingData.[wdBal] SMALLMONEY NULL,                   |  
                'v(8) =  tblWorkingData.[wdName] VARCHAR(MAX) NULL,                | v(1) =  exName
                'v(9) =  tblWorkingData.[wdAddr] VARCHAR(MAX) NULL,                | v(2) =  exAddr
                'v(10) = tblWorkingData.[wdLoc] VARCHAR(MAX) NULL,                 | 
                'v(11) = tblWorkingData.[wdCycle] INT NULL,                        | 
                'v(12) = tblWorkingData.[wdLstPayDte] DATETIME2 NULL,              | 
                'v(13) = tblWorkingData.[wdLstPayAmt] SMALLMONEY NULL,             | 
                'v(14) = tblWorkingData.[wdStCde] INT NULL,                        | 
                'v(15) = tblWorkingData.[wdStDesc] VARCHAR(30) NULL,               | 
                'v(16) = tblWorkingData.[wdPnotes] VARCHAR(MAX) NULL,              | 
                'v(17) = tblWorkingData.[wdANotes] VARCHAR(MAX) NULL,              | 
                'v(18) = tblWorkingData.[wdMNotes] VARCHAR(MAX) NULL,              | 
                'v(19) = tblWorkingData.[wdTerm] BIT NOT NULL,                     |         
                'v(20) = tblWorkingData.[wdHang] BIT NOT NULL,                     |         
                'v(21) = tblWorkingData.[wdHangDte] DATETIME2 NULL,                | v(5) = exChgDte
                'v(22) = tblWorkingData.[wdCntDte] DATETIME2 NULL,                 |         
                'v(23) = tblWorkingData.[wdTermDte] DATETIME2 NULL,                |         
                'v(24) = tblWorkingData.[wdAgreeDue] DATETIME2 NULL,               | 
                'v(25) = tblWorkingData.[wdPmtAgreed] SMALLMONEY NULL,             | 
                'v(26) = tblWorkingData.[wdUnPmt] SMALLMONEY NULL,                 | 
                'v(27) = tblWorkingData.[wdPriRte] VARCHAR(30) NULL,               | 
                'v(28) = tblWorkingData.[wdSecRte] VARCHAR(30) NULL,               | 
                'v(29) = tblWorkingData.[wdStCdeDte] DATETIME2 NULL,               | 
                'v(30) = tblWorkingData.[wdAgreedMade] Datetime2 null              | 
                'v(31) = tblWorkingData.[wdMinDue] SMALLMONEY NULL

                '===END - Fill tblExcelExport  ===

                '===START - Update tblExcelExport so information is saved to db table===
                'Trying to update database when the import action is processed
                'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                '[DEBUG] - Me.Validate()
                Me.TblExcelExportBindingSource.EndEdit()
                Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)
                '===END - Update tblExcelExport so information is saved to db table===

                '===START - Write data to file for Customer Service Charge ===
                'using this link to help me (http://msdn.microsoft.com/en-us/library/system.io.filestream(v=vs.110).aspx)

                'This files contains all the customer accounts that received a CSC.
                'Each time the Door Hanger labels are printed this file will be overwritten with new information, so save the file somewhere else as soon as possible.

                '[TO DO - Future Feature] -Let the user choose what directory they want this file saved to

                '[TO DO - Future Feature] -Automatically open the folder this is saved to, OR ask if they want the folder opened after saving it

                '[DEBUG] - Check for empty record set before saving CSC File. The CSC code is in two spots of the application so far.

                'variable for DH Report Path
                Dim vCscPath As String

                '[NOTES] - Export data to a Customer Service Charge file for Kathy. 
                '[TO DO - Future Feature] - Current Path to Customer Service Charge file (), allow user to save this under preferences
                vCscPath = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv"

                'Delete the file if it exist already
                If File.Exists(vCscPath) Then
                    File.Delete(vCscPath)
                End If

                'Create the file
                Dim vCscFs As FileStream = File.Create(vCscPath)

                'declare variable to read row
                Dim vCscDataRow As DataRow = DhA_sampleDataSet1.tblExcelExport.Rows(0)

                'data for file
                Me.TblExcelExportTableAdapter.Fill(Me.DhA_sampleDataSet1.tblExcelExport)

                '[TO DO - Future Feature] - validate for comma's. I don't have time now but that is a good thing to do.

                'This is a comma delimiter instead of a Tab delimiter, there are no quotes expected in this data that's why the delimiter works
                'create first row for file(exAccount,	exName,	exAddr,	exWtr,	exSwr,	exChgDte)
                AddText(vCscFs, "exAccount", 2)
                AddText(vCscFs, "exName", 2)
                AddText(vCscFs, "exAddr", 2)
                AddText(vCscFs, "exWtr", 2)
                AddText(vCscFs, "exSwr", 2)
                AddText(vCscFs, "exChgDte", 0)

                'loop through dataset and write each line to file
                For Each vCscDataRow In Me.DhA_sampleDataSet1.tblExcelExport.Rows()

                    '[DEBUG] - Dates and number types need to be converted or esle the merge breaks.

                    'move to the next line for a new record
                    AddText(vCscFs, Environment.NewLine, False)

                    'write all the data to appropriate fields
                    AddText(vCscFs, vCscDataRow("exAccount").ToString(), 2)
                    AddText(vCscFs, vCscDataRow("exName").ToString(), 2)
                    AddText(vCscFs, vCscDataRow("exAddr").ToString(), 2)
                    AddText(vCscFs, 10, 2)
                    AddText(vCscFs, 10, 2)
                    'convert date to Short Date format
                    Dim vDate As Date = #2/2/2022#
                    vDate = vCscDataRow("exChgDte")
                    vDate = vDate.ToShortDateString
                    AddText(vCscFs, vDate, 0)

                Next

                vCscFs.Close()

                'User Notification - Notify user CSC is complete
                MessageBox.Show("Finished saving Customer Service Charges to file. ", "Notification: Customer Service Charges Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '[TO DO - Future Feature] - Make this a link that the user can click on to open the save folder. Make this a notification that ask the user
                'MessageBox.Show with "Yes/No". If Yes "Labels have finished would you like to open CSC location?"
                'Yes open CSC location automatically
                'No Close the message and do nothing
                '===END - Write data to file for Customer Service Charge ===

                'added this to update the date fields ASAP
                'fill table with new data
                Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

                'Change the label for dates to match the current cycle
                Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to Save Customer Service Charge file." & vbCrLf & "(CSCReportToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub CustomerServiceChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerServiceChargesToolStripMenuItem.Click
        '[NOTES] - Re-Print CSC file to MailMerge

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        'Error Handling
        Try

            If CycleInput() = "Cancel" Then

                'Exit Sub because the vCycle wasn't successful
                Exit Sub

            End If

            'User Notification - Application Processing
            frmBusyImport.Show()

            '===START- WdMailMerge Call===
            '[NOTES] - Project File Paths and Names to save Merge files

            ' vCscPath = Merge data File Path (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv")
            ' vWdDocOpen = Merge Document to open (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_CSC_Report.docx")
            ' vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
            ' Fields to print on Door Hanger Report (exAccount,	exName,	exAddr,	exWtr,	exSwr,	exChgDte)

            'Needed variables for this call to work are below

            'Variable that deals with File Name and Path that the MailMerge should open
            Dim vWdDocOpen As String = ""

            'Variable deals with File Name and Path that the MailMerge should use as its datasource
            Dim vCscPath As String = ""

            'Variable deals with File Name and Path that the MailMerge should use to save the new document
            Dim vWdDocSave As String = ""

            '[DEBUG] - check that the file exist before adding it to the MailMerge
            If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_CSC_Report.docx") = True Then

                vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_CSC_Report.docx"

                '[DEBUG] - check that the file exist before adding it to the MailMerge
                If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv") = True Then

                    vCscPath = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv"

                    vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"

                    'this calls the mail merge with appropriate variables
                    WdMailMerge(vWdDocOpen, vCscPath, vWdDocSave)

                    'User Notification - Notify user CSC is complete
                    MessageBox.Show("Finished printing Customer Service Charges. ", "Notification: Customer Service Charges Printed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else

                    'Error - File doesn't exist
                    MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger CSC Charges " & vCycle & ".csv"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            Else

                'Error - File doesn't exist
                MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_CSC_Report.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
            '===END - WdMailMerge Call===

            'User Notification - Application finished processing
            frmBusyImport.Close()

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Standard Error 
            MessageBox.Show("Unable to Print CSC Report." & vbCrLf & "(CustomerServiceChargesToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'added this to update the date fields ASAP
        'fill table with new data
        Me.TblDateLogTableAdapter.FillByCycle(Me.DhA_sampleDataSet1.tblDateLog, vCycle)

        'Change the label for dates to match the current cycle
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #" & vCycle

    End Sub

    Public Shared Sub WdMailMerge(ByVal vWdDocOpen As String, ByVal vPath As String, ByVal vWdDocSave As String)
        '[NOTES] - This shared sub does all the MailMerging that is required throughout the application

        '[NOTES] - Following Code segment to put where you want to use this mailMerge call, just uncomment it after filling in the appropriate variables and notes
        ''===START- WdMailMerge Call===
        ''[NOTES] - Project File Paths and Names to save Merge files
        '' Merge information for "..."
        '' vPath = Merge data File Path (My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt")
        '' vWdDocOpen = Merge Document to open (My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx")
        '' vWdDocSave = Save Finished Document as (My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx")
        '' Fields to print on Door Hanger Report (wdAccount, wdName, wdAddr, Bal [wdBal + $20], Min [wdAge2 + wdAge3 + wdAge4 + wdAge5 + $20], wdTermDte, wdHangDte, wdHang [check box], wdTerm [check box], wdWater/wdSewer)
        '
        ''Needed variables for this call to work are below
        '
        ''Variable that deals with File Name and Path that the MailMerge should open
        'Dim vWdDocOpen As String = ""
        '
        ''Variable deals with File Name and Path that the MailMerge should use as its datasource
        'Dim vPath As String = ""
        '
        ''Variable deals with File Name and Path that the MailMerge should use to save the new document
        'Dim vWdDocSave As String = ""
        '
        ''[DEBUG] - check that the file exist before adding it to the MailMerge
        'If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx") = True Then
        '
        'vWdDocOpen = My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx"
        '
        ''[DEBUG] - check that the file exist before adding it to the MailMerge
        'If File.Exists(My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt") = True Then
        '
        'vPath = My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"
        '
        'vWdDocSave = My.Computer.FileSystem.CurrentDirectory & "\Reports\Door Hanger Report Cycle " & vCycle & "- " & DateTime.Today.Month.ToString() & "_" & DateTime.Today.Day.ToString() & "_" & DateTime.Today.Year.ToString() & "_" & TimeOfDay.Hour.ToString() & "_" & TimeOfDay.Minute.ToString() & ".docx"
        '
        ''this calls the mail merge with appropriate variables
        'WdMailMerge(vWdDocOpen, vDhRptPath, vWdDocSave)
        '
        ''Notify user CSC is complete
        'MessageBox.Show("Finished printing ??Customer Service Charges. ", "Notification: Customer Service Charges Printed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '
        'Else
        '
        '    'Error - File doesn't exist
        '    MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\Merge\DhReportData.txt"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '
        'End If
        '
        'Else
        '
        '    'Error - File doesn't exist
        '    MessageBox.Show("File (" & My.Computer.FileSystem.CurrentDirectory & "\MERGE\Door_Hanger_Report.docx"") doesn't exist." & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com)", "Data Error: File Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '
        'End If
        ''===END - WdMailMerge Call===

        'Error Handling
        Try

            '===START- MS Word MailMerge CODE===

            '[NOTES] - Found this link on how to MailMerge with MS Word(http://support.microsoft.com/kb/301656)

            'declare variables for MailMerge 
            Dim wrdApp As Word.Application
            Dim wrdDoc As Word._Document

            Dim wrdSelection As Word.Selection
            Dim wrdMailMerge As Word.MailMerge
            Dim wrdMergeFields As Word.MailMergeFields

            'create an instance of MS Word
            wrdApp = CreateObject("Word.Application")

            'make MS Word work in the background so user can't see it
            '[DEBUG] -  wrdApp.Visible = True
            wrdApp.Visible = False
            'wrdApp.Visible = True

            '[DEBUG] -I got a "Command Failed" exception because the document was waiting for user input.
            '[DEBUG] -I need a way to prevent this type of behavior in the future. The word document threw an exception and wanted to know what version it should recover.
            '[DEBUG] - it was a simple problem but not when I won't be around to look for it.
            '[DEBUG] -One solution is to have a list of master files I can copy and replace any that are giving errors.
            '[DEBUG] -Put this "Open" operation in a try-catch that will replace the original file from a backup folder
            'Open the merge template document in the background
            ' reference for this method is here (http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.documents.open.aspx)

            'Running to errors in the .exe
            '[DEBUG] - wrdDoc = wrdApp.Documents.Open(vWdDocOpen, Visible:=True)
            wrdDoc = wrdApp.Documents.Open(vWdDocOpen, Visible:=False)
            'wrdDoc = wrdApp.Documents.Open(vWdDocOpen, Visible:=True)

            'select as current document
            wrdDoc.Select()         'Select Method info here (http://msdn.microsoft.com/en-us/library/microsoft.office.tools.word.document.select.aspx)

            'required after .Select() is used
            wrdSelection = wrdApp.Selection() 'Selection info here (http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.selection.aspx)
            wrdMailMerge = wrdDoc.MailMerge() 'Not sure what this is doing

            With wrdDoc.MailMerge
                .MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters 'Information here (http://msdn.microsoft.com/en-us/library/microsoft.office.interop.word.wdmailmergemaindoctype.aspx)

                '[NOTES] - If the main document already contains merge fields, use those same merge fields in your header source. 
                ' If you do not do this, you must replace the merge fields in the main document to match the field names in the header source.
                ' MailMerge expects a Header as the first line in a MailMerge Data file - explained here (http://support.microsoft.com/kb/189014)
                ' The data in a header record should match the fields I am using in the mail merge word document. Information here (http://msdn.microsoft.com/en-us/library/office/ff196953(v=office.14).aspx)

                'OpenDataSource Information (http://msdn.microsoft.com/en-us/library/office/ff841005(v=office.14).aspx)
                .OpenDataSource(vPath, AddToRecentFiles:=False)

                '[NOTE] - OpenDataSource is unable to connect to a .mdf file. 
                ' I save the document in .txt format with Tab delimiters for the merge.

                '[TO DO - Future Feature] - use the data merge file as a log file or backup.
                ' (vDhRptPath = My.Computer.FileSystem.CurrentDirectory & "\MERGE\DhLabelData.txt")
                ' Not set up yet. The file is saved but I don't use it for anything but the mailmerge currently

                'Perform mail merge - .Destination
                .Destination = Word.WdMailMergeDestination.wdSendToNewDocument 'http://msdn.microsoft.com/en-US/library/microsoft.office.interop.word.wdmailmergedestination(v=office.15).aspx
                .SuppressBlankLines = True ' supress blank lines on empty fields

                With .DataSource 'Information here (http://msdn.microsoft.com/en-us/library/office/ff835762(v=office.14).aspx)
                    .FirstRecord = Word.WdMailMergeDefaultRecord.wdDefaultFirstRecord
                    .LastRecord = Word.WdMailMergeDefaultRecord.wdDefaultLastRecord
                End With

                'verifies that the MailMerge datasource is attached (wdMainAndDataSource)
                'enumaration variables for .State (http://msdn.microsoft.com/en-US/library/microsoft.office.interop.word.wdmailmergestate(v=office.15).aspx)
                If .State = Word.WdMailMergeState.wdMainAndDataSource Then
                    .Execute(Pause:=False)
                End If

            End With

            '[NOTES] - links for the future
            ' Information on how to create Merge Fields in MS Word 2010 document (http://office.microsoft.com/en-us/word-help/insert-and-format-field-codes-in-word-2010-HA101830917.aspx)
            ' Field Codes in MS Word 2010 (http://office.microsoft.com/en-us/word-help/field-codes-in-word-HA010100426.aspx?CTT=5&origin=HA101830917)
            ' Make a checklist in MS Word 2010 (http://office.microsoft.com/en-us/word-help/make-a-checklist-in-word-HA010030748.aspx?CTT=5&origin=HA010100426)

            'Save the document in a report folder with current MM_DD_YYYY_Hour_Minute to make entry unique
            'wrdApp.ActiveDocument.SaveAs2(vWdDocSave)

            '[DEBUG] -I think SaveAs2 comes from a newer version of this Word Document Model
            '[DEBUG continued] - I think the program crashes at this point. That doesn't explain why my Try...Catch isn't dealing with this.
            wrdApp.ActiveDocument.SaveAs(vWdDocSave)

            'Close all the word documents 
            'don't save any changes the merge changes were saved above in SaveAs2 statement
            wrdDoc.Close(False)

            ' Release References
            wrdSelection = Nothing
            wrdMailMerge = Nothing
            wrdMergeFields = Nothing
            wrdDoc = Nothing

            wrdApp.Quit()
            wrdApp = Nothing
            '===END- MS Word MailMerge CODE===

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to call WdMailMerge successfully." & vbCrLf & "Close all Microsoft Word Apps." & vbCrLf & "(Form1_WdMailMerge) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Close all instances of MS Word
            'Find instance of Word that didn't close
            'try to close instance of word
            For Each p As Process In System.Diagnostics.Process.GetProcessesByName("winword")
                Try
                    p.Kill()
                    ' possibly with a timeout
                    p.WaitForExit()
                    ' process was terminating or can't be terminated - deal with it
                Catch winException As Win32Exception
                    ' process has already exited - might be able to let this one go
                    'Standard Error 
                    MessageBox.Show("Unable to winException." & vbCrLf & "(Form1_WdMailMerge) Original error: " & winException.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Catch invalidException As InvalidOperationException
                    'Standard Error 
                    MessageBox.Show("Unable to invalidException." & vbCrLf & "(Form1_WdMailMerge) Original error: " & invalidException.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            Next

        End Try

    End Sub

    Private Sub ImportedDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportedDataToolStripMenuItem.Click
        'Allow the user to view all the imported data easily

        Dim frmImportData As frmImpData = New frmImpData
        frmImportData.Show()

    End Sub

    Private Sub CleanSweepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CleanSweepToolStripMenuItem.Click
        'Clear Door Hanger and Termination marks
        'Update dlCSweep

        'User Notification - Application Processing
        Dim frmBusyImport As frmBusy
        frmBusyImport = New frmBusy
        frmBusyImport.lblMsg.Text = "Application Busy... Please Wait"
        frmBusyImport.Text = "Door Hanger Application Busy"

        Try 'Error Handling

            'User Decision - msgbox for user to cancel their operation
            vMsgBox = MessageBox.Show("This action will erase all the Marks for (Door Hanger) and (Termination)." & vbCrLf & "Do you want to continue?", "Clean Sweep the data?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If vMsgBox = Windows.Forms.DialogResult.OK Then

                'User Notification - Application Processing
                frmBusyImport.Show()

                'update wdTerm and wdHang to false
                Me.TblWorkingDataTableAdapter.UpdateSweepNoti()

                'update tblDateLog.dlCSweep = Now()
                Me.TblDateLogTableAdapter.FillBySweepNow("" & Now().ToShortDateString & "")

                'Change label after Clean Sweep complete
                Me.lblUserNotification.Text = "Finished Clean Sweep-Begin Marking Accounts"

                'User Notification - Application finished processing
                frmBusyImport.Close()

            Else

                'User Notification - Notify user this was cancelled
                MessageBox.Show("Action cancelled!", "Notification: Clean Sweep Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
            '[DEBUG] - Me.Validate()
            Me.TblWorkingDataBindingSource.EndEdit()
            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

            'show updated data
            Me.TblWorkingDataTableAdapter.Fill(Me.DhA_sampleDataSet1.tblWorkingData)

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'User Notification - Application finished processing
            frmBusyImport.Close()

            'Standard Error 
            MessageBox.Show("Unable to Clean Sweep the data." & vbCrLf & "(CleanSweepToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub PrintCSC(sender As Object, e As EventArgs)
        '[TO DO - Future Feature] - Make this action a call that can be used elsewhere in the code.
        ' This is all commented so I can work on it later

        Try 'Error Handling

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to _MESSAGE." & vbCrLf & "(LOCATION_HERE) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cbTermPrinted_MouseUp(sender As Object, e As MouseEventArgs) Handles cbTermPrinted.MouseUp

        If cbTermPrinted.CheckState = CheckState.Checked And cbDHPrinted.CheckState = CheckState.Unchecked Then

            'User Warning - Notify that the DH was not selected
            MessageBox.Show("Did this person get a Door Hanger already?" & vbCrLf & "", "Warning: Door Hanger not marked", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '[TO DO - Future Feature] - This should be added after the Table of User Preferences is created and finished.
        '[NOTES] - have this open a form that allows the user to make choices about items saved in the user preferences table.
        ' This option could be a shortcut to selecting the preferences during actions or install.
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        '[TO DO - Future Feature] - Disable all controls on form until the user imports data. Don't disable the ToolStrip

        Try 'Error Handling

            Do While Me.DhA_sampleDataSet1.tblShutOff.Rows.Count <> 0

                'define dataset
                Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblShutOff.Rows(0)

                'delete row
                vDeleteRow.Delete()

                'notify database of delete
                Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)

            Loop

            '===START - Update tblShutOff so information is saved to db table===
            'Trying to update database when the import action is processed
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            '[DEBUG] - Removed Validate in this part because it was causing errors since there are empty tables.
            'Me.Validate()

            Me.TblShutOffBindingSource.EndEdit()
            Me.TblShutOffTableAdapter.Update(Me.DhA_sampleDataSet1.tblShutOff)
            '===END - Update tblShutOff so information is saved to db table===

            Do While Me.DhA_sampleDataSet1.tblWorkingData.Rows.Count <> 0

                'define dataset
                Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                'delete row
                vDeleteRow.Delete()

                'notify database of delete
                Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)

            Loop

            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database when the import action is processed
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            '[DEBUG] - Removed Validate in this part because it was causing errors since there are empty tables.
            'Me.Validate()

            Me.TblWorkingDataBindingSource.EndEdit()
            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

            Do While Me.DhA_sampleDataSet1.tblExcelExport.Rows.Count <> 0

                'define dataset
                Dim vDeleteRow As DataRow = DhA_sampleDataSet1.tblExcelExport.Rows(0)

                'delete row
                vDeleteRow.Delete()

                'notify database of delete
                Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)

            Loop

            '===START - Update tblExcelExport so information is saved to db table===
            'Trying to update database when the import action is processed
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            '[DEBUG] - Removed Validate in this part because it was causing errors since there are empty tables.
            'Me.Validate()

            Me.TblExcelExportBindingSource.EndEdit()
            Me.TblExcelExportTableAdapter.Update(Me.DhA_sampleDataSet1.tblExcelExport)
            '===END - Update tblExcelExport so information is saved to db table===

            'User Notification - 
            MessageBox.Show("Finished clearing all data in application." & vbCrLf & " ", "Notification: Clear All Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to Clear all the data." & vbCrLf & "(ClearAllToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    'code to read text box in another form
    Private vAccountValue As String
    Public Property vAccount() As String
        Get
            Return txtAccount.Text
        End Get
        Set(ByVal value As String)
            vAccountValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vNameValue As String
    Public Property vName() As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal value As String)
            vNameValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vAddrValue As String
    Public Property vAddr() As String
        Get
            Return txtAddr.Text
        End Get
        Set(ByVal value As String)
            vAddrValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vLocValue As String
    Public Property vLoc() As String
        Get
            Return txtLoc.Text
        End Get
        Set(ByVal value As String)
            vLocValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vLstPayDteValue As String
    Public Property vLstPayDte() As String
        Get
            Return txtLstPayDte.Text
        End Get
        Set(ByVal value As String)
            vLstPayDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vLstPayAmtValue As String
    Public Property vLstPayAmt() As String
        Get
            Return txtLstPayAmt.Text
        End Get
        Set(ByVal value As String)
            vLstPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vStDescValue As String
    Public Property vStDesc() As String
        Get
            Return txtStCde.Text
        End Get
        Set(ByVal value As String)
            vStDescValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vPnotesValue As String
    Public Property vPnotes() As String
        Get
            Return txtPnotes.Text
        End Get
        Set(ByVal value As String)
            vPnotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vAnotesValue As String
    Public Property vAnotes() As String
        Get
            Return txtANotes.Text
        End Get
        Set(ByVal value As String)
            vAnotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vMNotesValue As String
    Public Property vMNotes() As String
        Get
            Return txtMNotes.Text
        End Get
        Set(ByVal value As String)
            vMNotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vBalValue As String
    Public Property vBal() As String
        Get
            Return txtBal.Text
        End Get
        Set(ByVal value As String)
            vBalValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vAgrPayDueDteValue As String
    Public Property vAgrPayDueDte() As String
        Get
            Return txtAgrPayDueDte.Text
        End Get
        Set(ByVal value As String)
            vAgrPayDueDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vAgrPayAmtValue As String
    Public Property vAgrPayAmt() As String
        Get
            Return txtAgrPayAmt.Text
        End Get
        Set(ByVal value As String)
            vAgrPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vUnPayAmtValue As String
    Public Property vUnPayAmt() As String
        Get
            Return txtUnPayAmt.Text
        End Get
        Set(ByVal value As String)
            vUnPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vPriRteValue As String
    Public Property vPriRte() As String
        Get
            Return txtPriRte.Text
        End Get
        Set(ByVal value As String)
            vPriRteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vSecRteValue As String
    Public Property vSecRte() As String
        Get
            Return txtSecRte.Text
        End Get
        Set(ByVal value As String)
            vSecRteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vStCdeDteValue As String
    Public Property vStCdeDte() As String
        Get
            Return txtStCdeDte.Text
        End Get
        Set(ByVal value As String)
            vStCdeDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vAgrMadeDteValue As String
    Public Property vAgrMadeDte() As String
        Get
            Return txtAgrMadeDte.Text
        End Get
        Set(ByVal value As String)
            vAgrMadeDteValue = value
        End Set
    End Property

    Private Sub BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorSaveItem.Click

        '[NOTES] - Save the current account to the Door Hanger list 
        'Mark True the wdHang and/or wdTerm, Check if either rdoBtnDH.Checked or rdoBtnTerm.Checked is True

        Try 'Error Handling

            'ask user [inputbox] which cycle this account should be added to for Door Hangers or Terminations
            If CycleInput() = "Cancel" Then

                'User Notification - 
                MessageBox.Show("Save Cancelled.", "Notification: Account Update Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                'Exit Sub because the vCycle wasn't successful
                Exit Sub

            Else
                'Do this by opening a new form
                'Pass the variables back this form

                ''open another form that allows the user to add the fields and save them to the Datatable
                'Dim frmAddDoorHanger As frmAddTblWD
                'frmAddDoorHanger = New frmAddTblWD()

                ''ShowDialog() will open the new form modally
                'frmAddDoorHanger.ShowDialog(Me)

                'disposes of frmAddTblWD, which is only hidden after dialogResult is returned
                'frmAddDoorHanger.Dispose()

                '[NOTES] - Updating the tblWorkingData with the following 3 lines of code
                'This was giving an error until I moved the .Validate() and .EndEdit() before the update 
                'and removed the second update, which was frivulous
                '[DEBUG] - Me.Validate()
                Me.TblWorkingDataBindingSource.EndEdit()
                'update current record
                Me.TblWorkingDataTableAdapter.UpdateFrmButton(Me.txtAccount.Text, vCycle)

                'User Notification - 
                MessageBox.Show("Account saved to new Cycle." & vbCrLf & "It can printed with current Door Hangers now!", "Notification: Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to save account to new cycle." & vbCrLf & "(BindingNavigatorSaveItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BindingNavigatorAddItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddItem.Click
        Try 'Error Handling

            '[NOTES] - Add an account that is not in the Door Hanger Application or import
            'Do this by opening a new form
            'Pass the variables back this form

            'open another form that allows the user to add the fields and save them to the Datatable
            Dim frmAddDoorHanger As frmAddTblWD
            frmAddDoorHanger = New frmAddTblWD()

            'ShowDialog() will open the new form modally
            frmAddDoorHanger.ShowDialog(Me)

            'disposes of frmAddTblWD, which is only hidden after dialogResult is returned
            frmAddDoorHanger.Dispose()

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to Add new Account." & vbCrLf & "(BindingNavigatorAddItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub txtAccount_Validating(sender As Object, e As CancelEventArgs) Handles txtAccount.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then
            'Check For invalid strings
            If txtAccount.Text = "" Or txtAccount.Text Is Nothing Or txtAccount.Text.Count > 11 Then

                'Set to known variable amount
                'txtAccount.Text = "None" & Now()
                e.Cancel = True

                'change background to indicate an issue
                txtAccount.BackColor = Color.IndianRed

                'Error - Invalid data entry
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text." & vbCrLf & "It cannot be empty nor larger than 11 characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtAccount.BackColor = SystemColors.Window

            End If
        End If

    End Sub

    Private Sub txtName_Validating(sender As Object, e As CancelEventArgs) Handles txtName.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtName.Text = "" Or txtName.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtName.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtName.BackColor = SystemColors.Window

            End If

        End If
    End Sub

    Private Sub txtAddr_Validating(sender As Object, e As CancelEventArgs) Handles txtAddr.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtAddr.Text = "" Or txtAddr.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtAddr.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtAddr.BackColor = SystemColors.Window

            End If


        End If
    End Sub


    Private Sub txtLoc_Validating(sender As Object, e As CancelEventArgs) Handles txtLoc.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtLoc.Text = "" Or txtLoc.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtLoc.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtLoc.BackColor = SystemColors.Window

            End If

        End If

    End Sub

    Private Sub txtStCde_Validating(sender As Object, e As CancelEventArgs) Handles txtStCde.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtStCde.Text = "" Or txtStCde.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtStCde.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                ''[TO DO - Future Feature] - Add a way to change the color based on what value is in the field
                ''check for specific words
                'If txtStCde.Text = "Water Off at our Valve" Then

                '    'change background to indicate an issue
                '    txtStCde.BackColor = Color.Blue

                '    'change text color for contrast
                '    txtStCde.ForeColor = Color.White

                '    'change border so it stands out
                '    txtStCde.BorderStyle = BorderStyle.FixedSingle
                'Else

                '    'change background to indicate an issue
                '    txtStCde.BackColor = SystemColors.Window

                '    'change border so it stands out
                '    txtStCde.BorderStyle = BorderStyle.Fixed3D

                '    'change text color for contrast
                '    txtStCde.ForeColor = SystemColors.WindowText

                'End If

                'change background to indicate an issue
                txtStCde.BackColor = Color.Blue

                'change text color for contrast
                txtStCde.ForeColor = Color.White

                'change border so it stands out
                txtStCde.BorderStyle = BorderStyle.FixedSingle

            End If

        End If

    End Sub

    Private Sub txtPriRte_Validating(sender As Object, e As CancelEventArgs) Handles txtPriRte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtPriRte.Text = "" Or txtPriRte.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtPriRte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtPriRte.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtSecRte_Validating(sender As Object, e As CancelEventArgs) Handles txtSecRte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtSecRte.Text = "" Or txtSecRte.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtSecRte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtSecRte.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtMNotes_Validating(sender As Object, e As CancelEventArgs) Handles txtMNotes.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtMNotes.Text = "" Or txtMNotes.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtMNotes.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtMNotes.BackColor = SystemColors.Window

            End If

        End If

    End Sub

    Private Sub txtPnotes_Validating(sender As Object, e As CancelEventArgs) Handles txtPnotes.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

            'Check For invalid strings
            If txtPnotes.Text = "" Or txtPnotes.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtPnotes.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtPnotes.BackColor = SystemColors.Window

            End If

        End If
    End Sub

    Private Sub txtANotes_Validating(sender As Object, e As CancelEventArgs) Handles txtANotes.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'Check For invalid strings
            If txtANotes.Text = "" Or txtANotes.Text Is Nothing Then

                'Set to known variable amount
                'txt.Text ="None" & Now()
                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtANotes.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'change background to indicate an issue
                txtANotes.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtStCdeDte_Validating(sender As Object, e As CancelEventArgs) Handles txtStCdeDte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtStCdeDte.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtStCdeDte.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtStCdeDte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtStCdeDte.Text = vStringDate

                'change background to indicate an issue
                txtStCdeDte.BackColor = SystemColors.Window

            End If

        End If

    End Sub

    Private Sub txtLstPayDte_Validating(sender As Object, e As CancelEventArgs) Handles txtLstPayDte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtLstPayDte.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtLstPayDte.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtLstPayDte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtLstPayDte.Text = vStringDate

                'change background to indicate an issue
                txtLstPayDte.BackColor = SystemColors.Window

            End If

        End If

    End Sub

    Private Sub txtAgrMadeDte_Validating(sender As Object, e As CancelEventArgs) Handles txtAgrMadeDte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtAgrMadeDte.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtAgrMadeDte.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtAgrMadeDte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtAgrMadeDte.Text = vStringDate

                'change background to indicate an issue
                txtAgrMadeDte.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtAgrPayDueDte_Validating(sender As Object, e As CancelEventArgs) Handles txtAgrPayDueDte.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtAgrPayDueDte.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtAgrPayDueDte.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtAgrPayDueDte.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtAgrPayDueDte.Text = vStringDate

                'change background to indicate an issue
                txtAgrPayDueDte.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtdlNew_Validating(sender As Object, e As CancelEventArgs) Handles txtdlNew.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtdlNew.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtdlNew.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtdlNew.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtdlNew.Text = vStringDate

                'change background to indicate an issue
                txtdlNew.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtdlUpdate_Validating(sender As Object, e As CancelEventArgs) Handles txtdlUpdate.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtdlUpdate.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtdlUpdate.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtdlUpdate.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtdlUpdate.Text = vStringDate

                'change background to indicate an issue
                txtdlUpdate.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtdlDH_Validating(sender As Object, e As CancelEventArgs) Handles txtdlDH.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtdlDH.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtdlDH.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtdlDH.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtdlDH.Text = vStringDate

                'change background to indicate an issue
                txtdlDH.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtdlTerm_Validating(sender As Object, e As CancelEventArgs) Handles txtdlTerm.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtdlTerm.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtdlTerm.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtdlTerm.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtdlTerm.Text = vStringDate

                'change background to indicate an issue
                txtdlTerm.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtdlCSweep_Validating(sender As Object, e As CancelEventArgs) Handles txtdlCSweep.Validating
        If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then


            'check for invalid dates

            'declare variable to accept converted date
            Dim vDate As Date = #1/1/1900#

            'dim string variable to capture user input
            Dim vStringDate As String = txtdlCSweep.Text

            If DateTime.TryParse(vStringDate, vDate) = False Then

                txtdlCSweep.Text = vStringDate

                e.Cancel = True 'cancel validating event, keeps user in the control

                'change background to indicate an issue
                txtdlCSweep.BackColor = Color.IndianRed

                'Error - My coding caused an issue
                MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                'pass string data and convert it for variable to accept
                vStringDate = Convert.ToDateTime(vDate).ToShortDateString

                'end system.DateTime conversion
                txtdlCSweep.Text = vStringDate

                'change background to indicate an issue
                txtdlCSweep.BackColor = SystemColors.Window

            End If


        End If
    End Sub

    Private Sub txtLstPayAmt_Validating(sender As Object, e As CancelEventArgs) Handles txtLstPayAmt.Validating
        Try 'Error Handling

            If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

                'convert decimals to look like Currency

                'declare variable to accept converted Decimal data
                'initialize to a known value
                Dim vDecimal As Decimal = 1.0

                'dim string variable to assist in conversion
                'initialize to current textbox value
                Dim vStringDecimal As String = txtLstPayAmt.Text

                'remove $ from string
                vStringDecimal = vStringDecimal.Replace("$", "")

                'check For non decimal values in textbox
                If Decimal.TryParse(vStringDecimal, vDecimal) = False Then
                    'if value cannot be converted alert user

                    're-enter value that was originally typed into text box
                    txtLstPayAmt.Text = vStringDecimal

                    'change background to indicate an issue
                    txtLstPayAmt.BackColor = Color.IndianRed

                    'Error - My coding caused an issue
                    MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    e.Cancel = True 'cancel validating event, keeps user in the control

                Else

                    'convert text data to look like a decimal (.00) for currency
                    'txtLstPayAmt.Text = vDecimal.ToString("C2") 'currency conversion
                    'txtLstPayAmt.Text = vDecimal.ToString("f2") 

                    'change background to indicate an issue
                    txtLstPayAmt.BackColor = SystemColors.Window

                End If

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to add data to database." & vbCrLf & "(txtLstPayAmt_Validating) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtUnPayAmt_Validating(sender As Object, e As CancelEventArgs) Handles txtUnPayAmt.Validating
        Try 'Error Handling

            If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

                'convert decimals to look like Currency

                'declare variable to accept converted Decimal data
                'initialize to a known value
                Dim vDecimal As Decimal = 1.0

                'dim string variable to assist in conversion
                'initialize to current textbox value
                Dim vStringDecimal As String = txtUnPayAmt.Text

                'remove $ from string
                vStringDecimal = vStringDecimal.Replace("$", "")

                'check For non decimal values in textbox
                If Decimal.TryParse(vStringDecimal, vDecimal) = False Then
                    'if value cannot be converted alert user

                    're-enter value that was originally typed into text box
                    txtUnPayAmt.Text = vStringDecimal

                    'change background to indicate an issue
                    txtUnPayAmt.BackColor = Color.IndianRed

                    'Error - My coding caused an issue
                    MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    e.Cancel = True 'cancel validating event, keeps user in the control

                Else


                    'change background to indicate an issue
                    txtUnPayAmt.BackColor = SystemColors.Window

                    'change border so it stands out
                    txtUnPayAmt.BorderStyle = BorderStyle.Fixed3D

                    'change text color for contrast
                    txtUnPayAmt.ForeColor = SystemColors.WindowText

                    'convert text data to look like a decimal (.00) for currency
                    'txtUnPayAmt.Text = vDecimal.ToString("C2")
                    'txtUnPayAmt.Text = vDecimal.ToString("f2")

                End If

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to add data to database." & vbCrLf & "(txtUnPayAmt_Validating) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtAgrPayAmt_Validating(sender As Object, e As CancelEventArgs) Handles txtAgrPayAmt.Validating
        Try 'Error Handling

            If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

                'convert decimals to look like Currency

                'declare variable to accept converted Decimal data
                'initialize to a known value
                Dim vDecimal As Decimal = 1.0

                'dim string variable to assist in conversion
                'initialize to current textbox value
                Dim vStringDecimal As String = txtAgrPayAmt.Text

                'remove $ from string
                vStringDecimal = vStringDecimal.Replace("$", "")

                'check For non decimal values in textbox
                If Decimal.TryParse(vStringDecimal, vDecimal) = False Then
                    'if value cannot be converted alert user

                    're-enter value that was originally typed into text box
                    txtAgrPayAmt.Text = vStringDecimal

                    'change background to indicate an issue
                    txtAgrPayAmt.BackColor = Color.IndianRed

                    'Error - My coding caused an issue
                    MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    e.Cancel = True 'cancel validating event, keeps user in the control

                Else

                    'convert text data to look like a decimal (.00) for currency
                    'txtAgrPayAmt.Text = vDecimal.ToString("C2")
                    'txtAgrPayAmt.Text = vDecimal.ToString("f2")

                    'change background to indicate an issue
                    txtAgrPayAmt.BackColor = SystemColors.Window

                End If

            End If

        Catch ex As Exception

            'keep a log file in a log folder
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to add data to database." & vbCrLf & "(txtAgrPayAmt_Validating) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        Try 'Error Handling

            'create instance of About form
            Dim vfrmAbout As frmAbout = New frmAbout

            'open About Form
            vfrmAbout.Show()

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to _MESSAGE." & vbCrLf & "(LOCATION_HERE) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub StatusCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusCodesToolStripMenuItem.Click
       
        Try 'Error Handling

            Dim vfrmCodes As frmCodes = New frmCodes
            vfrmCodes.Show()

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to _MESSAGE." & vbCrLf & "(LOCATION_HERE) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub cbDHPrinted_Click(sender As Object, e As EventArgs) Handles cbDHPrinted.Click
        Try 'Error Handling

            'save user selection immediately
            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            Me.TblWorkingDataBindingSource.EndEdit()

            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to mark account for Door Hanger." & vbCrLf & "(cbDHPrinted_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub cbTermPrinted_Click(sender As Object, e As EventArgs) Handles cbTermPrinted.Click
        Try 'Error Handling

            'save user selection immediately
            '===START - Update tblWorkingData so information is saved to db table===
            'Trying to update database
            'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)

            Me.TblWorkingDataBindingSource.EndEdit()

            Me.TblWorkingDataTableAdapter.Update(Me.DhA_sampleDataSet1.tblWorkingData)
            '===END - Update tblWorkingData so information is saved to db table===

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to mark account for Door Hanger." & vbCrLf & "(cbTermPrinted_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtBal_Validated(sender As Object, e As EventArgs) Handles txtBal.Validated

        Try 'Error Handling

            'If txtBal.Text <> "" Then

            '    'change to currency with $
            '    txtBal.Text = FormatCurrency(txtBal.Text)

            'End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to complete data validation and add dollar sign ($)." & vbCrLf & "(txtBal_Validated) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub txtBal_Validating(sender As Object, e As CancelEventArgs) Handles txtBal.Validating
        Try 'Error Handling

            If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

                'convert decimals to look like Currency

                'declare variable to accept converted Decimal data
                'initialize to a known value
                Dim vDecimal As Decimal = 1.0

                'dim string variable to assist in conversion
                'initialize to current textbox value
                Dim vStringDecimal As String = txtBal.Text

                'remove $ from string
                vStringDecimal = vStringDecimal.Replace("$", "")

                'check For non decimal values in textbox
                If Decimal.TryParse(vStringDecimal, vDecimal) = False Then
                    'if value cannot be converted alert user

                    're-enter value that was originally typed into text box
                    txtBal.Text = vStringDecimal

                    'change background to indicate an issue
                    txtBal.BackColor = Color.IndianRed

                    'Error - My coding caused an issue
                    MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    e.Cancel = True 'cancel validating event, keeps user in the control

                Else

                    'convert text data to look like a decimal (.00) for currency
                    'txtBal.Text = vDecimal.ToString("C2")
                    'txtBal.Text = vDecimal.ToString("f2")

                    'change background to indicate an issue
                    txtBal.BackColor = SystemColors.Window

                End If

            End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to add data to database." & vbCrLf & "(txtBal_Validating) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtLstPayAmt_Validated(sender As Object, e As EventArgs) Handles txtLstPayAmt.Validated
        Try 'Error Handling

            'If txtLstPayAmt.Text <> "" Then

            '    'change to currency with $
            '    txtLstPayAmt.Text = FormatCurrency(txtLstPayAmt.Text)

            'End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to complete data validation and add dollar sign ($)." & vbCrLf & "(txtLstPayAmt_Validated) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtUnPayAmt_Validated(sender As Object, e As EventArgs) Handles txtUnPayAmt.Validated
        Try 'Error Handling

            'If txtUnPayAmt.Text <> "" Then

            '    'change to currency with $
            '    txtUnPayAmt.Text = FormatCurrency(txtUnPayAmt.Text)

            'End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to complete data validation and add dollar sign ($)." & vbCrLf & "(txtUnPayAmt_Validated) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub txtAgrPayAmt_Validated(sender As Object, e As EventArgs) Handles txtAgrPayAmt.Validated
        Try 'Error Handling

            'If txtAgrPayAmt.Text <> "" Then

            '    'change to currency with $
            '    txtAgrPayAmt.Text = FormatCurrency(txtAgrPayAmt.Text)

            'End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to complete data validation and add dollar sign ($)." & vbCrLf & "(txtAgrPayAmt_Validated) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub TblWorkingDataBindingSource_CurrentItemChanged(sender As Object, e As EventArgs) Handles TblWorkingDataBindingSource.CurrentItemChanged
        Try 'Error Handling

            '[TO DO - Future Feature] - Add a way to change the color based on what value is in the field
            'change color of unposted payment to make it stand out
            If txtUnPayAmt.Text <> "$0.00" Then

                'change background to indicate an issue
                txtUnPayAmt.BackColor = Color.Blue

                'change text color for contrast
                txtUnPayAmt.ForeColor = Color.White

                'change border so it stands out
                txtUnPayAmt.BorderStyle = BorderStyle.FixedSingle

            Else

                'change background to indicate an issue
                txtUnPayAmt.BackColor = SystemColors.Window

                'change border so it stands out
                txtUnPayAmt.BorderStyle = BorderStyle.Fixed3D

                'change text color for contrast
                txtUnPayAmt.ForeColor = SystemColors.WindowText

            End If

            If txtStCde.Text <> "" Then

                '[TO DO - Future Feature] - Add a way to change the color based on what value is in the field
                'check for specific words
                If txtStCde.Text = "Water Off at our Valve" Then

                    'change background to indicate an issue
                    txtStCde.BackColor = Color.Blue

                    'change text color for contrast
                    txtStCde.ForeColor = Color.White

                    'change border so it stands out
                    txtStCde.BorderStyle = BorderStyle.FixedSingle
                Else

                    'change background to indicate an issue
                    txtStCde.BackColor = SystemColors.Window

                    'change border so it stands out
                    txtStCde.BorderStyle = BorderStyle.Fixed3D

                    'change text color for contrast
                    txtStCde.ForeColor = SystemColors.WindowText

                End If

            End If

            If txtMNotes.Text <> "" Then

                '[TO DO - Future Feature] - Add a way to change the color based on what value is in the field
                'check for specific words
                If InStr(txtMNotes.Text, "CORRUPT DATA") > 0 Then

                    'change background to indicate an issue
                    txtMNotes.BackColor = Color.IndianRed

                    'change text color for contrast
                    txtMNotes.ForeColor = Color.White

                    'change border so it stands out
                    txtMNotes.BorderStyle = BorderStyle.FixedSingle
                Else

                    'change background to indicate an issue
                    txtMNotes.BackColor = SystemColors.Window

                    'change border so it stands out
                    txtMNotes.BorderStyle = BorderStyle.Fixed3D

                    'change text color for contrast
                    txtMNotes.ForeColor = SystemColors.WindowText

                End If

            End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("..." & vbCrLf & "(TblWorkingDataBindingSource_CurrentItemChanged) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ToolStripBtnSearch_Click(sender As Object, e As EventArgs) Handles ToolStripBtnSearch.Click
        '[NOTES] - open form with search result for user

        Try 'Error Handling


            '[NOTES] - Search for account 
            'open new form and show results
            'Pass the variables back this form

            vSearch = InputBox("Search by Account")

            'vSearch = "%" & vSearch & "%"
            'MessageBox.Show(vSearch.ToString)

            Me.TblWorkingDataTableAdapter.FindSearch(DhA_sampleDataSet1.tblWorkingData, vSearch.ToString)

            ''open another form that allows the user to add the fields and save them to the Datatable
            'Dim frmAddDoorHanger As frmAddTblWD
            'frmAddDoorHanger = New frmAddTblWD()

            ''ShowDialog() will open the new form modally
            'frmAddDoorHanger.ShowDialog(Me)

            ''disposes of frmAddTblWD, which is only hidden after dialogResult is returned
            'frmAddDoorHanger.Dispose()

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to Search." & vbCrLf & "(ToolStripBtnSearch_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub txtMinDue_Validating(sender As Object, e As CancelEventArgs) Handles txtMinDue.Validating
        Try 'Error Handling

            If DhA_sampleDataSet1.tblWorkingData.Rows.Count() <> 0 Then

                'convert decimals to look like Currency

                'declare variable to accept converted Decimal data
                'initialize to a known value
                Dim vDecimal As Decimal = 1.0

                'dim string variable to assist in conversion
                'initialize to current textbox value
                Dim vStringDecimal As String = txtMinDue.Text

                'remove $ from string
                vStringDecimal = vStringDecimal.Replace("$", "")

                'check For non decimal values in textbox
                If Decimal.TryParse(vStringDecimal, vDecimal) = False Then
                    'if value cannot be converted alert user

                    're-enter value that was originally typed into text box
                    txtMinDue.Text = vStringDecimal

                    'change background to indicate an issue
                    txtMinDue.BackColor = Color.IndianRed

                    'Error - My coding caused an issue
                    MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    e.Cancel = True 'cancel validating event, keeps user in the control

                Else

                    'convert text data to look like a decimal (.00) for currency
                    'txtMinDue.Text = vDecimal.ToString("C2")
                    'txtMinDue.Text = vDecimal.ToString("f2")

                    'change background to indicate an issue
                    txtMinDue.BackColor = SystemColors.Window

                End If

            End If

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to add data to database." & vbCrLf & "(txtMinDue_Validating) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub DBConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '[TO DO - Future Feature] - I would like to add this to the Maintenance Drop Down at the top of the application

        'links on this topic
        'http://stackoverflow.com/questions/12333850/change-my-settings-connectionstring-in-runtime

        'http://msdn.microsoft.com/en-us/library/8eyb2ct1.aspx
        'http://msdn.microsoft.com/en-us/library/system.configuration.applicationsettingsbase.aspx

        'http://msdn.microsoft.com/en-us/library/a65txexh(v=vs.100).aspx
        'http://msdn.microsoft.com/en-us/library/saa62613(v=vs.100).aspx

        'I think this is the answer. Now I want to know HOW it works
        'http://thecodemonk.com/2008/02/18/tableadapter-connection-strings/

        '[DEBUG] - need to know how to update at run time

        Try 'Error Handling

            'Local Computer connectionString
            'Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30
            Dim vLocalDB As String = Nothing
            vLocalDB = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30"

            'Network connectionString
            'Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Billmaster\Tre Query Reports\Door Hanger DB\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30
            Dim vNetworkDB As String = Nothing
            vNetworkDB = "Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Billmaster\Tre Query Reports\Door Hanger DB\DHA_sample.mdf;Integrated Security=True;Connect Timeout=30"

            'SQL Server ConnectionString
            Dim vSqlServerDB As String = Nothing
            vSqlServerDB = ""

            'variable for InputBox data
            Dim vInputBoxDB As Object = vLocalDB

            vInputBoxDB = InputBox("Enter a Value = LOCAL, NETWORK, or SQL SERVER.", "DB Connection Preferences")

            Select Case vInputBoxDB
                Case "LOCAL"

                    '
                    'Change DB connection
                    'My.Settings.DHA_sampleConnectionString = vLocalDB

                Case "NETWORK"

                    'Change DB connection
                    'My.Settings.DHA_sampleConnectionString 

                Case "SQL SERVER"

                    'Change DB connection
                    'My.Settings.DHA_sampleConnectionString 

                Case Else

                    'Inform the user nothing was updated
                    MessageBox.Show("Try Again. Answer was not in the proper format!", "DB Selection Misunderstood", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Select

        Catch ex As Exception

            'write to log file
            SaveLogFs(ex)

            'Standard Error 
            MessageBox.Show("Unable to select new DB Connection." & vbCrLf & "(DBConnectionToolStripMenuItem_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
