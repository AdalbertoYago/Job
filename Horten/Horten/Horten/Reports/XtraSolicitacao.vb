Imports System.Drawing
Imports DevExpress.XtraReports.UI
Public Class XtraSolicitacao
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

        conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL3.Open()
        querySQL3.Connection = conSQL3

        querySQl.CommandText = "select * from SC where CDSC = '" & sCDReq & "'"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            XrLabel1.Text = "Solicitação de Compra Nº " & sCDReq
            XrLabel2.Text = "Solicitação de Compra Nº " & sCDReq
            Try
                XrLObservacao.Text = "Observação: " & datRead("Obs")
                XrLObservacao2.Text = "Observação: " & datRead("Obs")
            Catch
            End Try
            If datRead("Prioridade") = "1" Then
                XrLPrioridade.Text = "Prioridade: Média"
                XrLPrioridade2.Text = "Prioridade: Média"
            ElseIf datRead("Prioridade") = "0" Then
                XrLPrioridade.Text = "Prioridade: Baixa"
                XrLPrioridade2.Text = "Prioridade: Baixa"
            ElseIf datRead("Prioridade") = "2" Then
                XrLPrioridade.Text = "Prioridade: Alta"
                XrLPrioridade2.Text = "Prioridade: Alta"
            End If

            XrLData.Text = "Data: " & datRead("DTSC")
            XrLData2.Text = "Data: " & datRead("DTSC")
            Try
                XrLDTEntrega.Text = "Data Entrega: " & datRead("DTEntrega")
                XrLDTEntrega2.Text = "Data Entrega: " & datRead("DTEntrega")
            Catch ex As Exception

            End Try
            XrLUsuario.Text = gUsuario.ToUpper()
            XrLUsuario2.Text = gUsuario.ToUpper()

            querySQL3.CommandText = "select * from Fornecedores where CDFornec = '" & datRead("CDFornec") & "'"
            datRead3 = querySQL3.ExecuteReader()
            If datRead3.Read = True Then
                XrLFornecedores.Text = "Fornecedor: " & datRead3("Fantasia")
                XrLFornecedor2.Text = "Fornecedor: " & datRead3("Fantasia")
            End If
            datRead3.Close()
            conSQL3.Close()

            querySQL2.CommandText = "Select * from ItemSC where CDSC = '" & sCDReq & "'"
            datRead2 = querySQL2.ExecuteReader()
            Dim sDescricao, sEspaco As String
            Do Until datRead2.Read = False
                'CDRequisicao,CDMaterial,,Un8idade,Item,Descricao
                sDescricao = datRead2("Descricao")
                If sDescricao.Length > 55 Then
                    LBLCDProduto1.Text &= datRead2("CDMaterial") & vbCrLf & vbCrLf
                    LBLCDProduto2.Text &= datRead2("CDMaterial") & vbCrLf & vbCrLf
                    LBLItem1.Text &= datRead2("CDItem") & vbCrLf & vbCrLf
                    LBLItem2.Text &= datRead2("CDItem") & vbCrLf & vbCrLf
                    LBLDescricao1.Text &= datRead2("Descricao") & vbCrLf
                    LBLDescricao2.Text &= sDescricao & vbCrLf
                    LBLQtde1.Text &= datRead2("Qtde") & vbCrLf & vbCrLf
                    LBLQtde2.Text &= datRead2("Qtde") & vbCrLf & vbCrLf
                    LBLUM1.Text &= datRead2("Unidade") & vbCrLf & vbCrLf
                    LBLUM2.Text &= datRead2("Unidade") & vbCrLf & vbCrLf

                Else
                    LBLCDProduto1.Text &= datRead2("CDMaterial") & vbCrLf
                    LBLCDProduto2.Text &= datRead2("CDMaterial") & vbCrLf
                    LBLItem1.Text &= datRead2("CDItem") & vbCrLf
                    LBLItem2.Text &= datRead2("CDItem") & vbCrLf
                    LBLDescricao1.Text &= datRead2("Descricao") & vbCrLf
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