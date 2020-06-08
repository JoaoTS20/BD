namespace Gestão_Scouting
{
    partial class EditarJogador
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
            this.comboBoxListas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PeFav = new System.Windows.Forms.GroupBox();
            this.radPeEsq = new System.Windows.Forms.RadioButton();
            this.radPeDir = new System.Windows.Forms.RadioButton();
            this.DupNac = new System.Windows.Forms.GroupBox();
            this.radDupNao = new System.Windows.Forms.RadioButton();
            this.radDupSim = new System.Windows.Forms.RadioButton();
            this.Cancelar = new System.Windows.Forms.Button();
            this.bbtEditar = new System.Windows.Forms.Button();
            this.NumInter = new System.Windows.Forms.Label();
            this.textBoxNumeroInter = new System.Windows.Forms.TextBox();
            this.TextBoxIdade = new System.Windows.Forms.TextBox();
            this.Idade = new System.Windows.Forms.Label();
            this.Altura = new System.Windows.Forms.Label();
            this.Peso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_FIFPro = new System.Windows.Forms.Label();
            this.TextBoxNome = new System.Windows.Forms.TextBox();
            this.TextBoxAltura = new System.Windows.Forms.TextBox();
            this.textBoxPeso = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.PeFav.SuspendLayout();
            this.DupNac.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxListas
            // 
            this.comboBoxListas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListas.FormattingEnabled = true;
            this.comboBoxListas.Location = new System.Drawing.Point(137, 287);
            this.comboBoxListas.Name = "comboBoxListas";
            this.comboBoxListas.Size = new System.Drawing.Size(213, 24);
            this.comboBoxListas.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Lista de Seleção ";
            // 
            // PeFav
            // 
            this.PeFav.Controls.Add(this.radPeEsq);
            this.PeFav.Controls.Add(this.radPeDir);
            this.PeFav.Location = new System.Drawing.Point(475, 363);
            this.PeFav.Margin = new System.Windows.Forms.Padding(4);
            this.PeFav.Name = "PeFav";
            this.PeFav.Padding = new System.Windows.Forms.Padding(4);
            this.PeFav.Size = new System.Drawing.Size(169, 105);
            this.PeFav.TabIndex = 39;
            this.PeFav.TabStop = false;
            this.PeFav.Text = "Pé Favorito";
            // 
            // radPeEsq
            // 
            this.radPeEsq.AutoSize = true;
            this.radPeEsq.Location = new System.Drawing.Point(8, 52);
            this.radPeEsq.Margin = new System.Windows.Forms.Padding(4);
            this.radPeEsq.Name = "radPeEsq";
            this.radPeEsq.Size = new System.Drawing.Size(90, 21);
            this.radPeEsq.TabIndex = 3;
            this.radPeEsq.TabStop = true;
            this.radPeEsq.Text = "Esquerdo";
            this.radPeEsq.UseVisualStyleBackColor = true;
            // 
            // radPeDir
            // 
            this.radPeDir.AutoSize = true;
            this.radPeDir.Location = new System.Drawing.Point(8, 23);
            this.radPeDir.Margin = new System.Windows.Forms.Padding(4);
            this.radPeDir.Name = "radPeDir";
            this.radPeDir.Size = new System.Drawing.Size(70, 21);
            this.radPeDir.TabIndex = 2;
            this.radPeDir.TabStop = true;
            this.radPeDir.Text = "Direito";
            this.radPeDir.UseVisualStyleBackColor = true;
            // 
            // DupNac
            // 
            this.DupNac.Controls.Add(this.radDupNao);
            this.DupNac.Controls.Add(this.radDupSim);
            this.DupNac.Location = new System.Drawing.Point(138, 363);
            this.DupNac.Margin = new System.Windows.Forms.Padding(4);
            this.DupNac.Name = "DupNac";
            this.DupNac.Padding = new System.Windows.Forms.Padding(4);
            this.DupNac.Size = new System.Drawing.Size(169, 105);
            this.DupNac.TabIndex = 38;
            this.DupNac.TabStop = false;
            this.DupNac.Text = "Dupla Nacionalidade";
            // 
            // radDupNao
            // 
            this.radDupNao.AutoSize = true;
            this.radDupNao.Location = new System.Drawing.Point(8, 52);
            this.radDupNao.Margin = new System.Windows.Forms.Padding(4);
            this.radDupNao.Name = "radDupNao";
            this.radDupNao.Size = new System.Drawing.Size(55, 21);
            this.radDupNao.TabIndex = 1;
            this.radDupNao.TabStop = true;
            this.radDupNao.Text = "Não";
            this.radDupNao.UseVisualStyleBackColor = true;
            // 
            // radDupSim
            // 
            this.radDupSim.AutoSize = true;
            this.radDupSim.Location = new System.Drawing.Point(8, 23);
            this.radDupSim.Margin = new System.Windows.Forms.Padding(4);
            this.radDupSim.Name = "radDupSim";
            this.radDupSim.Size = new System.Drawing.Size(52, 21);
            this.radDupSim.TabIndex = 0;
            this.radDupSim.TabStop = true;
            this.radDupSim.Text = "Sim";
            this.radDupSim.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(227, 492);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(100, 28);
            this.Cancelar.TabIndex = 37;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // bbtEditar
            // 
            this.bbtEditar.Location = new System.Drawing.Point(446, 492);
            this.bbtEditar.Margin = new System.Windows.Forms.Padding(4);
            this.bbtEditar.Name = "bbtEditar";
            this.bbtEditar.Size = new System.Drawing.Size(142, 28);
            this.bbtEditar.TabIndex = 36;
            this.bbtEditar.Text = "Editar Jogador";
            this.bbtEditar.UseVisualStyleBackColor = true;
            this.bbtEditar.Click += new System.EventHandler(this.bbtEditar_Click);
            // 
            // NumInter
            // 
            this.NumInter.AutoSize = true;
            this.NumInter.Location = new System.Drawing.Point(407, 186);
            this.NumInter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumInter.Name = "NumInter";
            this.NumInter.Size = new System.Drawing.Size(211, 17);
            this.NumInter.TabIndex = 35;
            this.NumInter.Text = "Número de Internacionalizações";
            // 
            // textBoxNumeroInter
            // 
            this.textBoxNumeroInter.Location = new System.Drawing.Point(410, 207);
            this.textBoxNumeroInter.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNumeroInter.Name = "textBoxNumeroInter";
            this.textBoxNumeroInter.Size = new System.Drawing.Size(207, 22);
            this.textBoxNumeroInter.TabIndex = 34;
            // 
            // TextBoxIdade
            // 
            this.TextBoxIdade.Location = new System.Drawing.Point(410, 137);
            this.TextBoxIdade.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxIdade.Name = "TextBoxIdade";
            this.TextBoxIdade.Size = new System.Drawing.Size(132, 22);
            this.TextBoxIdade.TabIndex = 33;
            // 
            // Idade
            // 
            this.Idade.AutoSize = true;
            this.Idade.Location = new System.Drawing.Point(407, 116);
            this.Idade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Idade.Name = "Idade";
            this.Idade.Size = new System.Drawing.Size(43, 17);
            this.Idade.TabIndex = 32;
            this.Idade.Text = "Idade";
            // 
            // Altura
            // 
            this.Altura.AutoSize = true;
            this.Altura.Location = new System.Drawing.Point(135, 186);
            this.Altura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Altura.Name = "Altura";
            this.Altura.Size = new System.Drawing.Size(45, 17);
            this.Altura.TabIndex = 31;
            this.Altura.Text = "Altura";
            // 
            // Peso
            // 
            this.Peso.AutoSize = true;
            this.Peso.Location = new System.Drawing.Point(407, 49);
            this.Peso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(40, 17);
            this.Peso.TabIndex = 30;
            this.Peso.Text = "Peso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Nome";
            // 
            // ID_FIFPro
            // 
            this.ID_FIFPro.AutoSize = true;
            this.ID_FIFPro.Location = new System.Drawing.Point(134, 49);
            this.ID_FIFPro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ID_FIFPro.Name = "ID_FIFPro";
            this.ID_FIFPro.Size = new System.Drawing.Size(70, 17);
            this.ID_FIFPro.TabIndex = 28;
            this.ID_FIFPro.Text = "ID_FIFPro";
            // 
            // TextBoxNome
            // 
            this.TextBoxNome.Location = new System.Drawing.Point(137, 137);
            this.TextBoxNome.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxNome.Name = "TextBoxNome";
            this.TextBoxNome.Size = new System.Drawing.Size(213, 22);
            this.TextBoxNome.TabIndex = 27;
            // 
            // TextBoxAltura
            // 
            this.TextBoxAltura.Location = new System.Drawing.Point(137, 207);
            this.TextBoxAltura.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxAltura.Name = "TextBoxAltura";
            this.TextBoxAltura.Size = new System.Drawing.Size(77, 22);
            this.TextBoxAltura.TabIndex = 26;
            // 
            // textBoxPeso
            // 
            this.textBoxPeso.Location = new System.Drawing.Point(410, 69);
            this.textBoxPeso.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPeso.Name = "textBoxPeso";
            this.textBoxPeso.Size = new System.Drawing.Size(132, 22);
            this.textBoxPeso.TabIndex = 25;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(138, 69);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(213, 22);
            this.textBoxID.TabIndex = 24;
            // 
            // EditarJogador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 568);
            this.Controls.Add(this.comboBoxListas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PeFav);
            this.Controls.Add(this.DupNac);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.bbtEditar);
            this.Controls.Add(this.NumInter);
            this.Controls.Add(this.textBoxNumeroInter);
            this.Controls.Add(this.TextBoxIdade);
            this.Controls.Add(this.Idade);
            this.Controls.Add(this.Altura);
            this.Controls.Add(this.Peso);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID_FIFPro);
            this.Controls.Add(this.TextBoxNome);
            this.Controls.Add(this.TextBoxAltura);
            this.Controls.Add(this.textBoxPeso);
            this.Controls.Add(this.textBoxID);
            this.Name = "EditarJogador";
            this.Text = "EditarJogador";
            this.PeFav.ResumeLayout(false);
            this.PeFav.PerformLayout();
            this.DupNac.ResumeLayout(false);
            this.DupNac.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxListas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox PeFav;
        private System.Windows.Forms.RadioButton radPeEsq;
        private System.Windows.Forms.RadioButton radPeDir;
        private System.Windows.Forms.GroupBox DupNac;
        private System.Windows.Forms.RadioButton radDupNao;
        private System.Windows.Forms.RadioButton radDupSim;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button bbtEditar;
        private System.Windows.Forms.Label NumInter;
        private System.Windows.Forms.TextBox textBoxNumeroInter;
        private System.Windows.Forms.TextBox TextBoxIdade;
        private System.Windows.Forms.Label Idade;
        private System.Windows.Forms.Label Altura;
        private System.Windows.Forms.Label Peso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID_FIFPro;
        private System.Windows.Forms.TextBox TextBoxNome;
        private System.Windows.Forms.TextBox TextBoxAltura;
        private System.Windows.Forms.TextBox textBoxPeso;
        private System.Windows.Forms.TextBox textBoxID;
    }
}