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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db.conString))
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
            using (SqlConnection con = new SqlConnection(db.conString))
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

        private void findBtn_Click(object sender, EventArgs e)
        {
            if (findText.Text != "")
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.White;
                        dataGridView1[i, j].Style.ForeColor = Color.Black;
                    }
                }

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                    {
                        if (dataGridView1[i, j].Value.ToString().IndexOf(findText.Text) != -1)
                        {
                            dataGridView1[i, j].Style.BackColor = Color.White;
                            dataGridView1[i, j].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите значение в поиск", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
