using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes.Interface.Base
{
    public partial class BaseForm : Form
    {
        protected Menu FormularioMenu;

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(Menu menu) : this()
        {
            FormularioMenu = menu;
            MdiParent = menu;
        }
    }
}
