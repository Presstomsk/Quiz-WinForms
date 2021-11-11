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
    
    public partial class QuizForm : Form
    {

        Form formToOpen;
        Questions test= new Questions();
        List<Questions> deserializedQuestions;
        DataBaseConnect db;
        User user;

        uint answ, score;        
        string testName, numberOfQuestions;

        int counter;
        string path;

        Dictionary<string,string> Path = new Dictionary<string, string>
            {
                {"История","history.json"},
                {"География","geography.json"}
            };

        public QuizForm()
        {
            InitializeComponent();
        }

        public QuizForm(CheckQuizForm form, User user ,string selectedString)
        {
            InitializeComponent();
            label6.Hide();          
            formToOpen = form;
            testName = selectedString;

            label2.Text = $"\"{selectedString}\"";
            label3.Text = "";
            label4.Text = "";

            path = Path[selectedString];

            deserializedQuestions = test.QuestionsDeserialization(path);

            label3.Text = deserializedQuestions[counter].Question;

            foreach (var ans in deserializedQuestions[counter].Answers)
            { 
                label4.Text += $"{ans.Key} - {ans.Value}\n";
                numberOfQuestions = ans.Key;
            }

            this.user = user;
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            formToOpen.Show();
            formToOpen.Location = Location;
        }

        private void QuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = $"^[1-{numberOfQuestions}]" + "{1}$";
            bool checkResult;
            checkResult = Regex.IsMatch(textBox1.Text, pattern);


            if (checkResult && counter < 19)
            {
                answ = Convert.ToUInt32(textBox1.Text);
                if (answ == deserializedQuestions[counter].TrueAnswer) score++;
                counter++;
                deserializedQuestions = test.QuestionsDeserialization(path);
                label4.Text = "";
                label3.Text = deserializedQuestions[counter].Question;
                foreach (var ans in deserializedQuestions[counter].Answers)
                {
                    label4.Text += $"{ans.Key} - {ans.Value}\n";
                    numberOfQuestions = ans.Key;
                }
                textBox1.Text = "";
                label7.Hide();
            }
            else if (!checkResult && counter < 19)
            {
            
                    label7.Show();
                    label7.Text = "Введите корректное значение";
                    label7.ForeColor = Color.Red;
                
            }
            else
            {

                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox1.Hide();
                button1.Hide();
                label6.Show();
                label7.Hide();
                label6.Text = $"Ваш результат: {score} из 20";
                db = new DataBaseConnect();
                db.ScoreHistory(user, testName, score);
            }
        }
    }
}
