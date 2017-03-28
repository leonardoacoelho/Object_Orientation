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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void btnCadCli_Click(object sender, EventArgs e)
        {
            var cadCli = new Form1();
            cadCli.Show();
        }

        private void btnCadProd_Click(object sender, EventArgs e)
        {
            var cadProd = new Form3();
            cadProd.Show();
        }

    }
}