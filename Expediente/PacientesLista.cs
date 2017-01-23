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

            LoadData();
        }

        private void LoadData()
        {
            DataTable TableView = new DataTable();
            Database_classes.UserDB userDB = new Database_classes.UserDB();

            try
            {
                TableView = userDB.UserGetList();

                dataGridView1.DataSource = TableView;
                dataGridView1.AutoResizeColumns();
                dataGridView1.Columns[0].Visible = false;

                toolStripStatusLabel1.Text = string.Format("Se encontraron {0} registros", TableView.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio el siguiente error {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            Paciente paciente = new Paciente();

            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

            paciente.Id = Convert.ToInt16(selectedRow.Cells[0].Value);

            if (paciente.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
