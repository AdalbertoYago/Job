Public Class ReportUsinart
    Dim sFuncionario As frmEPI = New frmEPI()
    Public gFunc, gData As String

    Public Sub New(ByVal sFunc As String, ByVal sData As String)
        InitializeComponent()
        ''##RESGATA VALORES DO FRMEPI
        gFunc = sFunc
        gData = sData

        conSQL.Open()

        ''###SELECIONA NOME DE FUNCIONARIO
        querySQl.Connection = conSQL
        querySQl.CommandText = "Select * from vetorh.dbo.R034FUN where numCra='" & gFunc & "'"
        datRead2 = querySQl.ExecuteReader()
        If datRead2.Read = True Then
            Try
                XrLFunc.Text = datRead2("nomFun")
                XrLNome2.Text = datRead2("nomFun")
            Catch
                XrLFunc.Text = ""
                XrLNome2.Text = ""
            End Try
            datRead2.Close()
        End If

        ''###SELECIONA EPI
        querySQl.Connection = conSQL
        querySQl.CommandText = "Select EPI.*,Estoque.Descricao From Prisma.dbo.EPI Left Join Prisma.dbo.Estoque On EPI.CDEPI = Estoque.CDProduto Where CDFuncionario = '" & gFunc & "' And DTRetirada = convert(datetime,'" & gData & "',103)"
        datRead = querySQl.ExecuteReader()
        Dim lData As String = ""
        Dim lQTde As String = ""
        Dim lEquip As String = ""
        Do Until datRead.Read = False
            lData = lData & datRead("DTRetirada") & vbCrLf
            lQTde = lQTde & datRead("Qtde") & vbCrLf
            lEquip = lEquip & datRead("Descricao") & vbCrLf
        Loop
        XrLData.Text = lData
        XrLQtde.Text = lQTde
        XrLEquipamento.Text = lEquip
        datRead.Close()

    End Sub

    Private Sub XrLabel7_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabel7.BeforePrint
        XrLabel7.Text = "São Paulo, " & DateTime.Now.ToLongDateString
    End Sub

End Class