Imports System.Net
Imports System.IO
Imports System.Threading.Thread
Imports System.ComponentModel
Imports System.IO.Compression


Public Class Form1

    Private Sub BtnRic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRic.Click
        Loading()
        Me.BWDes.RunWorkerAsync()
    End Sub

    Private Sub BtnPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPre.Click
        If (NTor > 1) Then
            NTor -= 1
            Loading()
            Me.BWFindDesc.RunWorkerAsync()
        End If
    End Sub

    Private Sub BtnSuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuc.Click
        If (NTor < NTorTot) Then
            NTor += 1
            Loading()
            Me.BWFindDesc.RunWorkerAsync()
        End If
    End Sub

    Private Sub BtnDow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDow.Click
        Dim Downloader As New System.Net.WebClient
        If (Directory.Exists(Application.StartupPath + "\Torrent") = False) Then
            Directory.CreateDirectory(Application.StartupPath + "\Torrent")
        End If
        Downloader.DownloadFile(TorrentCode, Application.StartupPath + "\Torrent\Delete.abc")
        DecompressFile(Application.StartupPath + "\Torrent\Delete.abc", Application.StartupPath + "\Torrent\Tor.torrent")
        System.IO.File.Delete(Application.StartupPath + "\Torrent\Delete.abc")
        Dim p As New Process
        With p.StartInfo
            .FileName = "C:\Program Files (x86)\uTorrent\uTorrent.exe"
            .Arguments = "/directory """ + Form2.TxtDownload.Text + "\"" """ + Application.StartupPath + "\Torrent\Tor.torrent"""
            .CreateNoWindow = True
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        p.Start()
        MsgBox("Download avviato correttamente")
    End Sub

    '***
    'ToolStripMenuItem
    '***

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Applicazione creata da Alessandro Beltramo")
    End Sub

    Private Sub EsciToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsciToolStripMenuItem.Click
        End
    End Sub

    Private Sub PreferenzeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferenzeToolStripMenuItem.Click
        Form2.ShowDialog()
    End Sub

    Private Sub ControlloAggiornamentiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlloAggiornamentiToolStripMenuItem.Click
        Process.Start("updater.exe")
    End Sub

    '***
    'BACKGROUND WORKER
    '***
    Private RisRic As Boolean
    Private Sub BWDes_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWDes.DoWork
        RisRic = RicTorrent(Me.TxtRic.Text)
    End Sub

    Private Sub BWDes_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BWDes.RunWorkerCompleted
        If RisRic = False Then
            Stop_Loading()
            LblRis.Text = "La ricerca non ha prodotto alcun risultato."
        Else
            Me.BWFindDesc.RunWorkerAsync()
        End If
    End Sub

    Private RisRicDes As String

    Private Sub BWFindDesc_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWFindDesc.DoWork
        RisRicDes = FindDesc(DesTor(NTor))
    End Sub

    Private Sub BWFindDesc_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BWFindDesc.RunWorkerCompleted
        Me.TxtDes.DocumentText = RisRicDes
        Stop_Loading()
        LblRis.Text = "Stai visualizzando il download N." + NTor.ToString + "/" + NTorTot.ToString + " trovati"
    End Sub

    Private Sub TxtRic_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRic.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnRic_Click(sender, e)
        End If
    End Sub

    '*******
    'Default value text box
    '*******
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtRic.ForeColor = Color.Gray
        TxtRic.Text = "Ricerca un file"
    End Sub

    Private Sub TxtRic_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRic.GotFocus
        TxtRic.Clear()
        TxtRic.ForeColor = Color.Black
    End Sub

    Private Sub TxtRic_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRic.Leave
        If (TxtRic.Text = "") Then
            TxtRic.Text = "Ricerca un file"
            TxtRic.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Caricare le impostazioni del form2
        If File.Exists(Application.StartupPath + "\User.dat") = True Then
            Form2.Form2_Load(sender, e)
        Else
            Form2.ShowDialog()
        End If
    End Sub
End Class