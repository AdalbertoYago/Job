Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports OnBarcode.Barcode
Public Class XtraRequisicao2
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public sCDReq As String
    Public VEnd As String
    Public Sub New(ByVal ssCDReq As String)
        InitializeComponent()
        sCDReq = ssCDReq
        '##Pega impressora padrao
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlPathPrinters & "impressora.xml", "Danfe")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try
        'XrPictureBox1.ImageUrl = gLogoDanfe
        XrLEmpresa.Text = StrConv(gFantasia, VbStrConv.ProperCase)

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL2.Open()
        querySQL2.Connection = conSQL2

        conSQL3 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL3.Open()
        querySQL3.Connection = conSQL3

        querySQl.CommandText = "select * from Requisicao where CDRequisicao = '" & sCDReq & "'"
        datRead = querySQl.ExecuteReader()
        If datRead.Read = True Then
            XrLabel1.Text = "Requisição de Materiais Nº " & sCDReq
            XrLData.Text = "Data: " & datRead("DTRequisicao") & " " & datRead("HRRequisicao")
            XrLRequisitante.Text = "Requisitante: " & datRead("Requisitante")
            LBLObs.Text = "Obs: " & datRead("Historico")
            querySQL2.CommandText = "Select * from ItemReq where CDRequisicao = '" & sCDReq & "' order by Item"
            datRead2 = querySQL2.ExecuteReader()
            Do Until datRead2.Read = False
                Dim Row1 As New XRTableRow()
                Dim Cell1, Cell2, Cell3, Cell4, Cell5, Cell6 As New XRTableCell()
                '## tamanho da celula
                Cell1.Width = 86
                Cell2.Width = 200
                Cell3.Width = 1132
                Cell4.Width = 148
                Cell5.Width = 147
                Cell6.Width = 86
                '# alinhamento 
                Cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                Cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                Cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                Cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                Cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                Cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                
                '## configura fonte das celulas    
                Cell1.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Cell2.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Cell3.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Cell4.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Cell5.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
                Cell6.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)

                Row1.Height = 17
                Row1.Cells.Add(Cell1)
                Row1.Cells.Add(Cell2)
                Row1.Cells.Add(Cell3)
                Row1.Cells.Add(Cell4)
                Row1.Cells.Add(Cell5)
                Row1.Cells.Add(Cell6)

                Try
                    Row1.Cells(0).Text = datRead2("Item")
                Catch
                End Try
                Try
                    Row1.Cells(1).Text = datRead2("CDMaterial")
                Catch
                End Try
                Try
                    Row1.Cells(2).Text = datRead2("Descricao")
                Catch
                End Try
                Try
                    'Procura o endereco de estoque
                    querySQL3.CommandText = "Select Endereco From EstoqueEndereco Where CDProduto = '" & datRead2("CDMaterial") & "'"
                    Try
                        VEnd = querySQL3.ExecuteScalar
                    Catch
                        VEnd = ""
                    End Try
                    Row1.Cells(3).Text = VEnd
                Catch
                End Try
                Try
                    Row1.Cells(4).Text = datRead2("Qtde")
                Catch
                End Try
                Try
                    Row1.Cells(5).Text = datRead2("Unidade")
                Catch
                End Try
                XrTable1.Rows.Add(Row1)
            Loop
            conSQL.Close()
            datRead2.Close()
        End If
        datRead.Close()
        conSQL.Close()
        conSQL2.Close()
        conSQL3.Close()
    End Sub
End Class