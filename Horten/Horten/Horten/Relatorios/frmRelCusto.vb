Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmRelCusto
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor
        If ckIndustrial.Checked = True Then
            GridColumn4.Caption = "VL. Hora"
            GridColumn7.Caption = "Saldo (Hora)"
        Else
            GridColumn4.Caption = "VL. Última Compra"
            GridColumn7.Caption = "Saldo (Qtde)"
        End If
        Dim sBusca As String = ""
        Dim sBuscaK As String = ""
        Dim bImp As Boolean = True
        Dim dSaldoKardex, dSaldoK1, dSaldoK2 As Decimal
        Dim dCustoMedio, dLucro, dQTUltCom As Decimal
        Dim sDTUltCom As String = ""
        Dim dVLUltCom As Decimal = 0
        Dim dValor As Decimal = 0
        Dim dQtdeEstrutura As Decimal = 0

        Dim dValorTotal As Decimal
        Dim dSaldoTotal As Decimal
        Dim dSaldoEstrutura As Decimal
        If ckAtivos.Checked = True Then
            sBusca &= " And Idle = 0 "
        End If
        sBusca &= " And Estoque='" & cbTipoEstoque.SelectedIndex & "' and Left(CDProduto, 4) <> '1001' And left(CDProduto, 4) <> '1002' And left(CDProduto, 4) <> '1004'"


        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2
        conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL3.Open()
        querySQL3.Connection = conSQL3

        '"Dropa" tabelas temporarias
        Try
            querySQl.CommandText = "Delete from TMP_RelCusto where Terminal='" & gTerminal & "'"
            querySQl.ExecuteNonQuery()
        Catch
        End Try

        If cbTipoEstoque.SelectedIndex <> 1 Then
            querySQL2.CommandText = "Select * from Estoque where not CDProduto Is NULL " & sBusca & " order by CDProduto"
        Else
            querySQL2.CommandText = "Select CDProduto, VLUnitario as VLUltCom,Descricao,Unidade from ListaPreco where not CDProduto Is NULL and Tipo='" & gListaPadrao & "' and CDEmpresa='" & gEmpresa & "' order by CDProduto"
        End If
        datRead2 = querySQL2.ExecuteReader()

        If cbTipoEstoque.SelectedIndex < 3 Then
            Do Until datRead2.Read = False
                Try
                    querySQl.CommandText = "Select Top 1 Saldo From Kardex Where CDProduto = '" & datRead2("CDProduto") & "' Order By Registro Desc"
                    dSaldoK1 = querySQl.ExecuteScalar()
                Catch
                    dSaldoK1 = 0
                End Try

                Try
                    querySQl.CommandText = "Select Top 1 Saldo From Kardex2 Where CDProduto = '" & datRead2("CDProduto") & "' Order By Registro Desc"
                    dSaldoK2 = querySQl.ExecuteScalar()
                Catch
                    dSaldoK2 = 0
                End Try

                dSaldoKardex = dSaldoK1 + dSaldoK2

                If RadioPositivo.Checked = True Then
                    If dSaldoKardex > 0 Then
                        bImp = True
                    Else
                        bImp = False
                    End If
                End If
                If RadioNegativo.Checked = True Then
                    If dSaldoKardex <= 0 Then
                        bImp = True
                    Else
                        bImp = False
                    End If
                End If

                If bImp = True Then
                    Try
                        dCustoMedio = datRead2("CustoMedio")
                    Catch
                        dCustoMedio = 0
                    End Try
                    Try
                        dLucro = ((datRead2("Valor") * 100) / dCustoMedio) - 100
                    Catch ex As Exception
                        dLucro = 0
                    End Try
                    Try
                        dQTUltCom = datRead2("QTUltCom")
                    Catch ex As Exception
                        dQTUltCom = 0
                    End Try
                    Try
                        If datRead2("DTUltCom") <> "" Then
                            sDTUltCom = "convert(datetime,'" & datRead2("DTUltCom") & "',103)"
                        Else
                            sDTUltCom = "NULL"
                        End If
                    Catch ex As Exception
                        sDTUltCom = "NULL"
                    End Try
                    Try
                        dVLUltCom = datRead2("VLUltCom")
                    Catch ex As Exception
                        dVLUltCom = 0
                    End Try
                    Try
                        dValor = dSaldoKardex * dVLUltCom
                    Catch ex As Exception
                        dValor = 0
                    End Try

                    gVSQL = "insert into Prisma.dbo.TMP_RelCusto (Terminal,CDProduto,Descricao,Unidade,Saldo,CustoMedio,Lucro,QTUltCom,VLUltCom,DTUltCom,ValorTotal) values "
                    gVSQL &= "('" & gTerminal & "','" & datRead2("CDProduto") & "','" & datRead2("Descricao") & "','" & datRead2("Unidade") & "'," & Replace(dSaldoKardex, ",", ".") & ""
                    gVSQL &= "," & Replace(dCustoMedio, ",", ".") & "," & Replace(dLucro, ",", ".") & "," & Replace(dQTUltCom, ",", ".") & ""
                    gVSQL &= "," & Replace(dVLUltCom, ",", ".") & "," & sDTUltCom & "," & Replace(dValor, ",", ".") & ")"
                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()

                End If
            Loop
        Else
            Dim VSQL As String
            Do Until datRead2.Read = False
                Try
                    vsql = "Select Top 1 Saldo From  Kardex Where CDProduto = '" & datRead2("CDProduto") & "' Order By Registro Desc"
                    querySQl.CommandText = "Select Top 1 Saldo From  Kardex Where CDProduto = '" & datRead2("CDProduto") & "' Order By Registro Desc"
                    dSaldoK1 = querySQl.ExecuteScalar()
                Catch
                    dSaldoK1 = 0
                End Try

                Try
                    querySQl.CommandText = "Select Top 1 Saldo From  Kardex2 Where CDProduto = '" & datRead2("CDProduto") & "' Order By Registro Desc"
                    dSaldoK2 = querySQl.ExecuteScalar()
                Catch
                    dSaldoK2 = 0
                End Try

                dSaldoKardex = dSaldoK1 + dSaldoK2

                If RadioPositivo.Checked = True Then
                    If dSaldoKardex > 0 Then
                        bImp = True
                    Else
                        bImp = False
                    End If
                End If

                If RadioNegativo.Checked = True Then
                    If dSaldoKardex <= 0 Then
                        bImp = True
                    Else
                        bImp = False
                    End If
                End If

                If bImp = True Then
                    Try
                        dCustoMedio = datRead2("CustoMedio")
                    Catch
                        dCustoMedio = 0
                    End Try
                    Try
                        dLucro = ((datRead2("Valor") * 100) / dCustoMedio) - 100
                    Catch ex As Exception
                        dLucro = 0
                    End Try
                    Try
                        dQTUltCom = datRead2("QTUltCom")
                    Catch ex As Exception
                        dQTUltCom = 0
                    End Try
                    Try
                        If datRead2("DTUltCom") <> "" Then
                            sDTUltCom = "convert(datetime,'" & datRead2("DTUltCom") & "',103)"
                        Else
                            sDTUltCom = "NULL"
                        End If
                    Catch ex As Exception
                        sDTUltCom = "NULL"
                    End Try

                    Try
                        If ckIndustrial.Checked = True Then
                            dVLUltCom = 0
                        Else
                            dVLUltCom = datRead2("VLUltCom")
                        End If

                    Catch ex As Exception
                        dVLUltCom = 0
                    End Try

                    'Pega Valor de Custo
                    If ckIndustrial.Checked = True Then
                        querySQL3.CommandText = "Select * From EstruturaMPC Where CDComponente = '" & datRead2("CDProduto") & "' And CDMaterial = 'AAAAAAA' and Cenario=1 order by CDMaterial"
                    Else
                        querySQL3.CommandText = "Select * From EstruturaMPC Where CDComponente = '" & datRead2("CDProduto") & "' And CDMaterial <> 'AAAAAAA' And CDMaterial <> 'BBBBBBB' And CDMaterial <> 'CCCCCCC' And CDMaterial <> 'DDDDDDD' and Cenario=1 order by CDMaterial"
                    End If

                    datRead3 = querySQL3.ExecuteReader()
                    dQtdeEstrutura = 0
                    Do Until datRead3.Read = False
                        If datRead2("CDProduto") = "7319006" Then
                            'MsgBox(datRead3("CDMaterial"))
                        End If
                        Try
                            dVLUltCom = datRead3("Valor")
                            dQtdeEstrutura = datRead3("Qtde")
                        Catch
                            dVLUltCom = 0
                            dQtdeEstrutura = 0
                        End Try


                        If ckIndustrial.Checked = True Then
                            Try
                                dSaldoEstrutura = dSaldoKardex * dQtdeEstrutura
                                dValor = dSaldoEstrutura * dVLUltCom
                            Catch ex As Exception
                                dValor = 0
                            End Try
                        Else
                            Try
                                dSaldoEstrutura = dSaldoKardex * dQtdeEstrutura
                                dValor = dSaldoEstrutura * dVLUltCom
                            Catch ex As Exception
                                dValor = 0
                            End Try
                        End If

                        dValorTotal += dValor
                        If ckIndustrial.Checked = True Then
                            dSaldoTotal += dSaldoEstrutura
                        Else
                            dSaldoTotal = dSaldoKardex
                        End If
                    Loop

                    datRead3.Close()
                    gVSQL = "insert into Prisma.dbo.TMP_RelCusto (Terminal,CDProduto,Descricao,Unidade,Saldo,CustoMedio,Lucro,QTUltCom,VLUltCom,DTUltCom,ValorTotal) values "
                    gVSQL &= "('" & gTerminal & "','" & datRead2("CDProduto") & "','" & datRead2("Descricao") & "','" & datRead2("Unidade") & "'," & Replace(dSaldoTotal, ",", ".") & ""
                    gVSQL &= "," & Replace(dCustoMedio, ",", ".") & "," & Replace(dLucro, ",", ".") & "," & Replace(dQTUltCom, ",", ".") & ""
                    gVSQL &= "," & Replace(dVLUltCom, ",", ".") & "," & sDTUltCom & "," & Replace(dValorTotal, ",", ".") & ")"
                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()

                    dSaldoTotal = 0
                    dValorTotal = 0
                End If
            Loop
        End If

        datRead2.Close()
        conSQL.Close()
        conSQL2.Close()
        conSQL3.Close()

        ds.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from TMP_RelCusto where Terminal='" & gTerminal & "'", conSQL2)
        adaptSQL.Fill(ds, "Custo")
        GridControl1.DataSource = ds.Tables("Custo")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmRelCusto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbTipoEstoque.Items.Add("0 - Selecione")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 1
    End Sub

    Private Sub bt0Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Imprimir.Click
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With
        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView1.GridControl
        link.Margins.Left = 40
        link.Margins.Right = 40
        link.Landscape = False
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add(Date.Now.ToShortDateString())
        HeaderArea.Content.Add("Relatório de Custo: " & cbTipoEstoque.SelectedItem)
        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center
        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        link.PageHeaderFooter = Header
        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckAtivos.CheckedChanged

    End Sub
End Class