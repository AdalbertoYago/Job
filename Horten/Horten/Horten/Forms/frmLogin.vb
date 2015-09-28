Imports System.Xml
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Dns
Imports PrismaLibrary
Public Class frmLogin
    Public xmlString As String = xmlPathPrisma & "autenticacao.xml"

    Private Sub frmLogin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Alt Then
            If e.KeyCode = Keys.F2 Then
                If Me.BackColor = Color.Firebrick Then
                    Me.BackColor = Color.SlateGray
                    gA = True
                    gB = False
                Else
                    Me.BackColor = Color.Firebrick

                    gA = False
                    gB = True
                End If
            End If
        End If
    End Sub
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sSeparadorDecimal As String = My.Application.Culture.NumberFormat.NumberDecimalSeparator.ToString()
        If sSeparadorDecimal = "." Then
            MessageBox.Show("Atenção, você está usando ""."" como SÍMBOLO DECIMAL. " & vbCrLf & "Entre nas Opções Regionais e Idioma e o altere para "",""" & vbCrLf & "Lembre-se que o sistema não EMITIRÁ NFE CORRETAMENTE!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End
        Else
            '####Cria diretorios
            If Not System.IO.Directory.Exists(xmlPathPrisma) Then
                System.IO.Directory.CreateDirectory(xmlPathPrisma)
            End If
            If Not System.IO.Directory.Exists(xmlPathPrinters) Then
                System.IO.Directory.CreateDirectory(xmlPathPrinters)
            End If
            If Not System.IO.Directory.Exists(xmlPathTMP) Then
                System.IO.Directory.CreateDirectory(xmlPathTMP)
            End If
            If Not System.IO.Directory.Exists(xmlPathRecibos) Then
                System.IO.Directory.CreateDirectory(xmlPathRecibos)
            End If
            If Not System.IO.Directory.Exists(xmlPathLayouts) Then
                System.IO.Directory.CreateDirectory(xmlPathLayouts)
            End If
            Dim sEmpresaXML As String
            Try
                Dim cXML As ClassXML = New ClassXML()
                sEmpresaXML = cXML.pegaStringXML(xmlString, "Empresa")
            Catch
                sEmpresaXML = ""
            End Try

            Dim selEmp = New ClassParametros()
            Dim datRead = selEmp.selEmpresa()
            Do Until datRead.read = False
                Dim vItem As String = datRead("Empresa")
                txtEmpresa.Items.Add(vItem)
            Loop

            If sEmpresaXML <> "" Then
                txtEmpresa.SelectedItem = sEmpresaXML
                txtSenha.Select()
            Else
                txtEmpresa.SelectedValue = 0
                txtEmpresa.Select()
            End If

            'LabelControl1.Text = "Versão: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
            LabelControl1.Text = "Versão: 2.0.001"
            '        Dim odr As System.Net.IPAddress = New System.Net.IPAddress()
            Dim nome As String = My.User.Name
            Dim quebra As Array = Split(nome, "\", , CompareMethod.Text)
            txtLogin.Text = quebra(1)

            Dim sHostName As String = Dns.GetHostName()
            Dim ipE As IPHostEntry = Dns.GetHostByName(sHostName)
            Dim IpA As IPAddress() = ipE.AddressList
            Dim str As String = ""
            str = IpA(0).ToString()
            Dim quebraT As Array = Split(str, ".", , CompareMethod.Text)
            gTerminal = quebraT(3)


            gA = True
            gB = False
        End If
    End Sub


    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Entrar.Click
        Dim erro As ErrorProvider = New ErrorProvider()
        If txtEmpresa.Text <> "" Then
            Dim Usuario As ClassUsuarios = New ClassUsuarios()
            If txtLogin.Text <> "" Then
                'primeiro passo, autentica na base prisma
                Dim valUsuario As String = Usuario.autenticaPrisma(txtLogin.Text, txtSenha.Text, txtEmpresa.SelectedItem)
                If valUsuario <> "" Then
                    gEmpresa = Usuario.gEmpresa
                    gDataSource = Usuario.sDataSource
                    gUserID = Usuario.sUserID
                    gSetor = Usuario.sSetor
                    gPWD = Usuario.sPWD
                    gInitialCatalog = Usuario.sInitialCatalog

                    gDataSourceAux = Usuario.sDataSourceAux
                    gUserIDAux = Usuario.sUserIDAux
                    gPWDAux = Usuario.sPWDAux
                    gInitialCatalogAux = Usuario.sInitialCatalogAux

                    gNomeEmpresa = Usuario.sNomeEmpresa

                    gFantasia = Usuario.sFantasia
                    gIDUsuario = Usuario.iIDUsuario
                    gIDEmpresa = Usuario.gIDEmpresa
                    gUsuario = txtLogin.Text
                    gCDPerfil = Usuario.iCDPerfil
                    gEndereco = Usuario.sEndereco
                    gNumero = Usuario.iNumero
                    gBairro = Usuario.sBairro
                    gCidade = Usuario.sCidade
                    gMunicipioEmissor = Usuario.sMunicipioEmissor
                    gsUFEmissor = Usuario.sUFEmissor
                    gUFEmissor = Usuario.iUFEmissor
                    gLogo = Usuario.sLogo
                    gLogoDanfe = Usuario.sLogoDanfe
                    gLogoWeb = Usuario.sLogoWeb
                    gCNPJ = Usuario.sCNPJ
                    gIE = Usuario.sIE
                    gCEP = Usuario.sCEP
                    gFone = Usuario.sFone
                    gEmailNFE = Usuario.sEmailNFE
                    gTpAmb = Usuario.iTpAmb
                    gComplemento = Usuario.sComplemento
                    gEmailPedidos = Usuario.sEmailPedido
                    gEmailContasAReceber = Usuario.sEmailContasAReceber
                    gEmailContasAPagar = Usuario.sEmailContasAPagar
                    gCertificadoDigital = Usuario.sCertificadoDigital
                    gCertificadoSenha = Usuario.sCertificadoSenha
                    gPathXML = Usuario.sPathXML
                    gPathBoleto = Usuario.sPathBoleto
                    gPathFotos = Usuario.sPathFotos
                    gBanco = Usuario.sBanco
                    gAgencia = Usuario.sAgencia
                    gContaCorrente = Usuario.sContaCorrente
                    gBanco2 = Usuario.sBanco2
                    gAgencia2 = Usuario.sAgencia2
                    gContaCorrente2 = Usuario.sContaCorrente2
                    gPathCNAB = Usuario.sPathCNAB
                    gDominio = Usuario.sDominio
                    gDadosDeposito1 = Usuario.sDadosDeposito1
                    gDadosDeposito2 = Usuario.sDadosDeposito2
                    gEmailAlmoxarife = Usuario.sEmailAlmoxarife
                    gListaPadrao = Usuario.sListaPadrao

                    gdPrazoDeEntrega = 21


                    'Dados do banco Legado
                    gDataSourceLegado = Usuario.sDataSourceLegado
                    gUserIDLegado = Usuario.sUserIDLegado
                    gPWDLegado = Usuario.sPWDLegado
                    gInitialCatalogLegado = Usuario.sInitialCatalogLegado

                    'Dados do banco Legado Auxiliar
                    gDataSourceLegadoAux = Usuario.sDataSourceLegadoAux
                    gUserIDLegadoAux = Usuario.sUserIDLegadoAux
                    gPWDLegadoAux = Usuario.sPWDAux
                    gInitialCatalogLegadoAux = Usuario.sInitialCatalogLegadoAux


                    '#SELECIONA AS PERMISSOES DAS PROCEDURES DA EMPRESA
                    bChecaEstoque = Usuario.selProceduresPrisma(gIDEmpresa, "pedidoVerificaEstoque")
                    bGeraOPPedido = Usuario.selProceduresPrisma(gIDEmpresa, "gerarOPPedido")
                    bTecidoFornecido = Usuario.selProceduresPrisma(gIDEmpresa, "tecidoFornecido")
                    bBaixaEstoque = Usuario.selProceduresPrisma(gIDEmpresa, "baixaEstoque")
                    bDividePedido = Usuario.selProceduresPrisma(gIDEmpresa, "divisaoPedidoItens")
                    bPedidoChecaLimiteCredito = Usuario.selProceduresPrisma(gIDEmpresa, "pedidoChecaLimiteCredito")
                    bPedidoChecaRestricaoFinanceira = Usuario.selProceduresPrisma(gIDEmpresa, "pedidoChecaRestricaoFinanceira")
                    bTravaPedidoUsuario = Usuario.selProceduresPrisma(gIDEmpresa, "travaPedidoUsuario")
                    bPedidoOrdenaPorItem = Usuario.selProceduresPrisma(gIDEmpresa, "pedidoOrdenaPorItem")


                    '###PATHS DO XML DA NFE
                    If gTpAmb = 2 Then
                        xmlPathCancNFeCabeca = "C:\Prisma\Xml\XmlHomologacao\cancNFe_Cabeca.xml"
                        xmlPathConsCadCabeca = "C:\Prisma\Xml\XmlHomologacao\consCad_Cabeca.xml"
                        xmlPathConsProcLoteCabeca = "C:\Prisma\Xml\XmlHomologacao\ConsProcLoteNFe_Cabeca.xml"
                        xmlPathConsProcLoteDados = "C:\Prisma\Xml\XmlHomologacao\ConsProcLoteNFe_Dados.xml"
                        xmlPathConsReciNFeCabeca = "C:\Prisma\Xml\XmlHomologacao\consReciNFe_Cabeca.xml"
                        xmlPathConsSitNFeCabeca = "C:\Prisma\Xml\XmlHomologacao\consSitNFe_Cabeca.xml"
                        xmlPathConsStatServCabeca = "C:\Prisma\Xml\XmlHomologacao\consStatServ_Cabeca.xml"
                        xmlPathConsStatServDados = "C:\Prisma\Xml\XmlHomologacao\consStatServ_Dados.xml"
                        xmlPathEnvLote = "C:\Prisma\Xml\XmlHomologacao\EnvLoteNFe_Cabeca.xml"
                        xmlPathInutNfe = "C:\Prisma\Xml\XmlHomologacao\InutNFe_Cabeca.xml"
                    ElseIf gTpAmb = 1 Then
                        xmlPathCancNFeCabeca = "C:\Prisma\Xml\XmlProducao\cancNFe_Cabeca.xml"
                        xmlPathConsCadCabeca = "C:\Prisma\Xml\XmlProducao\consCad_Cabeca.xml"
                        xmlPathConsProcLoteCabeca = "C:\Prisma\Xml\XmlProducao\ConsProcLoteNFe_Cabeca.xml"
                        xmlPathConsProcLoteDados = "C:\Prisma\Xml\XmlProducao\ConsProcLoteNFe_Dados.xml"
                        xmlPathConsReciNFeCabeca = "C:\Prisma\Xml\XmlProducao\consReciNFe_Cabeca.xml"
                        xmlPathConsSitNFeCabeca = "C:\Prisma\Xml\XmlProducao\consSitNFe_Cabeca.xml"
                        xmlPathConsStatServCabeca = "C:\Prisma\Xml\XmlProducao\consStatServ_Cabeca.xml"
                        xmlPathConsStatServDados = "C:\Prisma\Xml\XmlProducao\consStatServ_Dados.xml"
                        xmlPathEnvLote = "C:\Prisma\Xml\XmlProducao\EnvLoteNFe_Cabeca.xml"
                        xmlPathInutNfe = "C:\Prisma\Xml\XmlProducao\InutNFe_Cabeca.xml"
                    End If

                    '#####################
                    '###Grava XML de Logins
                    Dim writer As New XmlTextWriter(xmlString, System.Text.Encoding.UTF8)
                    writer.Formatting = Formatting.Indented
                    writer.WriteStartDocument()

                    '#Abre Header
                    writer.WriteStartElement("autenticacao")
                    writer.WriteElementString("Empresa", gNomeEmpresa)
                    writer.WriteElementString("CDEmpresa", gIDEmpresa)
                    writer.WriteEndElement()
                    writer.WriteEndDocument()
                    '#### FIM DO DOCUMENTO
                    writer.Flush()
                    writer.Close()

                    gConSTR = "Integrated Security=False; Data Source=" & gDataSource & "; User ID=" & gUserID & "; Pwd=" & gPWD & "; Initial Catalog=" & gInitialCatalog & ";"

                    conSQLY.ConnectionString = gConSTR
                    conSQLY1.ConnectionString = gConSTR
                    conSQLY2.ConnectionString = gConSTR
                    conSQLY3.ConnectionString = gConSTR
                    conSQLY4.ConnectionString = gConSTR

                    Dim frmMen As frmMenuRibbon = New frmMenuRibbon()
                    frmMen.Show()
                    Me.Hide()
                Else
                    erro.SetError(txtLogin, "Usuário ou senha inválido!")
                End If
            Else
                erro.SetError(txtLogin, "Preencha todos os dados!")
            End If
        Else
            erro.SetError(txtEmpresa, "Selecione a Empresa")
        End If
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Sair.Click
        End
    End Sub
End Class