using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class RegistrationForm : Form
    {
        Form formToOpen;
        User user;
        DataBaseConnect db;
        bool choice;

        public RegistrationForm(MainForm form)
        {
            InitializeComponent();
            formToOpen = form;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formToOpen.Show();
            formToOpen.Location = this.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = "^[0-9a-zA-Zа-яА-Я]+$";
            bool checkLogin, checkPassword;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            checkLogin = Regex.IsMatch(textBox1.Text, pattern);
            checkPassword = Regex.IsMatch(textBox2.Text, pattern);
            if (!checkLogin)
            {
                label5.Text = "Недопустимые символы";
                label5.ForeColor = Color.Red;
            }
            if (!checkPassword)
            {
                label6.Text = "Недопустимые символы";
                label6.ForeColor = Color.Red;
            }
            if (checkLogin && checkPassword)
            {
                user = new User(textBox1.Text, textBox2.Text, dateTimePicker1.Value);
                db = new DataBaseConnect();
                choice = db.LoginCheck(user); 
                if (!choice)
                {
                    label7.Text = "Введённый вами логин уже зарегистрирован!";
                    label8.Text = "Пройдите регистрацию повторно";
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                }
                if (choice)
                {
                    db.NewUser(user);
                    UserMenuForm userMenuForm = new UserMenuForm(user);
                    userMenuForm.Show();
                    userMenuForm.Location = this.Location;
                    this.Hide();

                }
            }
        }
    }
}
