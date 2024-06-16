namespace SNEAKERS_STORES_VENTA
{
    partial class ReporteInventario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteInventario));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sistem_ventasDataSet = new SNEAKERS_STORES_VENTA.sistem_ventasDataSet();
            this.sPCONSULTARinventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_CONSULTAR_inventarioTableAdapter = new SNEAKERS_STORES_VENTA.sistem_ventasDataSetTableAdapters.SP_CONSULTAR_inventarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sistem_ventasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARinventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.sPCONSULTARinventarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SNEAKERS_STORES_VENTA.ReportInventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // sistem_ventasDataSet
            // 
            this.sistem_ventasDataSet.DataSetName = "sistem_ventasDataSet";
            this.sistem_ventasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPCONSULTARinventarioBindingSource
            // 
            this.sPCONSULTARinventarioBindingSource.DataMember = "SP_CONSULTAR_inventario";
            this.sPCONSULTARinventarioBindingSource.DataSource = this.sistem_ventasDataSet;
            // 
            // sP_CONSULTAR_inventarioTableAdapter
            // 
            this.sP_CONSULTAR_inventarioTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteInventario";
            this.Text = "ReporteInventario";
            this.Load += new System.EventHandler(this.ReporteInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistem_ventasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPCONSULTARinventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private sistem_ventasDataSet sistem_ventasDataSet;
        private System.Windows.Forms.BindingSource sPCONSULTARinventarioBindingSource;
        private sistem_ventasDataSetTableAdapters.SP_CONSULTAR_inventarioTableAdapter sP_CONSULTAR_inventarioTableAdapter;
    }
}