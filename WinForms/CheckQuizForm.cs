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

        User user;
        string selectedString;
        bool formFlag;
        public CheckQuizForm()
        {
            InitializeComponent();
        }

        public CheckQuizForm(UserMenuForm form, bool flag)
        {
            InitializeComponent();
            formToOpen = form;            
            comboBox1.Items.AddRange(new string[] { "История", "География" });
            comboBox1.Text = comboBox1.Items[0].ToString();
            formFlag = flag;

        }
        public CheckQuizForm(UserMenuForm form, User user, bool flag)
        {
            InitializeComponent();
            formToOpen = form;
            comboBox1.Items.AddRange(new string[] { "История", "География" });
            comboBox1.Text = comboBox1.Items[0].ToString();
            formFlag = flag;
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            formToOpen.Show();
            formToOpen.Location = Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!formFlag)
            {
                TOP20Form top20 = new TOP20Form(this, selectedString);
                Hide();
                top20.Show();
                top20.Location = Location;
            }
            else 
            {
                QuizForm quiz = new QuizForm(this, user, selectedString);
                Hide();
                quiz.Show();
                quiz.Location = Location;
            }
        }

        private void CheckQuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedString = comboBox1.SelectedItem.ToString();            
        }
    }
}
