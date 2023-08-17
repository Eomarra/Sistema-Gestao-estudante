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
        Estudante estudante = new Estudante();
        private void ListaEstudante_Load(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SElECT + FROM ´estudantes'");
            dataGridViewLista.ReadOnly = true;
            DataGridViewImageColumn colunaDeFotos = new DataGridViewImageColumn();
            dataGridViewLista.RowTemplate.Height = 80;
            dataGridViewLista.DataSource = Estudante.getEstudantes(comando);
            colunaDeFotos = (DataGridViewImageColumn)dataGridViewLista.Columns[7];
            colunaDeFotos.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewLista.AllowUserToAddRows = false;
    }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}

