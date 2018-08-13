<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMails
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim RFCLabel As System.Windows.Forms.Label
        Dim Mail1Label As System.Windows.Forms.Label
        Dim Mail2Label As System.Windows.Forms.Label
        Dim Mail3Label As System.Windows.Forms.Label
        Dim Mail4Label As System.Windows.Forms.Label
        Me.RFCTextBox = New System.Windows.Forms.TextBox()
        Me.CFDI_MailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Production_AUXDataSet = New CompPagosFilialesV.Production_AUXDataSet()
        Me.Mail1TextBox = New System.Windows.Forms.TextBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Mail2TextBox = New System.Windows.Forms.TextBox()
        Me.Mail3TextBox = New System.Windows.Forms.TextBox()
        Me.Mail4TextBox = New System.Windows.Forms.TextBox()
        Me.cmbRFC = New System.Windows.Forms.ComboBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.CFDI_MailTableAdapter = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.CFDI_MailTableAdapter()
        Me.TableAdapterManager = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager()
        RFCLabel = New System.Windows.Forms.Label()
        Mail1Label = New System.Windows.Forms.Label()
        Mail2Label = New System.Windows.Forms.Label()
        Mail3Label = New System.Windows.Forms.Label()
        Mail4Label = New System.Windows.Forms.Label()
        CType(Me.CFDI_MailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Production_AUXDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RFCLabel
        '
        RFCLabel.AutoSize = True
        RFCLabel.Location = New System.Drawing.Point(11, 15)
        RFCLabel.Name = "RFCLabel"
        RFCLabel.Size = New System.Drawing.Size(31, 13)
        RFCLabel.TabIndex = 2
        RFCLabel.Text = "RFC:"
        '
        'Mail1Label
        '
        Mail1Label.AutoSize = True
        Mail1Label.Location = New System.Drawing.Point(8, 41)
        Mail1Label.Name = "Mail1Label"
        Mail1Label.Size = New System.Drawing.Size(34, 13)
        Mail1Label.TabIndex = 3
        Mail1Label.Text = "mail1:"
        '
        'Mail2Label
        '
        Mail2Label.AutoSize = True
        Mail2Label.Location = New System.Drawing.Point(8, 67)
        Mail2Label.Name = "Mail2Label"
        Mail2Label.Size = New System.Drawing.Size(34, 13)
        Mail2Label.TabIndex = 5
        Mail2Label.Text = "mail2:"
        '
        'Mail3Label
        '
        Mail3Label.AutoSize = True
        Mail3Label.Location = New System.Drawing.Point(8, 93)
        Mail3Label.Name = "Mail3Label"
        Mail3Label.Size = New System.Drawing.Size(34, 13)
        Mail3Label.TabIndex = 7
        Mail3Label.Text = "mail3:"
        '
        'Mail4Label
        '
        Mail4Label.AutoSize = True
        Mail4Label.Location = New System.Drawing.Point(8, 119)
        Mail4Label.Name = "Mail4Label"
        Mail4Label.Size = New System.Drawing.Size(34, 13)
        Mail4Label.TabIndex = 9
        Mail4Label.Text = "mail4:"
        '
        'RFCTextBox
        '
        Me.RFCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_MailBindingSource, "RFC", True))
        Me.RFCTextBox.Enabled = False
        Me.RFCTextBox.Location = New System.Drawing.Point(201, 12)
        Me.RFCTextBox.Name = "RFCTextBox"
        Me.RFCTextBox.Size = New System.Drawing.Size(152, 20)
        Me.RFCTextBox.TabIndex = 1
        '
        'CFDI_MailBindingSource
        '
        Me.CFDI_MailBindingSource.DataMember = "CFDI_Mail"
        Me.CFDI_MailBindingSource.DataSource = Me.Production_AUXDataSet
        '
        'Production_AUXDataSet
        '
        Me.Production_AUXDataSet.DataSetName = "Production_AUXDataSet"
        Me.Production_AUXDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Mail1TextBox
        '
        Me.Mail1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_MailBindingSource, "mail1", True))
        Me.Mail1TextBox.Location = New System.Drawing.Point(48, 38)
        Me.Mail1TextBox.Name = "Mail1TextBox"
        Me.Mail1TextBox.Size = New System.Drawing.Size(411, 20)
        Me.Mail1TextBox.TabIndex = 2
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(500, 57)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 6
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'Mail2TextBox
        '
        Me.Mail2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_MailBindingSource, "mail2", True))
        Me.Mail2TextBox.Location = New System.Drawing.Point(48, 64)
        Me.Mail2TextBox.Name = "Mail2TextBox"
        Me.Mail2TextBox.Size = New System.Drawing.Size(411, 20)
        Me.Mail2TextBox.TabIndex = 3
        '
        'Mail3TextBox
        '
        Me.Mail3TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_MailBindingSource, "mail3", True))
        Me.Mail3TextBox.Location = New System.Drawing.Point(48, 90)
        Me.Mail3TextBox.Name = "Mail3TextBox"
        Me.Mail3TextBox.Size = New System.Drawing.Size(411, 20)
        Me.Mail3TextBox.TabIndex = 4
        '
        'Mail4TextBox
        '
        Me.Mail4TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_MailBindingSource, "mail4", True))
        Me.Mail4TextBox.Location = New System.Drawing.Point(48, 116)
        Me.Mail4TextBox.Name = "Mail4TextBox"
        Me.Mail4TextBox.Size = New System.Drawing.Size(411, 20)
        Me.Mail4TextBox.TabIndex = 5
        '
        'cmbRFC
        '
        Me.cmbRFC.FormattingEnabled = True
        Me.cmbRFC.Items.AddRange(New Object() {"FGM790801SD7", "PCO880928RD1", "PPL8012295V2", "MSU850911A56", "PAM781201CW0", "HPI880624SW5", "GTC980421R4A", "DME061031H27", "DIM061230LN8", "CVN140812CQ9"})
        Me.cmbRFC.Location = New System.Drawing.Point(48, 11)
        Me.cmbRFC.Name = "cmbRFC"
        Me.cmbRFC.Size = New System.Drawing.Size(147, 21)
        Me.cmbRFC.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Enabled = False
        Me.btnNuevo.Location = New System.Drawing.Point(500, 93)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'CFDI_MailTableAdapter
        '
        Me.CFDI_MailTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CFDI_BancosTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_CompConsFactorajeTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_ComplementoPagoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_CuentasClientesTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_DetalleTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_EncabezadoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_MailTableAdapter = Me.CFDI_MailTableAdapter
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'frmMails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 151)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cmbRFC)
        Me.Controls.Add(Mail4Label)
        Me.Controls.Add(Me.Mail4TextBox)
        Me.Controls.Add(Mail3Label)
        Me.Controls.Add(Me.Mail3TextBox)
        Me.Controls.Add(Mail2Label)
        Me.Controls.Add(Me.Mail2TextBox)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Mail1Label)
        Me.Controls.Add(Me.Mail1TextBox)
        Me.Controls.Add(RFCLabel)
        Me.Controls.Add(Me.RFCTextBox)
        Me.Name = "frmMails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Direcciones de correo destinatarios"
        CType(Me.CFDI_MailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Production_AUXDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Production_AUXDataSet As Production_AUXDataSet
    Friend WithEvents CFDI_MailBindingSource As BindingSource
    Friend WithEvents CFDI_MailTableAdapter As Production_AUXDataSetTableAdapters.CFDI_MailTableAdapter
    Friend WithEvents TableAdapterManager As Production_AUXDataSetTableAdapters.TableAdapterManager
    Friend WithEvents RFCTextBox As TextBox
    Friend WithEvents Mail1TextBox As TextBox
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Mail2TextBox As TextBox
    Friend WithEvents Mail3TextBox As TextBox
    Friend WithEvents Mail4TextBox As TextBox
    Friend WithEvents cmbRFC As ComboBox
    Friend WithEvents btnNuevo As Button
End Class
