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
    
    public partial class ResultForm : Form
    {
        Form formToOpen;
        DataBaseConnect db;
        public ResultForm()
        {
            InitializeComponent();
        }

        public ResultForm(UserMenuForm form, User user)
        {
            InitializeComponent();
            formToOpen = form;
            dataGridView1.Columns.Add("column1", "Дата");
            dataGridView1.Columns.Add("column2", "Название теста");
            dataGridView1.Columns.Add("column3", "Результат");
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            db = new DataBaseConnect();
            var list = db.ShowScoreHistory(user);
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.Date, item.TestName,item.Score);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            formToOpen.Show();
            formToOpen.Location = Location;
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
