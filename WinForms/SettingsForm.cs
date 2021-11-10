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
    public partial class SettingsForm : Form
    {
        Form formToOpen;
        DataBaseConnect db;
        User user;
        public SettingsForm()
        {
            InitializeComponent();
        }
        public SettingsForm(UserMenuForm form, User user)
        {
            InitializeComponent();
            formToOpen = form;
            this.user = user;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formToOpen.Show();
            formToOpen.Location = Location;
            Hide();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = "^[0-9a-zA-Zа-яА-Я]+$";
            bool checkPassword;
            bool passFlag, dateFlag;
            label6.Text = "";
            label1.Text = "";
            checkPassword = Regex.IsMatch(textBox2.Text, pattern);
            if (!checkPassword && textBox2.Text != "")
            {
                label6.Text = "Недопустимые символы";
                label6.ForeColor = Color.Red;
            }
            if (textBox2.Text == "")
            {
                db = new DataBaseConnect();
                dateFlag = db.DateOfBirthChange(user, dateTimePicker1.Value);
                if (dateFlag)
                {
                    label1.Text = "Дата рождения изменена";
                    label1.ForeColor = Color.Green;
                }
            }
            if (checkPassword)
            {
                db = new DataBaseConnect();
                passFlag = db.PassChange(user, textBox2.Text);
                dateFlag = db.DateOfBirthChange(user, dateTimePicker1.Value);
                if (passFlag)
                {
                    label6.Text = "Пароль изменен";
                    label6.ForeColor = Color.Green;
                }
                if (dateFlag)
                {
                    label1.Text = "Дата рождения изменена";
                    label1.ForeColor = Color.Green;
                }
            }
        }
    }
}
