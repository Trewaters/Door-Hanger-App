'imported to use Filestream
Imports System.IO
'imported to use UTF 8 Encoding
Imports System.Text

Module Module1
    'Global variables

    'Variable to track the current cycle
    'initialize variable to known value "0"
    Public vCycle As Integer = 1

    '[TO DO] - 
    'variable to track current notification setting
    'initialize variable to known value "None"
    Public vNotice As String = "None"

    'variable to capture result of MessageBox
    'initialize variable to known value "None"
    Public vMsgBox As DialogResult = DialogResult.Cancel

    'variable for silent errors.
    'initialize variable to known value "None"
    Public vSilentErr As String = "False"

    'InputBox variable
    'initialize variable to known value "None"
    Public vInputVal As Object = "1"

    'InputBox variable
    'initialize variable to known value "None"
    Public vSearch As Object = "None"

    'variable for dates.
    'initialize variable to known value "None"
    Public vHangDte As Date = #1/1/1900# 'Hang on Date
    Public vCntDte As Date = #1/1/1900# 'Contact office by Date
    Public vTermDte As Date = #1/1/1900# 'Termination on Date

    '[TO DO - Before Release of .exe] Before Build change Initial Directory
    'variable for path string
    Public vImportDirectoryPath As String = "F:\Tre Query Exports\Door Hanger DB\DoorHanger_v2_Export.TXT"

    '[TO DO - Before Release of .exe] Before Build change Initial Directory
    'variable for path string
    Public vTblCodesDirectoryPath As String = "F:\Tre Query Exports\Door Hanger DB\tblCodes.txt"

    'Function for inputting new vCycle
    Public Function CycleInput() As String
        'I have been using this in multiple parts of the application. Time to wrie it once.

        'Input Box
        vInputVal = InputBox("Please select a Billing Cycle 1-4.", "Customer Service Charge Cycle Selection:", 1)

        'Set vCycle for report
        Select Case vInputVal.ToString
            Case "1"
                vCycle = 1

                'return an updated string
                Return "Updated"

            Case "2"
                vCycle = 2

                'return an updated string
                Return "Updated"

            Case "3"
                vCycle = 3

                'return an updated string
                Return "Updated"

            Case "4"
                vCycle = 4

                'return an updated string
                Return "Updated"

            Case ""

                'return a cancel string
                Return "Cancel"

            Case Else

                'Error - My coding caused an issue
                MessageBox.Show("That is not a valid Cycle." & vbCrLf & "Response must be 1, 2, 3, or 4." & vbCrLf & "Please try again!", "Error: Cycle Not in list.", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'return a cancel string
                Return "Cancel"

        End Select

        'return an updated string
        Return "Updated"

    End Function

    Public Sub SaveLogFs(ByVal ex As Exception)
        'accept error exception
        'write to file for later

        'Declare variable for log file path data
        Dim logFPath As String = Nothing

        'declare variable to read lines from filestream
        Dim TextLine As String = Nothing

        'declare string variable to accept all previous error data
        Dim vErrorData As String = Nothing

        'declare the filestream
        Dim logFs As FileStream = Nothing

        'initialize teh log file variable with the default path.
        logFPath = My.Computer.FileSystem.CurrentDirectory & "\log\ErrorLog " & DateTime.Today.Day.ToString & "-" & DateTime.Today.Month.ToString & "-" & DateTime.Today.Year.ToString & "-" & TimeOfDay.Hour.ToString & " " & TimeOfDay.Minute.ToString & ".txt"

        'check file
        If File.Exists(logFPath) Then

            'open file as an append
            logFs = File.Open(logFPath, FileMode.Append)

            ''declares streamreader which inherits textreader for logFPath,
            ''allowing file to be read form the filestream (logFs)
            'Dim objReader As New System.IO.StreamReader(logFs)

            ''check for end of file, read lines into Filestream
            'Do While objReader.Peek() <> -1

            '    'read data line by line
            '    TextLine = objReader.ReadLine()

            '    'hold error data in variable until ready to write to filestream
            '    vErrorData = TextLine & vbCrLf

            'Loop

        Else

            'create file because nothing exist
            logFs = File.Create(logFPath)

        End If



        'create variable to hold error message string
        Dim logErr As String = "NONE"

        'add error message to String
        logErr = "Error Object: " & ex.Source & vbCrLf & _
            "Error Stack Trace: " & ex.StackTrace & vbCrLf & _
            "Error Time: " & System.DateTime.Now().ToString & vbCrLf & _
            "Error Message: " & ex.Message & vbCrLf & _
            "===" & vbCrLf & vErrorData

        'add Tab as Bytes so it can read into the FileStream
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(logErr)

        logFs.Write(info, 0, info.Length)

        'close filestream
        logFs.Close()

    End Sub
End Module
