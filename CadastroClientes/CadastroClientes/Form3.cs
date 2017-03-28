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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnFinaliza_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (txtTam.Text == ""))
                MessageBox.Show("Os campos em negrito são obrigatóros!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    var vegetal = new Vegetal();
                    vegetal.Nome = txtNome.Text;
                    vegetal.Tamanho = txtTam.Text;

                    var logica = new VegetalLogica();
                    logica.Finalizar(vegetal);

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var lista = new Form4();
            lista.Show();
        }
    }
}
