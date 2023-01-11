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
    public partial class login : Form
    {
        private DB_GestionEntities db;
        Connexion c = new Connexion();
       
        public login()
        {
            InitializeComponent();
        }
        String testobligatoire()
        {
            if(username.Text=="" )
            {
                return "username champ obligatoire";
            }
            if( mdp.Text == "")
            {
                return "password champ obligatoire";
            }
            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
              db = new DB_GestionEntities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (testobligatoire() == null)
            {
               if(c.ConnexionValide(db, username.Text , mdp.Text)==true)
                {
                    MessageBox.Show("Connecter avec reussi","Connexion",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                   FormMenu obj = new FormMenu();
                    this.Hide();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Connecter avec echoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(testobligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
