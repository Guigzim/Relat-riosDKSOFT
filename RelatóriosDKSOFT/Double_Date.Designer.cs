namespace RelatóriosDKSOFT
{
    partial class Double_Date
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_Inicial = new System.Windows.Forms.DateTimePicker();
            this.dtp_Final = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Final";
            // 
            // dtp_Inicial
            // 
            this.dtp_Inicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Inicial.Location = new System.Drawing.Point(4, 28);
            this.dtp_Inicial.Name = "dtp_Inicial";
            this.dtp_Inicial.Size = new System.Drawing.Size(101, 20);
            this.dtp_Inicial.TabIndex = 2;
            this.dtp_Inicial.ValueChanged += new System.EventHandler(this.Dtp_Inicial_ValueChanged);
            // 
            // dtp_Final
            // 
            this.dtp_Final.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Final.Location = new System.Drawing.Point(111, 27);
            this.dtp_Final.Name = "dtp_Final";
            this.dtp_Final.Size = new System.Drawing.Size(101, 20);
            this.dtp_Final.TabIndex = 3;
            this.dtp_Final.ValueChanged += new System.EventHandler(this.Dtp_Final_ValueChanged);
            // 
            // Double_Date
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtp_Final);
            this.Controls.Add(this.dtp_Inicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Double_Date";
            this.Size = new System.Drawing.Size(220, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_Inicial;
        private System.Windows.Forms.DateTimePicker dtp_Final;
    }
}
