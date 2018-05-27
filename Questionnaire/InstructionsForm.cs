using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Questionnaire
{
    public partial class InstructionsForm : DevExpress.XtraEditors.XtraForm
    {
        NewExam UserExam = new NewExam();
        LabelTexts Labels = new LabelTexts();

        public InstructionsForm(NewExam E)
        {
            InitializeComponent();
            UserExam = E;
            Labels = UserExam.LabelsTexts;
            SetLabels();
        }

        private void SetLabels() {
            SetInstructionsLabels();       
            AgeLabel.Text = Labels.Age;
            ExamStartButton.Text = Labels.Button;
            GenderLabel.Text = Labels.Gender;
            radioGroup1.Properties.Items[0].Description = Labels.MaleGender;
            radioGroup1.Properties.Items[1].Description = Labels.FemaleGender;
            radioGroup1.Properties.Items[2].Description = Labels.NonSpecGender;
        }

        private void SetInstructionsLabels(){
            Header.Text = Labels.Instructions[0];
            Intent1.Text = Labels.Instructions[1];
            SubHeader.Text = Labels.Instructions[2];
            Intent2.Text = Labels.Instructions[3];
        }

        private void ExamForm_Click(object sender, EventArgs e)
        {
            if (TextBoxAreEmpty())
            {
                MessageBox.Show(Labels.InstructionsMessage);
            }
            else
            {
                UserExam.UserData = UserData();
                ExamForm Ex = new ExamForm(UserExam);
                Hide();
                Ex.ShowDialog();
                Close();
            }            
        }

        private bool TextBoxAreEmpty()
        {
            foreach (TextBox Box in layoutControl1.Controls.OfType<TextBox>()) {
                if (String.IsNullOrEmpty(Box.Text)) {
                    return true;
                }
            }
            return false;
        }
        private UserData UserData() {
            UserData NewUser = new UserData();
            NewUser.ID = IDBox.Text;
            NewUser.Instructor = InstructorBox.Text;
            NewUser.Age = AgeBox.Text;
            NewUser.Gender = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description;
            return NewUser;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TitleForm TF = new TitleForm();
            Hide();
            TF.ShowDialog();
            Close();
        }
    }
}