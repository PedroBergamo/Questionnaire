using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DataAnalysis
{
    class Tables
    {
        public DataTable AllData()
        {
            DataSet Data = new DataSet();
            Data.ReadXml("C:/Users/pedber/Documents/Visual Studio 2015/Projects/Questionnaire/Questionnaire/UserData/UsersData.xml");
            
            return Data.Tables[0];                                                           
        }

        public void MeanPointsPercentage()
        {
            DataTable Data = AllData();
            DataColumn PercentageColumn = Data.Columns[0];
            string a = "";
            
            ////Declare an object variable.
            //Data
            //List<int> s = myTable.AsEnumerable().Select(x => Int32.Parse(x[0].ToString()).ToList();

            //int avgFiveSbefore = (int)myTable.Compute("AVG([Int32.Parse(TextBoxD1.Text)PointsPercentage])", "");
            //DataTable myDataTable = new DataTable();
            //List<int> myList = new List<int>();
            //foreach (DataRow row in myDataTable.Rows)
            //{
            //    myList.Add((int)row[0]);
            //}
            //return Result;
        }
    }
}
