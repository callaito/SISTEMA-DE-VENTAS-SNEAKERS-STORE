namespace SNEAKERS_STORES_VENTA
{
    partial class ReporteCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCliente));
            this.sPCONSULTARclienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemventasDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistem_ventasDataSet = new SNEAKERS_STORES_VENTA.sistem_ventasDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sP_CONSULTAR_clienteTableAdapter = new SNEAKERS_STORES_VENTA.sistem_ventasDataSetTableAdapters.SP_CONSULTAR_clienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARclienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemventasDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistem_ventasDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sPCONSULTARclienteBindingSource
            // 
            this.sPCONSULTARclienteBindingSource.DataMember = "SP_CONSULTAR_cliente";
            this.sPCONSULTARclienteBindingSource.DataSource = this.sistemventasDataSetBindingSource;
            // 
            // sistemventasDataSetBindingSource
            // 
            this.sistemventasDataSetBindingSource.DataSource = this.sistem_ventasDataSet;
            this.sistemventasDataSetBindingSource.Position = 0;
            // 
            // sistem_ventasDataSet
            // 
            this.sistem_ventasDataSet.DataSetName = "sistem_ventasDataSet";
            this.sistem_ventasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPCONSULTARclienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNEAKERS_STORES_VENTA.ReporteCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sP_CONSULTAR_clienteTableAdapter
            // 
            this.sP_CONSULTAR_clienteTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteCliente";
            this.Text = "ReporteCliente";
            this.Load += new System.EventHandler(this.ReporteCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARclienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemventasDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistem_ventasDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private sistem_ventasDataSet sistem_ventasDataSet;
        private System.Windows.Forms.BindingSource sistemventasDataSetBindingSource;
        private System.Windows.Forms.BindingSource sPCONSULTARclienteBindingSource;
        private sistem_ventasDataSetTableAdapters.SP_CONSULTAR_clienteTableAdapter sP_CONSULTAR_clienteTableAdapter;
    }
}