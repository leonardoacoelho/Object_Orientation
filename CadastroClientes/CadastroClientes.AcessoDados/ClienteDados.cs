using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.AcessoDados
{
    public class ClienteDados
    {
        SqlConnection conn;

        public ClienteDados()
        {
            conn = Conexao.ObterConexao();
        }

        public void Salvar(Cliente cliente)
        {
            try
            {
                var query = $"insert into Cliente (Nome, Endereco, Bairro, Estado, Telefone, Celular, Email) values (@Nome, @End, @Bairro, @Estado, @Tel, @Cel, @Email)";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@End", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Tel", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Cel", cliente.Celular);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                var query = "select * from Cliente";

                var cmd = new SqlCommand(query, conn);

                var clientes = new List<Cliente>();

                conn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        var cliente = new Cliente();
                        cliente.Codigo = Convert.ToInt32(dr["Codigo"].ToString());
                        cliente.Nome = dr["Nome"].ToString();
                        cliente.Endereco = dr["Endereco"].ToString();
                        cliente.Bairro = dr["Bairro"].ToString();
                        cliente.Estado = dr["Estado"].ToString();
                        cliente.Telefone = dr["Telefone"].ToString();
                        cliente.Celular = dr["Celular"].ToString();
                        cliente.Email = dr["Email"].ToString();

                        clientes.Add(cliente);
                    }
                conn.Close();


                return clientes;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
