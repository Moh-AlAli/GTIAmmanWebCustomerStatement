Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Friend Class crviewer
    Private rdoc As New ReportDocument

    Private Sub crviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cwvr As New CrystalReportViewer
            cwvr.Dock = DockStyle.Fill
            cwvr.BorderStyle = BorderStyle.None
            Me.Controls.Add(cwvr)

          


            Dim curr As String = ""
            If custstatement.Rbfunc.Checked = True Then
                curr = "F"
            ElseIf custstatement.Rbsource.Checked = True Then
                curr = "C"
            End If


           


            Dim fmonthnew As String = 0
            If custstatement.DateTimePicker1.Value.Month.ToString.Length < 2 Then
                fmonthnew = "0" & custstatement.DateTimePicker1.Value.Month
            Else
                fmonthnew = custstatement.DateTimePicker1.Value.Month
            End If
            Dim tmonthnew As String = 0
            If custstatement.DateTimePicker2.Value.Month.ToString.Length < 2 Then
                tmonthnew = "0" & custstatement.DateTimePicker2.Value.Month
            Else
                tmonthnew = custstatement.DateTimePicker2.Value.Month
            End If

            Dim fdaynew As String = 0
            If custstatement.DateTimePicker1.Value.Day.ToString.Length < 2 Then
                fdaynew = "0" & custstatement.DateTimePicker1.Value.Day
            Else
                fdaynew = custstatement.DateTimePicker1.Value.Day
            End If

            Dim tdaynew As String = 0

            If custstatement.DateTimePicker2.Value.Day.ToString.Length < 2 Then
                tdaynew = "0" & custstatement.DateTimePicker2.Value.Day
            Else
                tdaynew = custstatement.DateTimePicker2.Value.Day
            End If

            Dim fdate As String = custstatement.DateTimePicker1.Value.Year & fmonthnew & fdaynew

            Dim tdate As String = custstatement.DateTimePicker2.Value.Year & tmonthnew & tdaynew

            Dim c As New Clsfunct
            Dim ds As New DataSet
            ds = c.custstatement(custstatement.txtfrmcus.Text, custstatement.Txttocus.Text, Integer.Parse(fdate), Integer.Parse(tdate), curr, OPCompany.compid)
            'ds.WriteXmlSchema("xsd\xcuststatem.xsd")
            Dim dsbb As New DataSet
            dsbb = c.bb(custstatement.txtfrmcus.Text, custstatement.Txttocus.Text, Integer.Parse(fdate), curr, OPCompany.compid)
            'dsbb.WriteXmlSchema("xsd\xbb.xsd")


            rdoc.Load("reports\ARStatment.rpt")
            rdoc.SetDataSource(ds)
            Dim sec As Section
            Dim secs As Sections
            Dim rob As ReportObject
            Dim robs As ReportObjects
            Dim subrpobj As SubreportObject
            Dim subrp As ReportDocument
            secs = rdoc.ReportDefinition.Sections
            For Each sec In secs
                robs = sec.ReportObjects
                For Each rob In robs
                    If rob.Kind = ReportObjectKind.SubreportObject Then
                        subrpobj = CType(rob, SubreportObject)
                        subrp = subrpobj.OpenSubreport(subrpobj.SubreportName)
                        If subrp.Name = "OB" Then
                            subrp.SetDataSource(dsbb)
                        End If
                    End If

                Next
            Next


            rdoc.SetParameterValue("FromDate", fdate)
            rdoc.SetParameterValue("ToDate", tdate)
            rdoc.SetParameterValue("FromCustomer", custstatement.txtfrmcus.Text)
            rdoc.SetParameterValue("ToCustomer", custstatement.Txttocus.Text)
            rdoc.SetParameterValue("Currency", curr)
            rdoc.SetParameterValue("DB", OPCompany.compid)
            rdoc.SetParameterValue("Coname", OPCompany.compname)
            cwvr.ReportSource = rdoc

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If rdoc Is Nothing Then
                rdoc.Close()
                rdoc.Dispose()
            End If
        End Try
    End Sub
End Class



