Public Class frmCuentas


    Private Sub frmCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Production_AUXDataSet.CFDI_Bancos' Puede moverla o quitarla según sea necesario.
        Me.CFDI_BancosTableAdapter.Fill(Me.Production_AUXDataSet.CFDI_Bancos)
        'TODO: esta línea de código carga datos en la tabla 'Production_AUXDataSet.CFDI_CuentasClientes' Puede moverla o quitarla según sea necesario.
        Me.CFDI_CuentasClientesTableAdapter.Fill(Me.Production_AUXDataSet.CFDI_CuentasClientes)
        Me.CFDI_CuentasClientesTableAdapter.ObtDatosCuentasFillBy(Me.Production_AUXDataSet.CFDI_CuentasClientes, frmPrincipal.RFCTextBox.Text)

    End Sub

    Private Sub ComboBox1_SelectedChanged(sender As Object, e As EventArgs) Handles cmbRFCCliente.SelectedIndexChanged
        Try
            'Me.CFDI_CuentasClientesTableAdapter.ObtDatosCuentasFillBy(Me.Production_AUXDataSet.CFDI_CuentasClientes, cmbRFCCliente.Text)
            If RFC_ClienteTextBox.Text = cmbRFCCliente.Text Then
                btnNuevo.Enabled = False
                btnActualizar.Enabled = True
            Else
                btnActualizar.Enabled = False
                btnNuevo.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Error..." + vbNewLine + ex.ToString)
        End Try
    End Sub

    Private Sub RFC_ClienteTextBox_TextChanged(sender As Object, e As EventArgs) Handles RFC_ClienteTextBox.TextChanged
        If RFC_ClienteTextBox.Text <> "" Then
            cmbRFCCliente.Text = RFC_ClienteTextBox.Text
        End If
        If RFC_BancoTextBox.Text <> "" Then
            cmbRFCBanco.Text = RFC_BancoTextBox.Text
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Me.CFDI_CuentasClientesBindingSource.EndEdit()
            Me.CFDI_CuentasClientesTableAdapter.Update(Me.Production_AUXDataSet.CFDI_CuentasClientes)
            Me.Production_AUXDataSet.GetChanges()
            MsgBox("Actualización exitosa...")
        Catch ex As Exception
            MsgBox("Error al actualizar registro..." + vbNewLine(2), ex.ToString)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            CFDI_CuentasClientesTableAdapter.Insert(cmbRFCCliente.Text, cmbRFCBanco.Text, NoCuentaTextBox.Text, "", "", "")
            MsgBox("Actualización exitosa...")
        Catch ex As Exception
            MsgBox("Error al insertar nuevo registro..." + vbNewLine(2), ex.ToString)
        End Try
    End Sub
End Class