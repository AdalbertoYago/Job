Public Class frmKardexContabil
    Public datPubsKardex, datPubsTipoKardex As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub frmKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)


        Dim dHoje As Date = Date.Now.ToShortDateString()
        Dim dData As Date = dHoje.AddMonths(-8)
        txtDe.Text = dData
        txtAte.Text = dHoje

        busca()

        datPubsTipoKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from TipoKardex  order by Status", conSQL2)
        adaptSQL.Fill(datPubsTipoKardex, "TipoEnd")
        cbTipoKardex.DataSource = datPubsTipoKardex.Tables("TipoEnd")
        cbTipoKardex.DisplayMember = "Descricao"
        cbTipoKardex.ValueMember = "Status"
        cbTipoKardex.SelectedIndex = -1
    End Sub
    Public Sub busca()
        Dim sBusca As String = ""
        If cbTipoKardex.SelectedValue <> "" Then
            sBusca = " And Status='" & cbTipoKardex.SelectedValue() & "' "
        End If

        'CARREGA Tipo de Endereco
        datPubsKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from Kardex where Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & txtAte.Text & "',103) " & sBusca & " order by Registro Desc", conSQL2)
        adaptSQL.Fill(datPubsKardex, "TipoEnd")
        GridKardex.DataSource = datPubsKardex.Tables("TipoEnd")
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        busca()
    End Sub

    Private Sub bt0ExcluirEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If classParam.selPermissoes(234, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim sRegistro As String
            Try
                sRegistro = row("Registro")
            Catch ex As Exception
                sRegistro = ""
            End Try
            If sRegistro <> "" Then
                conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                conSQL2.Open()
                querySQl.Connection = conSQL2
                querySQl.CommandText = "Delete from kardex where Registro='" & sRegistro & "'"
                querySQl.ExecuteNonQuery()
                conSQL.Close()
                row.Delete()
            Else
                MessageBox.Show("Selecion um registro!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub
End Class