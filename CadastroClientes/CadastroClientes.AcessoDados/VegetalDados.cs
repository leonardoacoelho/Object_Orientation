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
        public void Salvar(Vegetal vegetal)
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

        public void Editar(Vegetal vegetal)
        {
            try
            {
                var query = "update Vegetais set Nome = @Nome, Tamanho = @Tamanho";

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

        public void Remover( int codigo)
        {
            try
            {
                var query = "delete from Vegetais where Codigo = @Codigo";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Vegetal> Listar()
        {
            try
            {
                var query = "select * from Vegetais";

                var cmd = new SqlCommand(query, conn);

                var vegetais = new List<Vegetal>();

                conn.Open();
                var datareader = cmd.ExecuteReader();

                if (datareader.HasRows)
                    while (datareader.Read())
                    {
                        var vegetal = new Vegetal();
                        vegetal.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());

                        vegetal.Nome = datareader["Nome"].ToString();
                        vegetal.Tamanho = datareader["Tamanho"].ToString();

                        vegetais.Add(vegetal);
                    }
                conn.Close();

                return vegetais;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Vegetal Encontrar(int codigo)
        {
            var query = "select * from Vegetais where Codigo = @Codigo ";

            var cmd = new SqlCommand(query, conn);

            conn.Open();

            var datareader = cmd.ExecuteReader();

            var vegetal = new Vegetal();

            if (datareader.HasRows)
            {
                datareader.Read();

                vegetal.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());
                vegetal.Nome = datareader["Nome"].ToString();
                vegetal.Tamanho = datareader["Tamanho"].ToString();
            }
            conn.Close();
            return vegetal;
        }
    }
}
