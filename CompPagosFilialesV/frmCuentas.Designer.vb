<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim RFC_ClienteLabel As System.Windows.Forms.Label
        Dim RFC_BancoLabel As System.Windows.Forms.Label
        Dim NoCuentaLabel As System.Windows.Forms.Label
        Me.Production_AUXDataSet = New CompPagosFilialesV.Production_AUXDataSet()
        Me.CFDI_CuentasClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFDI_CuentasClientesTableAdapter = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter()
        Me.TableAdapterManager = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager()
        Me.CFDI_BancosTableAdapter = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.CFDI_BancosTableAdapter()
        Me.RFC_ClienteTextBox = New System.Windows.Forms.TextBox()
        Me.RFC_BancoTextBox = New System.Windows.Forms.TextBox()
        Me.NoCuentaTextBox = New System.Windows.Forms.TextBox()
        Me.cmbRFCCliente = New System.Windows.Forms.ComboBox()
        Me.cmbRFCBanco = New System.Windows.Forms.ComboBox()
        Me.CFDIBancosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CFDIBancosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductionAUXDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        RFC_ClienteLabel = New System.Windows.Forms.Label()
        RFC_BancoLabel = New System.Windows.Forms.Label()
        NoCuentaLabel = New System.Windows.Forms.Label()
        CType(Me.Production_AUXDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFDI_CuentasClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFDIBancosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFDIBancosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductionAUXDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RFC_ClienteLabel
        '
        RFC_ClienteLabel.AutoSize = True
        RFC_ClienteLabel.Location = New System.Drawing.Point(11, 15)
        RFC_ClienteLabel.Name = "RFC_ClienteLabel"
        RFC_ClienteLabel.Size = New System.Drawing.Size(66, 13)
        RFC_ClienteLabel.TabIndex = 1
        RFC_ClienteLabel.Text = "RFC Cliente:"
        '
        'RFC_BancoLabel
        '
        RFC_BancoLabel.AutoSize = True
        RFC_BancoLabel.Location = New System.Drawing.Point(12, 41)
        RFC_BancoLabel.Name = "RFC_BancoLabel"
        RFC_BancoLabel.Size = New System.Drawing.Size(65, 13)
        RFC_BancoLabel.TabIndex = 2
        RFC_BancoLabel.Text = "RFC Banco:"
        '
        'NoCuentaLabel
        '
        NoCuentaLabel.AutoSize = True
        NoCuentaLabel.Location = New System.Drawing.Point(16, 67)
        NoCuentaLabel.Name = "NoCuentaLabel"
        NoCuentaLabel.Size = New System.Drawing.Size(61, 13)
        NoCuentaLabel.TabIndex = 4
        NoCuentaLabel.Text = "No Cuenta:"
        '
        'Production_AUXDataSet
        '
        Me.Production_AUXDataSet.DataSetName = "Production_AUXDataSet"
        Me.Production_AUXDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CFDI_CuentasClientesBindingSource
        '
        Me.CFDI_CuentasClientesBindingSource.DataMember = "CFDI_CuentasClientes"
        Me.CFDI_CuentasClientesBindingSource.DataSource = Me.Production_AUXDataSet
        '
        'CFDI_CuentasClientesTableAdapter
        '
        Me.CFDI_CuentasClientesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CFDI_BancosTableAdapter = Me.CFDI_BancosTableAdapter
        Me.TableAdapterManager.CFDI_CompConsFactorajeTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_ComplementoPagoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_CuentasClientesTableAdapter = Me.CFDI_CuentasClientesTableAdapter
        Me.TableAdapterManager.CFDI_DetalleTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_EncabezadoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_MailTableAdapter = Nothing
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CFDI_BancosTableAdapter
        '
        Me.CFDI_BancosTableAdapter.ClearBeforeFill = True
        '
        'RFC_ClienteTextBox
        '
        Me.RFC_ClienteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_CuentasClientesBindingSource, "RFC_Cliente", True))
        Me.RFC_ClienteTextBox.Enabled = False
        Me.RFC_ClienteTextBox.Location = New System.Drawing.Point(210, 12)
        Me.RFC_ClienteTextBox.Name = "RFC_ClienteTextBox"
        Me.RFC_ClienteTextBox.Size = New System.Drawing.Size(123, 20)
        Me.RFC_ClienteTextBox.TabIndex = 2
        '
        'RFC_BancoTextBox
        '
        Me.RFC_BancoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_CuentasClientesBindingSource, "RFC_Banco", True))
        Me.RFC_BancoTextBox.Enabled = False
        Me.RFC_BancoTextBox.Location = New System.Drawing.Point(210, 38)
        Me.RFC_BancoTextBox.Name = "RFC_BancoTextBox"
        Me.RFC_BancoTextBox.Size = New System.Drawing.Size(123, 20)
        Me.RFC_BancoTextBox.TabIndex = 3
        '
        'NoCuentaTextBox
        '
        Me.NoCuentaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CFDI_CuentasClientesBindingSource, "NoCuenta", True))
        Me.NoCuentaTextBox.Location = New System.Drawing.Point(83, 64)
        Me.NoCuentaTextBox.Name = "NoCuentaTextBox"
        Me.NoCuentaTextBox.Size = New System.Drawing.Size(250, 20)
        Me.NoCuentaTextBox.TabIndex = 5
        '
        'cmbRFCCliente
        '
        Me.cmbRFCCliente.FormattingEnabled = True
        Me.cmbRFCCliente.Items.AddRange(New Object() {"FGM790801SD7", "PCO880928RD1", "PPL8012295V2", "MSU850911A56", "PAM781201CW0", "HPI880624SW5", "GTC980421R4A", "DME061031H27", "DIM061230LN8", "CVN140812CQ9"})
        Me.cmbRFCCliente.Location = New System.Drawing.Point(83, 11)
        Me.cmbRFCCliente.Name = "cmbRFCCliente"
        Me.cmbRFCCliente.Size = New System.Drawing.Size(121, 21)
        Me.cmbRFCCliente.TabIndex = 6
        '
        'cmbRFCBanco
        '
        Me.cmbRFCBanco.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CFDIBancosBindingSource, "RFC", True))
        Me.cmbRFCBanco.DataSource = Me.CFDIBancosBindingSource1
        Me.cmbRFCBanco.DisplayMember = "RFC"
        Me.cmbRFCBanco.FormattingEnabled = True
        Me.cmbRFCBanco.Location = New System.Drawing.Point(83, 37)
        Me.cmbRFCBanco.Name = "cmbRFCBanco"
        Me.cmbRFCBanco.Size = New System.Drawing.Size(121, 21)
        Me.cmbRFCBanco.TabIndex = 7
        Me.cmbRFCBanco.ValueMember = "RFC"
        '
        'CFDIBancosBindingSource
        '
        Me.CFDIBancosBindingSource.DataMember = "CFDI_Bancos"
        Me.CFDIBancosBindingSource.DataSource = Me.Production_AUXDataSet
        '
        'CFDIBancosBindingSource1
        '
        Me.CFDIBancosBindingSource1.DataMember = "CFDI_Bancos"
        Me.CFDIBancosBindingSource1.DataSource = Me.ProductionAUXDataSetBindingSource
        '
        'ProductionAUXDataSetBindingSource
        '
        Me.ProductionAUXDataSetBindingSource.DataSource = Me.Production_AUXDataSet
        Me.ProductionAUXDataSetBindingSource.Position = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(363, 17)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 8
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Enabled = False
        Me.btnNuevo.Location = New System.Drawing.Point(363, 53)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 9
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 95)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.cmbRFCBanco)
        Me.Controls.Add(Me.cmbRFCCliente)
        Me.Controls.Add(NoCuentaLabel)
        Me.Controls.Add(Me.NoCuentaTextBox)
        Me.Controls.Add(RFC_BancoLabel)
        Me.Controls.Add(Me.RFC_BancoTextBox)
        Me.Controls.Add(RFC_ClienteLabel)
        Me.Controls.Add(Me.RFC_ClienteTextBox)
        Me.Name = "frmCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas bancarias origen"
        CType(Me.Production_AUXDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFDI_CuentasClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFDIBancosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFDIBancosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductionAUXDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Production_AUXDataSet As Production_AUXDataSet
    Friend WithEvents CFDI_CuentasClientesBindingSource As BindingSource
    Friend WithEvents CFDI_CuentasClientesTableAdapter As Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter
    Friend WithEvents TableAdapterManager As Production_AUXDataSetTableAdapters.TableAdapterManager
    Friend WithEvents RFC_ClienteTextBox As TextBox
    Friend WithEvents RFC_BancoTextBox As TextBox
    Friend WithEvents NoCuentaTextBox As TextBox
    Friend WithEvents CFDI_BancosTableAdapter As Production_AUXDataSetTableAdapters.CFDI_BancosTableAdapter
    Friend WithEvents cmbRFCCliente As ComboBox
    Friend WithEvents cmbRFCBanco As ComboBox
    Friend WithEvents ProductionAUXDataSetBindingSource As BindingSource
    Friend WithEvents CFDIBancosBindingSource As BindingSource
    Friend WithEvents CFDIBancosBindingSource1 As BindingSource
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnNuevo As Button
End Class
