using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questionnaire
{
    public partial class ExamForm : Form
    {
        Interactor Control = new Interactor();
        NewExam UserExam = new NewExam();
        LabelTexts Labels = new LabelTexts();
        
        public List<int> WrongAnswers = new List<int>();
        public ExamForm(NewExam Ex)
        {
            InitializeComponent();
            UserExam = Ex;
            Labels = Ex.LabelsTexts;
            Control.SetUser(UserExam);          
            SetOtherLabels();
            SetQuestionLabels();
            SetProgressBarColor();
            InitiateTimer();
            CheckRadioButton();
            Alt1.Checked = false;
        }
        private void CheckRadioButton()
        {
            int Button = 0;
            int Answer = Control.GetAnswer() - 1;
            foreach (RadioButton Option in gbRadioButtons.Controls.OfType<RadioButton>())
            {
                if (Button == Answer)
                {
                    Option.Checked = true;
                    break;
                }
                Option.Checked = false;
                Button++;
            }
        }

        private void SetQuestionLabels() {
            Question Quest = Control.GetQuestion();
            string Number = (Control.GetIndex() + 1).ToString();
            NumberLabel.Text = Number + "/25";
            QuestionLabel.Text = Control.GetIndex() + 1 + ". " + Quest.Quest;
            Alt1.Text = Quest.Alternative1;
            Alt2.Text = Quest.Alternative2;
            Alt3.Text = Quest.Alternative3;
            Alt4.Text = Quest.Alternative4;
            Alt5.Text = Quest.Alternative5;
            NextButton.Text = Labels.NextButton;
            
        }

        private void SetOtherLabels() {
            ExamHeaderLabel.Text = Labels.ExamHeader;            
            BackButton.Text = Labels.BackButton;
        }

        private void SetProgressBarColor() {
            progressBarControl1.Position = 0;
            progressBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            progressBarControl1.LookAndFeel.SetSkinMaskColors(Color.Black, 
                Color.FromArgb(115, 155, 255));
         }       

        private void NextButton_Click(object sender, EventArgs e)
        {
            progressBarControl1.Position++;
            Control.WriteAnswer(AnswerIndex());
            Control.IncreaseIndex();
            CheckIndex();
            CheckRadioButton();
        } 
 
        private int AnswerIndex() {
            int AnswerIndex = 1;
            bool RadioIsNotChecked = true;
            foreach (RadioButton rdo in gbRadioButtons.Controls.OfType<RadioButton>())
            {
                if (rdo.Checked)
                {
                    RadioIsNotChecked = false;
                    break;
                }
                AnswerIndex++;
            }
            if (RadioIsNotChecked) {
                AnswerIndex = 8;
            }
            return AnswerIndex;
        }

        private void CheckIndex()
        {

            if (Control.GetIndex() < 24)
            {
                SetQuestionLabels();
            }
            else if (Control.GetIndex() == 24) {
                SetQuestionLabels();
                NextButton.Text = Labels.FinalQuestionButton;
            }
            else
            {
                CallResultsForm();
            }
        }
     
        private void CallResultsForm()
        {
            ResultsForm RF = new ResultsForm(Control.GetResults());
            Hide();
            RF.ShowDialog();
            Close();
        }

        private void InitiateTimer() {
            ExamTimer.Interval = 2000; 
            ExamTimer.Tick += new EventHandler(ExamTimer_Tick);
            ExamTimer.Start();
        }
        
        double timeLeft = 3600;
        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft <= 0)
            {
                TimeIsUp();
            }
            timeLeft = timeLeft - 1;
            var timespan = TimeSpan.FromSeconds(timeLeft);
            TimerLabel.Text = timespan.ToString(@"mm\:ss");
        }

        private void TimeIsUp()
        {
                ExamTimer.Stop();
                MessageBox.Show("Time's up!", "Time has elapsed", MessageBoxButtons.OK);
                CallResultsForm();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (Control.GetIndex() > 0)
            {
                Control.WriteAnswer(AnswerIndex());
                Control.DecreaseIndex();
                CheckIndex();
                progressBarControl1.Position--;
                CheckRadioButton();
            }
        }
     
        private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Control.GetIndex() < 24)
            if (MessageBox.Show("Are you sure you want exit the theory exam?", "Vex", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
