using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
namespace Questionnaire
{
    public class XmlManager
    {
        public List<Question> QuestionList(string path)
        {
            List<Question> QuestionList = new List<Question>();
            XmlSerializer Serial = new XmlSerializer(typeof(List<Question>));
            using (FileStream Fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                QuestionList = Serial.Deserialize(Fs) as List<Question>;
            }
            return QuestionList;
        }

        public void WriteResults(UserData User)
        {
            List<UserData> UserList = new List<UserData>();
                XmlSerializer Serial = new XmlSerializer(typeof(List<UserData>));
                using (FileStream Fs = new FileStream(
                    "C:/Users/pedber/Documents/Visual Studio 2015/Projects/Questionnaire/Questionnaire/UserData/UsersData.xml",
                    FileMode.Open, FileAccess.Read))
                {
                    if (Fs.Length != 0)
                    {
                        UserList = Serial.Deserialize(Fs) as List<UserData>;
                    }
                }

            UserList.Add(User);
            using (FileStream F = new FileStream(
                "C:/Users/pedber/Documents/Visual Studio 2015/Projects/Questionnaire/Questionnaire/UserData/UsersData.xml",
                FileMode.Create, FileAccess.Write))
            {
                Serial.Serialize(F, UserList);
            }
        }
    }
}
