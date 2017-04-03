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
    public partial class CadastroVegetais : BaseForm
    {
        Vegetal _vegetal;

        VegetalLogica _logica;

        public CadastroVegetais(Menu menu) : base(menu)
        {
            InitializeComponent();

            _logica = new VegetalLogica();
        }

        public CadastroVegetais(Menu menu, Vegetal vegetal) : this(menu)
        {
            _vegetal = vegetal;
        }

        private void CadastroVegetais_Load(object sender, EventArgs e)
        {
            var grupoVegetalLogica = new GrupoVegetalLogica();

            var grupos = grupoVegetalLogica.Listar();

            if (grupos != null)
            {
                foreach (var grupo in grupos)
                {
                    cbxGrupo.Items.Add(grupo);
                }
            }

            if (_vegetal != null)
            {
                txtCodigo.Text = _vegetal.Codigo.ToString();
                txtNome.Text = _vegetal.Nome.ToString();
                txtTam.Text = _vegetal.Tamanho.ToString();

                var grupo = grupos.FirstOrDefault(x => x.Codigo == _vegetal.GrupoVegetal_Codigo);
                var index = grupos.IndexOf(grupo);
                cbxGrupo.SelectedIndex = index;
            }

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var lista = new ListaVegetais(FormularioMenu);
            lista.Show();

            Hide();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {


            try
            {
                var grupo = (GrupoVegetal)cbxGrupo.SelectedItem;

                var vegetal = new Vegetal
                {
                    Codigo = ObterCodigo(),
                    Nome = txtNome.Text,
                    Tamanho = txtTam.Text,
                    GrupoVegetal = grupo,
                    GrupoVegetal_Codigo = grupo?.Codigo ?? 0
                };

                var logica = new VegetalLogica();
                logica.Salvar(vegetal);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();

                txtNome.Focus();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os campos em negrito são obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            txtNome.Focus();
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtTam.Text = "";
            cbxGrupo.SelectedIndex = -1;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show($"Tem certeza que deseja excluir {txtNome.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var codigo = ObterCodigo();

                    if (codigo >= 0)
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
