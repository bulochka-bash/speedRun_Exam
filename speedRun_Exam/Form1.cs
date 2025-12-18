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
    public partial class Form1 : Form
    {
        static string pcName = Environment.MachineName;
        string _conString = $"Data Source={pcName}\\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conString))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable = dataGridView1.DataSource as DataTable;
                    using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Пользователи", connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataTable);
                        MessageBox.Show("Изменения сохранены", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dataTable.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Блин", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Пользователи", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        using (DataTable dataTable = new DataTable())
                        {
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
