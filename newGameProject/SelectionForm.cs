using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGameProject
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
            options1.Visible = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form form = new Main();
            this.Hide();
            form.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            options1.Visible = true;
        }

        private void options1_Click(object sender, EventArgs e)
        {
            options1.Visible = false;
        }
    }
}
