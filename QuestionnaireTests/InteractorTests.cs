using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace QuestionnaireTests
{
    [TestClass]
    public class InteractorTests
    {
        Questionnaire.Interactor Interactor = new Questionnaire.Interactor();
        [TestMethod]
        public void QuestionAdditionTest()
        {            
            Interactor.SetUser(Questionnaire.Exam.EnglishExam());
            string Expected = "600 m3/h";
            string Actual = Interactor.GetQuestion().Alternative1;
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void ChangeIndexTest()
        {
            Interactor.SetUser(Questionnaire.Exam.EnglishExam());
            Interactor.IncreaseIndex();
            string Expected = "Pyrite";
            string Actual = Interactor.GetQuestion().Alternative1;
            Assert.AreEqual(Expected, Actual);
        }

    }
}
