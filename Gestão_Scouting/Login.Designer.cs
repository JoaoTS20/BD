namespace Gestão_Scouting
{
    partial class Login
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SelecionadorCriarButton = new System.Windows.Forms.Button();
            this.CreateObservadorButton = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(60, 304);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(90, 23);
            this.ConfirmButton.TabIndex = 26;
            this.ConfirmButton.Text = "Confirmar";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Criar Conta";
            // 
            // SelecionadorCriarButton
            // 
            this.SelecionadorCriarButton.Location = new System.Drawing.Point(320, 235);
            this.SelecionadorCriarButton.Name = "SelecionadorCriarButton";
            this.SelecionadorCriarButton.Size = new System.Drawing.Size(90, 23);
            this.SelecionadorCriarButton.TabIndex = 24;
            this.SelecionadorCriarButton.Text = "Selecionador";
            this.SelecionadorCriarButton.UseVisualStyleBackColor = true;
            // 
            // CreateObservadorButton
            // 
            this.CreateObservadorButton.Location = new System.Drawing.Point(320, 166);
            this.CreateObservadorButton.Name = "CreateObservadorButton";
            this.CreateObservadorButton.Size = new System.Drawing.Size(90, 23);
            this.CreateObservadorButton.TabIndex = 23;
            this.CreateObservadorButton.Text = "Observador";
            this.CreateObservadorButton.UseVisualStyleBackColor = true;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(60, 235);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 22;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(60, 169);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameBox.TabIndex = 21;
            this.UserNameBox.TextChanged += new System.EventHandler(this.UserNameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nome de Utilizador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Login";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 450);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelecionadorCriarButton);
            this.Controls.Add(this.CreateObservadorButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelecionadorCriarButton;
        private System.Windows.Forms.Button CreateObservadorButton;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}