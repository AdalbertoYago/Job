Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Dns
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmRegistroInventario
    Public datPubsEmp, datPubs1, datPubs2, datPubs3, datPubs4 As New DataSet()
    Private Sub frmRegistroInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dDataAtual As Date = Date.Now()
        tbData.Text = Now.Date.ToShortDateString

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

        Dim VFiltroProd As String = ""
        Dim VEmpresa As String = ""
        If cbEmpresas.SelectedValue <> "" Then
            VEmpresa = " And A.CDEmpresa = '" & cbEmpresas.SelectedValue & "'"
        Else
            VEmpresa = ""
        End If

        VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,Valor,(Qtde * Valor) As Parcial,(((Qtde * Valor) * ICMS) / 100) As VLICMS,((Qtde * Valor) - (((Qtde * Valor) * ICMS) / 100)) As VLLiquido,"
        VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde "
        VSQL &= "Into TMP_RegistroInventario "
        VSQL &= "From Estoque A Where (Estoque = '2' or Estoque = '5' Or Estoque = '1') And Substring(CDProduto,1,3) > '100' And Substring(CDProduto,1,3) < '190' Or Substring(CDProduto,1,1) = '7' And Idle = 0 Order By CDProduto"

        'VSQL &= "From Estoque A Where (Estoque = '2' or Estoque = '5' Or Estoque = '1') And Substring(CDProduto,1,3) > '100' And Substring(CDProduto,1,3) < '190' Or Substring(CDProduto,1,1) = '7' And Idle = 0 Order By CDProduto"

        datPubs1.Clear()
        adaptSQL1 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL1.Fill(datPubs1, "Estoque")
        GridControl1.DataSource = datPubs1.Tables("Estoque")

        Me.Cursor = Cursors.Default
    End Sub

End Class