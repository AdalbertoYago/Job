Imports DevExpress.XtraReports.UI
Public Class frmEPI
    Public sValidade As String
    Public gFunc, gData As String
    Public conn As New PrismaLibrary.ClassSqlConnection
    Private Sub frmEPI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        limpaCampos()
        datPubs2.Clear()
        VSQL = "Select EPI.*,Vetorh.dbo.R034FUN.NomFun,Estoque.Descricao From " ',Estoque.Validade From "
        VSQL &= "(Prisma.dbo.EPI Left Join Vetorh.dbo.R034FUN On EPI.CDFuncionario = Vetorh.dbo.R034FUN.NumCra) "
        VSQL &= "Left Join Prisma.dbo.Estoque On EPI.CDEPI = Estoque.CDProduto "
        VSQL &= "Order By Vetorh.dbo.R034FUN.NumCad,DTRetirada Desc"

        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQL)
        adaptSQL2.Fill(datPubs2, "EPIFuncionario")
        GridControl1.DataSource = datPubs2.Tables("EPIFuncionario")
    End Sub
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        If conSQL.State = ConnectionState.Closed Then conSQL.Open()
        querySQl.Connection = conSQL
        Try
            querySQl.CommandText = "Select * From Prisma.dbo.EPI where CDFuncionario='" & row("CDFuncionario") & "' and CDEPI='" & row("CDEPI") & "' and DTRetirada = convert(datetime,'" & row("DTRetirada") & "',103)"
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                Try
                    CBFunc.SelectedValue = datRead("CDFuncionario")
                Catch
                End Try

                CBEPI.SelectedValue = datRead("CDEPI")
                txtDTRetirada.Text = datRead("DTRetirada")
                txtQtde.Text = datRead("Qtde")
                Try
                    txtDTDevolucao.Text = datRead("DTDevolucao")
                Catch
                    txtDTDevolucao.Text = ""
                End Try
                Try
                    txtDTValidade.Text = datRead("DTValidade")
                Catch
                    txtDTValidade.Text = ""
                End Try
                Try
                    txtDTBaixa.Text = datRead("DTBaixa")
                Catch
                    txtDTBaixa.Text = ""
                End Try
            End If
            datRead.Close()
        Catch
        End Try

        Try
            querySQl.CommandText = "Select NumEmp From vetorh.dbo.R034FUN where numCra='" & CBFunc.SelectedValue & "'"
            datRead3 = querySQl.ExecuteReader()
            If datRead3.Read = True Then
                txtCDEmpresa.Text = datRead3("NumEmp")
            End If
            datRead3.Close()
        Catch
        End Try
        conSQL.Close()
        SimpleButton1.Enabled = True
        btExcluir.Enabled = True
        btBaixar.Enabled = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        btGravar.Enabled = True
        SimpleButton1.Enabled = False
        btExcluir.Enabled = False
        btBaixar.Enabled = False
        limpaCampos()
        txtQtde.Text = 1
        CBFunc.Focus()
        CBFunc.Select()
        txtDTRetirada.Text = Now.Date.ToShortDateString
    End Sub
    Private Sub btGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGravar.Click
        If MessageBox.Show("Confirma a gravação do EPI", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        querySQl.Connection = conSQL
        Dim sDTDevolucao As String = ""
        Dim sDTValidade As String = ""
        Dim sDTBaixa As String = ""
        Dim sQDTDevolucao As String = ""
        Dim sQDTValidade As String = ""
        Dim sQDTBaixa As String = ""

        Try
            If txtDTDevolucao.Text <> "" And Trim(txtDTDevolucao.Text) <> "/  /" Then
                sQDTDevolucao = ",DTDevolucao"
                sDTDevolucao = ", convert(datetime,'" & txtDTDevolucao.Text & "',103)"
            End If
            If txtDTValidade.Text <> "" And Trim(txtDTValidade.Text) <> "/  /" Then
                sQDTValidade = ",DTValidade"
                sDTValidade = ", convert(datetime,'" & txtDTValidade.Text & "',103)"
            End If
            If txtDTBaixa.Text <> "" And Trim(txtDTBaixa.Text) <> "/  /" Then
                sQDTBaixa = ",DTBaixa"
                sDTBaixa = ", convert(datetime,'" & txtDTBaixa.Text & "',103)"
            End If

            ''## atualiza registro anterior para colocar data de devolucao
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandText = "Update Prisma.dbo.EPI set DTDevolucao=convert(datetime,'" & Date.Today.Date() & "',103) where CDFuncionario='" & CBFunc.SelectedValue & "' and CDEPI='" & CBEPI.SelectedValue & "'"
            querySQl.ExecuteNonQuery()

            querySQl.CommandText = "Insert into Prisma.dbo.EPI (CDFuncionario,CDEPI,DTRetirada,Qtde" & sQDTDevolucao & sQDTValidade & sQDTBaixa & ") values " & _
                                   "('" & CBFunc.SelectedValue & "','" & CBEPI.SelectedValue & "',convert(datetime,'" & txtDTRetirada.Text & "',103),'" & txtQtde.Text & "'" & sDTDevolucao & sDTValidade & sDTBaixa & ")"
            querySQl.ExecuteNonQuery()

            MessageBox.Show("Registro inserido com sucesso!", "Sucesso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            btGravar.Enabled = False
            SimpleButton1.Enabled = True
            selGrid()
        Catch ex As Exception
            MessageBox.Show("Houve um erro na inserção dos dados, por favor verifique!", "Erro....", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        conSQL.Close()
    End Sub
    Public Sub limpaCampos()
        txtDTRetirada.Text = ""
        txtDTDevolucao.Text = ""
        txtDTValidade.Text = ""
        txtDTBaixa.Text = ""
        txtQtde.Text = ""
    End Sub
    ''###SELECIONA DIAS DE VALIDADE DO ITEM
    Private Sub txtDTRetirada_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        conSQL.Open()
        querySQl.Connection = conSQL
        querySQl.CommandText = "Select Validade from Prisma.dbo.Estoque where cdproduto='" & CBEPI.SelectedValue & "'"
        datRead2 = querySQl.ExecuteReader()
        If datRead2.Read = True Then
            Try
                sValidade = datRead2("Validade")
                txtDTValidade.Text = Date.Now.AddDays(sValidade)
            Catch
                sValidade = ""
            End Try
            datRead2.Close()
        End If
        conSQL.Close()
    End Sub
    ''###EXCLUI EPI
    Private Sub btExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExcluir.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Try
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandText = "Delete From Prisma.dbo.EPI Where Id = " & row("Id")
            querySQl.ExecuteNonQuery()

            If IsDate(txtDTBaixa.Text) Then
                querySQl.CommandType = CommandType.StoredProcedure
                querySQl.CommandText = "Prisma.dbo.sp_Kardex"
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", CBEPI.SelectedValue))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Qtde", txtQtde.Text))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CBEPI.Text))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Status", "EMC"))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@obs", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", "Almoxarife"))
                querySQl.ExecuteNonQuery()
                querySQl.Parameters.Clear()
                querySQl.CommandType = CommandType.Text
            End If
            MessageBox.Show("Registro excluído com sucesso!", "Sucesso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            selGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show("Erro na exclusão!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        conSQL.Close()
    End Sub
    ''###DAR BAIXA NO EPI
    Private Sub btBaixar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBaixar.Click
        Dim VSaldo As Decimal = 0
        conSQL.Open()
        querySQl.Connection = conSQL
        VSQL = "Select Top 1 Saldo From Kardex Where CDProduto = '" & CBEPI.SelectedValue & "' And Saldo >= " & txtQtde.Text & " Order By Registro Desc"
        querySQl.CommandText = "Select Top 1 Saldo From Kardex Where CDProduto = '" & CBEPI.SelectedValue & "' Order By Registro Desc"
        Try
            VSaldo = querySQl.ExecuteScalar
        Catch ex As Exception
            VSaldo = 0
        End Try
        conSQL.Close()
        If VSaldo < txtQtde.Text Then
            MessageBox.Show("Saldo Insuficiente.....Verifique", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                conSQL.Open()
                querySQl.Connection = conSQL
                querySQl.CommandText = "Update Prisma.dbo.EPI Set DTBaixa = Convert(datetime,'" & Date.Now() & "',103) where CDEPI='" & CBEPI.SelectedValue & "' and CDFuncionario='" & CBFunc.SelectedValue & "' and DTRetirada=convert(datetime,'" & txtDTRetirada.Text & "',103)"
                querySQl.ExecuteNonQuery()
                querySQl.CommandType = CommandType.StoredProcedure
                querySQl.CommandText = "sp_Kardex"
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", CBEPI.SelectedValue))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Qtde", txtQtde.Text))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Descricao", CBEPI.Text))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMC"))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@obs", ""))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                querySQl.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", "Almoxarife"))
                querySQl.ExecuteNonQuery()
                querySQl.Parameters.Clear()
                querySQl.CommandType = CommandType.Text
                MessageBox.Show("Registro baixado com sucesso!", "Sucesso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                selGrid()
            Catch
                MessageBox.Show("Erro na baixa!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
            conSQL.Close()
        End If
    End Sub
    ''###DEVOLVE EPI
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Try
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandType = CommandType.Text
            querySQl.CommandText = "update Prisma.dbo.EPI set DTDevolucao=convert(datetime,'" & Date.Now() & "',103) where CDEPI='" & CBEPI.SelectedValue & "' and CDFuncionario='" & CBFunc.SelectedValue & "' and DTRetirada=convert(datetime,'" & txtDTRetirada.Text & "',103)"
            querySQl.ExecuteNonQuery()
            MessageBox.Show("Registro alterado com sucesso!", "Sucesso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            selGrid()
        Catch
            MessageBox.Show("Erro na alteração!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        conSQL.Close()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            'gFunc = CBFunc.SelectedValue.ToString()
            gFunc = row("CDFuncionario")
            gData = txtDTRetirada.Text
            If gIDEmpresa = 1 Then
                Dim xtraR As ReportClassica = New ReportClassica(gFunc, gData)
                xtraR.ShowPreview()
            ElseIf gIDEmpresa = 2 Then
                Dim xtraR As ReportForma = New ReportForma(gFunc, gData)
                xtraR.ShowPreview()
            ElseIf gIDEmpresa = 3 Then
                Dim xtraR As Reportalado = New Reportalado(gFunc, gData)
                xtraR.ShowPreview()
            ElseIf gIDEmpresa = 4 Then
                Dim xtraR As ReportUsinart = New ReportUsinart(gFunc, gData)
                xtraR.ShowPreview()
            End If
        Catch

        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        selGrid()
    End Sub
    Private Sub CBFunc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBFunc.LostFocus
        Try
            conSQL.Open()
            querySQl.Connection = conSQL
            querySQl.CommandText = "Select NumEmp From vetorh.dbo.R034FUN where numCra = " & CBFunc.SelectedValue
            datRead3 = querySQl.ExecuteReader()
            If datRead3.Read = True Then
                txtCDEmpresa.Text = datRead3("NumEmp")
            End If
            datRead3.Close()
        Catch
        End Try
        conSQL.Close()
    End Sub
    Private Sub BTConsultar_Click(sender As Object, e As EventArgs) Handles BTConsultar.Click
        limpaCampos()
        datPubs2.Clear()
        VSQL = "Select EPI.*,Vetorh.dbo.R034FUN.NomFun,Estoque.Descricao From " ',Estoque.Validade From "
        VSQL &= "(Prisma.dbo.EPI Left Join Vetorh.dbo.R034FUN On EPI.CDFuncionario = Vetorh.dbo.R034FUN.NumCra) "
        VSQL &= "Left Join Prisma.dbo.Estoque On EPI.CDEPI = Estoque.CDProduto "
        VSQL &= "where NumCra='" & CBFunc.SelectedValue & "' "
        VSQL &= "Order By Vetorh.dbo.R034FUN.NumCad,DTRetirada Desc"

        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQL)
        adaptSQL2.Fill(datPubs2, "EPIFuncionario")
        GridControl1.DataSource = datPubs2.Tables("EPIFuncionario")
    End Sub


    Private Sub GridView1_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated
        querySQl.Connection = conSQL
        Dim sDTDevolucao As String = ""
        Dim sDTValidade As String = ""
        Dim sDTBaixa As String = ""
        Dim sDTRetirada As String = ""
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)


        sDTDevolucao = IIf(IsDate(row("DTDevolucao")), "Convert(datetime,'" & row("DTDevolucao") & "',103)", "NULL")
        sDTValidade = IIf(IsDate(row("DTValidade")), "Convert(datetime,'" & row("DTValidade") & "',103)", "NULL")
        sDTBaixa = IIf(IsDate(row("DTBaixa")), "Convert(datetime,'" & row("DTBaixa") & "',103)", "NULL")
        sDTRetirada = IIf(IsDate(row("DTRetirada")), "Convert(datetime,'" & row("DTRetirada") & "',103)", "NULL")

        ''## atualiza registro anterior para colocar data de devolucao
        conSQL.Open()
        querySQl.Connection = conSQL
        querySQl.CommandText = "Update Prisma.dbo.EPI set DTRetirada=" & sDTRetirada & ",  Usados='" & row("Usados") & "', Qtde='" & CDBNumber(row("Qtde")) & "', DTDevolucao=" & sDTDevolucao & ", DTValidade=" & sDTValidade & ", DTBaixa=" & sDTBaixa & " where Id='" & row("Id") & "'"
        querySQl.ExecuteNonQuery()


        conSQL.Close()
    End Sub
End Class