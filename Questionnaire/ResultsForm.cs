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
    public partial class ResultsForm : DevExpress.XtraEditors.XtraForm
    {
        NewExam UserExam = new NewExam();
        
        public ResultsForm(NewExam NE)
        {
            UserExam = NE;
            InitializeComponent();
            SetLabels();
        }

        private void SetLabels()
        {
            LabelTexts Labels = UserExam.LabelsTexts;
            UserData User = UserExam.UserData;
            IDLabel.Text = "ID: " + User.ID;
            InstructorLabel.Text = Labels.instructor + ": " + User.Instructor;
            PercentLabel.Text = Labels.Points + ": " + User.PointsPercentage + "%";
            EndButton.Text = Labels.ExamEnderButtonText;
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}