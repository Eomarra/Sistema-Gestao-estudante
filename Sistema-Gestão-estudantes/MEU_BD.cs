using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_Gestão_estudantes
{
    internal class MEU_BD
    {

        MySqlConnection conexao = new MySqlConnection("datasource=localhost; username=root;password=;database=t4_sga_bd");

        public MySqlConnection getConexao
        {
            get
            {
                return conexao;
            }
        }
        public void AbrirConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();

            }
        }

        public void fecharConexao()
        {
             if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();

            }
        }
    }

}
