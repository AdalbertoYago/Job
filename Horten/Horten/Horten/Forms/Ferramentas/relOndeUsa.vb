Imports System.Drawing
Imports DevExpress.XtraReports.UI
Public Class relOndeUsa
    Public conn As New PrismaLibrary.ClassSqlConnection
    Public sCDMaterial, sTipo, sDescricaoMaterial As String
    Public Sub New(ByVal ssCDMaterial As String, ByVal ssTipo As String, ByVal ssDescricaoMaterial As String)
        InitializeComponent()
        sCDMaterial = ssCDMaterial
        sTipo = ssTipo
        sDescricaoMaterial = ssDescricaoMaterial
        XrLData.Text = Date.Now.ToShortDateString()
        '##Pega impressora padrao
        Dim cXML As ClassXML = New ClassXML()
        Dim sPrinter As String = ""
        Try
            sPrinter = cXML.pegaStringXML(xmlPathPrinters & "impressora.xml", "Danfe")
            Me.PrinterName = sPrinter
        Catch ex As Exception
            sPrinter = ""
        End Try
        XrPictureBox1.ImageUrl = gLogoDanfe
        XrLEmpresa.Text = StrConv(gNomeEmpresa, VbStrConv.ProperCase)
        XrLabel1.Text = "Onde Usa - Material: " & sDescricaoMaterial

        conSQL = conn.sqlConnect(gDataSource, gUserID, gPWD, gInitialCatalog)
        conSQL.Open()
        querySQl.Connection = conSQL

        'Produto
        If sTipo <> 4 Then
            gVSQL = "Select Estrutura.*,Estoque.Descricao as Descricao2 From Estrutura Left Join Estoque On Estrutura.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDMaterial = '" & sCDMaterial & "' Order By Estrutura.CDProduto"
        Else
            gVSQL = "Select EstruturaSubCJ.*,Estoque.Descricao as Descricao2 From EstruturaSUBCJ Left Join Estoque On EstruturaSubCJ.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDItem = '" & sCDMaterial & "' Order By EstruturaSubCJ.CDProduto"
        End If
        querySQl.CommandText = gVSQL
        datRead = querySQl.ExecuteReader()
        Do Until datRead.Read = False
            Try
                xrlCDMateriaPrima.Text &= datRead("CDProduto") & vbCrLf
                xrlDescMateriaPrima.Text &= datRead("Descricao2") & vbCrLf
                xrlUMMateriaPrima.Text &= datRead("Unidade") & vbCrLf
                xrlQtdeMateriaPrima.Text &= datRead("Qtde") & vbCrLf
            Catch ex As Exception
                xrlCDMateriaPrima.Text &= " " & vbCrLf
                xrlDescMateriaPrima.Text &= " " & vbCrLf
                xrlUMMateriaPrima.Text &= " " & vbCrLf
                xrlQtdeMateriaPrima.Text &= " " & vbCrLf
            End Try
        Loop
        datRead.Close()


        'SubCJ
        Try
            gVSQL = "Select EstruturaMP.*,Estoque.Descricao  as Descricao2 From EstruturaMP Left Join Estoque On EstruturaMP.CDProduto = Estoque.CDProduto "
            gVSQL &= "Where CDMaterial = '" & sCDMaterial & "' Order By EstruturaMP.CDProduto"
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            Do Until datRead.Read = False
                Try
                    xrlCDSubCJ.Text &= datRead("CDProduto") & vbCrLf
                    xrlDescSubCJ.Text &= datRead("Descricao2") & vbCrLf
                    xrlUMSubCJ.Text &= datRead("Unidade") & vbCrLf
                    xrlQtdeSubCJ.Text &= datRead("Qtde") & vbCrLf
                Catch ex As Exception
                    xrlCDSubCJ.Text &= " " & vbCrLf
                    xrlDescSubCJ.Text &= " " & vbCrLf
                    xrlUMSubCJ.Text &= " " & vbCrLf
                    xrlQtdeSubCJ.Text &= " " & vbCrLf
                End Try
            Loop
            datRead.Close()
        Catch
        End Try

        'Fornecedores
        Try
            gVSQL = "Select a.CDFornec1,b.Fantasia,b.Produtos from Estoque a, Fornecedores b where a.CDFornec1=b.CDFornec and a.CDProduto='" & sCDMaterial & "'"
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                xrlCDFornec.Text &= datRead("CDFornec1") & vbCrLf
                xrlFantasia.Text &= datRead("Fantasia") & vbCrLf
                xrlPrincipaisProdutos.Text &= datRead("Produtos") & vbCrLf
            End If
            datRead.Close()
        Catch
        End Try
        Try
            gVSQL = "Select a.CDFornec1,b.Fantasia,b.Produtos from Estoque a, Fornecedores b where a.CDFornec2=b.CDFornec and a.CDProduto='" & sCDMaterial & "' "
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                xrlCDFornec.Text &= datRead("CDFornec2") & vbCrLf
                xrlFantasia.Text &= datRead("Fantasia") & vbCrLf
                xrlPrincipaisProdutos.Text &= datRead("Produtos") & vbCrLf
            End If
            datRead.Close()
        Catch
        End Try
        Try
            gVSQL = "Select a.CDFornec1,b.Fantasia,b.Produtos from Estoque a, Fornecedores b where a.CDFornec3=b.CDFornec and a.CDProduto='" & sCDMaterial & "' "
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                xrlCDFornec.Text &= datRead("CDFornec3") & vbCrLf
                xrlFantasia.Text &= datRead("Fantasia") & vbCrLf
                xrlPrincipaisProdutos.Text &= datRead("Produtos") & vbCrLf
            End If
            datRead.Close()
        Catch
        End Try
        Try
            gVSQL = "Select a.CDFornec1,b.Fantasia,b.Produtos from Estoque a, Fornecedores b where a.CDFornec4=b.CDFornec and a.CDProduto='" & sCDMaterial & "' "
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                xrlCDFornec.Text &= datRead("CDFornec4") & vbCrLf
                xrlFantasia.Text &= datRead("Fantasia") & vbCrLf
                xrlPrincipaisProdutos.Text &= datRead("Produtos") & vbCrLf
            End If
            datRead.Close()
        Catch
        End Try
        Try
            gVSQL = "Select a.CDFornec1,b.Fantasia,b.Produtos from Estoque a, Fornecedores b where a.CDFornec5=b.CDFornec and a.CDProduto='" & sCDMaterial & "' "
            querySQl.CommandText = gVSQL
            datRead = querySQl.ExecuteReader()
            If datRead.Read = True Then
                xrlCDFornec.Text &= datRead("CDFornec5") & vbCrLf
                xrlFantasia.Text &= datRead("Fantasia") & vbCrLf
                xrlPrincipaisProdutos.Text &= datRead("Produtos") & vbCrLf
            End If
            datRead.Close()
        Catch
        End Try
    End Sub
End Class