Public Class ClassUsuarios
    Inherits ClassSqlConnection
    Public nomeUsuario, iIDUsuario, sDataSource, sUserID, sPWD, sInitialCatalog, gEmpresa, sNomeEmpresa, sEnderecoEntrega, sFantasia, sSenha, sEmailNFE, sEmailContasAPagar, sEmailContasAReceber As String
    Public sDataSourceLegado, sUserIDLegado, sPWDLegado, sInitialCatalogLegado As String
    Public sEndereco, sCidade, sCNPJ, sIE, sBairro, sFone, sFax As String
    Public sLogo, sLogoDanfe, sLogoWeb, sComplemento, sCEP As String
    Public iNumero As Integer
    Public sDataSourceAux, sUserIDAux, sPWDAux, sInitialCatalogAux As String
    Public sDataSourceLegadoAux, sUserIDLegadoAux, sPWDLegadoAux, sInitialCatalogLegadoAux As String
    Public sDescProcedure As String
    Public iPermissaoProcedure As Integer
    Public iUFEmissor As Integer
    Public sUFEmissor As String
    Public gIDEmpresa As Integer
    Public sMunicipioEmissor As String
    Public sCertificadoDigital, sCertificadoSenha, sPathBoleto, sPathXML, sPathFotos As String
    Public sBanco, sAgencia, sContaCorrente, sBanco2, sAgencia2, sContaCorrente2 As String
    Public sDadosDeposito1, sDadosDeposito2 As String
    Public sURLFichaCadastral, sURLLogoEmpresa As String
    Public sListaPadrao As String
    Public iDiasEntrega As Integer
    Public dDescontoMaximo As Decimal
    Public sSetor As String
    Public sEmailAlmoxarife As String
    Public iCRT As Integer
    Public sPWEmail As String

    Public iTpAmb As Integer = 0
    Public sEmailPedido As String
    Public sDominio As String
    Public sPathCNAB

    Public iCDPerfil As Integer
    Public sCDCC, sUserName, sAutentica As String

    Public Function autenticaPrisma(ByVal UserName As String, ByVal Senha As String, ByVal Empresa As String) As String
        Dim querySQL As New SqlClient.SqlCommand()


        Dim datRead2 As SqlClient.SqlDataReader
        Senha = senhaCrypt(Senha.ToUpper())
        conSQL = Me.sqlConnectPrisma()
        conSQL.open()
        querySQL.Connection = conSQL

        'conecta na prismaAcesso para ver se o usuario existe
        querySQL.CommandText = "select * from Autentica where Empresa='" & Empresa & "'"
        datRead2 = querySQL.ExecuteReader()
        If datRead2.Read = True Then
            gEmpresa = datRead2("CDEmpresa")
            gIDEmpresa = datRead2("id")
            sDataSource = datRead2("DataSource")
            sUserID = datRead2("UserID")
            sPWD = datRead2("Pwd")
            sInitialCatalog = datRead2("InitialCatalog")
            sNomeEmpresa = datRead2("Empresa")
            sFantasia = datRead2("Fantasia")
            sEndereco = datRead2("Endereco")
            iNumero = datRead2("Numero")
            Try
                sComplemento = datRead2("Complemento")
            Catch
                sComplemento = ""
            End Try
            sCidade = datRead2("Municipio")
            sCNPJ = datRead2("CNPJ")
            Try
                sIE = datRead2("IE")
            Catch
                sIE = ""
            End Try
            sBairro = datRead2("Bairro")
            sLogo = datRead2("Logo")
            Try
                sLogoDanfe = datRead2("LogoDanfe")
            Catch
                sLogoDanfe = ""
            End Try
            Try
                sLogoWeb = datRead2("LogoWeb")
            Catch
                sLogoWeb = ""
            End Try
            Try
                sDominio = datRead2("Dominio")
            Catch ex As Exception
                sDominio = ""
            End Try

            Try
                sCertificadoDigital = datRead2("CertificadoDigital")
                sCertificadoSenha = datRead2("CertificadoSenha")
                sBanco = datRead2("Banco")
                sAgencia = datRead2("Agencia")
                sContaCorrente = datRead2("ContaCorrente")
                sBanco2 = datRead2("Banco2")
                sAgencia2 = datRead2("Agencia2")
                sContaCorrente2 = datRead2("ContaCorrente2")
                iUFEmissor = datRead2("CDUF")
                sUFEmissor = datRead2("UF")
                sMunicipioEmissor = datRead2("CDMunicipio")
                sCEP = datRead2("CEP")
                sFone = datRead2("Fone")
                sFax = datRead2("Fax")
            Catch
            End Try

            sEmailNFE = datRead2("EmailNFE")
            sEmailPedido = datRead2("EmailPedidos")

            Try
                sEmailContasAReceber = datRead2("EmailContasAReceber")
            Catch
                sEmailContasAReceber = ""
            End Try
            Try
                sEmailContasAPagar = datRead2("EmailContasAPagar")
            Catch
                sEmailContasAPagar = ""
            End Try
            Try
                sEnderecoEntrega = datRead2("EnderecoEntrega")
            Catch
                sEnderecoEntrega = ""
            End Try
            Try
                sPathBoleto = datRead2("PathBoleto")
            Catch
                sPathBoleto = ""
            End Try
            Try
                sPathXML = datRead2("PathXML")
            Catch
                sPathXML = ""
            End Try
            Try
                sPathFotos = datRead2("PathFotos")
            Catch
                sPathFotos = ""
            End Try
            Try
                iTpAmb = datRead2("tpAmb")
            Catch
                iTpAmb = 0
            End Try
            Try
                sDadosDeposito1 = datRead2("DadosDeposito1")
            Catch
                sDadosDeposito1 = ""
            End Try
            Try
                sDadosDeposito2 = datRead2("DadosDeposito2")
            Catch
                sDadosDeposito2 = ""
            End Try

            Try
                sPathCNAB = datRead2("PathCNAB")
            Catch ex As Exception
                sPathCNAB = ""
            End Try
            Try
                sURLFichaCadastral = datRead2("URLFichaCadastral")
            Catch ex As Exception
                sURLFichaCadastral = ""
            End Try
            Try
                sURLLogoEmpresa = datRead2("URLLogoEmpresa")
            Catch ex As Exception
                sURLLogoEmpresa = ""
            End Try
            Try
                sListaPadrao = datRead2("ListaPadrao")
            Catch ex As Exception
                sListaPadrao = ""
            End Try
            Try
                iCRT = datRead2("CRT")
            Catch ex As Exception
                iCRT = 3 'Regime Tributario normal
            End Try
            Try
                iDiasEntrega = datRead2("DiasEntrega")
            Catch ex As Exception
                iDiasEntrega = 0
            End Try
            Try
                dDescontoMaximo = datRead2("DescontoMaximo")
            Catch ex As Exception
                dDescontoMaximo = 0
            End Try
            Try
                sEmailAlmoxarife = datRead2("EmailAlmoxarife")
            Catch ex As Exception
                sEmailAlmoxarife = ""
            End Try
            datRead2.Close()

            'Pegando conexao com base legado
            querySQL.CommandText = "select * from AutenticaLegado where CDAutentica='" & gIDEmpresa & "' and CDEmpresa='" & gEmpresa & "'"
            datRead2 = querySQL.ExecuteReader()
            If datRead2.Read = True Then
                sDataSourceLegado = datRead2("DataSource")
                sUserIDLegado = datRead2("UserID")
                sPWDLegado = datRead2("Pwd")
                sInitialCatalogLegado = datRead2("InitialCatalog")
            End If
            datRead2.Close()

            'Pegando conexao com base Auxiliar
            querySQL.CommandText = "select * from AutenticaAuxiliar where CDAutentica='" & gIDEmpresa & "' and CDEmpresa='" & gEmpresa & "'"
            datRead2 = querySQL.ExecuteReader()
            If datRead2.Read = True Then
                sDataSourceAux = datRead2("DataSource")
                sUserIDAux = datRead2("UserID")
                sPWDAux = datRead2("Pwd")
                sInitialCatalogAux = datRead2("InitialCatalog")
            End If
            datRead2.Close()

            'Pegando conexao com base Legado Auxiliar
            querySQL.CommandText = "select * from AutenticaLegadoAuxiliar where CDAutentica='" & gIDEmpresa & "' and CDEmpresa='" & gEmpresa & "'"
            datRead2 = querySQL.ExecuteReader()
            If datRead2.Read = True Then
                sDataSourceLegadoAux = datRead2("DataSource")
                sUserIDLegadoAux = datRead2("UserID")
                sPWDLegadoAux = datRead2("Pwd")
                sInitialCatalogLegadoAux = datRead2("InitialCatalog")
            End If
            datRead2.Close()

            'Conecta na base prisma pra checar usuario
            conSQL2 = Me.sqlConnect(sDataSource, sUserID, sPWD, sInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2
            querySQL2.CommandText = "select * from Usuarios where UserName='" & UserName & "' and Senha='" & Senha & "'"
            datRead2 = querySQL2.ExecuteReader()
            If datRead2.HasRows = True Then
                Do Until datRead2.Read = False
                    nomeUsuario = datRead2("Nome")
                    iIDUsuario = datRead2("id")
                    sUserName = datRead2("UserName")
                    Try
                        sCDCC = datRead2("CDCC")
                    Catch
                        sCDCC = ""
                    End Try
                    Try
                        iCDPerfil = datRead2("CDPerfil")
                    Catch
                        iCDPerfil = 0
                    End Try
                    Try
                        sSetor = datRead2("Setor")
                    Catch ex As Exception
                        sSetor = ""
                    End Try
                    Try
                        sPWEmail = datRead2("PWEmail")
                    Catch ex As Exception
                        sPWEmail = ""
                    End Try
                    sSenha = datRead2("Senha")
                Loop
            Else
                nomeUsuario = ""
            End If
            Return nomeUsuario
            datRead2.Close()
            Me.sqlDisconnect()
        End If
    End Function

    Public Function selUtimaNF(ByVal sCDEmpresa As String, ByVal sDataSource As String, ByVal sUserID As String, ByVal sPWD As String, ByVal sInitialCatalog As String) As Integer
        Dim querySQL As New SqlClient.SqlCommand()

        Dim datRead2 As SqlClient.SqlDataReader
        Dim nNF As Integer
        conSQL = Me.sqlConnect(sDataSource, sUserID, sPWD, sInitialCatalog)
        conSQL.open()
        querySQL.Connection = conSQL

        'conecta na prismaAcesso para ver se o usuario existe
        querySQL.CommandText = "select * from NFNumero where CDEmpresa='" & sCDEmpresa & "'"
        datRead2 = querySQL.ExecuteReader()
        If datRead2.Read = True Then
            nNF = datRead2("CDNF")
        End If
        datRead2.Close()
        conSQL2.Close()
        Return nNF
    End Function

    Public Sub AtualizaNF(ByVal sCDEmpresa As String, ByVal sCDNF As String, ByVal sDataSource As String, ByVal sUserID As String, ByVal sPWD As String, ByVal sInitialCatalog As String)
        Dim querySQL As New SqlClient.SqlCommand()

        conSQL = Me.sqlConnect(sDataSource, sUserID, sPWD, sInitialCatalog)
        conSQL.open()
        querySQL.Connection = conSQL

        'conecta na prismaAcesso para ver se o usuario existe
        querySQL.CommandText = "update NFNumero set CDNF='" & sCDNF & "' where CDEmpresa='" & sCDEmpresa & "'"
        querySQL.ExecuteReader()
        conSQL.close()
    End Sub

    Public Function selUtimaFAT(ByVal sCDEmpresa As String, ByVal sDataSourceAux As String, ByVal sUserIDAux As String, ByVal sPWDAux As String, ByVal sInitialCatalogAux As String) As Integer
        Dim querySQL As New SqlClient.SqlCommand()
        Dim datRead2 As SqlClient.SqlDataReader
        Dim nNF As Integer
        conSQL = Me.sqlConnect(sDataSourceAux, sUserIDAux, sPWDAux, sInitialCatalogAux)
        conSQL.open()
        querySQL.Connection = conSQL

        'conecta na prismaAcesso para ver se o usuario existe
        querySQL.CommandText = "select * from Prisma2.dbo.NFNumero where CDEmpresa='" & sCDEmpresa & "'"
        datRead2 = querySQL.ExecuteReader()
        If datRead2.Read = True Then
            nNF = datRead2("CDNF")
        End If
        datRead2.Close()
        conSQL2.Close()
        Return nNF
    End Function

    Public Sub AtualizaFAT(ByVal sCDEmpresa As String, ByVal sCDNF As String, ByVal sDataSourceAux As String, ByVal sUserIDAux As String, ByVal sPWDAux As String, ByVal sInitialCatalogAux As String)
        Dim querySQL As New SqlClient.SqlCommand()

        conSQL = Me.sqlConnect(sDataSourceAux, sUserIDAux, sPWDAux, sInitialCatalogAux)
        conSQL.open()
        querySQL.Connection = conSQL

        'conecta na prismaAcesso para ver se o usuario existe
        querySQL.CommandText = "update Prisma2.dbo.NFNumero set CDNF='" & sCDNF & "' where CDEmpresa='" & sCDEmpresa & "'"
        querySQL.ExecuteReader()
        conSQL.close()
    End Sub
    Public Function selProceduresPrisma(ByVal idEmpresa As Integer, ByVal sProcedure As String) As Boolean
        Dim querySQL As New SqlClient.SqlCommand()
        conSQL = Me.sqlConnectPrisma()
        conSQL.open()
        querySQL.Connection = conSQL
        querySQL.CommandText = "select * from AutenticaProcedure where CDAutentica='" & idEmpresa & "' and descProcedure='" & sProcedure & "'"
        datRead = querySQL.ExecuteReader()
        If datRead.Read = True Then
            If datRead("AcessoProcedure") = 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
        conSQL.close()
    End Function

    Public Sub selUsuarios(ByVal userID As Integer, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String)
        Dim querySQL As New SqlClient.SqlCommand()

        Dim datRead As SqlClient.SqlDataReader
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.open()
        querySQL.Connection = conSQL

        querySQL.CommandText = "select * from Usuarios where id='" & userID & "'"
        datRead = querySQL.ExecuteReader()
        If datRead.HasRows = True Then
            Do Until datRead.Read = False
                nomeUsuario = datRead("Nome")
                iIDUsuario = datRead("id")
                sUserName = datRead("UserName")
                sSenha = datRead("Senha")
                Try
                    sCDCC = datRead("CDCC")
                Catch
                    sCDCC = ""
                End Try
                Try
                    sAutentica = datRead("Autentica")
                Catch
                    sAutentica = ""
                End Try
                'grava acessos somente na instancia da classe
                Try
                    iCDPerfil = datRead("CDPerfil")
                Catch
                    iCDPerfil = 0
                End Try
                Try
                    sPWEmail = datRead("PWEmail")
                Catch ex As Exception
                    sPWEmail = ""
                End Try
            Loop
        Else
            nomeUsuario = ""
        End If

        datRead.Close()
        Me.sqlDisconnect()
    End Sub
    Public Function selUsuarios(ByVal UserName As String, ByVal Senha As String, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As String
        Dim querySQL As New SqlClient.SqlCommand()
        Dim nomeUsuario As String
        Senha = senhaCrypt(Senha.ToUpper())
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.open()
        querySQL.Connection = conSQL
        querySQL.CommandText = "select * from Usuarios where UserName='" & UserName & "' and Senha='" & Senha & "'"

        Dim datRead As SqlClient.SqlDataReader
        datRead = querySQL.ExecuteReader()
        If datRead.HasRows = True Then
            Do Until datRead.Read = False
                nomeUsuario = datRead.GetString(2)
            Loop
        Else
            nomeUsuario = ""
        End If
        Return nomeUsuario
        datRead.Close()
        Me.sqlDisconnect()
    End Function


    Public Function alteraSenha(ByVal senha1 As String, ByVal senha2 As String, ByVal iID As Integer, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As Boolean
        Dim sSenha As String
        If senha1 = senha2 Then
            sSenha = senhaCrypt(senha1.ToUpper())
            conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandText = "update Usuarios set senha='" & sSenha & "' where id=" & iID
            querySQl.ExecuteNonQuery()
            Return True
        Else
            Return False
        End If
    End Function
    Public Function alteraUsuario(ByVal iId As Integer, ByVal sNome As String, ByVal sUserName As String, ByVal sCDCC As String, ByVal sSenha As String, ByVal iCDPerfil As Integer, ByVal sPWEmail As String, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As Boolean
        Dim sSenha2 As String
        sSenha2 = senhaCrypt(sSenha.ToUpper())
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        Try
            querySQl.Connection = conSQL
            querySQl.CommandText = "update Usuarios set Nome='" & sNome & "', UserName='" & sUserName & "', CDCC='" & sCDCC & "', senha='" & sSenha2 & "', CDPerfil='" & iCDPerfil & "',PWEmail='" & sPWEmail & "' where id=" & iId
            querySQl.ExecuteNonQuery()
            Return True
        Catch
            Return False
        End Try
        conSQL.Close()
    End Function
    Public Function incluiUsuario(ByVal sNome As String, ByVal sUserName As String, ByVal sCDCC As String, ByVal sSenha As String, ByVal iCDPerfil As Integer, ByVal sPWEmail As String, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As Boolean
        Dim sSenha2 As String
        sSenha2 = senhaCrypt(sSenha.ToUpper())
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        Try
            querySQl.Connection = conSQL
            querySQl.CommandText = "insert into Usuarios (Nome, UserName, CDCC, senha,CDPerfil,PWEmail) values('" & sNome & "','" & sUserName & "','" & sCDCC & "','" & sSenha2 & "', '" & iCDPerfil & "','" & sPWEmail & "')"
            querySQl.ExecuteNonQuery()
            Return True
        Catch
            Return False
        End Try
        conSQL.Close()
    End Function
    Public Function excluiUsuario(ByVal iId As Integer, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As Boolean
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        Try
            querySQl.Connection = conSQL
            querySQl.CommandText = "delete from Usuarios  where id=" & iId
            querySQl.ExecuteNonQuery()
            Return True
        Catch
            Return False
        End Try
        conSQL.Close()
    End Function

    Public Function senhaCrypt(ByVal senha As String) As String
        Dim mTemp As String = ""
        Dim nn As Integer
        Dim n, z As Integer
        Dim mTotal As String
        nn = senha.Length
        Dim s As Char
        mTotal = senha
        For z = 0 To (nn - 1)
            s = Convert.ToChar(mTotal.Substring(z, 1))
            n = Convert.ToInt32(s)
            n = n + 20
            mTemp = mTemp + ChrW(n)
        Next
        Return mTemp
    End Function

    Public Function senhaDecrypt(ByVal senha As String) As String
        Dim mTemp As String = ""
        Dim nn As Integer
        Dim n, z As Integer
        Dim mTotal As String
        nn = senha.Length
        Dim s As Char
        mTotal = senha
        For z = 0 To (nn - 1)
            s = Convert.ToChar(mTotal.Substring(z, 1))
            n = Convert.ToInt32(s)
            n = n - 20
            mTemp = mTemp + ChrW(n)
        Next
        Return mTemp
    End Function
End Class
