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

namespace CadastroClientes
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
                    var conn = Conexao.ObterConexao();
                    var query = $"insert into Cliente (Nome, Endereco, Bairro, Estado, Telefone, Celular, Email) values (@Nome, @End, @Bairro, @Estado, @Tel, @Cel, @Email)";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@End", txtEnd.Text);
                    cmd.Parameters.AddWithValue("@Bairro", txtBairro.Text);
                    cmd.Parameters.AddWithValue("@Estado", cbbEstado.Text);
                    cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Cel", txtCel.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao Salvar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
