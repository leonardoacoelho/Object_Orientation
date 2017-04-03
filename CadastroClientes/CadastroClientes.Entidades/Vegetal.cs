using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.Entidades
{
    public class Vegetal
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Tamanho { get; set; }

        public GrupoVegetal GrupoVegetal { get; set; }

        public int GrupoVegetal_Codigo { get; set; }

    }
}
