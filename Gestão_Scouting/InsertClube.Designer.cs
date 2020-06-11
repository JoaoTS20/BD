namespace Gestão_Scouting
{
    partial class InsertClube
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
            this.buttonInserirClube = new System.Windows.Forms.Button();
            this.textBoxClubeNome = new System.Windows.Forms.TextBox();
            this.textBoxClubePais = new System.Windows.Forms.TextBox();
            this.textBoxNumeroInscricaoFifaClube = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInserirClube
            // 
            this.buttonInserirClube.Location = new System.Drawing.Point(113, 124);
            this.buttonInserirClube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInserirClube.Name = "buttonInserirClube";
            this.buttonInserirClube.Size = new System.Drawing.Size(128, 28);
            this.buttonInserirClube.TabIndex = 35;
            this.buttonInserirClube.Text = "Inserir Clube";
            this.buttonInserirClube.UseVisualStyleBackColor = true;
            this.buttonInserirClube.Click += new System.EventHandler(this.buttonDeleteClube_Click);
            // 
            // textBoxClubeNome
            // 
            this.textBoxClubeNome.Location = new System.Drawing.Point(379, 42);
            this.textBoxClubeNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClubeNome.Name = "textBoxClubeNome";
            this.textBoxClubeNome.Size = new System.Drawing.Size(157, 22);
            this.textBoxClubeNome.TabIndex = 32;
            this.textBoxClubeNome.TextChanged += new System.EventHandler(this.textBoxClubeNome_TextChanged);
            // 
            // textBoxClubePais
            // 
            this.textBoxClubePais.Location = new System.Drawing.Point(209, 42);
            this.textBoxClubePais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClubePais.Name = "textBoxClubePais";
            this.textBoxClubePais.Size = new System.Drawing.Size(150, 22);
            this.textBoxClubePais.TabIndex = 31;
            this.textBoxClubePais.TextChanged += new System.EventHandler(this.textBoxClubePais_TextChanged);
            // 
            // textBoxNumeroInscricaoFifaClube
            // 
            this.textBoxNumeroInscricaoFifaClube.Location = new System.Drawing.Point(15, 42);
            this.textBoxNumeroInscricaoFifaClube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumeroInscricaoFifaClube.Name = "textBoxNumeroInscricaoFifaClube";
            this.textBoxNumeroInscricaoFifaClube.Size = new System.Drawing.Size(167, 22);
            this.textBoxNumeroInscricaoFifaClube.TabIndex = 30;
            this.textBoxNumeroInscricaoFifaClube.TextChanged += new System.EventHandler(this.textBoxNumeroInscricaoFifaClube_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(206, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 17);
            this.label19.TabIndex = 28;
            this.label19.Text = "País";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(376, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 26;
            this.label17.Text = "Nome";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "Número de Inscrição FIFA";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 36;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InsertClube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 177);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonInserirClube);
            this.Controls.Add(this.textBoxClubeNome);
            this.Controls.Add(this.textBoxClubePais);
            this.Controls.Add(this.textBoxNumeroInscricaoFifaClube);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Name = "InsertClube";
            this.Text = "InsertClube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInserirClube;
        private System.Windows.Forms.TextBox textBoxClubeNome;
        private System.Windows.Forms.TextBox textBoxClubePais;
        private System.Windows.Forms.TextBox textBoxNumeroInscricaoFifaClube;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
    }
}