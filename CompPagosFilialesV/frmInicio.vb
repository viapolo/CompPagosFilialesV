Imports System.Xml
Imports System.IO
Public Class frmPrincipal

    Dim taConsecutivo As New Production_AUXDataSetTableAdapters.CFDI_CompConsFactorajeTableAdapter
    Dim dsConsecutivo As New Production_AUXDataSet

    Dim taComplementos As New Factor100DataSetTableAdapters.Vw_ChequesDetalleTableAdapter
    Dim dsComplemento As New Factor100DataSet

    Dim taCFDI_CtasPAGO As New Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter
    Dim dsCFDI_CtasPAGO As New Production_AUXDataSet

    Dim taCOFIDI As New ATEBCOFIDIRECDataSetTableAdapters.CFDProveedorTableAdapter
    Dim dsCOFIDI As New ATEBCOFIDIRECDataSet

    Dim taCOFIDI_Emp As New ATEBCOFIDIRECDataSetTableAdapters.EmpresaTableAdapter
    Dim dsCOFIDI_Emp As New ATEBCOFIDIRECDataSet

    Dim taCFDI_ENC As New Production_AUXDataSetTableAdapters.CFDI_EncabezadoTableAdapter
    Dim dsCFDI_ENC As New Production_AUXDataSet

    Dim taClientes As New Production_AUXDataSetTableAdapters.ClientesTableAdapter
    Dim dsClientes As New Production_AUXDataSet

    Dim taCFDI_DET As New Production_AUXDataSetTableAdapters.CFDI_DetalleTableAdapter
    Dim dsCFDI_DET As New Production_AUXDataSet

    Dim taCFDI_CPAGO As New Production_AUXDataSetTableAdapters.CFDI_ComplementoPagoTableAdapter
    Dim dsCFDI_CPAGO As New Production_AUXDataSet

    Dim taCFDI_Bancos As New Production_AUXDataSetTableAdapters.CFDI_BancosTableAdapter
    Dim dsCFDI_Bancos As New Production_AUXDataSet

    Dim taWeb_Finagil As New WEB_FinagilDataSetTableAdapters.WEB_FacturasXMLTableAdapter
    Dim dsWeb_Finagil As New WEB_FinagilDataSet

    Dim taMailCFDI As New Production_AUXDataSetTableAdapters.CFDI_MailTableAdapter
    Dim dsMailCFDI As New Production_AUXDataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'dsProduction.CFDI_CuentasClientes' Puede moverla o quitarla según sea necesario.
        Me.CFDI_CuentasClientesTableAdapter.Fill(Me.dsProduction.CFDI_CuentasClientes)

        Me.Vw_ChequesDetalleTableAdapter.Fill(Me.Factor100DataSet.Vw_ChequesDetalle)
        Me.taCFDI_CompConsFactoraje.NProcFillBy(Me.dsProduction.CFDI_CompConsFactoraje)
        For i = 0 To dgvComplementos.Rows.Count - 1
            Me.dgvComplementos.Item("dgDocRelacionado", i).Value = "UUID's Rel"
        Next
    End Sub

    Private Sub NProcFillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.taCFDI_CompConsFactoraje.NProcFillBy(Me.dsProduction.CFDI_CompConsFactoraje)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub NProcFillByToolStripButton_Click_1(sender As Object, e As EventArgs)
        Try
            Me.taCFDI_CompConsFactoraje.NProcFillBy(Me.dsProduction.CFDI_CompConsFactoraje)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnNoProcesados_Click(sender As Object, e As EventArgs) Handles btnNoProcesados.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnNoProcesados.Enabled = False
        btnProcesar.Enabled = False
        btnMails.Enabled = False
        btnCuentas.Enabled = False
        Dim rows As Factor100DataSet.Vw_ChequesDetalleRow

        taComplementos.CFDI_Enc_FillBy1(dsComplemento.Vw_ChequesDetalle)

        If dsComplemento.Vw_ChequesDetalle.Rows.Count > 0 Then

            For Each rows In dsComplemento.Vw_ChequesDetalle.Rows()
                Try
                    Dim rowheader As Production_AUXDataSet.CFDI_CompConsFactorajeRow
                    rowheader = dsConsecutivo.CFDI_CompConsFactoraje.NewCFDI_CompConsFactorajeRow()
                    rowheader.RFC = rows.RFC
                    rowheader.Cheque = rows.Cheque
                    rowheader.Referencia = rows.Banco
                    rowheader.Serie_CFDI = "REPF"
                    rowheader.Procesado = 0

                    rowheader.FechaPago = rows.Fecha
                    rowheader.FormaDePagoP = rows.MetPago.Replace("Spei", "03")
                    rowheader.MonedaP = rows.Moneda.Replace("PESO", "MXN")
                    rowheader.Monto = rows.MontoCheque
                    rowheader.NumOperacion = rows.Cheque
                    rowheader.RFCEmisorCtaOrd = validaNull(taCFDI_CtasPAGO.Obt_RFC_Banco_FillBy(rows.RFC))
                    rowheader.NomBancoOrdExt = validaNull(taCFDI_Bancos.Obtiene_Nombre_Banco(rowheader.RFCEmisorCtaOrd))
                    If rowheader.NomBancoOrdExt.Length > 0 Then
                        rowheader.NomBancoOrdExt = rowheader.NomBancoOrdExt.ToString.Substring(0, 49)
                    End If
                    rowheader.CtaOrdenante = validaNull(taCFDI_CtasPAGO.Obt_Cta_Banco_FillBy(rows.RFC))
                    rowheader.RFCEmisorCtaBen = "BBA830831LJ2"
                    rowheader.CtaBeneficiario = "0448250278"

                    dsConsecutivo.CFDI_CompConsFactoraje.Rows.Add(rowheader)
                    taConsecutivo.Update(dsConsecutivo.CFDI_CompConsFactoraje)

                Catch ex As Exception
                End Try
                dsConsecutivo.CFDI_CompConsFactoraje.Clear()
            Next
        End If

        Me.taCFDI_CompConsFactoraje.NProcFillBy(Me.dsProduction.CFDI_CompConsFactoraje)
        For i = 0 To dgvComplementos.Rows.Count - 1
            Me.dgvComplementos.Item("dgDocRelacionado", i).Value = "UUID's Rel"
        Next
        Cursor = System.Windows.Forms.Cursors.Default
        btnNoProcesados.Enabled = True
        btnProcesar.Enabled = True
        btnMails.Enabled = True
        btnCuentas.Enabled = True
    End Sub

    Private Sub dgvComplementos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComplementos.CellContentClick
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnNoProcesados.Enabled = False
        btnProcesar.Enabled = False
        btnMails.Enabled = False
        btnCuentas.Enabled = False
        If e.ColumnIndex = 16 And Me.dgvComplementos.Item("dgDocRelacionado", e.RowIndex).Value = "UUID's Rel" Then
            varFechaDePago = dgvComplementos.Item("FechaPagoDataGridViewTextBoxColumn", e.RowIndex).Value
            varFormaDePago = dgvComplementos.Item("FormaDePagoPDataGridViewTextBoxColumn", e.RowIndex).Value
            varMoneda = dgvComplementos.Item("MonedaPDataGridViewTextBoxColumn", e.RowIndex).Value
            varTipoDeCambio = ""
            varMontoDePago = dgvComplementos.Item("MontoDataGridViewTextBoxColumn", e.RowIndex).Value
            varReferencia = dgvComplementos.Item("NumOperacionDataGridViewTextBoxColumn", e.RowIndex).Value + ""
            varRFCBancoOrdenante = dgvComplementos.Item("RFCEmisorCtaOrdDataGridViewTextBoxColumn", e.RowIndex).Value + ""
            varNombreBancoOrdenante = dgvComplementos.Item("NomBancoOrdExtDataGridViewTextBoxColumn", e.RowIndex).Value + ""
            varCtaOrdenante = dgvComplementos.Item("CtaOrdenanteDataGridViewTextBoxColumn", e.RowIndex).Value + ""
            varCheque = dgvComplementos.Item("ChequeDataGridViewTextBoxColumn", e.RowIndex).Value

            frmUUIDRel.Show()

        End If
        Cursor = System.Windows.Forms.Cursors.Default
        btnNoProcesados.Enabled = True
        btnProcesar.Enabled = True
        btnMails.Enabled = True
        btnCuentas.Enabled = True
    End Sub

    Public Function validaNull(valor As Object)
        If String.IsNullOrEmpty(valor) Then
            Return ""
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Private Sub cmbRFC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFC.SelectedIndexChanged
        Me.taCFDI_CompConsFactoraje.NProcXRFC_FillBy(Me.dsProduction.CFDI_CompConsFactoraje, cmbRFC.Text)
        For i = 0 To dgvComplementos.Rows.Count - 1
            Me.dgvComplementos.Item("dgDocRelacionado", i).Value = "UUID's Rel"
        Next
    End Sub

    Public Function regresaSF(ByVal Referencia As String)
        Dim retorno(1) As String
        For Each Val As Char In Referencia.ToCharArray()
            If Char.IsNumber(Val) Then
                retorno(1) = retorno(1) + Val
            Else
                retorno(0) = retorno(0) + Val
            End If
        Next
        Return retorno
    End Function

    Public Function habilitar_desabilitar(ByVal parametro As String)
        If parametro = "D" Then
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            btnNoProcesados.Enabled = False
            btnProcesar.Enabled = False
            btnMails.Enabled = False
            btnCuentas.Enabled = False
        ElseIf parametro = "H" Then
            Cursor = System.Windows.Forms.Cursors.Default
            btnNoProcesados.Enabled = True
            btnProcesar.Enabled = True
            btnMails.Enabled = True
            btnCuentas.Enabled = True
        End If
    End Function

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnNoProcesados.Enabled = False
        btnProcesar.Enabled = False
        btnMails.Enabled = False
        btnCuentas.Enabled = False
        pbCheque.Visible = True
        pbTodos.Visible = True
        pbTodos.Value = 1
        pbTodos.Step = 1
        pbTodos.Maximum = dgvComplementos.Rows.Count + 1
        Dim verdes As Integer = 0
        For i = 0 To dgvComplementos.Rows.Count - 1
            If dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "FGM790801SD7" Or dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "PCO880928RD1" Or dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "PPL8012295V2" Or dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "MSU850911A56" Or dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "PAM781201CWO" Or dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value = "HPI880624SW5" Then
                'FILIALES
                Me.taComplementos.DocRela_FillBy(Me.dsComplemento.Vw_ChequesDetalle, dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value, dgvComplementos.Item("ChequeDataGridViewTextBoxColumn", i).Value)
                Dim importeXML As Double = 0
                Dim rowsD3 As Factor100DataSet.Vw_ChequesDetalleRow
                pbCheque.Value = 1
                pbCheque.Step = 1
                pbCheque.Maximum = dsComplemento.Vw_ChequesDetalle.Rows.Count + 1
                For Each rowsD3 In dsComplemento.Vw_ChequesDetalle.Rows()
                    Try
                        If rowsD3.Referencia.Length = 15 Then
                            Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, rowsD3.Referencia.Insert(8, "-").Insert(13, "-"), rowsD3.RFC)
                        Else
                            Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, rowsD3.Referencia.Substring(0, 8), rowsD3.RFC)
                        End If
                    Catch
                    End Try
                    Dim rowsD4 As ATEBCOFIDIRECDataSet.CFDProveedorRow
                    For Each rowsD4 In dsCOFIDI.CFDProveedor.Rows()
                        importeXML += Val(validaNull(leeXML(rowsD4.CFDOriginal, "Total")))
                    Next
                    pbCheque.Value += 1
                Next

                If Math.Round(importeXML, 2) = dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Value Then
                    Me.dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Style.BackColor = Color.Green
                    Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).ReadOnly = False
                    verdes += 1
                Else
                    Me.dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Style.BackColor = Color.Firebrick
                    Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).ReadOnly = True
                End If
                Me.Refresh()
                pbTodos.Value += 1
            Else
                'NO FILIALES
                Me.taComplementos.DocRela_FillBy(Me.dsComplemento.Vw_ChequesDetalle, dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value, dgvComplementos.Item("ChequeDataGridViewTextBoxColumn", i).Value)
                Dim importeXML As Double = 0
                Dim rowsD3 As Factor100DataSet.Vw_ChequesDetalleRow
                pbCheque.Value = 1
                pbCheque.Step = 1
                pbCheque.Maximum = dsComplemento.Vw_ChequesDetalle.Rows.Count + 1
                For Each rowsD3 In dsComplemento.Vw_ChequesDetalle.Rows()
                    Dim SF() As String = regresaSF(rowsD3.Referencia)
                    Try
                        Me.taWeb_Finagil.Obt_CFDI_FillBy(Me.dsWeb_Finagil.WEB_FacturasXML, SF(0), SF(1))
                    Catch
                    End Try
                    Dim rowsD4 As WEB_FinagilDataSet.WEB_FacturasXMLRow
                    For Each rowsD4 In dsWeb_Finagil.WEB_FacturasXML.Rows()
                        importeXML += Math.Round(Val(rowsD4.ImporteFactura), 2)
                    Next
                    pbCheque.Value += 1
                Next

                If Math.Round(importeXML, 2) = dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Value Then
                    Me.dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Style.BackColor = Color.Green
                    Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).ReadOnly = False
                    verdes += 1
                Else
                    Me.dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Style.BackColor = Color.Firebrick
                    Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).ReadOnly = True
                End If
                Me.Refresh()
                pbTodos.Value += 1
            End If
        Next
        pbCheque.Visible = False
        pbTodos.Visible = False
        If verdes > 0 Then
            btnTimbrar.Enabled = True
        End If
        Cursor = System.Windows.Forms.Cursors.Default
        btnNoProcesados.Enabled = True
        btnProcesar.Enabled = True
        btnMails.Enabled = True
        btnCuentas.Enabled = True
    End Sub

    Public Function leeXML(docXML As String, nodo As String)
        Dim doc As XmlDataDocument
        doc = New XmlDataDocument
        doc.LoadXml(docXML)
        Dim CFDI As XmlNode
        Dim retorno As String = ""

        CFDI = doc.DocumentElement

        For Each Comprobante As XmlNode In CFDI.Attributes
            If Comprobante.Name = "Moneda" And nodo = "Moneda" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf Comprobante.Name = "TipoCambio" And nodo = "TipoCambio" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Total" Or Comprobante.Name = "total") And nodo = "Total" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "MetodoPago" Or Comprobante.Name = "metodoDePago") And nodo = "MetodoPago" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Serie" Or Comprobante.Name = "serie") And nodo = "Serie" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Folio" Or Comprobante.Name = "folio") And nodo = "Folio" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            End If
        Next
    End Function

    Public Function leeXMLF(docXML As String, nodo As String)
        Dim doc As XmlDataDocument
        doc = New XmlDataDocument
        doc.Load(docXML)
        Dim CFDI As XmlNode
        Dim retorno As String = ""

        CFDI = doc.DocumentElement

        For Each Comprobante As XmlNode In CFDI.Attributes
            If Comprobante.Name = "Moneda" And nodo = "Moneda" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf Comprobante.Name = "TipoCambio" And nodo = "TipoCambio" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Total" Or Comprobante.Name = "total") And nodo = "Total" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "MetodoPago" Or Comprobante.Name = "metodoDePago") And nodo = "MetodoPago" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf Comprobante.Name = "FormaPago" And nodo = "FormaPago" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Serie" Or Comprobante.Name = "serie") And nodo = "Serie" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            ElseIf (Comprobante.Name = "Folio" Or Comprobante.Name = "folio") And nodo = "Folio" Then
                retorno = Comprobante.Value.ToString
                Return retorno
                Exit Function
            End If
        Next
    End Function

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click
        For i = 0 To dgvComplementos.Rows.Count - 1
            Dim valor As Boolean = Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).Value
            If Me.dgvComplementos.Item("ProcesadoDataGridViewCheckBoxColumn", i).Value = True Then
                varFechaDePago = dgvComplementos.Item("FechaPagoDataGridViewTextBoxColumn", i).Value
                varFormaDePago = dgvComplementos.Item("FormaDePagoPDataGridViewTextBoxColumn", i).Value
                varMoneda = dgvComplementos.Item("MonedaPDataGridViewTextBoxColumn", i).Value
                varTipoDeCambio = ""
                varMontoDePago = dgvComplementos.Item("MontoDataGridViewTextBoxColumn", i).Value
                varReferencia = dgvComplementos.Item("NumOperacionDataGridViewTextBoxColumn", i).Value + ""
                varRFCBancoOrdenante = dgvComplementos.Item("RFCEmisorCtaOrdDataGridViewTextBoxColumn", i).Value + ""
                varNombreBancoOrdenante = dgvComplementos.Item("NomBancoOrdExtDataGridViewTextBoxColumn", i).Value + ""
                varCtaOrdenante = dgvComplementos.Item("CtaOrdenanteDataGridViewTextBoxColumn", i).Value + ""
                varCheque = dgvComplementos.Item("ChequeDataGridViewTextBoxColumn", i).Value

                Me.taComplementos.DocRela_FillBy(Me.dsComplemento.Vw_ChequesDetalle, dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value, dgvComplementos.Item("ChequeDataGridViewTextBoxColumn", i).Value)
                Dim rowsD3 As Factor100DataSet.Vw_ChequesDetalleRow
                Dim rowCFDI_ENC As Production_AUXDataSet.CFDI_EncabezadoRow
                rowCFDI_ENC = dsCFDI_ENC.CFDI_Encabezado.NewCFDI_EncabezadoRow()

                rowCFDI_ENC._1_Folio = taCFDI_ENC.ObtieneFolioFact()
                rowCFDI_ENC._2_Nombre_Emisor = "FINAGIL S.A. DE C.V, SOFOM E.N.R"
                rowCFDI_ENC._3_RFC_Emisor = "FIN940905AX7"
                rowCFDI_ENC._4_Dom_Emisor_calle = "Leandro Valle"
                rowCFDI_ENC._5_Dom_Emisor_noExterior = "402"
                rowCFDI_ENC._6_Dom_Emisor_noInterior = ""
                rowCFDI_ENC._7_Dom_Emisor_colonia = "Reforma y F.F.C.C"
                rowCFDI_ENC._8_Dom_Emisor_localidad = "Toluca"
                rowCFDI_ENC._9_Dom_Emisor_referencia = ""
                rowCFDI_ENC._10_Dom_Emisor_municipio = "Toluca"
                rowCFDI_ENC._11_Dom_Emisor_estado = "Estado de México"
                rowCFDI_ENC._12_Dom_Emisor_pais = "México"
                rowCFDI_ENC._13_Dom_Emisor_codigoPostal = "50070"
                rowCFDI_ENC._26_Version = "3.3"
                rowCFDI_ENC._27_Serie_Comprobante = "REPF"
                rowCFDI_ENC._29_FormaPago = ""
                rowCFDI_ENC._30_Fecha = Date.Now.ToString("yyyy-MM-dd")
                rowCFDI_ENC._31_Hora = Date.Now.ToString("hh:mm:ss")
                rowCFDI_ENC._41_Dom_LugarExpide_codigoPostal = "50070"
                rowCFDI_ENC._42_Nombre_Receptor = taClientes.ScalarQuery(dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value).ToString.Trim
                rowCFDI_ENC._43_RFC_Receptor = dgvComplementos.Item("RFCDataGridViewTextBoxColumn", i).Value
                rowCFDI_ENC._54_Monto_SubTotal = 0
                rowCFDI_ENC._55_Monto_IVA = 0
                rowCFDI_ENC._56_Monto_Total = 0
                rowCFDI_ENC._57_Estado = "1"
                rowCFDI_ENC._58_TipoCFD = "FA"
                rowCFDI_ENC._83_Cod_Moneda = "XXX"
                rowCFDI_ENC._97_Condiciones_Pago = ""
                rowCFDI_ENC._100_Letras_Monto_Total = ""
                rowCFDI_ENC._113_Misc01 = "[CPG_FINAGIL]"
                rowCFDI_ENC._114_Misc02 = ""
                rowCFDI_ENC._132_Misc20 = "[CPG]"
                rowCFDI_ENC._144_Misc32 = "P01"
                rowCFDI_ENC._157_Misc45 = ""
                rowCFDI_ENC._158_Misc46 = ""
                rowCFDI_ENC._159_Misc47 = ""
                rowCFDI_ENC._162_Misc50 = (taMailCFDI.ObtMail1(rowCFDI_ENC._43_RFC_Receptor) + ";" + taMailCFDI.ObtMail2(rowCFDI_ENC._43_RFC_Receptor) + ";" + taMailCFDI.ObtMail3(rowCFDI_ENC._43_RFC_Receptor) + ";" + taMailCFDI.ObtMail4(rowCFDI_ENC._43_RFC_Receptor)).ToString.Replace(";;", ";").Replace(";;;", ";")
                rowCFDI_ENC._167_RegimentFiscal = "601"
                rowCFDI_ENC._180_LugarExpedicion = "50070"
                rowCFDI_ENC._190_Metodo_Pago = ""
                rowCFDI_ENC._191_Efecto_Comprobante = "P"
                rowCFDI_ENC._192_Monto_TotalImp_Retenidos = 0
                rowCFDI_ENC._193_Monto_TotalImp_Trasladados = 0
                rowCFDI_ENC.Encabezado_Procesado = False
                taCFDI_ENC.ConsumeFolioFact()

                dsCFDI_ENC.CFDI_Encabezado.Rows.Add(rowCFDI_ENC)
                taCFDI_ENC.Update(dsCFDI_ENC.CFDI_Encabezado)

                'Inserta información en Tabla CFDI_Detalle
                Dim rowCFDI_DET As Production_AUXDataSet.CFDI_DetalleRow
                rowCFDI_DET = dsCFDI_DET.CFDI_Detalle.NewCFDI_DetalleRow()

                rowCFDI_DET._1_Linea_Descripcion = "Pago"
                rowCFDI_DET._2_Linea_Cantidad = 1
                rowCFDI_DET._3_Linea_Unidad = "ACT"
                rowCFDI_DET._4_Linea_PrecioUnitario = 0
                rowCFDI_DET._5_Linea_Importe = 0
                rowCFDI_DET._16_Linea_Cod_Articulo = "84111506"
                rowCFDI_DET.Detalle_Folio = rowCFDI_ENC._1_Folio
                rowCFDI_DET.Detalle_Serie = rowCFDI_ENC._27_Serie_Comprobante

                dsCFDI_DET.CFDI_Detalle.Rows.Add(rowCFDI_DET)
                taCFDI_DET.Update(dsCFDI_DET.CFDI_Detalle)

                'Inserta información en tabla CFDI_Complemento, sección Pagos

                Dim rowCFD_CPAGO As Production_AUXDataSet.CFDI_ComplementoPagoRow
                rowCFD_CPAGO = dsCFDI_CPAGO.CFDI_ComplementoPago.NewCFDI_ComplementoPagoRow()

                rowCFD_CPAGO._1_DetalleAux_Tipo = "CPG"
                rowCFD_CPAGO._2_DetalleAux_DescTipo = "Pagos"
                rowCFD_CPAGO._3_DetalleAux_Misc01 = "HD"
                rowCFD_CPAGO._4_DetalleAux_Misc02 = "1.0"
                rowCFD_CPAGO._5_DetalleAux_Misc03 = CDate(varFechaDePago).ToString("yyyy-MM-dd") + "T12:00:00"
                rowCFD_CPAGO._6_DetalleAux_Misc04 = varFormaDePago.Replace("Spei", "03")
                rowCFD_CPAGO._7_DetalleAux_Misc05 = varMoneda.Replace("PESO", "MXN")
                If rowCFD_CPAGO._7_DetalleAux_Misc05 = "USD" Then
                    rowCFD_CPAGO._8_DetalleAux_Misc06 = varTipoDeCambio
                Else
                    rowCFD_CPAGO._8_DetalleAux_Misc06 = ""
                End If
                rowCFD_CPAGO._9_DetalleAux_Misc07 = varMontoDePago
                rowCFD_CPAGO._10_DetalleAux_Misc08 = varReferencia
                rowCFD_CPAGO._11_DetalleAux_Misc09 = varRFCBancoOrdenante
                rowCFD_CPAGO._12_DetalleAux_Misc10 = validaNull(taCFDI_Bancos.ObtNomBanco(rowCFD_CPAGO._11_DetalleAux_Misc09))
                rowCFD_CPAGO._13_DetalleAux_Misc11 = ""
                rowCFD_CPAGO._18_DetalleAux_Misc16 = ""
                rowCFD_CPAGO._19_DetalleAux_Folio = rowCFDI_ENC._1_Folio
                rowCFD_CPAGO._20_DetalleAux_Serie = rowCFDI_ENC._27_Serie_Comprobante

                dsCFDI_CPAGO.CFDI_ComplementoPago.Rows.Add(rowCFD_CPAGO)
                taCFDI_CPAGO.Update(dsCFDI_CPAGO.CFDI_ComplementoPago)

                'Inserta información en tabla CFDI_Complemento, sección Pago

                rowCFD_CPAGO = dsCFDI_CPAGO.CFDI_ComplementoPago.NewCFDI_ComplementoPagoRow()

                rowCFD_CPAGO._1_DetalleAux_Tipo = "CPG"
                rowCFD_CPAGO._2_DetalleAux_DescTipo = "Pago"
                rowCFD_CPAGO._3_DetalleAux_Misc01 = "HD"
                rowCFD_CPAGO._4_DetalleAux_Misc02 = varCtaOrdenante
                rowCFD_CPAGO._5_DetalleAux_Misc03 = "BBA830831LJ2"
                rowCFD_CPAGO._6_DetalleAux_Misc04 = "0448250278"
                rowCFD_CPAGO._7_DetalleAux_Misc05 = "" '"TipoDeCadenaDepago"
                rowCFD_CPAGO._8_DetalleAux_Misc06 = "" '"CertificadoDePago"
                rowCFD_CPAGO._9_DetalleAux_Misc07 = "" '"CadenaDePago"
                rowCFD_CPAGO._10_DetalleAux_Misc08 = "" '"SelloDePago"
                rowCFD_CPAGO._11_DetalleAux_Misc09 = ""
                rowCFD_CPAGO._12_DetalleAux_Misc10 = ""
                rowCFD_CPAGO._13_DetalleAux_Misc11 = ""

                rowCFD_CPAGO._18_DetalleAux_Misc16 = ""
                rowCFD_CPAGO._19_DetalleAux_Folio = rowCFDI_ENC._1_Folio
                rowCFD_CPAGO._20_DetalleAux_Serie = rowCFDI_ENC._27_Serie_Comprobante

                dsCFDI_CPAGO.CFDI_ComplementoPago.Rows.Add(rowCFD_CPAGO)
                taCFDI_CPAGO.Update(dsCFDI_CPAGO.CFDI_ComplementoPago)

                pbTodos.Visible = True
                pbTodos.Value = 1
                pbTodos.Step = 1
                pbTodos.Maximum = dsComplemento.Vw_ChequesDetalle.Rows.Count + 1
                'Dim cont As Integer = 0
                For Each rowsD3 In dsComplemento.Vw_ChequesDetalle.Rows()
                    'cont += 1
                    Try
                        Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, rowsD3.Referencia.Insert(8, "-").Insert(13, "-"), rowsD3.RFC)
                        'Dim referencia() As String = rowsD3.Referencia.Split("/")
                        'Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, referencia(1), rowsD3.RFC)
                    Catch
                    End Try
                    Dim rowsD4 As ATEBCOFIDIRECDataSet.CFDProveedorRow
                    For Each rowsD4 In dsCOFIDI.CFDProveedor.Rows()

                        rowCFD_CPAGO = dsCFDI_CPAGO.CFDI_ComplementoPago.NewCFDI_ComplementoPagoRow()

                        rowCFD_CPAGO._1_DetalleAux_Tipo = "CPG"
                        rowCFD_CPAGO._2_DetalleAux_DescTipo = "DoctoRelacionado"
                        rowCFD_CPAGO._3_DetalleAux_Misc01 = "HD"
                        rowCFD_CPAGO._4_DetalleAux_Misc02 = rowsD4.UUID 'dgvUUIDRelacionados.Item("dgUUID", row.Index).Value
                        rowCFD_CPAGO._5_DetalleAux_Misc03 = rowsD4.Serie + "" 'dgvUUIDRelacionados.Item("dgSerie", row.Index).Value
                        rowCFD_CPAGO._6_DetalleAux_Misc04 = rowsD4.FolioFiscal + "" 'dgvUUIDRelacionados.Item("dgFolio", row.Index).Value
                        rowCFD_CPAGO._7_DetalleAux_Misc05 = validaNull(leeXML(rowsD4.CFDOriginal, "Moneda")) 'dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value

                        If rowCFD_CPAGO._7_DetalleAux_Misc05 = "MXN" Then
                            rowCFD_CPAGO._8_DetalleAux_Misc06 = ""
                        Else
                            rowCFD_CPAGO._8_DetalleAux_Misc06 = validaNull(leeXML(rowsD4.CFDOriginal, "TipoCambio"))
                        End If

                        rowCFD_CPAGO._9_DetalleAux_Misc07 = validaNull(leeXML(rowsD4.CFDOriginal, "MetodoPago"))

                        rowCFD_CPAGO._10_DetalleAux_Misc08 = taCFDI_CPAGO.ObtieneNoPago(rowCFD_CPAGO._4_DetalleAux_Misc02)

                        rowCFD_CPAGO._11_DetalleAux_Misc09 = validaNullSA(taCFDI_CPAGO.ObtieneSaldoAnterior(rowCFD_CPAGO._4_DetalleAux_Misc02), rowsD3.Importe)
                        rowCFD_CPAGO._12_DetalleAux_Misc10 = rowsD3.Importe
                        rowCFD_CPAGO._13_DetalleAux_Misc11 = CDec(rowCFD_CPAGO._11_DetalleAux_Misc09 - rowsD3.Importe)

                        rowCFD_CPAGO._18_DetalleAux_Misc16 = ""
                        rowCFD_CPAGO._19_DetalleAux_Folio = rowCFDI_ENC._1_Folio
                        rowCFD_CPAGO._20_DetalleAux_Serie = rowCFDI_ENC._27_Serie_Comprobante

                        dsCFDI_CPAGO.CFDI_ComplementoPago.Rows.Add(rowCFD_CPAGO)
                        taCFDI_CPAGO.Update(dsCFDI_CPAGO.CFDI_ComplementoPago)

                    Next
                    pbTodos.Value += 1
                    pbTodos.Visible = False
                Next
                taConsecutivo.ActAProcesado(rowCFDI_ENC._27_Serie_Comprobante, rowCFDI_ENC._1_Folio, varCheque, rowCFDI_ENC._43_RFC_Receptor)
            End If
        Next
        MsgBox("CFDI's con complemento de recepción de pagos generados correctamente...", MsgBoxStyle.Information, "Complementos de recepción de pagos")
        btnTimbrar.Enabled = False
        Me.taCFDI_CompConsFactoraje.NProcFillBy(Me.dsProduction.CFDI_CompConsFactoraje)

        Me.taCFDI_CompConsFactoraje.NProcXRFC_FillBy(Me.dsProduction.CFDI_CompConsFactoraje, cmbRFC.Text)
        For i = 0 To dgvComplementos.Rows.Count - 1
            Me.dgvComplementos.Item("dgDocRelacionado", i).Value = "UUID's Rel"
        Next

    End Sub
    Public Function validaNullSA(valor As Object, imp As Decimal)
        If String.IsNullOrEmpty(valor) Then
            Return 0.00 + imp
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Private Sub btnMails_Click(sender As Object, e As EventArgs) Handles btnMails.Click
        frmMails.Show()
    End Sub

    Private Sub btnCuentas_Click(sender As Object, e As EventArgs) Handles btnCuentas.Click
        frmCuentas.Show()
    End Sub
End Class
