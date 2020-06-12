namespace Gestão_Scouting
{
    partial class InsertJogo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxCompID = new System.Windows.Forms.TextBox();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.Resultado = new System.Windows.Forms.Label();
            this.textBoxResultado = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.comboBoxObservadoresList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxObservadores = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxConvocados = new System.Windows.Forms.TextBox();
            this.listBoxCompeticaoClubes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Competição ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Local:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(61, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(196, 22);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBoxCompID
            // 
            this.textBoxCompID.Location = new System.Drawing.Point(113, 23);
            this.textBoxCompID.Name = "textBoxCompID";
            this.textBoxCompID.Size = new System.Drawing.Size(144, 22);
            this.textBoxCompID.TabIndex = 4;
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(61, 98);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(196, 22);
            this.textBoxLocal.TabIndex = 5;
            // 
            // Resultado
            // 
            this.Resultado.AutoSize = true;
            this.Resultado.Location = new System.Drawing.Point(12, 141);
            this.Resultado.Name = "Resultado";
            this.Resultado.Size = new System.Drawing.Size(76, 17);
            this.Resultado.TabIndex = 6;
            this.Resultado.Text = "Resultado:";
            // 
            // textBoxResultado
            // 
            this.textBoxResultado.Location = new System.Drawing.Point(86, 141);
            this.textBoxResultado.Name = "textBoxResultado";
            this.textBoxResultado.Size = new System.Drawing.Size(171, 22);
            this.textBoxResultado.TabIndex = 7;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(40, 400);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(198, 400);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(87, 23);
            this.buttonInserir.TabIndex = 9;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // comboBoxObservadoresList
            // 
            this.comboBoxObservadoresList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObservadoresList.FormattingEnabled = true;
            this.comboBoxObservadoresList.Location = new System.Drawing.Point(440, 19);
            this.comboBoxObservadoresList.Name = "comboBoxObservadoresList";
            this.comboBoxObservadoresList.Size = new System.Drawing.Size(235, 24);
            this.comboBoxObservadoresList.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ordenar:";
            // 
            // listBoxObservadores
            // 
            this.listBoxObservadores.FormattingEnabled = true;
            this.listBoxObservadores.ItemHeight = 16;
            this.listBoxObservadores.Location = new System.Drawing.Point(383, 68);
            this.listBoxObservadores.Name = "listBoxObservadores";
            this.listBoxObservadores.Size = new System.Drawing.Size(292, 180);
            this.listBoxObservadores.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Jogadores Convocados:";
            // 
            // textBoxConvocados
            // 
            this.textBoxConvocados.Location = new System.Drawing.Point(185, 349);
            this.textBoxConvocados.Name = "textBoxConvocados";
            this.textBoxConvocados.Size = new System.Drawing.Size(138, 22);
            this.textBoxConvocados.TabIndex = 14;
            // 
            // listBoxCompeticaoClubes
            // 
            this.listBoxCompeticaoClubes.FormattingEnabled = true;
            this.listBoxCompeticaoClubes.ItemHeight = 16;
            this.listBoxCompeticaoClubes.Location = new System.Drawing.Point(20, 195);
            this.listBoxCompeticaoClubes.Name = "listBoxCompeticaoClubes";
            this.listBoxCompeticaoClubes.Size = new System.Drawing.Size(265, 148);
            this.listBoxCompeticaoClubes.TabIndex = 15;
            // 
            // InsertJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 477);
            this.Controls.Add(this.listBoxCompeticaoClubes);
            this.Controls.Add(this.textBoxConvocados);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxObservadores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxObservadoresList);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.textBoxResultado);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.textBoxCompID);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InsertJogo";
            this.Text = "InsertJogo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxCompID;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.Label Resultado;
        private System.Windows.Forms.TextBox textBoxResultado;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.ComboBox comboBoxObservadoresList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxObservadores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxConvocados;
        private System.Windows.Forms.ListBox listBoxCompeticaoClubes;
    }
}