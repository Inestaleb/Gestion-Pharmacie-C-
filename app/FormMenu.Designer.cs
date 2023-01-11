
namespace app
{
    partial class FormMenu
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnvente = new System.Windows.Forms.Button();
            this.p = new System.Windows.Forms.Panel();
            this.btnfournisseur = new System.Windows.Forms.Button();
            this.btnCommande = new System.Windows.Forms.Button();
            this.btnCategorie = new System.Windows.Forms.Button();
            this.btnproduit = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.pnlafficher = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 739);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1409, 18);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btnvente);
            this.panel1.Controls.Add(this.p);
            this.panel1.Controls.Add(this.btnfournisseur);
            this.panel1.Controls.Add(this.btnCommande);
            this.panel1.Controls.Add(this.btnCategorie);
            this.panel1.Controls.Add(this.btnproduit);
            this.panel1.Controls.Add(this.btnClient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 739);
            this.panel1.TabIndex = 5;
            // 
            // btnvente
            // 
            this.btnvente.FlatAppearance.BorderSize = 0;
            this.btnvente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvente.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnvente.ForeColor = System.Drawing.Color.Black;
            this.btnvente.Image = global::app.Properties.Resources.Line_ui_icons_Svg_10_icon_icons3;
            this.btnvente.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnvente.Location = new System.Drawing.Point(-3, 607);
            this.btnvente.Name = "btnvente";
            this.btnvente.Size = new System.Drawing.Size(296, 89);
            this.btnvente.TabIndex = 0;
            this.btnvente.Text = "Vente";
            this.btnvente.UseVisualStyleBackColor = true;
            this.btnvente.Click += new System.EventHandler(this.btnvente_Click);
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.SystemColors.ControlDark;
            this.p.Location = new System.Drawing.Point(3, 108);
            this.p.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(10, 79);
            this.p.TabIndex = 6;
            this.p.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Paint);
            // 
            // btnfournisseur
            // 
            this.btnfournisseur.FlatAppearance.BorderSize = 0;
            this.btnfournisseur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfournisseur.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfournisseur.Image = global::app.Properties.Resources.icons8_supplier_1002;
            this.btnfournisseur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfournisseur.Location = new System.Drawing.Point(-1, 495);
            this.btnfournisseur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfournisseur.Name = "btnfournisseur";
            this.btnfournisseur.Size = new System.Drawing.Size(291, 85);
            this.btnfournisseur.TabIndex = 4;
            this.btnfournisseur.Text = "      Fournisseur";
            this.btnfournisseur.UseVisualStyleBackColor = true;
            this.btnfournisseur.Click += new System.EventHandler(this.btnFournisseur_Click);
            // 
            // btnCommande
            // 
            this.btnCommande.FlatAppearance.BorderSize = 0;
            this.btnCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommande.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommande.Image = global::app.Properties.Resources.shopping_icon1;
            this.btnCommande.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommande.Location = new System.Drawing.Point(0, 407);
            this.btnCommande.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCommande.Name = "btnCommande";
            this.btnCommande.Size = new System.Drawing.Size(291, 66);
            this.btnCommande.TabIndex = 4;
            this.btnCommande.Text = "   Commande";
            this.btnCommande.UseVisualStyleBackColor = true;
            this.btnCommande.Click += new System.EventHandler(this.btnCommande_Click);
            // 
            // btnCategorie
            // 
            this.btnCategorie.FlatAppearance.BorderSize = 0;
            this.btnCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorie.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorie.Image = global::app.Properties.Resources.category_icon_184181;
            this.btnCategorie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorie.Location = new System.Drawing.Point(1, 319);
            this.btnCategorie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategorie.Name = "btnCategorie";
            this.btnCategorie.Size = new System.Drawing.Size(289, 71);
            this.btnCategorie.TabIndex = 4;
            this.btnCategorie.Text = "     Categorie";
            this.btnCategorie.UseVisualStyleBackColor = true;
            this.btnCategorie.Click += new System.EventHandler(this.btnCategorie_Click);
            // 
            // btnproduit
            // 
            this.btnproduit.FlatAppearance.BorderSize = 0;
            this.btnproduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproduit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproduit.Image = global::app.Properties.Resources.virus_covid_corona_hand_drug_drugs_medical_icon_141770;
            this.btnproduit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduit.Location = new System.Drawing.Point(1, 211);
            this.btnproduit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnproduit.Name = "btnproduit";
            this.btnproduit.Size = new System.Drawing.Size(289, 74);
            this.btnproduit.TabIndex = 4;
            this.btnproduit.Text = "    Médicament";
            this.btnproduit.UseVisualStyleBackColor = true;
            this.btnproduit.Click += new System.EventHandler(this.btnproduit_Click);
            // 
            // btnClient
            // 
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.Image = global::app.Properties.Resources.user_icon_icons_com_57997;
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(-3, 105);
            this.btnClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(293, 82);
            this.btnClient.TabIndex = 4;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // pnlafficher
            // 
            this.pnlafficher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlafficher.BackColor = System.Drawing.Color.Lavender;
            this.pnlafficher.Location = new System.Drawing.Point(296, 44);
            this.pnlafficher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlafficher.Name = "pnlafficher";
            this.pnlafficher.Size = new System.Drawing.Size(1105, 691);
            this.pnlafficher.TabIndex = 6;
            this.pnlafficher.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlafficher_Paint);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1207, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 39);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::app.Properties.Resources.Button_Delete_icon5;
            this.button1.Location = new System.Drawing.Point(1369, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 37);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1409, 757);
            this.Controls.Add(this.pnlafficher);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCommande;
        private System.Windows.Forms.Button btnCategorie;
        private System.Windows.Forms.Button btnproduit;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Panel p;
        private System.Windows.Forms.Panel pnlafficher;
        private System.Windows.Forms.Button btnfournisseur;
        public System.Windows.Forms.Button btnvente;
    }
}