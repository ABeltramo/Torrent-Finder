﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.BtnPre = New System.Windows.Forms.Button()
        Me.BtnSuc = New System.Windows.Forms.Button()
        Me.BtnDow = New System.Windows.Forms.Button()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.TxtRic = New System.Windows.Forms.TextBox()
        Me.BtnRic = New System.Windows.Forms.Button()
        Me.BWDes = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EsciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BWFindDesc = New System.ComponentModel.BackgroundWorker()
        Me.TxtDes = New System.Windows.Forms.WebBrowser()
        Me.Tab.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab
        '
        Me.Tab.Controls.Add(Me.Tab1)
        Me.Tab.Controls.Add(Me.Tab2)
        Me.Tab.Location = New System.Drawing.Point(4, 59)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(691, 583)
        Me.Tab.TabIndex = 0
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.TxtDes)
        Me.Tab1.Controls.Add(Me.BtnPre)
        Me.Tab1.Controls.Add(Me.BtnSuc)
        Me.Tab1.Controls.Add(Me.BtnDow)
        Me.Tab1.Location = New System.Drawing.Point(4, 25)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(683, 554)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Descrizione"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'BtnPre
        '
        Me.BtnPre.Location = New System.Drawing.Point(90, 4)
        Me.BtnPre.Name = "BtnPre"
        Me.BtnPre.Size = New System.Drawing.Size(144, 34)
        Me.BtnPre.TabIndex = 3
        Me.BtnPre.Text = "Precedente"
        Me.BtnPre.UseVisualStyleBackColor = True
        '
        'BtnSuc
        '
        Me.BtnSuc.Location = New System.Drawing.Point(430, 4)
        Me.BtnSuc.Name = "BtnSuc"
        Me.BtnSuc.Size = New System.Drawing.Size(144, 34)
        Me.BtnSuc.TabIndex = 2
        Me.BtnSuc.Text = "Successivo"
        Me.BtnSuc.UseVisualStyleBackColor = True
        '
        'BtnDow
        '
        Me.BtnDow.Location = New System.Drawing.Point(260, 4)
        Me.BtnDow.Name = "BtnDow"
        Me.BtnDow.Size = New System.Drawing.Size(144, 34)
        Me.BtnDow.TabIndex = 1
        Me.BtnDow.Text = "Download"
        Me.BtnDow.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.Location = New System.Drawing.Point(4, 25)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(683, 359)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Download"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'TxtRic
        '
        Me.TxtRic.Location = New System.Drawing.Point(426, 30)
        Me.TxtRic.Multiline = True
        Me.TxtRic.Name = "TxtRic"
        Me.TxtRic.Size = New System.Drawing.Size(188, 30)
        Me.TxtRic.TabIndex = 1
        Me.TxtRic.Text = "prova"
        '
        'BtnRic
        '
        Me.BtnRic.Location = New System.Drawing.Point(620, 30)
        Me.BtnRic.Name = "BtnRic"
        Me.BtnRic.Size = New System.Drawing.Size(77, 30)
        Me.BtnRic.TabIndex = 2
        Me.BtnRic.Text = "Ricerca"
        Me.BtnRic.UseVisualStyleBackColor = True
        '
        'BWDes
        '
        Me.BWDes.WorkerReportsProgress = True
        Me.BWDes.WorkerSupportsCancellation = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(697, 28)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EsciToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EsciToolStripMenuItem
        '
        Me.EsciToolStripMenuItem.Name = "EsciToolStripMenuItem"
        Me.EsciToolStripMenuItem.Size = New System.Drawing.Size(103, 24)
        Me.EsciToolStripMenuItem.Text = "Esci"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(28, 24)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(119, 24)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'BWFindDesc
        '
        Me.BWFindDesc.WorkerReportsProgress = True
        Me.BWFindDesc.WorkerSupportsCancellation = True
        '
        'TxtDes
        '
        Me.TxtDes.Location = New System.Drawing.Point(0, 41)
        Me.TxtDes.MinimumSize = New System.Drawing.Size(20, 20)
        Me.TxtDes.Name = "TxtDes"
        Me.TxtDes.Size = New System.Drawing.Size(680, 507)
        Me.TxtDes.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 646)
        Me.Controls.Add(Me.BtnRic)
        Me.Controls.Add(Me.TxtRic)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Tab.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtRic As System.Windows.Forms.TextBox
    Friend WithEvents BtnRic As System.Windows.Forms.Button
    Public WithEvents BWDes As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnPre As System.Windows.Forms.Button
    Friend WithEvents BtnSuc As System.Windows.Forms.Button
    Friend WithEvents BtnDow As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EsciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BWFindDesc As System.ComponentModel.BackgroundWorker
    Friend WithEvents TxtDes As System.Windows.Forms.WebBrowser

End Class
