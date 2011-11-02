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
        If (NTor > 2) Then
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
        Dim s As New StreamWriter("/Prova.torrent")
        'DECOMPRIMERE GZIP LA STRING RESTITUITA e salvarla su file .torrent
        s.WriteLine(getHtml(TorrentCode))
        s.Close()
        MsgBox("Il download è stato avviato correttamente")
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

    '***
    'BACKGROUND WORKER
    '***

    Private Sub BWDes_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWDes.DoWork
        RicTorrent(Me.TxtRic.Text)
    End Sub

    Private Sub BWDes_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BWDes.RunWorkerCompleted
        Me.BWFindDesc.RunWorkerAsync()
    End Sub

    Private RisRicDes As String

    Private Sub BWFindDesc_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWFindDesc.DoWork
        RisRicDes = FindDesc(DesTor(NTor))
    End Sub

    Private Sub BWFindDesc_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BWFindDesc.RunWorkerCompleted
        Me.TxtDes.DocumentText = RisRicDes
        Stop_Loading()
    End Sub
End Class