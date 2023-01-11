
namespace app
{
    partial class AjouterFournisseur
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
            this.lbltitre = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.ville = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.adr = new System.Windows.Forms.TextBox();
            this.nom = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.prenom = new System.Windows.Forms.Label();
            this.tel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbltitre
            // 
            this.lbltitre.AutoSize = true;
            this.lbltitre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbltitre.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitre.ForeColor = System.Drawing.Color.Lavender;
            this.lbltitre.Location = new System.Drawing.Point(6, 42);
            this.lbltitre.Name = "lbltitre";
            this.lbltitre.Size = new System.Drawing.Size(387, 47);
            this.lbltitre.TabIndex = 157;
            this.lbltitre.Text = "Ajouter Fournisseur";
            // 
            // btnModifier
            // 
            this.btnModifier.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(14, 414);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(223, 34);
            this.btnModifier.TabIndex = 154;
            this.btnModifier.Text = "Actualiser";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click_1);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(329, 414);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(220, 34);
            this.btnAjouter.TabIndex = 155;
            this.btnAjouter.Text = "Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click_1);
            // 
            // ville
            // 
            this.ville.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ville.Location = new System.Drawing.Point(248, 305);
            this.ville.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ville.Name = "ville";
            this.ville.Size = new System.Drawing.Size(301, 22);
            this.ville.TabIndex = 148;
            // 
            // phone
            // 
            this.phone.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.phone.Location = new System.Drawing.Point(248, 259);
            this.phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(301, 22);
            this.phone.TabIndex = 149;
            // 
            // adr
            // 
            this.adr.Location = new System.Drawing.Point(248, 215);
            this.adr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adr.Name = "adr";
            this.adr.Size = new System.Drawing.Size(301, 22);
            this.adr.TabIndex = 152;
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(248, 172);
            this.nom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(301, 22);
            this.nom.TabIndex = 153;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.email.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(10, 305);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(58, 23);
            this.email.TabIndex = 143;
            this.email.Text = "Ville:";
            // 
            // prenom
            // 
            this.prenom.AutoSize = true;
            this.prenom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prenom.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenom.Location = new System.Drawing.Point(10, 215);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(94, 23);
            this.prenom.TabIndex = 146;
            this.prenom.Text = "Adresse:";
            // 
            // tel
            // 
            this.tel.AutoSize = true;
            this.tel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tel.Location = new System.Drawing.Point(10, 259);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(118, 23);
            this.tel.TabIndex = 142;
            this.tel.Text = "Telephone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 147;
            this.label2.Text = "Nom:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 562);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(571, 6);
            this.panel3.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 6);
            this.panel1.TabIndex = 140;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Image = global::app.Properties.Resources.Button_Delete_icon2;
            this.button2.Location = new System.Drawing.Point(533, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 22);
            this.button2.TabIndex = 156;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AjouterFournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(571, 568);
            this.Controls.Add(this.lbltitre);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.ville);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.adr);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.email);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterFournisseur";
            this.Text = "AjouterFournisseur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbltitre;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnModifier;
        public System.Windows.Forms.Button btnAjouter;
        public System.Windows.Forms.TextBox ville;
        public System.Windows.Forms.TextBox phone;
        public System.Windows.Forms.TextBox adr;
        public System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label prenom;
        private System.Windows.Forms.Label tel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}