Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Clsfunct
    Private server As String = ""
    Private uid As String = ""
    Private pass As String = ""
    Private db As String
    Friend Function createdes(ByVal key As String) As TripleDES
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim des As TripleDES = New TripleDESCryptoServiceProvider()
        des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key))
        des.IV = New Byte(des.BlockSize \ 8 - 1) {}
        Return des
    End Function
    Friend Function Decryption(ByVal cyphertext As String, ByVal key As String) As String
        Dim b As Byte() = Convert.FromBase64String(cyphertext)
        Dim des As TripleDES = createdes(key)
        Dim ct As ICryptoTransform = des.CreateDecryptor()
        Dim output As Byte() = ct.TransformFinalBlock(b, 0, b.Length)
        Return Encoding.Unicode.GetString(output)
    End Function
    Friend Function Readconnectionstring() As String

        Dim secretkey As String = "Fhghqwjehqwlegtoit123mnk12%&4#"
        Dim path As String = ("txtcon\gticon.txt")
        Dim sr As New StreamReader(path)

        server = sr.ReadLine()
        db = sr.ReadLine()
        uid = sr.ReadLine()
        pass = sr.ReadLine()


        server = Decryption(server, secretkey)
        db = Decryption(db, secretkey)
        uid = Decryption(uid, secretkey)
        pass = Decryption(pass, secretkey)

        Dim cons As String = "Data Source =" & server & "; DataBase =" & db & "; User Id =" & uid & "; Password =" & pass & ";"
        'Dim cons As String = "Data Source =(local); DataBase =master; User Id =sa; Password =P@$$w0rd;"

        Return cons
    End Function
    Friend Function customer(ByVal condt As String, ByVal dbname As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As String = "Select IDCUST,NAMECUST from " & dbname & ".dbo.ARCUS" & condt & " "
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function

    Friend Function sagecompany() As DataSet
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT name FROM sys.databases  where name like '%DAT%' order by name"
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function
    Friend Function sagecompanydesc(ByVal dbname As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As String = "SELECT CONAME From " & dbname & ".dbo.CSCOM  order by orgid "
        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function
    Friend Function custstatement(ByVal fcust As String, ByVal tcust As String, ByVal fdate As Integer, ByVal tdate As Integer, ByVal curtype As String, ByVal dbname As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As String = " SELECT DISTINCT b.TRXTYPETXT as TRXTYPE, b.IDINVC, c.NAMECUST, b.DATEINVC as DATEINVC, b.IDCUST, b.AMTINVCTC as AMTINVCTC, b.DESCINVC as DESCINVC,  c.CODECURN, b.AMTINVCHC as AMTINVCHC, b.CNTBTCH as Batch, b.CNTITEM as [Entry],ltrim(rtrim('" & curtype & "')) as curtype " &
                                 " FROM  " & dbname & ".dbo.ARCUS c INNER JOIN " & dbname & ".dbo.CSCOM m ON c.AUDTORG=m.ORGID INNER JOIN " & dbname & ".dbo.AROBL b ON c.IDCUST=b.IDCUST LEFT OUTER JOIN " & dbname & ".dbo.ARTCR t ON b.CNTBTCH=t.CNTBTCH AND b.CNTITEM=t.CNTITEM AND b.IDCUST=t.IDCUST  INNER JOIN " & dbname & ".dbo.CSCCD s ON m.HOMECUR=s.CURID  " &
                                 " WHERE   ltrim(rtrim(b.IDCUST)) between ltrim(rtrim('" & fcust & "')) and ltrim(rtrim('" & tcust & "')) and b.DATEINVC between " & fdate & " and " & tdate & " " &
                                 " union all " &
                                 " SELECT DISTINCT p.TRXTYPE as TRXTYPE, p.IDINVC, c.NAMECUST, p.DATEBUS as DATEINVC,p.IDCUST, p.AMTPAYMTC as AMTINVCTC, p.IDMEMOXREF as DESCINVC,   c.CODECURN, p.AMTPAYMHC as AMTINVCHC,  p.CNTBTCH as Batch,  p.CNTITEM as [Entry],ltrim(rtrim('" & curtype & "')) as curtype" &
                                 " FROM  " & dbname & ".dbo.ARCUS c INNER JOIN " & dbname & ".dbo.CSCOM m ON c.AUDTORG=m.ORGID INNER JOIN " & dbname & ".dbo.AROBL b ON c.IDCUST=b.IDCUST INNER JOIN " & dbname & ".dbo.AROBP p ON b.IDCUST=p.IDCUST AND b.IDINVC=p.IDINVC LEFT OUTER JOIN " & dbname & ".dbo.ARTCR t ON b.CNTBTCH=t.CNTBTCH AND b.CNTITEM=t.CNTITEM AND b.IDCUST=t.IDCUST LEFT OUTER JOIN " & dbname & ".dbo.ARRRH h ON p.IDBANK=h.IDBANK AND p.IDCUST=h.IDCUST AND p.IDRMIT=h.IDRMIT AND p.DEPSEQ=h.DEPSEQ AND p.DEPLINE=h.DEPLINE AND p.DATERMIT=h.DATERMIT INNER JOIN " & dbname & ".dbo.CSCCD s ON m.HOMECUR=s.CURID " &
                                 " WHERE  ltrim(rtrim(p.IDCUST)) between ltrim(rtrim('" & fcust & "')) and ltrim(rtrim('" & tcust & "')) and p.DATEBUS between " & fdate & " and " & tdate & " " &
                                 " and (p.TRXTYPE = 4 or ( p.TRXTYPE = 53 and p.IDMEMOXREF= '') or ( p.TRXTYPE = 59 and p.IDMEMOXREF= '') or   ((ltrim(rtrim('" & curtype & "'))='F' ) and (p.TRXTYPE = 65  or   p.TRXTYPE = 67)) ) " &
                                 " order by IDCUST,DATEINVC"

        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function

    Friend Function bb(ByVal fcust As String, ByVal tcust As String, ByVal fdate As Integer, ByVal curtype As String, ByVal dbname As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As String = " SELECT DISTINCT b.TRXTYPETXT as TRXTYPE, b.IDINVC, c.NAMECUST, b.DATEINVC as DATEINVC, b.IDCUST, b.AMTINVCTC as AMTINVCTC, b.DESCINVC as DESCINVC,  c.CODECURN, b.AMTINVCHC as AMTINVCHC, b.CNTBTCH as Batch, b.CNTITEM as [Entry],ltrim(rtrim('" & curtype & "')) as curtype " &
                                 " FROM  " & dbname & ".dbo.ARCUS c INNER JOIN " & dbname & ".dbo.CSCOM m ON c.AUDTORG=m.ORGID INNER JOIN " & dbname & ".dbo.AROBL b ON c.IDCUST=b.IDCUST LEFT OUTER JOIN " & dbname & ".dbo.ARTCR t ON b.CNTBTCH=t.CNTBTCH AND b.CNTITEM=t.CNTITEM AND b.IDCUST=t.IDCUST  INNER JOIN " & dbname & ".dbo.CSCCD s ON m.HOMECUR=s.CURID   " &
                                 " WHERE   ltrim(rtrim(b.IDCUST)) between ltrim(rtrim('" & fcust & "')) and ltrim(rtrim('" & tcust & "')) and b.DATEINVC <" & fdate & " " &
                                 " union all " &
                                 " SELECT DISTINCT p.TRXTYPE as TRXTYPE, p.IDINVC, c.NAMECUST, p.DATEBUS as DATEINVC,p.IDCUST, p.AMTPAYMTC as AMTINVCTC, p.IDMEMOXREF as DESCINVC,   c.CODECURN, p.AMTPAYMHC as AMTINVCHC,  p.CNTBTCH as Batch,  p.CNTITEM as [Entry],ltrim(rtrim('" & curtype & "')) as curtype" &
                                 " FROM  " & dbname & ".dbo.ARCUS c INNER JOIN " & dbname & ".dbo.CSCOM m ON c.AUDTORG=m.ORGID INNER JOIN " & dbname & ".dbo.AROBL b ON c.IDCUST=b.IDCUST INNER JOIN " & dbname & ".dbo.AROBP p ON b.IDCUST=p.IDCUST AND b.IDINVC=p.IDINVC LEFT OUTER JOIN " & dbname & ".dbo.ARTCR t ON b.CNTBTCH=t.CNTBTCH AND b.CNTITEM=t.CNTITEM AND b.IDCUST=t.IDCUST LEFT OUTER JOIN " & dbname & ".dbo.ARRRH h ON p.IDBANK=h.IDBANK AND p.IDCUST=h.IDCUST AND p.IDRMIT=h.IDRMIT AND p.DEPSEQ=h.DEPSEQ AND p.DEPLINE=h.DEPLINE AND p.DATERMIT=h.DATERMIT INNER JOIN " & dbname & ".dbo.CSCCD s ON m.HOMECUR=s.CURID  " &
                                 " WHERE  ltrim(rtrim(p.IDCUST)) between ltrim(rtrim('" & fcust & "')) and ltrim(rtrim('" & tcust & "')) and p.DATEBUS< " & fdate & "" &
                                 " and (p.TRXTYPE = 4 or ( p.TRXTYPE = 53 and p.IDMEMOXREF= '') or ( p.TRXTYPE = 59 and p.IDMEMOXREF= '') or   ((ltrim(rtrim('" & curtype & "'))='F' ) and (p.TRXTYPE = 65  or  p.TRXTYPE = 67)) ) " &
                                 " order by IDCUST,DATEINVC"

        Dim da As New SqlDataAdapter
        Dim con As New SqlConnection(Readconnectionstring())
        With cmd
            .CommandText = sql
            .CommandType = CommandType.Text
            .Connection = con
        End With
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds
    End Function
End Class
