using CadastroClientes.AcessoDados;
using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.LogicasNegocio
{
    public class ClienteLogica
    {
        //Criamos uma variável da camada de dados
        ClienteDados dados;
        
        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public ClienteLogica()
        {
            //Instanciar a clasee da camada de dados
            dados = new ClienteDados();
        }

        /// <summary>
        /// Método que insere um cliente
        /// </summary>
        /// <param name="cliente">Cliente preenchido</param>
        private void Inserir(Cliente cliente)
        {
            try
            {
                //Chama o método inserir da camada de dados passando cliente. Este método esta definido como private, pois, está sendo usado no método salvar
                dados.Inserir(cliente);
            }
            catch (Exception)
            {

                throw;
            } 

        }

        /// <summary>
        /// Método que edita um cliente
        /// </summary>
        /// <param name="cliente">Cliente preenchido</param>
        private void Editar(Cliente cliente)
        {
            try
            {
                //Chama o método editar da camada de dados passando cliente. Este método esta definido como private, pois, está sendo usado no método salvar
                dados.Editar(cliente);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Método que salva um cliente
        /// </summary>
        /// <param name="cliente">Cliente preenchido</param>
        public void Salvar(Cliente cliente)
        {
            //Verificamos se o nome e o telefone foram preenchidos, caso não, lançamos uma excessão
            if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Telefone))
                throw new ArgumentNullException();

            //Verificamos se o tamanho do campo telefone é válido, caso nãõ, lançamos uma excessão
            if (cliente.Telefone.Length < 8 || cliente.Telefone.Length > 9)
                throw new ArgumentOutOfRangeException();

            //Verificamos se o código do cliente é 0 para definir se será Inserido ou Editado
            if (cliente.Codigo == 0)
                Inserir(cliente);
            else
                Editar(cliente);
        }

        /// <summary>
        /// Método que remove um cliente
        /// </summary>
        /// <param name="codigo">Codigo de cliente</param>
        public void Remover(int codigo)
        {
            try
            {
                //Chama o método remover da camada de dados passando código. 
                dados.Remover(codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// Método que lista os clientes cadastrados
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public List<Cliente> Listar()
        {
            try
            {
                //Chama o método listar da camada de dados passando cliente.
                return dados.Listar();
            }
            catch (Exception)
            {


                throw;
            }
        }

        /// <summary>
        /// Método que encontra um único cliente
        /// </summary>
        /// <param name="codigo">Codigo do cliente</param>
        /// <returns>Cliente</returns>
        public Cliente Encontrar(int codigo)
        {
            try
            {
                //Chama o método Encontrar da camada de dados passando codigo.
                return dados.Encontrar(codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}