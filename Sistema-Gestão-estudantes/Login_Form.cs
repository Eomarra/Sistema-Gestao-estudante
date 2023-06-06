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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../imagens/avatar.gif");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            MEU_BD bancoDeDados = new MEU_BD();

            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            DataTable tabela = new DataTable();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM `usuarios` WHERE  `username` = @usn AND `password` = @psd ", bancoDeDados.getConexao);

            comando.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@psd", MySqlDbType.VarChar).Value = textBox2.Text;

            adaptador.SelectCommand = comando;
            adaptador.Fill(tabela);


            if (tabela.Rows.Count > 0)
            {
               this.DialogResult= DialogResult.OK;
            }
            {
                MessageBox.Show("Usúario ou senha incorretos, erro de login.");
            }
        }
    }
}
