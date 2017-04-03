using CadastroClientes.Entidades;
using CadastroClientes.Interface.Base;
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
    public partial class CadastroClientes : BaseForm
    {
        //Cria uma variavel do tipo cliente (Entidade)
        Cliente _cliente;

        //Cria uma variavel da nossa camada de lógica
        ClienteLogica _logica;

        //Construtor 1 
        public CadastroClientes(Menu menu) : base(menu)
        {
            //Inicializa o Form (vem por padrão Não Alterar/Remover)
            InitializeComponent();

            //Instancia um objeto da camada de lógica
            _logica = new ClienteLogica();


        }

        //Construtor 2, recebe um cliente como parametro. Através da sobrecarga ': this()' chamamos o construtor acima, para que, antes de executar o código contido abaixo seja executado o código do construtor 1
        public CadastroClientes(Menu menu, Cliente cliente) : this(menu)
        {
            //Preencher o cliente que criamos anteriormente com os dados do cliente que chegou por parametro
            _cliente = cliente;
        }

        //Clique do botão gravar
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Criamos uma instancia já preenchida para a variável cliente que criamos anteriormente
                _cliente = new Cliente
                {
                    Codigo = ObterCodigo(),
                    Nome = txtNome.Text,
                    Endereco = txtEnd.Text,
                    Bairro = txtBairro.Text,
                    Estado = cbbEstado.Text,
                    Telefone = txtTel.Text,
                    Celular = txtCel.Text,
                    Email = txtEmail.Text
                };

                //Salvamos o cliente através do método Salvar da camada de logica
                _logica.Salvar(_cliente);

                MessageBox.Show("Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Os campos em negrito são obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        /// <summary>
        /// Método que obtem o codigo do cliente baseado nas informações de tela
        /// </summary>
        /// <returns>Codigo do cliente</returns>
        private int ObterCodigo()
        {
            //Verifica se a caixa de texto txtCod possui a propriedade Text diferente de vazio ou null, caso não seja nula retorna o seu conteúdo convertido para int, caso seja nula retorna 0. Para tal retorno utilizamos um if ternário https://msdn.microsoft.com/pt-br/library/zakwfxx4(v=vs.100).aspx
            return !string.IsNullOrEmpty(txtCod.Text) ? Convert.ToInt32(txtCod.Text) : 0;
        }

        //Evento ao clicar no botao Novo Cadastro
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Metodo que limpa os campos da tela de cadastro
        /// </summary>
        private void LimparCampos()
        {
            //Limpar textos
            txtCod.Text = "";
            txtNome.Text = "";
            txtEnd.Text = "";
            txtBairro.Text = "";
            cbbEstado.Text = "";
            txtTel.Text = "";
            txtCel.Text = "";
            txtEmail.Text = "";

            //Colocar o foco no textbox txtNome
            txtNome.Focus();
        }

        //Evento ao clicar no botao VEr cadastro
        private void btnVer_Click(object sender, EventArgs e)
        {
            //Instancia um objeto do tipo ListaClientes (Form)
            var lista = new ListaClientes(FormularioMenu);

            //Mostra o formulário LIstaClientes
            lista.Show();

            //Fecha o formulário atual (CadastroClientes)
            Hide();
        }

        //Evento ao carregar form
        private void Form1_Load(object sender, EventArgs e)
        {
            //Verifica se o cliente é diferente de null, caso seja, preenche os campos do formulario com as informações deste cliente. Esta verificação deve ser feita pois temos 2 construtores neste form, um vazio e o outro que recebe uma instancia de cliente
            if (_cliente != null)
            {
                //Preenche os campos
                txtCod.Text = _cliente.Codigo.ToString();
                txtNome.Text = _cliente.Nome;
                txtEnd.Text = _cliente.Endereco;
                txtBairro.Text = _cliente.Bairro;
                cbbEstado.Text = _cliente.Estado;
                txtTel.Text = _cliente.Telefone;
                txtCel.Text = _cliente.Celular;
                txtEmail.Text = _cliente.Email;
            }
        }

        //Evento ao clicar no botão Remover Cadastros
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                //Cria uma variavel do tipo DialogResult para obter a decisão do usuário através de uma messagebox com botoes Sim e Nao
                var result = MessageBox.Show($"Você tem certeza que deseja remover {txtNome.Text}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //Caso o usuário tenha clicado em sim o codigo abaixo será executado
                if (result == DialogResult.Yes)
                {
                    //Obter o codigo através do metodo que criamos anteriormente
                    var codigo = ObterCodigo();

                    //Verifica seo codigo obtido é maior que 0, caso verdadeiro executa o método remover da camada de logica, mostra mensagem de confirmação e limpa os campos.
                    if (codigo > 0)
                    {
                        _logica.Remover(codigo);

                        MessageBox.Show("Removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
