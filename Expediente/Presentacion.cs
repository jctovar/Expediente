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
    public partial class Presentacion : Form
    {
        private static System.Timers.Timer aTimer;

        public Presentacion()
        {
            InitializeComponent();
        }

        private void Presentacion_Load(object sender, EventArgs e)
        {
            label5.Text = Application.ProductName;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
