using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Gestão_estudantes
{
    public partial class FormInserirEstudante : Form
    {
        public FormInserirEstudante()
        {
            InitializeComponent();
        }


        private void btnenviarft_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirarquivo = new OpenFileDialog();
            abrirarquivo.Filter = "Seleciona A Foto (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (abrirarquivo.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(abrirarquivo.FileName);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Estudante estudante = new Estudante();
            string nome = textBoxnome.Text;
            string sobrenome = textBoxsobrenome.Text;
            string telefone = textBoxtelefone.Text;
            string endereco = textboxendereco.Text;
            string genero = "Feminino";

            if (radioButtonmasculino.Checked)
            {
                genero = "Masculino";
            }


            MemoryStream foto = new MemoryStream();

            int anoDeNascimento = dateTimePickernascimento.Value.Year;

            int anoAtual = DateTime.Now.Year;
            if (
                (anoAtual - anoDeNascimento) < 10 ||
                (anoAtual - anoDeNascimento) > 100
                )
            {
                MessageBox.Show("a idade precisa ser entre 10 e 100 anos ", "idade invalida",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Verificar())
            {
                pictureBox.Image.Save(foto, pictureBox.Image.RawFormat);
                if (estudante.InserirEstudante(nome, sobrenome,
                    telefone, genero, endereco, foto))
                {
                    MessageBox.Show("Novo Estudante Cadastrado", "Sucesso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro", "Inserir Estudante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
               
           

            }
             else
                {
                    MessageBox.Show("Campo Não Preenchido", "Inserir Estudante",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }


            bool Verificar()
            {
                if ((textBoxnome.Text.Trim() == "") ||
                    (textBoxsobrenome.Text.Trim() == "") ||
                    (textBoxtelefone.Text.Trim() == "") ||
                    (textboxendereco.Text.Trim() == "") ||
                    (pictureBox.Image == null))

                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
}


