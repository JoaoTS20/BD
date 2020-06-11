namespace Gestão_Scouting
{
    partial class UpdateClube
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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEditClube = new System.Windows.Forms.Button();
            this.textBoxClubeNome = new System.Windows.Forms.TextBox();
            this.textBoxClubePais = new System.Windows.Forms.TextBox();
            this.textBoxNumeroInscricaoFifaClube = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 148);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 44;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEditClube
            // 
            this.buttonEditClube.Location = new System.Drawing.Point(147, 148);
            this.buttonEditClube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditClube.Name = "buttonEditClube";
            this.buttonEditClube.Size = new System.Drawing.Size(128, 28);
            this.buttonEditClube.TabIndex = 43;
            this.buttonEditClube.Text = "Editar Clube";
            this.buttonEditClube.UseVisualStyleBackColor = true;
            this.buttonEditClube.Click += new System.EventHandler(this.buttonEditClube_Click);
            // 
            // textBoxClubeNome
            // 
            this.textBoxClubeNome.Location = new System.Drawing.Point(413, 66);
            this.textBoxClubeNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClubeNome.Name = "textBoxClubeNome";
            this.textBoxClubeNome.Size = new System.Drawing.Size(157, 22);
            this.textBoxClubeNome.TabIndex = 42;
            // 
            // textBoxClubePais
            // 
            this.textBoxClubePais.Location = new System.Drawing.Point(243, 66);
            this.textBoxClubePais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClubePais.Name = "textBoxClubePais";
            this.textBoxClubePais.Size = new System.Drawing.Size(150, 22);
            this.textBoxClubePais.TabIndex = 41;
            // 
            // textBoxNumeroInscricaoFifaClube
            // 
            this.textBoxNumeroInscricaoFifaClube.Location = new System.Drawing.Point(49, 66);
            this.textBoxNumeroInscricaoFifaClube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumeroInscricaoFifaClube.Name = "textBoxNumeroInscricaoFifaClube";
            this.textBoxNumeroInscricaoFifaClube.Size = new System.Drawing.Size(167, 22);
            this.textBoxNumeroInscricaoFifaClube.TabIndex = 40;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(240, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 17);
            this.label19.TabIndex = 39;
            this.label19.Text = "País";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(410, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 38;
            this.label17.Text = "Nome";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(46, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 17);
            this.label15.TabIndex = 37;
            this.label15.Text = "Número de Inscrição FIFA";
            // 
            // UpdateClube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 220);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEditClube);
            this.Controls.Add(this.textBoxClubeNome);
            this.Controls.Add(this.textBoxClubePais);
            this.Controls.Add(this.textBoxNumeroInscricaoFifaClube);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Name = "UpdateClube";
            this.Text = "UpdateClube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonEditClube;
        private System.Windows.Forms.TextBox textBoxClubeNome;
        private System.Windows.Forms.TextBox textBoxClubePais;
        private System.Windows.Forms.TextBox textBoxNumeroInscricaoFifaClube;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
    }
}