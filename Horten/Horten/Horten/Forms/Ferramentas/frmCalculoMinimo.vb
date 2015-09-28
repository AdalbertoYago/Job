Public Class frmCalculoMinimo

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        'If MessageBox.Show("Confirma o processamento", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

        '    Dim VMeses As Integer, VDataIni As String, VDataFim As String, VMesI As Integer, VMesF As Integer, VAnoI As Integer, VAnoF As Integer
        '    Dim VCDProduto As String
        '    Dim VMes As Integer
        '    VMes = tbMeses.Text

        '    If VMes = 0 Or VMes = "" Or VMes = 1 Then
        '        VMeses = 1
        '    ElseIf VMes > 12 Then
        '        MessageBox.Show("Atebção o número máximo de meses é 12", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '        Exit Sub
        '    Else
        '        VMeses = VMes
        '    End If

        '    VMesI = Date.Now.Month - VMeses
        '    VMesF = Date.Now.Month - 1
        '    VAnoI = Date.Now.Year
        '    VAnoF = Date.Now.Year
        '    If VMesI <= 0 Then
        '        VAnoI = VAnoI - 1
        '        Select Case Date.Now.Month - VMeses
        '            Case -1
        '                VMesI = 11
        '            Case -2
        '                VMesI = 10
        '            Case -3
        '                VMesI = 9
        '            Case -4
        '                VMesI = 8
        '            Case -5
        '                VMesI = 7
        '            Case -6
        '                VMesI = 6
        '            Case -7
        '                VMesI = 5
        '            Case -8
        '                VMesI = 4
        '            Case -9
        '                VMesI = 3
        '            Case -10
        '                VMesI = 2
        '            Case -11
        '                VMesI = 1
        '            Case 0
        '                VMesI = 12
        '        End Select
        '    End If
        '    VDataIni = "01/" & VMesI & "/" & VAnoI
        '    VDataFim = DiaMes(StrZero(Trim(Str(VMesF)), 2)) & "/" & StrZero(Trim(Str(VMesF)), 2) & "/" & VAnoF

        '    Screen.MousePointer = 11
        '    VSQL = ""
        '    If Option1.Value = True Then
        '        VSQL = VSQL & "Select Pedidos.Dis,ItemPed.CDProduto,ItemPed.Qtde From Pedidos Left Join ItemPed On Pedidos.CDPedido = ItemPed.CDPedido Where Dis BetWeen Convert(DateTime,'" & VDataIni & "',103) And Convert(DateTime,'" & VDataFim & "',103) Order By CDProduto"
        '    Else
        '        VSQL = VSQL & "Select NF.Dis,ItemNF.CDProduto,ItemNF.Qtde From ((NF Left Join ItemNF On NF.CDNF = ItemNF.CDNF) Left Join NaturezaOperacao On NF.CDNatOper = NaturezaOperacao.CDNatOper) Where Dis BetWeen Convert(DateTime,'" & VDataIni & "',103) And Convert(DateTime,'" & VDataFim & "',103) And CDCliente <> '000027' And STLan = 1 And Faturamento = 1 Order By CDProduto"
        '    End If
        '    If RSA.State = 1 Then RSA.Close()
        '    RSA.Open(VSQL, CN, adOpenStatic, adLockOptimistic)

        '    If RSA.RecordCount = 0 Then
        '        Beep()
        '        Screen.MousePointer = 0
        '        MsgBox("Não existe dados no período selecionado....Verifique", vbInformation)
        '        Exit Sub
        '    End If

        '    CN.Execute("Delete From RelTMP Where Terminal = '" & gTerminal & "'")

        '    If RSAT.State = 1 Then RSAT.Close()
        '    RSAT.Open("Select * From RelTMP", CN, adOpenStatic, adLockOptimistic)

        '    Do While Not RSA.EOF
        '        RSAT.AddNew()
        '        RSAT!Terminal = gTerminal
        '        RSAT!CDProduto = RSA!CDProduto
        '        RSAT!Qtde = RSA!Qtde
        '        RSAT.Update()
        '        RSA.MoveNext()
        '    Loop

        '    If RSA.State = 1 Then RSA.Close()
        '    RSA.Open("Select CDProduto, Sum(Qtde) As Total From RelTMP Where Terminal = '" & gTerminal & "' Group By CDProduto Order By CDProduto", CN, adOpenStatic, adLockOptimistic)


        '    If RadioMP.Checked = True Then

        '        VOpcao = " And Not CDProduto Between '1312001' And '1312044' And Not CDProduto Between '1313001' And '1313033' And Not CDProduto Between '1314001' And '1314027' And Not CDProduto Between '1315001' And '1315021' And Not CDProduto Between '1316000' And '1316019' And Not CDProduto Between '1317000' And '1317014' And Not CDProduto Between '1310001' And '1310002'"
        '        CN.Execute("Update Estoque Set Maximo = 0,Minimo = 0 Where Estoque = '2' And TipoCalculo = 'S'" & VOpcao)

        '        Do While Not RSA.EOF
        '            If IsNull(RSA!CDProduto) Then
        '                RSA.MoveNext()
        '            Else
        '                VCDProduto = RSA!CDProduto
        '                If RSA2.State = 1 Then RSA2.Close()
        '                RSA2.Open("Select * From Arvore Where CDProduto = '" & VCDProduto & "' Order By CDProduto,Posicao", CN, adOpenStatic, adLockOptimistic)
        '                If RSA2.RecordCount > 0 Then
        '                    Do While Not RSA2.EOF
        '                        If RSA1.State = 1 Then RSA1.Close()
        '                        RSA1.Open("Select * From Estoque Where Estoque = '2' And TipoCalculo = 'S'" & VOpcao & " and CDProduto = '" & RSA2!CDItem & "'", CN, adOpenStatic, adLockOptimistic)
        '                        If RSA1.RecordCount > 0 Then
        '                            If RSA1!QtdeMax > 0 Then
        '                                RSA1!Maximo = RSA1!Maximo + Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMax)
        '                            Else
        '                                RSA1!Maximo = RSA1!Maximo + Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMaximo.Text))
        '                            End If
        '                            If RSA1!QtdeMin > 0 Then
        '                                RSA1!Minimo = RSA1!Minimo + Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMin)
        '                            Else
        '                                RSA1!Minimo = RSA1!Minimo + Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMinimo.Text))
        '                            End If
        '                            If RSA1!QtdeMax = 0 Or IsNull(RSA1!QtdeMax) Then
        '                                RSA1!QtdeMax = TBMaximo.Text
        '                            End If
        '                            If RSA1!QtdeMin = 0 Or IsNull(RSA1!QtdeMin) Then
        '                                RSA1!QtdeMin = TBMinimo.Text
        '                            End If
        '          RSA1!DTCalculo = Date
        '                            RSA1.Update()
        '                        End If
        '                        RSA2.MoveNext()
        '                    Loop
        '                End If
        '                RSA.MoveNext()
        '            End If
        '        Loop
        '    ElseIf RadioSubCJ = True Then
        '        CN.Execute("Update Estoque Set Maximo = 0,Minimo = 0 Where Estoque = '4'  And TipoCalculo = 'S'")

        '        Do While Not RSA.EOF
        '            If IsNull(RSA!CDProduto) Then
        '                RSA.MoveNext()
        '            Else
        '                VCDProduto = RSA!CDProduto
        '                If RSA2.State = 1 Then RSA2.Close()
        '                RSA2.Open("Select * From EstruturaSubCJ Where CDProduto = '" & VCDProduto & "' Order By CDProduto,Posicao", CN, adOpenStatic, adLockOptimistic)
        '                If RSA2.RecordCount > 0 Then
        '                    Do While Not RSA2.EOF
        '                        If RSA1.State = 1 Then RSA1.Close()
        '                        RSA1.Open("Select * From Estoque Where Estoque = '4' And TipoCalculo = 'S' And CDProduto = '" & RSA2!CDItem & "' Order By CDProduto", CN, adOpenStatic, adLockOptimistic)
        '                        If RSA1.RecordCount > 0 Then
        '                            If RSA1!QtdeMax > 0 Then
        '                                If (((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMax) < 1 Then
        '                                    RSA1!Maximo = RSA1!Maximo + 1
        '                                Else
        '                                    RSA1!Maximo = RSA1!Maximo + (Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMax))
        '                                End If
        '                            Else
        '                                If (((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMaximo.Text)) < 1 Then
        '                                    RSA1!Maximo = RSA1!Maximo + 1
        '                                Else
        '                                    RSA1!Maximo = RSA1!Maximo + (Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMaximo.Text)))
        '                                End If
        '                            End If
        '                            If RSA1!QtdeMin > 0 Then
        '                                If (((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMin) < 1 Then
        '                                    RSA1!Minimo = RSA1!Minimo + 1
        '                                Else
        '                                    RSA1!Minimo = RSA1!Minimo + (Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * RSA1!QtdeMin))
        '                                End If
        '                            Else
        '                                If (((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMinimo.Text)) < 1 Then
        '                                    RSA1!Minimo = RSA1!Minimo + 1
        '                                Else
        '                                    RSA1!Minimo = RSA1!Minimo + (Int(((RSA!Total * RSA2!Qtde) / Val(TBMeses.Text)) * Val(TBMinimo.Text)))
        '                                End If
        '                            End If
        '                            If RSA1!QtdeMax = 0 Or IsNull(RSA1!QtdeMax) Then
        '                                RSA1!QtdeMax = TBMaximo.Text
        '                            End If
        '                            If RSA1!QtdeMin = 0 Or IsNull(RSA1!QtdeMin) Then
        '                                RSA1!QtdeMin = TBMinimo.Text
        '                            End If
        '                            RSA1.Update()
        '                        End If
        '                        RSA2.MoveNext()
        '                    Loop
        '                End If
        '                RSA.MoveNext()
        '            End If
        '        Loop
        '    ElseIf RadioUso = True Then 'Uso e Consumo

        '        CN.Execute("Delete From RelTMP Where Terminal = '" & gTerminal & "'")
        '        If RSAT.State = 1 Then RSAT.Close()
        '        RSAT.Open("Select * From RelTMP Where Terminal = '" & gTerminal & "'", CN, adOpenStatic, adLockOptimistic)

        '        VSQL = "Select OC.Dis,ItemOC.CDCodigo,ItemOC.Descricao,ItemOC.Qtde,ItemOC.Unidade From OC Left Join ItemOC On OC.CDOC = ItemOC.CDOC Where Dis BetWeen convert(datetime,'" & VDataIni & "',103) And convert(datetime,'" & VDataFim & "',103) Order By CDCodigo"
        '        'A
        '        If RSA.State = 1 Then RSA.Close()
        '        RSA.Open(VSQL, CN, adOpenStatic, adLockOptimistic)

        '        Do While Not RSA.EOF
        '            RSAT.AddNew()
        '            RSAT!Terminal = gTerminal
        '            RSAT!CDProduto = RSA!CDCodigo
        '            RSAT!Qtde = RSA!Qtde
        '            RSAT.Update()
        '            RSA.MoveNext()
        '        Loop

        '        VSQL = "Select OC.Dis,ItemOC.CDCodigo,ItemOC.Descricao,ItemOC.Qtde,ItemOC.Unidade From OC Left Join ItemOC On OC.CDOC = ItemOC.CDOC Where Dis BetWeen convert(datetime,'" & VDataIni & "',103) And convert(datetime,'" & VDataFim & "',103) Order By CDCodigo"
        '        'B
        '        If RSA.State = 1 Then RSA.Close()
        '        RSA.Open(VSQL, CN2, adOpenStatic, adLockOptimistic)

        '        Do While Not RSA.EOF
        '            RSAT.AddNew()
        '            RSAT!Terminal = gTerminal
        '            RSAT!CDProduto = RSA!CDCodigo
        '            RSAT!Qtde = RSA!Qtde
        '            RSAT.Update()
        '            RSA.MoveNext()
        '        Loop
        '        If RSA.State = 1 Then RSA.Close()
        '        RSA.Open("Select CDProduto, Sum(Qtde) As Total From RelTMP Where Terminal = '" & gTerminal & "' Group By CDProduto Order By CDProduto", CN, adOpenStatic, adLockOptimistic)

        '        CN.Execute("Update Estoque Set Maximo = 0,Minimo = 0 Where Estoque = '3'")

        '        Do While Not RSA.EOF
        '            If IsNull(RSA!CDProduto) Then
        '                RSA.MoveNext()
        '            Else
        '                If RSA1.State = 1 Then RSA1.Close()
        '                RSA1.Open("Select * From Estoque Where Estoque = '3' And TipoCalculo = 'S' and CDProduto = '" & RSA!CDProduto & "' Order By CDProduto", CN, adOpenStatic, adLockOptimistic)
        '                If RSA1.RecordCount > 0 Then
        '                    If RSA1!QtdeMax > 0 Then
        '                        If ((RSA!Total / Val(TBMeses.Text)) * RSA1!QtdeMax) < 1 Then
        '                            RSA1!Maximo = RSA1!Maximo + 1
        '                        Else
        '                            RSA1!Maximo = RSA1!Maximo + (Int((RSA!Total / Val(TBMeses.Text)) * RSA1!QtdeMax))
        '                        End If
        '                    Else
        '                        If ((RSA!Total / Val(TBMeses.Text)) * Val(TBMaximo.Text)) < 1 Then
        '                            RSA1!Maximo = RSA1!Maximo + 1
        '                        Else
        '                            RSA1!Maximo = RSA1!Maximo + (Int((RSA!Total / Val(TBMeses.Text)) * Val(TBMaximo.Text)))
        '                        End If
        '                    End If
        '                    If RSA1!QtdeMin > 0 Then
        '                        If ((RSA!Total / Val(TBMeses.Text)) * RSA1!QtdeMin) < 1 Then
        '                            RSA1!Minimo = RSA1!Minimo + 1
        '                        Else
        '                            RSA1!Minimo = RSA1!Minimo + (Int((RSA!Total / Val(TBMeses.Text)) * RSA1!QtdeMin))
        '                        End If
        '                    Else
        '                        If ((RSA!Total / Val(TBMeses.Text)) * Val(TBMinimo.Text)) < 1 Then
        '                            RSA1!Minimo = RSA1!Minimo + 1
        '                        Else
        '                            RSA1!Minimo = RSA1!Minimo + (Int((RSA!Total / Val(TBMeses.Text)) * Val(TBMinimo.Text)))
        '                        End If
        '                    End If
        '                    If RSA1!QtdeMax = 0 Or IsNull(RSA1!QtdeMax) Then
        '                        RSA1!QtdeMax = TBMaximo.Text
        '                    End If
        '                    If RSA1!QtdeMin = 0 Or IsNull(RSA1!QtdeMin) Then
        '                        RSA1!QtdeMin = TBMinimo.Text
        '                    End If
        '                    RSA1.Update()
        '                End If
        '            End If
        '            RSA.MoveNext()
        '        Loop
        '    End If
        'End If
    End Sub
End Class