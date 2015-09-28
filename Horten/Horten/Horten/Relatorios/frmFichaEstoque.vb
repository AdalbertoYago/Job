Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Dns
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmFichaEstoque
    Public datPubsEmp, datPubs1, datPubs2, datPubs3, datPubs4 As New DataSet()
    Private Sub frmFichaEstoque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sDataAntes, sDataAtual As String
        Dim dDataInicial As Date = Date.Now()
        dDataInicial = dDataInicial.AddMonths(-6)
        Dim sMesInicial, sMesAtual As String
        sMesInicial = dDataInicial.Month()
        sDataAntes = "01/" & sMesInicial.PadLeft(2, "0") & "/" & dDataInicial.Year.ToString()

        Dim dDataAtual As Date = Date.Now()
        sMesAtual = dDataAtual.Month()
        sDataAtual = "01/" & sMesAtual.PadLeft(2, "0") & "/" & dDataAtual.Year


        tbDe.Text = sDataAntes
        tbAte.Text = sDataAtual

        datPubsEmp.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select CDEmpresa,Descricao From Empresas Order By Descricao", conSQLY)
        adaptSQL.Fill(datPubsEmp, "Emp")
        cbEmpresas.DataSource = datPubsEmp.Tables("Emp")
        cbEmpresas.DisplayMember = "Descricao"
        cbEmpresas.ValueMember = "CDEmpresa"
        cbEmpresas.SelectedIndex = 0

    End Sub
    Private Sub BTSair_Click(sender As Object, e As EventArgs) Handles BTSair.Click
        Me.Close()
    End Sub
    Private Sub BTSelecionar_Click(sender As Object, e As EventArgs) Handles BTSelecionar.Click
        MontaQuery()
    End Sub
    Private Sub MontaQuery()
        Me.Cursor = Cursors.WaitCursor
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Seleciona os Produtos vendidos no periodo
        Dim VFiltroProd As String = ""
        Dim VEmpresa As String = ""
        If cbEmpresas.SelectedValue <> "" Then
            VEmpresa = " And A.CDEmpresa = '" & cbEmpresas.SelectedValue & "'"
        Else
            VEmpresa = ""
        End If
        VFiltroProd = " And (Substring(B.CDProduto,1,1) <> '0' And Substring(B.CDProduto,1,1) <> '2' And Substring(B.CDProduto,1,1) <> '3' And Substring(B.CDProduto,1,1) <> '4' And Substring(B.CDProduto,1,1) <> '6' And (Substring(B.CDProduto,1,1) <> '1' And Len(B.CDProduto) <= 7))"
        If CheckEdit2.Checked Then
            VSQL = "Select B.CDProduto,B.Descricao,Sum(B.Qtde) As Total From NF A,ItemNF B Where (A.CDEmpresa = B.CDEmpresa And A.CDNF = B.CDNF) " & VEmpresa & " And A.DIS Between Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & tbAte.Text & "',103)" & VFiltroProd & " Group By B.CDProduto,B.Descricao Order By B.CDProduto"
            GridView1.Columns("CDNF").Visible = False
            GridView1.Columns("Total").Width = 127
        Else
            VSQL = "Select A.CDNF,B.CDProduto,B.Descricao,(B.Qtde) As Total From NF A,ItemNF B Where (A.CDEmpresa = B.CDEmpresa And A.CDNF = B.CDNF) " & VEmpresa & " And A.DIS Between Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & tbAte.Text & "',103)" & VFiltroProd & " Order By B.CDProduto"
            GridView1.Columns("CDNF").Visible = True
            GridView1.Columns("Total").Width = 73
        End If
        datPubs1.Clear()
        adaptSQL1 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL1.Fill(datPubs1, "Estoque")
        GridControl1.DataSource = datPubs1.Tables("Estoque")
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Seleciona as Materias Primas dos produtos vendidos no ano
        Dim i As Integer = 0
        Dim VCDProduto As String
        Dim VQtdeProd As Decimal = 0
        conSQLY1.Open()
        querySQL1.Connection = conSQLY1
        querySQL1.CommandText = "Delete From TMP_FichaEstoque"
        querySQL1.ExecuteNonQuery()
        For i = 0 To GridView1.RowCount - 1 Step 1
            VCDProduto = GridView1.GetDataRow(i).Item("CDProduto")
            VQtdeProd = GridView1.GetDataRow(i).Item("Total")
            querySQL1.CommandText = "Insert Into TMP_FichaEstoque Select CDProduto,CDMaterial,Descricao,Qtde * " & VQtdeProd & " From Estrutura Where Cenario = 3 And CDProduto = '" & VCDProduto & "' And Substring(CDMaterial,1,1) = '1' And Substring(CDMaterial,1,3) <> '100' Order By CDMaterial"
            querySQL1.ExecuteNonQuery()
        Next
        conSQLY1.Close()
        If CheckEdit1.Checked Then
            VSQL = "Select CDMaterial,Descricao,Sum(Total) As Total From TMP_FichaEstoque Group By CDMaterial,Descricao Order By CDMaterial"
            GridView2.Columns("CDProduto").Visible = False
            GridView2.Columns("Total").Width = 156
        Else
            VSQL = "Select CDProduto,CDMaterial,Descricao,Total From TMP_FichaEstoque Order By CDProduto,CDMaterial"
            GridView2.Columns("CDProduto").Visible = True
            GridView2.Columns("Total").Width = 76
        End If
        datPubs2.Clear()
        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL2.Fill(datPubs2, "MP")
        GridControl2.DataSource = datPubs2.Tables("MP")
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Ficha de Estoque
        datPubs3.Clear()
        VSQL = "Select CDMaterial,Descricao,Sum(Total) As Total,"
        VSQL &= "(Select Top 1 Saldo From Kardex Where CDProduto = A.CDMaterial Order By Registro Desc) As Estoque,"
        VSQL &= "(Select Sum(C.Qtde) From OC B,ItemOC C Where (B.CDEmpresa = C.CDEmpresa And B.CDOC = C.CDOC) And C.CDCodigo = A.CDMaterial And B.Dis Between Convert(DateTime,'" & tbDe.Text & "',103) And Convert(DateTime,'" & tbAte.Text & "',103)) As Compras "
        VSQL &= "From TMP_FichaEstoque A Group By CDMaterial,Descricao Order By CDMaterial"
        adaptSQL3 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL3.Fill(datPubs3, "Ficha")
        GridControl3.DataSource = datPubs3.Tables("Ficha")
        Dim VCompras As Decimal = 0
        Dim VEstoque As Decimal = 0
        Dim VSaldo As Decimal = 0
        For i = 0 To GridView3.RowCount - 1
            Try
                VCompras = GridView3.GetDataRow(i).Item("Compras")
            Catch
                VCompras = 0
            End Try
            Try
                VEstoque = GridView3.GetDataRow(i).Item("Estoque")
            Catch
                VEstoque = 0
            End Try
            VSaldo = VEstoque - VCompras
            GridView3.SetRowCellValue(i, "Saldo", VSaldo)
        Next
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim Frm As frmEstruturaMP = New frmEstruturaMP(row("CDProduto"))
            Frm.Show()
        Catch
        End Try
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked Then
            VSQL = "Select CDMaterial,Descricao,Sum(Total) As Total From TMP_FichaEstoque Group By CDMaterial,Descricao Order By CDMaterial"
            GridView2.Columns("CDProduto").Visible = False
            GridView2.Columns("Total").Width = 156
        Else
            VSQL = "Select CDProduto,CDMaterial,Descricao,Total From TMP_FichaEstoque Order By CDProduto,CDMaterial"
            GridView2.Columns("CDProduto").Visible = True
            GridView2.Columns("Total").Width = 76
        End If
        datPubs2.Clear()
        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL2.Fill(datPubs2, "MP")
        GridControl2.DataSource = datPubs2.Tables("MP")
    End Sub
    Private Sub BTImpFicha_Click(sender As Object, e As EventArgs) Handles BTImpFicha.Click
        Dim row As System.Data.DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
        Dim x As New FichaEstoque1(row("CDMaterial"), row("Descricao"), tbDe.Text, tbAte.Text)
        x.ShowPreview()
    End Sub
End Class