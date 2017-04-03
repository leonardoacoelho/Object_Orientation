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
    public partial class GruposVegetais : BaseForm
    {
        GrupoVegetal _grupo;

        GrupoVegetalLogica _logica;

        public GruposVegetais(Menu menu) : base(menu)
        {
            InitializeComponent();

            _logica = new GrupoVegetalLogica();
        }

        public GruposVegetais(Menu menu, GrupoVegetal grupo) : this(menu)
        {
            _grupo = grupo;
        }

        private void GruposVegetais_Load(object sender, EventArgs e)
        {
            if (_grupo != null)
            {
                txtCodigo.Text = _grupo.Codigo.ToString();
                txtNome.Text = _grupo.Nome.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
                MessageBox.Show("Os campos em negrito são obrigatóros!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
                try
                {
                    var grupo = new GrupoVegetal
                    {
                        Codigo = ObterCodigo(),
                        Nome = txtNome.Text
                    };

                    var logica = new GrupoVegetalLogica();
                    logica.Salvar(grupo);

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpaCampos();

                    txtNome.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            txtNome.Focus();
        }

        private void LimpaCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var lista = new ListaGrupos(FormularioMenu);
            lista.Show();

            Hide();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show($"Tem certeza que deseja excluir {txtNome.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    var codigo = ObterCodigo();

                    if(codigo >= 0)
                    {
                        _logica.Remover(codigo);

                        MessageBox.Show("Removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpaCampos();

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

