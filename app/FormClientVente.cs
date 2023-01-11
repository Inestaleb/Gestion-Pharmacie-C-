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
    public partial class ListesClient : Form
    {
        private DB_GestionEntities db;
        public ListesClient()
        {
            InitializeComponent();
            db = new DB_GestionEntities();
        }

        private void ListesClient_Load(object sender, EventArgs e)
        {
            foreach (var s in db.Clients)
            {
                dgvClient.Rows.Add(s.CodeClt, s.NomClt, s.PrenomClt, s.telClt, s.emailClt, s.adrClt, s.codepostale);
            }
        }

        private void dgvClient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }
    }
}
