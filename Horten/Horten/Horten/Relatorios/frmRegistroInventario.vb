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

        cbTipoEstoque.Items.Add("0 - Todos os Itens")
        cbTipoEstoque.Items.Add("1 - Material Acabado")
        cbTipoEstoque.Items.Add("2 - Matéria Prima")
        cbTipoEstoque.Items.Add("3 - Material de Consumo")
        cbTipoEstoque.Items.Add("4 - Subconjunto")
        cbTipoEstoque.Items.Add("5 - Embalagem")
        cbTipoEstoque.SelectedIndex = 2

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

        Dim VMes As Integer
        Dim VAno As Integer
        VMes = Month(tbData.Text)
        VAno = Year(tbData.Text)

        If gIDEmpresa = 1 Then
            If cbTipoEstoque.Text.Substring(0, 1) = "1" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,0 As ICMS,'3' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Sum(Qtde) From NF b, ItemNF c Where b.CDEmpresa = c.CDEmpresa and b.CDNF = c.CDNF and month(dis) = " & VMes & " And Year(dis) = " & VAno & " and c.cdproduto = a.CDProduto) As Qtde,"
                VSQL &= "(Select Top 1 VLUnitario From NF b, ItemNF c Where b.CDEmpresa = c.CDEmpresa and b.CDNF = c.CDNF and month(dis) = " & VMes & " And Year(dis) = " & VAno & " and c.cdproduto = a.CDProduto) As Valor "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' And Substring(CDProduto,1,1) <> '7' And Substring(CDProduto,1,1) <> '8' And Substring(CDProduto,1,3) > '100' And Substring(CDProduto,1,3) < '904' Order By CDProduto"
            ElseIf cbTipoEstoque.Text.Substring(0, 1) = "2" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,VLUltCom As Valor,18 As ICMS,'1' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde,"
                VSQL &= "((Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) * VLUltCom) * 0.18 As VLICMS "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' And Substring(CDProduto,1,3) > '100' And Substring(CDProduto,1,3) < '170' Order By CDProduto"
            ElseIf cbTipoEstoque.Text.Substring(0, 1) = "5" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,VLUltCom As Valor,18 As ICMS,'2' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde,"
                VSQL &= "((Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) * VLUltCom) * 0.18 As VLICMS "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' Order By CDProduto"
            End If
        ElseIf gIDEmpresa = 3 Then
            If cbTipoEstoque.Text.Substring(0, 1) = "1" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,0 As VLICMS,'3' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde, "
                VSQL &= "(Select Top 1 VLUnitario From ListaPreco C Where C.CDProduto = A.CDProduto And Tipo = 'A') As Valor "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' Order By CDProduto"
            ElseIf cbTipoEstoque.Text.Substring(0, 1) = "2" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,VLUltCom As Valor,18 As ICMS,'1' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde, "
                VSQL &= "((Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) * VLUltCom) * 0.18 As VLICMS "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' And Substring(CDProduto,1,3) > '100' And Substring(CDProduto,1,3) < '190' Order By CDProduto"
            ElseIf cbTipoEstoque.Text.Substring(0, 1) = "5" Then
                VSQL = "Select CDClasF,CDProduto,Descricao,Unidade,VLUltCom As Valor,18 As ICMS,'2' As Grupo,'" & cbTipoEstoque.Text.Substring(3, Len(cbTipoEstoque.Text) - 3) & "' As DescricaoGrupo,"
                VSQL &= "(Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) As Qtde, "
                VSQL &= "((Select Top 1 Saldo From Kardex B Where B.CDProduto = A.CDProduto And Data <= Convert(DateTime,'" & tbData.Text & "',103) Order By Data Desc) * VLUltCom) * 0.18 As VLICMS "
                VSQL &= "From Estoque A Where Idle = 0 And Estoque = '" & cbTipoEstoque.Text.Substring(0, 1) & "' Order By CDProduto"
            End If
        End If

        datPubs1.Clear()
        adaptSQL1 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL1.Fill(datPubs1, "Estoque")
        GridControl1.DataSource = datPubs1.Tables("Estoque")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub BTExportarTXT_Click(sender As Object, e As EventArgs) Handles BTExportarTXT.Click
        If MessageBox.Show("Confirma a geração do arquivo TXT", "TXT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim mNome As String = ""
        Dim mReg As String = ""
        Dim VDia As String, VMes As String, VAno As String

        VDia = Now.Day.ToString
        VMes = Now.Month.ToString
        VAno = Now.Year.ToString.Substring(2, 2)
        VDia = VDia.PadLeft(2, "0")
        VMes = VMes.PadLeft(2, "0")

        mNome = gPathXML & "INV" & StrZero(VMes, 2) & VAno & ".TXT"

        Dim Arquivo As String = mNome

        If IO.File.Exists(mNome) Then
            IO.File.Delete(mNome)
        End If

        Dim V As String = ""
        Dim Strm As System.IO.StreamWriter = New System.IO.StreamWriter(Arquivo)

        Strm.Flush()

        Dim VItem, VCDProduto, VDescricao, VNBM, VGrupo, VDescricaoGrupo, VUM As String
        Dim VQtde, VValor, VICMS, VVLICMS As Decimal

        For I = 0 To GridView1.RowCount - 1
            VItem = I + 1
            VCDProduto = GridView1.GetDataRow(I).Item("CDProduto")
            VDescricao = GridView1.GetDataRow(I).Item("Descricao")
            Try
                VNBM = GridView1.GetDataRow(I).Item("CDClasF")
            Catch
                VNBM = ""
            End Try
            VGrupo = GridView1.GetDataRow(I).Item("Grupo")
            VDescricaoGrupo = GridView1.GetDataRow(I).Item("DescricaoGrupo")
            Try
                VQtde = GridView1.GetDataRow(I).Item("Qtde")
            Catch
                VQtde = 0
            End Try
            Try
                VUM = GridView1.GetDataRow(I).Item("Unidade")
            Catch
                VUM = Space(4)
            End Try
            Try
                VValor = GridView1.GetDataRow(I).Item("Valor")
            Catch
                VValor = 0
            End Try
            Try
                VICMS = GridView1.GetDataRow(I).Item("ICMS")
            Catch
                VICMS = 0
            End Try
            Try
                VVLICMS = GridView1.GetDataRow(I).Item("VLICMS")
            Catch
                VVLICMS = 0
            End Try
            If VQtde > 0 And VDescricao <> "LIVRE" Then
                'Codigo do Produto
                If Len(VCDProduto) < 9 Then
                    mReg = VCDProduto + Space(8 - Len(VCDProduto))
                    VDescricao = TiraChar(Trim(VDescricao))
                    VDescricao = CDBTexto(Trim(VDescricao))
                    If Len(Trim(VDescricao)) > 60 Then
                        mReg = mReg + VDescricao.Substring(0, 60)
                    Else
                        mReg = mReg + VDescricao + Space(60 - Len(VDescricao))
                    End If
                    'NBM
                    If VNBM <> "" Then
                        mReg = mReg + Trim(TiraPontos(VNBM))
                    Else
                        mReg = mReg + Space(8)
                    End If
                    mReg = mReg + Trim(VGrupo)
                    mReg = mReg + Trim(VDescricaoGrupo) + Space(30 - Len(Trim(VDescricaoGrupo)))
                    'Qtde
                    V = Trim(Format(VQtde, "######0.00"))
                    V = Mid(V, 1, Len(V) - 3) & Mid(V, Len(V) - 1, 2)
                    mReg = mReg + V + Space(9 - Len(V))
                    If VUM = "PÇ" Then
                        VUM = "PC"
                    End If
                    mReg = mReg + VUM + Space(4 - Len(VUM))
                    'Valor Unitario
                    V = Trim(Format(VValor, "######0.00"))
                    V = Mid(V, 1, Len(V) - 3) & Mid(V, Len(V) - 1, 2)
                    mReg = mReg + V + Space(9 - Len(V))
                    mReg = mReg + VICMS.ToString
                    'Valor ICMS
                    V = Trim(Format(VVLICMS, "######0.00"))
                    V = Mid(V, 1, Len(V) - 3) & Mid(V, Len(V) - 1, 2)
                    mReg = mReg + V + Space(8 - Len(V))

                    Strm.WriteLine(mReg)
                End If
            End If
        Next
        Strm.Close()
    End Sub
    Private Function TiraPontos(PNBM As String) As String
        Dim u As Integer
        Dim wNBM As String = ""
        For u = 0 To Len(PNBM) - 1
            If PNBM.Substring(u, 1) <> "." Then
                wNBM &= PNBM.Substring(u, 1)
            End If
        Next
        Return wNBM
    End Function
    Private Function TiraZero(PValor As String) As String
        Dim u As Integer
        Dim wValor As String = ""
        For u = 0 To Len(PValor) - 1
            If PValor.Substring(u, 1) = "0" Then
                wValor &= PValor.Substring(u, 1)
            End If
        Next
        Return wValor

    End Function
    Public Function TiraChar(ByVal texto As String) As String
        'Dim ComAcentos As String = "!@#$%¨&*()-?:{}][ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇçØ"
        'Dim SemAcentos As String = "_@__%_____-______AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc "

        Dim ComAcentos As String = "'Ø#ºª%*"""
        Dim SemAcentos As String = "         "

        Dim i As Integer
        Dim z As Integer = Len(ComAcentos)
        For i = 0 To z - 1
            texto = Replace(texto, ComAcentos(i).ToString(), SemAcentos(i).ToString())
        Next
        Return texto
    End Function
End Class