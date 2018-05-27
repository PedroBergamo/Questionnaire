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
using System.Xml.Serialization;
using System.IO;

namespace Questionnaire
{
    public partial class TitleForm : DevExpress.XtraEditors.XtraForm
    {
        public TitleForm()
        {
            InitializeComponent();
        }

        private void PortugueseButton_Click_1(object sender, EventArgs e)
        {
            NewExam Ex = Exam.PortugueseExam();
            InstructionsForm InstructForm = new InstructionsForm(Ex);
            Hide();
            InstructForm.Text = Ex.LabelsTexts.ExamHeader;
            InstructForm.ShowDialog();
            Close();
        }

        private void EnglishButton_Click_1(object sender, EventArgs e)
        {
            NewExam Ex = Exam.EnglishExam();
            InstructionsForm InstructForm = new InstructionsForm(Ex);
            Hide();
            InstructForm.Text = Ex.LabelsTexts.ExamHeader;
            InstructForm.ShowDialog();
            Close();
        }

        private void DataAnalysisButton_Click(object sender, EventArgs e)
        {
            DataAnalysis.MainForm MF = new DataAnalysis.MainForm();
            Hide();
            MF.ShowDialog();
            Close();
        }
    }
}