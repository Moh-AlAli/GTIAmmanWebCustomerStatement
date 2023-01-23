Imports System.Data
Imports System.Data.SqlClient
Public Class OPCompany
    Friend compid As String = ""
    Friend compname As String = ""
    Private Sub Company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As New Clsfunct
        Dim dbcomp As New DataSet
        Dim dbcompdesc As New DataSet
        dbcomp = c.sagecompany()
        Dim sagedesc As DataSet = New DataSet("AR")
        Dim cust As DataTable = sagedesc.Tables.Add("CompDESC")
        Dim cname As DataColumn = cust.Columns.Add("VALUE", Type.GetType("System.String"))
        Dim id As DataColumn = cust.Columns.Add("VDESC", Type.GetType("System.String"))
        Dim row As DataRow
        row = cust.NewRow()
        For i = 0 To dbcomp.Tables(0).Rows.Count - 1 Step 1
            Dim name As String = dbcomp.Tables(0).Rows(i).Item("name").ToString()
            dbcompdesc = c.sagecompanydesc(name)
            Dim desc As String = dbcompdesc.Tables(0).Rows(0).Item("CONAME").ToString()
            row("VALUE") = name
            row("VDESC") = desc
            sagedesc.Tables(0).Rows.Add(row)
            row = cust.NewRow()
        Next
        CBcompname.DataSource = sagedesc.Tables(0)
        CBcompname.DisplayMember = "VDESC"
        CBcompname.ValueMember = "VALUE"
    End Sub
    Private Sub butopencomp_Click(sender As Object, e As EventArgs) Handles butopencomp.Click
        compid = CBcompname.SelectedValue
        compname = CBcompname.Text
        custstatement.Show()

    End Sub
End Class