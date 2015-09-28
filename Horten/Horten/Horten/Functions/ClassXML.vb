Imports System.Xml
Imports System.Math
Imports System.IO
Imports System.Xml.Schema
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Public Class ClassXML
    Public Function readXML(ByVal sArquivo As String) As String
        Dim sString2 As String = ""
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Do While (reader2.Read())
            Select Case reader2.NodeType
                Case XmlNodeType.XmlDeclaration
                    sString2 = sString2 & "<?" & reader2.Name & " " & reader2.Value & "?>" & vbCrLf
                Case XmlNodeType.Element 'Display beginning of element.
                    sString2 = sString2 & "<" & reader2.Name & ""

                    If reader2.HasAttributes Then 'If attributes exist
                        While reader2.MoveToNextAttribute()
                            'Display attribute name and value.
                            sString2 = sString2 & " " & reader2.Name & "=""" & reader2.Value & """"
                        End While
                    End If
                    sString2 = sString2 & ">"

                Case XmlNodeType.Text 'Display the text in each element.
                    sString2 = sString2 & reader2.Value
                Case XmlNodeType.EndElement 'Display end of element.
                    sString2 = sString2 & "</" & reader2.Name & ">" & vbCrLf
            End Select
        Loop
        Return sString2
    End Function
    Public Sub gravaEnviNFe()
        Dim sArquivoNovo As String = gPathXML & "\" & gCVAcesso & "-ENV.xml"
        Dim sArquivo As String = gPathXML & "\" & gCVAcesso & ".xml"

        Dim docOld As XmlDocument = New XmlDocument()
        Dim docNew As XmlDocument = New XmlDocument()

        'cria arquivo novo
        Dim bGrava As Boolean = gravaXMLRecebido("<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">", sArquivoNovo)
        Try
            docNew.Load(sArquivoNovo)
            docOld.Load(sArquivo)
            docOld.PreserveWhitespace = False

            '#### criar tag nfe
            Dim objXmlNodeListNFe As System.Xml.XmlNodeList
            Dim objXmlNodeNFe As System.Xml.XmlNode
            Dim objXmlNodeNovo As System.Xml.XmlNode

            objXmlNodeNFe = docOld.DocumentElement
            objXmlNodeListNFe = objXmlNodeNFe.ChildNodes
            For Each objXmlNodeNFe In objXmlNodeListNFe
                Dim s As String = objXmlNodeNFe.Name.ToString()
                If objXmlNodeNFe.Name.ToString() = "infNFe" Then
                    objXmlNodeNovo = objXmlNodeNFe
                    docNew.DocumentElement.AppendChild(docNew.ImportNode(objXmlNodeNFe, True))
                End If
                If objXmlNodeNFe.Name.ToString() = "Signature" Then
                    objXmlNodeNovo = objXmlNodeNFe
                    docNew.DocumentElement.AppendChild(docNew.ImportNode(objXmlNodeNFe, True))
                End If
            Next
            docNew.Save(sArquivo)
            IO.File.Delete(sArquivoNovo)
        Catch
        End Try
        'Dim sArquivoNovo As String = gPathXML & "\" & gCVAcesso & "-ENV.xml"
        'Dim sArquivo As String = gPathXML & "\" & gCVAcesso & ".xml"

        'Dim docOld As XmlDocument = New XmlDocument()
        'Dim docNew As XmlDocument = New XmlDocument()

        ''cria arquivo novo
        'Dim bGrava As Boolean = gravaXMLRecebido("<enviNFe versao=""1.10"" xmlns=""http://www.portalfiscal.inf.br/nfe""><idLote>2</idLote></enviNFe>", sArquivoNovo)
        'Try
        '    docNew.Load(sArquivoNovo)
        '    docOld.Load(sArquivo)
        '    docOld.PreserveWhitespace = False

        '    Dim objXmlNodeNFe As System.Xml.XmlNode
        '    objXmlNodeNFe = docOld.DocumentElement
        '    Dim mNode1 As XmlElement = docNew.ImportNode(objXmlNodeNFe, True)
        '    docNew.AppendChild(mNode1)
        '    docNew.Save(sArquivoNovo)
        '    '            IO.File.Delete(sArquivo)
    End Sub

    Public Function gravaNFE(ByVal gCVAcesso As String, ByVal cNF As String, ByVal sNF As String, ByVal iDV As Integer, ByVal sCDPedido As String, ByVal cbCDCliente As String, ByVal cbNatOp As String, ByVal cbIndPag As String, ByVal bEntrada As Boolean, _
                            ByVal txtCGC As String, ByVal txtTipoEndereco As String, ByVal txtLogradouro As String, ByVal txtNumero As String, ByVal txtBairro As String, ByVal CDMunicipio As String, ByVal cbMunicipio As String, ByVal cbUF As String, ByVal CDUF As Integer, _
                            ByVal txtCEP As String, ByVal CDPais As String, ByVal cbPais As String, ByVal txtInscEst As String, ByVal txtInscEstST As String, ByVal txtSuframa As String, ByVal txtValorICMS As Decimal, ByVal txtBCICMS As String, ByVal txtAbatimento As Decimal, ByVal txtAcrescimo As Decimal, ByVal cbModalidadeFrete As String, ByVal txtTranspCNPJ As String, ByVal cbTransportadora As String, _
                            ByVal txtTranspInscEst As String, ByVal txtTranspLogradouro As String, ByVal cbTranspUF As String, ByVal cbTranspMunicipio As String, ByVal txtVeiculoRNTC As String, ByVal txtVolumeQtde As Decimal, ByVal txtVolumeEspecie As String, _
                            ByVal txtVolumeMarca As String, ByVal txtVolumeNumero As String, ByVal txtVolumePesoL As Decimal, ByVal txtVolumePesoB As Decimal, ByVal txtNumeroFatura As String, ByVal txtInfAdicional As String, ByVal txtInfAdicContribuinte As String, _
    ByVal cbUFEmbarque As String, ByVal txtLocalEmbarque As String, ByVal bChecarEstoque As Boolean, ByVal sFinNFe As String, ByVal sRefNFe As String) As Boolean
        Dim conn As New PrismaLibrary.ClassSqlConnection
        Dim xmlPath As String = gPathXML & "\" & gCVAcesso & ".xml"

        Dim writer As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()
        Try
            writer.WriteStartElement("NFe")
            writer.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")

            ' Criar o elemento "Favoritos" e alguns dados
            writer.WriteStartElement("infNFe")
            'writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            writer.WriteAttributeString("versao", "1.10")
            writer.WriteAttributeString("Id", "NFe" & gCVAcesso)


            '#### DADOS DE IDENTIFICACAO DA NFE
            writer.WriteStartElement("ide")
            writer.WriteElementString("cUF", gUFEmissor) 'uf emissor
            writer.WriteElementString("cNF", cNF) 'Codigo de acesso gerado aleatoriamente
            Dim lCBNatOp As Integer = cbNatOp.Length
            lCBNatOp = lCBNatOp - 6
            cbNatOp = cbNatOp.Substring(6, lCBNatOp)

            writer.WriteElementString("natOp", tiraAcentos(Trim(cbNatOp))) 'Natureza de operacao
            writer.WriteElementString("indPag", cbIndPag) 'indicacao da forma de pagamento
            writer.WriteElementString("mod", "55") 'modelo da nf
            writer.WriteElementString("serie", "0") 'serie da nf
            writer.WriteElementString("nNF", sNF) 'numero da nota

            Dim dDate As DateTime = DateTime.Now
            Dim dEmi As String = Format(dDate, "yyyy") & "-" & Format(dDate, "MM") & "-" & Format(dDate, "dd")

            writer.WriteElementString("dEmi", dEmi) 'data de emissao 
            writer.WriteElementString("dSaiEnt", dEmi) 'Data de saida/entrada
            If bEntrada = True Then
                writer.WriteElementString("tpNF", 0) 'tipo NF 0 entrada
            Else
                writer.WriteElementString("tpNF", 1) ' tipo NF 1 Saida
            End If
            writer.WriteElementString("cMunFG", gMunicipioEmissor) 'Codigo do municipio do emitente

            If sFinNFe = 2 Then
                writer.WriteStartElement("NFref")
                writer.WriteElementString("refNFe", sRefNFe) 'Chave de acesso das nfe referenciadas
                writer.WriteEndElement() 'fecha nfref
            End If


            writer.WriteElementString("tpImp", 1) 'Tipo de impressao
            writer.WriteElementString("tpEmis", 1) 'tipo de emissao de nf 1-normal 2-contigencia 3-scan 4-dpec 5 fs-da
            writer.WriteElementString("cDV", iDV) 'Digito verificado da chave de acesso 
            writer.WriteElementString("tpAmb", gTpAmb) 'tipo de ambiente 1-producao 2-homologacao 3-scan
            writer.WriteElementString("finNFe", sFinNFe) 'Finalidade da emissao 1-normal 2-complementar 3-nfe de ajuste
            writer.WriteElementString("procEmi", 0) 'processo de emissao da nf 0-com aplicativo do contribuinte
            writer.WriteElementString("verProc", "1.0.0.0") 'informar versao do aplicativo emissor
            writer.WriteEndElement()
            '#### FIM DA IDENTIFICACAO DA NFE


            '####DADOS DO EMITENTE
            writer.WriteStartElement("emit")
            If gCNPJ.Length < 14 Then
                writer.WriteElementString("CPF", gCNPJ) 'CNPJ do emitente
            Else
                writer.WriteElementString("CNPJ", gCNPJ) 'CNPJ do emitente
            End If
            writer.WriteElementString("xNome", tiraAcentos(Trim(gNomeEmpresa)))
            writer.WriteElementString("xFant", tiraAcentos(Trim(gFantasia)))


            '#### ENDERECO DO EMITENTE
            writer.WriteStartElement("enderEmit")
            writer.WriteElementString("xLgr", tiraAcentos(gEndereco)) 'endereco
            writer.WriteElementString("nro", gNumero) 'Numero 
            writer.WriteElementString("xBairro", tiraAcentos(gBairro)) 'Bairro
            writer.WriteElementString("cMun", gMunicipioEmissor) 'Municipio
            writer.WriteElementString("xMun", "Sao Paulo") 'Nome do Municipio
            writer.WriteElementString("UF", gsUFEmissor) 'Sigla da UF
            writer.WriteElementString("CEP", gCEP)
            writer.WriteElementString("cPais", "1058") 'Codigo do Pais
            writer.WriteElementString("xPais", "Brasil") 'Nome do Pais
            writer.WriteEndElement()
            '### FIM DO ENDERECO DO EMITENTE

            writer.WriteElementString("IE", gIE)
            If txtInscEstST <> "" Then
                writer.WriteElementString("IEST", txtInscEstST)
            End If
            writer.WriteEndElement()
            '### FIM DOS DADOS DO EMITENTE



            '####DADOS DO DESTINATARIO
            writer.WriteStartElement("dest")
            If txtCGC.Length < 14 Then
                writer.WriteElementString("CPF", txtCGC) 'CNPJ do destinatario
            Else
                'MessageBox.Show(txtCGC.Substring(0, 6))
                If txtCGC.Substring(0, 6) <> "000000" Then
                    writer.WriteElementString("CNPJ", txtCGC) 'CNPJ do destinatario
                Else
                    writer.WriteElementString("CNPJ", "") 'CNPJ do destinatario
                End If
            End If
            writer.WriteElementString("xNome", tiraAcentos(Trim(cbCDCliente)))

            '#### ENDERECO DO DESTINATARIO
            writer.WriteStartElement("enderDest")
            writer.WriteElementString("xLgr", txtTipoEndereco & " " & tiraAcentos(txtLogradouro)) 'endereco
            writer.WriteElementString("nro", txtNumero) 'Numero 
            writer.WriteElementString("xBairro", txtBairro) 'Bairro
            writer.WriteElementString("cMun", CDMunicipio) 'Municipio
            writer.WriteElementString("xMun", tiraAcentos(cbMunicipio)) 'Nome do Municipio
            writer.WriteElementString("UF", cbUF) 'Sigla da UF
            writer.WriteElementString("CEP", txtCEP)
            writer.WriteElementString("cPais", CDPais) 'Codigo do Pais
            writer.WriteElementString("xPais", cbPais) 'Nome do Pais
            writer.WriteEndElement()
            '### FIM DO ENDERECO DO DESTINATARIO

            writer.WriteElementString("IE", txtInscEst.Replace(",", ""))

            If txtSuframa <> "" Then
                writer.WriteElementString("ISUF", txtSuframa)
            End If
            writer.WriteEndElement()
            '#### FIM DOS DADOS DO DESTINATARIO



            '### IDENTIFICACAO DO LOCAL DE RETIRADA



            '### IDENTIFICACAO DO LOCAL DE ENTREGA



            '### DETALHAMENTO DOS PRODUTOS
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQl.Connection = conSQL2
            If sFinNFe = 1 Then '# se a finalidade for faturamento
                querySQl.CommandText = "select * from TMP_ItemPed where CDPedido='" & sCDPedido & "' and CDEmpresa='" & gEmpresa & "' and Saldo > 0 order by CDItem"
            Else
                querySQl.CommandText = "select * from TMP_ItemPed where CDPedido='" & sCDPedido & "' and CDEmpresa='" & gEmpresa & "' order by CDItem"
            End If
            datRead = querySQl.ExecuteReader()
            Dim x As Integer = 1
            Dim dVLUnitario, dVLTotalLinha, dSaldo As Decimal
            Dim dAliquotaPIS, dAliquotaCofins, dAliquotaIPI, dAliquotaICMS As Decimal
            Dim dValorICMS, dValorIPI, dValorCofins, dValorPIS As Decimal
            Dim selCFOP As PrismaLibrary.ClassNatOperacao = New PrismaLibrary.ClassNatOperacao()
            Dim cPedidos As PrismaLibrary.ClassPedidosItensG = New PrismaLibrary.ClassPedidosItensG()
            Dim sCFOP As String = ""
            Dim sNCM As String
            Dim bTemEstoque As Boolean = True
            Dim dBCICMS, dBCICMSAcum, dBCPIS, dBCPISAcum, dBCIPI, dBCIPIAcum, dBCCofins, dBCCofinsAcum As Decimal
            Do Until datRead.Read = False
                dSaldo = datRead("Saldo")
                dVLUnitario = datRead("VLUnitario")
                dVLTotalLinha = dSaldo * dVLUnitario

                dAliquotaPIS = datRead("PIS")
                dAliquotaCofins = datRead("Cofins")
                dAliquotaIPI = datRead("IPI")
                dAliquotaICMS = datRead("ICMS")

                writer.WriteStartElement("det")
                writer.WriteAttributeString("nItem", x)

                writer.WriteStartElement("prod")
                writer.WriteElementString("cProd", datRead("CDProduto")) 'Código do produto

                selCFOP.selNatOperacaoPorCodigo(gEmpresa, datRead("CFOP"), gDataSource, gUserID, gPWD, gInitialCatalog)
                sCFOP = selCFOP.sNome

                If selCFOP.bBaixarEstoque = True And sFinNFe = 1 Then
                    If bChecarEstoque = True Then
                        bTemEstoque = cPedidos.checaEstoque(gEmpresa, datRead("CDProduto"), dSaldo, gDataSource, gUserID, gPWD, gInitialCatalog)
                        If bTemEstoque = False Then
                            MessageBox.Show("Impossivel faturar, existe um item sem saldo: " & datRead("CDProduto") & "", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            writer.WriteEndDocument()
                            '#### FIM DO DOCUMENTO
                            writer.Flush()
                            writer.Close()
                            Return False
                            Exit Function
                        End If
                    End If
                End If

                writer.WriteElementString("cEAN", "")
                writer.WriteElementString("xProd", tiraAcentos(Trim(datRead("Descricao")))) 'descricao do produto
                sNCM = datRead("CDClasf")
                If sNCM <> "" Then
                    sNCM = sNCM.Replace(".", "")
                    writer.WriteElementString("NCM", sNCM) 'Classificacao fiscal
                    writer.WriteElementString("genero", sNCM.Substring(0, 2)) 'dois primeiros numeros da Classificacao Fiscal
                End If
                'writer.WriteElementString("EXTIPI", "???")

                writer.WriteElementString("CFOP", sCFOP) 'CFOP do item
                writer.WriteElementString("uCom", datRead("Unidade")) 'unidade de medida
                writer.WriteElementString("qCom", CDBNumber(dSaldo, 4))
                writer.WriteElementString("vUnCom", CDBNumber(dVLUnitario, 4)) 'Valor Unitario
                writer.WriteElementString("vProd", CDBNumber(dVLTotalLinha, 2)) 'Valor da linha
                writer.WriteElementString("cEANTrib", "")

                writer.WriteElementString("uTrib", datRead("Unidade")) 'Unidade Tributavel
                writer.WriteElementString("qTrib", CDBNumber(dSaldo, 4)) ' Quantidade tributavel
                writer.WriteElementString("vUnTrib", CDBNumber(dVLUnitario, 4)) 'Valor unitario tributavel
                writer.WriteEndElement()
                '### FECHA TAG PROD



                '#################################################################################################################
                '#### ABRE BLOCO DE IMPOSTO
                writer.WriteStartElement("imposto")


                '#Selecionar CFOP para ver se incide ICMSST
                Dim dIVA As Decimal
                selCFOP.selNatOperacaoPorCodigo(gEmpresa, datRead("CFOP"), gDataSource, gUserID, gPWD, gInitialCatalog)
                'selCFOP.selIVAPorSigla(cbUF, datRead("CDClasf"), 3, gDataSource, gUserID, gPWD, gInitialCatalog, 3)
                dIVA = selCFOP.dIVA

                dIVA = (dIVA * 100) - 100
                Dim vBCST, pICMSST, vICMSST As Decimal
                pICMSST = selCFOP.dICMSIVA '#####ALIQUOTA DE ICMS USADA QUANDO TEM ST


                '#### COLOCA TODAS BASE DE CALCULO
                If selCFOP.bIncideICMS = True Then
                    dBCICMS = dVLTotalLinha
                    dBCICMSAcum = dBCICMSAcum + dBCICMS
                End If
                If selCFOP.bIncidePIS = True Then
                    dBCPIS = dVLTotalLinha
                    dBCPISAcum = dBCPISAcum + dBCPIS
                End If
                If selCFOP.bIncideCofins = True Then
                    dBCCofins = dVLTotalLinha
                    dBCCofinsAcum = dBCPISAcum + dBCCofins
                End If
                If selCFOP.bIncideIPI = True Then
                    dBCIPI = dVLTotalLinha
                    dBCIPIAcum = dBCPISAcum + dBCIPI
                End If


                '### BLOCO DE ICMS
                writer.WriteStartElement("ICMS")
                If datRead("CSTICMS") = "00" Then
                    writer.WriteStartElement("ICMS00")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", "00")
                    writer.WriteElementString("modBC", "3") ' modalidade de determinacao da BC do ICMS
                    writer.WriteElementString("vBC", CDBNumber(dBCICMS, 2)) ' Valor da BC do ICMS
                    writer.WriteElementString("pICMS", CDBNumber(dAliquotaICMS, 2)) 'Aliquota
                    dValorICMS = (dAliquotaICMS * dVLTotalLinha) / 100
                    writer.WriteElementString("vICMS", CDBNumber(dValorICMS, 2)) 'Valor do imposto
                    writer.WriteEndElement()
                ElseIf datRead("CSTICMS") = "10" Then
                    writer.WriteStartElement("ICMS10")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", "10")
                    writer.WriteElementString("modBC", "3") ' modalidade de determinacao da BC do ICMS
                    writer.WriteElementString("vBC", CDBNumber(dBCICMS, 2)) ' Valor da BC do ICMS
                    writer.WriteElementString("pICMS", CDBNumber(dAliquotaICMS, 2)) 'Aliquota
                    dValorICMS = (dAliquotaICMS * dVLTotalLinha) / 100
                    writer.WriteElementString("vICMS", CDBNumber(dValorICMS, 2)) 'Valor do imposto
                    writer.WriteElementString("modBCST", "4") 'Modalidade de determinacao de BC do ICMSST
                    writer.WriteElementString("pMVAST", CDBNumber(dIVA, 2)) 'percentual de margem de valor adicionado do ICMSST
                    'writer.WriteElementString("pRedBCST", "????") 'percentual de reducao de BC do ICMSST

                    'Precisa do IPI para fazer a BC do ICMSST
                    dValorIPI = (dAliquotaIPI * dVLTotalLinha) / 100

                    'vBCST = Total do produto + total de ipi * o iva
                    vBCST = dVLTotalLinha + dValorIPI + ((dVLTotalLinha + dValorIPI) * dIVA) / 100

                    'vICMSST = BC * aliquitoa de icms - icms original
                    vICMSST = (vBCST * (pICMSST / 100)) - dValorICMS
                    writer.WriteElementString("vBCST", CDBNumber(vBCST, 2)) ' Valor da BC do ICMSST
                    writer.WriteElementString("pICMSST", CDBNumber(pICMSST, 2)) 'Aliquota do imposto do ICMSST - Verificar se nao eh o de destino
                    writer.WriteElementString("vICMSST", CDBNumber(vICMSST, 2)) 'valor do icmsst
                    writer.WriteEndElement()
                ElseIf datRead("CSTICMS") = "20" Then
                    writer.WriteStartElement("ICMS20")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", "20")
                    writer.WriteElementString("modBC", "3") ' modalidade de determinacao da BC do ICMS
                    writer.WriteElementString("pRedBC", "33.33") 'percentual de reducao de BC do ICMS

                    writer.WriteElementString("vBC", CDBNumber(dBCICMS, 2)) ' Valor da BC do ICMS
                    writer.WriteElementString("pICMS", CDBNumber(dAliquotaICMS, 2)) 'Aliquota
                    dValorICMS = (dAliquotaICMS * dVLTotalLinha) / 100
                    writer.WriteElementString("vICMS", CDBNumber(dValorICMS, 2)) 'Valor do imposto
                    writer.WriteEndElement()
                ElseIf datRead("CSTICMS") = "40" Or datRead("CSTICMS") = "41" Or datRead("CSTICMS") = "50" Then
                    writer.WriteStartElement("ICMS40")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", datRead("CSTICMS"))
                    writer.WriteEndElement()
                ElseIf datRead("CSTICMS") = "51" Then
                    writer.WriteStartElement("ICMS51")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", "51")
                    writer.WriteElementString("modBC", "3") ' modalidade de determinacao da BC do ICMS
                    '                writer.WriteElementString("pRedBC", "????") 'percentual de reducao de BC do ICMS
                    writer.WriteElementString("vBC", CDBNumber(dBCICMS, 2)) ' Valor da BC do ICMS
                    writer.WriteElementString("pICMS", CDBNumber(dAliquotaICMS, 2)) 'Aliquota
                    dValorICMS = (dAliquotaICMS * dVLTotalLinha) / 100
                    writer.WriteElementString("vICMS", CDBNumber(dValorICMS, 2)) 'Valor do imposto
                    writer.WriteEndElement()
                ElseIf datRead("CSTICMS") = "90" Then
                    writer.WriteStartElement("ICMS90")
                    writer.WriteElementString("orig", 0) 'Origem da mercadoria - Nacional
                    writer.WriteElementString("CST", "90")
                    writer.WriteElementString("modBC", "3") ' modalidade de determinacao da BC do ICMS
                    writer.WriteElementString("vBC", CDBNumber(dBCICMS, 2)) ' Valor da BC do ICMS
                    writer.WriteElementString("pRedBC", "????") 'percentual de reducao de BC do ICMS
                    writer.WriteElementString("pICMS", CDBNumber(dAliquotaICMS, 2)) 'Aliquota
                    dValorICMS = (dAliquotaICMS * dVLTotalLinha) / 100
                    writer.WriteElementString("vICMS", CDBNumber(dValorICMS, 2)) 'Valor do imposto
                    writer.WriteElementString("modBCST", "4") 'Modalidade de determinacao de BC do ICMSST
                    writer.WriteElementString("pMVAST", "????") 'percentual de margem de valor adicionado do ICMSST
                    writer.WriteElementString("pRedBCST", "????") 'percentual de reducao de BC do ICMSST
                    writer.WriteElementString("vBCST", "???") ' Valor da BC do ICMSST
                    writer.WriteElementString("pICMSST", "????") 'Aliquota do imposto do ICMSST
                    writer.WriteElementString("vICMSST", "????") 'valor do icmsst
                    writer.WriteEndElement()
                End If
                writer.WriteEndElement()
                '### FECHA BLOCO DO ICMS

                '### BLOCO DE IPI
                writer.WriteStartElement("IPI")
                writer.WriteElementString("cEnq", "999") 'Classe do enquadramento do IPI
                If datRead("CSTIPI") = "00" Or datRead("CSTIPI") = "49" Or datRead("CSTIPI") = "50" Or datRead("CSTIPI") = "99" Then
                    writer.WriteStartElement("IPITrib")
                    writer.WriteElementString("CST", datRead("CSTIPI")) ' CST do IPI
                    writer.WriteElementString("vBC", CDBNumber(dBCIPI, 2)) 'BC do IPI
                    ' writer.WriteElementString("qUnid", "???") 'Quantidade total na unidade padrao para tributacao
                    writer.WriteElementString("pIPI", CDBNumber(dAliquotaIPI, 2)) ' Aliquota de ipi
                    dValorIPI = (dAliquotaIPI * dVLTotalLinha) / 100
                    writer.WriteElementString("vIPI", CDBNumber(dValorIPI, 2))
                    writer.WriteEndElement()
                Else
                    writer.WriteStartElement("IPINT")
                    writer.WriteElementString("CST", datRead("CSTIPI")) ' CST do IPI
                    writer.WriteEndElement()
                End If
                writer.WriteEndElement()
                '### FECHA BLOCO DO IPI


                '### BLOCO DE IMPOSTO DE IMPORTACAO

                '### BLOCO DE PIS
                writer.WriteStartElement("PIS")
                If datRead("CSTPIS") = "01" Or datRead("PIS") = "02" Then
                    writer.WriteStartElement("PISAliq")
                    writer.WriteElementString("CST", datRead("CSTPIS")) ' CST do PIS
                    writer.WriteElementString("vBC", CDBNumber(dBCPIS, 2)) 'base de calculo do pis
                    writer.WriteElementString("pPIS", CDBNumber(dAliquotaPIS, 2)) ' aliquota do pis em percentual
                    dValorPIS = (dAliquotaPIS * dVLTotalLinha) / 100
                    writer.WriteElementString("vPIS", CDBNumber(dValorPIS, 2)) 'Valor do PIS
                    writer.WriteEndElement()
                ElseIf datRead("CSTPIS") = "03" Then
                    writer.WriteStartElement("PISQtde")
                    writer.WriteElementString("CST", datRead("CSTPIS")) ' CST do PIS
                    writer.WriteElementString("qBCProd", "????") ' Quantidade Vendida
                    writer.WriteElementString("vAliqPrd", "???") ' Aliquota do pis em reais
                    writer.WriteElementString("vPIS", CDBNumber(dValorPIS, 2)) 'valor do PIS
                    writer.WriteEndElement()
                ElseIf datRead("CSTPIS") = "04" Or datRead("CSTPIS") = "06" Or datRead("CSTPIS") = "07" Or datRead("CSTPIS") = "08" Or datRead("CSTPIS") = "09" Then
                    writer.WriteStartElement("PISNT")
                    writer.WriteElementString("CST", datRead("CSTPIS")) ' CST do PIS
                    writer.WriteEndElement()
                ElseIf datRead("CSTPIS") = "99" Then
                    writer.WriteStartElement("PISOutr")
                    writer.WriteElementString("CST", datRead("CSTPIS")) ' CST do PIS
                    writer.WriteElementString("vBC", CDBNumber(dBCPIS, 2)) 'base de calculo do pis
                    writer.WriteElementString("pPIS", CDBNumber(dAliquotaPIS, 2)) ' aliquota do pis em percentual
                    writer.WriteElementString("qBCProd", "????") ' Quantidade Vendida
                    writer.WriteElementString("vAliqPrd", "???") ' Aliquota do pis em reais
                    writer.WriteElementString("vPIS", CDBNumber(dValorPIS, 2)) 'valor do PIS
                    writer.WriteEndElement()
                End If
                writer.WriteEndElement()
                '#### FECHA TAG PIS


                '### BLOCO DE PISST
                'writer.WriteStartElement("PISST")
                'writer.WriteElementString("vBC", CDBNumber(dVLTotalLinha, 4)) 'base de calculo do pis
                'writer.WriteElementString("pPIS", CDBNumber(dAliquotaPIS, 2)) ' aliquota do pis em percentual
                'writer.WriteElementString("qBCProd", "????") ' Quantidade Vendida
                'writer.WriteElementString("vAliqPrd", "???") ' Aliquota do pis em reais
                'writer.WriteElementString("vPIS", "????") 'valor do PIS
                'writer.WriteEndElement()
                '#### FECHA TAG PIS ST


                '### BLOCO DE COFINS
                writer.WriteStartElement("COFINS")
                If datRead("CSTCofins") = "01" Or datRead("CSTCofins") = "02" Then
                    writer.WriteStartElement("COFINSAliq")
                    writer.WriteElementString("CST", datRead("CSTCofins"))
                    writer.WriteElementString("vBC", CDBNumber(dBCCofins, 2)) 'base de calculo da cofins
                    writer.WriteElementString("pCOFINS", CDBNumber(dAliquotaCofins, 2)) 'aliquota do cofins
                    dValorCofins = (dVLTotalLinha * dAliquotaCofins) / 100
                    writer.WriteElementString("vCOFINS", CDBNumber(dValorCofins, 2)) 'valor de cofins
                    writer.WriteEndElement()
                ElseIf datRead("CSTCofins") = "03" Then
                    writer.WriteStartElement("COFINSQtde")
                    writer.WriteElementString("CST", datRead("CSTCofins")) 'CST do Cofins
                    writer.WriteElementString("qBCProd", "???") 'Quantidades vendidas
                    writer.WriteElementString("vAliqProd", "????") 'Aliquota em reais
                    writer.WriteElementString("vCOFINS", CDBNumber(dValorCofins, 2)) 'valor do cofins
                    writer.WriteEndElement()
                ElseIf datRead("CSTCofins") = "04" Or datRead("CSTCofins") = "06" Or datRead("CSTCofins") = "07" Or datRead("CSTCofins") = "08" Or datRead("CSTCofins") = "09" Then
                    writer.WriteStartElement("COFINSNT")
                    writer.WriteElementString("CST", datRead("CSTCofins")) 'CST do Cofins
                    writer.WriteEndElement()
                ElseIf datRead("CSTCofins") = "99" Then
                    writer.WriteStartElement("COFINSOutr")
                    writer.WriteElementString("CST", datRead("CSTCofins")) 'CST do Cofins
                    writer.WriteElementString("vBC", CDBNumber(dBCCofins, 2)) 'base de calculo da cofins
                    writer.WriteElementString("pCOFINS", CDBNumber(dAliquotaCofins, 2)) 'aliquota do cofins
                    writer.WriteElementString("qBCProd", "???") 'Quantidades vendidas
                    writer.WriteElementString("vAliqProd", "????") 'Aliquota em reais
                    writer.WriteElementString("vCOFINS", CDBNumber(dValorCofins, 2)) 'valor do cofins
                    writer.WriteEndElement()
                End If
                writer.WriteEndElement()
                '#### FECHA TAG COFINS


                '#### BLOCO DO COFINS ST    
                'writer.WriteStartElement("COFINSST")
                'writer.WriteElementString("vBC", CDBNumber(dVLTotalLinha, 4)) 'base de calculo do pis
                'writer.WriteElementString("pCOFINS", CDBNumber(dAliquotaCofins, 2)) ' aliquota do pis em percentual
                'writer.WriteElementString("qBCProd", "????") ' Quantidade Vendida
                'writer.WriteElementString("vAliqPrd", "???") ' Aliquota do pis em reais
                'writer.WriteElementString("vCOFINS", "????") 'valor do COFINS
                'writer.WriteEndElement()
                '#### FECHA TAG DO COFINS ST


                '#### BLOCO DO ISSQN


                '#### INFORMACOES ADICIONAIS

                writer.WriteEndElement()
                '### FECHA BLOCO IMPOSTO
                '##########################################################################################################

                writer.WriteEndElement()
                '### FECHA TAG DET (PRODUTO)

                x = x + 1
            Loop
            datRead.Close()

            Dim vVLTotalNF As Decimal


            '##############################################################################################################
            querySQl.CommandText = "select * from TMP_PedidosStatus where CDPedido='" & sCDPedido & "' and CDEmpresa='" & gEmpresa & "'"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                '#### TOTAIS DA NOTA
                writer.WriteStartElement("total")
                writer.WriteStartElement("ICMSTot")
                Try
                    writer.WriteElementString("vBC", CDBNumber(txtBCICMS, 2)) 'Base de calculo do icms
                Catch
                    writer.WriteElementString("vBC", 0) 'Base de calculo do icms
                End Try
                Try
                    writer.WriteElementString("vICMS", CDBNumber(txtValorICMS, 2)) 'Valor total do icms
                Catch
                    writer.WriteElementString("vICMS", 0) 'Valor total do icms
                End Try
                Try
                    writer.WriteElementString("vBCST", CDBNumber(datRead("BCICMSST"), 2)) 'Valor total da base de calculo do icmsst
                Catch
                    writer.WriteElementString("vBCST", 0) 'Valor total da base de calculo do icmsst
                End Try
                Try
                    writer.WriteElementString("vST", CDBNumber(datRead("ValorICMSST"), 2)) ' valor total do icms st
                Catch
                    writer.WriteElementString("vST", 0) ' valor total do icms st
                End Try
                Try
                    writer.WriteElementString("vProd", CDBNumber(datRead("ValorTotal"), 2)) 'valor total dos produtos
                Catch
                    writer.WriteElementString("vProd", 0) 'valor total dos produtos
                End Try

                writer.WriteElementString("vFrete", CDBNumber(0, 2)) 'valor total do frete
                writer.WriteElementString("vSeg", CDBNumber(0, 2)) 'valor total do seguro
                writer.WriteElementString("vDesc", CDBNumber(0, 2)) 'valor total do desconto
                writer.WriteElementString("vII", CDBNumber(0, 2)) 'Valor total do II
                Try
                    writer.WriteElementString("vIPI", CDBNumber(datRead("ValorIPI"), 2)) 'Valor total do IPI
                Catch
                    writer.WriteElementString("vIPI", 0) 'Valor total do IPI
                End Try
                Try
                    writer.WriteElementString("vPIS", CDBNumber(datRead("ValorPIS"), 2)) 'Valor total do PIS
                Catch
                    writer.WriteElementString("vPIS", 0) 'Valor total do PIS
                End Try
                Try
                    writer.WriteElementString("vCOFINS", CDBNumber(datRead("ValorCofins"), 2)) 'Valor total do confins
                Catch
                    writer.WriteElementString("vCOFINS", 0) 'Valor total do confins
                End Try
                writer.WriteElementString("vOutro", 0) ' Valor de outras despesas
                Try
                    vVLTotalNF = datRead("ValorTotal") + datRead("ValorIPI") + datRead("ValorICMSST") - txtAbatimento + txtAcrescimo
                    writer.WriteElementString("vNF", CDBNumber(vVLTotalNF, 2)) ' Valor total da NFE
                Catch
                    writer.WriteElementString("vNF", 0) ' Valor total da NFE
                End Try
                writer.WriteEndElement()
                writer.WriteEndElement()
                '#### FIM FOS TOTAIS DA NF
            End If
            datRead.Close()
            '###########################################################################################################



            '#### BLOCO DE TRANSPORTE
            writer.WriteStartElement("transp")
            writer.WriteElementString("modFrete", cbModalidadeFrete)

            If txtTranspCNPJ <> "" Then
                writer.WriteStartElement("transporta")
                If txtTranspCNPJ.Length < 14 Then
                    writer.WriteElementString("CPF", txtTranspCNPJ)
                Else
                    writer.WriteElementString("CNPJ", txtTranspCNPJ)
                End If
                writer.WriteElementString("xNome", tiraAcentos(Trim(cbTransportadora)))
                writer.WriteElementString("IE", txtTranspInscEst.Replace(".", ""))
                writer.WriteElementString("xEnder", tiraAcentos(txtTranspLogradouro))
                writer.WriteElementString("xMun", tiraAcentos(cbTranspMunicipio))
                writer.WriteElementString("UF", cbTranspUF)

                writer.WriteEndElement()

                '#### FIM DA TAG DE TRANSPORTA


                'SE NAO TEM PLACA NAO DA PRA EXIBIR O RNTC
                'If txtVeiculoRNTC <> "" Then
                '    writer.WriteStartElement("veicTransp")
                '    writer.WriteElementString("UF", cbTranspUF)
                '    writer.WriteElementString("RNTC", txtVeiculoRNTC)
                '    writer.WriteEndElement()
                'End If


                '#### BLOCO DE VOLUMES
                writer.WriteStartElement("vol")
                writer.WriteElementString("qVol", txtVolumeQtde) 'quantidade dos volumes transportados
                writer.WriteElementString("esp", tiraAcentos(txtVolumeEspecie)) 'especie dos volumes transportados
                If txtVolumeMarca <> "" Then
                    writer.WriteElementString("marca", tiraAcentos(txtVolumeMarca)) 'marca dos volumes transportados
                End If
                If txtVolumeNumero <> "" Then
                    writer.WriteElementString("nVol", txtVolumeNumero) 'numeracao de volumes transportados
                End If
                writer.WriteElementString("pesoL", CDBNumber(txtVolumePesoL, 3)) 'peso liquido
                writer.WriteElementString("pesoB", CDBNumber(txtVolumePesoB, 3)) 'Peso bruto
                writer.WriteEndElement()
                '#### FIM DE VOLUMES
            End If

            writer.WriteEndElement()
            '#### FIM DA TAG DE TRANSP


            '#### BLOCO DE DADOS DA COBRANCA
            writer.WriteStartElement("cobr")

            '#### DADOS DA FATURA
            If vVLTotalNF <> 0 Then
                writer.WriteStartElement("fat")
                writer.WriteElementString("nFat", txtNumeroFatura) 'Numero da fatura
                If vVLTotalNF <> 0 Then
                    writer.WriteElementString("vOrig", CDBNumber(vVLTotalNF, 2)) 'valor original da fatura
                Else
                    writer.WriteElementString("vOrig", 0) 'valor original da fatura
                End If

                'writer.WriteElementString("vDesc", 0) 'valor do desconto
                If vVLTotalNF <> 0 Then
                    writer.WriteElementString("vLiq", CDBNumber(vVLTotalNF, 2)) 'valor liquido
                Else
                    writer.WriteElementString("vLiq", 0) 'valor liquido
                End If
                writer.WriteEndElement()
            End If

            '#### DUPLICATAS
            querySQl.CommandText = "select id, CPL, Valor, DTVencimento from TMP_NFCP where CDPedido='" & sCDPedido & "' and CDEmpresa='" & gEmpresa & "' order by DTVencimento"
            datRead = querySQl.ExecuteReader()
            Dim nFat As String
            Dim i As Integer = 1
            Do Until datRead.Read = False
                nFat = sNF & "/" & i
                Dim dDataVenc As Date = datRead("DTVencimento")
                writer.WriteStartElement("dup")
                writer.WriteElementString("nDup", nFat) 'Numero da Duplicata
                writer.WriteElementString("dVenc", Format(dDataVenc, "yyyy") & "-" & Format(dDataVenc, "MM") & "-" & Format(dDataVenc, "dd")) 'data de vencimento
                writer.WriteElementString("vDup", CDBNumber(datRead("Valor"), 2)) 'Valor da Duplicata
                writer.WriteEndElement()
                i = i + 1
            Loop
            datRead.Close()
            writer.WriteEndElement()
            '#### FINAL DOS DADOS DE COBRANCA



            '#### INFORMACOES ADCIONAIS
            If txtInfAdicional.Length = 0 And txtInfAdicContribuinte.Length > 5 Then
                writer.WriteStartElement("infAdic")
                writer.WriteElementString("infCpl", txtInfAdicContribuinte) 'informacoes adionais de interesse do contribuinte
                writer.WriteEndElement()
            ElseIf txtInfAdicional.Length > 5 And txtInfAdicContribuinte.Length = 0 Then
                writer.WriteStartElement("infAdic")
                writer.WriteElementString("infAdFisco", txtInfAdicional) 'informacoes adicionais de interesse do fisco
                writer.WriteEndElement()
            ElseIf txtInfAdicional.Length > 5 And txtInfAdicContribuinte.Length > 5 Then
                writer.WriteStartElement("infAdic")
                writer.WriteElementString("infAdFisco", txtInfAdicional) 'informacoes adicionais de interesse do fisco
                writer.WriteElementString("infCpl", tiraAcentos(txtInfAdicContribuinte)) 'informacoes adionais de interesse do contribuinte
                writer.WriteEndElement()
            End If

            '#### FIM DE INFORMACOES ADICIONAIS


            '#### INFORMAÇÕES DO COMERCIO EXTERIOR
            If cbUFEmbarque <> "" And txtLocalEmbarque <> "" Then
                writer.WriteStartElement("exporta")
                writer.WriteElementString("UFEmbarq", cbUFEmbarque)
                writer.WriteElementString("xLocEmbarq", tiraAcentos(txtLocalEmbarque))
                writer.WriteEndElement()
                '#### FIM DAS INFORMACOES DO COMERCIO EXTERIOR
            End If


            writer.WriteEndElement()
            '#### FIM DA TAG infNFe

            writer.WriteEndElement()
            '#### fim da tag NFe

            writer.WriteEndDocument()
            '#### FIM DO DOCUMENTO
            writer.Flush()
            writer.Close()
            Return True
        Catch
            writer.WriteEndDocument()
            '#### FIM DO DOCUMENTO
            writer.Flush()
            writer.Close()
            Return False
        End Try
        conSQL2.Close()
    End Function
    Public Function gravaXMLRecebido(ByVal sString As String, ByVal sPath As String) As Boolean
        Try
            Dim xmlWRITER As XmlTextWriter = New XmlTextWriter(sPath, System.Text.Encoding.UTF8)
            xmlWRITER.Formatting = Formatting.Indented
            xmlWRITER.Indentation = 4
            xmlWRITER.WriteRaw(sString)
            xmlWRITER.Close()
            Return True
        Catch
            Return False
        End Try
    End Function
    Public Function pegaValorXML(ByVal sArquivo As String, ByVal sTag As String) As Decimal
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Dim iLeProximo As Integer = 0
        Do While (reader2.Read())
            If iLeProximo = 1 Then
                Return Replace(reader2.Value, ".", ",")
            End If
            If reader2.Name = sTag Then
                iLeProximo = iLeProximo + 1
            End If
        Loop
    End Function

    Public Function pegaStringXML(ByVal sArquivo As String, ByVal sTag As String) As String
        Dim document2 As XmlDocument = New XmlDocument()
        Dim sString2 As String = ""
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Dim iLeProximo As Integer = 0
        Do While (reader2.Read())
            If iLeProximo = 1 Then
                Return reader2.Value
            End If
            If reader2.Name = sTag Then
                iLeProximo = iLeProximo + 1
            End If
        Loop
        Return sString2
    End Function

    Public Function pegaRecibo(ByVal sArquivo As String) As String
        Dim sString2 As String = ""
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Dim iLeProximo As Integer = 0
        Do While (reader2.Read())
            If iLeProximo = 1 Then
                Return reader2.Value
            End If
            If reader2.Name = "nRec" Then
                iLeProximo = iLeProximo + 1
            End If
        Loop
        Return sString2
    End Function
    Public Function pegaStatus(ByVal sArquivo As String) As String
        Dim sString2 As String = ""
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Dim iLeProximo As Integer = 0
        Dim sRetorno As String = ""
        Do While (reader2.Read())
            If iLeProximo = 1 Then
                sRetorno = reader2.Value
                iLeProximo = 2
            End If
            If reader2.Name = "cStat" Then
                iLeProximo = iLeProximo + 1
            End If
            If reader2.Name = "protNFe" Then
                iLeProximo = 0
            End If
        Loop
        Return sRetorno
    End Function
    Public Function pegaProtocolo(ByVal sArquivo As String) As String
        Dim sString2 As String = ""
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Dim iLeProximo As Integer = 0
        Dim sRetorno As String = ""
        Do While (reader2.Read())
            If iLeProximo = 1 Then
                sRetorno = reader2.Value
                iLeProximo = 2
            End If
            If reader2.Name = "nProt" Then
                iLeProximo = iLeProximo + 1
            End If
        Loop
        Return sRetorno
    End Function


    Public Sub nfeProcessada(ByVal sArquivo As String, ByVal sArquivoNovo As String, ByVal sProtocolo As String)
        '#documento de nfe / no servidor

        Dim docOld As XmlDocument = New XmlDocument()
        Dim docNew As XmlDocument = New XmlDocument()

        'cria arquivo novo
        Dim bGrava As Boolean = gravaXMLRecebido("<nfeProc versao=""1.10"" xmlns=""http://www.portalfiscal.inf.br/nfe""></nfeProc>", sArquivoNovo)
        Try
            docNew.Load(sArquivoNovo)
            docNew.PreserveWhitespace = False
            docOld.Load(sArquivo)
            docOld.PreserveWhitespace = False

            '#documento de protocolo / na maquina
            Dim docProt As XmlDocument = New XmlDocument()
            docProt.Load(sProtocolo)
            docProt.PreserveWhitespace = False

            '#### criar tag nfe
            Dim objXmlNodeListNFe As System.Xml.XmlNodeList
            Dim objXmlNodeNFe As System.Xml.XmlNode
            Dim objXmlNodeNovo As System.Xml.XmlNode
            objXmlNodeNFe = docOld.DocumentElement
            objXmlNodeListNFe = objXmlNodeNFe.ChildNodes
            For Each objXmlNodeNFe In objXmlNodeListNFe
                If objXmlNodeNFe.Name.ToString() = "NFe" Then
                    objXmlNodeNovo = objXmlNodeNFe
                    docNew.DocumentElement.AppendChild(docNew.ImportNode(objXmlNodeNovo, True))
                End If
            Next

            '#criar tag protnfe
            Dim objXmlNodeListProt As System.Xml.XmlNodeList
            Dim objXmlNodeProt As System.Xml.XmlNode
            objXmlNodeProt = docProt.DocumentElement
            objXmlNodeListProt = objXmlNodeProt.ChildNodes
            For Each objXmlNodeProt In objXmlNodeListProt
                If objXmlNodeProt.Name.ToString() = "protNFe" Then
                    objXmlNodeNovo = objXmlNodeProt
                    docNew.DocumentElement.AppendChild(docNew.ImportNode(objXmlNodeNovo, True))
                End If
            Next
            docNew.Save(sArquivoNovo)

            Dim r As New XmlDocument
            r.Load(sArquivoNovo)
            Dim sXML As String = r.OuterXml
            sXML = sXML.Trim
            Me.gravaXMLRecebido(sXML, sArquivoNovo)

            '#### APOS PROCESSADO, APAGA O XML VELHO
            IO.File.Delete(sArquivo)
        Catch
        End Try

    End Sub

    Public Sub nfeProcessadaValores(ByVal sArquivo As String, ByVal sArquivoNovo As String)
        '#documento de nfe / no servidor
        Dim docOld As XmlDocument = New XmlDocument()
        Dim docNew As XmlDocument = New XmlDocument()
        'cria arquivo novo com totais
        Dim bGrava As Boolean = gravaXMLRecebido("<nfeTot xmlns=""http://www.portalfiscal.inf.br/nfe"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.portalfiscal.inf.br/nfe procNFe_v1.00.xsd"" versao=""1.10""></nfeTot>", sArquivoNovo)
        Try
            docNew.Load(sArquivoNovo)
            docOld.Load(sArquivo)
            docOld.PreserveWhitespace = False

            Dim objXmlNodeNovo As System.Xml.XmlNode
            Dim objXmlNodeListOld As System.Xml.XmlNodeList
            Dim objXmlNodeOld As System.Xml.XmlNode
            objXmlNodeOld = docOld.DocumentElement
            objXmlNodeListOld = objXmlNodeOld.ChildNodes(0).ChildNodes(0).ChildNodes
            For Each objXmlNodeOld In objXmlNodeListOld
                If objXmlNodeOld.Name.ToString() = "total" Then
                    objXmlNodeNovo = objXmlNodeOld
                    docNew.DocumentElement.AppendChild(docNew.ImportNode(objXmlNodeNovo, True))
                End If
            Next
            docNew.Save(sArquivoNovo)
        Catch
        End Try
    End Sub
    '#### LE XML E ALTERA RECIBO PARA SOLICITACAO DE RETORNO DE NFE
    Public Function readXMLRecibo(ByVal sArquivo As String, ByVal sRecibo As String) As String
        Dim sString2 As String = ""
        Dim iLeProximo As Integer = 0
        Dim document2 As XmlDocument = New XmlDocument()
        document2.Load(sArquivo)
        Dim reader2 As XmlNodeReader = New XmlNodeReader(document2)
        Do While (reader2.Read())
            Select Case reader2.NodeType
                Case XmlNodeType.XmlDeclaration
                    sString2 = sString2 & "<?" & reader2.Name & " " & reader2.Value & "?>" & vbCrLf
                Case XmlNodeType.Element 'Display beginning of element.
                    sString2 = sString2 & "<" & reader2.Name & ""
                    If reader2.Name = "nRec" Then
                        iLeProximo = iLeProximo + 1
                    End If
                    If reader2.HasAttributes Then 'If attributes exist
                        While reader2.MoveToNextAttribute()
                            'Display attribute name and value.
                            sString2 = sString2 & " " & reader2.Name & "=""" & reader2.Value & """"
                        End While
                    End If
                    sString2 = sString2 & ">"

                Case XmlNodeType.Text 'Display the text in each element.
                    If iLeProximo = 1 Then
                        sString2 = sString2 & sRecibo
                    Else
                        sString2 = sString2 & reader2.Value
                    End If
                Case XmlNodeType.EndElement 'Display end of element.
                    sString2 = sString2 & "</" & reader2.Name & ">" & vbCrLf
            End Select
        Loop
        Return sString2
    End Function
    Public Sub cancelaNFE(ByVal xmlPath As String, ByVal gCVAcesso As String, ByVal snProt As String, ByVal sxJust As String)
        Dim conn As New PrismaLibrary.ClassSqlConnection

        Dim writer As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()

        '#Abre Header
        writer.WriteStartElement("cancNFe")
        writer.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")
        writer.WriteAttributeString("versao", "1.07")

        writer.WriteStartElement("infCanc")
        writer.WriteAttributeString("Id", "ID" & gCVAcesso)
        writer.WriteElementString("tpAmb", gTpAmb)
        writer.WriteElementString("xServ", "CANCELAR")
        writer.WriteElementString("chNFe", gCVAcesso)
        writer.WriteElementString("nProt", snProt)
        writer.WriteElementString("xJust", sxJust)
        writer.WriteEndElement()

        writer.WriteEndElement()
        writer.WriteEndDocument()
        '#### FIM DO DOCUMENTO
        writer.Flush()
        writer.Close()
    End Sub

    Public Sub inutilizaNFE(ByVal xmlPath As String, ByVal nInicial As String, ByVal nFinal As String, ByVal sxJust As String)
        Dim writer As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()

        '#Abre Header
        writer.WriteStartElement("inutNFe")
        writer.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")
        writer.WriteAttributeString("versao", "1.07")

        writer.WriteStartElement("infInut")
        writer.WriteAttributeString("Id", "ID" & gCVAcesso)
        writer.WriteElementString("tpAmb", gTpAmb)
        writer.WriteElementString("xServ", "INUTILIZAR")
        writer.WriteElementString("cUF", "35")
        writer.WriteElementString("ano", Date.Now.Year)
        writer.WriteElementString("CNPJ", gCNPJ)
        writer.WriteElementString("mod", "55")
        writer.WriteElementString("serie", "0")
        writer.WriteElementString("nNFIni", nInicial)
        writer.WriteElementString("nNFFin", nFinal)
        writer.WriteElementString("xJust", sxJust)
        writer.WriteEndElement()

        writer.WriteEndElement()
        writer.WriteEndDocument()
        '#### FIM DO DOCUMENTO
        writer.Flush()
        writer.Close()
    End Sub
    Public Sub gravaParaInutilizacao(ByVal xmlPath As String, ByVal sChaveAcesso As String)

        Dim writer As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()

        '#Abre Header
        writer.WriteStartElement("consSitNFe")
        writer.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")
        writer.WriteAttributeString("versao", "1.07")

        writer.WriteElementString("tpAmb", gTpAmb)
        writer.WriteElementString("xServ", "CONSULTAR")
        writer.WriteElementString("xJust", sChaveAcesso)

        writer.WriteEndElement()
        writer.WriteEndDocument()
        '#### FIM DO DOCUMENTO
        writer.Flush()
        writer.Close()
    End Sub

    Public Sub gravaConsCad(ByVal xmlPath As String, ByVal sIE As String, ByVal sCNPJ As String, ByVal sUF As String)

        Dim writer As New XmlTextWriter(xmlPath, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()

        '#Abre Header
        writer.WriteStartElement("ConsCad")
        writer.WriteAttributeString("versao", "1.01")
        writer.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe")

        writer.WriteStartElement("infCons")
        writer.WriteElementString("xServ", "CONS-CAD")
        writer.WriteElementString("UF", sUF)
        If sIE <> "" Then
            writer.WriteElementString("IE", sIE)
        End If
        If sCNPJ <> "" Then
            writer.WriteElementString("CNPJ", sCNPJ)
        End If
        writer.WriteEndElement()

        writer.WriteEndElement()
        writer.WriteEndDocument()
        '#### FIM DO DOCUMENTO
        writer.Flush()
        writer.Close()
    End Sub


    Public Function JustSign(ByVal xmlstring As String, ByVal IdTagName As String) As String
        Try
            'Cria Certificado
            Dim X509Cert As New X509Certificate2(gCertificadoDigital, gCertificadoSenha)
            Try
                'Novo documento XML
                Dim doc As New XmlDocument()
                doc.LoadXml(xmlstring)
                Try
                    'Verifica se a tag a ser assinada existe nica
                    Dim qtdeRefUri As Integer = doc.GetElementsByTagName(IdTagName).Count
                    If (qtdeRefUri = 0) Then
                        Return "A tag " + IdTagName + " no foi localizada"
                        Exit Function
                    ElseIf (qtdeRefUri > 1) Then 'Existe mais de uma tag a ser assinada
                        Return "A tag " + IdTagName + " no nica"
                        Exit Function
                    Else
                        Try
                            'Cria um SignedXml
                            Dim signedXml As SignedXml = New SignedXml(doc)
                            'Adiciona a chave
                            signedXml.SigningKey = X509Cert.PrivateKey
                            'Cria a referncia aser assinada
                            Dim reference As New Reference()
                            'Pega o uri que deve ser assinada
                            Dim _Uri As XmlAttributeCollection = doc.GetElementsByTagName(IdTagName).Item(0).Attributes
                            Dim _atributo As XmlAttribute
                            For Each _atributo In _Uri
                                If _atributo.Name = "Id" Then
                                    reference.Uri = "#" + _atributo.InnerText
                                End If
                            Next
                            'Agora receita de bolo
                            Dim env As New XmlDsigEnvelopedSignatureTransform()
                            reference.AddTransform(env)
                            Dim c14 As New XmlDsigC14NTransform()
                            reference.AddTransform(c14)
                            signedXml.AddReference(reference)
                            Dim keyInfo As New KeyInfo()
                            'Le certificdo e adiciona a chave
                            keyInfo.AddClause(New KeyInfoX509Data(X509Cert))
                            signedXml.KeyInfo = keyInfo
                            signedXml.ComputeSignature()
                            'Pega a XML representation da assinatura e salva
                            Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
                            'Adiciona o elemento no documento
                            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))
                            Return doc.OuterXml()
                        Catch ex As Exception
                            Return "Erro ao assinar o documento: " + ex.Message
                            Exit Function
                        End Try
                    End If
                    Return True
                Catch ex As Exception
                    Return "xml mal formatado: " + ex.Message
                    Exit Function
                End Try
            Catch ex As Exception
                Return "Erro ao carregar o documento: " + ex.Message
                Exit Function
            End Try
        Catch ex As Exception
            Return "Erro ao criar o certificado: " + ex.Message
            Exit Function
        End Try
    End Function

    Public Function CDBNumber(ByVal dValor As Decimal, ByVal casas As Integer) As String
        Dim retValor As String = ""
        If casas = 2 Then
            retValor = Replace(dValor.ToString("#########0.00"), ",", ".")
        ElseIf casas = 3 Then
            retValor = Replace(dValor.ToString("#########0.000"), ",", ".")
        ElseIf casas = 4 Then
            retValor = Replace(dValor.ToString("#########0.0000"), ",", ".")
        End If
        Return retValor
    End Function
End Class
