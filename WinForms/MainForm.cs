using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public  partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm(this);
            loginForm.Show();
            loginForm.Location = this.Location;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm(this);
            registrationForm.Show();
            registrationForm.Location = this.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
