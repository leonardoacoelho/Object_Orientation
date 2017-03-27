using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes
{
    public class Cliente
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public void Salvar()
        {
            try
            {
                if (Telefone.Length < 8 || Telefone.Length > 9)
                    throw new ArgumentOutOfRangeException();

                var conn = Conexao.ObterConexao();
                var query = $"insert into Cliente (Nome, Endereco, Bairro, Estado, Telefone, Celular, Email) values (@Nome, @End, @Bairro, @Estado, @Tel, @Cel, @Email)";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@End", Endereco);
                cmd.Parameters.AddWithValue("@Bairro", Bairro);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.Parameters.AddWithValue("@Tel", Telefone);
                cmd.Parameters.AddWithValue("@Cel", Celular);
                cmd.Parameters.AddWithValue("@Email", Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
