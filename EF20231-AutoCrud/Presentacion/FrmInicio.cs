using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrincipal objformPrincipal = new FrmPrincipal();
            objformPrincipal.Show();
            //this.Hide();
        }
    }
}
