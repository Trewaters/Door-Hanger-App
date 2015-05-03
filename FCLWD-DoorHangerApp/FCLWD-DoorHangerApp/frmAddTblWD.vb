Public Class frmAddTblWD

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        '[DEBUG] This is not saving to the table as I thought it would

        Try 'Error Handling
            If CycleInput() = "Cancel" Then

                'Exit Sub because the vCycle wasn't successful
                'avoid using exit sub command. Since this is in and ifThen it will end without doing anything.
                'Exit Sub

            Else

                'declare variables that will convert text to appropriate value
                Dim vAccount As String = "None"
                vAccount = Me.txtAccount.Text

                Dim vName As String = "None"
                vName = Me.txtName.Text

                Dim vAddr As String = "None"
                vAddr = Me.txtAddr.Text

                Dim vLoc As String = "None"
                vLoc = Me.txtLoc.Text

                Dim vBal As Decimal = 0

                'testing for successful conversion of data
                Dim vBoolean As Boolean = False

                'decimal data needs to be formatted for conversion
                'remove $ from string
                txtBal.Text = txtBal.Text.Replace("$", "")

                'test conversion
                vBoolean = Decimal.TryParse(txtBal.Text, vBal)

                'ifThen
                If vBoolean = True Then

                    'convert data since TryParse was successful
                    vBal = System.Convert.ToDecimal(txtBal.Text)

                Else

                    'set variable to safe known value
                    vBal = 0

                End If

                Dim vLstPayDte As Date = #1/1/1900#
                vLstPayDte = System.Convert.ToDateTime(txtLstPayDte.Text)

                Dim vLstPayAmt As Decimal = 0

                'decimal data needs to be formatted for conversion
                'remove $ from string
                txtLstPayAmt.Text = txtLstPayAmt.Text.Replace("$", "")

                'test conversion
                vBoolean = Decimal.TryParse(txtLstPayAmt.Text, vLstPayAmt)


                'ifThen
                If vBoolean = True Then

                    'convert data since TryParse was successful
                    vLstPayAmt = System.Convert.ToDecimal(txtLstPayAmt.Text)

                Else

                    'set variable to safe known value
                    vLstPayAmt = 0

                End If

                Dim vStDesc As String = "None"
                vStDesc = Me.txtStDesc.Text

                Dim vPnotes As String = "None"
                vPnotes = Me.txtPnotes.Text

                Dim vAnotes As String = "None"
                vAnotes = Me.txtANotes.Text

                Dim vMNotes As String = "None"
                vMNotes = Me.txtMNotes.Text

                Dim vTerm As Boolean = False
                vTerm = System.Convert.ToBoolean(cbDHPrinted.Checked)

                Dim vHang As Boolean = False
                vHang = System.Convert.ToBoolean(cbTermPrinted.Checked)

                Dim vAgreeDue As Date = #1/1/1900#
                vAgreeDue = System.Convert.ToDateTime(txtAgrPayDueDte.Text)

                Dim vPmtAgreed As Decimal = 0

                'decimal data needs to be formatted for conversion
                'remove $ from string
                txtAgrPayAmt.Text = txtAgrPayAmt.Text.Replace("$", "")

                'test conversion
                vBoolean = Decimal.TryParse(txtAgrPayAmt.Text, vPmtAgreed)

                'ifThen
                If vBoolean = True Then

                    'convert data since TryParse was successful
                    vPmtAgreed = System.Convert.ToDecimal(txtAgrPayAmt.Text)

                Else

                    'set variable to safe known value
                    vPmtAgreed = 0

                End If

                Dim vUnPmt As Decimal = 0

                'decimal data needs to be formatted for conversion
                'remove $ from string
                txtUnPayAmt.Text = txtUnPayAmt.Text.Replace("$", "")

                'test conversion
                vBoolean = Decimal.TryParse(txtUnPayAmt.Text, vUnPmt)

                'ifThen
                If vBoolean = True Then

                    'convert data since TryParse was successful
                    vUnPmt = System.Convert.ToDecimal(txtUnPayAmt.Text)

                Else

                    'set variable to safe known value
                    vUnPmt = 0

                End If

                Dim vPriRte As String = "None"
                vPriRte = Me.txtPriRte.Text

                Dim vSecRte As String = "None"
                vSecRte = Me.txtSecRte.Text

                Dim vStCdeDte As Date = #1/1/1900#
                vStCdeDte = System.Convert.ToDateTime(txtStCdeDte.Text)

                Dim vAgreeMade As Date = #1/1/1900#
                vAgreeMade = System.Convert.ToDateTime(txtAgrMadeDte.Text)

                If vAccount = "" Then

                    'User Warning - 
                    MessageBox.Show("The Account number was empty thus action was cancelled." & vbCrLf & "", "Warning: Cancelled Save!", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                    'set DialogResult for form
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel

                Else

                    Me.TblWorkingDataTableAdapter1.Fill(DhA_sampleDataSet1.tblWorkingData)

                    'check for duplicates
                    Dim vCheckDups As DataRow = DhA_sampleDataSet1.tblWorkingData.Rows(0)

                    'walk through db looking for duplicate account
                    For Each vCheckDups In DhA_sampleDataSet1.tblWorkingData.Rows()

                        'find vAccount in database
                        If vAccount = vCheckDups(0).ToString Then
                            'inform user of duplicate
                            MessageBox.Show("This account is already in the list. The duplicate couldn't be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            'set DialogResult for form
                            Me.DialogResult = Windows.Forms.DialogResult.Cancel

                            'exit sub
                            Exit Sub

                        End If
                    Next

                    Dim vTblWDNewRow As DataRow = DhA_sampleDataSet1.tblWorkingData.NewRow()

                    'Poor way of mapping table rows, comments show mapping
                    'each vTblWDNewRow(#) copies data from tblShutOff
                    vTblWDNewRow(0) = vAccount  'wdAccount 
                    vTblWDNewRow(1) = 0  'wdAge0, default value
                    vTblWDNewRow(2) = 0 'wdAge1, default value
                    vTblWDNewRow(3) = 0 'wdAge2, default value
                    vTblWDNewRow(4) = 0 'wdAge3, default value
                    vTblWDNewRow(5) = 0  'wdAge4, default value
                    vTblWDNewRow(6) = 0  'wdAge5, default value
                    vTblWDNewRow(7) = vBal  'wdBal
                    vTblWDNewRow(8) = vName 'wdName
                    vTblWDNewRow(9) = vAddr 'wdAddr
                    vTblWDNewRow(10) = vLoc 'wdLoc
                    vTblWDNewRow(11) = vCycle 'wdCycle
                    vTblWDNewRow(12) = vLstPayDte  'wdLstPayDte
                    vTblWDNewRow(13) = vLstPayAmt 'wdLstPayAmt
                    vTblWDNewRow(14) = 1 'wdStCde, default value
                    vTblWDNewRow(15) = vStDesc 'wdStDesc
                    vTblWDNewRow(16) = vPnotes 'wdPnotes
                    vTblWDNewRow(17) = vAnotes 'wdANotes
                    vTblWDNewRow(18) = vMNotes 'wdMNotes
                    vTblWDNewRow(19) = vTerm 'vbTrue 'wdTerm, This would be better if I let the user choose OR if I checked the controls current data and copied that 
                    vTblWDNewRow(20) = vHang 'vbTrue 'wdHang, This would be better if I let the user choose OR if I checked the controls current data and copied that  
                    vTblWDNewRow(21) = vHangDte.ToShortDateString  'wdHangDte
                    vTblWDNewRow(22) = vCntDte.ToShortDateString  'wdCntDte
                    vTblWDNewRow(23) = vTermDte.ToShortDateString  'wdTermDte
                    vTblWDNewRow(24) = vAgreeDue  'wdAgreeDue
                    vTblWDNewRow(25) = vPmtAgreed 'wdPmtAgreed
                    vTblWDNewRow(26) = vUnPmt 'wdUnPmt
                    vTblWDNewRow(27) = vPriRte 'wdPriRte
                    vTblWDNewRow(28) = vSecRte 'wdSecRte
                    vTblWDNewRow(29) = vStCdeDte  'wdStCdeDte
                    vTblWDNewRow(30) = vAgreeMade 'wdAgreeMade

                    'add new row with copied data to tblWorkingData
                    DhA_sampleDataSet1.tblWorkingData.Rows.Add(vTblWDNewRow)

                    '===START - Update tblWorkingData so information is saved to db table===
                    'Trying to update database
                    'Found following code here (http://msdn.microsoft.com/en-us/library/0f92s97z.aspx)
                    'Me.Validate()
                    Me.TblWorkingDataBindingSource.EndEdit()
                    Me.TblWorkingDataTableAdapter1.Update(Me.DhA_sampleDataSet1.tblWorkingData)
                    '===END - Update tblWorkingData so information is saved to db table===

                    'set DialogResult for form
                    Me.DialogResult = Windows.Forms.DialogResult.OK

                End If

            End If
        Catch ex As Exception

            'Standard Error 
            MessageBox.Show("Unable to Save new account." & vbCrLf & "(btnSave_Click) Original error: " & ex.Message & vbCrLf & "If issue persist contact Tre'Grisby (trewaters@hotmail.com).", "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub frmAddTblWD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.vAccount = "" Then
            txtAccount.Text = "Required"
            txtName.Text = "Required"
            txtAddr.Text = "Required"

        Else
            'set controls equal to form1 controls

            Me.txtAccount.Text = Form1.vAccount 'txtAccount.Text = FCLWD_DoorHangerApp.Form1.txtAccount.Text
            Me.txtBal.Text = Form1.vBal 'txtBal.Text = FCLWD_DoorHangerApp.Form1.txtBal.Text
            Me.txtName.Text = Form1.vName 'txtName.Text = FCLWD_DoorHangerApp.Form1.txtName.Text
            Me.txtAddr.Text = Form1.vAddr 'txtAddr.Text = FCLWD_DoorHangerApp.Form1.txtAddr.Text
            Me.txtLoc.Text = Form1.vLoc 'txtLoc.Text = FCLWD_DoorHangerApp.Form1.txtLoc.Text
            'vCycle()
            Me.txtLstPayDte.Text = Form1.vLstPayDte 'txtLstPayDte.Text = FCLWD_DoorHangerApp.Form1.txtLstPayDte.Text
            Me.txtLstPayAmt.Text = Form1.vLstPayAmt 'txtLstPayAmt.Text = FCLWD_DoorHangerApp.Form1.txtLstPayAmt.Text
            Me.txtStDesc.Text = Form1.vStDesc 'txtStDesc.Text = FCLWD_DoorHangerApp.Form1.txtStCde.Text
            Me.txtPnotes.Text = Form1.vPnotes 'txtPnotes.Text = FCLWD_DoorHangerApp.Form1.txtPnotes.Text
            Me.txtANotes.Text = Form1.vAnotes 'txtANotes.Text = FCLWD_DoorHangerApp.Form1.txtANotes.Text
            Me.txtMNotes.Text = Form1.vMNotes 'txtMNotes.Text = FCLWD_DoorHangerApp.Form1.txtMNotes.Text
            Me.cbTermPrinted.CheckState = CheckState.Checked 'vTerm(), set to "Checked/True"
            Me.cbDHPrinted.CheckState = CheckState.Checked 'vHang(), set to "Checked/True"
            'vHangDte.ToShortDateString()
            'vCntDte.ToShortDateString()
            'vTermDte.ToShortDateString()
            Me.txtAgrPayDueDte.Text = Form1.vAgrPayDueDte 'txtAgrPayDueDte.Text = FCLWD_DoorHangerApp.Form1.txtAgrPayDueDte.Text 'vAgreeDue.ToShortDateString
            Me.txtAgrPayAmt.Text = Form1.vAgrPayAmt 'txtAgrPayAmt.Text = FCLWD_DoorHangerApp.Form1.txtAgrPayAmt.Text 'vPmtAgreed
            Me.txtUnPayAmt.Text = Form1.vUnPayAmt 'txtUnPayAmt.Text = FCLWD_DoorHangerApp.Form1.txtUnPayAmt.Text 'vUnPmt
            Me.txtPriRte.Text = Form1.vPriRte  'txtPriRte.Text = FCLWD_DoorHangerApp.Form1.txtPriRte.Text
            Me.txtSecRte.Text = Form1.vSecRte 'txtSecRte.Text = FCLWD_DoorHangerApp.Form1.txtSecRte.Text
            Me.txtStCdeDte.Text = Form1.vStCdeDte 'txtStCdeDte.Text = FCLWD_DoorHangerApp.Form1.txtStCdeDte.Text 'vStCdeDte.ToShortDateString
            Me.txtAgrMadeDte.Text = Form1.vAgrMadeDte 'txtAgrMadeDte.Text = FCLWD_DoorHangerApp.Form1.txtAgrMadeDte.Text 'vAgreeMade.ToShortDateString

        End If
        
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'set DialogResult for form
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub
    'code to read text box in another form
    Private vFrmAccountValue As String
    Public Property vFrmAccount() As String
        Get
            Return txtAccount.Text
        End Get
        Set(ByVal value As String)
            vFrmAccountValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmNameValue As String
    Public Property vFrmName() As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal value As String)
            vFrmNameValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmAddrValue As String
    Public Property vFrmAddr() As String
        Get
            Return txtAddr.Text
        End Get
        Set(ByVal value As String)
            vFrmAddrValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmLocValue As String
    Public Property vFrmLoc() As String
        Get
            Return txtLoc.Text
        End Get
        Set(ByVal value As String)
            vFrmLocValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmLstPayDteValue As String
    Public Property vFrmLstPayDte() As String
        Get
            Return txtLstPayDte.Text
        End Get
        Set(ByVal value As String)
            vFrmLstPayDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmLstPayAmtValue As String
    Public Property vFrmLstPayAmt() As String
        Get
            Return txtLstPayAmt.Text
        End Get
        Set(ByVal value As String)
            vFrmLstPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmStDescValue As String
    Public Property vFrmStDesc() As String
        Get
            Return txtStDesc.Text
        End Get
        Set(ByVal value As String)
            vFrmStDescValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmPnotesValue As String
    Public Property vFrmPnotes() As String
        Get
            Return txtPnotes.Text
        End Get
        Set(ByVal value As String)
            vFrmPnotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmAnotesValue As String
    Public Property vFrmAnotes() As String
        Get
            Return txtAnotes.Text
        End Get
        Set(ByVal value As String)
            vFrmAnotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmMNotesValue As String
    Public Property vFrmMNotes() As String
        Get
            Return txtMNotes.Text
        End Get
        Set(ByVal value As String)
            vFrmMNotesValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmBalValue As String
    Public Property vFrmBal() As String
        Get
            Return txtBal.Text
        End Get
        Set(ByVal value As String)
            vFrmBalValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmAgrPayDueDteValue As String
    Public Property vFrmAgrPayDueDte() As String
        Get
            Return txtAgrPayDueDte.Text
        End Get
        Set(ByVal value As String)
            vFrmAgrPayDueDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmAgrPayAmtValue As String
    Public Property vFrmAgrPayAmt() As String
        Get
            Return txtAgrPayAmt.Text
        End Get
        Set(ByVal value As String)
            vFrmAgrPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmUnPayAmtValue As String
    Public Property vFrmUnPayAmt() As String
        Get
            Return txtUnPayAmt.Text
        End Get
        Set(ByVal value As String)
            vFrmUnPayAmtValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmPriRteValue As String
    Public Property vFrmPriRte() As String
        Get
            Return txtPriRte.Text
        End Get
        Set(ByVal value As String)
            vFrmPriRteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmSecRteValue As String
    Public Property vFrmSecRte() As String
        Get
            Return txtSecRte.Text
        End Get
        Set(ByVal value As String)
            vFrmSecRteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmStCdeDteValue As String
    Public Property vFrmStCdeDte() As String
        Get
            Return txtStCdeDte.Text
        End Get
        Set(ByVal value As String)
            vFrmStCdeDteValue = value
        End Set
    End Property

    'code to read text box in another form
    Private vFrmAgrMadeDteValue As String
    Public Property vFrmAgrMadeDte() As String
        Get
            Return txtAgrMadeDte.Text
        End Get
        Set(ByVal value As String)
            vFrmAgrMadeDteValue = value
        End Set
    End Property

    Private Sub txtAccount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAccount.Validating

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
    End Sub

    Private Sub txtName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtName.Validating

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
    End Sub

    Private Sub txtAddr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAddr.Validating

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
    End Sub
    '[TO DO - Future Feature] - All the code below is commented out because it forces data to be entered,
    '[TO DO - Future Feature] - I don't need all these fields to be input for the data to be saved. But I would like this code to load default data instead.

    'Private Sub txtLoc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLoc.Validating
    '    'Check For invalid strings
    '    If txtLoc.Text = "" Or txtLoc.Text Is Nothing Then

    '        'Set to known variable amount
    '        'txt.Text ="None" & Now()
    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtLoc.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'change background to indicate an issue
    '        txtLoc.BackColor = SystemColors.Window

    '    End If
    'End Sub

    'Private Sub txtStDesc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtStDesc.Validating

    '    'Check For invalid strings
    '    If txtStDesc.Text = "" Or txtStDesc.Text Is Nothing Then

    '        'Set to known variable amount
    '        'txt.Text ="None" & Now()
    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtStDesc.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'change background to indicate an issue
    '        txtStDesc.BackColor = SystemColors.Window

    '    End If
    'End Sub

    'Private Sub txtStCdeDte_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtStCdeDte.Validating

    '    'check for invalid dates

    '    'declare variable to accept converted date
    '    Dim vDate As Date = #1/1/1900#

    '    'dim string variable to capture user input
    '    Dim vStringDate As String = txtStCdeDte.Text

    '    If DateTime.TryParse(vStringDate, vDate) = False Then

    '        txtStCdeDte.Text = vStringDate

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtStCdeDte.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vStringDate = Convert.ToDateTime(vDate).ToShortDateString

    '        'end system.DateTime conversion
    '        txtStCdeDte.Text = vStringDate

    '        'change background to indicate an issue
    '        txtStCdeDte.BackColor = SystemColors.Window

    '    End If
    'End Sub

    'Private Sub txtBal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBal.Validating

    '    'convert decimals 
    '    'assign to proper column

    '    'declare variable to accept converted Decimal data
    '    Dim vDecimal As Decimal = 1.0

    '    'dim string variable
    '    Dim vStringDecimal As String = txtBal.Text

    '    'remove $ from string
    '    vStringDecimal = vStringDecimal.Replace("$", "")

    '    'check For non decimal values
    '    If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

    '        txtBal.Text = vStringDecimal

    '        'change background to indicate an issue
    '        txtBal.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vDecimal = System.Convert.ToDecimal(vDecimal)

    '        'end system.Decimal conversion
    '        txtBal.Text = vDecimal.ToString("C2")

    '        'change background to indicate an issue
    '        txtBal.BackColor = SystemColors.Window

    '    End If
    'End Sub

    'Private Sub txtLstPayAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLstPayAmt.Validating

    '    'convert decimals 
    '    'assign to proper column

    '    'declare variable to accept converted Decimal data
    '    Dim vDecimal As Decimal = 1.0

    '    'dim string variable
    '    Dim vStringDecimal As String = txtLstPayAmt.Text

    '    'check For non decimal values
    '    If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

    '        txtLstPayAmt.Text = vStringDecimal

    '        'change background to indicate an issue
    '        txtLstPayAmt.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vDecimal = System.Convert.ToDecimal(vDecimal)

    '        'end system.Decimal conversion
    '        txtLstPayAmt.Text = vDecimal.ToString("C2")

    '        'change background to indicate an issue
    '        txtLstPayAmt.BackColor = SystemColors.Window

    '    End If

    '    'end system.decimal conversion

    'End Sub

    'Private Sub txtLstPayDte_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLstPayDte.Validating

    '    'check for invalid dates

    '    'declare variable to accept converted date
    '    Dim vDate As Date = #1/1/1900#

    '    'dim string variable to capture user input
    '    Dim vStringDate As String = txtLstPayDte.Text

    '    If DateTime.TryParse(vStringDate, vDate) = False Then

    '        txtLstPayDte.Text = vStringDate

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtLstPayDte.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vStringDate = Convert.ToDateTime(vDate).ToShortDateString

    '        'end system.DateTime conversion
    '        txtLstPayDte.Text = vStringDate

    '        'change background to indicate an issue
    '        txtLstPayDte.BackColor = SystemColors.Window

    '    End If

    'End Sub

    'Private Sub txtMNotes_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMNotes.Validating

    '    'Check For invalid strings
    '    If txtMNotes.Text = "" Or txtMNotes.Text Is Nothing Then

    '        'Set to known variable amount
    '        'txt.Text ="None" & Now()
    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtMNotes.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'change background to indicate an issue
    '        txtMNotes.BackColor = SystemColors.Window

    '    End If

    'End Sub

    'Private Sub txtPnotes_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPnotes.Validating

    '    'Check For invalid strings
    '    If txtPnotes.Text = "" Or txtPnotes.Text Is Nothing Then

    '        'Set to known variable amount
    '        'txt.Text ="None" & Now()
    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtPnotes.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'change background to indicate an issue
    '        txtPnotes.BackColor = SystemColors.Window

    '    End If

    'End Sub

    'Private Sub txtANotes_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtANotes.Validating

    '    'Check For invalid strings
    '    If txtANotes.Text = "" Or txtANotes.Text Is Nothing Then

    '        'Set to known variable amount
    '        'txt.Text ="None" & Now()
    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtANotes.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have text.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'change background to indicate an issue
    '        txtANotes.BackColor = SystemColors.Window

    '    End If

    'End Sub

    'Private Sub txtUnPayAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUnPayAmt.Validating

    '    'convert decimals 
    '    'assign to proper column

    '    'declare variable to accept converted Decimal data
    '    Dim vDecimal As Decimal = 1.0

    '    'dim string variable
    '    Dim vStringDecimal As String = txtUnPayAmt.Text

    '    'check For non decimal values
    '    If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

    '        txtUnPayAmt.Text = vStringDecimal

    '        'change background to indicate an issue
    '        txtUnPayAmt.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vDecimal = System.Convert.ToDecimal(vDecimal)

    '        'end system.Decimal conversion
    '        txtUnPayAmt.Text = vDecimal.ToString("C2")

    '        'change background to indicate an issue
    '        txtUnPayAmt.BackColor = SystemColors.Window

    '    End If

    '    'end system.decimal conversion
    'End Sub

    'Private Sub txtAgrMadeDte_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAgrMadeDte.Validating

    '    'check for invalid dates

    '    'declare variable to accept converted date
    '    Dim vDate As Date = #1/1/1900#

    '    'dim string variable to capture user input
    '    Dim vStringDate As String = txtAgrMadeDte.Text

    '    If DateTime.TryParse(vStringDate, vDate) = False Then

    '        txtAgrMadeDte.Text = vStringDate

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtAgrMadeDte.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vStringDate = Convert.ToDateTime(vDate).ToShortDateString

    '        'end system.DateTime conversion
    '        txtAgrMadeDte.Text = vStringDate

    '        'change background to indicate an issue
    '        txtAgrMadeDte.BackColor = SystemColors.Window

    '    End If

    'End Sub

    'Private Sub txtAgrPayAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAgrPayAmt.Validating

    '    'convert decimals 
    '    'assign to proper column

    '    'declare variable to accept converted Decimal data
    '    Dim vDecimal As Decimal = 1.0

    '    'dim string variable
    '    Dim vStringDecimal As String = txtAgrPayAmt.Text

    '    'check For non decimal values
    '    If Decimal.TryParse(vStringDecimal, vDecimal) = False Then

    '        txtAgrPayAmt.Text = vStringDecimal

    '        'change background to indicate an issue
    '        txtAgrPayAmt.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a money value. Decimal is optional." & vbCrLf & "Do not include $, or ""Aa-Zz"" text, or special characters.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vDecimal = System.Convert.ToDecimal(vDecimal)

    '        'end system.Decimal conversion
    '        txtAgrPayAmt.Text = vDecimal.ToString("C2")

    '        'change background to indicate an issue
    '        txtAgrPayAmt.BackColor = SystemColors.Window

    '    End If

    '    'end system.decimal conversion

    'End Sub

    'Private Sub txtAgrPayDueDte_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAgrPayDueDte.Validating

    '    'check for invalid dates

    '    'declare variable to accept converted date
    '    Dim vDate As Date = #1/1/1900#

    '    'dim string variable to capture user input
    '    Dim vStringDate As String = txtAgrPayDueDte.Text

    '    If DateTime.TryParse(vStringDate, vDate) = False Then

    '        txtAgrPayDueDte.Text = vStringDate

    '        e.Cancel = True 'cancel validating event, keeps user in the control

    '        'change background to indicate an issue
    '        txtAgrPayDueDte.BackColor = Color.IndianRed

    '        'Error - My coding caused an issue
    '        MessageBox.Show("Invalid Data Entry!" & vbCrLf & "This control must have a valide date formatted as 1/1/1900.", "Data Error: Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Else

    '        'pass string data and convert it for variable to accept
    '        vStringDate = Convert.ToDateTime(vDate).ToShortDateString

    '        'end system.DateTime conversion
    '        txtAgrPayDueDte.Text = vStringDate

    '        'change background to indicate an issue
    '        txtAgrPayDueDte.BackColor = SystemColors.Window

    '    End If

    'End Sub
End Class