using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Interactor
    {
        private int index = 0;
        private int Points = 0;
        NewExam UserExam = new NewExam();
        List<int> AnswerList = new List<int>(24);
        List<int> WrongAnswers = new List<int>();
        XmlManager XmlFiles = new XmlManager();

        public Interactor() {
           
        }
        public Question GetQuestion() {
            return XmlFiles.QuestionList(UserExam.QuestionsPath)[index];
        }

        public void SetUser(NewExam Ex) {
            UserExam = Ex;
        }

        public NewExam GetResults() {
            CheckAnswers();
            SetPercentage();
            WriteResults();
            return UserExam;
        }

        public void WriteAnswer(int Answer) {
            if (index < AnswerList.Count) {
                AnswerList.RemoveAt(index);
            }
            AnswerList.Insert(index, Answer);
        }

        public void IncreaseIndex() {
            index++;
        }
        public void DecreaseIndex() {          
                index--;          
        }

        public int GetAnswer() {
            if (index < AnswerList.Count)
            {
                return AnswerList[index];
            }
            return 11;
        }

        public void CheckAnswers()
        {
            int QuestionIndex = 0;
            foreach (int Answer in AnswerList)
            {
                if (Answer == CorrectAnswers()[QuestionIndex])
                {
                    Points++;
                }
                else
                {
                    WrongAnswers.Add(QuestionIndex + 1);
                }
                QuestionIndex++;
            }
        }

        public List<int> CorrectAnswers()
        {
            List<int> Answers = new List<int>()
           {3, 2, 3, 1, 2, 2, 3, 2, 5, 4, 5, 2, 4, 4, 3, 4, 1, 2, 4, 2, 1, 4, 5, 1, 2};
            return Answers;
        }

        public int GetIndex() {
            return index;
        }

        private void SetPercentage() {
            UserExam.UserData.PointsPercentage = Points * 100 / 25;            
        }

        private void WriteResults() {
            XmlFiles.WriteResults(UserExam.UserData);           
        }       
    }
}
