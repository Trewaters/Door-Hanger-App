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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.TblWorkingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DhA_sampleDataSet1 = New FCLWD_DoorHangerApp.DHA_sampleDataSet()
        Me.TblShutOffBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.txtdlUpdate = New System.Windows.Forms.TextBox()
        Me.TblDateLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.PrintLabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerServiceChargesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSCReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminationShutOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReviewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportedDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TblShutOffBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TblShutOffDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.cbDHPrinted = New System.Windows.Forms.CheckBox()
        Me.cbTermPrinted = New System.Windows.Forms.CheckBox()
        Me.dtpHangDte = New System.Windows.Forms.DateTimePicker()
        Me.dtpCntDte = New System.Windows.Forms.DateTimePicker()
        Me.dtpTermDte = New System.Windows.Forms.DateTimePicker()
        Me.TblWorkingDataDataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUserNotification = New System.Windows.Forms.Label()
        Me.TblCodesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblDateLogDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn58 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn59 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn61 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn62 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblShutOffTableAdapter = New FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblShutOffTableAdapter()
        Me.TableAdapterManager = New FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager()
        Me.TblWorkingDataTableAdapter = New FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter()
        Me.TblCodesTableAdapter = New FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter()
        Me.TblDateLogTableAdapter = New FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblDateLogTableAdapter()
        Me.TblWorkingDataBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem1 = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblShutOffBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCycle.SuspendLayout()
        Me.grpNotice.SuspendLayout()
        CType(Me.TblDateLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TblShutOffBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblShutOffBindingNavigator.SuspendLayout()
        CType(Me.TblShutOffDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblWorkingDataDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblCodesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDateLogDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblWorkingDataBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblWorkingDataBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAccount
        '
        Me.txtAccount.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAccount", True))
        Me.txtAccount.Location = New System.Drawing.Point(147, 216)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(100, 20)
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
        'TblShutOffBindingSource
        '
        Me.TblShutOffBindingSource.DataMember = "tblShutOff"
        Me.TblShutOffBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'txtName
        '
        Me.txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdName", True))
        Me.txtName.Location = New System.Drawing.Point(147, 242)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 1
        '
        'txtAddr
        '
        Me.txtAddr.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAddr", True))
        Me.txtAddr.Location = New System.Drawing.Point(147, 270)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtAddr.TabIndex = 2
        '
        'txtLoc
        '
        Me.txtLoc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLoc", True))
        Me.txtLoc.Location = New System.Drawing.Point(147, 299)
        Me.txtLoc.Name = "txtLoc"
        Me.txtLoc.Size = New System.Drawing.Size(100, 20)
        Me.txtLoc.TabIndex = 3
        '
        'txtStCde
        '
        Me.txtStCde.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStDesc", True))
        Me.txtStCde.Location = New System.Drawing.Point(147, 325)
        Me.txtStCde.Name = "txtStCde"
        Me.txtStCde.Size = New System.Drawing.Size(100, 20)
        Me.txtStCde.TabIndex = 4
        '
        'txtStCdeDte
        '
        Me.txtStCdeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdStCdeDte", True))
        Me.txtStCdeDte.Location = New System.Drawing.Point(147, 354)
        Me.txtStCdeDte.Name = "txtStCdeDte"
        Me.txtStCdeDte.Size = New System.Drawing.Size(100, 20)
        Me.txtStCdeDte.TabIndex = 5
        '
        'txtBal
        '
        Me.txtBal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdBal", True))
        Me.txtBal.Location = New System.Drawing.Point(433, 253)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.Size = New System.Drawing.Size(100, 20)
        Me.txtBal.TabIndex = 6
        '
        'txtLstPayAmt
        '
        Me.txtLstPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayAmt", True))
        Me.txtLstPayAmt.Location = New System.Drawing.Point(433, 280)
        Me.txtLstPayAmt.Name = "txtLstPayAmt"
        Me.txtLstPayAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtLstPayAmt.TabIndex = 7
        '
        'txtLstPayDte
        '
        Me.txtLstPayDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdLstPayDte", True))
        Me.txtLstPayDte.Location = New System.Drawing.Point(433, 307)
        Me.txtLstPayDte.Name = "txtLstPayDte"
        Me.txtLstPayDte.Size = New System.Drawing.Size(100, 20)
        Me.txtLstPayDte.TabIndex = 8
        '
        'txtUnPayAmt
        '
        Me.txtUnPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdUnPmt", True))
        Me.txtUnPayAmt.Location = New System.Drawing.Point(433, 334)
        Me.txtUnPayAmt.Name = "txtUnPayAmt"
        Me.txtUnPayAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtUnPayAmt.TabIndex = 9
        '
        'txtAgrMadeDte
        '
        Me.txtAgrMadeDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeMade", True))
        Me.txtAgrMadeDte.Location = New System.Drawing.Point(672, 249)
        Me.txtAgrMadeDte.Name = "txtAgrMadeDte"
        Me.txtAgrMadeDte.Size = New System.Drawing.Size(100, 20)
        Me.txtAgrMadeDte.TabIndex = 10
        '
        'txtAgrPayAmt
        '
        Me.txtAgrPayAmt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdPmtAgreed", True))
        Me.txtAgrPayAmt.Location = New System.Drawing.Point(672, 276)
        Me.txtAgrPayAmt.Name = "txtAgrPayAmt"
        Me.txtAgrPayAmt.Size = New System.Drawing.Size(100, 20)
        Me.txtAgrPayAmt.TabIndex = 11
        '
        'txtAgrPayDueDte
        '
        Me.txtAgrPayDueDte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblWorkingDataBindingSource, "wdAgreeDue", True))
        Me.txtAgrPayDueDte.Location = New System.Drawing.Point(672, 303)
        Me.txtAgrPayDueDte.Name = "txtAgrPayDueDte"
        Me.txtAgrPayDueDte.Size = New System.Drawing.Size(100, 20)
        Me.txtAgrPayDueDte.TabIndex = 12
        '
        'grpCycle
        '
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle4)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle3)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle2)
        Me.grpCycle.Controls.Add(Me.rdoBtnCycle1)
        Me.grpCycle.Location = New System.Drawing.Point(12, 48)
        Me.grpCycle.Name = "grpCycle"
        Me.grpCycle.Size = New System.Drawing.Size(267, 44)
        Me.grpCycle.TabIndex = 13
        Me.grpCycle.TabStop = False
        Me.grpCycle.Text = "Select Cycle:"
        '
        'rdoBtnCycle4
        '
        Me.rdoBtnCycle4.AutoSize = True
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
        Me.grpNotice.Controls.Add(Me.rdoBtnTerm)
        Me.grpNotice.Controls.Add(Me.rdoBtnDH)
        Me.grpNotice.Location = New System.Drawing.Point(12, 98)
        Me.grpNotice.Name = "grpNotice"
        Me.grpNotice.Size = New System.Drawing.Size(248, 48)
        Me.grpNotice.TabIndex = 14
        Me.grpNotice.TabStop = False
        Me.grpNotice.Text = "Select Notification:"
        '
        'rdoBtnTerm
        '
        Me.rdoBtnTerm.AutoSize = True
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
        Me.rdoBtnDH.Checked = True
        Me.rdoBtnDH.Location = New System.Drawing.Point(3, 16)
        Me.rdoBtnDH.Name = "rdoBtnDH"
        Me.rdoBtnDH.Size = New System.Drawing.Size(91, 17)
        Me.rdoBtnDH.TabIndex = 0
        Me.rdoBtnDH.TabStop = True
        Me.rdoBtnDH.Text = "Door Hangers"
        Me.rdoBtnDH.UseVisualStyleBackColor = True
        '
        'lblHangDte
        '
        Me.lblHangDte.AutoSize = True
        Me.lblHangDte.Location = New System.Drawing.Point(285, 95)
        Me.lblHangDte.Name = "lblHangDte"
        Me.lblHangDte.Size = New System.Drawing.Size(82, 13)
        Me.lblHangDte.TabIndex = 15
        Me.lblHangDte.Text = "Hang On Date -"
        '
        'lblTermDte
        '
        Me.lblTermDte.AutoSize = True
        Me.lblTermDte.Location = New System.Drawing.Point(284, 195)
        Me.lblTermDte.Name = "lblTermDte"
        Me.lblTermDte.Size = New System.Drawing.Size(138, 13)
        Me.lblTermDte.TabIndex = 19
        Me.lblTermDte.Text = "Termination/Shut Off Date -"
        '
        'lblCntDte
        '
        Me.lblCntDte.AutoSize = True
        Me.lblCntDte.Location = New System.Drawing.Point(284, 138)
        Me.lblCntDte.Name = "lblCntDte"
        Me.lblCntDte.Size = New System.Drawing.Size(95, 13)
        Me.lblCntDte.TabIndex = 20
        Me.lblCntDte.Text = "Contact Office by -"
        '
        'lbfrmDteLog
        '
        Me.lbfrmDteLog.AutoSize = True
        Me.lbfrmDteLog.Location = New System.Drawing.Point(631, 79)
        Me.lbfrmDteLog.Name = "lbfrmDteLog"
        Me.lbfrmDteLog.Size = New System.Drawing.Size(119, 13)
        Me.lbfrmDteLog.TabIndex = 21
        Me.lbfrmDteLog.Text = "Date Logs for Cycle #1 "
        '
        'lbldlNew
        '
        Me.lbldlNew.AutoSize = True
        Me.lbldlNew.Location = New System.Drawing.Point(556, 98)
        Me.lbldlNew.Name = "lbldlNew"
        Me.lbldlNew.Size = New System.Drawing.Size(106, 13)
        Me.lbldlNew.TabIndex = 22
        Me.lbldlNew.Text = "New Billmaster data -"
        '
        'lbldlUpdate
        '
        Me.lbldlUpdate.AutoSize = True
        Me.lbldlUpdate.Location = New System.Drawing.Point(537, 124)
        Me.lbldlUpdate.Name = "lbldlUpdate"
        Me.lbldlUpdate.Size = New System.Drawing.Size(125, 13)
        Me.lbldlUpdate.TabIndex = 23
        Me.lbldlUpdate.Text = "Updated Billmaster data -"
        '
        'lbldlDH
        '
        Me.lbldlDH.AutoSize = True
        Me.lbldlDH.Location = New System.Drawing.Point(548, 148)
        Me.lbldlDH.Name = "lbldlDH"
        Me.lbldlDH.Size = New System.Drawing.Size(114, 13)
        Me.lbldlDH.TabIndex = 24
        Me.lbldlDH.Text = "Door Hangers printed -"
        '
        'lbldlTerm
        '
        Me.lbldlTerm.AutoSize = True
        Me.lbldlTerm.Location = New System.Drawing.Point(554, 169)
        Me.lbldlTerm.Name = "lbldlTerm"
        Me.lbldlTerm.Size = New System.Drawing.Size(108, 13)
        Me.lbldlTerm.TabIndex = 25
        Me.lbldlTerm.Text = "Terminations printed -"
        '
        'lbldlCSweep
        '
        Me.lbldlCSweep.AutoSize = True
        Me.lbldlCSweep.Location = New System.Drawing.Point(586, 197)
        Me.lbldlCSweep.Name = "lbldlCSweep"
        Me.lbldlCSweep.Size = New System.Drawing.Size(76, 13)
        Me.lbldlCSweep.TabIndex = 26
        Me.lbldlCSweep.Text = "Clean Sweep -"
        '
        'txtdlNew
        '
        Me.txtdlNew.Location = New System.Drawing.Point(674, 98)
        Me.txtdlNew.Name = "txtdlNew"
        Me.txtdlNew.Size = New System.Drawing.Size(100, 20)
        Me.txtdlNew.TabIndex = 27
        '
        'txtdlUpdate
        '
        Me.txtdlUpdate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TblDateLogBindingSource, "dlUpdate", True))
        Me.txtdlUpdate.Location = New System.Drawing.Point(674, 122)
        Me.txtdlUpdate.Name = "txtdlUpdate"
        Me.txtdlUpdate.Size = New System.Drawing.Size(100, 20)
        Me.txtdlUpdate.TabIndex = 28
        '
        'TblDateLogBindingSource
        '
        Me.TblDateLogBindingSource.DataMember = "tblDateLog"
        Me.TblDateLogBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'txtdlDH
        '
        Me.txtdlDH.Location = New System.Drawing.Point(674, 148)
        Me.txtdlDH.Name = "txtdlDH"
        Me.txtdlDH.Size = New System.Drawing.Size(100, 20)
        Me.txtdlDH.TabIndex = 29
        '
        'txtdlTerm
        '
        Me.txtdlTerm.Location = New System.Drawing.Point(674, 169)
        Me.txtdlTerm.Name = "txtdlTerm"
        Me.txtdlTerm.Size = New System.Drawing.Size(100, 20)
        Me.txtdlTerm.TabIndex = 30
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DoorHangerToolStripMenuItem, Me.TerminationShutOffToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem, Me.MaintenanceToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(845, 24)
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
        Me.ReviewToolStripMenuItem.Name = "ReviewToolStripMenuItem"
        Me.ReviewToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ReviewToolStripMenuItem.Text = "Review"
        '
        'PrintLabelsToolStripMenuItem
        '
        Me.PrintLabelsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportToolStripMenuItem, Me.LabelsToolStripMenuItem, Me.CustomerServiceChargesToolStripMenuItem})
        Me.PrintLabelsToolStripMenuItem.Name = "PrintLabelsToolStripMenuItem"
        Me.PrintLabelsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PrintLabelsToolStripMenuItem.Text = "Print"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
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
        Me.TerminationShutOffToolStripMenuItem.Size = New System.Drawing.Size(133, 20)
        Me.TerminationShutOffToolStripMenuItem.Text = "&Termination/Shut Off"
        '
        'ReviewToolStripMenuItem1
        '
        Me.ReviewToolStripMenuItem1.Name = "ReviewToolStripMenuItem1"
        Me.ReviewToolStripMenuItem1.Size = New System.Drawing.Size(111, 22)
        Me.ReviewToolStripMenuItem1.Text = "Review"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportToolStripMenuItem1, Me.LabelsToolStripMenuItem1})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ReportToolStripMenuItem1
        '
        Me.ReportToolStripMenuItem1.Name = "ReportToolStripMenuItem1"
        Me.ReportToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.ReportToolStripMenuItem1.Text = "Report"
        '
        'LabelsToolStripMenuItem1
        '
        Me.LabelsToolStripMenuItem1.Name = "LabelsToolStripMenuItem1"
        Me.LabelsToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.LabelsToolStripMenuItem1.Text = "Labels"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportedDataToolStripMenuItem})
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
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateCodesToolStripMenuItem})
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
        'lblAccount
        '
        Me.lblAccount.AutoSize = True
        Me.lblAccount.Location = New System.Drawing.Point(11, 219)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(57, 13)
        Me.lblAccount.TabIndex = 33
        Me.lblAccount.Text = "Account #"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(11, 244)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(82, 13)
        Me.lblName.TabIndex = 34
        Me.lblName.Text = "Customer Name"
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(11, 273)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(76, 13)
        Me.lblAddr.TabIndex = 35
        Me.lblAddr.Text = "Street Address"
        '
        'lblLoc
        '
        Me.lblLoc.AutoSize = True
        Me.lblLoc.Location = New System.Drawing.Point(11, 305)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(78, 13)
        Me.lblLoc.TabIndex = 36
        Me.lblLoc.Text = "Meter Location"
        '
        'lblStCde
        '
        Me.lblStCde.AutoSize = True
        Me.lblStCde.Location = New System.Drawing.Point(11, 331)
        Me.lblStCde.Name = "lblStCde"
        Me.lblStCde.Size = New System.Drawing.Size(67, 13)
        Me.lblStCde.TabIndex = 37
        Me.lblStCde.Text = "Meter Status"
        '
        'lblStCdeDte
        '
        Me.lblStCdeDte.AutoSize = True
        Me.lblStCdeDte.Location = New System.Drawing.Point(11, 357)
        Me.lblStCdeDte.Name = "lblStCdeDte"
        Me.lblStCdeDte.Size = New System.Drawing.Size(63, 13)
        Me.lblStCdeDte.TabIndex = 38
        Me.lblStCdeDte.Text = "Status Date"
        '
        'lblBal
        '
        Me.lblBal.AutoSize = True
        Me.lblBal.Location = New System.Drawing.Point(321, 260)
        Me.lblBal.Name = "lblBal"
        Me.lblBal.Size = New System.Drawing.Size(83, 13)
        Me.lblBal.TabIndex = 39
        Me.lblBal.Text = "Current Balance"
        '
        'lblLstPayAmt
        '
        Me.lblLstPayAmt.AutoSize = True
        Me.lblLstPayAmt.Location = New System.Drawing.Point(321, 287)
        Me.lblLstPayAmt.Name = "lblLstPayAmt"
        Me.lblLstPayAmt.Size = New System.Drawing.Size(90, 13)
        Me.lblLstPayAmt.TabIndex = 40
        Me.lblLstPayAmt.Text = "Last Amount Paid"
        '
        'lblLstPayDte
        '
        Me.lblLstPayDte.AutoSize = True
        Me.lblLstPayDte.Location = New System.Drawing.Point(321, 314)
        Me.lblLstPayDte.Name = "lblLstPayDte"
        Me.lblLstPayDte.Size = New System.Drawing.Size(97, 13)
        Me.lblLstPayDte.TabIndex = 41
        Me.lblLstPayDte.Text = "Last Payment Date"
        '
        'lblUnPayAmt
        '
        Me.lblUnPayAmt.AutoSize = True
        Me.lblUnPayAmt.Location = New System.Drawing.Point(321, 341)
        Me.lblUnPayAmt.Name = "lblUnPayAmt"
        Me.lblUnPayAmt.Size = New System.Drawing.Size(97, 13)
        Me.lblUnPayAmt.TabIndex = 42
        Me.lblUnPayAmt.Text = "Unposted Payment"
        '
        'lblAgrMadeDte
        '
        Me.lblAgrMadeDte.AutoSize = True
        Me.lblAgrMadeDte.Location = New System.Drawing.Point(542, 256)
        Me.lblAgrMadeDte.Name = "lblAgrMadeDte"
        Me.lblAgrMadeDte.Size = New System.Drawing.Size(116, 13)
        Me.lblAgrMadeDte.TabIndex = 43
        Me.lblAgrMadeDte.Text = "Arrangements made on"
        '
        'lblAgrPayAmt
        '
        Me.lblAgrPayAmt.AutoSize = True
        Me.lblAgrPayAmt.Location = New System.Drawing.Point(542, 283)
        Me.lblAgrPayAmt.Name = "lblAgrPayAmt"
        Me.lblAgrPayAmt.Size = New System.Drawing.Size(124, 13)
        Me.lblAgrPayAmt.TabIndex = 44
        Me.lblAgrPayAmt.Text = "Agreed Payment Amount"
        '
        'lblAgrPayDueDte
        '
        Me.lblAgrPayDueDte.AutoSize = True
        Me.lblAgrPayDueDte.Location = New System.Drawing.Point(542, 310)
        Me.lblAgrPayDueDte.Name = "lblAgrPayDueDte"
        Me.lblAgrPayDueDte.Size = New System.Drawing.Size(111, 13)
        Me.lblAgrPayDueDte.TabIndex = 45
        Me.lblAgrPayDueDte.Text = "Agreed Payment Date"
        '
        'lblPNote
        '
        Me.lblPNote.AutoSize = True
        Me.lblPNote.Location = New System.Drawing.Point(12, 392)
        Me.lblPNote.Name = "lblPNote"
        Me.lblPNote.Size = New System.Drawing.Size(70, 13)
        Me.lblPNote.TabIndex = 46
        Me.lblPNote.Text = "Premise Note"
        '
        'TblShutOffBindingNavigator
        '
        Me.TblShutOffBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.TblShutOffBindingNavigator.BindingSource = Me.TblShutOffBindingSource
        Me.TblShutOffBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TblShutOffBindingNavigator.DeleteItem = Nothing
        Me.TblShutOffBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.TblShutOffBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem})
        Me.TblShutOffBindingNavigator.Location = New System.Drawing.Point(0, 24)
        Me.TblShutOffBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TblShutOffBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TblShutOffBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TblShutOffBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TblShutOffBindingNavigator.Name = "TblShutOffBindingNavigator"
        Me.TblShutOffBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TblShutOffBindingNavigator.Size = New System.Drawing.Size(232, 25)
        Me.TblShutOffBindingNavigator.TabIndex = 47
        Me.TblShutOffBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TblShutOffDataGridView
        '
        Me.TblShutOffDataGridView.AutoGenerateColumns = False
        Me.TblShutOffDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblShutOffDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25})
        Me.TblShutOffDataGridView.DataSource = Me.TblShutOffBindingSource
        Me.TblShutOffDataGridView.Location = New System.Drawing.Point(399, 424)
        Me.TblShutOffDataGridView.Name = "TblShutOffDataGridView"
        Me.TblShutOffDataGridView.Size = New System.Drawing.Size(375, 230)
        Me.TblShutOffDataGridView.TabIndex = 47
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "soAccount"
        Me.DataGridViewTextBoxColumn1.HeaderText = "soAccount"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "soAge0"
        Me.DataGridViewTextBoxColumn2.HeaderText = "soAge0"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "soAge1"
        Me.DataGridViewTextBoxColumn3.HeaderText = "soAge1"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "soAge2"
        Me.DataGridViewTextBoxColumn4.HeaderText = "soAge2"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "soAge3"
        Me.DataGridViewTextBoxColumn5.HeaderText = "soAge3"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "soAge4"
        Me.DataGridViewTextBoxColumn6.HeaderText = "soAge4"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "soAge5"
        Me.DataGridViewTextBoxColumn7.HeaderText = "soAge5"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "soBal"
        Me.DataGridViewTextBoxColumn8.HeaderText = "soBal"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "soName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "soName"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "soAddr"
        Me.DataGridViewTextBoxColumn10.HeaderText = "soAddr"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "soLoc"
        Me.DataGridViewTextBoxColumn11.HeaderText = "soLoc"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "soCycle"
        Me.DataGridViewTextBoxColumn12.HeaderText = "soCycle"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "soLstPayDte"
        Me.DataGridViewTextBoxColumn13.HeaderText = "soLstPayDte"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "soLstPayAmt"
        Me.DataGridViewTextBoxColumn14.HeaderText = "soLstPayAmt"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "soStCde"
        Me.DataGridViewTextBoxColumn15.HeaderText = "soStCde"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "soStCdeDte"
        Me.DataGridViewTextBoxColumn16.HeaderText = "soStCdeDte"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "soAgreeDue"
        Me.DataGridViewTextBoxColumn17.HeaderText = "soAgreeDue"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "soAgreeMade"
        Me.DataGridViewTextBoxColumn18.HeaderText = "soAgreeMade"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "soPmtAgreed"
        Me.DataGridViewTextBoxColumn19.HeaderText = "soPmtAgreed"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "soUnPmt"
        Me.DataGridViewTextBoxColumn20.HeaderText = "soUnPmt"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "soPriRte"
        Me.DataGridViewTextBoxColumn21.HeaderText = "soPriRte"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "soSecRte"
        Me.DataGridViewTextBoxColumn22.HeaderText = "soSecRte"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "soPnotes"
        Me.DataGridViewTextBoxColumn23.HeaderText = "soPnotes"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "soANotes"
        Me.DataGridViewTextBoxColumn24.HeaderText = "soANotes"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "soMNotes"
        Me.DataGridViewTextBoxColumn25.HeaderText = "soMNotes"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.BackColor = System.Drawing.Color.Red
        Me.lblTest.ForeColor = System.Drawing.Color.Yellow
        Me.lblTest.Location = New System.Drawing.Point(186, 158)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Padding = New System.Windows.Forms.Padding(5)
        Me.lblTest.Size = New System.Drawing.Size(81, 23)
        Me.lblTest.TabIndex = 48
        Me.lblTest.Text = "Testing Label"
        '
        'cbDHPrinted
        '
        Me.cbDHPrinted.AutoSize = True
        Me.cbDHPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdHang", True))
        Me.cbDHPrinted.Location = New System.Drawing.Point(12, 157)
        Me.cbDHPrinted.Name = "cbDHPrinted"
        Me.cbDHPrinted.Size = New System.Drawing.Size(168, 17)
        Me.cbDHPrinted.TabIndex = 49
        Me.cbDHPrinted.Text = "Door Hanger Selected to Print"
        Me.cbDHPrinted.UseVisualStyleBackColor = True
        '
        'cbTermPrinted
        '
        Me.cbTermPrinted.AutoSize = True
        Me.cbTermPrinted.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TblWorkingDataBindingSource, "wdTerm", True))
        Me.cbTermPrinted.Location = New System.Drawing.Point(12, 183)
        Me.cbTermPrinted.Name = "cbTermPrinted"
        Me.cbTermPrinted.Size = New System.Drawing.Size(162, 17)
        Me.cbTermPrinted.TabIndex = 50
        Me.cbTermPrinted.Text = "Termination Selected to Print"
        Me.cbTermPrinted.UseVisualStyleBackColor = True
        '
        'dtpHangDte
        '
        Me.dtpHangDte.Location = New System.Drawing.Point(324, 112)
        Me.dtpHangDte.Name = "dtpHangDte"
        Me.dtpHangDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpHangDte.TabIndex = 52
        '
        'dtpCntDte
        '
        Me.dtpCntDte.Location = New System.Drawing.Point(324, 163)
        Me.dtpCntDte.Name = "dtpCntDte"
        Me.dtpCntDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpCntDte.TabIndex = 53
        '
        'dtpTermDte
        '
        Me.dtpTermDte.Location = New System.Drawing.Point(324, 218)
        Me.dtpTermDte.Name = "dtpTermDte"
        Me.dtpTermDte.Size = New System.Drawing.Size(200, 20)
        Me.dtpTermDte.TabIndex = 54
        '
        'TblWorkingDataDataGridView1
        '
        Me.TblWorkingDataDataGridView1.AutoGenerateColumns = False
        Me.TblWorkingDataDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblWorkingDataDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn42, Me.DataGridViewTextBoxColumn43, Me.DataGridViewTextBoxColumn44, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn45, Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn47, Me.DataGridViewTextBoxColumn48, Me.DataGridViewTextBoxColumn49, Me.DataGridViewTextBoxColumn50, Me.DataGridViewTextBoxColumn51, Me.DataGridViewTextBoxColumn52, Me.DataGridViewTextBoxColumn53, Me.DataGridViewTextBoxColumn54})
        Me.TblWorkingDataDataGridView1.DataSource = Me.TblWorkingDataBindingSource
        Me.TblWorkingDataDataGridView1.Location = New System.Drawing.Point(15, 424)
        Me.TblWorkingDataDataGridView1.Name = "TblWorkingDataDataGridView1"
        Me.TblWorkingDataDataGridView1.Size = New System.Drawing.Size(352, 230)
        Me.TblWorkingDataDataGridView1.TabIndex = 54
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "wdAccount"
        Me.DataGridViewTextBoxColumn26.HeaderText = "wdAccount"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "wdAge0"
        Me.DataGridViewTextBoxColumn27.HeaderText = "wdAge0"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "wdAge1"
        Me.DataGridViewTextBoxColumn28.HeaderText = "wdAge1"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "wdAge2"
        Me.DataGridViewTextBoxColumn29.HeaderText = "wdAge2"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "wdAge3"
        Me.DataGridViewTextBoxColumn30.HeaderText = "wdAge3"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "wdAge4"
        Me.DataGridViewTextBoxColumn31.HeaderText = "wdAge4"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "wdAge5"
        Me.DataGridViewTextBoxColumn32.HeaderText = "wdAge5"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "wdBal"
        Me.DataGridViewTextBoxColumn33.HeaderText = "wdBal"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "wdName"
        Me.DataGridViewTextBoxColumn34.HeaderText = "wdName"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "wdAddr"
        Me.DataGridViewTextBoxColumn35.HeaderText = "wdAddr"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "wdLoc"
        Me.DataGridViewTextBoxColumn36.HeaderText = "wdLoc"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "wdCycle"
        Me.DataGridViewTextBoxColumn37.HeaderText = "wdCycle"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "wdLstPayDte"
        Me.DataGridViewTextBoxColumn38.HeaderText = "wdLstPayDte"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "wdLstPayAmt"
        Me.DataGridViewTextBoxColumn39.HeaderText = "wdLstPayAmt"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "wdStCde"
        Me.DataGridViewTextBoxColumn40.HeaderText = "wdStCde"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "wdStDesc"
        Me.DataGridViewTextBoxColumn41.HeaderText = "wdStDesc"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "wdPnotes"
        Me.DataGridViewTextBoxColumn42.HeaderText = "wdPnotes"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "wdANotes"
        Me.DataGridViewTextBoxColumn43.HeaderText = "wdANotes"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "wdMNotes"
        Me.DataGridViewTextBoxColumn44.HeaderText = "wdMNotes"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "wdTerm"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "wdTerm"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "wdHang"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "wdHang"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "wdHangDte"
        Me.DataGridViewTextBoxColumn45.HeaderText = "wdHangDte"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "wdCntDte"
        Me.DataGridViewTextBoxColumn46.HeaderText = "wdCntDte"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "wdTermDte"
        Me.DataGridViewTextBoxColumn47.HeaderText = "wdTermDte"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.DataPropertyName = "wdAgreeDue"
        Me.DataGridViewTextBoxColumn48.HeaderText = "wdAgreeDue"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.DataPropertyName = "wdPmtAgreed"
        Me.DataGridViewTextBoxColumn49.HeaderText = "wdPmtAgreed"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.DataPropertyName = "wdUnPmt"
        Me.DataGridViewTextBoxColumn50.HeaderText = "wdUnPmt"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.DataPropertyName = "wdPriRte"
        Me.DataGridViewTextBoxColumn51.HeaderText = "wdPriRte"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "wdSecRte"
        Me.DataGridViewTextBoxColumn52.HeaderText = "wdSecRte"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "wdStCdeDte"
        Me.DataGridViewTextBoxColumn53.HeaderText = "wdStCdeDte"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "wdAgreeMade"
        Me.DataGridViewTextBoxColumn54.HeaderText = "wdAgreeMade"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        '
        'lblUserNotification
        '
        Me.lblUserNotification.AutoSize = True
        Me.lblUserNotification.Location = New System.Drawing.Point(294, 74)
        Me.lblUserNotification.Name = "lblUserNotification"
        Me.lblUserNotification.Size = New System.Drawing.Size(85, 13)
        Me.lblUserNotification.TabIndex = 55
        Me.lblUserNotification.Text = "User Notification"
        '
        'TblCodesDataGridView
        '
        Me.TblCodesDataGridView.AutoGenerateColumns = False
        Me.TblCodesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblCodesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn55, Me.DataGridViewTextBoxColumn56})
        Me.TblCodesDataGridView.DataSource = Me.TblCodesBindingSource
        Me.TblCodesDataGridView.Location = New System.Drawing.Point(12, 660)
        Me.TblCodesDataGridView.Name = "TblCodesDataGridView"
        Me.TblCodesDataGridView.Size = New System.Drawing.Size(355, 188)
        Me.TblCodesDataGridView.TabIndex = 55
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "CodeValue"
        Me.DataGridViewTextBoxColumn55.HeaderText = "CodeValue"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.DataPropertyName = "CodeDescription"
        Me.DataGridViewTextBoxColumn56.HeaderText = "CodeDescription"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        '
        'TblCodesBindingSource
        '
        Me.TblCodesBindingSource.DataMember = "tblCodes"
        Me.TblCodesBindingSource.DataSource = Me.DhA_sampleDataSet1
        '
        'TblDateLogDataGridView
        '
        Me.TblDateLogDataGridView.AutoGenerateColumns = False
        Me.TblDateLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblDateLogDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn57, Me.DataGridViewTextBoxColumn58, Me.DataGridViewTextBoxColumn59, Me.DataGridViewTextBoxColumn60, Me.DataGridViewTextBoxColumn61, Me.DataGridViewTextBoxColumn62})
        Me.TblDateLogDataGridView.DataSource = Me.TblDateLogBindingSource
        Me.TblDateLogDataGridView.Location = New System.Drawing.Point(399, 660)
        Me.TblDateLogDataGridView.Name = "TblDateLogDataGridView"
        Me.TblDateLogDataGridView.Size = New System.Drawing.Size(373, 198)
        Me.TblDateLogDataGridView.TabIndex = 55
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.DataPropertyName = "dlPkey"
        Me.DataGridViewTextBoxColumn57.HeaderText = "dlPkey"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        '
        'DataGridViewTextBoxColumn58
        '
        Me.DataGridViewTextBoxColumn58.DataPropertyName = "dlNew"
        Me.DataGridViewTextBoxColumn58.HeaderText = "dlNew"
        Me.DataGridViewTextBoxColumn58.Name = "DataGridViewTextBoxColumn58"
        '
        'DataGridViewTextBoxColumn59
        '
        Me.DataGridViewTextBoxColumn59.DataPropertyName = "dlUpdate"
        Me.DataGridViewTextBoxColumn59.HeaderText = "dlUpdate"
        Me.DataGridViewTextBoxColumn59.Name = "DataGridViewTextBoxColumn59"
        '
        'DataGridViewTextBoxColumn60
        '
        Me.DataGridViewTextBoxColumn60.DataPropertyName = "dlDH"
        Me.DataGridViewTextBoxColumn60.HeaderText = "dlDH"
        Me.DataGridViewTextBoxColumn60.Name = "DataGridViewTextBoxColumn60"
        '
        'DataGridViewTextBoxColumn61
        '
        Me.DataGridViewTextBoxColumn61.DataPropertyName = "dlTerm"
        Me.DataGridViewTextBoxColumn61.HeaderText = "dlTerm"
        Me.DataGridViewTextBoxColumn61.Name = "DataGridViewTextBoxColumn61"
        '
        'DataGridViewTextBoxColumn62
        '
        Me.DataGridViewTextBoxColumn62.DataPropertyName = "dlCSweep"
        Me.DataGridViewTextBoxColumn62.HeaderText = "dlCSweep"
        Me.DataGridViewTextBoxColumn62.Name = "DataGridViewTextBoxColumn62"
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
        Me.TableAdapterManager.tblShutOffTableAdapter = Me.TblShutOffTableAdapter
        Me.TableAdapterManager.tblWorkingDataTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        'TblWorkingDataBindingNavigator
        '
        Me.TblWorkingDataBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem1
        Me.TblWorkingDataBindingNavigator.BindingSource = Me.TblWorkingDataBindingSource
        Me.TblWorkingDataBindingNavigator.CountItem = Me.BindingNavigatorCountItem1
        Me.TblWorkingDataBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TblWorkingDataBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.TblWorkingDataBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem1, Me.BindingNavigatorMovePreviousItem1, Me.BindingNavigatorSeparator3, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.BindingNavigatorSeparator4, Me.BindingNavigatorMoveNextItem1, Me.BindingNavigatorMoveLastItem1, Me.BindingNavigatorSeparator5, Me.BindingNavigatorAddNewItem1, Me.BindingNavigatorDeleteItem})
        Me.TblWorkingDataBindingNavigator.Location = New System.Drawing.Point(247, 24)
        Me.TblWorkingDataBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem1
        Me.TblWorkingDataBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem1
        Me.TblWorkingDataBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem1
        Me.TblWorkingDataBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem1
        Me.TblWorkingDataBindingNavigator.Name = "TblWorkingDataBindingNavigator"
        Me.TblWorkingDataBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem1
        Me.TblWorkingDataBindingNavigator.Size = New System.Drawing.Size(255, 25)
        Me.TblWorkingDataBindingNavigator.TabIndex = 56
        Me.TblWorkingDataBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem1
        '
        Me.BindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem1.Image = CType(resources.GetObject("BindingNavigatorAddNewItem1.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem1.Name = "BindingNavigatorAddNewItem1"
        Me.BindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem1.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem1.Text = "Add new"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(862, 741)
        Me.Controls.Add(Me.TblWorkingDataBindingNavigator)
        Me.Controls.Add(Me.TblDateLogDataGridView)
        Me.Controls.Add(Me.TblCodesDataGridView)
        Me.Controls.Add(Me.lblUserNotification)
        Me.Controls.Add(Me.TblWorkingDataDataGridView1)
        Me.Controls.Add(Me.dtpTermDte)
        Me.Controls.Add(Me.dtpCntDte)
        Me.Controls.Add(Me.dtpHangDte)
        Me.Controls.Add(Me.cbTermPrinted)
        Me.Controls.Add(Me.cbDHPrinted)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.TblShutOffDataGridView)
        Me.Controls.Add(Me.TblShutOffBindingNavigator)
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
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Door Hanger Application by 3Waters"
        CType(Me.TblWorkingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DhA_sampleDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblShutOffBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCycle.ResumeLayout(False)
        Me.grpCycle.PerformLayout()
        Me.grpNotice.ResumeLayout(False)
        Me.grpNotice.PerformLayout()
        CType(Me.TblDateLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TblShutOffBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblShutOffBindingNavigator.ResumeLayout(False)
        Me.TblShutOffBindingNavigator.PerformLayout()
        CType(Me.TblShutOffDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblWorkingDataDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblCodesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDateLogDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblWorkingDataBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblWorkingDataBindingNavigator.ResumeLayout(False)
        Me.TblWorkingDataBindingNavigator.PerformLayout()
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
    Friend WithEvents DhA_sampleDataSet1 As FCLWD_DoorHangerApp.DHA_sampleDataSet
    Friend WithEvents TblShutOffBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblShutOffTableAdapter As FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblShutOffTableAdapter
    Friend WithEvents TableAdapterManager As FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TblShutOffBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TblShutOffDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents cbDHPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents cbTermPrinted As System.Windows.Forms.CheckBox
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportedDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpHangDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCntDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTermDte As System.Windows.Forms.DateTimePicker
    Friend WithEvents TblWorkingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblWorkingDataTableAdapter As FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblWorkingDataTableAdapter
    Friend WithEvents TblWorkingDataDataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn49 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn50 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn54 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblUserNotification As System.Windows.Forms.Label
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TblCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblCodesTableAdapter As FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter
    Friend WithEvents TblCodesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn56 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TblDateLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblDateLogTableAdapter As FCLWD_DoorHangerApp.DHA_sampleDataSetTableAdapters.tblDateLogTableAdapter
    Friend WithEvents TblDateLogDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn57 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn58 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn59 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn61 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn62 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TblWorkingDataBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
