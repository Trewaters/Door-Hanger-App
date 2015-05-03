<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim WdPriRteLabel As System.Windows.Forms.Label
        Dim WdSecRteLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.TblWorkingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DhA_sampleDataSet1 = New DoorHangerApp.DHA_sampleDataSet()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.txtLoc = New System.Windows.Forms.TextBox()
        Me.txtStCde = New System.Windows.Forms.TextBox()
        Me.txtStCdeDte = New System.Windows.Forms.TextBox()
        Me.txtBal = New System.Windows.Forms.TextBox()
        Me.txtLstPayAmt = New System.Windows.Forms.TextBox()
        Me.txtLstPayDte = New System.Windows.Forms.TextBox()
        Me.txtUnPayAmt = New System.Windows.Forms.TextBox()
        Me.txtAgrMadeDte = New System.Windows.Forms.TextBox()
        Me.txtAgrPayAmt = New System.Windows.Forms.TextBox()
        Me.txtAgrPayDueDte = New System.Windows.Forms.TextBox()
        Me.grpCycle = New System.Windows.Forms.GroupBox()
        Me.rdoBtnCycle4 = New System.Windows.Forms.RadioButton()
        Me.rdoBtnCycle3 = New System.Windows.Forms.RadioButton()
        Me.rdoBtnCycle2 = New System.Windows.Forms.RadioButton()
        Me.rdoBtnCycle1 = New System.Windows.Forms.RadioButton()
        Me.grpNotice = New System.Windows.Forms.GroupBox()
        Me.RdoBtnAll = New System.Windows.Forms.RadioButton()
        Me.rdoBtnTerm = New System.Windows.Forms.RadioButton()
        Me.rdoBtnDH = New System.Windows.Forms.RadioButton()
        Me.lblHangDte = New System.Windows.Forms.Label()
        Me.lblTermDte = New System.Windows.Forms.Label()
        Me.lblCntDte = New System.Windows.Forms.Label()
        Me.lbfrmDteLog = New System.Windows.Forms.Label()
        Me.lbldlNew = New System.Windows.Forms.Label()
        Me.lbldlUpdate = New System.Windows.Forms.Label()
        Me.lbldlDH = New System.Windows.Forms.Label()
        Me.lbldlTerm = New System.Windows.Forms.Label()
        Me.lbldlCSweep = New System.Windows.Forms.Label()
        Me.txtdlNew = New System.Windows.Forms.TextBox()
        Me.TblDateLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtdlUpdate = New System.Windows.Forms.TextBox()
        Me.txtdlDH = New System.Windows.Forms.TextBox()
        Me.txtdlTerm = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CleanSweepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoorHangerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerServiceChargesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSCReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminationShutOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReviewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle1ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle2ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle3ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cycle4ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportedDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblAddr = New System.Windows.Forms.Label()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.lblStCde = New System.Windows.Forms.Label()
        Me.lblStCdeDte = New System.Windows.Forms.Label()
        Me.lblBal = New System.Windows.Forms.Label()
        Me.lblLstPayAmt = New System.Windows.Forms.Label()
        Me.lblLstPayDte = New System.Windows.Forms.Label()
        Me.lblUnPayAmt = New System.Windows.Forms.Label()
        Me.lblAgrMadeDte = New System.Windows.Forms.Label()
        Me.lblAgrPayAmt = New System.Windows.Forms.Label()
        Me.lblAgrPayDueDte = New System.Windows.Forms.Label()
        Me.lblPNote = New System.Windows.Forms.Label()
        Me.cbDHPrinted = New System.Windows.Forms.CheckBox()
        Me.cbTermPrinted = New System.Windows.Forms.CheckBox()
        Me.dtpHangDte = New System.Windows.Forms.DateTimePicker()
        Me.dtpCntDte = New System.Windows.Forms.DateTimePicker()
        Me.dtpTermDte = New System.Windows.Forms.DateTimePicker()
        Me.lblUserNotification = New System.Windows.Forms.Label()
        Me.TblWorkingDataBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripBtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorAddItem = New System.Windows.Forms.ToolStripButton()
        Me.txtdlCSweep = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMNotes = New System.Windows.Forms.RichTextBox()
        Me.txtPnotes = New System.Windows.Forms.RichTextBox()
        Me.txtANotes = New System.Windows.Forms.RichTextBox()
        Me.txtPriRte = New System.Windows.Forms.TextBox()
        Me.txtSecRte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMinDue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TblShutOffBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblExcelExportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblShutOffTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblShutOffTableAdapter()
        Me.TableAdapterManager = New DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager()
        Me.TblWorkingDataTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter()
        Me.TblCodesTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter()
        Me.TblDateLogTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblDateLogTableAdapter()
        Me.TblExcelExportTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblExcelExportTableAdapter()
        WdPriRteLabel = New System.Windows.Forms.Label()
        WdSecRteLabel = New System.Windows.Forms.Label()
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCycle.SuspendLayout()
        Me.grpNotice.SuspendLayout()
        CType(Me.TblDateLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TblWorkingDataBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblWorkingDataBindingNavigator.SuspendLayout()
        CType(Me.TblShutOffBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblExcelExportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WdPriRteLabel
        '
        WdPriRteLabel.AutoSize = True
        WdPriRteLabel.Location = New System.Drawing.Point(358, 300)
        WdPriRteLabel.Name = "WdPriRteLabel"
        WdPriRteLabel.Size = New System.Drawing.Size(80, 13)
        WdPriRteLabel.TabIndex = 66
        WdPriRteLabel.Text = "Primary Service"
        '
        'WdSecRteLabel
        '
        WdSecRteLabel.AutoSize = True
        WdSecRteLabel.Location = New System.Drawing.Point(346, 325)
        WdSecRteLabel.Name = "WdSecRteLabel"
        WdSecRteLabel.Size = New System.Drawing.Size(97, 13)
        WdSecRteLabel.TabIndex = 67
        WdSecRteLabel.Text = "Secondary Service"
        '
        'txtAccount
        '
        Me.txtAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAccount", True))
        Me.txtAccount.Location = New System.Drawing.Point(88, 191)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(70, 20)
        Me.txtAccount.TabIndex = 0
        '
        'TblWorkingDataBindingSource
        '
        Me.TblWorkingDataBindingSource.DataMember = "tblWorkingData"
        Me.TblWorkingDataBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'DhA_sampleDataSet1
        '
        Me.DhA_sampleDataSet1.DataSetName = "DHA_sampleDataSet"
        Me.DhA_sampleDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtName
        '
        Me.txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdName", True))
        Me.txtName.Location = New System.Drawing.Point(88, 216)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(140, 20)
        Me.txtName.TabIndex = 1
        '
        'txtAddr
        '
        Me.txtAddr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAddr", True))
        Me.txtAddr.Location = New System.Drawing.Point(88, 243)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(140, 20)
        Me.txtAddr.TabIndex = 2
        '
        'txtLoc
        '
        Me.txtLoc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLoc", True))
        Me.txtLoc.Location = New System.Drawing.Point(88, 273)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(250, 20)
        Me.txtLoc.TabIndex = 3
        '
        'txtStCde
        '
        Me.txtStCde.BackColor = System.Drawing.SystemColors.Window
        Me.txtStCde.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStDesc", True))
        Me.txtStCde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStCde.Location = New System.Drawing.Point(88, 298)
        Me.txtStCde.Name = "txtStCde"
        Me.txtStCde.Size = New System.Drawing.Size(140, 20)
        Me.txtStCde.TabIndex = 4
        '
        'txtStCdeDte
        '
        Me.txtStCdeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStCdeDte", True))
        Me.txtStCdeDte.Location = New System.Drawing.Point(88, 323)
        Me.txtStCdeDte.Name = "txtStCdeDte"
        Me.txtStCdeDte.Size = New System.Drawing.Size(65, 20)
        Me.txtStCdeDte.TabIndex = 5
        Me.txtStCdeDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBal
        '
        Me.txtBal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdBal", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtBal.Location = New System.Drawing.Point(690, 219)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.Size = New System.Drawing.Size(65, 20)
        Me.txtBal.TabIndex = 6
        Me.txtBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLstPayAmt
        '
        Me.txtLstPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayAmt", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtLstPayAmt.Location = New System.Drawing.Point(444, 191)
        Me.txtLstPayAmt.Name = "txtLstPayAmt"
        Me.txtLstPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtLstPayAmt.TabIndex = 7
        Me.txtLstPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLstPayDte
        '
        Me.txtLstPayDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayDte", True))
        Me.txtLstPayDte.Location = New System.Drawing.Point(444, 216)
        Me.txtLstPayDte.Name = "txtLstPayDte"
        Me.txtLstPayDte.Size = New System.Drawing.Size(65, 20)
        Me.txtLstPayDte.TabIndex = 8
        Me.txtLstPayDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnPayAmt
        '
        Me.txtUnPayAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdUnPmt", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtUnPayAmt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUnPayAmt.Location = New System.Drawing.Point(690, 191)
        Me.txtUnPayAmt.Name = "txtUnPayAmt"
        Me.txtUnPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtUnPayAmt.TabIndex = 9
        Me.txtUnPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAgrMadeDte
        '
        Me.txtAgrMadeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeMade", True))
        Me.txtAgrMadeDte.Location = New System.Drawing.Point(690, 272)
        Me.txtAgrMadeDte.Name = "txtAgrMadeDte"
        Me.txtAgrMadeDte.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrMadeDte.TabIndex = 10
        Me.txtAgrMadeDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAgrPayAmt
        '
        Me.txtAgrPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPmtAgreed", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtAgrPayAmt.Location = New System.Drawing.Point(690, 297)
        Me.txtAgrPayAmt.Name = "txtAgrPayAmt"
        Me.txtAgrPayAmt.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrPayAmt.TabIndex = 11
        Me.txtAgrPayAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAgrPayDueDte
        '
        Me.txtAgrPayDueDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeDue", True))
        Me.txtAgrPayDueDte.Location = New System.Drawing.Point(690, 322)
        Me.txtAgrPayDueDte.Name = "txtAgrPayDueDte"
        Me.txtAgrPayDueDte.Size = New System.Drawing.Size(65, 20)
        Me.txtAgrPayDueDte.TabIndex = 12
        Me.txtAgrPayDueDte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpCycle
        '
        Me.grpCycle.BackColor = System.Drawing.SystemColors.Control
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle4)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle3)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle2)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle1)
        Me.grpCycle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCycle.Location = New System.Drawing.Point(12, 27)
        Me.grpCycle.Name = "grpCycle"
        Me.grpCycle.Size = New System.Drawing.Size(267, 44)
        Me.grpCycle.TabIndex = 13
        Me.grpCycle.TabStop = False
        Me.grpCycle.Text = "Select Cycle:"
        '
        'rdoBtnCycle4
        '
        Me.rdoBtnCycle4.AutoSize = True
        Me.rdoBtnCycle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnCycle4.Location = New System.Drawing.Point(201, 16)
        Me.rdoBtnCycle4.Name = "rdoBtnCycle4"
        Me.rdoBtnCycle4.Size = New System.Drawing.Size(60, 17)
        Me.rdoBtnCycle4.TabIndex = 3
        Me.rdoBtnCycle4.Text = "Cycle 4"
        Me.rdoBtnCycle4.UseVisualStyleBackColor = True
        '
        'rdoBtnCycle3
        '
        Me.rdoBtnCycle3.AutoSize = True
        Me.rdoBtnCycle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnCycle3.Location = New System.Drawing.Point(135, 16)
        Me.rdoBtnCycle3.Name = "rdoBtnCycle3"
        Me.rdoBtnCycle3.Size = New System.Drawing.Size(60, 17)
        Me.rdoBtnCycle3.TabIndex = 2
        Me.rdoBtnCycle3.Text = "Cycle 3"
        Me.rdoBtnCycle3.UseVisualStyleBackColor = True
        '
        'rdoBtnCycle2
        '
        Me.rdoBtnCycle2.AutoSize = True
        Me.rdoBtnCycle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnCycle2.Location = New System.Drawing.Point(69, 16)
        Me.rdoBtnCycle2.Name = "rdoBtnCycle2"
        Me.rdoBtnCycle2.Size = New System.Drawing.Size(60, 17)
        Me.rdoBtnCycle2.TabIndex = 1
        Me.rdoBtnCycle2.Text = "Cycle 2"
        Me.rdoBtnCycle2.UseVisualStyleBackColor = True
        '
        'rdoBtnCycle1
        '
        Me.rdoBtnCycle1.AutoSize = True
        Me.rdoBtnCycle1.Checked = True
        Me.rdoBtnCycle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnCycle1.Location = New System.Drawing.Point(3, 16)
        Me.rdoBtnCycle1.Name = "rdoBtnCycle1"
        Me.rdoBtnCycle1.Size = New System.Drawing.Size(60, 17)
        Me.rdoBtnCycle1.TabIndex = 0
        Me.rdoBtnCycle1.TabStop = True
        Me.rdoBtnCycle1.Text = "Cycle 1"
        Me.rdoBtnCycle1.UseVisualStyleBackColor = True
        '
        'grpNotice
        '
        Me.grpNotice.Controls.Add(Me.RdoBtnAll)
        Me.grpNotice.Controls.Add(Me.rdoBtnTerm)
        Me.grpNotice.Controls.Add(Me.rdoBtnDH)
        Me.grpNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNotice.Location = New System.Drawing.Point(12, 77)
        Me.grpNotice.Name = "grpNotice"
        Me.grpNotice.Size = New System.Drawing.Size(310, 46)
        Me.grpNotice.TabIndex = 14
        Me.grpNotice.TabStop = False
        Me.grpNotice.Text = "Select Notification:"
        '
        'RdoBtnAll
        '
        Me.RdoBtnAll.AutoSize = True
        Me.RdoBtnAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoBtnAll.Location = New System.Drawing.Point(224, 16)
        Me.RdoBtnAll.Name = "RdoBtnAll"
        Me.RdoBtnAll.Size = New System.Drawing.Size(84, 17)
        Me.RdoBtnAll.TabIndex = 2
        Me.RdoBtnAll.TabStop = True
        Me.RdoBtnAll.Text = "All Accounts"
        Me.RdoBtnAll.UseVisualStyleBackColor = True
        '
        'rdoBtnTerm
        '
        Me.rdoBtnTerm.AutoSize = True
        Me.rdoBtnTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnTerm.ForeColor = System.Drawing.Color.Red
        Me.rdoBtnTerm.Location = New System.Drawing.Point(100, 16)
        Me.rdoBtnTerm.Name = "rdoBtnTerm"
        Me.rdoBtnTerm.Size = New System.Drawing.Size(124, 17)
        Me.rdoBtnTerm.TabIndex = 1
        Me.rdoBtnTerm.Text = "Termination/Shut Off"
        Me.rdoBtnTerm.UseVisualStyleBackColor = True
        '
        'rdoBtnDH
        '
        Me.rdoBtnDH.AutoSize = True
        Me.rdoBtnDH.BackColor = System.Drawing.Color.Transparent
        Me.rdoBtnDH.Checked = True
        Me.rdoBtnDH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBtnDH.ForeColor = System.Drawing.Color.DarkBlue
        Me.rdoBtnDH.Location = New System.Drawing.Point(3, 16)
        Me.rdoBtnDH.Name = "rdoBtnDH"
        Me.rdoBtnDH.Size = New System.Drawing.Size(91, 17)
        Me.rdoBtnDH.TabIndex = 0
        Me.rdoBtnDH.TabStop = True
        Me.rdoBtnDH.Text = "Door Hangers"
        Me.rdoBtnDH.UseVisualStyleBackColor = False
        '
        'lblHangDte
        '
        Me.lblHangDte.AutoSize = True
        Me.lblHangDte.Location = New System.Drawing.Point(376, 45)
        Me.lblHangDte.Name = "lblHangDte"
        Me.lblHangDte.Size = New System.Drawing.Size(76, 13)
        Me.lblHangDte.TabIndex = 15
        Me.lblHangDte.Text = "Hang On Date"
        '
        'lblTermDte
        '
        Me.lblTermDte.AutoSize = True
        Me.lblTermDte.Location = New System.Drawing.Point(364, 95)
        Me.lblTermDte.Name = "lblTermDte"
        Me.lblTermDte.Size = New System.Drawing.Size(88, 13)
        Me.lblTermDte.TabIndex = 19
        Me.lblTermDte.Text = "Termination Date"
        '
        'lblCntDte
        '
        Me.lblCntDte.AutoSize = True
        Me.lblCntDte.Location = New System.Drawing.Point(363, 69)
        Me.lblCntDte.Name = "lblCntDte"
        Me.lblCntDte.Size = New System.Drawing.Size(89, 13)
        Me.lblCntDte.TabIndex = 20
        Me.lblCntDte.Text = "Contact Office by"
        '
        'lbfrmDteLog
        '
        Me.lbfrmDteLog.BackColor = System.Drawing.Color.Black
        Me.lbfrmDteLog.ForeColor = System.Drawing.Color.White
        Me.lbfrmDteLog.Location = New System.Drawing.Point(746, 27)
        Me.lbfrmDteLog.Margin = New System.Windows.Forms.Padding(3)
        Me.lbfrmDteLog.Name = "lbfrmDteLog"
        Me.lbfrmDteLog.Size = New System.Drawing.Size(175, 14)
        Me.lbfrmDteLog.TabIndex = 21
        Me.lbfrmDteLog.Text = "Date Logs for Cycle # "
        Me.lbfrmDteLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbldlNew
        '
        Me.lbldlNew.AutoSize = True
        Me.lbldlNew.Location = New System.Drawing.Point(767, 51)
        Me.lbldlNew.Name = "lbldlNew"
        Me.lbldlNew.Size = New System.Drawing.Size(83, 13)
        Me.lbldlNew.TabIndex = 22
        Me.lbldlNew.Text = "Billmaster Import"
        '
        'lbldlUpdate
        '
        Me.lbldlUpdate.AutoSize = True
        Me.lbldlUpdate.Location = New System.Drawing.Point(750, 75)
        Me.lbldlUpdate.Name = "lbldlUpdate"
        Me.lbldlUpdate.Size = New System.Drawing.Size(100, 13)
        Me.lbldlUpdate.TabIndex = 23
        Me.lbldlUpdate.Text = "Billmaster Payments"
        '
        'lbldlDH
        '
        Me.lbldlDH.AutoSize = True
        Me.lbldlDH.Location = New System.Drawing.Point(742, 101)
        Me.lbldlDH.Name = "lbldlDH"
        Me.lbldlDH.Size = New System.Drawing.Size(108, 13)
        Me.lbldlDH.TabIndex = 24
        Me.lbldlDH.Text = "Door Hangers printed"
        '
        'lbldlTerm
        '
        Me.lbldlTerm.AutoSize = True
        Me.lbldlTerm.Location = New System.Drawing.Point(748, 125)
        Me.lbldlTerm.Name = "lbldlTerm"
        Me.lbldlTerm.Size = New System.Drawing.Size(102, 13)
        Me.lbldlTerm.TabIndex = 25
        Me.lbldlTerm.Text = "Terminations printed"
        '
        'lbldlCSweep
        '
        Me.lbldlCSweep.AutoSize = True
        Me.lbldlCSweep.Location = New System.Drawing.Point(780, 151)
        Me.lbldlCSweep.Name = "lbldlCSweep"
        Me.lbldlCSweep.Size = New System.Drawing.Size(70, 13)
        Me.lbldlCSweep.TabIndex = 26
        Me.lbldlCSweep.Text = "Clean Sweep"
        '
        'txtdlNew
        '
        Me.txtdlNew.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlNew", True))
        Me.txtdlNew.Location = New System.Drawing.Point(856, 47)
        Me.txtdlNew.Name = "txtdlNew"
        Me.txtdlNew.Size = New System.Drawing.Size(65, 20)
        Me.txtdlNew.TabIndex = 27
        Me.txtdlNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TblDateLogBindingSource
        '
        Me.TblDateLogBindingSource.DataMember = "tblDateLog"
        Me.TblDateLogBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'txtdlUpdate
        '
        Me.txtdlUpdate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlUpdate", True))
        Me.txtdlUpdate.Location = New System.Drawing.Point(856, 72)
        Me.txtdlUpdate.Name = "txtdlUpdate"
        Me.txtdlUpdate.Size = New System.Drawing.Size(65, 20)
        Me.txtdlUpdate.TabIndex = 28
        Me.txtdlUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdlDH
        '
        Me.txtdlDH.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlDH", True))
        Me.txtdlDH.Location = New System.Drawing.Point(856, 97)
        Me.txtdlDH.Name = "txtdlDH"
        Me.txtdlDH.Size = New System.Drawing.Size(65, 20)
        Me.txtdlDH.TabIndex = 29
        Me.txtdlDH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdlTerm
        '
        Me.txtdlTerm.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlTerm", True))
        Me.txtdlTerm.Location = New System.Drawing.Point(856, 122)
        Me.txtdlTerm.Name = "txtdlTerm"
        Me.txtdlTerm.Size = New System.Drawing.Size(65, 20)
        Me.txtdlTerm.TabIndex = 30
        Me.txtdlTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DoorHangerToolStripMenuItem, Me.TerminationShutOffToolStripMenuItem, Me.ViewToolStripMenuItem, Me.MaintenanceToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(954, 24)
        Me.MenuStrip1.TabIndex = 32
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.CleanSweepToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ImportToolStripMenuItem.Text = "&Import - Get Billmaster Data"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.UpdateToolStripMenuItem.Text = "&Update"
        '
        'CleanSweepToolStripMenuItem
        '
        Me.CleanSweepToolStripMenuItem.Name = "CleanSweepToolStripMenuItem"
        Me.CleanSweepToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.CleanSweepToolStripMenuItem.Text = "&Clean Sweep"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'DoorHangerToolStripMenuItem
        '
        Me.DoorHangerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReviewToolStripMenuItem, Me.PrintLabelsToolStripMenuItem, Me.CSCReportToolStripMenuItem})
        Me.DoorHangerToolStripMenuItem.Name = "DoorHangerToolStripMenuItem"
        Me.DoorHangerToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.DoorHangerToolStripMenuItem.Text = "&Door Hanger"
        '
        'ReviewToolStripMenuItem
        '
        Me.ReviewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cycle1ToolStripMenuItem, Me.Cycle2ToolStripMenuItem, Me.Cycle3ToolStripMenuItem, Me.Cycle4ToolStripMenuItem})
        Me.ReviewToolStripMenuItem.Name = "ReviewToolStripMenuItem"
        Me.ReviewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ReviewToolStripMenuItem.Text = "Review"
        '
        'Cycle1ToolStripMenuItem
        '
        Me.Cycle1ToolStripMenuItem.Name = "Cycle1ToolStripMenuItem"
        Me.Cycle1ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.Cycle1ToolStripMenuItem.Text = "Cycle 1"
        '
        'Cycle2ToolStripMenuItem
        '
        Me.Cycle2ToolStripMenuItem.Name = "Cycle2ToolStripMenuItem"
        Me.Cycle2ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.Cycle2ToolStripMenuItem.Text = "Cycle 2"
        '
        'Cycle3ToolStripMenuItem
        '
        Me.Cycle3ToolStripMenuItem.Name = "Cycle3ToolStripMenuItem"
        Me.Cycle3ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.Cycle3ToolStripMenuItem.Text = "Cycle 3"
        '
        'Cycle4ToolStripMenuItem
        '
        Me.Cycle4ToolStripMenuItem.Name = "Cycle4ToolStripMenuItem"
        Me.Cycle4ToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.Cycle4ToolStripMenuItem.Text = "Cycle 4"
        '
        'PrintLabelsToolStripMenuItem
        '
        Me.PrintLabelsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelsToolStripMenuItem, Me.CustomerServiceChargesToolStripMenuItem, Me.ReportToolStripMenuItem})
        Me.PrintLabelsToolStripMenuItem.Name = "PrintLabelsToolStripMenuItem"
        Me.PrintLabelsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PrintLabelsToolStripMenuItem.Text = "Print"
        '
        'LabelsToolStripMenuItem
        '
        Me.LabelsToolStripMenuItem.Name = "LabelsToolStripMenuItem"
        Me.LabelsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.LabelsToolStripMenuItem.Text = "Labels"
        '
        'CustomerServiceChargesToolStripMenuItem
        '
        Me.CustomerServiceChargesToolStripMenuItem.Name = "CustomerServiceChargesToolStripMenuItem"
        Me.CustomerServiceChargesToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.CustomerServiceChargesToolStripMenuItem.Text = "Customer Service Charges (CSC)"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'CSCReportToolStripMenuItem
        '
        Me.CSCReportToolStripMenuItem.Name = "CSCReportToolStripMenuItem"
        Me.CSCReportToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.CSCReportToolStripMenuItem.Text = "Create CSC File"
        '
        'TerminationShutOffToolStripMenuItem
        '
        Me.TerminationShutOffToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReviewToolStripMenuItem1, Me.PrintToolStripMenuItem})
        Me.TerminationShutOffToolStripMenuItem.Name = "TerminationShutOffToolStripMenuItem"
        Me.TerminationShutOffToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.TerminationShutOffToolStripMenuItem.Text = "&Termination"
        '
        'ReviewToolStripMenuItem1
        '
        Me.ReviewToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cycle1ToolStripMenuItem1, Me.Cycle2ToolStripMenuItem1, Me.Cycle3ToolStripMenuItem1, Me.Cycle4ToolStripMenuItem1})
        Me.ReviewToolStripMenuItem1.Name = "ReviewToolStripMenuItem1"
        Me.ReviewToolStripMenuItem1.Size = New System.Drawing.Size(111, 22)
        Me.ReviewToolStripMenuItem1.Text = "Review"
        '
        'Cycle1ToolStripMenuItem1
        '
        Me.Cycle1ToolStripMenuItem1.Name = "Cycle1ToolStripMenuItem1"
        Me.Cycle1ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.Cycle1ToolStripMenuItem1.Text = "Cycle 1"
        '
        'Cycle2ToolStripMenuItem1
        '
        Me.Cycle2ToolStripMenuItem1.Name = "Cycle2ToolStripMenuItem1"
        Me.Cycle2ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.Cycle2ToolStripMenuItem1.Text = "Cycle 2"
        '
        'Cycle3ToolStripMenuItem1
        '
        Me.Cycle3ToolStripMenuItem1.Name = "Cycle3ToolStripMenuItem1"
        Me.Cycle3ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.Cycle3ToolStripMenuItem1.Text = "Cycle 3"
        '
        'Cycle4ToolStripMenuItem1
        '
        Me.Cycle4ToolStripMenuItem1.Name = "Cycle4ToolStripMenuItem1"
        Me.Cycle4ToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
        Me.Cycle4ToolStripMenuItem1.Text = "Cycle 4"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelsToolStripMenuItem1, Me.ReportToolStripMenuItem1})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'LabelsToolStripMenuItem1
        '
        Me.LabelsToolStripMenuItem1.Name = "LabelsToolStripMenuItem1"
        Me.LabelsToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.LabelsToolStripMenuItem1.Text = "Labels"
        '
        'ReportToolStripMenuItem1
        '
        Me.ReportToolStripMenuItem1.Name = "ReportToolStripMenuItem1"
        Me.ReportToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.ReportToolStripMenuItem1.Text = "Report"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportedDataToolStripMenuItem, Me.StatusCodesToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ImportedDataToolStripMenuItem
        '
        Me.ImportedDataToolStripMenuItem.Name = "ImportedDataToolStripMenuItem"
        Me.ImportedDataToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ImportedDataToolStripMenuItem.Text = "Imported Data"
        '
        'StatusCodesToolStripMenuItem
        '
        Me.StatusCodesToolStripMenuItem.Name = "StatusCodesToolStripMenuItem"
        Me.StatusCodesToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.StatusCodesToolStripMenuItem.Text = "Status Codes"
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateCodesToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.MaintenanceToolStripMenuItem.Text = "Maintenance"
        '
        'UpdateCodesToolStripMenuItem
        '
        Me.UpdateCodesToolStripMenuItem.Name = "UpdateCodesToolStripMenuItem"
        Me.UpdateCodesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.UpdateCodesToolStripMenuItem.Text = "Import Codes/Descriptions"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentationToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'DocumentationToolStripMenuItem
        '
        Me.DocumentationToolStripMenuItem.Name = "DocumentationToolStripMenuItem"
        Me.DocumentationToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DocumentationToolStripMenuItem.Text = "D&ocumentation"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(25, 194)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(57, 13)
        Me.lblAccount.TabIndex = 33
        Me.lblAccount.Text = "Account #"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(0, 219)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(82, 13)
        Me.lblName.TabIndex = 34
        Me.lblName.Text = "Customer Name"
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(6, 246)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(76, 13)
        Me.lblAddr.TabIndex = 35
        Me.lblAddr.Text = "Street Address"
        '
        'lblLoc
        '
        Me.lblLoc.AutoSize = True
        Me.lblLoc.Location = New System.Drawing.Point(4, 276)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(78, 13)
        Me.lblLoc.TabIndex = 36
        Me.lblLoc.Text = "Meter Location"
        '
        'lblStCde
        '
        Me.lblStCde.AutoSize = True
        Me.lblStCde.Location = New System.Drawing.Point(15, 301)
        Me.lblStCde.Name = "lblStCde"
        Me.lblStCde.Size = New System.Drawing.Size(67, 13)
        Me.lblStCde.TabIndex = 37
        Me.lblStCde.Text = "Meter Status"
        '
        'lblStCdeDte
        '
        Me.lblStCdeDte.AutoSize = True
        Me.lblStCdeDte.Location = New System.Drawing.Point(19, 326)
        Me.lblStCdeDte.Name = "lblStCdeDte"
        Me.lblStCdeDte.Size = New System.Drawing.Size(63, 13)
        Me.lblStCdeDte.TabIndex = 38
        Me.lblStCdeDte.Text = "Status Date"
        '
        'lblBal
        '
        Me.lblBal.AutoSize = True
        Me.lblBal.Location = New System.Drawing.Point(604, 222)
        Me.lblBal.Name = "lblBal"
        Me.lblBal.Size = New System.Drawing.Size(83, 13)
        Me.lblBal.TabIndex = 39
        Me.lblBal.Text = "Current Balance"
        '
        'lblLstPayAmt
        '
        Me.lblLstPayAmt.AutoSize = True
        Me.lblLstPayAmt.Location = New System.Drawing.Point(351, 194)
        Me.lblLstPayAmt.Name = "lblLstPayAmt"
        Me.lblLstPayAmt.Size = New System.Drawing.Size(90, 13)
        Me.lblLstPayAmt.TabIndex = 40
        Me.lblLstPayAmt.Text = "Last Amount Paid"
        '
        'lblLstPayDte
        '
        Me.lblLstPayDte.AutoSize = True
        Me.lblLstPayDte.Location = New System.Drawing.Point(344, 218)
        Me.lblLstPayDte.Name = "lblLstPayDte"
        Me.lblLstPayDte.Size = New System.Drawing.Size(97, 13)
        Me.lblLstPayDte.TabIndex = 41
        Me.lblLstPayDte.Text = "Last Payment Date"
        '
        'lblUnPayAmt
        '
        Me.lblUnPayAmt.AutoSize = True
        Me.lblUnPayAmt.Location = New System.Drawing.Point(587, 194)
        Me.lblUnPayAmt.Name = "lblUnPayAmt"
        Me.lblUnPayAmt.Size = New System.Drawing.Size(97, 13)
        Me.lblUnPayAmt.TabIndex = 42
        Me.lblUnPayAmt.Text = "Unposted Payment"
        '
        'lblAgrMadeDte
        '
        Me.lblAgrMadeDte.AutoSize = True
        Me.lblAgrMadeDte.Location = New System.Drawing.Point(568, 275)
        Me.lblAgrMadeDte.Name = "lblAgrMadeDte"
        Me.lblAgrMadeDte.Size = New System.Drawing.Size(116, 13)
        Me.lblAgrMadeDte.TabIndex = 43
        Me.lblAgrMadeDte.Text = "Arrangements made on"
        '
        'lblAgrPayAmt
        '
        Me.lblAgrPayAmt.AutoSize = True
        Me.lblAgrPayAmt.Location = New System.Drawing.Point(604, 300)
        Me.lblAgrPayAmt.Name = "lblAgrPayAmt"
        Me.lblAgrPayAmt.Size = New System.Drawing.Size(80, 13)
        Me.lblAgrPayAmt.TabIndex = 44
        Me.lblAgrPayAmt.Text = "Agreed Amount"
        '
        'lblAgrPayDueDte
        '
        Me.lblAgrPayDueDte.AutoSize = True
        Me.lblAgrPayDueDte.Location = New System.Drawing.Point(620, 325)
        Me.lblAgrPayDueDte.Name = "lblAgrPayDueDte"
        Me.lblAgrPayDueDte.Size = New System.Drawing.Size(64, 13)
        Me.lblAgrPayDueDte.TabIndex = 45
        Me.lblAgrPayDueDte.Text = "Agreed Due"
        '
        'lblPNote
        '
        Me.lblPNote.AutoSize = True
        Me.lblPNote.Location = New System.Drawing.Point(314, 363)
        Me.lblPNote.Name = "lblPNote"
        Me.lblPNote.Size = New System.Drawing.Size(75, 13)
        Me.lblPNote.TabIndex = 46
        Me.lblPNote.Text = "Premise Notes"
        '
        'cbDHPrinted
        '
        Me.cbDHPrinted.AutoSize = True
        Me.cbDHPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdHang", True))
        Me.cbDHPrinted.Location = New System.Drawing.Point(12, 164)
        Me.cbDHPrinted.Name = "cbDHPrinted"
        Me.cbDHPrinted.Size = New System.Drawing.Size(123, 17)
        Me.cbDHPrinted.TabIndex = 49
        Me.cbDHPrinted.Text = "Door Hanger Printed"
        Me.cbDHPrinted.UseVisualStyleBackColor = True
        '
        'cbTermPrinted
        '
        Me.cbTermPrinted.AutoSize = True
        Me.cbTermPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdTerm", True))
        Me.cbTermPrinted.Location = New System.Drawing.Point(141, 164)
        Me.cbTermPrinted.Name = "cbTermPrinted"
        Me.cbTermPrinted.Size = New System.Drawing.Size(117, 17)
        Me.cbTermPrinted.TabIndex = 50
        Me.cbTermPrinted.Text = "Termination Printed"
        Me.cbTermPrinted.UseVisualStyleBackColor = True
        '
        'dtpHangDte
        '
        Me.dtpHangDte.Location = New System.Drawing.Point(458, 45)
        Me.dtpHangDte.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpHangDte.Name = "dtpHangDte"
        Me.dtpHangDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpHangDte.TabIndex = 52
        '
        'dtpCntDte
        '
        Me.dtpCntDte.Location = New System.Drawing.Point(458, 67)
        Me.dtpCntDte.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpCntDte.Name = "dtpCntDte"
        Me.dtpCntDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpCntDte.TabIndex = 53
        '
        'dtpTermDte
        '
        Me.dtpTermDte.Location = New System.Drawing.Point(458, 91)
        Me.dtpTermDte.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpTermDte.Name = "dtpTermDte"
        Me.dtpTermDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpTermDte.TabIndex = 54
        '
        'lblUserNotification
        '
        Me.lblUserNotification.AutoSize = True
        Me.lblUserNotification.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblUserNotification.Location = New System.Drawing.Point(0, 534)
        Me.lblUserNotification.Name = "lblUserNotification"
        Me.lblUserNotification.Size = New System.Drawing.Size(85, 13)
        Me.lblUserNotification.TabIndex = 55
        Me.lblUserNotification.Text = "User Notification"
        '
        'TblWorkingDataBindingNavigator
        '
        Me.TblWorkingDataBindingNavigator.AddNewItem = Nothing
        Me.TblWorkingDataBindingNavigator.BackColor = System.Drawing.Color.LightGray
        Me.TblWorkingDataBindingNavigator.BindingSource = Me.TblWorkingDataBindingSource
        Me.TblWorkingDataBindingNavigator.CountItem = Me.BindingNavigatorCountItem1
        Me.TblWorkingDataBindingNavigator.DeleteItem = Nothing
        Me.TblWorkingDataBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.TblWorkingDataBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.ToolStripBtnSearch, Me.BindingNavigatorSaveItem, Me.BindingNavigatorAddItem})
        Me.TblWorkingDataBindingNavigator.Location = New System.Drawing.Point(8, 133)
        Me.TblWorkingDataBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.TblWorkingDataBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.TblWorkingDataBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.TblWorkingDataBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.TblWorkingDataBindingNavigator.Name = "TblWorkingDataBindingNavigator"
        Me.TblWorkingDataBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem1
        Me.TblWorkingDataBindingNavigator.Size = New System.Drawing.Size(519, 25)
        Me.TblWorkingDataBindingNavigator.TabIndex = 56
        Me.TblWorkingDataBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem1
        '
        Me.BindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem1.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem1.Name = "BindingNavigatorMoveFirstItem1"
        Me.BindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem1.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem1
        '
        Me.BindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem1.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem1.Name = "BindingNavigatorMovePreviousItem1"
        Me.BindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem1.Text = "Move previous"
        '
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem1
        '
        Me.BindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem1.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem1.Name = "BindingNavigatorMoveNextItem1"
        Me.BindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem1.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem1
        '
        Me.BindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem1.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem1.Name = "BindingNavigatorMoveLastItem1"
        Me.BindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem1.Text = "Move last"
        '
        'BindingNavigatorSeparator5
        '
        Me.BindingNavigatorSeparator5.Name = "BindingNavigatorSeparator5"
        Me.BindingNavigatorSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripBtnSearch
        '
        Me.ToolStripBtnSearch.Image = Global.DoorHangerApp.My.Resources.Resources.gray_view
        Me.ToolStripBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBtnSearch.Name = "ToolStripBtnSearch"
        Me.ToolStripBtnSearch.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripBtnSearch.Text = "Search"
        '
        'BindingNavigatorSaveItem
        '
        Me.BindingNavigatorSaveItem.Image = CType(resources.GetObject("BindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BindingNavigatorSaveItem.Name = "BindingNavigatorSaveItem"
        Me.BindingNavigatorSaveItem.Size = New System.Drawing.Size(124, 22)
        Me.BindingNavigatorSaveItem.Text = "Save to New Cycle"
        '
        'BindingNavigatorAddItem
        '
        Me.BindingNavigatorAddItem.Image = CType(resources.GetObject("BindingNavigatorAddItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BindingNavigatorAddItem.Name = "BindingNavigatorAddItem"
        Me.BindingNavigatorAddItem.Size = New System.Drawing.Size(124, 22)
        Me.BindingNavigatorAddItem.Text = "Add New Account"
        '
        'txtdlCSweep
        '
        Me.txtdlCSweep.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlCSweep", True))
        Me.txtdlCSweep.Location = New System.Drawing.Point(856, 147)
        Me.txtdlCSweep.Name = "txtdlCSweep"
        Me.txtdlCSweep.Size = New System.Drawing.Size(65, 20)
        Me.txtdlCSweep.TabIndex = 58
        Me.txtdlCSweep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(618, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Account Notes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 363)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Meter Notes"
        '
        'txtMNotes
        '
        Me.txtMNotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdMNotes", True))
        Me.txtMNotes.Location = New System.Drawing.Point(6, 379)
        Me.txtMNotes.Name = "txtMNotes"
        Me.txtMNotes.Size = New System.Drawing.Size(300, 140)
        Me.txtMNotes.TabIndex = 64
        Me.txtMNotes.Text = ""
        '
        'txtPnotes
        '
        Me.txtPnotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPnotes", True))
        Me.txtPnotes.Location = New System.Drawing.Point(312, 379)
        Me.txtPnotes.Name = "txtPnotes"
        Me.txtPnotes.Size = New System.Drawing.Size(300, 140)
        Me.txtPnotes.TabIndex = 65
        Me.txtPnotes.Text = ""
        '
        'txtANotes
        '
        Me.txtANotes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdANotes", True))
        Me.txtANotes.Location = New System.Drawing.Point(618, 379)
        Me.txtANotes.Name = "txtANotes"
        Me.txtANotes.Size = New System.Drawing.Size(300, 140)
        Me.txtANotes.TabIndex = 66
        Me.txtANotes.Text = ""
        '
        'txtPriRte
        '
        Me.txtPriRte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPriRte", True))
        Me.txtPriRte.Location = New System.Drawing.Point(444, 297)
        Me.txtPriRte.Name = "txtPriRte"
        Me.txtPriRte.Size = New System.Drawing.Size(100, 20)
        Me.txtPriRte.TabIndex = 67
        '
        'txtSecRte
        '
        Me.txtSecRte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdSecRte", True))
        Me.txtSecRte.Location = New System.Drawing.Point(444, 322)
        Me.txtSecRte.Name = "txtSecRte"
        Me.txtSecRte.Size = New System.Drawing.Size(100, 20)
        Me.txtSecRte.TabIndex = 68
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(349, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(309, 14)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Select Dates Below"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMinDue
        '
        Me.txtMinDue.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinDue.CausesValidation = False
        Me.txtMinDue.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdMinDue", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "C2"))
        Me.txtMinDue.Location = New System.Drawing.Point(856, 191)
        Me.txtMinDue.Name = "txtMinDue"
        Me.txtMinDue.ReadOnly = True
        Me.txtMinDue.Size = New System.Drawing.Size(65, 20)
        Me.txtMinDue.TabIndex = 70
        Me.txtMinDue.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(779, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Minimum Due"
        '
        'TblShutOffBindingSource
        '
        Me.TblShutOffBindingSource.DataMember = "tblShutOff"
        Me.TblShutOffBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'TblCodesBindingSource
        '
        Me.TblCodesBindingSource.DataMember = "tblCodes"
        Me.TblCodesBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'TblExcelExportBindingSource
        '
        Me.TblExcelExportBindingSource.DataMember = "tblExcelExport"
        Me.TblExcelExportBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'TblShutOffTableAdapter
        '
        Me.TblShutOffTableAdapter.ClearBeforeFill = False
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tblCodesTableAdapter = Nothing
        Me.TableAdapterManager.tblDateLogTableAdapter = Nothing
        Me.TableAdapterManager.tblExcelExportTableAdapter = Nothing
        Me.TableAdapterManager.tblShutOffTableAdapter = Me.TblShutOffTableAdapter
        Me.TableAdapterManager.tblWorkingDataTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TblWorkingDataTableAdapter
        '
        Me.TblWorkingDataTableAdapter.ClearBeforeFill = True
        '
        'TblCodesTableAdapter
        '
        Me.TblCodesTableAdapter.ClearBeforeFill = True
        '
        'TblDateLogTableAdapter
        '
        Me.TblDateLogTableAdapter.ClearBeforeFill = True
        '
        'TblExcelExportTableAdapter
        '
        Me.TblExcelExportTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(954, 547)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMinDue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(WdSecRteLabel)
        Me.Controls.Add(Me.txtSecRte)
        Me.Controls.Add(WdPriRteLabel)
        Me.Controls.Add(Me.txtPriRte)
        Me.Controls.Add(Me.txtANotes)
        Me.Controls.Add(Me.txtPnotes)
        Me.Controls.Add(Me.txtMNotes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtdlCSweep)
        Me.Controls.Add(Me.TblWorkingDataBindingNavigator)
        Me.Controls.Add(Me.lblUserNotification)
        Me.Controls.Add(Me.dtpTermDte)
        Me.Controls.Add(Me.dtpCntDte)
        Me.Controls.Add(Me.dtpHangDte)
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
        Me.Controls.Add(Me.txtdlTerm)
        Me.Controls.Add(Me.txtdlDH)
        Me.Controls.Add(Me.txtdlUpdate)
        Me.Controls.Add(Me.txtdlNew)
        Me.Controls.Add(Me.lbldlCSweep)
        Me.Controls.Add(Me.lbldlTerm)
        Me.Controls.Add(Me.lbldlDH)
        Me.Controls.Add(Me.lbldlUpdate)
        Me.Controls.Add(Me.lbldlNew)
        Me.Controls.Add(Me.lbfrmDteLog)
        Me.Controls.Add(Me.lblCntDte)
        Me.Controls.Add(Me.lblTermDte)
        Me.Controls.Add(Me.lblHangDte)
        Me.Controls.Add(Me.grpNotice)
        Me.Controls.Add(Me.grpCycle)
        Me.Controls.Add(Me.txtAgrPayDueDte)
        Me.Controls.Add(Me.txtAgrPayAmt)
        Me.Controls.Add(Me.txtAgrMadeDte)
        Me.Controls.Add(Me.txtUnPayAmt)
        Me.Controls.Add(Me.txtLstPayDte)
        Me.Controls.Add(Me.txtLstPayAmt)
        Me.Controls.Add(Me.txtBal)
        Me.Controls.Add(Me.txtStCdeDte)
        Me.Controls.Add(Me.txtStCde)
        Me.Controls.Add(Me.txtLoc)
        Me.Controls.Add(Me.txtAddr)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Door Hanger Application by 3Waters"
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCycle.ResumeLayout(False)
        Me.grpCycle.PerformLayout()
        Me.grpNotice.ResumeLayout(False)
        Me.grpNotice.PerformLayout()
        CType(Me.TblDateLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TblWorkingDataBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblWorkingDataBindingNavigator.ResumeLayout(False)
        Me.TblWorkingDataBindingNavigator.PerformLayout()
        CType(Me.TblShutOffBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblExcelExportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents txtLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtStCde As System.Windows.Forms.TextBox
    Friend WithEvents txtStCdeDte As System.Windows.Forms.TextBox
    Friend WithEvents txtBal As System.Windows.Forms.TextBox
    Friend WithEvents txtLstPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtLstPayDte As System.Windows.Forms.TextBox
    Friend WithEvents txtUnPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtAgrMadeDte As System.Windows.Forms.TextBox
    Friend WithEvents txtAgrPayAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtAgrPayDueDte As System.Windows.Forms.TextBox
    Friend WithEvents grpCycle As System.Windows.Forms.GroupBox
    Friend WithEvents rdoBtnCycle4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnCycle3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnCycle2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnCycle1 As System.Windows.Forms.RadioButton
    Friend WithEvents grpNotice As System.Windows.Forms.GroupBox
    Friend WithEvents rdoBtnTerm As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBtnDH As System.Windows.Forms.RadioButton
    Friend WithEvents lblHangDte As System.Windows.Forms.Label
    Friend WithEvents lblTermDte As System.Windows.Forms.Label
    Friend WithEvents lblCntDte As System.Windows.Forms.Label
    Friend WithEvents lbfrmDteLog As System.Windows.Forms.Label
    Friend WithEvents lbldlNew As System.Windows.Forms.Label
    Friend WithEvents lbldlUpdate As System.Windows.Forms.Label
    Friend WithEvents lbldlDH As System.Windows.Forms.Label
    Friend WithEvents lbldlTerm As System.Windows.Forms.Label
    Friend WithEvents lbldlCSweep As System.Windows.Forms.Label
    Friend WithEvents txtdlNew As System.Windows.Forms.TextBox
    Friend WithEvents txtdlUpdate As System.Windows.Forms.TextBox
    Friend WithEvents txtdlDH As System.Windows.Forms.TextBox
    Friend WithEvents txtdlTerm As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CleanSweepToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DoorHangerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintLabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerServiceChargesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CSCReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminationShutOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReviewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAddr As System.Windows.Forms.Label
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents lblStCde As System.Windows.Forms.Label
    Friend WithEvents lblStCdeDte As System.Windows.Forms.Label
    Friend WithEvents lblBal As System.Windows.Forms.Label
    Friend WithEvents lblLstPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblLstPayDte As System.Windows.Forms.Label
    Friend WithEvents lblUnPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblAgrMadeDte As System.Windows.Forms.Label
    Friend WithEvents lblAgrPayAmt As System.Windows.Forms.Label
    Friend WithEvents lblAgrPayDueDte As System.Windows.Forms.Label
    Friend WithEvents lblPNote As System.Windows.Forms.Label
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DhA_sampleDataSet1 As DoorHangerApp.DHA_sampleDataSet
    Friend WithEvents TblShutOffBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblShutOffTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblShutOffTableAdapter
    Friend WithEvents TableAdapterManager As DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbDHPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents cbTermPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportedDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpHangDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCntDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTermDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents TblWorkingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblWorkingDataTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter
    Friend WithEvents lblUserNotification As System.Windows.Forms.Label
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TblCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblCodesTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter
    Friend WithEvents TblDateLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblDateLogTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblDateLogTableAdapter
    Friend WithEvents TblWorkingDataBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cycle1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle1ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle2ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle3ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cycle4ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TblExcelExportBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblExcelExportTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblExcelExportTableAdapter
    Friend WithEvents RdoBtnAll As System.Windows.Forms.RadioButton
    Friend WithEvents txtdlCSweep As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents txtPnotes As System.Windows.Forms.RichTextBox
    Friend WithEvents txtANotes As System.Windows.Forms.RichTextBox
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPriRte As System.Windows.Forms.TextBox
    Friend WithEvents txtSecRte As System.Windows.Forms.TextBox
    Friend WithEvents BindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorAddItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripBtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMinDue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
