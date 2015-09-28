Public Class frmAtualzaUltimaCompra
    Public ds As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        If MessageBox.Show("Confirma a atualização?", "Pegunta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL.Open()
            querySQl.Connection = conSQL

            conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL2.Open()
            querySQL2.Connection = conSQL2

            conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
            conSQL3.Open()
            querySQL3.Connection = conSQL3


            querySQl.CommandText = "Select * From Estoque Where Estoque = '2'"
            datRead = querySQl.ExecuteReader()

            Do Until datRead.Read = False
                querySQL2.CommandText = "Select * From Baixas Where CDCodigo = '" & datRead("CDProduto") & "' Order By DTDoc Desc"
                datRead2 = querySQL2.ExecuteReader()
                If datRead2.Read = True Then
                    If datRead("CDProduto") = "1310035" Then
                        MessageBox.Show("OPA")
                    End If

                    Try
                        querySQL3.CommandText = "Update Estoque Set DTUltCom=Convert(datetime,'" & datRead2("DTDoc") & "',103),QTUltCom=" & Replace(datRead2("Qtde"), ",", ".") & ",VLUltCom=" & Replace(datRead2("VLUnitario"), ",", ".") & " where CDProduto='" & datRead("CDProduto") & "'"
                        querySQL3.ExecuteNonQuery()
                    Catch
                    End Try
                End If
                datRead2.Close()
            Loop
            MessageBox.Show("Registros atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            datRead.Close()
            Me.Cursor = Cursors.Default
            conSQL.Close()
            conSQL2.Close()
            conSQL3.Close()
        End If
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub
End Class