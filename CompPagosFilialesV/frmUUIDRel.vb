Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml
Public Class frmUUIDRel
    Dim totalPago As Double = 0
    Dim taCOFIDI As New ATEBCOFIDIRECDataSetTableAdapters.vw_GPO_FINAGILTableAdapter
    Dim dsCOFIDI As New ATEBCOFIDIRECDataSet

    Dim taCFDI_ENC As New Production_AUXDataSetTableAdapters.CFDI_EncabezadoTableAdapter
    Dim dsCFDI_ENC As New Production_AUXDataSet

    Dim taCFDI_Cuentas As New Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter
    Dim dsCFDI_Cuentas As New Production_AUXDataSet

    Dim taCFDI_DET As New Production_AUXDataSetTableAdapters.CFDI_DetalleTableAdapter
    Dim dsCFDI_DET As New Production_AUXDataSet

    Dim taCFDI_CPAGO As New Production_AUXDataSetTableAdapters.CFDI_ComplementoPagoTableAdapter
    Dim dsCFDI_CPAGO As New Production_AUXDataSet

    Dim taCFDI_Bancos As New Production_AUXDataSetTableAdapters.CFDI_BancosTableAdapter
    Dim dsCFDI_Bancos As New Production_AUXDataSet

    Dim taConsecutivo As New Production_AUXDataSetTableAdapters.CFDI_CompConsFactorajeTableAdapter
    Dim dsConsecutivo As New Production_AUXDataSet

    Dim taWeb_Finagil As New WEB_FinagilDataSetTableAdapters.WEB_FacturasXMLTableAdapter
    Dim dsWeb_Finagil As New WEB_FinagilDataSet

    Dim taMailCFDI As New Production_AUXDataSetTableAdapters.CFDI_MailTableAdapter
    Dim dsMailCFDI As New Production_AUXDataSet
    Private Sub frmUUIDRel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Factor100DataSet.Vw_ChequesDetalle' Puede moverla o quitarla según sea necesario.

        Me.taVw_ChequesDetalle.Fill(Me.dsFactor100.Vw_ChequesDetalle)

        If frmPrincipal.RFCTextBox.Text = "FGM790801SD7" Or frmPrincipal.RFCTextBox.Text = "PCO880928RD1" Or frmPrincipal.RFCTextBox.Text = "PPL8012295V2" Or frmPrincipal.RFCTextBox.Text = "MSU850911A56" Or frmPrincipal.RFCTextBox.Text = "PAM781201CW0" Or frmPrincipal.RFCTextBox.Text = "HPI880624SW5" Then
            Me.taVw_ChequesDetalle.DocRela_FillBy(Me.dsFactor100.Vw_ChequesDetalle, frmPrincipal.RFCTextBox.Text, frmPrincipal.ChequeTextBox.Text)
            'MsgBox(dgvUUIDRelacionados.Rows.Count.ToString)
            frmPrincipal.tspRegistrosPrincipal.Maximum = dgvUUIDRelacionados.Rows.Count
            Dim contador As Integer = 0
            For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
                frmPrincipal.tspRegistrosPrincipal.Value = contador
                Try
                    If row.Cells(3).Value.ToString.Length = 15 Then
                        Me.taCOFIDI.Fill(Me.dsCOFIDI.vw_GPO_FINAGIL, row.Cells(3).Value.Insert(8, "-").Insert(13, "-"), row.Cells(1).Value)
                    Else
                        Me.taCOFIDI.Fill(Me.dsCOFIDI.vw_GPO_FINAGIL, row.Cells(3).Value.ToString.Substring(0, 8), row.Cells(1).Value)
                    End If
                Catch

                End Try
                Dim rowUUID As ATEBCOFIDIRECDataSet.vw_GPO_FINAGILRow
                If dsCOFIDI.vw_GPO_FINAGIL.Rows.Count = 1 Then
                    For Each rowUUID In dsCOFIDI.vw_GPO_FINAGIL.Rows()
                        Me.dgvUUIDRelacionados.Item("dgUUID", row.Index).Value = rowUUID.UUID
                        Me.dgvUUIDRelacionados.Item("dgMPago", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "MetodoPago"))
                        Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "Moneda"))
                        Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "TipoCambio"))
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "Total"))
                        Me.dgvUUIDRelacionados.Item("dgSerie", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "Serie"))
                        Me.dgvUUIDRelacionados.Item("dgFolio", row.Index).Value = validaNull(leeXML(rowUUID.CFDOriginal, "Folio"))
                        Me.dgvUUIDRelacionados.Item("dgSaldo", row.Index).Value = taCFDI_CPAGO.ObtieneSaldoAnterior(rowUUID.UUID)
                        Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        If (Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) >= -1.0 Or Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) < 0) And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                            Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        End If
                        If CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) = CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Green
                        Else

                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = True
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                            Me.dgvUUIDRelacionados.Item("dgTC", row.Index).ReadOnly = False
                        End If
                    Next
                    If Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value.ToString = "" Then
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = False
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                    End If
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count > 1 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Pink
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = "-- " + dsCOFIDI.vw_GPO_FINAGIL.Rows.Count.ToString + " --"
                    varBanderaUUID = True
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count = 0 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Purple
                End If
                If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                    'totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
                Else
                    'totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))
                    lblSugerencia.Text = (Val(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) / Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)).ToString("#,###.#00000")
                End If
                contador += 1
                frmPrincipal.tslRegistrosPrincipal.Text = contador.ToString & " de " & dgvUUIDRelacionados.Rows.Count.ToString
                frmPrincipal.Update()
            Next
            frmPrincipal.tslRegistrosPrincipal.Text = ""
            frmPrincipal.tspRegistrosPrincipal.Value = 0
        ElseIf frmPrincipal.RFCTextBox.Text = "DME061031H27" Or frmPrincipal.RFCTextBox.Text = "DIM061230LN8" Or frmPrincipal.RFCTextBox.Text = "DME061031H27" Then
            Me.taVw_ChequesDetalle.DocRela_FillBy(Me.dsFactor100.Vw_ChequesDetalle, frmPrincipal.RFCTextBox.Text, frmPrincipal.ChequeTextBox.Text)
            For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
                Dim SF() As String = regresaSF(row.Cells(3).Value)
                Try
                    'Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, row.Cells(3).Value.Insert(8, "-").Insert(13, "-"), row.Cells(1).Value)
                    'Me.taWeb_Finagil.Obt_CFDI_FillBy(Me.dsWeb_Finagil.WEB_FacturasXML, SF(0), SF(1))
                    Me.taWeb_Finagil.Obt_CFDI_SoloFolio_FillBy(Me.dsWeb_Finagil.WEB_FacturasXML, SF(1), frmPrincipal.RFCTextBox.Text)
                Catch

                End Try
                Dim rowUUID As WEB_FinagilDataSet.WEB_FacturasXMLRow
                If dsWeb_Finagil.WEB_FacturasXML.Rows.Count = 1 Then
                    For Each rowUUID In dsWeb_Finagil.WEB_FacturasXML.Rows()
                        Me.dgvUUIDRelacionados.Item("dgUUID", row.Index).Value = rowUUID.UUID
                        Me.dgvUUIDRelacionados.Item("dgMPago", row.Index).Value = rowUUID.MPago
                        Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = rowUUID.Moneda
                        Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = rowUUID.TCambio.ToString.Replace("0.000000", "")
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = rowUUID.ImporteFactura
                        Me.dgvUUIDRelacionados.Item("dgSerie", row.Index).Value = SF(0)
                        Me.dgvUUIDRelacionados.Item("dgFolio", row.Index).Value = SF(1)
                        Me.dgvUUIDRelacionados.Item("dgSaldo", row.Index).Value = taCFDI_CPAGO.ObtieneSaldoAnterior(rowUUID.UUID) - Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                        Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        If (Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) >= -1.0 And Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) < 0) And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                            Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        End If
                        If (Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) = CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Green
                        Else
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = True
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                            Me.dgvUUIDRelacionados.Item("dgTC", row.Index).ReadOnly = False
                        End If
                    Next
                    If Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value.ToString = "" Then
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = False
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                    End If
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count > 1 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Pink
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = "-- " + dsWeb_Finagil.WEB_FacturasXML.Rows.Count.ToString + " --"
                    varBanderaUUID = True
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count = 0 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Purple
                End If
                If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                    'totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
                Else
                    'totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))
                    lblSugerencia.Text = (Val(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) / Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)).ToString("#,###.#00000")
                End If
            Next
        Else
            Me.taVw_ChequesDetalle.DocRela_FillBy(Me.dsFactor100.Vw_ChequesDetalle, frmPrincipal.RFCTextBox.Text, frmPrincipal.ChequeTextBox.Text)
            For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
                Dim SF() As String = regresaSF(row.Cells(3).Value)
                Try
                    'Me.taCOFIDI.FillBy(Me.dsCOFIDI.CFDProveedor, row.Cells(3).Value.Insert(8, "-").Insert(13, "-"), row.Cells(1).Value)
                    Me.taWeb_Finagil.Obt_CFDI_FillBy(Me.dsWeb_Finagil.WEB_FacturasXML, SF(0), SF(1))

                Catch

                End Try
                Dim rowUUID As WEB_FinagilDataSet.WEB_FacturasXMLRow
                If dsWeb_Finagil.WEB_FacturasXML.Rows.Count = 1 Then
                    For Each rowUUID In dsWeb_Finagil.WEB_FacturasXML.Rows()
                        Me.dgvUUIDRelacionados.Item("dgUUID", row.Index).Value = rowUUID.UUID
                        Me.dgvUUIDRelacionados.Item("dgMPago", row.Index).Value = rowUUID.MPago
                        Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = rowUUID.Moneda
                        Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = rowUUID.TCambio.ToString.Replace("0.000000", "")
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = rowUUID.ImporteFactura
                        Me.dgvUUIDRelacionados.Item("dgSerie", row.Index).Value = SF(0)
                        Me.dgvUUIDRelacionados.Item("dgFolio", row.Index).Value = SF(1)
                        Me.dgvUUIDRelacionados.Item("dgSaldo", row.Index).Value = taCFDI_CPAGO.ObtieneSaldoAnterior(rowUUID.UUID)
                        Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        If (Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) >= -1.0 Or Val(Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) < 0) And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                            Me.dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value = (CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) - CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)).ToString("#,###.#0")
                        End If
                        If (Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) = CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) Then
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Green
                        Else
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = True
                            Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                            Me.dgvUUIDRelacionados.Item("dgTC", row.Index).ReadOnly = False
                        End If
                    Next
                    If Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value.ToString = "" Then
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = False
                        Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                    End If
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count > 1 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Pink
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = "-- " + dsWeb_Finagil.WEB_FacturasXML.Rows.Count.ToString + " --"
                    varBanderaUUID = True
                ElseIf dsCOFIDI.vw_GPO_FINAGIL.Rows.Count = 0 Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Purple
                End If
                If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                    'totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
                Else
                    'totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))
                    lblSugerencia.Text = (Val(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) / Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)).ToString("#,###.#00000")
                End If
            Next
        End If
        actualizar_sin()
        Dim varPago As Double = CDbl(frmPrincipal.MontoTextBox.Text)
        Me.tslblPago.Text = varPago.ToString("$#,###.#0")
        Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
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
        If retorno(0) = Nothing Then
            retorno(0) = ""
        End If
        Return retorno
    End Function

    Public Function leeXML(docXML As String, nodo As String)
        Dim doc As XmlDataDocument
        doc = New XmlDataDocument
        doc.LoadXml(docXML)
        Dim CFDI As XmlNode
        Dim retorno As String = ""

        CFDI = doc.DocumentElement
        If nodo <> "UUID" Then
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
        Else
            For Each Comprobante As XmlNode In CFDI.ChildNodes
                For Each Complemento As XmlNode In Comprobante
                    If Complemento.Name = "cfdi:Complemento" Then
                        For Each atributos As XmlNode In Complemento
                            If atributos.Name = "UUID" Then
                                retorno = atributos.Value.ToString
                                Return retorno
                                Exit Function
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Function

    Public Function validaNull(valor As Object)
        If String.IsNullOrEmpty(valor) Then
            Return ""
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function
    Public Function validaNullN(valor As Object)
        If valor.ToString = "" Then
            Return 0
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Public Function validaNullSA(valor As Object, imp As Decimal)
        If String.IsNullOrEmpty(valor) Then
            Return 0.00 + imp
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Private Sub dgvUUIDRelacionados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUUIDRelacionados.CellContentClick
        Try
            If e.ColumnIndex = 11 And dgvUUIDRelacionados.Item("dgUUID", e.RowIndex).Value <> "" Then
                'If dgvUUIDRelacionados.Item("dgUUID", e.RowIndex).Value <> "" Then
                ts1.Text = dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", e.RowIndex).Value
                ts2.Text = dgvUUIDRelacionados.Item("ReferenciaDataGridViewTextBoxColumn", e.RowIndex).Value
                ts3.Text = e.ColumnIndex
                ts4.Text = e.RowIndex
                frmUUIDRelC.Show()
            Else
                ts1.Text = dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", e.RowIndex).Value
                ts2.Text = (dgvUUIDRelacionados.Item("ReferenciaDataGridViewTextBoxColumn", e.RowIndex).Value).ToString.Substring(0, 8)
                ts3.Text = e.ColumnIndex
                ts4.Text = e.RowIndex
                frmUUIDRelC.Show()
            End If

        Catch
        End Try
    End Sub

    Private Sub btnGComplemento_Click(sender As Object, e As EventArgs) Handles btnGComplemento.Click

        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                If IsNumeric(dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) Then
                    If Val(dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) = 0 Or Val(dgvUUIDRelacionados.Item("dgDiferencia", row.Index).Value) > 0 Then
                    Else
                        MsgBox("El importe de los documentos debe de ser númerico y menor o igual a cero, el comprobante no será emitido...")
                        Exit Sub
                    End If
                Else
                    MsgBox("Uno de los registros no tiene valores, el comprobante no será emitido...")
                    Exit Sub
                End If
            End If
        Next

        If CDec(tslblPago.Text) = CDec(tslblSumaUUID.Text) Then

            'Inserta información en Tabla CFDI_Encabezado
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
            rowCFDI_ENC._30_Fecha = Date.Now.ToString("yyyy/MM/dd")
            rowCFDI_ENC._31_Hora = Date.Now.ToString("hh:mm:ss")
            rowCFDI_ENC._41_Dom_LugarExpide_codigoPostal = "50070"
            rowCFDI_ENC._42_Nombre_Receptor = dgvUUIDRelacionados.Item("ClienteDataGridViewTextBoxColumn", 0).Value
            rowCFDI_ENC._43_RFC_Receptor = dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", 0).Value
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
            rowCFD_CPAGO._5_DetalleAux_Misc03 = CDate(varFechaDePago).ToString("yyyy/MM/dd") + "T12:00:00"
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

            'Documentos relacionados
            For Each row As DataGridViewRow In dgvUUIDRelacionados.Rows
                rowCFD_CPAGO = dsCFDI_CPAGO.CFDI_ComplementoPago.NewCFDI_ComplementoPagoRow()

                rowCFD_CPAGO._1_DetalleAux_Tipo = "CPG"
                rowCFD_CPAGO._2_DetalleAux_DescTipo = "DoctoRelacionado"
                rowCFD_CPAGO._3_DetalleAux_Misc01 = "HD"
                rowCFD_CPAGO._4_DetalleAux_Misc02 = dgvUUIDRelacionados.Item("dgUUID", row.Index).Value
                rowCFD_CPAGO._5_DetalleAux_Misc03 = dgvUUIDRelacionados.Item("dgSerie", row.Index).Value + ""
                rowCFD_CPAGO._6_DetalleAux_Misc04 = SoloNumeros(dgvUUIDRelacionados.Item("dgFolio", row.Index).Value + "")
                rowCFD_CPAGO._7_DetalleAux_Misc05 = dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value
                If rowCFD_CPAGO._7_DetalleAux_Misc05 = "MXN" Then
                    rowCFD_CPAGO._8_DetalleAux_Misc06 = ""
                Else
                    rowCFD_CPAGO._8_DetalleAux_Misc06 = dgvUUIDRelacionados.Item("dgTC", row.Index).Value
                End If

                rowCFD_CPAGO._9_DetalleAux_Misc07 = dgvUUIDRelacionados.Item("dgMPago", row.Index).Value

                rowCFD_CPAGO._10_DetalleAux_Misc08 = taCFDI_CPAGO.ObtieneNoPago(rowCFD_CPAGO._4_DetalleAux_Misc02)

                If rowCFD_CPAGO._7_DetalleAux_Misc05 = "MXN" Then
                    rowCFD_CPAGO._11_DetalleAux_Misc09 = validaNullSA(taCFDI_CPAGO.ObtieneSaldoAnterior(rowCFD_CPAGO._4_DetalleAux_Misc02), CDec(dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value))
                    rowCFD_CPAGO._12_DetalleAux_Misc10 = dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                    rowCFD_CPAGO._13_DetalleAux_Misc11 = CDec(rowCFD_CPAGO._11_DetalleAux_Misc09) - CDec(dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)
                Else
                    rowCFD_CPAGO._11_DetalleAux_Misc09 = validaNullSA(taCFDI_CPAGO.ObtieneSaldoAnterior(rowCFD_CPAGO._4_DetalleAux_Misc02), CDec(dgvUUIDRelacionados.Item("dgMonto", row.Index).Value))
                    rowCFD_CPAGO._12_DetalleAux_Misc10 = dgvUUIDRelacionados.Item("dgMonto", row.Index).Value
                    rowCFD_CPAGO._13_DetalleAux_Misc11 = CDec(rowCFD_CPAGO._11_DetalleAux_Misc09) - CDec(dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
                End If

                rowCFD_CPAGO._18_DetalleAux_Misc16 = ""
                rowCFD_CPAGO._19_DetalleAux_Folio = rowCFDI_ENC._1_Folio
                rowCFD_CPAGO._20_DetalleAux_Serie = rowCFDI_ENC._27_Serie_Comprobante

                dsCFDI_CPAGO.CFDI_ComplementoPago.Rows.Add(rowCFD_CPAGO)
                taCFDI_CPAGO.Update(dsCFDI_CPAGO.CFDI_ComplementoPago)

            Next
            taConsecutivo.ActAProcesado(rowCFDI_ENC._27_Serie_Comprobante, rowCFDI_ENC._1_Folio, varCheque, dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", 0).Value)
            MsgBox("CFDI con complemento de recepción de pagos generado correctamente...", MsgBoxStyle.Information, "Complementos de recepción de pagos")
            frmPrincipal.taCFDI_CompConsFactoraje.NProcFillBy(frmPrincipal.dsProduction.CFDI_CompConsFactoraje)
            Me.Close()
        Else
            Dim msgResultado As MsgBoxResult = MsgBox("El importe del pago vs los documentos originales es diferente. ¿Deseas continuar?", MsgBoxStyle.YesNo)

            If msgResultado = MsgBoxResult.Yes Then
                'Inserta información en Tabla CFDI_Encabezado
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
                rowCFDI_ENC._30_Fecha = Date.Now.ToString("dd/MM/yyyy")
                rowCFDI_ENC._31_Hora = Date.Now.ToString("hh:mm:ss")
                rowCFDI_ENC._41_Dom_LugarExpide_codigoPostal = "50070"
                rowCFDI_ENC._42_Nombre_Receptor = dgvUUIDRelacionados.Item("ClienteDataGridViewTextBoxColumn", 0).Value
                rowCFDI_ENC._43_RFC_Receptor = dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", 0).Value
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
                rowCFDI_ENC._162_Misc50 = ""
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
                rowCFD_CPAGO._5_DetalleAux_Misc03 = varFechaDePago + "T12:00:00"
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

                'Documentos relacionados
                For Each row As DataGridViewRow In dgvUUIDRelacionados.Rows
                    rowCFD_CPAGO = dsCFDI_CPAGO.CFDI_ComplementoPago.NewCFDI_ComplementoPagoRow()

                    rowCFD_CPAGO._1_DetalleAux_Tipo = "CPG"
                    rowCFD_CPAGO._2_DetalleAux_DescTipo = "DoctoRelacionado"
                    rowCFD_CPAGO._3_DetalleAux_Misc01 = "HD"
                    rowCFD_CPAGO._4_DetalleAux_Misc02 = dgvUUIDRelacionados.Item("dgUUID", row.Index).Value
                    rowCFD_CPAGO._5_DetalleAux_Misc03 = dgvUUIDRelacionados.Item("dgSerie", row.Index).Value
                    rowCFD_CPAGO._6_DetalleAux_Misc04 = SoloNumeros(dgvUUIDRelacionados.Item("dgFolio", row.Index).Value)
                    rowCFD_CPAGO._7_DetalleAux_Misc05 = dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value
                    If rowCFD_CPAGO._7_DetalleAux_Misc05 = "MXN" Then
                        rowCFD_CPAGO._8_DetalleAux_Misc06 = ""
                    Else
                        rowCFD_CPAGO._8_DetalleAux_Misc06 = dgvUUIDRelacionados.Item("dgTC", row.Index).Value
                    End If

                    rowCFD_CPAGO._9_DetalleAux_Misc07 = dgvUUIDRelacionados.Item("dgMPago", row.Index).Value

                    rowCFD_CPAGO._10_DetalleAux_Misc08 = taCFDI_CPAGO.ObtieneNoPago(rowCFD_CPAGO._4_DetalleAux_Misc02)

                    If rowCFD_CPAGO._7_DetalleAux_Misc05 = "MXN" Then
                        rowCFD_CPAGO._11_DetalleAux_Misc09 = validaNullSA(taCFDI_CPAGO.ObtieneSaldoAnterior(rowCFD_CPAGO._4_DetalleAux_Misc02), CDec(dgvUUIDRelacionados.Item("dgMonto", row.Index).Value))
                        rowCFD_CPAGO._12_DetalleAux_Misc10 = dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value
                        rowCFD_CPAGO._13_DetalleAux_Misc11 = CDec(rowCFD_CPAGO._11_DetalleAux_Misc09) - CDec(dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value)
                    Else
                        rowCFD_CPAGO._11_DetalleAux_Misc09 = validaNullSA(taCFDI_CPAGO.ObtieneSaldoAnterior(rowCFD_CPAGO._4_DetalleAux_Misc02), CDec(dgvUUIDRelacionados.Item("dgMonto", row.Index).Value))
                        rowCFD_CPAGO._12_DetalleAux_Misc10 = dgvUUIDRelacionados.Item("dgMonto", row.Index).Value
                        rowCFD_CPAGO._13_DetalleAux_Misc11 = CDec(rowCFD_CPAGO._11_DetalleAux_Misc09) - CDec(dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
                    End If

                    rowCFD_CPAGO._18_DetalleAux_Misc16 = ""
                    rowCFD_CPAGO._19_DetalleAux_Folio = rowCFDI_ENC._1_Folio
                    rowCFD_CPAGO._20_DetalleAux_Serie = rowCFDI_ENC._27_Serie_Comprobante

                    dsCFDI_CPAGO.CFDI_ComplementoPago.Rows.Add(rowCFD_CPAGO)
                    taCFDI_CPAGO.Update(dsCFDI_CPAGO.CFDI_ComplementoPago)

                Next
                taConsecutivo.ActAProcesado(rowCFDI_ENC._27_Serie_Comprobante, rowCFDI_ENC._1_Folio, varCheque, dgvUUIDRelacionados.Item("RFCDataGridViewTextBoxColumn", 0).Value)
                MsgBox("CFDI con complemento de recepción de pagos generado correctamente...", MsgBoxStyle.Information, "Complementos de recepción de pagos")
                frmPrincipal.taCFDI_CompConsFactoraje.NProcFillBy(frmPrincipal.dsProduction.CFDI_CompConsFactoraje)
                Me.Close()
            ElseIf msgResultado = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
    End Sub


    'Private Sub dgvUUIDRelacionados_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUUIDRelacionados.CellValueChanged
    '    For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
    '        Try
    '            If CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) = CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) Then
    '                Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Green
    '            Else
    '                Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = True
    '                Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
    '            End If
    '        Catch
    '        End Try
    '    Next
    '    actualizar_sin()
    'End Sub

    Private Sub dgvUUIDRelacionados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUUIDRelacionados.CellEndEdit
        Try
            Me.dgvUUIDRelacionados.Item("dgMonto", e.RowIndex).Value = CDec(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", e.RowIndex).Value) / CDec(Me.dgvUUIDRelacionados.Item("dgTC", e.RowIndex).Value)
        Catch ex As Exception
            MsgBox(e.ToString, MsgBoxStyle.Exclamation)
        End Try
        'totalPago = 0
        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            'If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
            '   totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
            'Else
            '   totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))
            'End If
            Try
                If CDbl(validaNullN(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)) = CDbl(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) Then
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Green
                Else
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).ReadOnly = True
                    Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Style.BackColor = Color.Red
                End If
            Catch
            End Try
        Next
        'Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
        actualizar_sin()
    End Sub

    Private Sub btnSugerencia_Click(sender As Object, e As EventArgs) Handles btnSugerencia.Click
        'totalPago = 0
        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                'totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
            ElseIf Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "MXN" And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "" Then
                Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = Math.Round((Val(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) / Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)), 6)
                'Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value = Val(Me.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", row.Index).Value) / Val(lblSugerencia.Text)
                'totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))
            End If
        Next
        'Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
        actualizar_tipo_de_cambio()
    End Sub

    Private Sub actualizar_sin()
        totalPago = 0
        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
            ElseIf Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "MXN" And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "" Then
                'Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = lblSugerencia.Text
                totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))

            End If
        Next
        Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
    End Sub

    Private Sub actualizar()
        totalPago = 0
        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value = "MXN" Then
                totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
            ElseIf Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "MXN" And Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "" Then
                Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value = lblSugerencia.Text
                totalPago += (Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value))

            End If
        Next
        Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
    End Sub

    Private Sub actualizar_tipo_de_cambio()
        totalPago = 0
        For Each row As DataGridViewRow In Me.dgvUUIDRelacionados.Rows
            If Me.dgvUUIDRelacionados.Item("dgMoneda", row.Index).Value <> "MXN" Then
                totalPago += Math.Round((Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value) * Val(Me.dgvUUIDRelacionados.Item("dgTC", row.Index).Value)), 2)
            Else
                totalPago += Val(Me.dgvUUIDRelacionados.Item("dgMonto", row.Index).Value)
            End If
        Next
        Me.tslblSumaUUID.Text = totalPago.ToString("$#,###.#0")
    End Sub
    Public Function leeXMLF(docXML As String, nodo As String)
        Dim doc As XmlDataDocument
        doc = New XmlDataDocument
        doc.Load(docXML)
        Dim CFDI As XmlNode
        Dim retorno As String = ""

        CFDI = doc.DocumentElement
        If nodo <> "UUID" Then
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
        Else
            For Each Comprobante As XmlNode In CFDI.ChildNodes
                For Each Complemento As XmlNode In Comprobante
                    If Complemento.Name = "tfd:TimbreFiscalDigital" Then
                        For Each atributos As XmlNode In Complemento.Attributes
                            If atributos.Name = "UUID" Then
                                retorno = atributos.Value.ToString
                                Return retorno
                                Exit Function
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Function

    Public Function SoloNumeros(ByVal strCadena As String) As Long
        Dim i As Integer
        For i = 1 To Len(strCadena)
            If Mid$(strCadena, i, 1) Like "#" Then _
            SoloNumeros = CLng(SoloNumeros & Mid$(strCadena, i, 1))
        Next i
        If SoloNumeros.ToString.Length <> 0 And SoloNumeros.ToString.Length > 8 Then
            SoloNumeros = CLng(SoloNumeros.ToString.Substring(0, 8))
        End If
        Return SoloNumeros
    End Function
End Class