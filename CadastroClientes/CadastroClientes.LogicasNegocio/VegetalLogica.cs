using CadastroClientes.AcessoDados;
using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.LogicasNegocio
{
    public class VegetalLogica
    {
        VegetalDados dados;

        public VegetalLogica()
        {
            dados = new VegetalDados();
        }

        public void Finalizar(Vegetal vegetal)
        {
            dados.Salvar(vegetal);
        }

        public List<Vegetal> Mostrar()
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