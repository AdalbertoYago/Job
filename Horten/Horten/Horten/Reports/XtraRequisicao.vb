Imports System.Drawing
Imports DevExpress.XtraReports.UI
Public Class XtraRequisicao
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public sCDReq As String
    Public Sub New(ByVal ssCDReq As String)
        InitializeComponent()
        sCDReq = ssCDReq
        '##Pega impressora padrao
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlPathPrinters & "impressora.xml", "Danfe")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try
        XrPictureBox1.ImageUrl = gLogoDanfe
        XrPictureBox2.ImageUrl = gLogoDanfe
        XrLEmpresa.Text = StrConv(gNomeEmpresa, VbStrConv.ProperCase)
        XrLEmpresa2.Text = StrConv(gNomeEmpresa, VbStrConv.ProperCase)


        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        querySQl.CommandText = "select * from Requisicao where CDRequisicao = '" & sCDReq & "'"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            XrLabel1.Text = "Requisição de Materiais Nº " & sCDReq
            XrLabel2.Text = "Requisição de Materiais Nº " & sCDReq

            XrLData.Text = "Data: " & datRead("DTRequisicao") & " " & datRead("HRRequisicao")
            XrLData2.Text = "Data: " & datRead("DTRequisicao") & " " & datRead("HRRequisicao")
            XrLRequisitante.Text = "Requisitante: " & datRead("Requisitante")
            XrLRequisitante2.Text = "Requisitante: " & datRead("Requisitante")
            txtObs1.Text = "Obs: " & datRead("Historico")
            txtObs2.Text = "Obs: " & datRead("Historico")

            querySQL2.CommandText = "Select * from ItemReq where CDRequisicao = '" & sCDReq & "' order by Item"
            datRead2 = querySQL2.ExecuteReader()
            Dim sDescricao, sEspaco As String
            Do Until datRead2.Read = False
                'CDRequisicao,CDMaterial,,Un8idade,Item,Descricao
                sDescricao = datRead2("Descricao")
                sDescricao = sDescricao.Trim()
                If sDescricao.Length > 74 Then
                    sDescricao = sDescricao.Substring(0, 73)
                End If

                If sDescricao.Length > 74 Then
                    LBLCDProduto1.Text &= datRead2("CDMAterial") & vbCrLf & vbCrLf
                    LBLCDProduto2.Text &= datRead2("CDMAterial") & vbCrLf & vbCrLf
                    LBLItem1.Text &= datRead2("Item") & vbCrLf & vbCrLf
                    LBLItem2.Text &= datRead2("Item") & vbCrLf & vbCrLf
                    LBLDescricao1.Text &= sDescricao & vbCrLf
                    LBLDescricao2.Text &= sDescricao & vbCrLf
                    LBLQtde1.Text &= datRead2("Qtde") & vbCrLf & vbCrLf
                    LBLQtde2.Text &= datRead2("Qtde") & vbCrLf & vbCrLf
                    LBLUM1.Text &= datRead2("Unidade") & vbCrLf & vbCrLf
                    LBLUM2.Text &= datRead2("Unidade") & vbCrLf & vbCrLf
                Else
                    LBLCDProduto1.Text &= datRead2("CDMAterial") & vbCrLf
                    LBLCDProduto2.Text &= datRead2("CDMAterial") & vbCrLf
                    LBLItem1.Text &= datRead2("Item") & vbCrLf
                    LBLItem2.Text &= datRead2("Item") & vbCrLf
                    LBLDescricao1.Text &= sDescricao & vbCrLf
                    LBLDescricao2.Text &= sDescricao & vbCrLf
                    LBLQtde1.Text &= datRead2("Qtde") & vbCrLf
                    LBLQtde2.Text &= datRead2("Qtde") & vbCrLf
                    LBLUM1.Text &= datRead2("Unidade") & vbCrLf
                    LBLUM2.Text &= datRead2("Unidade") & vbCrLf
                End If


            Loop
            datRead2.Close()
        End If
        datRead.Close()
        conSQL.Close()
        conSQL2.Close()

    End Sub
End Class