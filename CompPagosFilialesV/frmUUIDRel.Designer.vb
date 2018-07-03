<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUUIDRel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvUUIDRelacionados = New System.Windows.Forms.DataGridView()
        Me.bsVwChequesDetalle = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsFactor100 = New CompPagosFilialesV.Factor100DataSet()
        Me.stsDocRel = New System.Windows.Forms.StatusStrip()
        Me.tslblImpPago = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblPago = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblImpUUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblSumaUUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.taVw_ChequesDetalle = New CompPagosFilialesV.Factor100DataSetTableAdapters.Vw_ChequesDetalleTableAdapter()
        Me.btnGComplemento = New System.Windows.Forms.Button()
        Me.lblEncSugerencia = New System.Windows.Forms.Label()
        Me.lblSugerencia = New System.Windows.Forms.Label()
        Me.btnSugerencia = New System.Windows.Forms.Button()
        Me.ClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChequeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReferenciaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgUUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgFolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMonto = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDiferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvUUIDRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsVwChequesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsFactor100, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsDocRel.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUUIDRelacionados
        '
        Me.dgvUUIDRelacionados.AllowUserToAddRows = False
        Me.dgvUUIDRelacionados.AutoGenerateColumns = False
        Me.dgvUUIDRelacionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUUIDRelacionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClienteDataGridViewTextBoxColumn, Me.RFCDataGridViewTextBoxColumn, Me.ChequeDataGridViewTextBoxColumn, Me.ReferenciaDataGridViewTextBoxColumn, Me.ImporteDataGridViewTextBoxColumn, Me.dgUUID, Me.dgSerie, Me.dgFolio, Me.dgMPago, Me.dgMoneda, Me.dgTC, Me.dgMonto, Me.dgSaldo, Me.dgDiferencia})
        Me.dgvUUIDRelacionados.DataSource = Me.bsVwChequesDetalle
        Me.dgvUUIDRelacionados.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvUUIDRelacionados.Location = New System.Drawing.Point(0, 0)
        Me.dgvUUIDRelacionados.Name = "dgvUUIDRelacionados"
        Me.dgvUUIDRelacionados.Size = New System.Drawing.Size(1125, 356)
        Me.dgvUUIDRelacionados.TabIndex = 0
        '
        'bsVwChequesDetalle
        '
        Me.bsVwChequesDetalle.DataMember = "Vw_ChequesDetalle"
        Me.bsVwChequesDetalle.DataSource = Me.dsFactor100
        '
        'dsFactor100
        '
        Me.dsFactor100.DataSetName = "Factor100DataSet"
        Me.dsFactor100.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'stsDocRel
        '
        Me.stsDocRel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblImpPago, Me.tslblPago, Me.tslblImpUUID, Me.tslblSumaUUID, Me.ts1, Me.ts2, Me.ts3, Me.ts4})
        Me.stsDocRel.Location = New System.Drawing.Point(0, 428)
        Me.stsDocRel.Name = "stsDocRel"
        Me.stsDocRel.Size = New System.Drawing.Size(1125, 22)
        Me.stsDocRel.TabIndex = 1
        Me.stsDocRel.Text = "StatusStrip1"
        '
        'tslblImpPago
        '
        Me.tslblImpPago.Name = "tslblImpPago"
        Me.tslblImpPago.Size = New System.Drawing.Size(82, 17)
        Me.tslblImpPago.Text = "Importe Pago:"
        '
        'tslblPago
        '
        Me.tslblPago.Name = "tslblPago"
        Me.tslblPago.Size = New System.Drawing.Size(120, 17)
        Me.tslblPago.Text = "ToolStripStatusLabel1"
        '
        'tslblImpUUID
        '
        Me.tslblImpUUID.Name = "tslblImpUUID"
        Me.tslblImpUUID.Size = New System.Drawing.Size(78, 17)
        Me.tslblImpUUID.Text = "Suma UUID´s:"
        '
        'tslblSumaUUID
        '
        Me.tslblSumaUUID.Name = "tslblSumaUUID"
        Me.tslblSumaUUID.Size = New System.Drawing.Size(75, 17)
        Me.tslblSumaUUID.Text = "Suma UUID's"
        '
        'ts1
        '
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(0, 17)
        '
        'ts2
        '
        Me.ts2.Name = "ts2"
        Me.ts2.Size = New System.Drawing.Size(0, 17)
        '
        'ts3
        '
        Me.ts3.Name = "ts3"
        Me.ts3.Size = New System.Drawing.Size(0, 17)
        '
        'ts4
        '
        Me.ts4.Name = "ts4"
        Me.ts4.Size = New System.Drawing.Size(0, 17)
        '
        'taVw_ChequesDetalle
        '
        Me.taVw_ChequesDetalle.ClearBeforeFill = True
        '
        'btnGComplemento
        '
        Me.btnGComplemento.Location = New System.Drawing.Point(12, 382)
        Me.btnGComplemento.Name = "btnGComplemento"
        Me.btnGComplemento.Size = New System.Drawing.Size(156, 23)
        Me.btnGComplemento.TabIndex = 2
        Me.btnGComplemento.Text = "Emitir CFDI con CP"
        Me.btnGComplemento.UseVisualStyleBackColor = True
        '
        'lblEncSugerencia
        '
        Me.lblEncSugerencia.AutoSize = True
        Me.lblEncSugerencia.Location = New System.Drawing.Point(766, 392)
        Me.lblEncSugerencia.Name = "lblEncSugerencia"
        Me.lblEncSugerencia.Size = New System.Drawing.Size(74, 13)
        Me.lblEncSugerencia.TabIndex = 3
        Me.lblEncSugerencia.Text = "Sug TCambio:"
        '
        'lblSugerencia
        '
        Me.lblSugerencia.AutoSize = True
        Me.lblSugerencia.Location = New System.Drawing.Point(876, 392)
        Me.lblSugerencia.Name = "lblSugerencia"
        Me.lblSugerencia.Size = New System.Drawing.Size(16, 13)
        Me.lblSugerencia.TabIndex = 4
        Me.lblSugerencia.Text = "..."
        Me.lblSugerencia.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSugerencia
        '
        Me.btnSugerencia.Location = New System.Drawing.Point(944, 387)
        Me.btnSugerencia.Name = "btnSugerencia"
        Me.btnSugerencia.Size = New System.Drawing.Size(75, 23)
        Me.btnSugerencia.TabIndex = 5
        Me.btnSugerencia.Text = "Aplic Sug"
        Me.btnSugerencia.UseVisualStyleBackColor = True
        '
        'ClienteDataGridViewTextBoxColumn
        '
        Me.ClienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente"
        Me.ClienteDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.ClienteDataGridViewTextBoxColumn.Name = "ClienteDataGridViewTextBoxColumn"
        Me.ClienteDataGridViewTextBoxColumn.ReadOnly = True
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
        'ImporteDataGridViewTextBoxColumn
        '
        Me.ImporteDataGridViewTextBoxColumn.DataPropertyName = "Importe"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ImporteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.ImporteDataGridViewTextBoxColumn.HeaderText = "Importe"
        Me.ImporteDataGridViewTextBoxColumn.Name = "ImporteDataGridViewTextBoxColumn"
        Me.ImporteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'dgUUID
        '
        Me.dgUUID.HeaderText = "FFiscalDR"
        Me.dgUUID.Name = "dgUUID"
        Me.dgUUID.ReadOnly = True
        '
        'dgSerie
        '
        Me.dgSerie.HeaderText = "SerieDR"
        Me.dgSerie.Name = "dgSerie"
        '
        'dgFolio
        '
        Me.dgFolio.HeaderText = "FolioDR"
        Me.dgFolio.Name = "dgFolio"
        '
        'dgMPago
        '
        Me.dgMPago.HeaderText = "MPagoDR"
        Me.dgMPago.Name = "dgMPago"
        Me.dgMPago.ReadOnly = True
        '
        'dgMoneda
        '
        Me.dgMoneda.HeaderText = "MonedaDR"
        Me.dgMoneda.Name = "dgMoneda"
        Me.dgMoneda.ReadOnly = True
        '
        'dgTC
        '
        Me.dgTC.HeaderText = "TCambioDR"
        Me.dgTC.Name = "dgTC"
        Me.dgTC.ReadOnly = True
        '
        'dgMonto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.dgMonto.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgMonto.HeaderText = "MontoDR"
        Me.dgMonto.Name = "dgMonto"
        Me.dgMonto.ReadOnly = True
        Me.dgMonto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMonto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dgSaldo
        '
        Me.dgSaldo.HeaderText = "Saldo"
        Me.dgSaldo.Name = "dgSaldo"
        '
        'dgDiferencia
        '
        Me.dgDiferencia.HeaderText = "Diferencia"
        Me.dgDiferencia.Name = "dgDiferencia"
        '
        'frmUUIDRel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 450)
        Me.Controls.Add(Me.btnSugerencia)
        Me.Controls.Add(Me.lblSugerencia)
        Me.Controls.Add(Me.lblEncSugerencia)
        Me.Controls.Add(Me.btnGComplemento)
        Me.Controls.Add(Me.stsDocRel)
        Me.Controls.Add(Me.dgvUUIDRelacionados)
        Me.Name = "frmUUIDRel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos Relacionados"
        CType(Me.dgvUUIDRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsVwChequesDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsFactor100, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsDocRel.ResumeLayout(False)
        Me.stsDocRel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvUUIDRelacionados As DataGridView
    Friend WithEvents dsFactor100 As Factor100DataSet
    Friend WithEvents bsVwChequesDetalle As BindingSource
    Friend WithEvents taVw_ChequesDetalle As Factor100DataSetTableAdapters.Vw_ChequesDetalleTableAdapter
    Friend WithEvents stsDocRel As StatusStrip
    Friend WithEvents tslblImpPago As ToolStripStatusLabel
    Friend WithEvents tslblPago As ToolStripStatusLabel
    Friend WithEvents tslblImpUUID As ToolStripStatusLabel
    Friend WithEvents tslblSumaUUID As ToolStripStatusLabel
    Friend WithEvents ts1 As ToolStripStatusLabel
    Friend WithEvents ts2 As ToolStripStatusLabel
    Friend WithEvents ts3 As ToolStripStatusLabel
    Friend WithEvents ts4 As ToolStripStatusLabel
    Friend WithEvents btnGComplemento As Button
    Friend WithEvents lblEncSugerencia As Label
    Friend WithEvents lblSugerencia As Label
    Friend WithEvents btnSugerencia As Button
    Friend WithEvents ClienteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RFCDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ChequeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReferenciaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ImporteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents dgUUID As DataGridViewTextBoxColumn
    Friend WithEvents dgSerie As DataGridViewTextBoxColumn
    Friend WithEvents dgFolio As DataGridViewTextBoxColumn
    Friend WithEvents dgMPago As DataGridViewTextBoxColumn
    Friend WithEvents dgMoneda As DataGridViewTextBoxColumn
    Friend WithEvents dgTC As DataGridViewTextBoxColumn
    Friend WithEvents dgMonto As DataGridViewButtonColumn
    Friend WithEvents dgSaldo As DataGridViewTextBoxColumn
    Friend WithEvents dgDiferencia As DataGridViewTextBoxColumn
End Class
