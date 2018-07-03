Public Class frmMails
    Private Sub frmMails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CFDI_MailTableAdapter.ObtMails(Me.Production_AUXDataSet.CFDI_Mail, frmPrincipal.RFCTextBox.Text)
        cmbRFC.Text = frmPrincipal.RFCTextBox.Text
        'Me.CFDI_MailTableAdapter.Fill(Me.Production_AUXDataSet.CFDI_Mail)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            Me.CFDI_MailBindingSource.EndEdit()
            Me.CFDI_MailTableAdapter.Update(Me.Production_AUXDataSet.CFDI_Mail)
            Me.Production_AUXDataSet.GetChanges()
            MsgBox("Actualización exitosa...")
        Catch ex As Exception
            MsgBox("Error al actualizar registro..." + vbNewLine(2), ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFC.SelectedIndexChanged
        Me.CFDI_MailTableAdapter.ObtMails(Me.Production_AUXDataSet.CFDI_Mail, cmbRFC.Text)
        If RFCTextBox.Text = cmbRFC.Text Then
            btnNuevo.Enabled = False
            btnActualizar.Enabled = True
        Else
            btnActualizar.Enabled = False
            btnNuevo.Enabled = True
        End If
    End Sub

    Private Sub RFCTextBox_TextChanged(sender As Object, e As EventArgs) Handles RFCTextBox.TextChanged

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            CFDI_MailTableAdapter.Insert(cmbRFC.Text, Mail1TextBox.Text, Mail2TextBox.Text, Mail3TextBox.Text, Mail4TextBox.Text)
            MsgBox("Actualización exitosa...")
        Catch ex As Exception
            MsgBox("Error al insertar nuevo registro..." + vbNewLine(2), ex.ToString)
        End Try
    End Sub
End Class