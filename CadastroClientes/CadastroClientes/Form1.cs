using CadastroClientes.Entidades;
using CadastroClientes.LogicasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes.Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text == "") || (txtTel.Text == ""))
                MessageBox.Show("Os campos em negrito são obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    var cliente = new Cliente();
                    cliente.Nome = txtNome.Text;
                    cliente.Endereco = txtEnd.Text;
                    cliente.Bairro = txtBairro.Text;
                    cliente.Estado = cbbEstado.Text;
                    cliente.Telefone = txtTel.Text;
                    cliente.Celular = txtCel.Text;
                    cliente.Email = txtEmail.Text;

                    var logica = new ClienteLogica();
                    logica.Salvar(cliente);

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("O telefone deve ter 8 ou 9 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEnd.Text = "";
            txtBairro.Text = "";
            cbbEstado.Text = "";
            txtTel.Text = "";
            txtCel.Text = "";
            txtEmail.Text = "";
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            var lista = new Lista();
            lista.Show();
        }
    }
}
