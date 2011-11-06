Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FB1.ShowDialog()
        TxtDownload.Text = FB1.SelectedPath
    End Sub

    Private Sub BtnAnn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnn.Click
        Me.Hide()
        LeggiImpostazioni(Application.StartupPath + "\User.dat", "#!")
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Using outfile As New StreamWriter(Application.StartupPath + "\User.dat")
            outfile.Write("#!Cartella dove verrà scaricato il file")
            outfile.WriteLine()
            outfile.Write(TxtDownload.Name + "=" + TxtDownload.Text)
            outfile.WriteLine()
            outfile.Write("#!Aggiornamenti automatici")
            outfile.WriteLine()
            outfile.Write(CheckAgg.Name + "=" + CheckAgg.Checked.ToString)
        End Using
        Me.Hide()
    End Sub

    Public Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LeggiImpostazioni(Application.StartupPath + "\User.dat", "#!")
        If CheckAgg.Checked = True Then
            Using outfile As New StreamWriter(Application.StartupPath + "\IDProc.dat")
                outfile.WriteLine(Process.GetCurrentProcess().ProcessName)
            End Using
            'Controllo se sono presenti aggiornamenti
        End If
    End Sub

    Private Function LeggiImpostazioni(ByRef Path As String, ByRef Comment As String)
        Dim Riga As String
        Dim Imp(2) As String
        If File.Exists(Path) = True Then
            Using inputFile As New StreamReader(Path)
                While inputFile.EndOfStream = False
                    Riga = inputFile.ReadLine
                    If Riga.Contains(Comment) = False Then
                        Imp = Riga.Split("=")
                        If (Imp(0).ToLower.Contains("txt".ToLower)) Then
                            GetControlByName(Imp(0)).Text = Imp(1)
                        ElseIf (Imp(0).ToLower.Contains("check".ToLower)) Then
                            GetCheckBoxByName(Imp(0)).Checked = Imp(1)
                        End If
                    End If
                End While
            End Using
        Else
            Me.ShowDialog()
        End If
    End Function

    Private Function GetControlByName(ByVal name As String) As Control
        For Each value As Control In Me.Controls
            If value.Name.ToUpper = name.ToUpper Then
                Return value
            End If
        Next
        Return Nothing
    End Function

    Private Function GetCheckBoxByName(ByVal name As String) As CheckBox
        For Each value As CheckBox In Me.Controls
            If value.Name.ToUpper = name.ToUpper Then
                Return value
            End If
        Next
        Return Nothing
    End Function
End Class