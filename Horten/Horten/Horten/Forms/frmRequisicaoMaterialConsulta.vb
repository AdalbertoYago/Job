Imports DevExpress.XtraReports.UI
Public Class frmRequisicaoMaterialConsulta
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
        'adaptSQL = New SqlClient.SqlDataAdapter("Select a.*,b.Requisitante,b.DTRequisicao,b.HRRequisicao,b.Historico,b.Aprovacao,b.DTRequisicao,b.Setor,c.Endereco from ItemReq a, Requisicao b , EstoqueEndereco c where a.CDRequisicao=b.CDRequisicao and c.CDProduto=a.CDMaterial order by CDRequisicao desc", conSQL2)
        adaptSQL = New SqlClient.SqlDataAdapter("Select a.*,b.Requisitante,b.DTRequisicao,b.HRRequisicao,b.Historico,b.Aprovacao,b.DTRequisicao,b.Setor from ItemReq a, Requisicao b where a.CDRequisicao=b.CDRequisicao order by CDRequisicao desc", conSQL2)
        adaptSQL.Fill(ds, "ItemReq")
        GridControl1.DataSource = ds.Tables("ItemReq")
    End Sub

    Private Sub bt0Excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Excluir.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDRequisicao As String
        Try
            sCDRequisicao = row("CDRequisicao")
        Catch
            sCDRequisicao = ""
        End Try
        If sCDRequisicao <> "" Then
            If classParam.selPermissoes(349, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQL2.Connection = conSQL2
                gVSQL = "Delete from ItemReq where CDRequisicao='" & sCDRequisicao & "'"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()

                gVSQL = "Delete from Requisicao where CDRequisicao='" & sCDRequisicao & "'"
                querySQL2.CommandText = gVSQL
                querySQL2.ExecuteNonQuery()
                conSQL2.Close()

                MessageBox.Show("Requisição apagada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                carregaRequisicao()
            Else
                MessageBox.Show("Você não tem autorização para excluir requisições, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma requisição para ser apagada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDRequisicao As String
        Try
            sCDRequisicao = row("CDRequisicao")
        Catch
            sCDRequisicao = ""
        End Try
        If sCDRequisicao = "" Then
            MessageBox.Show("Selecione uma Requisição", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If gIDEmpresa = 1 Then
                Dim xtra As XtraRequisicao2 = New XtraRequisicao2(sCDRequisicao)
                xtra.ShowPreview()
            Else
                Dim xtra As XtraRequisicao = New XtraRequisicao(sCDRequisicao)
                xtra.ShowPreview()
            End If

        End If
    End Sub

    Private Sub bt0Alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Alterar.Click
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim sCDRequisicao As String
        Dim sHora As String = Date.Now.TimeOfDay.Hours()
        Dim sMinuto As String = Date.Now.TimeOfDay.Minutes()
        Dim sHoraInc As String = sHora.PadLeft(2, "0") & ":" & sMinuto.PadLeft(2, "0")
        Try
            sCDRequisicao = row("CDRequisicao")
        Catch
            sCDRequisicao = ""
        End Try
        If sCDRequisicao <> "" Then
            If classParam.selPermissoes(348, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
                If MessageBox.Show("Deseja realmente APROVAR a requisição " & sCDRequisicao & "?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.Yes Then
                    conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL2.Open()
                    querySQL2.Connection = conSQL2
                    gVSQL = "Update Requisicao set Aprovacao='" & gUsuario & "', DTAprovacao=convert(Datetime,'" & Date.Now.ToShortDateString() & "',103),HRAprovacao='" & sHoraInc & "' where CDRequisicao='" & sCDRequisicao & "'"
                    querySQL2.CommandText = gVSQL
                    querySQL2.ExecuteNonQuery()
                    conSQL2.Close()

                    MessageBox.Show("Requisição aprovada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Você não tem autorização para aprovar requisições, contacte o administrador do sistema", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecione uma Requisição", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        carregaRequisicao()
    End Sub
End Class