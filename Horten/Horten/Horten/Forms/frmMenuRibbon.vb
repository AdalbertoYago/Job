Public Class frmMenuRibbon 
    Public classParam As PrismaLibrary.ClassParametros = New PrismaLibrary.ClassParametros()

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        End
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        frmImpressoras.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim manEst As frmManutencaoEstoque = New frmManutencaoEstoque()
        manEst.MdiParent = Me
        manEst.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim lanc As frmLancamentosEstoque = New frmLancamentosEstoque()
        lanc.MdiParent = Me
        lanc.Show()

    End Sub

    Private Sub BarButtonItem13_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim req As frmRequisicaoMaterial = New frmRequisicaoMaterial()
        req.MdiParent = Me
        req.Show()
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Me.Cursor = Cursors.WaitCursor
        Dim k As frmKardex = New frmKardex()
        k.MdiParent = Me
        k.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarButtonItem8_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Me.Cursor = Cursors.WaitCursor
        Dim k As frmKardexEmpenho = New frmKardexEmpenho()
        k.MdiParent = Me
        k.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem25_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        Dim b As frmBalanco = New frmBalanco()
        b.MdiParent = Me
        b.Show()
    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim k As frmKardexContabil = New frmKardexContabil()
        k.MdiParent = Me
        k.Show()
    End Sub

    Private Sub frmMenuRibbon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RibbonControl.SelectedPage = RibbonPage1
        RibbonControl.Minimized = True
    End Sub

    Private Sub BarButtonItem24_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        Dim r As frmRelPosicaoEstoque = New frmRelPosicaoEstoque()
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem11_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim r As frmEstruturaProdutos = New frmEstruturaProdutos()
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            If Me.ActiveMdiChild.Name.IndexOf("frmRelPosicaoEstoque") > -1 Then
                CType(Me.ActiveMdiChild, frmRelPosicaoEstoque).imprimir()
            ElseIf Me.ActiveMdiChild.Name.IndexOf("frmRelPosicaoEntradaSaida") > -1 Then
                CType(Me.ActiveMdiChild, frmRelPosicaoEntradaSaida).imprimir()
            ElseIf Me.ActiveMdiChild.Name.IndexOf("frmBalanco") > -1 Then
                CType(Me.ActiveMdiChild, frmBalanco).imprimir()
            End If
        Catch
            MessageBox.Show("Você precisa estar dentro de uma tela para mandar algo para impressão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim r As frmEstruturaSubCJ = New frmEstruturaSubCJ()
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim r As frmEstruturaBaixaEstoque = New frmEstruturaBaixaEstoque("")
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem18_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Dim r As frmOndeUsa = New frmOndeUsa()
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem19_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim r As frmCalculoMinimo = New frmCalculoMinimo()
        r.MdiParent = Me
        r.Show()
    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim s As frmRequisicaoMaterialConsulta = New frmRequisicaoMaterialConsulta()
        s.MdiParent = Me
        s.Show()
    End Sub

    Private Sub BarButtonItem29_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        Dim s As frmRelCusto = New frmRelCusto()
        s.MdiParent = Me
        s.Show()
    End Sub

    Private Sub BarButtonItem23_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If classParam.selPermissoes(245, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            Dim a As frmAtualzaUltimaCompra = New frmAtualzaUltimaCompra()
            a.MdiParent = Me
            a.Show()
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub BarButtonItem22_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        If classParam.selPermissoes(244, gCDPerfil, gDataSource, gUserID, gPWD, gInitialCatalog) = True Then
            Dim i As frmRecalcEmpenho = New frmRecalcEmpenho()
            i.MdiParent = Me
            i.Show()
        Else
            MessageBox.Show("Você não tem acesso a essa opção. Contacte o Administrador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub BarButtonItem19_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim i As frmRelPosicaoEntradaSaida = New frmRelPosicaoEntradaSaida()
        i.MdiParent = Me
        i.Show()
    End Sub

    Private Sub BarButtonItem21_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Dim i As frmImprimeEtiqueta = New frmImprimeEtiqueta()
        i.MdiParent = Me
        i.Show()
    End Sub

    Private Sub BarButtonItem20_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim i As frmRequisicaoMaterialBaixa = New frmRequisicaoMaterialBaixa()
        i.MdiParent = Me
        i.Show()
    End Sub

    Private Sub BarButtonItem15_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim i As frmSolicitacaoCompra = New frmSolicitacaoCompra()
        i.MdiParent = Me
        i.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Dim i As frmSolicitacaoCompraConsulta = New frmSolicitacaoCompraConsulta()
        i.MdiParent = Me
        i.Show()
    End Sub

    Private Sub BarButtonItem17_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        MessageBox.Show("Atenção, a geração desse relatório é demorada. " & vbCrLf & "Lembre-se que ele utiliza os últimos Inventários realizados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Me.Cursor = Cursors.WaitCursor
        Dim i As frmHistoricoInventario = New frmHistoricoInventario()
        i.MdiParent = Me
        i.Show()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BarButtonItem27_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim f As frmProdutoMP = New frmProdutoMP()
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem30_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        Dim f As frmQtdeMP = New frmQtdeMP()
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub BarButtonItem31_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        Dim f As frmEPI = New frmEPI
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub RibbonControl_Click(sender As Object, e As EventArgs) Handles RibbonControl.Click

    End Sub

    Private Sub BTRecebimento_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BTRecebimento.ItemClick
        Dim f As FRMRecebimento = New FRMRecebimento
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub BarButtonItem34_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        Dim f As frmFichaEstoque = New frmFichaEstoque
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub BarButtonItem35_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        Dim f As frmRegistroInventario = New frmRegistroInventario
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick

    End Sub
End Class