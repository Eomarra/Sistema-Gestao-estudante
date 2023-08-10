using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Gestão_estudantes
{
    public partial class ListaEstudante : Form
    {
        public ListaEstudante()
        {
            InitializeComponent();
        }

        private void ListaEstudante_Load(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand ("SElECT + FROM ´estudantes'");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn colunaDeFotos = new DataGridViewImageColumn();
        }
    }
}
