Public Class frmRequisicoesEPI
    Friend WithEvents CBFunc, CBEPI As System.Windows.Forms.ComboBox
    Public conn As New PrismaLibrary.ClassSqlConnection

    Private Sub frmRequisicoesEPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL1 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        Dim VEmpresa As Integer = 0

        datPubsFun.Clear()
        If gIDEmpresa = 3 Then
            VEmpresa = 1
        ElseIf gIDEmpresa = 4 Then
            VEmpresa = 2
        ElseIf gIDEmpresa = 1 Then
            VEmpresa = 1
        ElseIf gIDEmpresa = 2 Then
            VEmpresa = 2
        End If
        adaptSQL = New SqlClient.SqlDataAdapter("Select numcra,nomfun From Vetorh.dbo.R034FUN Where numemp = " & VEmpresa & " And sitafa < 7 Order By nomfun", conSQL)
        adaptSQL.Fill(datPubsFun, "Funcionarios")
        CBFunc.DataSource = datPubsFun.Tables("Funcionarios")
        CBFunc.ValueMember = "numcra"
        CBFunc.DisplayMember = "nomfun"
        CBFunc.SelectedValue = 0

        datPubsEPI.Clear()
        If gIDEmpresa = 1 Or gIDEmpresa = 2 Then
            adaptSQL = New SqlClient.SqlDataAdapter("Select CDProduto,(CDProduto + ' - ' + Descricao) As Descricao From Estoque Where CDProduto >= '2401001' and CDProduto <= '2409007' Order By Descricao", conSQL)
        Else
            adaptSQL = New SqlClient.SqlDataAdapter("Select CDProduto,(CDProduto + ' - ' + Descricao) As Descricao From Estoque Where Substring(CDProduto,1,2) = '27' Order By Descricao", conSQL)
        End If
        adaptSQL.Fill(datPubsEPI, "EPI")
        CBEPI.DataSource = datPubsEPI.Tables("EPI")
        CBEPI.ValueMember = "CDProduto"
        CBEPI.DisplayMember = "Descricao"
        CBEPI.SelectedValue = 0

        selGrid()
    End Sub
    Private Sub selGrid()
        datPubs2.Clear()
        VSQL = "Select EPI.*,Vetorh.dbo.R034FUN.NomFun,Estoque.Descricao From " ',Estoque.Validade From "
        VSQL &= "(Prisma.dbo.EPI Left Join Vetorh.dbo.R034FUN On EPI.CDFuncionario = Vetorh.dbo.R034FUN.NumCra) "
        VSQL &= "Left Join Prisma.dbo.Estoque On EPI.CDEPI = Estoque.CDProduto "
        VSQL &= "Order By Vetorh.dbo.R034FUN.NumCad,DTRetirada Desc"

        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQL)
        adaptSQL2.Fill(datPubs2, "EPIFuncionario")
        GridControl1.DataSource = datPubs2.Tables("EPIFuncionario")
    End Sub

End Class