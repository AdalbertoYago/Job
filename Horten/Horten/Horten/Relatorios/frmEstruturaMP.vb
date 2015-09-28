Imports DevExpress.XtraGrid.Views.Grid
Public Class frmEstruturaMP
    Dim VCDProduto As String
    Public Sub New(ByVal PCDProduto As String)
        InitializeComponent()
        VCDProduto = PCDProduto
    End Sub
    Private Sub BTSair_Click(sender As Object, e As EventArgs) Handles BTSair.Click
        Me.Close()
    End Sub
    Private Sub frmEstruturaMP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        VSQL = "Select Id,CDProduto,CDMaterial,Unidade,Descricao,Qtde From Estrutura Where Cenario = 3 And CDProduto = '" & VCDProduto & "' And Substring(CDMaterial,1,1) = '1' And Substring(CDMaterial,1,3) <> '100' Order By CDmaterial"
        datPubs4.Clear()
        adaptSQL2 = New SqlClient.SqlDataAdapter(VSQL, conSQLY1)
        adaptSQL2.Fill(datPubs4, "EstruturaMP")
        GridControl1.DataSource = datPubs4.Tables("EstruturaMP")
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GridControl1_KeyUp(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Confirma a exclusão", "MP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim sRegistro As String
                Try
                    sRegistro = row("Id")
                Catch ex As Exception
                    sRegistro = ""
                End Try
                If sRegistro <> "" Then
                    conSQLY.Open()
                    querySQl.Connection = conSQLY
                    querySQl.CommandText = "Delete From Estrutura Where Id = '" & sRegistro & "'"
                    querySQl.ExecuteNonQuery()
                    conSQLY.Close()
                    row.Delete()
                Else
                    MessageBox.Show("Selecion um registro!", "Erro...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        End If
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim Row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        If Row.RowState = DataRowState.Modified Then
            If MessageBox.Show("Confirma a gravação dos dados", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim View As GridView = sender
                Dim VDado As String = "", VTipo As String = ""
                Dim VCampo As String = ""
                VCampo = e.Column.FieldName
                VTipo = e.Column.ColumnType.ToString
                VDado = View.EditingValue
                If VTipo = "System.Double" Then
                    gVSQL = "UPDATE Estrutura SET " & VCampo & " = " & Replace(VDado, ",", ".") & " WHERE Id = " & Row("Id")
                ElseIf VTipo = "System.String" Then
                    gVSQL = "UPDATE Estrutura SET " & VCampo & " = '" & VDado & "' WHERE Id = " & Row("Registro")
                End If
                Try
                    conSQLY.Open()
                    querySQl.Connection = conSQLY
                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()
                    conSQLY.Close()
                Catch
                    MessageBox.Show("Erro: Dado não foi alterado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Else
                GridView1.CancelUpdateCurrentRow()
            End If
        End If
    End Sub
    Private Sub GridView1_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.RowCountChanged
        Dim row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Try
            If row.RowState = DataRowState.Added Then
                conSQLY.Open()
                querySQl.Connection = conSQLY
                Try
                    VSQL = "Insert Into Estrutura (Cenario,CDProduto,CDMaterial,Qtde,Unidade,Descricao) Values (3,'" & row("CDProduto") & "','" & row("CDMaterial") & "'," & Replace(row("Qtde"), ",", ".") & ",'" & row("Unidade") & "','" & row("Descricao") & "')"
                    querySQl.CommandText = VSQL
                    querySQl.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                conSQLY.Close()
            End If
        Catch
        End Try
    End Sub
End Class