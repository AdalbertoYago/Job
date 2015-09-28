Public Class RelItemFornecidoRecebido
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public sCDControle As String
    Public Sub New(ByVal ssCDControle As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        sCDControle = ssCDControle
        Dim sStatus As String
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Dim spath = xmlPathPrinters & "impressora.xml"
        Try
            sPrinter = cXML.pegaStringXML(spath, "Etiquetas")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()

        querySQl.Connection = conSQL
        querySQl.CommandText = "select * from ItemFornecidoRecebido where CDControle='" & sCDControle & "'"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            If datRead("Status") = 0 Then
                sStatus = "Sem Status"
            ElseIf datRead("Status") = 1 Then
                sStatus = "Aguardando Complemento"
            ElseIf datRead("Status") = 2 Then
                sStatus = "Aguardando Pagamento"
            ElseIf datRead("Status") = 3 Then
                sStatus = "Aguardando Tecidos de Outros Itens"
            ElseIf datRead("Status") = 4 Then
                sStatus = "Identificar Lado Correto"
            ElseIf datRead("Status") = 5 Then
                sStatus = "Liberado"
            ElseIf datRead("Status") = 6 Then
                sStatus = "Pendente"
            End If
            XrLNome.Text = "Nº Controle: " & datRead("CDControle") & " - " & datRead("Descricao")
            XrLEndereco.Text = "Nº Pedido: " & datRead("CDPedido") & vbCrLf & "Cliente: " & datRead("CDCliente") & vbCrLf & "Status: " & sStatus
            XrLTransportadora.Text = "Obs: " & datRead("Obs")
        End If
    End Sub
End Class