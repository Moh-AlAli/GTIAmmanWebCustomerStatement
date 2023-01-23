

Friend Class Fromcust
    Private i As Integer
    Private j As Integer

    Private Sub Fromcust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer("", OPCompany.compid)
            Dim icl As New DataGridViewTextBoxColumn
            icl.DataPropertyName = "IDCUST"
            icl.Name = "clidc"
            icl.HeaderText = "Customer Number"
            icl.Width = 150
            DGfcus.Columns.Add(icl)
            Dim ncl As New DataGridViewTextBoxColumn
            ncl.DataPropertyName = "NAMECUST"
            ncl.Name = "colnc"
            ncl.HeaderText = "Customer Name"
            ncl.Width = 190
            DGfcus.Columns.Add(ncl)
            DGfcus.DataSource = arcusds.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSel.Click
        Try



            Dim searfil As String = ""

            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If


            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)


            Dim dt As DataTable = arcusds.Tables(0)

            i = DGfcus.CurrentCell.RowIndex
            j = DGfcus.CurrentCell.ColumnIndex
            custstatement.txtfrmcus.Text = dt.Rows(i)(0)
            custstatement.Txttocus.Text = dt.Rows(i)(0)
            custstatement.bffind.Enabled = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butcan.Click
        Close()
        custstatement.bffind.Enabled = True
    End Sub

    Private Sub Txtcusno_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcusno.MouseLeave




        Dim searfil As String = ""
        If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
            searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
        ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
            searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
        ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
            searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
        End If
        Dim arcusds As New DataSet
        Dim c As New Clsfunct

        arcusds = c.customer(searfil, OPCompany.compid)



        DGfcus.DataSource = arcusds.Tables(0)


    End Sub

    Private Sub Txtname_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.MouseLeave

        Try



            Dim searfil As String = ""
            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If

            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            DGfcus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Txtcusno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcusno.TextChanged
        Try



            Dim searfil As String = ""
            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)
            DGfcus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.TextChanged
        Try



            Dim searfil As String = ""
            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)
            DGfcus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGfcus_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGfcus.CellContentClick
        Try

            Dim searfil As String = ""

            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            Dim dt As DataTable = arcusds.Tables(0)

            i = DGfcus.CurrentCell.RowIndex
            j = DGfcus.CurrentCell.ColumnIndex
            custstatement.txtfrmcus.Text = dt.Rows(i)(0)
            custstatement.Txttocus.Text = dt.Rows(i)(0)
            custstatement.bffind.Enabled = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Fromcust_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        custstatement.bffind.Enabled = True
    End Sub
End Class