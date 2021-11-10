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
    public partial class CheckQuizForm : Form
    {
        Form formToOpen;
        public CheckQuizForm()
        {
            InitializeComponent();
        }

        public CheckQuizForm(UserMenuForm form)
        {
            InitializeComponent();
            formToOpen = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            formToOpen.Show();
            formToOpen.Location = Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TOP20Form top20 = new TOP20Form(this);
            Hide();
            top20.Show();
            top20.Location = Location;
        }

        private void CheckQuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
