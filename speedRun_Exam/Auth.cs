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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.conString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Select * From Пользователи Where Логин =@login  and Пароль =@password ",con))
                    {
                        cmd.Parameters.Add("@login",SqlDbType.NVarChar).Value = login.Text;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password.Text;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                userInfo userInfo = new userInfo(reader);
                                userInfo.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
