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
        ClienteDados dados;

        public ClienteLogica()
        {
            dados = new ClienteDados();
        }

        public void Salvar(Cliente cliente)
        {
            try
            {
                if (cliente.Telefone.Length < 8 || cliente.Telefone.Length > 9)
                    throw new ArgumentOutOfRangeException();

                dados.Salvar(cliente);
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
                return dados.Listar();
            }
            catch (Exception)
            {


                throw;
            }
        }
    }
}