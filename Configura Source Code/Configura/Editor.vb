Imports System.IO
Public Class Editor
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
    Private Sub NewToolStrip_click(sender As Object, e As EventArgs) Handles NewToolStrip.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub OpenToolStrip_click(sender As Object, e As EventArgs) Handles OpenToolStrip.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then 'Wenn auf OK geklickt wird, dann soll ausgeführt werden
            Dim reader As New StreamReader(OpenFileDialog1.FileName) ' Neuer Streamreader
            Dim dateiinhalt As String = reader.ReadToEnd
            reader.Close()
            Me.Text = "Editing: " & OpenFileDialog1.FileName & "" ' Text wird verändert
            RichTextBox1.Clear() ' Die RichTextBox1 soll geleert werden
            RichTextBox1.Text = dateiinhalt ' RichtextBox1.Text = Der geöffnete Text
        End If
    End Sub
    Private Sub SaveAsToolStrip_click(sender As Object, e As EventArgs) Handles SaveAsToolStrip.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SaveFileDialog1.Title = "Save As..."
            Dim writer As New StreamWriter(SaveFileDialog1.FileName)
            If Not (writer Is Nothing) Then
                writer.Write(RichTextBox1.Text)
                writer.Close()
            End If
            Me.Text = "Editing: " & SaveFileDialog1.FileName & ""
        End If
    End Sub
    Private Sub FontToolStrip_click(sender As Object, e As EventArgs) Handles FontStripMenu.Click
        FontDialog1.ShowDialog()
        RichTextBox1.SelectionFont = FontDialog1.Font ' Ausgewählte Schriftart mit Schriftgröße, Schrifteffekt und Schriftschnitt eird gesetzt
        RichTextBox1.SelectionColor = FontDialog1.Color
    End Sub
    Private Sub SaveToolStrip_click(sender As Object, e As EventArgs) Handles SaveToolStrip.Click

    End Sub
    Private Sub InfoToolStrip_click(sender As Object, e As EventArgs) Handles InfoStripMenu.Click
        About.Show()
    End Sub
    Private Sub ExitToolStrip_click(sender As Object, e As EventArgs) Handles ExitToolStrip.Click
        Me.Close()
        Close()
    End Sub
    Private Sub Undo_click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem2.Click
        RichTextBox1.Undo()
    End Sub
    Private Sub Redo_click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem2.Click
        RichTextBox1.Redo()
    End Sub
    Private Sub Copy_click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem2.Click
        If Not RichTextBox1.SelectedText = Nothing Then
            My.Computer.Clipboard.SetText(RichTextBox1.SelectedText)
        End If
    End Sub
    Private Sub Paste_click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem2.Click
        RichTextBox1.SelectedText = My.Computer.Clipboard.GetText
    End Sub
    Private Sub SelectAll_click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem2.Click
        RichTextBox1.SelectAll()
    End Sub
End Class