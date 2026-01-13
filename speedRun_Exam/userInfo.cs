using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace speedRun_Exam
{
    public partial class userInfo : Form
    {
        public userInfo(SqlDataReader reader)
        {
            InitializeComponent();
            using (DataTable dt = new DataTable())
            {
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
