
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
            ResultForm resultForm = new ResultForm(this, user);
            Hide();
            resultForm.Show();
            resultForm.Location = Location;
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            CheckQuizForm top20 = new CheckQuizForm(this,false);
            Hide();
            top20.Show();
            top20.Location = Location;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            CheckQuizForm quiz = new CheckQuizForm(this,user,true);
            Hide();
            quiz.Show();
            quiz.Location = Location;
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
