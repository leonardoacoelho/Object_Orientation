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
    public partial class ListaClientes : Form
    {
        //Cria uma variável da camada de lógica de negócios
        ClienteLogica _logica;

        //Construtor
        public ListaClientes()
        {
            //Inicializa o Form (vem por padrão Não Alterar/Remover)
            InitializeComponent();

            //Instancia um objeto da camada de lógica
            _logica = new ClienteLogica();
        }

        //Evento de load do Form
        private void Lista_Load(object sender, EventArgs e)
        {
            try
            {
                //Preenche a propriedade DataSource do grid com os clientes retonados pelo método Listar da camada de lógica, isso fará com que estes registros apareçam no grid mediante configuração das colunas do mesmo.
                dgvClientes.DataSource = _logica.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento de duplo clique na célula do grid
        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Obtem o indice da linha que foi clicada no grid, a variável 'e' trará métodos referentes ao evento disparado, neste caso podemos por exemplo obter o indice da linha          
            if (e.RowIndex >= 0)
            {
                //Criação da variavel codigo que é preenchida através do valor da célula 'codigo' da linha do grid que foi clicada e converte para int
                var codigo = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());

                try
                {
                    //Criação da variavel cliente que recebe um cliente através do método encontrar da camada de lógica, para isso passamos como parâmetro o codigo que recuperamos anteriormente
                    var cliente = _logica.Encontrar(codigo);

                    //Verificamos se o cliente encontrado é null, caso sim exibimos uma menssagem de erro 
                    if (cliente == null)
                        MessageBox.Show("Nenhum cliente foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        //Caso não, instanciamos um objeto do form de cadastro de clientes passando como parametro o cliente encontrado
                        var form = new CadastroClientes(cliente);

                        //Abrir o form CadastroClientes
                        form.Show();

                        //Fechar o form atual(ListaClientes)
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
