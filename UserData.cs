using System;
namespace Questionnaire
{
    abstract class UserData
    {
        string Name;
        int Age;
        string Sex;
        int Points;
        List<int> WrongQuestions = new List<int>();
    }
}
