using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.AcessoDados
{
    public class GrupoVegetalDados
    {
        SqlConnection conn;

        public GrupoVegetalDados()
        {
            conn = Conexao.ObterConexao();
        }
        public void Inserir(GrupoVegetal grupo)
        {
            try
            {
                var query = $"insert into GruposVegetais (Nome) values (@Nome)";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", grupo.Nome);

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

        public void Editar(GrupoVegetal grupo)
        {
            try
            {
                var query = $"update GruposVegetais set Nome = @Nome where Codigo = @Codigo";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", grupo.Nome);
                cmd.Parameters.AddWithValue("@Codigo", grupo.Codigo);

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
                var query = $"delete from GruposVegetais where Codigo = @Codigo";

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

        public List<GrupoVegetal> Listar()
        {
            try
            {
                var query = "select * from GruposVegetais";

                var cmd = new SqlCommand(query, conn);

                var grupos = new List<GrupoVegetal>();

                conn.Open();
                var datareader = cmd.ExecuteReader();

                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        var grupo = new GrupoVegetal();

                        grupo.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());
                        grupo.Nome = datareader["Nome"].ToString();

                        grupos.Add(grupo);
                    }
                }
                return grupos;
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

        public GrupoVegetal Encontrar(int codigo)
        {
            try
            {
                var query = $"select * from GruposVegetais where Codigo = @Codigo";

                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                conn.Open();

                var datareader = cmd.ExecuteReader();

                var grupo = new GrupoVegetal();

                if (datareader.HasRows)
                {
                    datareader.Read();

                    grupo.Codigo = Convert.ToInt32(datareader["Codigo"].ToString());
                    grupo.Nome = datareader["Nome"].ToString();
                }
                return grupo;
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
