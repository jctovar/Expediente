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
    public partial class Paciente : Form
    {
        public int Id = 0;
        public Paciente()
        {
            InitializeComponent();
        }

        private void Paciente_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            loadGender();

            if (Id != 0)
            {
                loadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData()
        {
            Object_classes.User user = new Object_classes.User();
            Database_classes.UserDB userDB = new Database_classes.UserDB();

            try
            {
                user = userDB.GetUser(Id);
                if (user != null)
                {
                    textBox1.Text = user.Firstname;
                    textBox2.Text = user.Lastname;
                    textBox3.Text = user.Email;
                    dateTimePicker1.Value = user.Birthday;
                    comboBox1.SelectedValue = user.Gender;
                }
                else
                {
                    MessageBox.Show("No se encontro la cuenta!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio el siguiente error {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Select();
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
            }
        }

        private void saveData()
        {
            Object_classes.User user = new Object_classes.User();
            Database_classes.UserDB userDB = new Database_classes.UserDB();

            user.Id = Id;
            user.Firstname = textBox1.Text;
            user.Lastname = textBox2.Text;
            user.Email = textBox3.Text;

            try
            {
                if (userDB.UpdateUser(user) == true)
                {
                    MessageBox.Show("Datos guardados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio el siguiente error {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void loadGender()
        {
            DataTable TableView = new DataTable();
            Database_classes.UserDB userDB = new Database_classes.UserDB();

            TableView = userDB.GenderGetList();

            comboBox1.DataSource = TableView;
            comboBox1.ValueMember = "gender_id";
            comboBox1.DisplayMember = "gender_name";
        }
    }
}
