using NPOI.POIFS.Crypt.Dsig;
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

namespace SubscribersTelephoneCompany
{
    public partial class Form5 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-RG9TH49K\SQLEXPRESS; Initial Catalog = subscribersTelephoneCompany; Integrated Security = True");
        
        string sql1 = @"SELECT * FROM Услуги";
        string sql2 = @"SELECT * FROM Тарифы";

        SqlDataAdapter adapter1;
        DataSet ds1;

        SqlDataAdapter adapter2;
        DataSet ds2;

        string str;

        bool error;

        DataGridView[] data = new DataGridView[2];

        public Form5()
        {
            InitializeComponent();
        }

        public void NewRow(DataSet dsN, string com)
        {
            try
            {
                DataRow row = dsN.Tables[0].NewRow();

                dsN.Tables[0].Rows.Add(row);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = com;
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Вы ввели не соотведстуещие даные!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
                connection.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            data[0] = dataGridView1;
            data[1] = dataGridView2;

            foreach (DataGridView d in data)
            {
                d.EnableHeadersVisualStyles = false;
                d.RowsDefaultCellStyle.BackColor = Color.LavenderBlush;
                d.RowsDefaultCellStyle.ForeColor = Color.PaleVioletRed;
                d.ColumnHeadersDefaultCellStyle.BackColor = Color.LavenderBlush;
                d.ColumnHeadersDefaultCellStyle.ForeColor = Color.PaleVioletRed;
                d.RowHeadersDefaultCellStyle.BackColor = Color.LavenderBlush;
                d.DefaultCellStyle.SelectionForeColor = Color.LavenderBlush;
                d.DefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
                d.GridColor = Color.PaleVioletRed;
                d.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, FontStyle.Bold);
            }

            connection.Open();

            adapter1 = new SqlDataAdapter(sql1, connection);
            ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            adapter2 = new SqlDataAdapter(sql2, connection);
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            connection.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                str += dataGridView1.Rows[dataGridView1.SelectedCells[i].RowIndex].Cells["Номер"].Value.ToString();
            }

            NewRow(ds1, "INSERT into Договора (ДатаЗаключения, МестоЗаключения, КодовоеСлово, Тариф) VALUES ('" + date.Value +"', '" + textBox1.Text + "', '" + textBox2.Text + "', " + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString() + ")");
            NewRow(ds2, "INSERT into ИнформацияАбонентов (Баланс, Тариф, Услуги) VALUES ('" + textBox3.Text + "', " + dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString() + ", '" + str + "')");

            if (!error) { this.Close(); }
        }
    }
}
