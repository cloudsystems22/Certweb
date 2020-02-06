namespace Certweb
{
    partial class Tarefas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tarefas));
            this.pnFlowLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pnFlowLinks
            // 
            this.pnFlowLinks.AutoScroll = true;
            this.pnFlowLinks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnFlowLinks.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnFlowLinks.Location = new System.Drawing.Point(16, 79);
            this.pnFlowLinks.Name = "pnFlowLinks";
            this.pnFlowLinks.Size = new System.Drawing.Size(640, 519);
            this.pnFlowLinks.TabIndex = 6;
            this.pnFlowLinks.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "Links";
            // 
            // btnExecutar
            // 
            this.btnExecutar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExecutar.BackgroundImage")));
            this.btnExecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExecutar.FlatAppearance.BorderSize = 0;
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Location = new System.Drawing.Point(712, 158);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(212, 212);
            this.btnExecutar.TabIndex = 7;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Fuchsia;
            this.progressBar1.Location = new System.Drawing.Point(712, 449);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // Tarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.pnFlowLinks);
            this.Controls.Add(this.label1);
            this.Name = "Tarefas";
            this.Size = new System.Drawing.Size(981, 617);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnFlowLinks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
