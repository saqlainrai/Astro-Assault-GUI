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
    public partial class EndScreen : Form
    {
        public EndScreen()
        {
            InitializeComponent();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (form != this && !form.Visible)
                {
                    form.Close(); // Close the hidden form
                }
            }
            this.Close();
        }
    }
}
