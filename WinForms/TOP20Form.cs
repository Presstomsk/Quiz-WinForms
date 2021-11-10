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
    public partial class TOP20Form : Form
    {
        Form formToOpen;
        DataBaseConnect db;
        
        public TOP20Form()
        {
            InitializeComponent();
        }
        public TOP20Form(CheckQuizForm form, string selectedString)
        {
            InitializeComponent();
            formToOpen = form;
            dataGridView1.Columns.Add("column1", "Логин");
            dataGridView1.Columns.Add("column2", "Результат");            
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 160;
            db = new DataBaseConnect();
            var list = db.ShowTop20(selectedString);
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.Login,item.Score);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            formToOpen.Show();
            formToOpen.Location = Location;
        }

        private void TOP20Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
