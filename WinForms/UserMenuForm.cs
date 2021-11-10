﻿
using System.Windows.Forms;

namespace WinForms
{
    public partial class UserMenuForm : Form
    {
        User user;
        public UserMenuForm()
        {
            InitializeComponent();
        }
        public UserMenuForm(User user)
        {
            InitializeComponent();
            label1.Text = user.Login;
            this.user = user;
        }

        private void UserMenuForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void UserMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm(this, user);
            Hide();
            settingForm.Show();
            settingForm.Location = Location;
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
