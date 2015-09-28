Module ModulePrisma
    Public gConSTR As String
    Public gEmpresa As String
    Public gIDEmpresa As Integer
    Public bAcessoExterno As Boolean = False
    '### Variaveis de Banco
    Public gDataSource As String
    Public gUserID As String
    Public gPWD As String
    Public gInitialCatalog As String
    Public gNomeEmpresa As String
    Public gSetor As String
    Public gFantasia As String
    Public gAcessos As String
    Public gCliente As String
    Public gClienteRel As String
    Public gCDPerfil As String
    Public gEndereco As String
    Public gNumero As Integer
    Public gComplemento As String
    Public gCidade As String
    Public gCNPJ As String
    Public gIE As String
    Public gBairro As String
    Public gLogo As String
    Public gLogoDanfe As String
    Public gLogoWeb As String
    Public gUFEmissor As Integer '35
    Public gsUFEmissor As String 'SP
    Public gCEP As String
    Public gFone As String
    Public gMunicipioEmissor As Integer
    Public gEmailNFE As String
    Public gEmailContasAPagar As String
    Public gEmailContasAReceber As String
    Public gPathCNAB As String
    Public gBanco As String
    Public gAgencia As String
    Public gContaCorrente As String
    Public gDominio As String
    Public gBanco2 As String
    Public gAgencia2 As String
    Public gContaCorrente2 As String
    Public gListaPadrao As String
    Public gEntradaEstoqueViaRecebimento As Boolean

    Public gDadosDeposito1 As String
    Public gDadosDeposito2 As String

    Public gTpAmb As Integer
    Public gCVAcesso, sNF As String

    'Banco Auxiliar
    Public gDataSourceAux As String
    Public gUserIDAux As String
    Public gPWDAux As String
    Public gInitialCatalogAux As String

    '### Variaveis de Banco LEGADO
    Public gDataSourceLegado As String
    Public gUserIDLegado As String
    Public gPWDLegado As String
    Public gInitialCatalogLegado As String

    '### Variaveis de Banco LEGADO AUXILIAR
    Public gDataSourceLegadoAux As String
    Public gUserIDLegadoAux As String
    Public gPWDLegadoAux As String
    Public gInitialCatalogLegadoAux As String
    Public gEmailAlmoxarife As String


    Public gdPrazoDeEntrega As Integer

    Public datPubsEPI, datPubsFun As New DataSet()

    Public conSTR As String = "Integrated Security=False; Data Source=192.168.0.1; User ID=sa; Pwd=alado; Initial Catalog=Prisma;"

    Public VSQL As String

    '### Variaveis de Usuario
    Public gUsuario As String
    Public gIDUsuario As String

    Public conSQL, conSQL1, conSQL2, conSQL3, conSQL4, conSQL5, conSQLNF, conSQLLegado, conSQLLegadoAux As New SqlClient.SqlConnection()
    Public conSQLY, conSQLY1, conSQLY2, conSQLY3, conSQLY4 As New SqlClient.SqlConnection()
    Public adaptSQL, adaptSQL1, adaptSQL2, adaptSQL3, adaptSQL4 As SqlClient.SqlDataAdapter

    Public datPubsRel, datPubs, datPubs2, datPubs3, datPubs4, datPubs5, datPubs6, datPubs7, datPubs8, datPubs9, datPubs10, datPubs11 As New DataSet()
    Public datPubs12, datPubs13, datPubs14, datPubs15 As New DataSet()

    Public datPubsCP1, datPubs1CEP, datPubsClientes, datPubsUF, datPubsMunicipio, datPubsPais, datPubsBusca, datPubsContatos, datPubsEmb, datPubsTipoEnd, datPubsProdutos, datPubsVendedor As New DataSet()
    Public datPubs2Clientes, datPubsTransp, datPubsTranspUF, datPubsTranspMunicipio, datPubsEmbarqueUF, datPubsVencimento, datPubsNatOper, datPubsGarantia As New DataSet()

    Public querySQl, querySQL1, querySQL2, querySQL3, querySQL4, querySQL5, querySQLProc As New SqlClient.SqlCommand()
    Public datRead, datRead2, datRead3, datRead4 As SqlClient.SqlDataReader

    Public gCertificadoDigital, gCertificadoSenha As String
    Public gPathXML As String
    Public xmlPathPrisma As String = "c:\Prisma\"
    Public xmlPathPrinters As String = "c:\Prisma\xml\Impressoras\"
    Public xmlPathTMP As String = "c:\Prisma\xml\tmp\"
    Public xmlPathRecibos As String = "c:\Prisma\xml\Recibos\"
    Public xmlPathLayouts As String = "c:\Prisma\xml\Layouts\"
    Public gPathInstalacao As String = "\\192.168.1.1\base\prisma"
    Public gPathFotos As String

    Public xmlPathCancNFeCabeca As String
    Public xmlPathConsCadCabeca As String
    Public xmlPathConsProcLoteCabeca As String
    Public xmlPathConsProcLoteDados As String
    Public xmlPathConsReciNFeCabeca As String
    Public xmlPathConsSitNFeCabeca As String
    Public xmlPathConsStatServCabeca As String
    Public xmlPathConsStatServDados As String
    Public xmlPathEnvLote As String
    Public xmlPathInutNfe As String


    Public gPathBoleto As String

    '#VARIAVEIS DE PERMISSAO NAS PROCEDURES TABELA: AUTENTICAPROCEDURE
    Public bChecaEstoque As Boolean
    Public bGeraOPPedido As Boolean
    Public bBaixaEstoque As Boolean
    Public bDividePedido As Boolean
    Public bTecidoFornecido As Boolean
    Public bPedidoChecaRestricaoFinanceira As Boolean
    Public bPedidoChecaLimiteCredito As Boolean
    Public bTravaPedidoUsuario As Boolean
    Public bPedidoOrdenaPorItem As Boolean


    Public gCNPJCliente As String

    'Variaveis para relatorios Pedido do Cliente
    Public sCDPedido As String
    Public gsBusca As String
    Public gsTipo As String
    Public sCDOrc As String
    Public sCDNFRel As String
    Public iCDVolume, iCDVolume2 As Integer
    Public gCDPedidoCliente As String
    Public gDTPedido As String
    Public gCDProduto As String
    Public gCDOP As String
    Public gCDItem As String

    'Variavel para montar string em relatorio
    Public gVSQL As String
    Public gsString As String
    Public gsString2 As String
    Public gTerminal As String

    '###
    Public gEmailPedidos As String


    '###VARIAVEIS QUE MOSTRAM QUAIS OPCOES DE RELATORIO DEVEMOS USAR
    Public gA, gB As Boolean
    Public Function StrZero(ByVal Numero As String, ByVal Comprimento As Integer) As String
        StrZero = Numero.PadLeft(Comprimento, "0")
    End Function
    Public Function CDBNumber(ByVal Number As Double) As String
        CDBNumber = Replace(Number, ",", ".")
    End Function
    Public Function CDBTexto(ByVal Texto As String) As String
        CDBTexto = Replace(Texto, "'", "''")
        CDBTexto = Replace(CDBTexto, ",", ".")
    End Function

    Public Sub LogIn(ByVal PUsuario As String, ByVal PHistorico As String)
        If conSQL.State = ConnectionState.Closed Then conSQL.Open()
        querySQl.Connection = conSQL
        querySQl.CommandText = "INSERT Into Prisma.dbo.LOG (Data,Hora,Usuario,Historico) VALUES (Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),'" & Now.TimeOfDay.ToString.Substring(0, 5) & "','" & PUsuario & "','" & PHistorico & "')"
        querySQl.ExecuteNonQuery()
        conSQL.Close()
    End Sub




    Public Sub LimpaForm(ByVal nomeForm As Object)
        Dim ctrl As Control
        For Each ctrl In nomeForm.Controls
            If TypeOf (ctrl) Is TextBox Then
                ctrl.Text = ""
            End If
            If TypeOf (ctrl) Is ComboBox Then

            End If
            If TypeOf (ctrl) Is CheckBox Then

            End If
            If TypeOf (ctrl) Is MaskedTextBox Then
                ctrl.Text = ""
            End If
            If ctrl.HasChildren Then
                LimpaForm(ctrl)
            End If
        Next
    End Sub
    Public Function tiraAcentos(ByVal texto As String) As String
        Dim ComAcentos As String = "!@#$%®&*()-?:{}][ƒ≈¡¬¿√‰·‚‡„… À»ÈÍÎËÕŒœÃÌÓÔÏ÷”‘“’ˆÛÙÚı‹⁄€¸˙˚˘«Áÿ"
        Dim SemAcentos As String = "_@__%_____-______AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc "
        Dim i As Integer
        Dim z As Integer = Len(ComAcentos)
        For i = 0 To z - 1
            texto = Replace(texto, ComAcentos(i).ToString(), SemAcentos(i).ToString())
        Next
        Return texto
    End Function
End Module
