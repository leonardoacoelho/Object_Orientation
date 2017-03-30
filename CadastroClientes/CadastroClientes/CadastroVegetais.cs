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
    public partial class CadastroVegetais : Form
    {
        Vegetal _vegetal;

        VegetalLogica _logica;

        public CadastroVegetais()
        {
            InitializeComponent();

            _logica = new VegetalLogica();
        }

        public CadastroVegetais(Vegetal vegetal) : this()
        {
            _vegetal = vegetal;
        }

        private void CadastroVegetais_Load(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var lista = new ListaVegetais();
            lista.Show();

            Hide();
        }

        private void btnGravar_Click(object sender, EventArgs e)
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
                    logica.Salvar(vegetal);

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();

                    txtNome.Focus();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            txtNome.Focus();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtTam.Text = "";
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show($"Tem certeza que deseja excluir {txtNome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    var codigo = ObterCodigo();

                    if(codigo >= 0)
                    {
                        _logica.Remover(codigo);

                        MessageBox.Show("Removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();

                        txtNome.Focus();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int ObterCodigo()
        {
            return !string.IsNullOrEmpty(txtCodigo.Text) ? Convert.ToInt32(txtCodigo.Text) : 0;
        }
    }
}
