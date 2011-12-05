'Copyright (C) <2011>  <The Private Dev Team>

'    This program is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.

'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.

'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <http://www.gnu.org/licenses/>
Public Class Form1
    Dim showoutput As Boolean = False
    Dim platform As String = ""
    Dim ramdisk As String = ""
    Dim filesystem As String = ""
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If platform = "" Or ramdisk = "" Or filesystem = "" Then
            MessageBox.Show("You haven't completed step one yet, finish that first", "0rangesn0w")
        Else
            Dim process As New Process()
            Dim FileName As String = "C:\genpass.exe"
            Dim Arguments As String = "-p " + platform + " -r " + ramdisk + " -f " + filesystem + " -v"
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.FileName = FileName
            process.StartInfo.Arguments = Arguments
            process.Start()
            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim where As Integer = InStr(output, "vfdecrypt") - 1
            Dim outputedited As String = output.Remove(0, where)
            If outputedited = " key" Then
                outputedited = "Error: Could not get vfdecrypt key, make sure the input files are correct"
            End If
            TextBox1.Text = outputedited
            TextBox2.Text = output
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.IO.File.WriteAllBytes("C:\genpass.exe", My.Resources.genpass)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MessageBox.Show("The Private Dev Team inc. Credits go to j0ker and orangesn0w for the program. Genpass was made entirely by the Chronic Dev team.", "0rangefreeze")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("If you need assistance please contact us through our blog, http://theprivatedevteam.blogspot.com/. Also you need to have a C:/ drive in order for this to work, so don't rename your drives!", "0rangefreeze")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        MessageBox.Show("This is the file in the ipsw typically it is one of the smallest files in it with a .dmg file extension. You must decrypt it using xpwntool. Those key's are available on the iPhone wiki under restore ramdisk on the firmware you are working on.", "0rangefreeze")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MessageBox.Show("Then it's not supported yet", "0rangefreeze")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "iPhone 2G" Then
            platform = "s5l8900x"
        ElseIf ComboBox1.Text = "iPhone 3G" Then
            platform = "s5l8900x"
        ElseIf ComboBox1.Text = "iPhone 3GS" Then
            platform = "s5l8920x"
        ElseIf ComboBox1.Text = "iPhone 4" Then
            platform = "s5l8930x"
        ElseIf ComboBox1.Text = "iPod Touch 1G" Then
            platform = "s5l8900x"
        ElseIf ComboBox1.Text = "iPod Touch 2G" Then
            platform = "s5l8720x"
        ElseIf ComboBox1.Text = "iPod Touch 3G" Then
            platform = "s5l8922x"
        ElseIf ComboBox1.Text = "iPod Touch 4" Then
            platform = "s5l8930x"
        ElseIf ComboBox1.Text = "iPad 1G" Then
            platform = "s5l8930x"
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        ramdisk = OpenFileDialog1.FileName
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub OpenFileDialog2_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        filesystem = OpenFileDialog2.FileName
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MessageBox.Show("This will always be (correct me if I'm wrong) the largest file in the ipsw with the extension .dmg. You don't need to modify it in any way.", "0rangesn0w")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        platform = ""
        ramdisk = ""
        filesystem = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
    End Sub
End Class
