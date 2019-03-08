<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUUIDRelC
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
        Me.CFDProveedorDataGridView = New System.Windows.Forms.DataGridView()
        Me.dgMPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XMLSAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CFDProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ATEBCOFIDIRECDataSet = New CompPagosFilialesV.ATEBCOFIDIRECDataSet()
        Me.CFDProveedorTableAdapter = New CompPagosFilialesV.ATEBCOFIDIRECDataSetTableAdapters.CFDProveedorTableAdapter()
        Me.TableAdapterManager = New CompPagosFilialesV.ATEBCOFIDIRECDataSetTableAdapters.TableAdapterManager()
        Me.Vw_GPO_FINAGILTableAdapter = New CompPagosFilialesV.ATEBCOFIDIRECDataSetTableAdapters.vw_GPO_FINAGILTableAdapter()
        Me.VwGPOFINAGILBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.CFDProveedorDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFDProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ATEBCOFIDIRECDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwGPOFINAGILBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CFDProveedorDataGridView
        '
        Me.CFDProveedorDataGridView.AutoGenerateColumns = False
        Me.CFDProveedorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CFDProveedorDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.dgMPago, Me.dgMoneda, Me.dgTC, Me.dgMonto, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn28, Me.XMLSAT})
        Me.CFDProveedorDataGridView.DataSource = Me.VwGPOFINAGILBindingSource
        Me.CFDProveedorDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.CFDProveedorDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.CFDProveedorDataGridView.Name = "CFDProveedorDataGridView"
        Me.CFDProveedorDataGridView.Size = New System.Drawing.Size(799, 274)
        Me.CFDProveedorDataGridView.TabIndex = 1
        '
        'dgMPago
        '
        Me.dgMPago.HeaderText = "MPagoDR"
        Me.dgMPago.Name = "dgMPago"
        '
        'dgMoneda
        '
        Me.dgMoneda.HeaderText = "MonedaDR"
        Me.dgMoneda.Name = "dgMoneda"
        '
        'dgTC
        '
        Me.dgTC.HeaderText = "TCambioDR"
        Me.dgTC.Name = "dgTC"
        '
        'dgMonto
        '
        Me.dgMonto.HeaderText = "MontoDR"
        Me.dgMonto.Name = "dgMonto"
        '
        'XMLSAT
        '
        Me.XMLSAT.DataPropertyName = "CFDOriginal"
        Me.XMLSAT.HeaderText = "XMLSAT"
        Me.XMLSAT.Name = "XMLSAT"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(712, 290)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "RFC"
        Me.DataGridViewTextBoxColumn3.HeaderText = "RFC"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Serie"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "FolioFiscal"
        Me.DataGridViewTextBoxColumn5.HeaderText = "FolioFiscal"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "RazonSocial"
        Me.DataGridViewTextBoxColumn10.HeaderText = "RazonSocial"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Monto"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Monto"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "FechaEmision"
        Me.DataGridViewTextBoxColumn12.HeaderText = "FechaEmision"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "UUID"
        Me.DataGridViewTextBoxColumn28.HeaderText = "UUID"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'CFDProveedorBindingSource
        '
        Me.CFDProveedorBindingSource.DataMember = "vw_GPO_FINAGIL"
        Me.CFDProveedorBindingSource.DataSource = Me.ATEBCOFIDIRECDataSet
        '
        'ATEBCOFIDIRECDataSet
        '
        Me.ATEBCOFIDIRECDataSet.DataSetName = "ATEBCOFIDIRECDataSet"
        Me.ATEBCOFIDIRECDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CFDProveedorTableAdapter
        '
        Me.CFDProveedorTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CFDProveedorTableAdapter = Me.CFDProveedorTableAdapter
        Me.TableAdapterManager.EmpresaTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = CompPagosFilialesV.ATEBCOFIDIRECDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Vw_GPO_FINAGILTableAdapter
        '
        Me.Vw_GPO_FINAGILTableAdapter.ClearBeforeFill = True
        '
        'VwGPOFINAGILBindingSource
        '
        Me.VwGPOFINAGILBindingSource.DataMember = "vw_GPO_FINAGIL"
        Me.VwGPOFINAGILBindingSource.DataSource = Me.ATEBCOFIDIRECDataSet
        '
        'frmUUIDRelC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 325)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.CFDProveedorDataGridView)
        Me.Name = "frmUUIDRelC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUUIDRelC"
        CType(Me.CFDProveedorDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFDProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ATEBCOFIDIRECDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwGPOFINAGILBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ATEBCOFIDIRECDataSet As ATEBCOFIDIRECDataSet
    Friend WithEvents CFDProveedorBindingSource As BindingSource
    Friend WithEvents CFDProveedorTableAdapter As ATEBCOFIDIRECDataSetTableAdapters.CFDProveedorTableAdapter
    Friend WithEvents TableAdapterManager As ATEBCOFIDIRECDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CFDProveedorDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents dgMPago As DataGridViewTextBoxColumn
    Friend WithEvents dgMoneda As DataGridViewTextBoxColumn
    Friend WithEvents dgTC As DataGridViewTextBoxColumn
    Friend WithEvents dgMonto As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents XMLSAT As DataGridViewTextBoxColumn
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Vw_GPO_FINAGILTableAdapter As ATEBCOFIDIRECDataSetTableAdapters.vw_GPO_FINAGILTableAdapter
    Friend WithEvents VwGPOFINAGILBindingSource As BindingSource
End Class
