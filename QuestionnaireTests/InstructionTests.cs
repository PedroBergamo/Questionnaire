using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestionnaireTests
{
    [TestClass]
    public class InstructionTests
    {        
        Questionnaire.InstructionsForm InstForm= new Questionnaire.InstructionsForm(Questionnaire.Exam.EnglishExam());

        [TestMethod]
        public void TextBoxAreEmptyTest()
        {
            string Expected = "Name";
            string Actual = Questionnaire.Exam.EnglishExam().LabelsTexts.name;
            Assert.AreEqual(Expected, Actual);
        }

 
    }
}
