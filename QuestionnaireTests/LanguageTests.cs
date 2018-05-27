using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestionnaireTests
{
    [TestClass]
    public class LanguageTests
    {        
        [TestMethod]
        public void EnglishExamTest()
        {
            string Expected = "Name";
            string Actual = Questionnaire.Exam.EnglishExam().LabelsTexts.name;
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void PortugueseExamTest()
        {
            string Expected = "Nome";
            string Actual = Questionnaire.Exam.PortugueseExam().LabelsTexts.name;
            Assert.AreEqual(Expected, Actual);
        }
    }
}
