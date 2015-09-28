Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Grid
Imports OnBarcode.Barcode
Public Class frmKardex
    Public datPubsKardex, datPubsTipoKardex As New DataSet()
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()
    Private Sub frmKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conSQL2 = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)


        Dim dHoje As Date = Date.Now.ToShortDateString()
        Dim dData As Date = dHoje.AddMonths(-4)
        txtDe.Text = dData
        txtAte.Text = dHoje.AddDays(1)

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
        Dim dDataAte As Date
        dDataAte = txtAte.Text
        dDataAte = dDataAte.AddDays(1)

        'CARREGA Tipo de Endereco
        datPubsKardex.Clear()
        adaptSQL = New SqlClient.SqlDataAdapter("select * from Kardex where Data Between convert(datetime,'" & txtDe.Text & "',103) and convert(datetime,'" & dDataAte & "',103) " & sBusca & " order by Registro Desc", conSQL2)
        adaptSQL.Fill(datPubsKardex, "TipoEnd")
        GridKardex.DataSource = datPubsKardex.Tables("TipoEnd")
    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub bt0Buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0Buscar.Click
        busca()
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If classParam.selPermissoes(234, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            If MessageBox.Show("Confirma a gravação dos dados", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Row As System.Data.DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim View As GridView = sender
                Dim VDado As String = "", VTipo As String = ""
                Dim VCampo As String = ""
                VCampo = e.Column.FieldName
                VTipo = e.Column.ColumnType.ToString
                VDado = View.EditingValue
                If VTipo = "System.Double" Then
                    gVSQL = "UPDATE Kardex SET " & VCampo & " = " & Replace(VDado, ",", ".") & " WHERE Registro = " & Row("Registro")
                ElseIf VTipo = "System.String" Then
                    gVSQL = "UPDATE Kardex SET " & VCampo & " = '" & VDado & "' WHERE Registro = " & Row("Registro")
                ElseIf VTipo = "System.DateTime" Then
                    gVSQL = "UPDATE Kardex SET " & VCampo & " = Convert(DateTime,'" & VDado & "',103) WHERE Registro = " & Row("Registro")
                ElseIf VTipo = "System.Boolean" Then
                    If VDado = True Then
                        gVSQL = "UPDATE Kardex SET " & VCampo & " = 1 WHERE Registro = " & Row("Registro")
                    Else
                        gVSQL = "UPDATE Kardex SET " & VCampo & " = 0 WHERE Registro = " & Row("Registro")
                    End If
                End If
                Try
                    conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
                    conSQL.Open()
                    querySQl.Connection = conSQL
                    querySQl.CommandText = gVSQL
                    querySQl.ExecuteNonQuery()
                    conSQL.Close()
                Catch
                    MessageBox.Show("Erro: Dado não foi alterado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Else
                GridView1.CancelUpdateCurrentRow()
            End If
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub


    Private Sub bt0ExcluirEndereco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt0ExcluirEndereco.Click
        'If classParam.selPermissoes(234, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
        If UCase(gUsuario) = "IVANILDO" Then
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

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim ps As New PrintingSystem
        With ps
            .ShowPrintStatusDialog = False
            .SetCommandVisibility(PrintingSystemCommand.File, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.View, CommandVisibility.None)
            .SetCommandVisibility(PrintingSystemCommand.Background, CommandVisibility.None)
        End With
        Dim link As New PrintableComponentLink(ps)
        link.Component = GridView1.GridControl
        link.Margins.Left = 50
        link.Margins.Right = 50
        link.Landscape = False
        link.EnablePageDialog = True

        Dim HeaderArea As DevExpress.XtraPrinting.PageHeaderArea = New DevExpress.XtraPrinting.PageHeaderArea
        HeaderArea.Content.Add(Date.Now.ToShortDateString())
        HeaderArea.Content.Add("Ficha Kardex")
        HeaderArea.Content.Add("Pagina[Page # of Pages #]")
        HeaderArea.Font = New Font("Arial", 11.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        HeaderArea.LineAlignment = BrickAlignment.Center
        Dim Header As DevExpress.XtraPrinting.PageHeaderFooter = New DevExpress.XtraPrinting.PageHeaderFooter(HeaderArea, Nothing)
        link.PageHeaderFooter = Header
        link.CreateDocument()
        link.ShowPreviewDialog()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton3.Click
        Dim dDataFim As Date = Date.Now.ToShortDateString()
        dDataFim = dDataFim.AddDays(1)
        Dim sMes As String = Date.Now.Month
        Dim dDataIni As String = "01/" & sMes.PadLeft(2, "0") & "/" & Date.Now.Year
        Dim cCDProduto As String = InputBox("Digite o codigo do produto", "Produto")
        Dim cCDInicio As String = InputBox("Digite a data inicial", "Data Inicial", dDataIni)
        Dim cCDFim As String = InputBox("Digite a data final", "Data Final", dDataFim)
        If cCDProduto <> "" And cCDFim <> "" And cCDInicio <> "" Then
            Dim x As New XtraFichaKardex(cCDProduto, cCDInicio, cCDFim)
            x.ShowPreview()
        End If
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim barcode As QRCode = New QRCode

    '    'QRCode Barcode Basic Settings

    '    'QRCode Valid data char set:
    '    'numeric data (digits 0 - 9);
    '    'alphanumeric data (digits 0 - 9; upper case letters A -Z;
    '    'nine other characters: space, $ % * + - . / : );
    '    'byte data (default: ISO/IEC 8859-1);
    '    'Kanji(characters)
    '    barcode.Data = "112233445566ABCDEFGHIJKLMNOPQRSTUVXYZ"

    '    barcode.DataMode = QRCodeDataMode.Auto
    '    barcode.Version = QRCodeVersion.V1
    '    barcode.ECL = QRCodeECL.L

    '    'Set the ProcessTilde property to true,if you want use the tilde character "~" 
    '    'to specify special characters in the input data. Default is false.

    '    '1) 1-byte character: ~0dd/~1dd/~2dd (character value from 000 ~ 255);
    '    '   ASCII character '~' is presented by ~126;
    '    '   Strings from "~256" to "~299" are unused
    '    '   modified to FS, GS, RS and US respectively.
    '    '2) 2-byte character (Unicode): ~6ddddd (character value from 00000 ~ 65535)
    '    '   Strings from "~665536" to "~699999" are unused
    '    '3) for GS1 AI Code: 
    '    '   ~ai2: AI with 2 digits
    '    '   ~ai3: AI with 3 digits
    '    '   ~ai4: AI with 4 digits
    '    '   ~ai5: AI with 5 digits
    '    '   ~ai6: AI with 6 digits
    '    '   ~ai7: AI with 7 digits
    '    '4) ECI: ~7dddddd (valid value of dddddd from 000000 to 999999)
    '    '5) SJIS: from ~9ddddd (Shift JIS 0x8140 ~ 0x9FFC and 0xE040 ~ 0xEBBF)
    '    barcode.ProcessTilde = True

    '    ' Barcode Size Related Settings
    '    barcode.UOM = UnitOfMeasure.PIXEL
    '    barcode.X = 3
    '    barcode.LeftMargin = 0
    '    barcode.RightMargin = 0
    '    barcode.TopMargin = 0
    '    barcode.BottomMargin = 0
    '    barcode.Resolution = 96
    '    barcode.Rotate = Rotate.Rotate0

    '    ' Image format setting
    '    barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif()
    '    barcode.drawBarcode("c:\prisma\qr-code.gif")
    '    'barcode.drawBarcode("c://qr-code.gif")



    '    ' PLANET Barcode Basic Settings
    '    'barcode.Type = BarcodeType.PLANET

    '    '   PLANET Valid data char set:
    '    '        0, 1, 2, 3, 4, 5, 6, 7, 8, 9 (Digits)

    '    '   PLANET Valid data length: 11 or 13 digits only, excluding the last checksum digit
    '    'barcode.Data = "01234567890"

    '    '' PLANET Short bar vs high bar ratio
    '    'barcode.ShortTallRatio = 0.4F

    '    '' Barcode Size Related Settings
    '    'barcode.UOM = UnitOfMeasure.PIXEL
    '    'barcode.X = 1
    '    'barcode.Y = 65
    '    'barcode.LeftMargin = 0
    '    'barcode.RightMargin = 0
    '    'barcode.TopMargin = 0
    '    'barcode.BottomMargin = 0
    '    'barcode.Resolution = 96
    '    'barcode.Rotate = Rotate.Rotate0

    '    '' Barcode Text Settings
    '    'barcode.ShowText = True
    '    ''barcode.TextFont = New Drawing.Font("Arial", 9.0F, Drawing.FontStyle.Regular)
    '    'barcode.TextMargin = 6

    '    '' Image format setting
    '    'barcode.Format = System.Drawing.Imaging.ImageFormat.Gif()

    '    ''barcode.drawBarcode("c://planet.gif")
    '    'barcode.drawBarcode("c:\prisma\planet.gif")
    'End Sub

    Private Sub frmKardex_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class