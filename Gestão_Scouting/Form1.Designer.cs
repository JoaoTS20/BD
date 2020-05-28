using System;

namespace Gestão_Scouting
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxJogadores = new System.Windows.Forms.ListBox();
            this.textJogadorNome = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonEliminarRelatorio = new System.Windows.Forms.Button();
            this.buttonEditarRelatório = new System.Windows.Forms.Button();
            this.AdicionarRelatorio = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxRelatoriosJogador = new System.Windows.Forms.ListBox();
            this.comboBoxListaSelecao = new System.Windows.Forms.ComboBox();
            this.buttonEliminarJogador = new System.Windows.Forms.Button();
            this.buttonEditarJogador = new System.Windows.Forms.Button();
            this.buttonCriarJogadores = new System.Windows.Forms.Button();
            this.radioButtonEsquerdo = new System.Windows.Forms.RadioButton();
            this.radioButtonDireito = new System.Windows.Forms.RadioButton();
            this.textNumeroInter = new System.Windows.Forms.TextBox();
            this.textPeso = new System.Windows.Forms.TextBox();
            this.textJogadorIdade = new System.Windows.Forms.TextBox();
            this.textDuplaNacionalidade = new System.Windows.Forms.TextBox();
            this.textJNome = new System.Windows.Forms.TextBox();
            this.textAltura = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textID_FIFPro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1547, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 24);
            this.toolStripMenuItem1.Text = "Utils";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 26);
            this.toolStripMenuItem2.Text = "Load";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listBoxJogadores
            // 
            this.listBoxJogadores.FormattingEnabled = true;
            this.listBoxJogadores.ItemHeight = 16;
            this.listBoxJogadores.Location = new System.Drawing.Point(8, 108);
            this.listBoxJogadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxJogadores.Name = "listBoxJogadores";
            this.listBoxJogadores.Size = new System.Drawing.Size(333, 644);
            this.listBoxJogadores.TabIndex = 2;
            this.listBoxJogadores.SelectedIndexChanged += new System.EventHandler(this.listBoxJogadores_SelectedIndexChanged_1);
            // 
            // textJogadorNome
            // 
            this.textJogadorNome.Location = new System.Drawing.Point(691, 84);
            this.textJogadorNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textJogadorNome.Name = "textJogadorNome";
            this.textJogadorNome.Size = new System.Drawing.Size(169, 22);
            this.textJogadorNome.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1547, 892);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBoxOrder);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.buttonEliminarRelatorio);
            this.tabPage1.Controls.Add(this.buttonEditarRelatório);
            this.tabPage1.Controls.Add(this.AdicionarRelatorio);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.listBoxRelatoriosJogador);
            this.tabPage1.Controls.Add(this.comboBoxListaSelecao);
            this.tabPage1.Controls.Add(this.buttonEliminarJogador);
            this.tabPage1.Controls.Add(this.buttonEditarJogador);
            this.tabPage1.Controls.Add(this.buttonCriarJogadores);
            this.tabPage1.Controls.Add(this.radioButtonEsquerdo);
            this.tabPage1.Controls.Add(this.radioButtonDireito);
            this.tabPage1.Controls.Add(this.textNumeroInter);
            this.tabPage1.Controls.Add(this.textPeso);
            this.tabPage1.Controls.Add(this.textJogadorIdade);
            this.tabPage1.Controls.Add(this.textDuplaNacionalidade);
            this.tabPage1.Controls.Add(this.textJNome);
            this.tabPage1.Controls.Add(this.textAltura);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textID_FIFPro);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listBoxJogadores);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1539, 863);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jogadores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Location = new System.Drawing.Point(57, 50);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(284, 24);
            this.comboBoxOrder.TabIndex = 31;
            this.comboBoxOrder.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Ordem:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Lista:";
            // 
            // buttonEliminarRelatorio
            // 
            this.buttonEliminarRelatorio.Location = new System.Drawing.Point(789, 418);
            this.buttonEliminarRelatorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEliminarRelatorio.Name = "buttonEliminarRelatorio";
            this.buttonEliminarRelatorio.Size = new System.Drawing.Size(145, 28);
            this.buttonEliminarRelatorio.TabIndex = 28;
            this.buttonEliminarRelatorio.Text = "Eliminar Relatório";
            this.buttonEliminarRelatorio.UseVisualStyleBackColor = true;
            // 
            // buttonEditarRelatório
            // 
            this.buttonEditarRelatório.Location = new System.Drawing.Point(789, 374);
            this.buttonEditarRelatório.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditarRelatório.Name = "buttonEditarRelatório";
            this.buttonEditarRelatório.Size = new System.Drawing.Size(145, 28);
            this.buttonEditarRelatório.TabIndex = 27;
            this.buttonEditarRelatório.Text = "Editar Relatório";
            this.buttonEditarRelatório.UseVisualStyleBackColor = true;
            // 
            // AdicionarRelatorio
            // 
            this.AdicionarRelatorio.Location = new System.Drawing.Point(789, 327);
            this.AdicionarRelatorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdicionarRelatorio.Name = "AdicionarRelatorio";
            this.AdicionarRelatorio.Size = new System.Drawing.Size(145, 28);
            this.AdicionarRelatorio.TabIndex = 26;
            this.AdicionarRelatorio.Text = "Adicionar Relatório";
            this.AdicionarRelatorio.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Relatórios";
            // 
            // listBoxRelatoriosJogador
            // 
            this.listBoxRelatoriosJogador.FormattingEnabled = true;
            this.listBoxRelatoriosJogador.ItemHeight = 16;
            this.listBoxRelatoriosJogador.Location = new System.Drawing.Point(375, 294);
            this.listBoxRelatoriosJogador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxRelatoriosJogador.Name = "listBoxRelatoriosJogador";
            this.listBoxRelatoriosJogador.Size = new System.Drawing.Size(381, 340);
            this.listBoxRelatoriosJogador.TabIndex = 24;
            // 
            // comboBoxListaSelecao
            // 
            this.comboBoxListaSelecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListaSelecao.FormattingEnabled = true;
            this.comboBoxListaSelecao.Location = new System.Drawing.Point(57, 17);
            this.comboBoxListaSelecao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxListaSelecao.Name = "comboBoxListaSelecao";
            this.comboBoxListaSelecao.Size = new System.Drawing.Size(284, 24);
            this.comboBoxListaSelecao.TabIndex = 23;
            this.comboBoxListaSelecao.SelectedIndexChanged += new System.EventHandler(this.comboBoxListaSelecao_SelectedIndexChanged);
            // 
            // buttonEliminarJogador
            // 
            this.buttonEliminarJogador.Location = new System.Drawing.Point(967, 28);
            this.buttonEliminarJogador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEliminarJogador.Name = "buttonEliminarJogador";
            this.buttonEliminarJogador.Size = new System.Drawing.Size(133, 28);
            this.buttonEliminarJogador.TabIndex = 22;
            this.buttonEliminarJogador.Text = "Eliminar Jogador";
            this.buttonEliminarJogador.UseVisualStyleBackColor = true;
            this.buttonEliminarJogador.Click += new System.EventHandler(this.buttonEliminarJogador_Click);
            // 
            // buttonEditarJogador
            // 
            this.buttonEditarJogador.Location = new System.Drawing.Point(789, 28);
            this.buttonEditarJogador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditarJogador.Name = "buttonEditarJogador";
            this.buttonEditarJogador.Size = new System.Drawing.Size(128, 28);
            this.buttonEditarJogador.TabIndex = 21;
            this.buttonEditarJogador.Text = "Editar Jogador";
            this.buttonEditarJogador.UseVisualStyleBackColor = true;
            this.buttonEditarJogador.Click += new System.EventHandler(this.buttonEditarJogador_Click);
            // 
            // buttonCriarJogadores
            // 
            this.buttonCriarJogadores.Location = new System.Drawing.Point(611, 28);
            this.buttonCriarJogadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCriarJogadores.Name = "buttonCriarJogadores";
            this.buttonCriarJogadores.Size = new System.Drawing.Size(128, 28);
            this.buttonCriarJogadores.TabIndex = 20;
            this.buttonCriarJogadores.Text = "Criar Jogadores";
            this.buttonCriarJogadores.UseVisualStyleBackColor = true;
            this.buttonCriarJogadores.Click += new System.EventHandler(this.buttonCriarJogadores_Click);
            // 
            // radioButtonEsquerdo
            // 
            this.radioButtonEsquerdo.AutoSize = true;
            this.radioButtonEsquerdo.Location = new System.Drawing.Point(375, 194);
            this.radioButtonEsquerdo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonEsquerdo.Name = "radioButtonEsquerdo";
            this.radioButtonEsquerdo.Size = new System.Drawing.Size(111, 21);
            this.radioButtonEsquerdo.TabIndex = 19;
            this.radioButtonEsquerdo.TabStop = true;
            this.radioButtonEsquerdo.Text = "Pé Esquerdo";
            this.radioButtonEsquerdo.UseVisualStyleBackColor = true;
            // 
            // radioButtonDireito
            // 
            this.radioButtonDireito.AutoSize = true;
            this.radioButtonDireito.Location = new System.Drawing.Point(375, 167);
            this.radioButtonDireito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonDireito.Name = "radioButtonDireito";
            this.radioButtonDireito.Size = new System.Drawing.Size(91, 21);
            this.radioButtonDireito.TabIndex = 18;
            this.radioButtonDireito.TabStop = true;
            this.radioButtonDireito.Text = "Pé Direito";
            this.radioButtonDireito.UseVisualStyleBackColor = true;
            // 
            // textNumeroInter
            // 
            this.textNumeroInter.Location = new System.Drawing.Point(1203, 112);
            this.textNumeroInter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textNumeroInter.Name = "textNumeroInter";
            this.textNumeroInter.Size = new System.Drawing.Size(100, 22);
            this.textNumeroInter.TabIndex = 17;
            // 
            // textPeso
            // 
            this.textPeso.Location = new System.Drawing.Point(789, 112);
            this.textPeso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPeso.Name = "textPeso";
            this.textPeso.Size = new System.Drawing.Size(87, 22);
            this.textPeso.TabIndex = 16;
            // 
            // textJogadorIdade
            // 
            this.textJogadorIdade.Location = new System.Drawing.Point(909, 112);
            this.textJogadorIdade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textJogadorIdade.Name = "textJogadorIdade";
            this.textJogadorIdade.Size = new System.Drawing.Size(100, 22);
            this.textJogadorIdade.TabIndex = 15;
            // 
            // textDuplaNacionalidade
            // 
            this.textDuplaNacionalidade.Location = new System.Drawing.Point(1052, 112);
            this.textDuplaNacionalidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDuplaNacionalidade.Name = "textDuplaNacionalidade";
            this.textDuplaNacionalidade.Size = new System.Drawing.Size(100, 22);
            this.textDuplaNacionalidade.TabIndex = 14;
            // 
            // textJNome
            // 
            this.textJNome.Location = new System.Drawing.Point(504, 112);
            this.textJNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textJNome.Name = "textJNome";
            this.textJNome.Size = new System.Drawing.Size(143, 22);
            this.textJNome.TabIndex = 13;
            // 
            // textAltura
            // 
            this.textAltura.Location = new System.Drawing.Point(671, 112);
            this.textAltura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textAltura.Name = "textAltura";
            this.textAltura.Size = new System.Drawing.Size(85, 22);
            this.textAltura.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Pé Favorito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1049, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Dupla Nacionalidade";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1200, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Número Internacionalizações";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(907, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Idade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Peso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Altura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // textID_FIFPro
            // 
            this.textID_FIFPro.Location = new System.Drawing.Point(375, 112);
            this.textID_FIFPro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textID_FIFPro.Name = "textID_FIFPro";
            this.textID_FIFPro.Size = new System.Drawing.Size(111, 22);
            this.textID_FIFPro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID FIFPro";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1539, 863);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clubes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1539, 863);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Observadores";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1539, 863);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Competição";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(1539, 863);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gestão";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 922);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textJogadorNome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Gestão Scouting";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ListBox listBoxJogadores;
        private System.Windows.Forms.TextBox textJogadorNome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textID_FIFPro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textNumeroInter;
        private System.Windows.Forms.TextBox textPeso;
        private System.Windows.Forms.TextBox textJogadorIdade;
        private System.Windows.Forms.TextBox textDuplaNacionalidade;
        private System.Windows.Forms.TextBox textJNome;
        private System.Windows.Forms.TextBox textAltura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonEsquerdo;
        private System.Windows.Forms.RadioButton radioButtonDireito;
        private System.Windows.Forms.Button buttonCriarJogadores;
        private System.Windows.Forms.Button buttonEliminarJogador;
        private System.Windows.Forms.Button buttonEditarJogador;
        private System.Windows.Forms.ComboBox comboBoxListaSelecao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBoxRelatoriosJogador;
        private System.Windows.Forms.Button buttonEliminarRelatorio;
        private System.Windows.Forms.Button buttonEditarRelatório;
        private System.Windows.Forms.Button AdicionarRelatorio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.Label label11;
    }
}

