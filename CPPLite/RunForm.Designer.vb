<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RunForm))
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.PrintTextBox = New System.Windows.Forms.TextBox()
        Me.ButtonsPanel = New System.Windows.Forms.Panel()
        Me.RunButton = New System.Windows.Forms.Button()
        Me.ErrorListBox = New System.Windows.Forms.ListView()
        Me.LineIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorMessage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CodeTextBox
        '
        Me.CodeTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CodeTextBox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CodeTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.CodeTextBox.Location = New System.Drawing.Point(0, 0)
        Me.CodeTextBox.Multiline = True
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CodeTextBox.Size = New System.Drawing.Size(323, 360)
        Me.CodeTextBox.TabIndex = 0
        Me.CodeTextBox.Text = resources.GetString("CodeTextBox.Text")
        '
        'PrintTextBox
        '
        Me.PrintTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.PrintTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PrintTextBox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PrintTextBox.Location = New System.Drawing.Point(364, 0)
        Me.PrintTextBox.Multiline = True
        Me.PrintTextBox.Name = "PrintTextBox"
        Me.PrintTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.PrintTextBox.Size = New System.Drawing.Size(366, 360)
        Me.PrintTextBox.TabIndex = 1
        '
        'ButtonsPanel
        '
        Me.ButtonsPanel.Controls.Add(Me.RunButton)
        Me.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonsPanel.Location = New System.Drawing.Point(0, 396)
        Me.ButtonsPanel.Name = "ButtonsPanel"
        Me.ButtonsPanel.Size = New System.Drawing.Size(730, 42)
        Me.ButtonsPanel.TabIndex = 2
        '
        'RunButton
        '
        Me.RunButton.Location = New System.Drawing.Point(12, 5)
        Me.RunButton.Name = "RunButton"
        Me.RunButton.Size = New System.Drawing.Size(80, 32)
        Me.RunButton.TabIndex = 0
        Me.RunButton.Text = "&Run !"
        Me.RunButton.UseVisualStyleBackColor = True
        '
        'ErrorListBox
        '
        Me.ErrorListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ErrorListBox.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LineIndex, Me.ErrorMessage})
        Me.ErrorListBox.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ErrorListBox.FullRowSelect = True
        Me.ErrorListBox.GridLines = True
        Me.ErrorListBox.Location = New System.Drawing.Point(379, 12)
        Me.ErrorListBox.MultiSelect = False
        Me.ErrorListBox.Name = "ErrorListBox"
        Me.ErrorListBox.Size = New System.Drawing.Size(304, 237)
        Me.ErrorListBox.TabIndex = 3
        Me.ErrorListBox.UseCompatibleStateImageBehavior = False
        Me.ErrorListBox.View = System.Windows.Forms.View.Details
        Me.ErrorListBox.Visible = False
        '
        'LineIndex
        '
        Me.LineIndex.Text = "错误行号"
        Me.LineIndex.Width = 80
        '
        'ErrorMessage
        '
        Me.ErrorMessage.Text = "错误信息"
        Me.ErrorMessage.Width = 500
        '
        'RunForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 438)
        Me.Controls.Add(Me.ButtonsPanel)
        Me.Controls.Add(Me.ErrorListBox)
        Me.Controls.Add(Me.PrintTextBox)
        Me.Controls.Add(Me.CodeTextBox)
        Me.DoubleBuffered = True
        Me.Name = "RunForm"
        Me.Text = "C++ Lite"
        Me.ButtonsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CodeTextBox As TextBox
    Friend WithEvents PrintTextBox As TextBox
    Friend WithEvents ButtonsPanel As Panel
    Friend WithEvents RunButton As Button
    Friend WithEvents ErrorListBox As ListView
    Friend WithEvents LineIndex As ColumnHeader
    Friend WithEvents ErrorMessage As ColumnHeader
End Class
