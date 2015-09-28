Imports DevExpress.Data.PivotGrid
Imports DevExpress.XtraPivotGrid

Imports DevExpress.XtraPrinting

Public Class frmBalanco
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub frmBalanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbTipoEstoque.Items.Add("0 - Todos os Itens")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 2

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)


    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        Me.Cursor = Cursors.WaitCursor

        'Quebrar essas consultas por quantidade de meses selecionados

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        querySQl.CommandText = "Delete from TMP_PivotBalancoEstoque"
        querySQl.ExecuteNonQuery()

        Dim dDataIni As Date = cbDe.Text
        Dim dDataFim As Date = cbAte.Text
        Dim dDataDiff As TimeSpan = dDataFim.Subtract(dDataIni)
        Dim dTotalMeses As Integer = Math.Round(dDataDiff.Days / 30)

        Dim dDataIniConsulta, dDataFimConsulta As Date
        Dim dQtde, dValor As Decimal
        For x = 0 To dTotalMeses - 1 Step 1
            dDataIniConsulta = dDataIni.AddMonths(x)
            dDataFimConsulta = dDataIni.AddMonths(x + 1)
            If ckKardex2.Checked = False Then
                '# se form material acabado pega valor da lista de preco
                If cbTipoEstoque.SelectedIndex <> 1 Then
                    gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, a.VLUltCom,(select top 1 c.Saldo from Kardex c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data) as Saldo "
                    gVSQL &= " from Estoque a where a.Estoque='" & cbTipoEstoque.SelectedIndex & "'  order by a.CDProduto"
                Else
                    gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, b.VLUnitario as VLUltCom,(select top 1 c.Saldo from Kardex c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data) as Saldo "
                    gVSQL &= " from Estoque a, ListaPreco b where a.Estoque='" & cbTipoEstoque.SelectedIndex & "' and a.CDProduto=b.CDProduto and b.CDEmpresa='" & gEmpresa & "' and b.Tipo='" & gListaPadrao & "' order by a.CDProduto"
                End If
            Else
                gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, a.VLUltCom,(select top 1 c.Saldo from Kardex2 c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data) as Saldo "
                gVSQL &= " from Estoque a where a.Estoque='" & cbTipoEstoque.SelectedIndex & "'  order by a.CDProduto"
            End If
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            Do Until datRead.Read = False
                Try
                    dQtde = datRead("Saldo")
                Catch ex As Exception
                    '## se nao acha registro, seleciono o ultimo
                    Try
                        If ckKardex2.Checked = False Then
                            querySQL2.CommandText = "Select top 1 Saldo from Kardex where CDProduto='" & datRead("CDProduto") & "' and data<=convert(datetime,'" & dDataIniConsulta & "',103) order by data desc"
                        Else
                            querySQL2.CommandText = "Select top 1 Saldo from Kardex2 where CDProduto='" & datRead("CDProduto") & "' and data<=convert(datetime,'" & dDataIniConsulta & "',103) order by data desc"
                        End If
                        dQtde = querySQL2.ExecuteScalar()
                    Catch
                    End Try
                End Try
                Try
                    dValor = datRead("VLUltCom")
                Catch ex As Exception
                    dValor = 0
                End Try
                gVSQL = "Insert into TMP_PivotBalancoEstoque (Mes,Ano,CDProduto,Descricao,QtdeInicial,ValorInicial) values ('" & dDataIniConsulta.Month() & "','" & dDataIniConsulta.Year() & "','" & datRead("CDProduto") & "','" & datRead("Descricao") & "'," & Replace(dQtde, ",", ".") & "," & Replace(dValor, ",", ".") & ")"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()
            Loop
            datRead.Close()

            If ckKardex2.Checked = False Then
                '# se form material acabado pega valor da lista de preco
                If cbTipoEstoque.SelectedIndex <> 1 Then
                    gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, a.VLUltCom,(select top 1 c.Saldo from Kardex c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data desc) as Saldo"
                    gVSQL &= " from Estoque a where a.Estoque='" & cbTipoEstoque.SelectedIndex & "' order by a.CDProduto desc"
                Else
                    gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, b.VLUnitario as VLUltCom,(select top 1 c.Saldo from Kardex c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data Desc) as Saldo "
                    gVSQL &= " from Estoque a, ListaPreco b where a.Estoque='" & cbTipoEstoque.SelectedIndex & "' and a.CDProduto=b.CDProduto and b.CDEmpresa='" & gEmpresa & "' and b.Tipo='" & gListaPadrao & "' order by a.CDProduto Desc"
                End If
            Else
                gVSQL = "select a.CDProduto, a.Descricao, a.Estoque, a.VLUltCom,(select top 1 c.Saldo from Kardex2 c where a.cdproduto=c.cdproduto and c.data >= convert(datetime,'" & dDataIniConsulta & "',103) and c.data <= convert(datetime,'" & dDataFimConsulta & "',103) order by c.data desc) as Saldo"
                gVSQL &= " from Estoque a where a.Estoque='" & cbTipoEstoque.SelectedIndex & "' order by a.CDProduto desc"
            End If
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            Do Until datRead.Read = False
                Try
                    dQtde = datRead("Saldo")
                Catch ex As Exception
                    '## se nao acha registro, seleciono o ultimo
                    Try
                        If ckKardex2.Checked = False Then
                            querySQL2.CommandText = "Select top 1 Saldo from Kardex where CDProduto='" & datRead("CDProduto") & "' and data<=convert(datetime,'" & dDataFimConsulta & "',103) order by data desc"
                        Else
                            querySQL2.CommandText = "Select top 1 Saldo from Kardex2 where CDProduto='" & datRead("CDProduto") & "' and data<=convert(datetime,'" & dDataFimConsulta & "',103) order by data desc"
                        End If
                        dQtde = querySQL2.ExecuteScalar()
                    Catch
                        dQtde = 0
                    End Try
                End Try
                Try
                    dValor = datRead("VLUltCom")
                Catch ex As Exception
                    dValor = 0
                End Try
                gVSQL = "update TMP_PivotBalancoEstoque set QtdeFinal=" & Replace(dQtde, ",", ".") & ", ValorFinal=" & Replace(dValor, ",", ".") & " where Mes='" & dDataIniConsulta.Month() & "' and Ano='" & dDataIniConsulta.Year() & "' and CDProduto='" & datRead("CDProduto") & "'"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()
            Loop
                datRead.Close()
        Next
        conSQL.Close()
        conSQL2.Close()


        ds.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select Mes,Ano,CDProduto,Descricao,QtdeInicial,(QtdeInicial * ValorInicial) as VLInicial, QtdeFinal,(QtdeFinal * ValorFinal) as VLFinal from tmp_pivotbalancoestoque", conSQL2)
        adaptSQL.Fill(ds, "Grid")
        gridBalanco.DataSource = ds.Tables("Grid")

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PivotGridField8.Visible = False
            PivotGridField7.Visible = False
        Else
            PivotGridField8.Visible = True
            PivotGridField7.Visible = True
        End If
    End Sub
    Public Sub imprimir()
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With

        Dim link As New PrintableComponentLink(ps)
        link.Component = gridBalanco
        link.Margins.Left = 30
        link.Margins.Right = 30
        link.Margins.Bottom = 30
        link.Margins.Top = 50
        link.Landscape = True
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        Dim sData As String = Date.Now.ToShortDateString()
        HeaderArea.Content.Add(sData)

        HeaderArea.Content.Add("Balanço Mensal de Estoque")

        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 13.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center

        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        Header.Header.LineAlignment = BrickAlignment.Center
        link.PageHeaderFooter = Header

        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub
End Class