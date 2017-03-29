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
        // Criação de uma variável do tipo SqlConnection
        SqlConnection conn;

        /// <summary>
        /// Construtor da classe cliente dados
        /// </summary>
        public ClienteDados()
        {
            //A variável que criamos anteriormente irá receber uma instância de SqlConnection que foi gerada no arquivo Conexao através do método ObterConexao()
            conn = Conexao.ObterConexao();
        }

        /// <summary>
        /// Método que salva um cliente no banco de dados
        /// </summary>
        /// <param name="cliente">Instância de um cliente preenchido</param>
        public void Salvar(Cliente cliente)
        {
            try
            {
                //Criação de uma variável do tipo string contendo a query do comando SQL que será executado. Os parâmetros de nossa query deverão ser formados pelo nome do campo na tabela precedido de um '@', posteriormente esses parâmetros serão substituídos  
                var query = $"insert into Cliente (Nome, Endereco, Bairro, Estado, Telefone, Celular, Email) values (@Nome, @Endereco, @Bairro, @Estado, @Telefone, @Celular, @Email)";

                //Criação de uma variável do tipo SqlCommand, que precisa de uma query e de uma instância de conexão com o banco de dados
                var cmd = new SqlCommand(query, conn);

                //Substituição dos parâmetros informados na query pelos valores preenchidos na instância do cliente
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                //Abrir a conexão com o banco de dados
                conn.Open();

                //Executar o comando criado
                cmd.ExecuteNonQuery();

                //Fechar a conexão com o banco de dados
                conn.Close();
            }
            catch (Exception)
            {
                //Relança a excessão para a camada superior 
                throw;
            }
        }

        /// <summary>
        /// Método que edita um cliente no banco de dados
        /// </summary>
        /// <param name="cliente">Cliente preenchido</param>
        public void Editar(Cliente cliente)
        {
            try
            {
                //Criação de uma variável do tipo string contendo a query do comando SQL que será executado. Os parâmetros de nossa query deverão ser formados pelo nome do campo na tabela precedido de um '@', posteriormente esses parâmetros serão substituídos  
                var query = $"update Cliente set Nome = @Nome, Endereco = @Endereco, Bairro = @Bairro, Estado = @Estado, Telefone = @Telefone,Celular = @Celular,Email = @Email where Codigo = @Codigo";

                //Criação de uma variável do tipo SqlCommand, que precisa de uma query e de uma instância de conexão com o banco de dados
                var cmd = new SqlCommand(query, conn);

                //Substituição dos parâmetros informados na query pelos valores preenchidos na instância do cliente
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);

                //Abrir a conexão com o banco de dados
                conn.Open();

                //Executar o comando criado
                cmd.ExecuteNonQuery();

                //Fechar a conexão com o banco de dados
                conn.Close();
            }
            catch (Exception)
            {
                //Relança a excessão para a camada superior 
                throw;
            }
        }

        /// <summary>
        /// Método que remove um cliente no banco de dados
        /// </summary>
        /// <param name="codigo">Codigo do cliente</param>
        public void Remover(int codigo)
        {
            try
            {
                //Criação de uma variável do tipo string contendo a query do comando SQL que será executado. Os parâmetros de nossa query deverão ser formados pelo nome do campo na tabela precedido de um '@', posteriormente esses parâmetros serão substituídos  
                var query = $"delete from Cliente where Codigo = @Codigo";

                //Criação de uma variável do tipo SqlCommand, que precisa de uma query e de uma instância de conexão com o banco de dados
                var cmd = new SqlCommand(query, conn);

                //Substituição dos parâmetros informados na query pelos valores preenchidos na instância do cliente
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                //Abrir a conexão com o banco de dados
                conn.Open();

                //Executar o comando criado
                cmd.ExecuteNonQuery();

                //Fechar a conexão com o banco de dados
                conn.Close();
            }
            catch (Exception)
            {
                //Relança a excessão para a camada superior 
                throw;
            }
        }

        /// <summary>
        /// Método que lista os clientes no banco de dados
        /// </summary>
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> Listar()
        {
            try
            {
                //Criação de uma variável do tipo string contendo a query do comando SQL que será executado. Os parâmetros de nossa query deverão ser formados pelo nome do campo na tabela precedido de um '@', posteriormente esses parâmetros serão substituídos  
                var query = "select * from Cliente";

                //Criação de uma variável do tipo SqlCommand, que precisa de uma query e de uma instância de conexão com o banco de dados
                var cmd = new SqlCommand(query, conn);

                //Criação de uma variável de lista de clientes que será preenchida abaixo e posteriormente retornada
                var clientes = new List<Cliente>();

                //Abrir a conexão com o banco de dados
                conn.Open();

                //Crie uma variável do tipo DataReader e o preenche através do método ExecuteReader do comando criado anteriormente
                var dataReader = cmd.ExecuteReader();

                //Verifica se a leitura retornou registros, caso sim teremos que ler linha a linha preencher as instâncias de clientes e adicioná-los à lista criada anteriormente
                if (dataReader.HasRows)
                {
                    //Percorre linha a linha encontradas na leitura do DataReader
                    while (dataReader.Read())
                    {
                        //Criação de uma instância de cliente que será populada com as informações que vieram do banco de dados
                        var cliente = new Cliente();

                        //Popular o cliente com as informações do banco de dados, por padrão sempre obteremos string (através do método ToString()), caso o campo seja de outro formato, como neste caso o codigo, é necessário fazer uma conversão
                        cliente.Codigo = Convert.ToInt32(dataReader["Codigo"].ToString());
                        cliente.Nome = dataReader["Nome"].ToString();
                        cliente.Endereco = dataReader["Endereco"].ToString();
                        cliente.Bairro = dataReader["Bairro"].ToString();
                        cliente.Estado = dataReader["Estado"].ToString();
                        cliente.Telefone = dataReader["Telefone"].ToString();
                        cliente.Celular = dataReader["Celular"].ToString();
                        cliente.Email = dataReader["Email"].ToString();

                        //Adicionar a instância do cliente preenchida à lista que criamos anteriormente
                        clientes.Add(cliente);
                    }
                }

                //Fechar a conexão com o banco de dados
                conn.Close();

                //Retorna a lista de clientes preenchida
                return clientes;
            }
            catch (Exception)
            {
                //Relança a excessão para a camada superior
                throw;
            }
        }

        /// <summary>
        /// Método que encontra um cliente no banco de dados
        /// </summary>
        /// <param name="codigo">Código do cliente</param>
        /// <returns>Cliente</returns>
        public Cliente Encontrar(int codigo)
        {
            try
            {
                //Criação de uma variável do tipo string contendo a query do comando SQL que será executado. Os parâmetros de nossa query deverão ser formados pelo nome do campo na tabela precedido de um '@', posteriormente esses parâmetros serão substituídos  
                var query = "select * from Cliente where Codigo = @Codigo";

                //Criação de uma variável do tipo SqlCommand, que precisa de uma query e de uma instância de conexão com o banco de dados
                var cmd = new SqlCommand(query, conn);

                //Abrir a conexão com o banco de dados
                conn.Open();

                //Crie uma variável do tipo DataReader e o preenche através do método ExecuteReader do comando criado anteriormente
                var dataReader = cmd.ExecuteReader();

                //Criação de uma instância de cliente que será populada com as informações que vieram do banco de dados
                var cliente = new Cliente();

                //Verifica se a leitura retornou registros, caso sim teremos que ler linha a linha preencher as instâncias de clientes e adicioná-los à lista criada anteriormente
                if (dataReader.HasRows)
                {
                    //Ler o registro no banco de dados
                    dataReader.Read();

                    //Popular o cliente com as informações do banco de dados, por padrão sempre obteremos string (através do método ToString()), caso o campo seja de outro formato, como neste caso o codigo, é necessário fazer uma conversão
                    cliente.Codigo = Convert.ToInt32(dataReader["Codigo"].ToString());
                    cliente.Nome = dataReader["Nome"].ToString();
                    cliente.Endereco = dataReader["Endereco"].ToString();
                    cliente.Bairro = dataReader["Bairro"].ToString();
                    cliente.Estado = dataReader["Estado"].ToString();
                    cliente.Telefone = dataReader["Telefone"].ToString();
                    cliente.Celular = dataReader["Celular"].ToString();
                    cliente.Email = dataReader["Email"].ToString();
                }

                //Fechar a conexão com o banco de dados
                conn.Close();

                //Retorna a lista de clientes preenchida
                return cliente;
            }
            catch (Exception)
            {
                //Relança a excessão para a camada superior
                throw;
            }
        }
    }
}
