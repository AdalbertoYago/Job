Public Class ClassParametros
    Inherits ClassSqlConnection
    Public cdempresa As String
    Public commSQL As New SqlClient.SqlCommand()
    Public paramSQL = New ClassSqlConnection()
    Public datRead As SqlClient.SqlDataReader

    Public Function selEmpresa() As SqlClient.SqlDataReader
        paramSQL = Me.sqlConnectPrisma()
        paramSQL.open()
        commSQL.Connection = paramSQL
        commSQL.CommandText = "select CDEmpresa, Empresa, Fantasia from Autentica order by Empresa"
        datRead = commSQL.ExecuteReader()
        Return datRead
    End Function


    Public Function selPerfilUsuario(ByVal sUsuario As String, ByVal sSenha As String, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As String
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        Dim Senha As String
        Dim cSenhas As ClassUsuarios = New ClassUsuarios()
        Senha = cSenhas.senhaCrypt(sSenha.ToUpper())
        querySQl.CommandText = "select CDPerfil from Usuarios where upper(UserName)='" & sUsuario.ToUpper() & "' and Senha='" & Senha & "'"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            Return datRead("CDPerfil")
        Else
            Return ""
        End If
        datRead.Close()
        conSQL.Close()
    End Function
    Public Function selPermissoes(ByVal iCDSecao As Integer, ByVal iCDPerfil As Integer, ByVal gDataSource As String, ByVal gUserID As String, ByVal gPWD As String, ByVal gInitialCatalog As String) As Boolean
        conSQL = Me.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        querySQl.CommandText = "select * from PerfilAcesso where CDSecao=" & iCDSecao & " and CDPerfil=" & iCDPerfil & " "
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            Return True
        Else
            Return False
        End If
        conSQL.Close()
    End Function

    ' VALIDAR CNPJ E CPF
    Public Function validaCNPJCPF(ByVal cgc As String) As Boolean
        Dim retorno, a, j, i, d1, d2
        If Left(cgc, 6) = "111111" Then
            Retorno = False
        ElseIf Left(cgc, 6) = "222222" Then
            retorno = False
        ElseIf Left(cgc, 6) = "333333" Then
            retorno = False
        ElseIf Left(cgc, 6) = "444444" Then
            retorno = False
        ElseIf Left(cgc, 6) = "555555" Then
            retorno = False
        ElseIf Left(cgc, 6) = "666666" Then
            retorno = False
        ElseIf Left(cgc, 6) = "777777" Then
            retorno = False
        ElseIf Left(cgc, 6) = "888888" Then
            retorno = False
            '        ElseIf Left(cgc, 6) = "999999" Then
            '            retorno = False
        Else
            If Char.IsNumber(cgc) Then
                If Len(cgc) = 11 Then
                    Dim soma As Integer
                    Dim Resto As Integer
                    'Valida argumento
                    If Len(cgc) <> 11 Then
                        validaCNPJCPF = False
                        Exit Function
                    End If
                    soma = 0
                    For i = 1 To 9
                        soma = soma + Val(Mid$(cgc, i, 1)) * (11 - i)
                    Next i
                    Resto = 11 - (soma - (Int(soma / 11) * 11))
                    If Resto = 10 Or Resto = 11 Then Resto = 0
                    If Resto <> Val(Mid$(cgc, 10, 1)) Then
                        validaCNPJCPF = False
                        Exit Function
                    End If
                    soma = 0
                    For i = 1 To 10
                        soma = soma + Val(Mid$(cgc, i, 1)) * (12 - i)
                    Next i
                    Resto = 11 - (soma - (Int(soma / 11) * 11))
                    If Resto = 10 Or Resto = 11 Then Resto = 0
                    If Resto <> Val(Mid$(cgc, 11, 1)) Then
                        validaCNPJCPF = False
                        Exit Function
                    End If
                    validaCNPJCPF = True
                Else
                    If Len(cgc) = 14 And Val(cgc) > 0 Then
                        a = 0
                        i = 0
                        d1 = 0
                        d2 = 0
                        j = 5
                        For i = 1 To 12 Step 1
                            a = a + (Val(Mid(cgc, i, 1)) * j)
                            j = IIf(j > 2, j - 1, 9)
                        Next i
                        a = a Mod 11
                        d1 = IIf(a > 1, 11 - a, 0)
                        a = 0
                        i = 0
                        j = 6
                        For i = 1 To 13 Step 1
                            a = a + (Val(Mid(cgc, i, 1)) * j)
                            j = IIf(j > 2, j - 1, 9)
                        Next i
                        a = a Mod 11
                        d2 = IIf(a > 1, 11 - a, 0)
                        If (d1 = Val(Mid(cgc, 13, 1)) And d2 = Val(Mid(cgc, 14, 1))) Then
                            validaCNPJCPF = True
                        Else
                            validaCNPJCPF = False
                        End If
                    Else
                        validaCNPJCPF = False
                    End If
                End If
                If validaCNPJCPF = True Then
                    retorno = True
                Else
                    retorno = False
                End If
            Else
                retorno = False
            End If
        End If
    End Function

    Public Function Modulo10(ByVal PNum As String, ByVal PQtde As Integer) As Integer
        Dim mSub As Integer, mTot As Integer, mDig As Integer, CTd As Integer
        Dim sSub As String
        Dim iModulo10 As Integer
        mSub = 0
        mDig = 2
        CTd = 0
        mTot = 0
        Dim I As Integer
        For I = 1 To PQtde
            'Val(Mid(PNum, PQtde - CTd, 1))
            mSub = (PNum.Substring((PQtde - 1) - CTd, 1) * mDig)
            If mSub >= 10 Then
                sSub = mSub.ToString()
                mTot = mTot + sSub.Substring(0, 1) + sSub.Substring(1, 1)
            Else
                mTot = mTot + mSub
            End If
            If mDig = 1 Then
                mDig = 2
            Else
                mDig = mDig - 1
            End If
            CTd = CTd + 1
        Next
        If mTot < 10 Then
            iModulo10 = 10 - mTot
        Else
            If (mTot Mod 10) = 0 Then
                mDig = 0
            Else
                mDig = 10 - (mTot Mod 10)
            End If
            iModulo10 = mDig
        End If
        Return iModulo10
    End Function
    Public Function Modulo11(ByVal PNum As String, ByVal PQtde As Integer, ByVal PPeso As Integer) As String
        Dim CTd As Integer, mTot As Integer, mDig As Integer
        CTd = 0
        mDig = 2
        mTot = 0
        Dim I As Integer
        Dim iTam As Integer = PQtde - 1
        For I = 1 To PQtde
            If mDig <= PPeso Then
                mTot = mTot + PNum.Substring(iTam - CTd, 1) * mDig
                mDig = mDig + 1
                CTd = CTd + 1
            Else
                mDig = 2
                mTot = mTot + PNum.Substring(iTam - CTd, 1) * mDig
                mDig = mDig + 1
                CTd = CTd + 1
            End If
        Next
        If (mTot Mod 11) = 0 Or (mTot Mod 11) = 1 Or (mTot Mod 11) = 10 Then
            mDig = 1
        Else
            mDig = 11 - (mTot Mod 11)
        End If
        Modulo11 = mDig
        Return Modulo11
    End Function
End Class
