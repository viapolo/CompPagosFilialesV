<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Dim ChequeLabel As System.Windows.Forms.Label
        Dim MontoLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvComplementos = New System.Windows.Forms.DataGridView()
        Me.RFCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChequeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenciaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerieCFDIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolioCFDIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPagoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FormaDePagoPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MonedaPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumOperacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomBancoOrdExtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtaOrdenanteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFCEmisorCtaBenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtaBeneficiarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcesadoDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgDocRelacionado = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.bsCFDICompConsFactoraje = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsProduction = New CompPagosFilialesV.Production_AUXDataSet()
        Me.btnNoProcesados = New System.Windows.Forms.Button()
        Me.RFCTextBox = New System.Windows.Forms.TextBox()
        Me.ChequeTextBox = New System.Windows.Forms.TextBox()
        Me.MontoTextBox = New System.Windows.Forms.TextBox()
        Me.cmbRFC = New System.Windows.Forms.ComboBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.pbTodos = New System.Windows.Forms.ProgressBar()
        Me.pbCheque = New System.Windows.Forms.ProgressBar()
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.fbdCargarXML = New System.Windows.Forms.FolderBrowserDialog()
        Me.VwChequesDetalleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Factor100DataSet = New CompPagosFilialesV.Factor100DataSet()
        Me.Factor100DataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_ChequesDetalleTableAdapter = New CompPagosFilialesV.Factor100DataSetTableAdapters.Vw_ChequesDetalleTableAdapter()
        Me.CFDICuentasClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.taCFDI_CompConsFactoraje = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.CFDI_CompConsFactorajeTableAdapter()
        Me.TableAdapterManager = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager()
        Me.CFDI_CuentasClientesTableAdapter = New CompPagosFilialesV.Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter()
        Me.btnMails = New System.Windows.Forms.Button()
        Me.btnCuentas = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tspRegistrosPrincipal = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslRegistrosPrincipal = New System.Windows.Forms.ToolStripStatusLabel()
        RFCLabel = New System.Windows.Forms.Label()
        ChequeLabel = New System.Windows.Forms.Label()
        MontoLabel = New System.Windows.Forms.Label()
        CType(Me.dgvComplementos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCFDICompConsFactoraje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwChequesDetalleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factor100DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Factor100DataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFDICuentasClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RFCLabel
        '
        RFCLabel.AutoSize = True
        RFCLabel.Location = New System.Drawing.Point(1158, 380)
        RFCLabel.Name = "RFCLabel"
        RFCLabel.Size = New System.Drawing.Size(31, 13)
        RFCLabel.TabIndex = 2
        RFCLabel.Text = "RFC:"
        '
        'ChequeLabel
        '
        ChequeLabel.AutoSize = True
        ChequeLabel.Location = New System.Drawing.Point(1142, 406)
        ChequeLabel.Name = "ChequeLabel"
        ChequeLabel.Size = New System.Drawing.Size(47, 13)
        ChequeLabel.TabIndex = 4
        ChequeLabel.Text = "Cheque:"
        '
        'MontoLabel
        '
        MontoLabel.AutoSize = True
        MontoLabel.Location = New System.Drawing.Point(1149, 432)
        MontoLabel.Name = "MontoLabel"
        MontoLabel.Size = New System.Drawing.Size(40, 13)
        MontoLabel.TabIndex = 6
        MontoLabel.Text = "Monto:"
        '
        'dgvComplementos
        '
        Me.dgvComplementos.AllowUserToAddRows = False
        Me.dgvComplementos.AutoGenerateColumns = False
        Me.dgvComplementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComplementos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RFCDataGridViewTextBoxColumn, Me.ChequeDataGridViewTextBoxColumn, Me.ReferenciaDataGridViewTextBoxColumn, Me.SerieCFDIDataGridViewTextBoxColumn, Me.FolioCFDIDataGridViewTextBoxColumn, Me.MontoDataGridViewTextBoxColumn, Me.FechaPagoDataGridViewTextBoxColumn, Me.FormaDePagoPDataGridViewTextBoxColumn, Me.MonedaPDataGridViewTextBoxColumn, Me.NumOperacionDataGridViewTextBoxColumn, Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn, Me.NomBancoOrdExtDataGridViewTextBoxColumn, Me.CtaOrdenanteDataGridViewTextBoxColumn, Me.RFCEmisorCtaBenDataGridViewTextBoxColumn, Me.CtaBeneficiarioDataGridViewTextBoxColumn, Me.ProcesadoDataGridViewCheckBoxColumn, Me.dgDocRelacionado})
        Me.dgvComplementos.DataSource = Me.bsCFDICompConsFactoraje
        Me.dgvComplementos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvComplementos.Location = New System.Drawing.Point(0, 0)
        Me.dgvComplementos.Name = "dgvComplementos"
        Me.dgvComplementos.Size = New System.Drawing.Size(1307, 370)
        Me.dgvComplementos.TabIndex = 0
        '
        'RFCDataGridViewTextBoxColumn
        '
        Me.RFCDataGridViewTextBoxColumn.DataPropertyName = "RFC"
        Me.RFCDataGridViewTextBoxColumn.HeaderText = "RFC"
        Me.RFCDataGridViewTextBoxColumn.Name = "RFCDataGridViewTextBoxColumn"
        Me.RFCDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ChequeDataGridViewTextBoxColumn
        '
        Me.ChequeDataGridViewTextBoxColumn.DataPropertyName = "Cheque"
        Me.ChequeDataGridViewTextBoxColumn.HeaderText = "Cheque"
        Me.ChequeDataGridViewTextBoxColumn.Name = "ChequeDataGridViewTextBoxColumn"
        Me.ChequeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ReferenciaDataGridViewTextBoxColumn
        '
        Me.ReferenciaDataGridViewTextBoxColumn.DataPropertyName = "Referencia"
        Me.ReferenciaDataGridViewTextBoxColumn.HeaderText = "Referencia"
        Me.ReferenciaDataGridViewTextBoxColumn.Name = "ReferenciaDataGridViewTextBoxColumn"
        Me.ReferenciaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SerieCFDIDataGridViewTextBoxColumn
        '
        Me.SerieCFDIDataGridViewTextBoxColumn.DataPropertyName = "Serie_CFDI"
        Me.SerieCFDIDataGridViewTextBoxColumn.HeaderText = "Serie_CFDI"
        Me.SerieCFDIDataGridViewTextBoxColumn.Name = "SerieCFDIDataGridViewTextBoxColumn"
        Me.SerieCFDIDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FolioCFDIDataGridViewTextBoxColumn
        '
        Me.FolioCFDIDataGridViewTextBoxColumn.DataPropertyName = "Folio_CFDI"
        Me.FolioCFDIDataGridViewTextBoxColumn.HeaderText = "Folio_CFDI"
        Me.FolioCFDIDataGridViewTextBoxColumn.Name = "FolioCFDIDataGridViewTextBoxColumn"
        Me.FolioCFDIDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MontoDataGridViewTextBoxColumn
        '
        Me.MontoDataGridViewTextBoxColumn.DataPropertyName = "Monto"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.MontoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.MontoDataGridViewTextBoxColumn.HeaderText = "Monto"
        Me.MontoDataGridViewTextBoxColumn.Name = "MontoDataGridViewTextBoxColumn"
        '
        'FechaPagoDataGridViewTextBoxColumn
        '
        Me.FechaPagoDataGridViewTextBoxColumn.DataPropertyName = "FechaPago"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FechaPagoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaPagoDataGridViewTextBoxColumn.HeaderText = "FechaPago"
        Me.FechaPagoDataGridViewTextBoxColumn.Name = "FechaPagoDataGridViewTextBoxColumn"
        '
        'FormaDePagoPDataGridViewTextBoxColumn
        '
        Me.FormaDePagoPDataGridViewTextBoxColumn.DataPropertyName = "FormaDePagoP"
        Me.FormaDePagoPDataGridViewTextBoxColumn.HeaderText = "FormaDePagoP"
        Me.FormaDePagoPDataGridViewTextBoxColumn.Name = "FormaDePagoPDataGridViewTextBoxColumn"
        Me.FormaDePagoPDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MonedaPDataGridViewTextBoxColumn
        '
        Me.MonedaPDataGridViewTextBoxColumn.DataPropertyName = "MonedaP"
        Me.MonedaPDataGridViewTextBoxColumn.HeaderText = "MonedaP"
        Me.MonedaPDataGridViewTextBoxColumn.Name = "MonedaPDataGridViewTextBoxColumn"
        Me.MonedaPDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NumOperacionDataGridViewTextBoxColumn
        '
        Me.NumOperacionDataGridViewTextBoxColumn.DataPropertyName = "NumOperacion"
        Me.NumOperacionDataGridViewTextBoxColumn.HeaderText = "NumOperacion"
        Me.NumOperacionDataGridViewTextBoxColumn.Name = "NumOperacionDataGridViewTextBoxColumn"
        Me.NumOperacionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RFCEmisorCtaOrdDataGridViewTextBoxColumn
        '
        Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn.DataPropertyName = "RFCEmisorCtaOrd"
        Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn.HeaderText = "RFCEmisorCtaOrd"
        Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn.Name = "RFCEmisorCtaOrdDataGridViewTextBoxColumn"
        Me.RFCEmisorCtaOrdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NomBancoOrdExtDataGridViewTextBoxColumn
        '
        Me.NomBancoOrdExtDataGridViewTextBoxColumn.DataPropertyName = "NomBancoOrdExt"
        Me.NomBancoOrdExtDataGridViewTextBoxColumn.HeaderText = "NomBancoOrdExt"
        Me.NomBancoOrdExtDataGridViewTextBoxColumn.Name = "NomBancoOrdExtDataGridViewTextBoxColumn"
        Me.NomBancoOrdExtDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CtaOrdenanteDataGridViewTextBoxColumn
        '
        Me.CtaOrdenanteDataGridViewTextBoxColumn.DataPropertyName = "CtaOrdenante"
        Me.CtaOrdenanteDataGridViewTextBoxColumn.HeaderText = "CtaOrdenante"
        Me.CtaOrdenanteDataGridViewTextBoxColumn.Name = "CtaOrdenanteDataGridViewTextBoxColumn"
        Me.CtaOrdenanteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RFCEmisorCtaBenDataGridViewTextBoxColumn
        '
        Me.RFCEmisorCtaBenDataGridViewTextBoxColumn.DataPropertyName = "RFCEmisorCtaBen"
        Me.RFCEmisorCtaBenDataGridViewTextBoxColumn.HeaderText = "RFCEmisorCtaBen"
        Me.RFCEmisorCtaBenDataGridViewTextBoxColumn.Name = "RFCEmisorCtaBenDataGridViewTextBoxColumn"
        Me.RFCEmisorCtaBenDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CtaBeneficiarioDataGridViewTextBoxColumn
        '
        Me.CtaBeneficiarioDataGridViewTextBoxColumn.DataPropertyName = "CtaBeneficiario"
        Me.CtaBeneficiarioDataGridViewTextBoxColumn.HeaderText = "CtaBeneficiario"
        Me.CtaBeneficiarioDataGridViewTextBoxColumn.Name = "CtaBeneficiarioDataGridViewTextBoxColumn"
        Me.CtaBeneficiarioDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProcesadoDataGridViewCheckBoxColumn
        '
        Me.ProcesadoDataGridViewCheckBoxColumn.HeaderText = "¿Procesar?"
        Me.ProcesadoDataGridViewCheckBoxColumn.Name = "ProcesadoDataGridViewCheckBoxColumn"
        Me.ProcesadoDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'dgDocRelacionado
        '
        Me.dgDocRelacionado.HeaderText = "Doc Rel"
        Me.dgDocRelacionado.Name = "dgDocRelacionado"
        Me.dgDocRelacionado.ReadOnly = True
        Me.dgDocRelacionado.Text = "CFDI Rel"
        '
        'bsCFDICompConsFactoraje
        '
        Me.bsCFDICompConsFactoraje.DataMember = "CFDI_CompConsFactoraje"
        Me.bsCFDICompConsFactoraje.DataSource = Me.dsProduction
        '
        'dsProduction
        '
        Me.dsProduction.DataSetName = "Production_AUXDataSet"
        Me.dsProduction.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnNoProcesados
        '
        Me.btnNoProcesados.Location = New System.Drawing.Point(13, 422)
        Me.btnNoProcesados.Name = "btnNoProcesados"
        Me.btnNoProcesados.Size = New System.Drawing.Size(133, 23)
        Me.btnNoProcesados.TabIndex = 1
        Me.btnNoProcesados.Text = "Actualizar"
        Me.btnNoProcesados.UseVisualStyleBackColor = True
        '
        'RFCTextBox
        '
        Me.RFCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCFDICompConsFactoraje, "RFC", True))
        Me.RFCTextBox.Location = New System.Drawing.Point(1195, 377)
        Me.RFCTextBox.Name = "RFCTextBox"
        Me.RFCTextBox.ReadOnly = True
        Me.RFCTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RFCTextBox.TabIndex = 3
        '
        'ChequeTextBox
        '
        Me.ChequeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCFDICompConsFactoraje, "Cheque", True))
        Me.ChequeTextBox.Location = New System.Drawing.Point(1195, 403)
        Me.ChequeTextBox.Name = "ChequeTextBox"
        Me.ChequeTextBox.ReadOnly = True
        Me.ChequeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ChequeTextBox.TabIndex = 5
        '
        'MontoTextBox
        '
        Me.MontoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsCFDICompConsFactoraje, "Monto", True))
        Me.MontoTextBox.Location = New System.Drawing.Point(1195, 429)
        Me.MontoTextBox.Name = "MontoTextBox"
        Me.MontoTextBox.ReadOnly = True
        Me.MontoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MontoTextBox.TabIndex = 7
        '
        'cmbRFC
        '
        Me.cmbRFC.FormattingEnabled = True
        Me.cmbRFC.Items.AddRange(New Object() {"FGM790801SD7", "PCO880928RD1", "PPL8012295V2", "MSU850911A56", "PAM781201CW0", "HPI880624SW5", "GTC980421R4A", "DME061031H27", "DIM061230LN8", "CVN140812CQ9"})
        Me.cmbRFC.Location = New System.Drawing.Point(13, 380)
        Me.cmbRFC.Name = "cmbRFC"
        Me.cmbRFC.Size = New System.Drawing.Size(298, 21)
        Me.cmbRFC.TabIndex = 8
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(178, 422)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(133, 23)
        Me.btnProcesar.TabIndex = 9
        Me.btnProcesar.Text = "Buscar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'pbTodos
        '
        Me.pbTodos.Location = New System.Drawing.Point(528, 415)
        Me.pbTodos.Name = "pbTodos"
        Me.pbTodos.Size = New System.Drawing.Size(469, 10)
        Me.pbTodos.TabIndex = 10
        Me.pbTodos.Visible = False
        '
        'pbCheque
        '
        Me.pbCheque.Location = New System.Drawing.Point(528, 435)
        Me.pbCheque.Name = "pbCheque"
        Me.pbCheque.Size = New System.Drawing.Size(469, 10)
        Me.pbCheque.TabIndex = 11
        Me.pbCheque.Visible = False
        '
        'btnTimbrar
        '
        Me.btnTimbrar.Enabled = False
        Me.btnTimbrar.Location = New System.Drawing.Point(346, 422)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(133, 23)
        Me.btnTimbrar.TabIndex = 12
        Me.btnTimbrar.Text = "Emitir CFDI con CP"
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'VwChequesDetalleBindingSource
        '
        Me.VwChequesDetalleBindingSource.DataMember = "Vw_ChequesDetalle"
        Me.VwChequesDetalleBindingSource.DataSource = Me.Factor100DataSet
        '
        'Factor100DataSet
        '
        Me.Factor100DataSet.DataSetName = "Factor100DataSet"
        Me.Factor100DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Factor100DataSetBindingSource
        '
        Me.Factor100DataSetBindingSource.DataSource = Me.Factor100DataSet
        Me.Factor100DataSetBindingSource.Position = 0
        '
        'Vw_ChequesDetalleTableAdapter
        '
        Me.Vw_ChequesDetalleTableAdapter.ClearBeforeFill = True
        '
        'CFDICuentasClientesBindingSource
        '
        Me.CFDICuentasClientesBindingSource.DataMember = "CFDI_CuentasClientes"
        Me.CFDICuentasClientesBindingSource.DataSource = Me.dsProduction
        '
        'taCFDI_CompConsFactoraje
        '
        Me.taCFDI_CompConsFactoraje.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CFDI_BancosTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_CompConsFactorajeTableAdapter = Me.taCFDI_CompConsFactoraje
        Me.TableAdapterManager.CFDI_ComplementoPagoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_CuentasClientesTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_DetalleTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_EncabezadoTableAdapter = Nothing
        Me.TableAdapterManager.CFDI_MailTableAdapter = Nothing
        Me.TableAdapterManager.ClientesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CompPagosFilialesV.Production_AUXDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CFDI_CuentasClientesTableAdapter
        '
        Me.CFDI_CuentasClientesTableAdapter.ClearBeforeFill = True
        '
        'btnMails
        '
        Me.btnMails.Location = New System.Drawing.Point(528, 380)
        Me.btnMails.Name = "btnMails"
        Me.btnMails.Size = New System.Drawing.Size(75, 23)
        Me.btnMails.TabIndex = 13
        Me.btnMails.Text = "Mails"
        Me.btnMails.UseVisualStyleBackColor = True
        '
        'btnCuentas
        '
        Me.btnCuentas.Location = New System.Drawing.Point(610, 380)
        Me.btnCuentas.Name = "btnCuentas"
        Me.btnCuentas.Size = New System.Drawing.Size(75, 23)
        Me.btnCuentas.TabIndex = 14
        Me.btnCuentas.Text = "Cuentas"
        Me.btnCuentas.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tspRegistrosPrincipal, Me.tslRegistrosPrincipal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1307, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tspRegistrosPrincipal
        '
        Me.tspRegistrosPrincipal.Name = "tspRegistrosPrincipal"
        Me.tspRegistrosPrincipal.Size = New System.Drawing.Size(100, 16)
        '
        'tslRegistrosPrincipal
        '
        Me.tslRegistrosPrincipal.Name = "tslRegistrosPrincipal"
        Me.tslRegistrosPrincipal.Size = New System.Drawing.Size(0, 17)
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1307, 485)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCuentas)
        Me.Controls.Add(Me.btnMails)
        Me.Controls.Add(Me.btnTimbrar)
        Me.Controls.Add(Me.pbCheque)
        Me.Controls.Add(Me.pbTodos)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.cmbRFC)
        Me.Controls.Add(MontoLabel)
        Me.Controls.Add(Me.MontoTextBox)
        Me.Controls.Add(ChequeLabel)
        Me.Controls.Add(Me.ChequeTextBox)
        Me.Controls.Add(RFCLabel)
        Me.Controls.Add(Me.RFCTextBox)
        Me.Controls.Add(Me.btnNoProcesados)
        Me.Controls.Add(Me.dgvComplementos)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Complementos de pago factoraje"
        CType(Me.dgvComplementos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCFDICompConsFactoraje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsProduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwChequesDetalleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factor100DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Factor100DataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFDICuentasClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvComplementos As DataGridView
    Friend WithEvents dsProduction As Production_AUXDataSet
    Friend WithEvents bsCFDICompConsFactoraje As BindingSource
    Friend WithEvents taCFDI_CompConsFactoraje As Production_AUXDataSetTableAdapters.CFDI_CompConsFactorajeTableAdapter
    Friend WithEvents btnNoProcesados As Button
    Friend WithEvents TableAdapterManager As Production_AUXDataSetTableAdapters.TableAdapterManager
    Friend WithEvents RFCTextBox As TextBox
    Friend WithEvents ChequeTextBox As TextBox
    Friend WithEvents MontoTextBox As TextBox
    Friend WithEvents cmbRFC As ComboBox
    Friend WithEvents Factor100DataSetBindingSource As BindingSource
    Friend WithEvents Factor100DataSet As Factor100DataSet
    Friend WithEvents VwChequesDetalleBindingSource As BindingSource
    Friend WithEvents Vw_ChequesDetalleTableAdapter As Factor100DataSetTableAdapters.Vw_ChequesDetalleTableAdapter
    Friend WithEvents btnProcesar As Button
    Friend WithEvents pbTodos As ProgressBar
    Friend WithEvents pbCheque As ProgressBar
    Friend WithEvents btnTimbrar As Button
    Friend WithEvents RFCDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ChequeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReferenciaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SerieCFDIDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FolioCFDIDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProcesadoDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents MontoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaPagoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FormaDePagoPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MonedaPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumOperacionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RFCEmisorCtaOrdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NomBancoOrdExtDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CtaOrdenanteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RFCEmisorCtaBenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CtaBeneficiarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgDocRelacionado As DataGridViewLinkColumn
    Friend WithEvents fbdCargarXML As FolderBrowserDialog
    Friend WithEvents CFDICuentasClientesBindingSource As BindingSource
    Friend WithEvents CFDI_CuentasClientesTableAdapter As Production_AUXDataSetTableAdapters.CFDI_CuentasClientesTableAdapter
    Friend WithEvents btnMails As Button
    Friend WithEvents btnCuentas As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tspRegistrosPrincipal As ToolStripProgressBar
    Friend WithEvents tslRegistrosPrincipal As ToolStripStatusLabel
End Class
