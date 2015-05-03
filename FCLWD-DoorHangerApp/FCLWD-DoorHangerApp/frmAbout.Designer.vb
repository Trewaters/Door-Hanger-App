<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblComp = New System.Windows.Forms.Label()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.lblCopy = New System.Windows.Forms.Label()
        Me.lblTrade = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblFileV = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtProd = New System.Windows.Forms.TextBox()
        Me.txtComp = New System.Windows.Forms.TextBox()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(73, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(131, 19)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Application Title"
        '
        'lblComp
        '
        Me.lblComp.AutoSize = True
        Me.lblComp.Location = New System.Drawing.Point(19, 101)
        Me.lblComp.Name = "lblComp"
        Me.lblComp.Size = New System.Drawing.Size(54, 13)
        Me.lblComp.TabIndex = 1
        Me.lblComp.Text = "Company:"
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(26, 69)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(47, 13)
        Me.lblProduct.TabIndex = 2
        Me.lblProduct.Text = "Product:"
        '
        'lblCopy
        '
        Me.lblCopy.AutoSize = True
        Me.lblCopy.Location = New System.Drawing.Point(194, 239)
        Me.lblCopy.Name = "lblCopy"
        Me.lblCopy.Size = New System.Drawing.Size(106, 13)
        Me.lblCopy.TabIndex = 3
        Me.lblCopy.Text = "Application Copyright"
        '
        'lblTrade
        '
        Me.lblTrade.AutoSize = True
        Me.lblTrade.Location = New System.Drawing.Point(12, 239)
        Me.lblTrade.Name = "lblTrade"
        Me.lblTrade.Size = New System.Drawing.Size(113, 13)
        Me.lblTrade.TabIndex = 4
        Me.lblTrade.Text = "Application Trademark"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(10, 165)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(63, 13)
        Me.lblDesc.TabIndex = 5
        Me.lblDesc.Text = "Description:"
        '
        'lblFileV
        '
        Me.lblFileV.AutoSize = True
        Me.lblFileV.Location = New System.Drawing.Point(9, 133)
        Me.lblFileV.Name = "lblFileV"
        Me.lblFileV.Size = New System.Drawing.Size(64, 13)
        Me.lblFileV.TabIndex = 6
        Me.lblFileV.Text = "File Version:"
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesc.Enabled = False
        Me.txtDesc.Location = New System.Drawing.Point(15, 182)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(285, 45)
        Me.txtDesc.TabIndex = 7
        '
        'txtProd
        '
        Me.txtProd.BackColor = System.Drawing.SystemColors.Control
        Me.txtProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProd.Location = New System.Drawing.Point(76, 69)
        Me.txtProd.Name = "txtProd"
        Me.txtProd.ReadOnly = True
        Me.txtProd.Size = New System.Drawing.Size(179, 13)
        Me.txtProd.TabIndex = 8
        '
        'txtComp
        '
        Me.txtComp.BackColor = System.Drawing.SystemColors.Control
        Me.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtComp.Location = New System.Drawing.Point(76, 101)
        Me.txtComp.Name = "txtComp"
        Me.txtComp.ReadOnly = True
        Me.txtComp.Size = New System.Drawing.Size(179, 13)
        Me.txtComp.TabIndex = 9
        '
        'txtFile
        '
        Me.txtFile.BackColor = System.Drawing.SystemColors.Control
        Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFile.Location = New System.Drawing.Point(76, 133)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(179, 13)
        Me.txtFile.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.ErrorImage = Global.DoorHangerApp.My.Resources.Resources._3W_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(5, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 48)
        Me.PictureBox1.TabIndex = 71
        Me.PictureBox1.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 261)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.txtComp)
        Me.Controls.Add(Me.txtProd)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.lblFileV)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.lblTrade)
        Me.Controls.Add(Me.lblCopy)
        Me.Controls.Add(Me.lblProduct)
        Me.Controls.Add(Me.lblComp)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Text = "About"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblComp As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblCopy As System.Windows.Forms.Label
    Friend WithEvents lblTrade As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents lblFileV As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtProd As System.Windows.Forms.TextBox
    Friend WithEvents txtComp As System.Windows.Forms.TextBox
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
