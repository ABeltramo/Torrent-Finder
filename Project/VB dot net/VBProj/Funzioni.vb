Imports System.Net
Imports System.IO
Imports System.Threading.Thread
Imports System.ComponentModel
Imports HtmlAgilityPack 'DLL per il parsing dell'html

Module Funzioni
    Public DesTor(300) As String 'Vettore che contiene le descrizioni di tutti i torrent trovati
    Public TorrentCode As String 'Url del file torrent che si sta visualizzando
    Public NTor As Integer = 1 'Il numero di torrent che si sta visualizzando
    Public NTorTot As Integer = 0 'Il numero totale di torrent trovati

    Private Doc As HtmlDocument = New HtmlDocument 'Html parser

    Public Function getHtml(ByVal url As String) As String
        Dim myWebRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
        Dim myWebSource As New StreamReader(myWebResponse.GetResponseStream())
        Dim myPageSource As String
        myPageSource = myWebSource.ReadToEnd()
        myWebResponse.Close()
        Return myPageSource
    End Function

    Public Function RicTorrent(ByVal KeySrc As String)
        NTorTot = 1
        Doc.LoadHtml(getHtml("http://www.kat.ph/search/" + KeySrc + "/"))
        Dim Cont As HtmlNodeCollection = Doc.DocumentNode.SelectNodes("//*[@class='torType filmType']")
        Dim node As HtmlNode
        For Each node In Cont
            DesTor(NTorTot) = "http://www.kat.ph" + node.GetAttributeValue("href", "-1")
            NTorTot += 1
        Next
    End Function

    Public Function FindDesc(ByVal url As String) As String
        Doc.LoadHtml(getHtml(url))
        Dim Cont As HtmlNodeCollection = Doc.DocumentNode.SelectNodes("//*[@class='siteButton giantButton verifTorrentButton']")
        Dim node As HtmlNode
        For Each node In Cont
            TorrentCode = node.GetAttributeValue("href", "-1")
            Exit For
        Next
        Cont = Doc.DocumentNode.SelectNodes("//*[@class='textcontent']")
        For Each node In Cont
            Return node.InnerHtml
        Next
    End Function

    Public Function Loading()
        Form1.Cursor = Cursors.WaitCursor
        Form1.Tab.Cursor = Cursors.WaitCursor
        Form1.BtnPre.Enabled = False
        Form1.BtnDow.Enabled = False
        Form1.BtnRic.Enabled = False
        Form1.BtnSuc.Enabled = False
    End Function

    Public Function Stop_Loading()
        Form1.Cursor = Cursors.Default
        Form1.Tab.Cursor = Cursors.Default
        Form1.BtnPre.Enabled = True
        Form1.BtnDow.Enabled = True
        Form1.BtnRic.Enabled = True
        Form1.BtnSuc.Enabled = True
    End Function


End Module
