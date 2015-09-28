Imports System.Drawing
Imports DevExpress.XtraReports.UI
Public Class FichaEstoque1
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public VCDMaterial, VDescricao, sDataIni, sDataFim As String
    Public Sub New(ByVal sCDProduto As String, PDescricao As String, ByVal ssDataIni As String, ByVal ssDataFim As String)
        InitializeComponent()
        'sCDProduto = ssCDProduto
        sDataIni = ssDataIni
        sDataFim = ssDataFim
        VCDMaterial = sCDProduto
        VDescricao = PDescricao
        '##Pega impressora padrao
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlPathPrinters & "impressora.xml", "Danfe")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try

        XrTableCell1.Text = VCDMaterial
        XrDescricao.Text = VDescricao

        conSQLY.Open()
        querySQl.Connection = conSQLY

        Dim dSaldoIncial As Decimal

        Dim X As Integer = 0

        querySQl.CommandText = "Select Top 1 Saldo From Kardex Where CDProduto ='" & VCDMaterial & "' And Data <= Convert(DateTime,'" & sDataIni & "',103) Order By Registro Desc"
        dSaldoIncial = querySQl.ExecuteScalar


        querySQl.Connection = conSQLY
        VSQL = "Select * From Kardex Where CDProduto = '" & VCDMaterial & "' And Data BetWeen Convert(DateTime,'" & sDataIni & "',103) And Convert(DateTime,'" & sDataFim & "',103) Order By Registro"
        querySQl.CommandText = "Select * From Kardex Where CDProduto = '" & VCDMaterial & "' And Data BetWeen Convert(DateTime,'" & sDataIni & "',103) And Convert(DateTime,'" & sDataFim & "',103) Order By Registro"
        datRead = querySQl.ExecuteReader()
        Do While datRead.Read = True
            Dim Row1 As New XRTableRow()
            Dim Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8, Cell9, Cell10, Cell11 As New XRTableCell()
            '## tamanho da celula
            Cell1.Width = 201.67
            Cell2.Width = 262.52
            Cell3.Width = 161
            Cell4.Width = 164
            Cell5.Width = 160
            Cell6.Width = 159.1
            Cell7.Width = 164
            Cell8.Width = 162
            Cell9.Width = 159
            Cell10.Width = 164
            Cell11.Width = 162.57

            'Cell1.BackColor = Color.White
            'Cell2.BackColor = Color.White
            'Cell3.BackColor = Color.White
            'Cell4.BackColor = Color.White

            '# alinhamento 
            Cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            Cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Cell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


            '## configura fonte das celulas    
            Cell1.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell2.Font = New Font("Microsoft Sans Serif", 8.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell3.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell4.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell5.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell6.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell7.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell8.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell9.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell10.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Cell11.Font = New Font("Microsoft Sans Serif", 7.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)

            Row1.Height = 17
            Row1.Cells.Add(Cell1)
            Row1.Cells.Add(Cell2)
            Row1.Cells.Add(Cell3)
            Row1.Cells.Add(Cell4)
            Row1.Cells.Add(Cell5)
            Row1.Cells.Add(Cell6)
            Row1.Cells.Add(Cell7)
            Row1.Cells.Add(Cell8)
            Row1.Cells.Add(Cell9)
            Row1.Cells.Add(Cell10)
            Row1.Cells.Add(Cell11)


            Try
                Row1.Cells(0).Text = datRead("Data")
            Catch
            End Try
            Try
                If X = 0 Then
                    Row1.Cells(1).Text = "Saldo Inicial"
                    Row1.Cells(8).Text = dSaldoIncial
                    Row1.Cells(9).Text = datRead("VLUnitario")
                    Row1.Cells(10).Text = dSaldoIncial * datRead("VLUnitario")
                    X = X + 1
                Else
                    If datRead("Status") = "SMP" Then
                        Row1.Cells(1).Text = "Baixa"
                        Row1.Cells(5).Text = datRead("Qtde")
                        Row1.Cells(6).Text = datRead("VLUnitario")
                        Row1.Cells(7).Text = datRead("VLUnitario") * datRead("Qtde")
                    ElseIf datRead("Status") = "EMP" Then
                        Row1.Cells(1).Text = "Aquisição"
                        Row1.Cells(2).Text = datRead("Qtde")
                        Row1.Cells(3).Text = datRead("VLUnitario")
                        Row1.Cells(3).Text = datRead("VLUnitario") * datRead("Qtde")
                    End If
                End If
            Catch
                Row1.Cells(1).Text = ""
            End Try

            XrTable2.Rows.Add(Row1)
            'LBLTotal.Text = "Sub-Total: " & Format(VSubTot, "###,###,##0.00")
        Loop
        'LBLTotal.Text = "Total: " & Format(VTotal, "###,###,##0.00")
        conSQLY.Close()
        datRead.Close()

    End Sub
End Class