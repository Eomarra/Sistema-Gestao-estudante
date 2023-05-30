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
        MySqlConnection conexao = new MySqlConnection("datasource=localhost; username=root;password=;databaset4_sga_bd");
    }
}
