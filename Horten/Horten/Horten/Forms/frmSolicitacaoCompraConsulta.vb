Imports DevExpress.XtraReports.UI
Public Class frmSolicitacaoCompraConsulta
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmRequisicaoMaterialConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carregaRequisicao()
    End Sub
    Public Sub carregaRequisicao()
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        ds.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("Select a.*,b.CDSolicitante,b.Obs,b.Aprovacao,b.DTSC from ItemSC a, SC b where a.CDSC=b.CDSC order by CDSC desc", conSQL2)
        adaptSQL.Fill(ds, "ItemSC")
        GridControl1.DataSource = ds.Tables("ItemSC")
    End Sub

    Private Sub bt0Excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Excluir.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDSC As String
        Try
            sCDSC = row("CDSC")
        Catch
            sCDSC = ""
        End Try
        If sCDSC <> "" Then
            If classParam.selPermissoes(349, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                gVSQL = "Delete from ItemSC where CDSC='" & sCDSC & "'"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()

                gVSQL = "Delete from SC where CDSC='" & sCDSC & "'"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()
                conSQL2.Close()

                MessageBox.Show("Solicitação de Compra apagada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                carregaRequisicao()
            Else
                MessageBox.Show("Você não tem autorização para excluir Solicitações, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma Solicitação de Compra para ser apagada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDSC As String
        Try
            sCDSC = row("CDSC")
        Catch
            sCDSC = ""
        End Try
        If sCDSC = "" Then
            MessageBox.Show("Selecione uma Solitição de Compra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim xtra As XtraSolicitacao = New XtraSolicitacao(sCDSC)
            xtra.ShowPreview()
        End If
    End Sub

    Private Sub bt0Alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Alterar.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDSC As String
        Dim sHora As String = Date.Now.TimeOfDay.Hours()
        Dim sMinuto As String = Date.Now.TimeOfDay.Minutes()
        Dim sHoraInc As String = sHora.PadLeft(2, "0") & ":" & sMinuto.PadLeft(2, "0")
        Try
            sCDSC = row("CDSC")
        Catch
            sCDSC = ""
        End Try
        If sCDSC <> "" Then
            If classParam.selPermissoes(348, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                If MessageBox.Show("Deseja realmente APROVAR a Solicitação " & sCDSC & "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes Then
                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2
                    gVSQL = "Update SC set Aprovacao='" & gUsuario & "', DTAprovacao=convert(Datetime,'" & Date.Now.ToShortDateString() & "',103),HRAprovacao='" & sHoraInc & "' where CDSC='" & sCDSC & "'"
                    querySQL2.CommandText = gVSQL
                    querySQL2.ExecuteNonQuery()
                    conSQL2.Close()

                    MessageBox.Show("Solicitação de Compra aprovada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Você não tem autorização para aprovar Solicitação de Compra, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma Solicitação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class