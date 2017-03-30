using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes.Interface
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void btnCadCli_Click(object sender, EventArgs e)
        {
            var cadCli = new CadastroClientes();
            cadCli.Show();
        }

        private void btnCadProd_Click(object sender, EventArgs e)
        {
            var cadProd = new CadastroVegetais();
            cadProd.Show();
        }

    }
}