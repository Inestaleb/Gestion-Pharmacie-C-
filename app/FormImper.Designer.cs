
namespace app
{
    partial class FormImper
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
            this.affiche = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // affiche
            // 
            this.affiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.affiche.Location = new System.Drawing.Point(0, 0);
            this.affiche.Name = "affiche";
            this.affiche.ServerReport.BearerToken = null;
            this.affiche.Size = new System.Drawing.Size(800, 450);
            this.affiche.TabIndex = 0;
            // 
            // FormImper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.affiche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormImper";
            this.Text = "ImperCommande";
            this.Load += new System.EventHandler(this.ImperCommande_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer affiche;
    }
}