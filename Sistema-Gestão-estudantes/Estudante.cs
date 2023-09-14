using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Sistema_Gestão_estudantes
{
    internal class Estudante

    {
        MEU_BD bancoDeDados = new MEU_BD();

        // Função que inclui o estudante no banco de dados.
        public bool InserirEstudante(string nome, string sobrenome,
        DateTime nascimento, string telefone, string genero, string endereco, MemoryStream foto)
        {
            MySqlCommand comando = new MySqlCommand("INSERT INTO `estudantes`(`nome`, `sobrenome`, `nascimento`, `genero`, `telefone`, `endereco`, `foto`) VALUES ('@nm','@sbn','@ncs','@gen','@tel','@end','@fot')", bancoDeDados.getConexao);

            comando.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nome;
            comando.Parameters.Add("@sbn", MySqlDbType.VarChar).Value = sobrenome;
            comando.Parameters.Add("@ncs", MySqlDbType.VarChar).Value = nascimento;
            comando.Parameters.Add("gen", MySqlDbType.VarChar).Value = genero;
            comando.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telefone;
            comando.Parameters.Add("@end", MySqlDbType.VarChar).Value = endereco;
            comando.Parameters.Add("@ft", MySqlDbType.LongBlob).Value = foto.ToArray();

            bancoDeDados.AbrirConexao();
            if (comando.ExecuteNonQuery() == 1)
            {
                bancoDeDados.fecharConexao();
                return true;

            }
            else
            {
                bancoDeDados.fecharConexao();
                return false;
            }

        }

        internal bool atualizarEstudante(int id, string nome, string sobrenome, string telefone, string genero, string endereco, MemoryStream foto)
        {
            throw new NotImplementedException();
        }
        public DataTable getEstudante(MySqlCommand comando)
        {
            comando.Connection = bancoDeDados.getConexao;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);


            return tabela;
        }

        public DataTable pegarEstudantes(MySqlCommand comando)
        {
            comando.Connection = bancoDeDados.getConexao;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);
            return tabela;

        }
        public bool AtualizarEstudante(int id, string nome, string sobrenome,
       DateTime nascimento, string telefone, string genero, string endereco, MemoryStream foto)
        {
            MySqlCommand comando = new MySqlCommand("UPDATE `estudantes` SET `nome`= @nm,`sobrenome`= @sbn,`nascimento`= @nsc,`genero`= @gen,`telefone`= @tel,`endereco`= @end,`foto`= @ft WHERE `id` = @id", bancoDeDados.getConexao);

            comando.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            comando.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nome;
            comando.Parameters.Add("@sbn", MySqlDbType.VarChar).Value = sobrenome;
            comando.Parameters.Add("@ncs", MySqlDbType.VarChar).Value = nascimento;
            comando.Parameters.Add("gen", MySqlDbType.VarChar).Value = genero;
            comando.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telefone;
            comando.Parameters.Add("@end", MySqlDbType.VarChar).Value = endereco;
            comando.Parameters.Add("@ft", MySqlDbType.LongBlob).Value = foto.ToArray();

            bancoDeDados.AbrirConexao();
            if (comando.ExecuteNonQuery() == 1)
            {
                bancoDeDados.fecharConexao();
                return true;

            }
           


            else
            {
                bancoDeDados.fecharConexao();
                return false;
            }

        }
        public bool deletarestudante(int id)
        {
            MySqlCommand comando = new MySqlCommand("DELETE FROM `estudantes` WHERE `id` = @studentid", bancoDeDados.getConexao);
            comando.Parameters.Add("@studentid", MySqlDbType.Int32).Value = id;

            bancoDeDados.AbrirConexao();

            if (comando.ExecuteNonQuery() == 1)
            {
                bancoDeDados.fecharConexao();
                return true;

            }
            else
            {
                bancoDeDados.fecharConexao();
                return false;
            }
        }
    }
}




