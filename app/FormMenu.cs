using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controllers;

namespace app
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            panel1.Size = new Size(220,494);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
       

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

     

        private void btnproduit_Click(object sender, EventArgs e)
        {
            p.Top = btnproduit.Top;
            if (!pnlafficher.Controls.Contains(UserProduit.Instance))
            {
                pnlafficher.Controls.Add(UserProduit.Instance);
                UserProduit.Instance.Dock = DockStyle.Fill;
                UserProduit.Instance.BringToFront();

            }
            else
            {
                UserProduit.Instance.BringToFront();
            }
        }


        private void btnCategorie_Click(object sender, EventArgs e)
        {
            p.Top = btnCategorie.Top;
            if(!pnlafficher.Controls.Contains(UserCategorie.Instance))
            {
                pnlafficher.Controls.Add(UserCategorie.Instance);
                UserCategorie.Instance.Dock = DockStyle.Fill;
                UserCategorie.Instance.BringToFront();

            }
            else
            {
                UserCategorie.Instance.BringToFront();
            }
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            p.Top = btnCommande.Top;
            if (!pnlafficher.Controls.Contains(UserCommande.Instance))
            {
                pnlafficher.Controls.Add(UserCommande.Instance);
                UserCommande.Instance.Dock = DockStyle.Fill;
                UserCommande.Instance.BringToFront();

            }
            else
            {
                UserCommande.Instance.BringToFront();
            }
        }
        

        private void btnClient_Click(object sender, EventArgs e)
        {
            p.Top = btnClient.Top;
            if (!pnlafficher.Controls.Contains(UserClient.Instance))
            {
                pnlafficher.Controls.Add(UserClient.Instance);
                UserClient.Instance.Dock = DockStyle.Fill;
                UserClient.Instance.BringToFront();

            }
            else
            {
                UserClient.Instance.BringToFront();
            }
        }

        private void pnlafficher_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFournisseur_Click(object sender, EventArgs e)
        {
            p.Top = btnCommande.Top;
            if (!pnlafficher.Controls.Contains(UserFournisseur.Instance))
            {
                pnlafficher.Controls.Add(UserFournisseur.Instance);
                UserFournisseur.Instance.Dock = DockStyle.Fill;
                UserFournisseur.Instance.BringToFront();

            }
            else
            {
                UserFournisseur.Instance.BringToFront();
            }

        }

        private void btnvente_Click(object sender, EventArgs e)
        {
            p.Top = btnvente.Top;
            if (!pnlafficher.Controls.Contains(UserVente.Instance))
            {
                pnlafficher.Controls.Add(UserVente.Instance);
                UserVente.Instance.Dock = DockStyle.Fill;
                UserVente.Instance.BringToFront();

            }
            else
            {
                UserVente.Instance.BringToFront();
            }

        }
    }
}
