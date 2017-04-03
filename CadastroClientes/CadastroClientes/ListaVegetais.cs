using CadastroClientes.Entidades;
using CadastroClientes.Interface.Base;
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
    public partial class ListaVegetais : BaseForm
    {
        VegetalLogica _logica;

        public ListaVegetais(Menu menu) : base(menu)
        {
            InitializeComponent();

            _logica = new VegetalLogica();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                var logica = new VegetalLogica();
                dgvVegetal.DataSource = logica.Listar();

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
                var codigo = Convert.ToInt32(dgvVegetal.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());

                try
                {
                    var vegetal = _logica.Encontrar(codigo);

                    if(vegetal == null)
                    {
                        MessageBox.Show("Nenhum vegetal foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var form = new CadastroVegetais(FormularioMenu, vegetal);

                        form.Show();

                        Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
