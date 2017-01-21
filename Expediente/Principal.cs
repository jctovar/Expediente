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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creditos creditos = new Creditos();
            creditos.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion configuracion = new Configuracion();
            configuracion.ShowDialog();
        }

        private void nuevaNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotaMedica nota = new NotaMedica();
            nota.ShowDialog();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de querer salir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                // Cancel the Closing event from closing the form.
                e.Cancel = true;
            }
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseDatos database = new BaseDatos();
            database.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PacientesLista pacientes = new PacientesLista();
            pacientes.ShowDialog();
        }
    }
}
