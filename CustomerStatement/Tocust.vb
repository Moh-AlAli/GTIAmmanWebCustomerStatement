﻿'Imports AccpacCOMAPI
Public Class tocust
    Private i As Integer
    Private j As Integer
    'Private os As New Session
    'Private dblink As DBLink
    'Private compid As String = ""
    Private Sub tocust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim arv As AccpacView
            'arv = custstatement.xdbcom.OpenView2("AR0024")
            'Dim arcusds As DataSet = New DataSet("AR")
            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim name As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim id As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer("", OPCompany.compid)
            Dim icl As New DataGridViewTextBoxColumn
            icl.DataPropertyName = "IDCUST"
            icl.Name = "clidc"
            icl.HeaderText = "Customer Number"
            icl.Width = 150
            DGtocus.Columns.Add(icl)
            Dim ncl As New DataGridViewTextBoxColumn
            ncl.DataPropertyName = "NAMECUST"
            ncl.Name = "colnc"
            ncl.HeaderText = "Customer Name"
            ncl.Width = 190
            DGtocus.Columns.Add(ncl)

            DGtocus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ButSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSel.Click
        Try


            'Dim arv As AccpacView
            'arv = custstatement.xdbcom.OpenView2("AR0024")
            Dim searfil As String = ""

            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If

            'arv.Browse(searfil, True)
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            Dim dt As DataTable = arcusds.Tables(0)

            i = DGtocus.CurrentCell.RowIndex
            j = DGtocus.CurrentCell.ColumnIndex
            custstatement.Txttocus.Text = dt.Rows(i)(0)
            custstatement.btfind.Enabled = True
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butcan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butcan.Click
        Close()
        custstatement.btfind.Enabled = True
    End Sub

    Private Sub Txtcusno_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcusno.MouseLeave

    

        'Dim arv As AccpacView
        'arv = custstatement.xdbcom.OpenView2("AR0024")
            Dim searfil As String = ""


         If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
            searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
        ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
            searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
        ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
            searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
        End If
        'arv.Browse(searfil, True)
        Dim arcusds As New DataSet
        Dim c As New Clsfunct

        arcusds = c.customer(searfil, OPCompany.compid)

        'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
        'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
        'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
        'cust.PrimaryKey = New DataColumn() {id}
        'Dim row As DataRow
        'row = cust.NewRow()
        'Do While arv.FilterFetch(False)
        '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
        '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
        '    row("IDCUST") = cid
        '    row("NAMECUST") = cn
        '    arcusds.Tables(0).Rows.Add(row)
        '    row = cust.NewRow()
        'Loop


            DGtocus.DataSource = arcusds.Tables(0)



    End Sub

    Private Sub Txtname_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtname.MouseLeave

        Try

          

            'Dim arv As AccpacView
            'arv = custstatement.xdbcom.OpenView2("AR0024")
            Dim searfil As String = ""
  If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If
            'arv.Browse(searfil, True)
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop

                DGtocus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txtcusno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcusno.TextChanged
        Try



            'Dim arv As AccpacView
            'arv = custstatement.xdbcom.OpenView2("AR0024")
           
            Dim searfil As String = ""

         If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If
            'arv.Browse(searfil, True)
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            'arv.Browse(searfil, True)
            'Dim arcusds As DataSet = New DataSet("AR")

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            DGtocus.DataSource = arcusds.Tables(0)

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

            'arv.Browse(searfil, True)
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            DGtocus.DataSource = arcusds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGtocus_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGtocus.CellContentClick
        Try

            Dim searfil As String = ""

            If Txtcusno.Text <> Nothing And Txtname.Text <> Nothing Then
                searfil = " Where NAMECUST Like N'%" + Txtname.Text + "%' And IDCUST Like N'%" + Txtcusno.Text + "%' "
            ElseIf Txtname.Text <> Nothing And Txtcusno.Text = Nothing Then
                searfil = " Where NAMECUST like N'%" + Txtname.Text + "%' "
            ElseIf Txtcusno.Text <> Nothing And Txtname.Text = Nothing Then
                searfil = " Where IDCUST like N'%" + Txtcusno.Text + "%' "
            End If

            'arv.Browse(searfil, True)
            Dim arcusds As New DataSet
            Dim c As New Clsfunct

            arcusds = c.customer(searfil, OPCompany.compid)

            'Dim cust As DataTable = arcusds.Tables.Add("ARCUS")
            'Dim id As DataColumn = cust.Columns.Add("IDCUST", Type.GetType("System.String"))
            'Dim name As DataColumn = cust.Columns.Add("NAMECUST", Type.GetType("System.String"))
            'cust.PrimaryKey = New DataColumn() {id}
            'Dim row As DataRow
            'row = cust.NewRow()
            'Do While arv.FilterFetch(False)
            '    Dim cid As String = arv.Fields.FieldByName("IDCUST").Value.ToString()
            '    Dim cn As String = arv.Fields.FieldByName("NAMECUST").Value.ToString()
            '    row("IDCUST") = cid
            '    row("NAMECUST") = cn
            '    arcusds.Tables(0).Rows.Add(row)
            '    row = cust.NewRow()
            'Loop
            Dim dt As DataTable = arcusds.Tables(0)

            i = DGtocus.CurrentCell.RowIndex
            j = DGtocus.CurrentCell.ColumnIndex
            custstatement.Txttocus.Text = dt.Rows(i)(0)
            custstatement.btfind.Enabled = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tocust_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        custstatement.btfind.Enabled = True
    End Sub
End Class