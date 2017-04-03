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
        public void Inserir(Vegetal vegetal)
        {
            try
            {
                var query = "insert into Vegetais (Nome, Tamanho, CodigoGrupo) values (@Nome, @Tamanho, @CodigoGrupo)";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", vegetal.Nome);
                cmd.Parameters.AddWithValue("@Tamanho", vegetal.Tamanho);
                cmd.Parameters.AddWithValue("@CodigoGrupo", vegetal.GrupoVegetal_Codigo);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public void Editar(Vegetal vegetal)
        {
            try
            {
                var query = "update Vegetais set Nome = @Nome, Tamanho = @Tamanho, CodigoGrupo = @CodigoGrupo where Codigo = @Codigo";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", vegetal.Codigo);
                cmd.Parameters.AddWithValue("@Nome", vegetal.Nome);
                cmd.Parameters.AddWithValue("@Tamanho", vegetal.Tamanho);
                cmd.Parameters.AddWithValue("@Codigo", vegetal.GrupoVegetal_Codigo);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public void Remover(int codigo)
        {
            try
            {
                var query = "delete from Vegetais where Codigo = @Codigo";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Vegetal> Listar()
        {
            try
            {
                var query = "select veg.*, grp.Nome as NomeGrupo from Vegetais as veg join GruposVegetais as grp on veg.CodigoGrupo = grp.Codigo";

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
                        vegetal.GrupoVegetal_Codigo = Convert.ToInt32(datareader["CodigoGrupo"].ToString());
                        vegetal.GrupoVegetal = new GrupoVegetal
                        {
                            Codigo = Convert.ToInt32(datareader["CodigoGrupo"].ToString()),
                            Nome = datareader["NomeGrupo"].ToString()
                        };

                        vegetais.Add(vegetal);
                    }


                return vegetais;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Vegetal Encontrar(int codigo)
        {
            try
            {
                var query = "select veg.*, grp.Nome as NomeGrupo from Vegetais as veg join GruposVegetais as grp on veg.CodigoGrupo = grp.Codigo where veg.Codigo = @Codigo ";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                conn.Open();

                var datareader = cmd.ExecuteReader();

                var vegetal = new Vegetal();

                if (datareader.HasRows)
                {
                    datareader.Read();

                    vegetal.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());
                    vegetal.Nome = datareader["Nome"].ToString();
                    vegetal.Tamanho = datareader["Tamanho"].ToString();
                    vegetal.GrupoVegetal_Codigo = Convert.ToInt32(datareader["CodigoGrupo"].ToString());
                    vegetal.GrupoVegetal = new GrupoVegetal
                    {
                        Codigo = Convert.ToInt32(datareader["CodigoGrupo"].ToString()),
                        Nome = datareader["NomeGrupo"].ToString()
                    };

                }

                return vegetal;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
