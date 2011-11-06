Imports System.Net
Imports System.IO
Imports System.Threading.Thread
Imports System.ComponentModel
Imports HtmlAgilityPack 'DLL per il parsing dell'html
Imports System.IO.Compression

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

    Public Function RicTorrent(ByVal KeySrc As String) As Boolean
        NTorTot = 1
        Doc.LoadHtml(getHtml("http://www.kat.ph/search/" + KeySrc + "/"))
        Dim Cont As HtmlNodeCollection = Doc.DocumentNode.SelectNodes("//*[@class='torType filmType']")
        Dim node As HtmlNode
        If Cont Is Nothing Then
            Return False
        Else
            For Each node In Cont
                DesTor(NTorTot) = "http://www.kat.ph" + node.GetAttributeValue("href", "-1")
                NTorTot += 1
            Next
            Return True
        End If
    End Function

    Public Function FindDesc(ByVal url As String) As String
        Doc.LoadHtml(getHtml(url))
        Dim Cont As HtmlNodeCollection = Doc.DocumentNode.SelectNodes("//*[@class='siteButton giantButton']")
        Dim node As HtmlNode
        If Cont Is Nothing Then
            Return ""
        Else
            For Each node In Cont
                TorrentCode = node.GetAttributeValue("href", "-1")
                Exit For
            Next
            node = Doc.DocumentNode.SelectSingleNode("//*[@class='textcontent']")
            If node Is Nothing Then
                Return ""
            Else
                Return node.InnerHtml
            End If
        End If
    End Function

    Public Function Loading()
        Form1.TxtDes.DocumentText = "" 'Svuoto la descrizione
        Form1.Cursor = Cursors.WaitCursor
        Form1.Tab.Cursor = Cursors.WaitCursor
        Form1.TxtRic.Cursor = Cursors.WaitCursor
        Form1.BtnPre.Enabled = False
        Form1.BtnDow.Enabled = False
        Form1.BtnRic.Enabled = False
        Form1.BtnSuc.Enabled = False
    End Function

    Public Function Stop_Loading()
        Form1.Cursor = Cursors.Default
        Form1.Tab.Cursor = Cursors.Default
        Form1.TxtRic.Cursor = Cursors.IBeam
        Form1.BtnPre.Enabled = True
        Form1.BtnDow.Enabled = True
        Form1.BtnRic.Enabled = True
        Form1.BtnSuc.Enabled = True
    End Function

    Public Sub DecompressFile(ByVal sourceFile As String, ByVal destinationFile As String)

        ' make sure the source file is there
        If File.Exists(sourceFile) = False Then
            Throw New FileNotFoundException
        End If

        ' Create the streams and byte arrays needed
        Dim sourceStream As FileStream = Nothing
        Dim destinationStream As FileStream = Nothing
        Dim decompressedStream As GZipStream = Nothing
        Dim quartetBuffer As Byte() = Nothing

        Try
            ' Read in the compressed source stream
            sourceStream = New FileStream(sourceFile, FileMode.Open)

            ' Create a compression stream pointing to the destiantion stream
            decompressedStream = New GZipStream(sourceStream, CompressionMode.Decompress, True)

            ' Read the footer to determine the length of the destiantion file
            quartetBuffer = New Byte(4) {}
            Dim position As Integer = CType(sourceStream.Length, Integer) - 4
            sourceStream.Position = position
            sourceStream.Read(quartetBuffer, 0, 4)
            sourceStream.Position = 0
            Dim checkLength As Integer = BitConverter.ToInt32(quartetBuffer, 0)

            Dim buffer(checkLength + 100) As Byte
            Dim offset As Integer = 0
            Dim total As Integer = 0

            ' Read the compressed data into the buffer
            While True
                Dim bytesRead As Integer = decompressedStream.Read(buffer, offset, 100)
                If bytesRead = 0 Then
                    Exit While
                End If
                offset += bytesRead
                total += bytesRead
            End While

            ' Now write everything to the destination file
            destinationStream = New FileStream(destinationFile, FileMode.Create)
            destinationStream.Write(buffer, 0, total)

            ' and flush everyhting to clean out the buffer
            destinationStream.Flush()

        Catch ex As ApplicationException
            MessageBox.Show(ex.Message, "An Error occured during compression", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Make sure we allways close all streams
            If Not (sourceStream Is Nothing) Then
                sourceStream.Close()
            End If
            If Not (decompressedStream Is Nothing) Then
                decompressedStream.Close()
            End If
            If Not (destinationStream Is Nothing) Then
                destinationStream.Close()
            End If
        End Try

    End Sub
End Module
