using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace DataAnalysis
{
    public partial class MainForm : Form
    {
        Tables Table = new Tables();
        public MainForm()
        {
            InitializeComponent();                    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Table.MeanPointsPercentage();
            dataGridView1.DataSource = Table.AllData();
        }
    }
}
