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

        /// <summary>
        /// Método que retorna uma instância de SqlConnection baseada em uma string de conexão.
        /// </summary>
        /// <returns>Conexão SQL</returns>
        public static SqlConnection ObterConexao() //Assinatura do método
        {
            //Criação de uma variável para armazenar a string de conexão que foi previamente configurada no arquivo App.config da camada de Interface. Para ler o App.config é necessário utilizar a classe ConfigurationManager que encontra-se no namespace System.Configuration, que deve ser referenciado no projeto.
            var stringDeConexao = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            //Criação de uma variável  do tipo SqlConnection, esta SqlConnection pede uma string de conexão como parâmetro 
            var conn = new SqlConnection(stringDeConexao);

            //Retorna uma instância de conexão SqlConnection conforme assinatura do método 
            return conn;
        }
    }
}
