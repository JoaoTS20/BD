namespace Gestão_Scouting
{
    partial class UpdateCompeticao
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonUpdateCompeticao = new System.Windows.Forms.Button();
            this.textBoxNumero = new System.Windows.Forms.TextBox();
            this.textBoxNomeComp = new System.Windows.Forms.TextBox();
            this.textBoxIDcomp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(44, 211);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 15;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonUpdateCompeticao
            // 
            this.buttonUpdateCompeticao.Location = new System.Drawing.Point(208, 211);
            this.buttonUpdateCompeticao.Name = "buttonUpdateCompeticao";
            this.buttonUpdateCompeticao.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateCompeticao.TabIndex = 14;
            this.buttonUpdateCompeticao.Text = "Editar Competicao";
            this.buttonUpdateCompeticao.UseVisualStyleBackColor = true;
            // 
            // textBoxNumero
            // 
            this.textBoxNumero.Location = new System.Drawing.Point(21, 149);
            this.textBoxNumero.Name = "textBoxNumero";
            this.textBoxNumero.Size = new System.Drawing.Size(128, 22);
            this.textBoxNumero.TabIndex = 13;
            // 
            // textBoxNomeComp
            // 
            this.textBoxNomeComp.Location = new System.Drawing.Point(21, 94);
            this.textBoxNomeComp.Name = "textBoxNomeComp";
            this.textBoxNomeComp.Size = new System.Drawing.Size(128, 22);
            this.textBoxNomeComp.TabIndex = 12;
            // 
            // textBoxIDcomp
            // 
            this.textBoxIDcomp.Location = new System.Drawing.Point(24, 40);
            this.textBoxIDcomp.Name = "textBoxIDcomp";
            this.textBoxIDcomp.Size = new System.Drawing.Size(128, 22);
            this.textBoxIDcomp.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Número de Equipas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Competição ID FIFA";
            // 
            // UpdateCompeticao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 246);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonUpdateCompeticao);
            this.Controls.Add(this.textBoxNumero);
            this.Controls.Add(this.textBoxNomeComp);
            this.Controls.Add(this.textBoxIDcomp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateCompeticao";
            this.Text = "UpdateCompeticao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonUpdateCompeticao;
        private System.Windows.Forms.TextBox textBoxNumero;
        private System.Windows.Forms.TextBox textBoxNomeComp;
        private System.Windows.Forms.TextBox textBoxIDcomp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}