<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OPCompany
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OPCompany))
        Me.CBcompname = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butopencomp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CBcompname
        '
        Me.CBcompname.FormattingEnabled = True
        Me.CBcompname.Location = New System.Drawing.Point(113, 30)
        Me.CBcompname.Name = "CBcompname"
        Me.CBcompname.Size = New System.Drawing.Size(506, 21)
        Me.CBcompname.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Unicode MS", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Company Name"
        '
        'butopencomp
        '
        Me.butopencomp.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butopencomp.Location = New System.Drawing.Point(294, 75)
        Me.butopencomp.Name = "butopencomp"
        Me.butopencomp.Size = New System.Drawing.Size(89, 36)
        Me.butopencomp.TabIndex = 4
        Me.butopencomp.Text = "OK"
        Me.butopencomp.UseVisualStyleBackColor = True
        '
        'OPCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 125)
        Me.Controls.Add(Me.butopencomp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBcompname)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OPCompany"
        Me.Text = "Open Company"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBcompname As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butopencomp As System.Windows.Forms.Button
End Class
