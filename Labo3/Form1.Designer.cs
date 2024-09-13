namespace Labo3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            algorithme = new ComboBox();
            cles = new TextBox();
            label1 = new Label();
            label2 = new Label();
            texteTransforme = new TextBox();
            texteUtilisateur = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // algorithme
            // 
            algorithme.FormattingEnabled = true;
            algorithme.Items.AddRange(new object[] { "Aucun", "TripleDES", "AES", "DSA", "RSA" });
            algorithme.Location = new Point(115, 99);
            algorithme.Name = "algorithme";
            algorithme.Size = new Size(345, 28);
            algorithme.TabIndex = 0;
            algorithme.SelectedIndexChanged += algorithme_SelectedIndexChanged;
            // 
            // cles
            // 
            cles.Location = new Point(115, 183);
            cles.Multiline = true;
            cles.Name = "cles";
            cles.Size = new Size(345, 289);
            cles.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 76);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 2;
            label1.Text = "Algorythme";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 160);
            label2.Name = "label2";
            label2.Size = new Size(30, 20);
            label2.TabIndex = 3;
            label2.Text = "Clé";
            // 
            // texteTransforme
            // 
            texteTransforme.Location = new Point(527, 265);
            texteTransforme.Multiline = true;
            texteTransforme.Name = "texteTransforme";
            texteTransforme.Size = new Size(316, 142);
            texteTransforme.TabIndex = 4;
            // 
            // texteUtilisateur
            // 
            texteUtilisateur.Location = new Point(528, 99);
            texteUtilisateur.Multiline = true;
            texteUtilisateur.Name = "texteUtilisateur";
            texteUtilisateur.Size = new Size(315, 140);
            texteUtilisateur.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(631, 76);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 6;
            label3.Text = "texte Utilisateur";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(624, 242);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 7;
            label4.Text = "texte Transforme";
            // 
            // button1
            // 
            button1.Location = new Point(578, 443);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "chiffrer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += chiffrer_Click;
            // 
            // button2
            // 
            button2.Location = new Point(717, 443);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "déchiffrer";
            button2.UseVisualStyleBackColor = true;
            button2.Click += dechiffrer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 577);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(texteUtilisateur);
            Controls.Add(texteTransforme);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cles);
            Controls.Add(algorithme);
            Name = "Form1";
            Text = "i";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox algorithme;
        private TextBox cles;
        private Label label1;
        private Label label2;
        private TextBox texteTransforme;
        private TextBox texteUtilisateur;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
    }
}
