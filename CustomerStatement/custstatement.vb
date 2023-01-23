Friend Class custstatement

    Public frmcust As String
    Public Tocust As String
    Public fdate As String
    Public tdate As String

    Private Sub custstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Txttocus.Text = "zzzzzzzzzzzzzzzzzzzzzz"

            Rbfunc.Checked = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Close()
        End Try
    End Sub
    Private Sub CMD_OK_Click(sender As Object, e As EventArgs) Handles CMD_OK.Click
        Try

            Dim fmonthnew As String = 0
            If DateTimePicker1.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & DateTimePicker1.Value.Month
            Else
                fmonthnew = DateTimePicker1.Value.Month
            End If
            Dim tmonthnew As String = 0
            If DateTimePicker2.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & DateTimePicker2.Value.Month
            Else
                tmonthnew = DateTimePicker2.Value.Month
            End If

            Dim fdaynew As String = 0
            If DateTimePicker1.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & DateTimePicker1.Value.Day
            Else
                fdaynew = DateTimePicker1.Value.Day
            End If
            Dim tdaynew As String = 0
            If DateTimePicker2.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & DateTimePicker2.Value.Day
            Else
                tdaynew = DateTimePicker2.Value.Day
            End If

            Dim fdate As String = DateTimePicker1.Value.Year & fmonthnew & fdaynew

            Dim tdate As String = DateTimePicker2.Value.Year & tmonthnew & tdaynew

            If Trim(txtfrmcus.Text) <= Trim(Txttocus.Text) Then
                If fdate <= tdate Then
                    crviewer.Show()

                Else
                    MessageBox.Show("From Date  greater than To Date")
                End If
            Else
                MessageBox.Show("From Customer No greater than To Customer No")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bffind_Click(sender As Object, e As EventArgs) Handles bffind.Click
        Fromcust.Show()
        bffind.Enabled = False
    End Sub

    Private Sub btfind_Click(sender As Object, e As EventArgs) Handles btfind.Click
        Dim f As Form = New tocust
        f.Show()
        btfind.Enabled = False
    End Sub
    Private Sub CMD_Exit_Click(sender As Object, e As EventArgs) Handles CMD_Exit.Click
        Close()
    End Sub
End Class
