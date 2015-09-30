Public Class frmRequisicaoMaterialBaixa
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmRequisicaoMaterialConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSaldoKardex.Text = ""
        carregaRequisicao()
    End Sub
    Public Sub carregaRequisicao()
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        ds.Clear()
        gVSQL = "Select a.*,b.Requisitante,b.Historico,b.DTRequisicao,b.HRRequisicao,b.Aprovacao,b.Setor from ItemReq a, Requisicao b "
        gVSQL &= "where a.CDRequisicao=b.CDRequisicao and a.DTBaixa is NULL and Len(a.Descricao) > 0 and DTRequisicao > convert(datetime,'01/01/2011',103) order by CDRequisicao desc"

        adaptSQL = New SqlClient.SqlDataAdapter(gVSQL, conSQL2)
        adaptSQL.Fill(ds, "ItemReq")
        GridControl1.DataSource = ds.Tables("ItemReq")
    End Sub


    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDRequisicao As String
        Dim sCDMaterial As String
        Dim dQtde As Decimal
        Dim sDescricao As String
        Dim sHora As String = Date.Now.TimeOfDay.Hours()
        Dim sMinuto As String = Date.Now.TimeOfDay.Minutes()
        Dim sHoraInc As String = sHora.PadLeft(2, "0") & ":" & sMinuto.PadLeft(2, "0")
        Try
            sCDRequisicao = row("CDRequisicao")
        Catch
            sCDRequisicao = ""
        End Try
        If sCDRequisicao <> "" Then
            If classParam.selPermissoes(351, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                If MessageBox.Show("Deseja realmente BAIXAR a requisição " & sCDRequisicao & "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes Then
                    conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL.Open()
                    querySQl.Connection = conSQL

                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2

                    conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    querySQL4.Connection = conSQL4

                    querySQl.CommandText = "Select * from ItemReq where CDRequisicao='" & sCDRequisicao & "' and DTBaixa Is Null"
                    datRead = querySQl.ExecuteReader()
                    Do Until datRead.Read = False
                        Try
                            sCDMaterial = datRead("CDMaterial")
                        Catch ex As Exception
                            sCDMaterial = ""
                        End Try
                        Try
                            dQtde = datRead("Qtde")
                        Catch ex As Exception
                            dQtde = 0
                        End Try
                        Try
                            sDescricao = datRead("Descricao")
                        Catch ex As Exception
                            sDescricao = ""
                        End Try

                        If sCDMaterial <> "" And dQtde <> 0 Then
                            'Atualiza baixa na itemreq
                            gVSQL = "Update ItemReq set Almoxarife='" & gUsuario & "', DTBaixa=convert(Datetime,'" & Date.Now.ToShortDateString() & "',103),HRBaixa='" & sHoraInc & "' where CDRequisicao='" & sCDRequisicao & "' and CDMaterial='" & sCDMaterial & "'"
                            querySQL2.CommandText = gVSQL
                            querySQL2.ExecuteNonQuery()

                            '#atualiza Kardex
                            If sCDMaterial.Substring(0, 1) = 2 Then
                                conSQL4.Open()
                                querySQLProc.Connection = conSQL4
                                querySQLProc.CommandType = CommandType.StoredProcedure
                                querySQLProc.CommandText = "sp_Kardex"
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDMaterial))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtde, ",", ".")))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMC"))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Requisicao Nº " & sCDRequisicao))
                                querySQLProc.ExecuteNonQuery()
                                querySQLProc.Parameters.Clear()
                                conSQL4.Close()
                            Else
                                conSQL4.Open()
                                querySQLProc.Connection = conSQL4
                                querySQLProc.CommandType = CommandType.StoredProcedure
                                querySQLProc.CommandText = "sp_Kardex"
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDMaterial))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtde, ",", ".")))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMP"))
                                querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Requisicao Nº " & sCDRequisicao))
                                querySQLProc.ExecuteNonQuery()
                                querySQLProc.Parameters.Clear()
                                conSQL4.Close()
                            End If
                        End If
                    Loop
                    datRead.Close()
                    conSQL2.Close()

                    carregaRequisicao()

                    MessageBox.Show("Requisição baixada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Você não tem autorização para baixar requisições, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma Requisição", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SimpleButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton4.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDRequisicao As String
        Dim sCDMaterial As String
        Dim dQtde As Decimal
        Dim sDescricao As String
        Dim sHora As String = Date.Now.TimeOfDay.Hours()
        Dim sMinuto As String = Date.Now.TimeOfDay.Minutes()
        Dim sHoraInc As String = sHora.PadLeft(2, "0") & ":" & sMinuto.PadLeft(2, "0")
        Try
            sCDRequisicao = row("CDRequisicao")
        Catch
            sCDRequisicao = ""
        End Try
        If sCDRequisicao <> "" Then
            If classParam.selPermissoes(351, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                If MessageBox.Show("Deseja realmente BAIXAR PARCIAL a requisição " & sCDRequisicao & "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes Then
                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2

                    conSQL4 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    querySQL4.Connection = conSQL4

                    Try
                        sCDMaterial = row("CDMaterial")
                    Catch ex As Exception
                        sCDMaterial = ""
                    End Try
                    Try
                        dQtde = row("Qtde")
                    Catch ex As Exception
                        dQtde = 0
                    End Try
                    Try
                        sDescricao = row("Descricao")
                    Catch ex As Exception
                        sDescricao = ""
                    End Try

                    If sCDMaterial <> "" And dQtde <> 0 Then
                        'Atualiza baixa na itemreq
                        gVSQL = "Update ItemReq set Almoxarife='" & gUsuario & "', DTBaixa=convert(Datetime,'" & Date.Now.ToShortDateString() & "',103),HRBaixa='" & sHoraInc & "' where CDRequisicao='" & sCDRequisicao & "' and CDMaterial='" & sCDMaterial & "'"
                        querySQL2.CommandText = gVSQL
                        querySQL2.ExecuteNonQuery()

                        '#atualiza Kardex

                        conSQL4.Open()
                        querySQLProc.Connection = conSQL4
                        querySQLProc.CommandType = CommandType.StoredProcedure
                        querySQLProc.CommandText = "sp_Kardex"
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDProduto", sCDMaterial))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Qtde", Replace(dQtde, ",", ".")))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Descricao", sDescricao))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDFornec", ""))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDDoc", ""))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@CDRequisitante", gUsuario.ToUpper()))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@VLUnitario", 0))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Status", "SMP"))
                        querySQLProc.Parameters.Add(New SqlClient.SqlParameter("@Obs", "Requisicao Nº " & sCDRequisicao))
                        querySQLProc.ExecuteNonQuery()
                        querySQLProc.Parameters.Clear()
                        conSQL4.Close()
                    End If


                    conSQL2.Close()

                    carregaRequisicao()

                    MessageBox.Show("Item baixado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Você não tem autorização para baixar requisições, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma Requisição", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        pegaSaldo()
    End Sub


    Public Sub pegaSaldo()
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDMaterial As String = ""
        Dim dSaldo As Decimal

        Try
            sCDMaterial = row("CDMaterial")
        Catch ex As Exception
            sCDMaterial = ""
        End Try
        If sCDMaterial <> "" Then
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2
            gVSQL = "Select top 1 Saldo from Kardex where CDProduto='" & sCDMaterial & "' order by registro desc"
            querySQL2.CommandText = gVSQL
            Try
                lblSaldoKardex.Text = "Saldo em Kardex do item Selecionado: " & querySQL2.ExecuteScalar()
                conSQL2.Close()
            Catch
                conSQL2.Close()
            End Try
        End If
    End Sub

    Private Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        '## CHECA SE ROW ESTA EM MODO DE UPDATE
        If row.RowState = DataRowState.Modified Then
            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQl.Connection = conSQL2
            Try
                gVSQL = "update ItemReq set Qtde='" & Replace(row("Qtde"), ",", ".") & "' where CDRequisicao='" & row("CDREquisicao") & "' and CDMaterial='" & row("CDMaterial") & "'"
                querySQl.CommandText = gVSQL
                querySQl.ExecuteNonQuery()
            Catch
            End Try
            conSQL2.Close()
        End If
    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        pegaSaldo()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        lblSaldoKardex.Text = ""
        carregaRequisicao()
    End Sub
End Class