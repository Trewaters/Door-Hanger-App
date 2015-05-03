<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodes))
        Me.DHA_sampleDataSet = New DoorHangerApp.DHA_sampleDataSet()
        Me.TblCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblCodesTableAdapter = New DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter()
        Me.TableAdapterManager = New DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager()
        Me.TblCodesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TblCodesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        CType(Me.DHA_sampleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblCodesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TblCodesBindingNavigator.SuspendLayout()
        CType(Me.TblCodesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DHA_sampleDataSet
        '
        Me.DHA_sampleDataSet.DataSetName = "DHA_sampleDataSet"
        Me.DHA_sampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblCodesBindingSource
        '
        Me.TblCodesBindingSource.DataMember = "tblCodes"
        Me.TblCodesBindingSource.DataSource = Me.DHA_sampleDataSet
        '
        'TblCodesTableAdapter
        '
        Me.TblCodesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tblCodesTableAdapter = Me.TblCodesTableAdapter
        Me.TableAdapterManager.tblDateLogTableAdapter = Nothing
        Me.TableAdapterManager.tblExcelExportTableAdapter = Nothing
        Me.TableAdapterManager.tblShutOffTableAdapter = Nothing
        Me.TableAdapterManager.tblWorkingDataTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TblCodesBindingNavigator
        '
        Me.TblCodesBindingNavigator.AddNewItem = Nothing
        Me.TblCodesBindingNavigator.BindingSource = Me.TblCodesBindingSource
        Me.TblCodesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.TblCodesBindingNavigator.DeleteItem = Nothing
        Me.TblCodesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.TblCodesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TblCodesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.TblCodesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.TblCodesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.TblCodesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.TblCodesBindingNavigator.Name = "TblCodesBindingNavigator"
        Me.TblCodesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.TblCodesBindingNavigator.Size = New System.Drawing.Size(378, 25)
        Me.TblCodesBindingNavigator.TabIndex = 0
        Me.TblCodesBindingNavigator.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TblCodesDataGridView
        '
        Me.TblCodesDataGridView.AutoGenerateColumns = False
        Me.TblCodesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TblCodesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.TblCodesDataGridView.DataSource = Me.TblCodesBindingSource
        Me.TblCodesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TblCodesDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.TblCodesDataGridView.Name = "TblCodesDataGridView"
        Me.TblCodesDataGridView.Size = New System.Drawing.Size(378, 299)
        Me.TblCodesDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CodeValue"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CodeValue"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CodeDescription"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CodeDescription"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
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
        'frmCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 324)
        Me.Controls.Add(Me.TblCodesDataGridView)
        Me.Controls.Add(Me.TblCodesBindingNavigator)
        Me.Name = "frmCodes"
        Me.Text = "Status Codes"
        CType(Me.DHA_sampleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblCodesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TblCodesBindingNavigator.ResumeLayout(False)
        Me.TblCodesBindingNavigator.PerformLayout()
        CType(Me.TblCodesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DHA_sampleDataSet As DoorHangerApp.DHA_sampleDataSet
    Friend WithEvents TblCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblCodesTableAdapter As DoorHangerApp.DHA_sampleDataSetTableAdapters.tblCodesTableAdapter
    Friend WithEvents TableAdapterManager As DoorHangerApp.DHA_sampleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TblCodesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TblCodesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
