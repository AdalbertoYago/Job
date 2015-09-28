Imports System.Xml
Imports System.Drawing.Printing
Public Class frmImpressoras
    Public xmlString As String = xmlPathPrinters & "impressora.xml"
    Private Sub frmImpressoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pkInstalledPrinters As String
        Dim ssTring As String = ""

        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            CBImpressoraEtiqueta.Items.Add(pkInstalledPrinters)
            CBImpressoraDanfe.Items.Add(pkInstalledPrinters)
            CBImpressoraRelatorio.Items.Add(pkInstalledPrinters)
        Next

        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlString, "Etiquetas")
            CBImpressoraEtiqueta.SelectedItem = sPrinter

            sPrinter = cXML.pegaStringXML(xmlString, "Danfe")
            CBImpressoraDanfe.SelectedItem = sPrinter

            sPrinter = cXML.pegaStringXML(xmlString, "Relatorios")
            CBImpressoraRelatorio.SelectedItem = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        Dim writer As New XmlTextWriter(xmlString, System.Text.Encoding.UTF8)
        writer.Formatting = Formatting.Indented
        writer.WriteStartDocument()

        '#Abre Header
        writer.WriteStartElement("impressoras")
        writer.WriteElementString("Etiquetas", CBImpressoraEtiqueta.Text)
        writer.WriteElementString("Relatorios", CBImpressoraRelatorio.Text)
        writer.WriteElementString("Danfe", CBImpressoraDanfe.Text)

        writer.WriteEndElement()

        writer.WriteEndDocument()
        '#### FIM DO DOCUMENTO
        writer.Flush()
        writer.Close()

        MessageBox.Show("Impressora gravada com sucesso!", "Sucesso...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    End Sub
End Class