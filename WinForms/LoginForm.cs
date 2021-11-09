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
    
    public partial class LoginForm : Form
    {
        User user;
        DataBaseConnect db;
        bool choice;
        Form formToOpen;
        public LoginForm(Form1 form)
        {
            InitializeComponent();
            formToOpen = form;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
                user = new User(textBox1.Text, textBox2.Text);
                db = new DataBaseConnect();
                choice = db.LogPasCheck(user);
                if (!choice)
                {
                    label7.Text = "Некорректные данные!";
                    label8.Text = "Измените данные или пройдите регистрацию";                              
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                }
                if (choice)
                {

                    UserMenuForm userMenuForm = new UserMenuForm(user);
                    userMenuForm.Show();
                    userMenuForm.Location = this.Location;
                    this.Hide();

                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            formToOpen.Show();
            formToOpen.Location = this.Location;
        }
    }
}
