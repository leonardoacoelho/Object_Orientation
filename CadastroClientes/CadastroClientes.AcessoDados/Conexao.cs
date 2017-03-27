using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CadastroClientes.AcessoDados
{
    public class Conexao
    {
        public static SqlConnection ObterConexao()
        {
            var stringDeConexao = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            var conn = new SqlConnection(stringDeConexao);
            return conn;
        }    
    }
}
