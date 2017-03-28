using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.AcessoDados
{
    public class VegetalDados
    {
        SqlConnection conn;

        public VegetalDados()
        {
            conn = Conexao.ObterConexao();

        }
        public void Finalizar(Vegetal vegetal)
        {
            try
            {
                var query = "insert into Vegetais (Nome, Tamanho) values (@Nome, @Tamanho)";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", vegetal.Nome);
                cmd.Parameters.AddWithValue("@Tamanho", vegetal.Tamanho);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Vegetal> Mostrar()
        {
            try
            {
                var query = "select * from Vegetais";

                var cmd = new SqlCommand(query, conn);

                var vegetal = new List<Vegetal>();

                conn.Open();
                var datareader = cmd.ExecuteReader();

                if (datareader.HasRows)
                    while (datareader.Read())
                    {
                        var vegetais = new Vegetal();
                        vegetais.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());

                        vegetais.Nome = datareader["Nome"].ToString();
                        vegetais.Tamanho = datareader["Tamanho"].ToString();

                        vegetal.Add(vegetais);
                    }
                conn.Close();

                return vegetal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
