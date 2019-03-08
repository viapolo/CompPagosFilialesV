Imports System.Xml
Public Class frmUUIDRelC
    Private Sub CFDProveedorBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.VwGPOFINAGILBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ATEBCOFIDIRECDataSet)

    End Sub

    Private Sub frmUUIDRelC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmUUIDRel.ts2.Text.Length <= 8 And varBanderaUUID = True Then
            Try
                Me.Vw_GPO_FINAGILTableAdapter.Fill(Me.ATEBCOFIDIRECDataSet.vw_GPO_FINAGIL, frmUUIDRel.ts2.Text.ToString, frmUUIDRel.ts1.Text)
            Catch
            End Try
        Else
            Try
                Me.Vw_GPO_FINAGILTableAdapter.Fill(Me.ATEBCOFIDIRECDataSet.vw_GPO_FINAGIL, frmUUIDRel.ts2.Text.ToString.Insert(8, "-").Insert(13, "-"), frmUUIDRel.ts1.Text)
            Catch
            End Try
        End If

        If CFDProveedorDataGridView.Rows.Count = 1 And CFDProveedorDataGridView.Item("DataGridViewTextBoxColumn28", 0).Value = Nothing And varBanderaUUID = False Then
            Dim fUUID As String = InputBox("Ingrese folio fiscal del comprobante a relacionar: ").ToString
            If fUUID.Length = 36 Then
                fUUID = fUUID.Substring(0, 16).Replace("-", "")
                frmUUIDRel.dgvUUIDRelacionados.Item(3, CInt(frmUUIDRel.ts4.Text)).Value = fUUID
                frmUUIDRel.ts2.Text = fUUID

                varBanderaUUID = True
                Me.Close()
            Else
                MsgBox("El UUID del comprobante no cumple con el patron correspondiente")
                Me.Close()
            End If
        End If

    End Sub

    Public Function validaNullN(valor As Object)
        If valor.ToString = "" Then
            Return 0
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Private Sub CFDProveedorDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles CFDProveedorDataGridView.CellClick
        Try
            varBanderaUUID = False
            'Folio fiscal
            frmUUIDRel.dgvUUIDRelacionados.Item(5, CInt(frmUUIDRel.ts4.Text)).Value = CFDProveedorDataGridView.Item("DataGridViewTextBoxColumn28", e.RowIndex).Value
            'MPago
            frmUUIDRel.dgvUUIDRelacionados.Item(8, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "MetodoPago")
            'Moneda
            frmUUIDRel.dgvUUIDRelacionados.Item(9, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "Moneda")
            'TCambio
            frmUUIDRel.dgvUUIDRelacionados.Item(10, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "TipoCambio")
            'Monto
            frmUUIDRel.dgvUUIDRelacionados.Item(11, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "Total")
            'TCambio
            frmUUIDRel.dgvUUIDRelacionados.Item(6, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "Serie")
            'Monto
            frmUUIDRel.dgvUUIDRelacionados.Item(7, CInt(frmUUIDRel.ts4.Text)).Value = leeXML(validaNull(CFDProveedorDataGridView.Item("XMLSAT", e.RowIndex).Value), "Folio")

            frmUUIDRel.dgvUUIDRelacionados.Item(13, CInt(frmUUIDRel.ts4.Text)).Value = (CDbl(frmUUIDRel.dgvUUIDRelacionados.Item(11, CInt(frmUUIDRel.ts4.Text)).Value)) - CDbl(CDbl(frmUUIDRel.dgvUUIDRelacionados.Item(4, CInt(frmUUIDRel.ts4.Text)).Value)).ToString("#,###.#0")
            If Val(frmUUIDRel.dgvUUIDRelacionados.Item("dgDiferencia", e.RowIndex).Value) = -0.01 And frmUUIDRel.dgvUUIDRelacionados.Item("dgMoneda", e.RowIndex).Value = "MXN" Then
                frmUUIDRel.dgvUUIDRelacionados.Item("dgMonto", e.RowIndex).Value = frmUUIDRel.dgvUUIDRelacionados.Item("ImporteDataGridViewTextBoxColumn", e.RowIndex).Value
                frmUUIDRel.dgvUUIDRelacionados.Item(13, CInt(frmUUIDRel.ts4.Text)).Value = (CDbl(frmUUIDRel.dgvUUIDRelacionados.Item(11, CInt(frmUUIDRel.ts4.Text)).Value)) - CDbl(CDbl(frmUUIDRel.dgvUUIDRelacionados.Item(4, CInt(frmUUIDRel.ts4.Text)).Value)).ToString("#,###.#0")
            End If
        Catch
        End Try
        frmUUIDRel.Refresh()
        Me.Close()
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
    Public Function validaNull(valor As String)
        If valor = "" Then
            Return ""
            Exit Function
        Else
            Return valor
            Exit Function
        End If
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub CFDProveedorDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CFDProveedorDataGridView.CellContentClick

    End Sub
End Class