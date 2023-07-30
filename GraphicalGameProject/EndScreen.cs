using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalGameProject
{
    public partial class EndScreen : Form
    {
        public EndScreen()
        {
            InitializeComponent();
            exit.FlatStyle = FlatStyle.Flat;
            exit.FlatAppearance.BorderSize = 0;
            restart.FlatStyle = FlatStyle.Flat;
            restart.FlatAppearance.BorderSize = 0;
        }

        private void restrart_Click(object sender, EventArgs e)
        {
            Form form = new main();
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
