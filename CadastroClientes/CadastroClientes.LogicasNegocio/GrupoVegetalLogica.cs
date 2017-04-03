using CadastroClientes.AcessoDados;
using CadastroClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.LogicasNegocio
{
    public class GrupoVegetalLogica
    {
        GrupoVegetalDados dados;

        public GrupoVegetalLogica()
        {
            dados = new GrupoVegetalDados();
        }

        private void Inserir(GrupoVegetal grupo)
        {
            try
            {
                dados.Inserir(grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Salvar(GrupoVegetal grupo)
        {
            try
            {
                if (grupo.Codigo == 0)
                    dados.Inserir(grupo);
                else
                    dados.Editar(grupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Editar(GrupoVegetal grupo)
        {
            try
            {
                dados.Editar(grupo);
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

        public List<GrupoVegetal> Listar()
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

        public GrupoVegetal Encontrar(int codigo)
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
