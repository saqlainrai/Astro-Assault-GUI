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
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            progressBar.Value = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Value++;
            if (progressBar.Value == 100)
            {
                timer.Enabled = false;
                this.Hide();
                Form form = new SelectionForm();
                form.Show();
            }
        }
    }
}
