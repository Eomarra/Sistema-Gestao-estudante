using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Gestão_estudantes
{
    public partial class AtualizarDeletarEstudante : Form
    {
        Estudante  estudante = new Estudante();
        public AtualizarDeletarEstudante()
        {
            InitializeComponent();
        }


        private void buttonEnviarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.Filter = "Seleciona a Foto(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(abrirArquivo.FileName);
            }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            Estudante estudante = new Estudante();
            int id = Convert.ToInt32(textBoxid.Text);
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
                if (estudante.atualizarEstudante(id, nome, sobrenome,
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
                MessageBox.Show("Campo Não Preenchido", "Inserir Estudante", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void buttonremover_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(textBoxid.Text);





            if (MessageBox.Show("Tem certeza que quer remover o estudante?",
                "remover estudante", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)

                if (estudante.deletarestudante(id))
                {
                    MessageBox.Show("Estudante Removido", "Remover Estudante",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxid.Text = "";
                    textBoxnome.Text = "";
                    textBoxsobrenome.Text = "";
                    textBoxtelefone.Text = "";
                    textboxendereco.Text = "";
                    dateTimePickernascimento.Value = DateTime.Now;
                    pictureBox.Image = null;
                }
                else
                { 
                    MessageBox.Show("Estudante Não Removido",
                        "Remover Estudante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                
                
                }

                    

           

            }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxid.Text);
            MySqlCommand comando = new MySqlCommand("SELECT `id`, `nome`, `sobrenome`, `nascimento`, `genero`, `telefone`, `endereco`, `foto` FROM `estudantes` WHERE `id`=" + id);


            DataTable tabela = estudante.pegarEstudantes(comando);


            if (tabela.Rows.Count > 0)
            {
                textBoxnome.Text = tabela.Rows[0]["nome"].ToString();
                textBoxsobrenome.Text = tabela.Rows[0]["sobrenome"].ToString();
                textBoxtelefone.Text = tabela.Rows[0]["telefone"].ToString();
                textboxendereco.Text = tabela.Rows[0]["endereco"].ToString();

                dateTimePickernascimento.Value = (DateTime)tabela.Rows[0]["nascimento"];


                if (tabela.Rows[0]["genero"].ToString() == "Feminino")
                {
                    radioButtonfeminino.Checked = true;

                }
                else
                {
                    radioButtonmasculino.Checked = false;   
                }
                byte[] fotoDaTabela = (byte[]) tabela.Rows[0]["foto"];
                MemoryStream fotoDaInterface = new MemoryStream(fotoDaTabela);
                pictureBox.Image = Image.FromStream(fotoDaInterface);

            }
        }
    }
    }

