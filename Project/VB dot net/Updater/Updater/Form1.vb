Imports System.IO
Imports System.Net

Public Class Form1

    Private UrlDownload As String = "http://serverale.sytes.net/TorrentFinder/Update/Version.xml"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath + "\IDProc.dat") = True Then
            Using inputFile As New StreamReader(Application.StartupPath + "\IDProc.dat")
                For Each RunningProcess In Process.GetProcessesByName(inputFile.ReadLine)
                    RunningProcess.Kill()
                Next
            End Using
        End If
        Dim Ris As String = getHtml(UrlDownload)
        Dim MainVer As Integer = Val(Ris(Ris.IndexOf("<release>") + Len("<release>")))
        Dim MinVer As Integer = Val(Ris(Ris.IndexOf("<release>") + Len("<release>") + 2))
        'Controllare se MainVer o MinVer sono minori della versione attualmente installata.
    End Sub

    Public Function getHtml(ByVal url As String) As String
        Dim myWebRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
        Dim myWebSource As New StreamReader(myWebResponse.GetResponseStream())
        Dim myPageSource As String
        myPageSource = myWebSource.ReadToEnd()
        myWebResponse.Close()
        Return myPageSource
    End Function

    Private Sub BtnAnn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("SCEMOOOOO!")
    End Sub
End Class
