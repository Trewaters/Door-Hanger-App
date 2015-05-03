<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddTblWD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim WdSecRteLabel As System.Windows.Forms.Label
        Dim WdPriRteLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddTblWD))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DhA_sampleDataSet1 = New DoorHangerApp.DHA_sampleDataSet()
        Me.TblWorkingDataTableAdapter1 = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter()
        Me.TblWorkingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtSecRte = New System.Windows.Forms.TextBox()
        Me.txtPriRte = New System.Windows.Forms.TextBox()
        Me.txtANotes = New System.Windows.Forms.RichTextBox()
        Me.txtPnotes = New System.Windows.Forms.RichTextBox()
        Me.txtMNotes = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTermPrinted = New System.Windows.Forms.CheckBox()
        Me.cbDHPrinted = New System.Windows.Forms.CheckBox()
        Me.lblPNote = New System.Windows.Forms.Label()
        Me.lblAgrPayDueDte = New System.Windows.Forms.Label()
        Me.lblAgrPayAmt = New System.Windows.Forms.Label()
        Me.lblAgrMadeDte = New System.Windows.Forms.Label()
        Me.lblUnPayAmt = New System.Windows.Forms.Label()
        Me.lblLstPayDte = New System.Windows.Forms.Label()
        Me.lblLstPayAmt = New System.Windows.Forms.Label()
        Me.lblBal = New System.Windows.Forms.Label()
        Me.lblStCdeDte = New System.Windows.Forms.Label()
        Me.lblStCde = New System.Windows.Forms.Label()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.lblAddr = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.txtAgrPayDueDte = New System.Windows.Forms.TextBox()
        Me.txtAgrPayAmt = New System.Windows.Forms.TextBox()
        Me.txtAgrMadeDte = New System.Windows.Forms.TextBox()
        Me.txtUnPayAmt = New System.Windows.Forms.TextBox()
        Me.txtLstPayDte = New System.Windows.Forms.TextBox()
        Me.txtLstPayAmt = New System.Windows.Forms.TextBox()
        Me.txtBal = New System.Windows.Forms.TextBox()
        Me.txtStCdeDte = New System.Windows.Forms.TextBox()
        Me.txtStDesc = New System.Windows.Forms.TextBox()
        Me.txtLoc = New System.Windows.Forms.TextBox()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        WdSecRteLabel = New System.Windows.Forms.Label()
        WdPriRteLabel = New System.Windows.Forms.Label()
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WdSecRteLabel
        '
        WdSecRteLabel.AutoSize = True
        WdSecRteLabel.Location = New System.Drawing.Point(329, 176)
        WdSecRteLabel.Name = "WdSecRteLabel"
        WdSecRteLabel.Size = New System.Drawing.Size(97, 13)
        WdSecRteLabel.TabIndex = 141
        WdSecRteLabel.Text = "Secondary Service"
        '
        'WdPriRteLabel
        '
        WdPriRteLabel.AutoSize = True
        WdPriRteLabel.Location = New System.Drawing.Point(341, 151)
        WdPriRteLabel.Name = "WdPriRteLabel"
        WdPriRteLabel.Size = New System.Drawing.Size(80, 13)
        WdPriRteLabel.TabIndex = 139
        WdPriRteLabel.Text = "Primary Service"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(717, 388)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 103
        Me.btnSave.Text = "Save Account"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(819, 388)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 104
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DhA_sampleDataSet1
        '
        Me.DhA_sampleDataSet1.DataSetName = "DHA_sampleDataSet"
        Me.DhA_sampleDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblWorkingDataTableAdapter1
        '
        Me.TblWorkingDataTableAdapter1.ClearBeforeFill = True
        '
        'TblWorkingDataBindingSource
        '
        Me.TblWorkingDataBindingSource.DataMember = "tblWorkingData"
        Me.TblWorkingDataBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'txtSecRte
        '
        Me.txtSecRte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdSecRte", True))
        Me.txtSecRte.Location = New System.Drawing.Point(427, 173)
        Me.txtSecRte.Name = "txtSecRte"
        Me.txtSecRte.Size = New System.Drawing.Size(100, 20)
        Me.txtSecRte.TabIndex = 142
        '
        'txtPriRte
        '
        Me.txtPriRte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPriRte", True))
        Me.txtPriRte.Location = New System.Drawing.Point(427, 148)
        Me.txtPriRte.Name = "txtPriRte"
        Me.txtPriRte.Size = New System.Drawing.Size(100, 20)
        Me.txtPriRte.TabIndex = 140
        '
        'txtANotes
        '
        Me.txtANotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdANotes", True))
        Me.txtANotes.Location = New System.Drawing.Point(618, 229)
        Me.txtANotes.Name = "txtANotes"
        Me.txtANotes.Size = New System.Drawing.Size(300, 140)
        Me.txtANotes.TabIndex = 138
        Me.txtANotes.Text = ""
        '
        'txtPnotes
        '
        Me.txtPnotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPnotes", True))
        Me.txtPnotes.Location = New System.Drawing.Point(312, 229)
        Me.txtPnotes.Name = "txtPnotes"
        Me.txtPnotes.Size = New System.Drawing.Size(300, 140)
        Me.txtPnotes.TabIndex = 137
        Me.txtPnotes.Text = ""
        '
        'txtMNotes
        '
        Me.txtMNotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdMNotes", True))
        Me.txtMNotes.Location = New System.Drawing.Point(6, 229)
        Me.txtMNotes.Name = "txtMNotes"
        Me.txtMNotes.Size = New System.Drawing.Size(300, 140)
        Me.txtMNotes.TabIndex = 136
        Me.txtMNotes.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Meter Notes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(618, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Account Notes"
        '
        'cbTermPrinted
        '
        Me.cbTermPrinted.AutoSize = True
        Me.cbTermPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdTerm", True))
        Me.cbTermPrinted.Location = New System.Drawing.Point(141, 14)
        Me.cbTermPrinted.Name = "cbTermPrinted"
        Me.cbTermPrinted.Size = New System.Drawing.Size(117, 17)
        Me.cbTermPrinted.TabIndex = 133
        Me.cbTermPrinted.Text = "Termination Printed"
        Me.cbTermPrinted.UseVisualStyleBackColor = True
        '
        'cbDHPrinted
        '
        Me.cbDHPrinted.AutoSize = True
        Me.cbDHPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdHang", True))
        Me.cbDHPrinted.Location = New System.Drawing.Point(12, 14)
        Me.cbDHPrinted.Name = "cbDHPrinted"
        Me.cbDHPrinted.Size = New System.Drawing.Size(123, 17)
        Me.cbDHPrinted.TabIndex = 132
        Me.cbDHPrinted.Text = "Door Hanger Printed"
        Me.cbDHPrinted.UseVisualStyleBackColor = True
        '
        'lblPNote
        '
        Me.lblPNote.AutoSize = True
        Me.lblPNote.Location = New System.Drawing.Point(314, 213)
        Me.lblPNote.Name = "lblPNote"
        Me.lblPNote.Size = New System.Drawing.Size(75, 13)
        Me.lblPNote.TabIndex = 131
        Me.lblPNote.Text = "Premise Notes"
        '
        'lblAgrPayDueDte
        '
        Me.lblAgrPayDueDte.AutoSize = True
        Me.lblAgrPayDueDte.Location = New System.Drawing.Point(624, 142)
        Me.lblAgrPayDueDte.Name = "lblAgrPayDueDte"
        Me.lblAgrPayDueDte.Size = New System.Drawing.Size(64, 13)
        Me.lblAgrPayDueDte.TabIndex = 130
        Me.lblAgrPayDueDte.Text = "Agreed Due"
        '
        'lblAgrPayAmt
        '
        Me.lblAgrPayAmt.AutoSize = True
        Me.lblAgrPayAmt.Location = New System.Drawing.Point(608, 117)
        Me.lblAgrPayAmt.Name = "lblAgrPayAmt"
        Me.lblAgrPayAmt.Size = New System.Drawing.Size(80, 13)
        Me.lblAgrPayAmt.TabIndex = 129
        Me.lblAgrPayAmt.Text = "Agreed Amount"
        '
        'lblAgrMadeDte
        '
        Me.lblAgrMadeDte.AutoSize = True
        Me.lblAgrMadeDte.Location = New System.Drawing.Point(572, 92)
        Me.lblAgrMadeDte.Name = "lblAgrMadeDte"
        Me.lblAgrMadeDte.Size = New System.Drawing.Size(116, 13)
        Me.lblAgrMadeDte.TabIndex = 128
        Me.lblAgrMadeDte.Text = "Arrangements made on"
        '
        'lblUnPayAmt
        '
        Me.lblUnPayAmt.AutoSize = True
        Me.lblUnPayAmt.Location = New System.Drawing.Point(591, 44)
        Me.lblUnPayAmt.Name = "lblUnPayAmt"
        Me.lblUnPayAmt.Size = New System.Drawing.Size(97, 13)
        Me.lblUnPayAmt.TabIndex = 127
        Me.lblUnPayAmt.Text = "Unposted Payment"
        '
        'lblLstPayDte
        '
        Me.lblLstPayDte.AutoSize = True
        Me.lblLstPayDte.Location = New System.Drawing.Point(359, 93)
        Me.lblLstPayDte.Name = "lblLstPayDte"
        Me.lblLstPayDte.Size = New System.Drawing.Size(97, 13)
        Me.lblLstPayDte.TabIndex = 126
        Me.lblLstPayDte.Text = "Last Payment Date"
        '
        'lblLstPayAmt
        '
        Me.lblLstPayAmt.AutoSize = True
        Me.lblLstPayAmt.Location = New System.Drawing.Point(366, 69)
        Me.lblLstPayAmt.Name = "lblLstPayAmt"
        Me.lblLstPayAmt.Size = New System.Drawing.Size(90, 13)
        Me.lblLstPayAmt.TabIndex = 125
        Me.lblLstPayAmt.Text = "Last Amount Paid"
        '
        'lblBal
        '
        Me.lblBal.AutoSize = True
        Me.lblBal.Location = New System.Drawing.Point(373, 44)
        Me.lblBal.Name = "lblBal"
        Me.lblBal.Size = New System.Drawing.Size(83, 13)
        Me.lblBal.TabIndex = 124
        Me.lblBal.Text = "Current Balance"
        '
        'lblStCdeDte
        '
        Me.lblStCdeDte.AutoSize = True
        Me.lblStCdeDte.Location = New System.Drawing.Point(19, 176)
        Me.lblStCdeDte.Name = "lblStCdeDte"
        Me.lblStCdeDte.Size = New System.Drawing.Size(63, 13)
        Me.lblStCdeDte.TabIndex = 123
        Me.lblStCdeDte.Text = "Status Date"
        '
        'lblStCde
        '
        Me.lblStCde.AutoSize = True
        Me.lblStCde.Location = New System.Drawing.Point(15, 151)
        Me.lblStCde.Name = "lblStCde"
        Me.lblStCde.Size = New System.Drawing.Size(67, 13)
        Me.lblStCde.TabIndex = 122
        Me.lblStCde.Text = "Meter Status"
        '
        'lblLoc
        '
        Me.lblLoc.AutoSize = True
        Me.lblLoc.Location = New System.Drawing.Point(4, 126)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(78, 13)
        Me.lblLoc.TabIndex = 121
        Me.lblLoc.Text = "Meter Location"
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(6, 96)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(76, 13)
        Me.lblAddr.TabIndex = 120
        Me.lblAddr.Text = "Street Address"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(0, 69)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(82, 13)
        Me.lblName.TabIndex = 119
        Me.lblName.Text = "Customer Name"
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(25, 44)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(57, 13)
        Me.lblAccount.TabIndex = 118
        Me.lblAccount.Text = "Account #"
        '
        'txtAgrPayDueDte
        '
        Me.txtAgrPayDueDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeDue", True))
        Me.txtAgrPayDueDte.Location = New System.Drawing.Point(694, 139)
        Me.txtAgrPayDueDte.Name = "txtAgrPayDueDte"
        Me.txtAgrPayDueDte.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrPayDueDte.TabIndex = 117
        Me.txtAgrPayDueDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAgrPayAmt
        '
        Me.txtAgrPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPmtAgreed", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtAgrPayAmt.Location = New System.Drawing.Point(694, 114)
        Me.txtAgrPayAmt.Name = "txtAgrPayAmt"
        Me.txtAgrPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrPayAmt.TabIndex = 116
        Me.txtAgrPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAgrMadeDte
        '
        Me.txtAgrMadeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeMade", True))
        Me.txtAgrMadeDte.Location = New System.Drawing.Point(694, 89)
        Me.txtAgrMadeDte.Name = "txtAgrMadeDte"
        Me.txtAgrMadeDte.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrMadeDte.TabIndex = 115
        Me.txtAgrMadeDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnPayAmt
        '
        Me.txtUnPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdUnPmt", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtUnPayAmt.Location = New System.Drawing.Point(694, 41)
        Me.txtUnPayAmt.Name = "txtUnPayAmt"
        Me.txtUnPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtUnPayAmt.TabIndex = 114
        Me.txtUnPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLstPayDte
        '
        Me.txtLstPayDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayDte", True))
        Me.txtLstPayDte.Location = New System.Drawing.Point(462, 90)
        Me.txtLstPayDte.Name = "txtLstPayDte"
        Me.txtLstPayDte.Size = New System.Drawing.Size(65, 20)
        Me.txtLstPayDte.TabIndex = 113
        Me.txtLstPayDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLstPayAmt
        '
        Me.txtLstPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayAmt", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtLstPayAmt.Location = New System.Drawing.Point(462, 65)
        Me.txtLstPayAmt.Name = "txtLstPayAmt"
        Me.txtLstPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtLstPayAmt.TabIndex = 112
        Me.txtLstPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBal
        '
        Me.txtBal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdBal", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtBal.Location = New System.Drawing.Point(462, 40)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.Size = New System.Drawing.Size(65, 20)
        Me.txtBal.TabIndex = 111
        Me.txtBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStCdeDte
        '
        Me.txtStCdeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStCdeDte", True))
        Me.txtStCdeDte.Location = New System.Drawing.Point(88, 173)
        Me.txtStCdeDte.Name = "txtStCdeDte"
        Me.txtStCdeDte.Size = New System.Drawing.Size(65, 20)
        Me.txtStCdeDte.TabIndex = 110
        Me.txtStCdeDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStDesc
        '
        Me.txtStDesc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStDesc", True))
        Me.txtStDesc.Location = New System.Drawing.Point(88, 148)
        Me.txtStDesc.Name = "txtStDesc"
        Me.txtStDesc.Size = New System.Drawing.Size(140, 20)
        Me.txtStDesc.TabIndex = 109
        '
        'txtLoc
        '
        Me.txtLoc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLoc", True))
        Me.txtLoc.Location = New System.Drawing.Point(88, 123)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(250, 20)
        Me.txtLoc.TabIndex = 108
        '
        'txtAddr
        '
        Me.txtAddr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAddr", True))
        Me.txtAddr.Location = New System.Drawing.Point(88, 93)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(140, 20)
        Me.txtAddr.TabIndex = 107
        Me.txtAddr.Text = "Required"
        '
        'txtName
        '
        Me.txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdName", True))
        Me.txtName.Location = New System.Drawing.Point(88, 66)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(140, 20)
        Me.txtName.TabIndex = 106
        Me.txtName.Text = "Required"
        '
        'txtAccount
        '
        Me.txtAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAccount", True))
        Me.txtAccount.Location = New System.Drawing.Point(88, 41)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(70, 20)
        Me.txtAccount.TabIndex = 105
        Me.txtAccount.Text = "Required"
        '
        'frmAddTblWD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 424)
        Me.Controls.Add(WdSecRteLabel)
        Me.Controls.Add(Me.txtSecRte)
        Me.Controls.Add(WdPriRteLabel)
        Me.Controls.Add(Me.txtPriRte)
        Me.Controls.Add(Me.txtANotes)
        Me.Controls.Add(Me.txtPnotes)
        Me.Controls.Add(Me.txtMNotes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbTermPrinted)
        Me.Controls.Add(Me.cbDHPrinted)
        Me.Controls.Add(Me.lblPNote)
        Me.Controls.Add(Me.lblAgrPayDueDte)
        Me.Controls.Add(Me.lblAgrPayAmt)
        Me.Controls.Add(Me.lblAgrMadeDte)
        Me.Controls.Add(Me.lblUnPayAmt)
        Me.Controls.Add(Me.lblLstPayDte)
        Me.Controls.Add(Me.lblLstPayAmt)
        Me.Controls.Add(Me.lblBal)
        Me.Controls.Add(Me.lblStCdeDte)
        Me.Controls.Add(Me.lblStCde)
        Me.Controls.Add(Me.lblLoc)
        Me.Controls.Add(Me.lblAddr)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblAccount)
        Me.Controls.Add(Me.txtAgrPayDueDte)
        Me.Controls.Add(Me.txtAgrPayAmt)
        Me.Controls.Add(Me.txtAgrMadeDte)
        Me.Controls.Add(Me.txtUnPayAmt)
        Me.Controls.Add(Me.txtLstPayDte)
        Me.Controls.Add(Me.txtLstPayAmt)
        Me.Controls.Add(Me.txtBal)
        Me.Controls.Add(Me.txtStCdeDte)
        Me.Controls.Add(Me.txtStDesc)
        Me.Controls.Add(Me.txtLoc)
        Me.Controls.Add(Me.txtAddr)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddTblWD"
        Me.Text = "Add New Account"
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents DhA_sampleDataSet1 As DoorHangerApp.DHA_sampleDataSet
    Friend WithEvents TblWorkingDataTableAdapter1 As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter
    Friend WithEvents TblWorkingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtSecRte As System.Windows.Forms.TextBox
    Friend WithEvents txtPriRte As System.Windows.Forms.TextBox
    Friend WithEvents txtANotes As System.Windows.Forms.RichTextBox
    Friend WithEvents txtPnotes As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTermPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents cbDHPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents lblPNote As System.Windows.Forms.Label
    Friend WithEvents lblAgrPayDueDte As System.Windows.Forms.Label
    Friend WithEvents lblAgrPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblAgrMadeDte As System.Windows.Forms.Label
    Friend WithEvents lblUnPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblLstPayDte As System.Windows.Forms.Label
    Friend WithEvents lblLstPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblBal As System.Windows.Forms.Label
    Friend WithEvents lblStCdeDte As System.Windows.Forms.Label
    Friend WithEvents lblStCde As System.Windows.Forms.Label
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents lblAddr As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAgrPayDueDte As System.Windows.Forms.TextBox
    Friend WithEvents txtAgrPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtAgrMadeDte As System.Windows.Forms.TextBox
    Friend WithEvents txtUnPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtLstPayDte As System.Windows.Forms.TextBox
    Friend WithEvents txtLstPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtBal As System.Windows.Forms.TextBox
    Friend WithEvents txtStCdeDte As System.Windows.Forms.TextBox
    Friend WithEvents txtStDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
End Class
