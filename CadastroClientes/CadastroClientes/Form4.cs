using CadastroClientes.Entidades;
using CadastroClientes.LogicasNegocio;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                var logica = new VegetalLogica();
                dgvVegetal.DataSource = logica.Mostrar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvVegetal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var codigo = dgvVegetal.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                MessageBox.Show(codigo);
            }
        }
    }
}
