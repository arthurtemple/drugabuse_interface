namespace DrugAbuse
{
    partial class PdfViewer
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewer));
            this.acrobatViewer = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.acrobatViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // acrobatViewer
            // 
            this.acrobatViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acrobatViewer.Enabled = true;
            this.acrobatViewer.Location = new System.Drawing.Point(0, 0);
            this.acrobatViewer.Name = "acrobatViewer";
            this.acrobatViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("acrobatViewer.OcxState")));
            this.acrobatViewer.Size = new System.Drawing.Size(150, 150);
            this.acrobatViewer.TabIndex = 0;
            this.acrobatViewer.Visible = true;
            // 
            // PdfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.acrobatViewer);
            this.Name = "PdfViewer";
            ((System.ComponentModel.ISupportInitialize)(this.acrobatViewer)).EndInit();
            this.ResumeLayout(false);
            this.Visible = true;

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF acrobatViewer;
    }
}
