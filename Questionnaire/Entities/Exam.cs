using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire
{
    public class Exam
    {
        public static NewExam EnglishExam()
        {
            NewExam Ex = new NewExam();
            Ex.LabelsTexts = EnglishLabels();
            Ex.QuestionsPath = "C:/Users/pedber/Documents/Visual Studio 2015/Projects/Questionnaire/Questionnaire/Questions/EnglishQuestions.xml";
            return Ex;
        }

        public static NewExam PortugueseExam()
        {
            NewExam Ex = new NewExam();
            Ex.LabelsTexts = PortugueseLabels();
            Ex.QuestionsPath = "C:/Users/pedber/Documents/Visual Studio 2015/Projects/Questionnaire/Questionnaire/Questions/PortugueseQuestions.xml";
            return Ex;
        }

        private static LabelTexts EnglishLabels() {
            LabelTexts Ex = new LabelTexts();
            Ex.Instructions = EnglishInstructions();
            Ex.name = "Name";
            Ex.instructor = "Instructor";
            Ex.Button = "Start Vex Exam";
            Ex.ExamHeader = "Vex Theory Exam";
            Ex.NextButton = "Next";
            Ex.Points = "Score";
            Ex.FinalQuestionButton = "End Exam";
            Ex.ExamEnderButtonText = "End Exam";
            Ex.BackButton = "Back";
            Ex.Gender = "Gender";
            Ex.MaleGender = "Male";
            Ex.FemaleGender = "Female";
            Ex.NonSpecGender = "Unspecified";
            Ex.InstructionsMessage = "Please, fill all the fields.";
            Ex.Age = "Age";
            return Ex;
        }

        private static LabelTexts PortugueseLabels() {
            LabelTexts PL = new LabelTexts();
            PL.Instructions = PortugueseInstructions();
            PL.name = "Nome";
            PL.instructor = "Instrutor";
            PL.Button = "Começar Exame";
            PL.ExamHeader = "Exame de teoria Vex";
            PL.NextButton = "Próxima";
            PL.ExamEnderButtonText = "Finalizar Exame";
            PL.Points = "Pontuação";
            PL.FinalQuestionButton = "Finalizar";
            PL.BackButton = "Voltar";
            PL.Gender = "Gênero";
            PL.MaleGender = "Masculino";
            PL.FemaleGender = "Feminino";
            PL.NonSpecGender = "Não especificado";
            PL.InstructionsMessage = "Por favor, preencha todos os campos.";
            PL.Age = "Idade";
            return PL;
        }

        public static List<string> EnglishInstructions()
        {
            List<string> Lines = new List<string> {
                "Final exam",
                "   The purpose of the final exam is to:\n" +
                "       •	Allow independent repetition of the central topics in this course;\n" +
                "       •	To measure and demonstrate the educational results of the course;\n\n" +
                "   Please, give ONLY one answer for each question.\n" +
                "   You are given 60 min to complete this test.\n\n",
                "Questions about knowledge",
                "   Please answer following questions.You should answer these questions individually without having the " +
                "help from your colleague, textbooks or internet."
            };
            return Lines;
        }

        public static List<string> PortugueseInstructions()
        {
            List<string> Lines = new List<string> {
                "Exame Final",
                "   O intuito do exame final é:\n" +
                "       •	Permitir a repetição independente dos temas centrais deste curso;\n" +
                "       •	Medir e demonstrar os resultados educacionais do curso;\n\n" +
                "   Cada pergunta possui somente uma resposta.\n" +
                "   Você possui 60 minutos para completar este teste.\n\n",
                "Teste de Conhecimento",
                "   Por favor, responda as seguintes perguntas.Você deve respondê - las individualmente, sem a ajuda de colegas," +
                "livros didáticos ou internet."
            };
            return Lines;
        }
    }
}