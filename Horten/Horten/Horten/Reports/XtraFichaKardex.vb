Imports System.Drawing
Imports DevExpress.XtraReports.UI
Public Class XtraFichaKardex
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public sCDProduto, sDataIni, sDataFim As String
    Public Sub New(ByVal ssCDProduto As String, ByVal ssDataIni As String, ByVal ssDataFim As String)
        InitializeComponent()
        sCDProduto = ssCDProduto
        sDataIni = ssDataIni
        sDataFim = ssDataFim

        '##Pega impressora padrao
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlPathPrinters & "impressora.xml", "Danfe")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try
        XrPictureBox1.ImageUrl = gLogo
        XrLEmpresa.Text = StrConv(gNomeEmpresa, VbStrConv.ProperCase)
        XrLData.Text = "Data de Emissão: " & Date.Now.ToShortDateString()


        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        Dim dSaldoIncial As Decimal
        Dim dQtdeEntrada, dQtdeEntradaAcum As Decimal
        Dim dQtdeSaida, dQtdeSaidaAcum As Decimal
        Dim sDescricao As String
        Dim sStatus As String
        querySQl.CommandText = "Select top 1 * from Kardex where CDProduto='" & sCDProduto & "' and data <= convert(datetime,'" & sDataIni & "',103) order by Registro desc"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            Try
                dSaldoIncial = datRead("Saldo")
            Catch
                dSaldoIncial = 0
            End Try
            Try
                sDescricao = datRead("Descricao")
            Catch ex As Exception
                sDescricao = ""
            End Try
        End If
        datRead.Close()
        XrLDescricao.Text = "Código: " & ssCDProduto & " - Descrição: " & sDescricao & " De: " & sDataIni & " Até: " & sDataFim
        XrLSaldoInicial.Text = "Saldo Inicial: " & dSaldoIncial


        XrLRegistro.Text = ""
        XrLDataKardex.Text = ""
        XrLEvento.Text = ""
        XrLEntrada.Text = ""
        XrLSaida.Text = ""
        XrLSaldo.Text = ""


        gVSQL = "Select * from Kardex where CDProduto='" & sCDProduto & "' and data between convert(datetime,'" & sDataIni & "',103) and convert(datetime,'" & sDataFim & "',103)  order by registro"
        querySQl.CommandText = gVSQL
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            sStatus = datRead("Status")
            If sStatus.Substring(0, 1) = "S" Then
                XrLRegistro.Text &= datRead("Registro") & vbCrLf
                XrLDataKardex.Text &= datRead("Data") & vbCrLf
                XrLEvento.Text &= datRead("Status") & vbCrLf
                XrLEntrada.Text &= "0" & vbCrLf
                XrLSaida.Text &= datRead("Qtde") & vbCrLf
                XrLSaldo.Text &= datRead("Saldo") & vbCrLf
                dQtdeSaidaAcum += datRead("qtde")
            ElseIf sStatus.Substring(0, 1) = "E" Then
                XrLRegistro.Text &= datRead("Registro") & vbCrLf
                XrLDataKardex.Text &= datRead("Data") & vbCrLf
                XrLEvento.Text &= datRead("Status") & vbCrLf
                XrLEntrada.Text &= datRead("Qtde") & vbCrLf
                XrLSaida.Text &= "0" & vbCrLf
                XrLSaldo.Text &= datRead("Saldo") & vbCrLf
                dQtdeEntradaAcum += datRead("qtde")
            End If
        Loop
        XrLTotalEntrada.Text = dQtdeEntradaAcum
        XrLTotalSaida.Text = dQtdeSaidaAcum
        datRead.Close()
        conSQL.Close()
    End Sub
End Class