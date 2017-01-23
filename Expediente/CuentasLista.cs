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
    public partial class CuentasLista : Form
    {
        public CuentasLista()
        {
            InitializeComponent();
        }

        private void CuentasLista_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            LoadData();
        }

        private void LoadData()
        {
            DataTable TableView = new DataTable();
            Database_classes.AccountDB accountDB = new Database_classes.AccountDB();

            try
            {
                TableView = accountDB.AccountGetList();

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
    }
}
