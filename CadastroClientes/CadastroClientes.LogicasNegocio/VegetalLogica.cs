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

        private void Inserir(Vegetal vegetal)
        {
            try
            {
                dados.Inserir(vegetal);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Salvar(Vegetal vegetal)
        {
            try
            {
                dados.Inserir(vegetal);
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
                dados.Editar(vegetal);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remover(int codigo)
        {
            try
            {
                dados.Remover(codigo);
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
                return dados.Listar();
            }
            catch (Exception)
            {


                throw;
            }
        }

        public Vegetal Encontrar(int codigo)
        {
            try
            {
                return dados.Encontrar(codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}