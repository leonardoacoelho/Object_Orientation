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

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cadCli = new CadastroClientes(this);

            cadCli.Show();
        }

        private void vegetaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cadVeg = new CadastroVegetais(this);

            cadVeg.Show();

        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cadGrupo = new GruposVegetais(this);

            cadGrupo.Show();
        }
    }
}