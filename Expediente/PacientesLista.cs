using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expediente
{
    public partial class PacientesLista : Form
    {
        public PacientesLista()
        {
            InitializeComponent();
        }

        private void PacientesLista_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
        }
    }
}
