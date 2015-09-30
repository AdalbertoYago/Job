Imports DevExpress.XtraReports.UI
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Public Class FRMRecebimento
    Public VTab As String
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public adaptOC, adaptFO, adaptCO, adaptRH, adaptCQ As SqlClient.SqlDataAdapter
    Public datPubsOC, datPubsFO, datPubsCO, datPubsRH, datPubsCQ As New DataSet()
    Public sParam As ClassParametros = New ClassParametros()
    Private Sub FRMRecebimento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        XtraTabControl1.SelectedTabPage = XtraTabPage1
        BTEMail.Enabled = False
        If gEntradaEstoqueViaRecebimento = True Then
            BTBaixar.Enabled = True
            BTEstornar.Enabled = True
        Else
            BTBaixar.Enabled = False
            BTEstornar.Enabled = False
        End If
        MontaQuery()
    End Sub
    Private Sub BTSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSair.Click
        Me.Close()

    End Sub
    Private Sub MontaQuery()
        If XtraTabControl1.SelectedTabPage.Text = "Ordens de Compra" Then
            VSQL = "Select OC.CDEmpresa,OC.CDOC,OC.Dis,ItemOC.IPI,Fantasia,OC.Frete,OC.DTEntrega,OC.DTPrevEntrega,DateDiff(d,Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),OC.DTPrevEntrega) As Atraso,OC.CDFornec,OC.CDComprador,CDItem,CDCodigo,Descricao,Unidade,Qtde,Saldo,VLUnitario,(Qtde * VLUnitario) As Total,ItemOC.Observacao From OC Left Join ItemOC On OC.CDEmpresa = ItemOC.CDEmpresa And OC.CDOC = ItemOC.CDOC Left Join Fornecedores On OC.CDFornec = Fornecedores.CDFornec Where Saldo > 0 Union All "
            VSQL = VSQL & "Select OC.CDEmpresa,OC.CDOC,OC.Dis,ItemOC.IPI,Fantasia,OC.Frete,OC.DTEntrega,OC.DTPrevEntrega,DateDiff(d,Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),OC.DTPrevEntrega) As Atraso,OC.CDFornec,OC.CDComprador,CDItem,CDCodigo,Descricao,Unidade,Qtde,Saldo,VLUnitario,(Qtde * VLUnitario) As Total,ItemOC.Observacao From Prisma2.dbo.OC Left Join Prisma2.dbo.ItemOC On OC.CDEmpresa = ItemOC.CDEmpresa And OC.CDOC = ItemOC.CDOC Left Join Fornecedores On Prisma2.dbo.OC.CDFornec = Prisma.dbo.Fornecedores.CDFornec Where Saldo > 0 Order By DTPrevEntrega"
            datPubsOC.Clear()
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            adaptOC = New SqlClient.SqlDataAdapter(VSQL, conSQL)
            adaptOC.Fill(datPubsOC, "OC")
            GridControl1.DataSource = datPubsOC.Tables("OC")

            Dim styleCondition1 As StyleFormatCondition = New StyleFormatCondition()
            GridView1.FormatConditions.Add(styleCondition1)
            styleCondition1.Column = GridView1.Columns("Atraso")
            styleCondition1.Condition = FormatConditionEnum.Less
            styleCondition1.Value1 = 0
            styleCondition1.Appearance.BackColor = Color.Red
            styleCondition1.Appearance.ForeColor = Color.Yellow
            styleCondition1.Appearance.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)

            Dim styleCondition2 As StyleFormatCondition = New StyleFormatCondition()
            GridView1.FormatConditions.Add(styleCondition2)
            styleCondition2.Column = GridView1.Columns("Atraso")
            styleCondition2.Condition = FormatConditionEnum.GreaterOrEqual
            styleCondition2.Value1 = 0
            styleCondition2.Appearance.BackColor = Color.Green
            styleCondition2.Appearance.ForeColor = Color.Black
            styleCondition2.Appearance.Font = New Font(GridView1.Appearance.Row.Font, FontStyle.Bold)

            datPubsFO.Clear()
            adaptFO = New SqlClient.SqlDataAdapter("Select CDFornec,Fantasia From Fornecedores", conSQL)
            adaptFO.Fill(datPubsFO, "FO")
            RepositoryItemLookUpEdit1.DataSource = datPubsFO.Tables("FO")

            datPubsCO.Clear()
            adaptCO = New SqlClient.SqlDataAdapter("Select CDVendedor,NMFantasia From Vendedores", conSQL)
            adaptCO.Fill(datPubsCO, "CO")
            RepositoryItemLookUpEdit2.DataSource = datPubsCO.Tables("CO")
        ElseIf XtraTabControl1.SelectedTabPage.Text = "Recebimentos" Then
            Try
                Dim Row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                VSQL = "Select * From RecebimentoHistorico Where CDEmpresa = '" & Row("CDEmpresa") & "' And CDOC = '" & Row("CDOC") & "' Order By CDItem"
                datPubsRH.Clear()
                adaptRH = New SqlClient.SqlDataAdapter(VSQL, conSQL)
                adaptRH.Fill(datPubsRH, "RH")
                GridControl2.DataSource = datPubsRH.Tables("RH")
            Catch
            End Try
        ElseIf XtraTabControl1.SelectedTabPage.Text = "Controle de Qualidade" Then
            Try
                Dim Row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                VSQL = "Select RecebimentoHistorico.*,"
                VSQL &= "(Select Top 1 Saldo From Kardex Where CDProduto = RecebimentoHistorico.CDProduto Order By Registro Desc) As Estoque, "
                VSQL &= "(Select Top 1 Saldo From Kardex2 Where CDProduto = RecebimentoHistorico.CDProduto Order By Registro Desc) As Empenho, "
                VSQL &= "(Select Observacao From ItemOC Where CDEmpresa = RecebimentoHistorico.CDEmpresa And CDOC = RecebimentoHistorico.CDOC And CDItem = RecebimentoHistorico.CDItem) As Observacao "
                VSQL &= "From RecebimentoHistorico Where CQ = 1 And DTBaixa Is NULL Order By Prioridade Desc"
                datPubsCQ.Clear()
                adaptCQ = New SqlClient.SqlDataAdapter(VSQL, conSQL)
                adaptCQ.Fill(datPubsCQ, "RH")
                GridControl3.DataSource = datPubsCQ.Tables("RH")

                Dim styleCondition1 As StyleFormatCondition = New StyleFormatCondition()
                GridView3.FormatConditions.Add(styleCondition1)
                styleCondition1.Column = GridView3.Columns("Estoque")
                styleCondition1.Condition = FormatConditionEnum.LessOrEqual
                styleCondition1.Value1 = 0
                styleCondition1.Appearance.BackColor = Color.Red
                styleCondition1.Appearance.ForeColor = Color.Yellow
                styleCondition1.Appearance.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)

                Dim styleCondition2 As StyleFormatCondition = New StyleFormatCondition()
                GridView3.FormatConditions.Add(styleCondition2)
                styleCondition2.Column = GridView3.Columns("Estoque")
                styleCondition2.Condition = FormatConditionEnum.Greater
                styleCondition2.Value1 = 0
                styleCondition2.Appearance.BackColor = Color.Green
                styleCondition2.Appearance.ForeColor = Color.Black
                styleCondition2.Appearance.Font = New Font(GridView3.Appearance.Row.Font, FontStyle.Bold)

            Catch
            End Try
        End If
    End Sub
    Private Sub XtraTabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XtraTabControl1.Click
        If XtraTabControl1.SelectedTabPage.Text = "Recebimentos" Then
            BTVerTodas.Enabled = False
            BTIncItens.Enabled = False
            BTEMail.Enabled = True
            MontaQuery()
        ElseIf XtraTabControl1.SelectedTabPage.Text = "Controle de Qualidade" Then
            BTVerTodas.Enabled = False
            BTIncItens.Enabled = False
            BTEMail.Enabled = True
            MontaQuery()
        Else
            BTVerTodas.Enabled = True
            BTIncItens.Enabled = True
            BTEMail.Enabled = False
        End If
    End Sub
    Private Sub GridControl2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl2.KeyUp
        'Exclusão de registros
        If e.KeyCode = Keys.Delete Then
            'If sParam.selPermissoes(231, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = False Then
            '    MessageBox.Show("Seu perfil não tem acesso a essa opção.....Contate o Administrador", "Nivel de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
            If MessageBox.Show("Deseja excluir o Recebimento Selecionado", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
                Dim VCDOC As String = row("CDOC")
                Try
                    conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL.Open()
                    querySQl.Connection = conSQL
                    querySQl.CommandText = "Delete From RecebimentoHistorico Where Id = " & row("Id")
                    querySQl.ExecuteNonQuery()
                    conSQL.Close()
                    row.Delete()
                    LogIn(gUsuario, "RM da OC " & VCDOC & " Excluído em " & Now.Date.ToShortDateString & " as " & Now.TimeOfDay.ToString.Substring(0, 5))
                Catch
                    conSQL.Close()
                End Try
            End If
        End If
    End Sub
    Private Sub Gridview2_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView2.RowUpdated
        Dim Row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        Try
            If Row.RowState = DataRowState.Modified Then
                Dim VCQ As Integer = 0
                If Row("CQ") Is DBNull.Value Then
                    VCQ = 0
                Else
                    VCQ = 1
                End If
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                querySQl.Connection = conSQL
                VSQL = "UPDATE RecebimentoHistorico SET "
                VSQL = VSQL & "CDEmpresa = '" & Row("CDEmpresa") & "',"
                VSQL = VSQL & "CDNF = '" & Row("CDNF") & "',"
                If IsDate(Row("DTNF")) Then
                    VSQL = VSQL & "DTNF = Convert(DateTime,'" & Row("DTNF") & "',103),"
                Else
                    VSQL = VSQL & "DTNF = NULL,"
                End If
                VSQL = VSQL & "CDOC = '" & StrZero(Row("CDOC"), 6) & "',"
                VSQL = VSQL & "CDProduto = '" & Row("CDProduto") & "',"
                VSQL = VSQL & "Descricao = '" & Row("Descricao") & "',"
                VSQL = VSQL & "Recebedor = '" & UCase(Row("Recebedor")) & "',"
                VSQL = VSQL & "Unidade = '" & Row("Unidade") & "',"
                VSQL = VSQL & "VLUnitario = " & CDBNumber(Row("VLUnitario")) & ","
                VSQL = VSQL & "Qtde = " & CDBNumber(Row("Qtde")) & ","
                VSQL = VSQL & "QtdeRecebida = " & CDBNumber(Row("QtdeRecebida")) & ","
                VSQL = VSQL & "QtdeAprovada = " & CDBNumber(Row("QtdeAprovada")) & ","
                VSQL = VSQL & "QtdeReprovada = " & CDBNumber(Row("QtdeReprovada")) & ","
                VSQL = VSQL & "CQ = " & VCQ & ","
                If IsDate(Row("DTBaixa")) Then
                    VSQL = VSQL & "DTBaixa = Convert(DateTime,'" & Row("DTBaixa") & "',103) "
                Else
                    VSQL = VSQL & "DTBaixa = NULL "
                End If
                VSQL = VSQL & " WHERE Id = " & Row("Id")
                querySQl.CommandText = VSQL
                querySQl.ExecuteNonQuery()
                conSQL.Close()
            End If
        Catch
            conSQL.Close()
        End Try
    End Sub
    Private Sub Gridview3_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView3.RowUpdated
        Dim Row As System.Data.DataRow = GridView3.GetDataRow(GridView3.FocusedRowHandle)
        Try
            If Row.RowState = DataRowState.Modified Then
                Dim VCQ As Integer = 0
                If Row("CQ") = True Then
                    VCQ = 1
                Else
                    VCQ = 0
                End If
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                querySQl.Connection = conSQL
                VSQL = "UPDATE RecebimentoHistorico SET "
                VSQL = VSQL & "CDEmpresa = '" & Row("CDEmpresa") & "',"
                VSQL = VSQL & "CDNF = '" & Row("CDNF") & "',"
                If IsDate(Row("DTNF")) Then
                    VSQL = VSQL & "DTNF = Convert(DateTime,'" & Row("DTNF") & "',103),"
                Else
                    VSQL = VSQL & "DTNF = NULL,"
                End If
                VSQL = VSQL & "CDOC = '" & StrZero(Row("CDOC"), 6) & "',"
                VSQL = VSQL & "CDProduto = '" & Row("CDProduto") & "',"
                VSQL = VSQL & "Descricao = '" & Row("Descricao") & "',"
                VSQL = VSQL & "Recebedor = '" & UCase(Row("Recebedor")) & "',"
                VSQL = VSQL & "Unidade = '" & Row("Unidade") & "',"
                VSQL = VSQL & "VLUnitario = " & CDBNumber(Row("VLUnitario")) & ","
                VSQL = VSQL & "Qtde = " & CDBNumber(Row("Qtde")) & ","
                VSQL = VSQL & "QtdeRecebida = " & CDBNumber(Row("QtdeRecebida")) & ","
                VSQL = VSQL & "QtdeAprovada = " & CDBNumber(Row("QtdeAprovada")) & ","
                VSQL = VSQL & "QtdeReprovada = " & CDBNumber(Row("QtdeReprovada")) & ","
                VSQL = VSQL & "CQ = " & VCQ & ","
                If IsDate(Row("DTBaixa")) Then
                    VSQL = VSQL & "DTBaixa = Convert(DateTime,'" & Row("DTBaixa") & "',103), "
                Else
                    VSQL = VSQL & "DTBaixa = NULL, "
                End If
                If Row("Prioridade") Is DBNull.Value Then
                    VSQL = VSQL & "Prioridade = 0,"
                Else
                    VSQL = VSQL & "Prioridade = " & CDBNumber(Row("Prioridade")) & ","
                End If
                If Row("QtdePrior") Is DBNull.Value Then
                    VSQL = VSQL & "QtdePrior = 0"
                Else
                    VSQL = VSQL & "QtdePrior = " & CDBNumber(Row("QtdePrior"))
                End If
                VSQL = VSQL & " WHERE Id = " & Row("Id")
                querySQl.CommandText = VSQL
                querySQl.ExecuteNonQuery()
                conSQL.Close()
            End If
        Catch
            conSQL.Close()
        End Try
    End Sub
    Private Sub BTSair_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSair.Click
        Me.Close()
    End Sub
    Private Sub BTImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTImprimir.Click
        'If sParam.selPermissoes(307, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = False Then
        '    MessageBox.Show("Seu perfil não tem acesso a essa opção.....Contate o Administrador", "Nivel de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With
        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView2.GridControl
        link.Landscape = True
        link.PaperKind = System.Drawing.Printing.PaperKind.A4
        link.Margins.Top = 40
        link.Margins.Bottom = 10
        link.Margins.Left = 10
        link.Margins.Right = 10
        link.EnablePageDialog = True
        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add("RECEBIMENTO DE MATERIAIS")
        HeaderArea.Font = New Font("Arial", 13.0F, FontStyle.Bold, GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center
        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        link.PageHeaderFooter = Header
        'link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub
    Private Sub BTAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTAlterar.Click
        'If sParam.selPermissoes(306, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = False Then
        '    MessageBox.Show("Seu perfil não tem acesso a essa opção.....Contate o Administrador", "Nivel de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'XtraTabControl1.SelectedTabPage = XtraTabPage2
        MontaQuery()
        GridView2.OptionsBehavior.Editable = True
        GridView3.OptionsBehavior.Editable = True
        If XtraTabControl1.SelectedTabPage.Text = "Recebimentos" Then
            GridView2.Focus()
        ElseIf XtraTabControl1.SelectedTabPage.Text = "Controle de Qualidade" Then
            GridView3.Focus()
        End If
    End Sub
    Private Sub Gridview2_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.RowCountChanged
        Me.Cursor = Cursors.WaitCursor
        Dim row1 As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim row2 As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        Try
            If row2.RowState = DataRowState.Added Then
                VSQL = "Insert Into RecebimentoHistorico (CDEmpresa,CDNF,DTNF,CDOC,CDItem,CDProduto,Descricao,Unidade,VLUnitario,Qtde,QtdeRecebida,QtdeAprovada,QtdeReprovada,DTRecebimento,HRRecebimento,Recebedor,CQ) VALUES ('"
                VSQL &= row1("CDEmpresa") & "','"
                VSQL &= row2("CDNF") & "',"
                If IsDate(row2("DTNF")) Then
                    VSQL &= "Convert(DateTime,'" & row2("DTNF") & "',103),'"
                Else
                    VSQL &= "NULL,'"
                End If
                VSQL &= row1("CDOC") & "',"
                VSQL &= row2("CDItem") & ",'"
                VSQL &= row2("CDProduto") & "','"
                VSQL &= row2("Descricao") & "','"
                VSQL &= row2("Unidade") & "',"
                VSQL &= CDBNumber(row2("VLUnitario")) & ","
                VSQL &= CDBNumber(row2("Qtde")) & ","
                If IsNumeric(row2("QtdeRecebida")) Then
                    VSQL &= CDBNumber(row2("QtdeRecebida")) & ","
                Else
                    VSQL &= "0,"
                End If
                If IsNumeric(row2("QtdeAprovada")) Then
                    VSQL &= CDBNumber(row2("QtdeAprovada")) & ","
                Else
                    VSQL &= "0,"
                End If
                If IsNumeric(row2("QtdeReprovada")) Then
                    VSQL &= CDBNumber(row2("QtdeReprovada")) & ","
                Else
                    VSQL &= "0,"
                End If
                VSQL &= "Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),'"
                VSQL &= Now.TimeOfDay.ToString.Substring(0, 5) & "','"
                VSQL &= row2("Recebedor") & "',1)"
                conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL.Open()
                querySQl.Connection = conSQL
                querySQl.CommandText = VSQL
                querySQl.ExecuteNonQuery()
                conSQL.Close()
                MontaQuery()
            End If
        Catch
            conSQL.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim row1 As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim row2 As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        Dim View As GridView = sender
        Dim VCDOC As String
        Dim sStatus As String = View.EditingValue
        If e.Column.FieldName = "CDItem" Then
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL
            VCDOC = row1("CDOC")
            If VCDOC.Substring(5, 1) = "C" Then
                querySQl.CommandText = "Select CDCodigo,Descricao,Unidade,Qtde,VLUnitario,ItemOC.Observacao From Prisma2.dbo.ItemOC Where CDEmpresa = '" & row1("CDEmpresa") & "' And CDOC = '" & row1("CDOC") & "' And CDItem = " & row2("CDItem")
            Else
                querySQl.CommandText = "Select CDCodigo,Descricao,Unidade,Qtde,VLUnitario,ItemOC.Observacao From ItemOC Where CDEmpresa = '" & row1("CDEmpresa") & "' And CDOC = '" & row1("CDOC") & "' And CDItem = " & row2("CDItem")
            End If
            datRead = querySQl.ExecuteReader
            If datRead.Read = True Then
                View.SetRowCellValue(e.RowHandle, "CDProduto", datRead("CDCodigo"))
                View.SetRowCellValue(e.RowHandle, "Descricao", datRead("Descricao") & " " & Trim(datRead("Observacao")))
                View.SetRowCellValue(e.RowHandle, "Unidade", UCase(datRead("Unidade")))
                View.SetRowCellValue(e.RowHandle, "Qtde", Format(datRead("Qtde"), "######0.00000"))
                View.SetRowCellValue(e.RowHandle, "Recebedor", UCase(gUsuario))
                View.SetRowCellValue(e.RowHandle, "VLUnitario", Format(datRead("VLUnitario"), "###,###,##0.00000"))
            Else
                MessageBox.Show("Nº do Ítem digitado não existe .......verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            datRead.Close()
            conSQL.Close()
        End If
    End Sub
    Private Sub BTEMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTEMail.Click
        'If sParam.selPermissoes(308, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = False Then
        '    MessageBox.Show("Seu perfil não tem acesso a essa opção.....Contate o Administrador", "Nivel de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        XtraTabControl1.SelectedTabPage = XtraTabPage3
        MontaQuery()
        If GridView3.RowCount = 0 Then
            MessageBox.Show("Não existe recebimentos na Ordem de Compra...............Verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim row1 As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim row2 As System.Data.DataRow = GridView2.GetDataRow(GridView3.FocusedRowHandle)
        Dim VComprador As String = "", VFornecedor As String = "", VEmpresa As String = "", VCDOC As String = "", VObs As String = ""
        VEmpresa = row2("CDEmpresa")
        VCDOC = row2("CDOC")
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL
        If VCDOC.Substring(5, 1) = "C" Then
            querySQl.CommandText = "Select * From Prisma2.dbo.OC Where CDEmpresa = '" & VEmpresa & "' And CDOC = '" & VCDOC & "'"
        Else
            querySQl.CommandText = "Select * From Prisma.dbo.OC Where CDEmpresa = '" & VEmpresa & "' And CDOC = '" & VCDOC & "'"
        End If
        datRead = querySQl.ExecuteReader
        If datRead.Read = True Then
            VComprador = datRead("CDComprador")
            VFornecedor = datRead("CDFornec")
        End If
        datRead.Close()

        querySQl.CommandText = "Select NMFantasia From Vendedores Where CDVendedor = '" & VComprador & "'"
        VComprador = querySQl.ExecuteScalar

        querySQl.CommandText = "Select Fantasia From Fornecedores Where CDFornec = '" & VFornecedor & "'"
        VFornecedor = querySQl.ExecuteScalar

        Dim sMail As ClassMail = New ClassMail()
        Dim sBody, sAssunto As String

        sBody = "AVISO DE RECEBIMENTO DE MATERIAIS DA ORDEM DE COMPRA Nº <b>" & row2("CDOC") & "</b> DO FORNECEDOR: <b>" & VFornecedor & "<b><br><br>"
        sBody &= "<table width=100% border=1 cellpadding=0 cellspacing=0>"
        sBody &= "  <tr bgcolor='#efefef'>"
        sBody &= "    <td width=10% align=center><b>Código</b></td>"
        sBody &= "    <td width=40% align=center><b>Descrição</b></td>"
        sBody &= "    <td width=5% align=center><b>UM</b></td>"
        sBody &= "    <td width=10% align=center><b>Qtde OC</b></td>"
        sBody &= "    <td width=10% align=center><b>Qtde Aprovada</b></td>"
        sBody &= "    <td width=10% align=center><b>Qtde Reprovada</b></td>"
        sBody &= "    <td width=15% align=center><b>VL.Unitário</b></b></td>"
        sBody &= "  </tr>"

        conSQL1 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL1.Open()
        querySQl1.Connection = conSQL1

        querySQl.CommandText = "Select * From RecebimentoHistorico Where CDEmpresa = '" & row2("CDEmpresa") & "' And CDOC = '" & row2("CDOC") & "' And CQ = 1 And DTBaixa Is NULL Order By CDItem"
        datRead.Close()
        datRead = querySQl.ExecuteReader
        Do While datRead.Read = True

            If VCDOC.Substring(5, 1) = "C" Then
                querySQl1.CommandText = "Select Observacao From Prisma2.dbo.ItemOC Where CDEmpresa = '" & VEmpresa & "' And CDOC = '" & VCDOC & "' And CDItem = " & datRead("CDItem") & " And CDCodigo = '" & datRead("CDProduto") & "'"
            Else
                querySQl1.CommandText = "Select Observacao From Prisma.dbo.ItemOC Where CDEmpresa = '" & VEmpresa & "' And CDOC = '" & VCDOC & "' And CDItem = " & datRead("CDItem") & " And CDCodigo = '" & datRead("CDProduto") & "'"
            End If
            If Not querySQl1.ExecuteScalar Is DBNull.Value Then
                VObs = querySQl1.ExecuteScalar
            Else
                VObs = ""
            End If
            sBody &= "  <tr>"
            sBody &= "    <td align=left>" & datRead("CDProduto") & "</td>"
            sBody &= "    <td align=left>" & datRead("Descricao") & " " & VObs & "</td>"
            sBody &= "    <td align=center>" & datRead("Unidade") & "</td>"
            sBody &= "    <td align=right>" & Format(datRead("Qtde"), "#######0.0000") & "</td>"
            sBody &= "    <td align=right>" & Format(datRead("QtdeAprovada"), "#######0.0000") & "</td>"
            sBody &= "    <td align=right>" & Format(datRead("QtdeReprovada"), "#######0.0000") & "</td>"
            sBody &= "    <td align=right>" & Format(datRead("VLUnitario"), "Currency") & "</td>"
            sBody &= "  </tr>"
        Loop
        conSQL.Close()
        conSQL1.Close()
        datRead.Close()
        sBody &= "</table>"

        sAssunto = "RECEBIMENTO DE MATERIAIS - OC Nº: " & row2("cdoc")
        Try
            If MessageBox.Show("Deseja enviar este E-Mail para o CORTE e CARLOS?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sMail.SendMailMessage(LCase(gUsuario) & "@" & gDominio, "corte@classica.com.br;euclides@classica.com.br;carlos@classica.com.br", "", "", sAssunto, sBody, "", "", gIDEmpresa, "", "")
            End If
            'sMail.SendMailMessage(LCase(gUsuario) & "@" & gDominio, "adalberto@classica.com.br", "", "", sAssunto, sBody, "", "")
            sMail.SendMailMessage(LCase(gUsuario) & "@" & gDominio, LCase(VComprador) & "@" & gDominio, "", "", sAssunto, sBody, "", "", gIDEmpresa, "", "")
            MessageBox.Show("E-Mail enviado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BTIncItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTIncItens.Click
        Dim row1 As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim VCDOC As String
        Try
            VCDOC = row1("CDOC")
        Catch
            MessageBox.Show("É necessário selecionar/clicar a OC antes de incluir os ítens.....Verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        Dim VCDNF As String = ""
        Dim VDTNF As String = ""
        VCDNF = InputBox("Digite o Número da Nota Fiscal/Documento", "")
        VDTNF = InputBox("Digite a Data da Nota Fiscal/Documento", "")
        If VDTNF <> "" Then
            If Not IsDate(VDTNF) Then
                MessageBox.Show("Data da NF/Doc Inválida......Verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL1 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        conSQL1.Open()
        querySQl.Connection = conSQL
        querySQl1.Connection = conSQL1
        If VCDOC.Substring(5, 1) = "C" Then
            querySQl.CommandText = "Select * From Prisma2.dbo.ItemOC Where CDEmpresa = '" & row1("CDEmpresa") & "' And CDOC = '" & VCDOC & "'"
        Else
            querySQl.CommandText = "Select * From Prisma.dbo.ItemOC Where CDEmpresa = '" & row1("CDEmpresa") & "' And CDOC = '" & VCDOC & "'"
        End If
        datRead = querySQl.ExecuteReader
        Do While datRead.Read = True
            VSQL = "INSERT INTO RecebimentoHistorico (CDEmpresa,CDNF,DTNF,CDOC,CDItem,CDProduto,Unidade,Descricao,Qtde,VLUnitario,DTRecebimento,HRRecebimento,Recebedor) VALUES ('"
            VSQL &= row1("CDEmpresa") & "','"
            VSQL &= VCDNF & "',"
            If IsDate(VDTNF) Then
                VSQL &= "Convert(DateTime,'" & VDTNF & "',103),'"
            Else
                VSQL &= "NULL,'"
            End If
            VSQL &= VCDOC & "',"
            VSQL &= datRead("CDItem") & ",'"
            VSQL &= datRead("CDCodigo") & "','"
            VSQL &= datRead("Unidade") & "','"
            VSQL &= CDBTexto(datRead("Descricao")) & " " & Trim(CDBTexto(datRead("Observacao"))) & "',"
            VSQL &= CDBNumber(datRead("Qtde")) & ","
            VSQL &= CDBNumber(datRead("VLUnitario")) & ","
            VSQL &= "Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),'"
            VSQL &= Now.TimeOfDay.ToString.Substring(0, 5) & "','"
            VSQL &= gUsuario & "')"
            querySQl1.CommandText = VSQL
            querySQl1.ExecuteNonQuery()
        Loop
        datRead.Close()
        conSQL.Close()
        conSQL1.Close()
        VSQL = "Select * From RecebimentoHistorico Where CDEmpresa = '" & row1("CDEmpresa") & "' And CDOC = '" & VCDOC & "' Order By CDItem"
        datPubsRH.Clear()
        adaptRH = New SqlClient.SqlDataAdapter(VSQL, conSQL)
        adaptRH.Fill(datPubsRH, "RH")
        GridControl2.DataSource = datPubsRH.Tables("RH")
    End Sub
    Private Sub BTBaixar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTBaixar.Click
        If MessageBox.Show("Confirma a entrada dos ítens selecionados no Estoque", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
            If IsDate(row("DTEstoque")) Then
                MessageBox.Show("Ítem ja foi baixado.....verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If row("QtdeAprovada") = 0 Then
                MessageBox.Show("Qtde Aprovada está zerada.....verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL
            conSQL1 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL1.Open()
            querySQl1.Connection = conSQL1
            querySQl.CommandText = "Select * From RecebimentoHistorico Where CDEmpresa = '" & row("CDEmpresa") & "' And CDOC = '" & row("CDOC") & "' And DTEstoque Is NULL Order By CDItem"
            datRead = querySQl.ExecuteReader
            Do While datRead.Read = True
                If MessageBox.Show("Confirma a baixa do ítem " & datRead("CDItem") & " da OC número: " & datRead("CDOC"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    'Lança no Kardex
                    querySQl1.CommandType = CommandType.StoredProcedure
                    querySQl1.CommandText = "SP_Kardex"
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", datRead("CDProduto")))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Qtde", datRead("QtdeAprovada")))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CDBTexto(datRead("Descricao"))))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Status", "EMP"))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Obs", "OC Nº " & row("CDOC") & " Em " & Now.Date.ToShortDateString))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", CDBNumber(datRead("VLUnitario"))))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario))
                    querySQl1.ExecuteNonQuery()
                    querySQl1.Parameters.Clear()
                    querySQl1.CommandType = CommandType.Text
                    'Lança no Kardex A - Custo Medio e Classificação Fiscal
                    querySQl1.CommandType = CommandType.StoredProcedure
                    querySQl1.CommandText = "SP_KardexA"
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", datRead("CDProduto")))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Qtde", datRead("QtdeAprovada")))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CDBTexto(datRead("Descricao"))))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Status", "EMP"))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Obs", "OC Nº " & row("CDOC") & " Em " & Now.Date.ToShortDateString))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", datRead("VLUnitario")))
                    querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario))
                    querySQl1.ExecuteNonQuery()
                    querySQl1.Parameters.Clear()
                    querySQl1.CommandType = CommandType.Text
                    'Atualiza a data de entrada no estoque
                    querySQl1.CommandText = "UPDATE Prisma.dbo.RecebimentoHistorico SET DTEstoque = Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),HREstoque = '" & Now.TimeOfDay.ToString.Substring(0, 5) & "' WHERE Id = " & datRead("Id")
                    querySQl1.ExecuteNonQuery()
                    'Atualiza qtde,Data e Valor da última compra
                    querySQl1.CommandText = "UPDATE Prisma.dbo.Estoque SET DTUltCom = Convert(DateTime,'" & datRead("DTNF") & "',103),QTUltCom = " & CDBNumber(datRead("QtdeAprovada")) & ",VLUltCom = " & CDBNumber(datRead("VLUnitario")) & " Where CDProduto = '" & datRead("CDProduto") & "'"
                    querySQl1.ExecuteNonQuery()
                    MessageBox.Show("Ítem " & datRead("CDItem") & " lançado no Estoque com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Loop
            conSQL.Close()
            conSQL1.Close()
            datRead.Close()
            MontaQuery()
        End If
    End Sub
    Private Sub BTEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTEstornar.Click
        If MessageBox.Show("Confirma a saída do ítem selecionado no Estoque", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
            conSQL1 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL1.Open()
            querySQl1.Connection = conSQL1
            querySQl1.CommandType = CommandType.StoredProcedure
            querySQl1.CommandText = "SP_Kardex"
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", row("CDProduto")))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Qtde", row("QtdeAprovada")))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CDBTexto(row("Descricao"))))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMP"))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Estorno OC Nº " & row("CDOC") & " Em " & Now.Date.ToShortDateString))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", CDBNumber(row("VLUnitario"))))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario))
            querySQl1.ExecuteNonQuery()
            querySQl1.Parameters.Clear()
            querySQl1.CommandType = CommandType.Text
            'Lança no Kardex A - Custo Medio e Classificação Fiscal
            querySQl1.CommandType = CommandType.StoredProcedure
            querySQl1.CommandText = "SP_KardexA"
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", row("CDProduto")))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Qtde", row("QtdeAprovada")))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CDBTexto(row("Descricao"))))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMP"))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Estorno OC Nº " & row("CDOC") & " Em " & Now.Date.ToShortDateString))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", row("VLUnitario")))
            querySQl1.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario))
            querySQl1.ExecuteNonQuery()
            querySQl1.Parameters.Clear()
            querySQl1.CommandType = CommandType.Text
            'Atualiza a data de entrada no estoque
            querySQl1.CommandText = "UPDATE RecebimentoHistorico SET DTEstoque = NULL,HREstoque = '' WHERE Id = " & row("Id")
            querySQl1.ExecuteNonQuery()
            conSQL1.Close()
            MontaQuery()
            MessageBox.Show("Estornado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub BTVerTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTVerTodas.Click
        Me.Cursor = Cursors.WaitCursor
        If BTVerTodas.Text = "Ver Todas" Then
            VSQL = "Select OC.CDEmpresa,OC.CDOC,OC.Dis,OC.DTEntrega,OC.DTPrevEntrega,DateDiff(d,Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),OC.DTPrevEntrega) As Atraso,OC.CDFornec,OC.CDComprador,CDItem,CDCodigo,Descricao,Unidade,Qtde,Saldo,VLUnitario,IPI,(Qtde * VLUnitario) As Total,ItemOC.Observacao From OC Left Join ItemOC On OC.CDEmpresa = ItemOC.CDEmpresa And OC.CDOC = ItemOC.CDOC Where Saldo > 0 Union All "
            VSQL = VSQL & "Select OC.CDEmpresa,OC.CDOC,OC.Dis,OC.DTEntrega,OC.DTPrevEntrega,DateDiff(d,Convert(DateTime,'" & Now.Date.ToShortDateString & "',103),OC.DTPrevEntrega) As Atraso,OC.CDFornec,OC.CDComprador,CDItem,CDCodigo,Descricao,Unidade,Qtde,Saldo,VLUnitario,IPI,(Qtde * VLUnitario) As Total,ItemOC.Observacao From Prisma2.dbo.OC Left Join Prisma2.dbo.ItemOC On OC.CDEmpresa = ItemOC.CDEmpresa And OC.CDOC = ItemOC.CDOC Order By DTPrevEntrega"
            datPubsOC.Clear()
            adaptOC = New SqlClient.SqlDataAdapter(VSQL, conSQL)
            adaptOC.Fill(datPubsOC, "OC")
            GridControl1.DataSource = datPubsOC.Tables("OC")
            BTVerTodas.Text = "OCs Pendentes"
        Else
            MontaQuery()
            BTVerTodas.Text = "Ver Todas"
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BTRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRefresh.Click
        MontaQuery()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class
