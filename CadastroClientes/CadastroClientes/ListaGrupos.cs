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
    public partial class ListaGrupos : BaseForm
    {
        GrupoVegetalLogica _logica;

        public ListaGrupos(Menu menu) : base(menu)
        {
            InitializeComponent();

            _logica = new GrupoVegetalLogica();
        }

        private void ListaGrupos_Load(object sender, EventArgs e)
        {
            try
            {
                var logica = new GrupoVegetalLogica();
                dgvListaGrupos.DataSource = logica.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListaGrupos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var codigo = Convert.ToInt32(dgvListaGrupos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());

                try
                {
                    var grupo = _logica.Encontrar(codigo);

                    if(grupo == null)
                    {
                        MessageBox.Show("Nenhum grupo foi encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var form = new GruposVegetais(FormularioMenu, grupo);

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
