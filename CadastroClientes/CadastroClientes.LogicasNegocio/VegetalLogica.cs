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
                if (string.IsNullOrEmpty(vegetal.Nome) || string.IsNullOrEmpty(vegetal.Tamanho) || vegetal.GrupoVegetal_Codigo == 0)
                    throw new ArgumentNullException();

                if (vegetal.Codigo == 0)
                    Inserir(vegetal);
                else
                    Editar(vegetal);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Editar(Vegetal vegetal)
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

        public List<Vegetal> Listar()
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