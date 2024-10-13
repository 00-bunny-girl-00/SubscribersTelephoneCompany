using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NPOI.POIFS.Crypt.Dsig;

namespace SubscribersTelephoneCompany
{
    public partial class Form4 : Form
    {
        string number;
        string[] servicesArray;
        string sql1;
        string sql2;
        string sql3;
        string sql4;

        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-RG9TH49K\SQLEXPRESS; Initial Catalog = subscribersTelephoneCompany; Integrated Security = True");
        SqlDataAdapter adapter1;
        DataSet ds1;
        SqlDataAdapter adapter2;
        DataSet ds2;

        DataGridView[] data = new DataGridView[2];

        public Form4(string number)
        {
            InitializeComponent();
            this.number = number;
        }

        private void Form4_Load(object sender, EventArgs e)
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
            sql3 = @"SELECT ИнформацияАбонентов.Баланс, ИнформацияАбонентов.Тариф, ИнформацияАбонентов.Услуги FROM ИнформацияАбонентов WHERE ИнформацияАбонентов.Номер = '" + number + "'";
            SqlCommand command = new SqlCommand(sql3, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                sql4 = @"SELECT Тарифы.Наименование FROM Тарифы WHERE Тарифы.Номер = '" + ((IDataRecord)reader)[1].ToString() + "'";

                label1.Text += ((IDataRecord)reader)[0].ToString();
                servicesArray = ((IDataRecord)reader)[2].ToString().Split(' ');
            }
            reader.Close();

            SqlCommand command1 = new SqlCommand(sql4, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                label2.Text += ((IDataRecord)reader1)[0].ToString();
            }
            reader1.Close();

            connection.Close();
            

            sql1 = @"SELECT Операции.Номер, Операции.Дата, Операции.Сумма FROM Операции WHERE Операции.НомерАбонента = '" + number + "'";
            connection.Open();
            adapter1 = new SqlDataAdapter(sql1, connection);
            ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            connection.Close();

            sql2 = @"SELECT * FROM Услуги";
            connection.Open();
            adapter2 = new SqlDataAdapter(sql2, connection);
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            ds2.Tables[0].Columns.Add("Статус", typeof(string));
            dataGridView2.DataSource = ds2.Tables[0];
            connection.Close();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (string str in servicesArray)
                {
                    if (row.Cells["Номер"].Value.ToString() == str)
                    {
                        row.Cells["Статус"].Value = "+";
                    }
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Статус"].Value?.ToString() != "+")
                {
                    row.Cells["Статус"].Value = "-";
                }
            }

            
        }

        private void sortingOperations_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Платежи")
            {
                sql1 = "SELECT Операции.Номер, Операции.Дата, Операции.Сумма FROM Операции WHERE (Операции.НомерАбонента = '" + number + "') AND (CHARINDEX('-', Сумма) > 0)";

            }
            else if (comboBox1.Text == "Начисления")
            {
                sql1 = "SELECT Операции.Номер, Операции.Дата, Операции.Сумма FROM Операции WHERE (Операции.НомерАбонента = '" + number + "') AND (CHARINDEX('+', Сумма) > 0)";

            }
            else
            {
                sql1 = @"SELECT Операции.Номер, Операции.Дата, Операции.Сумма FROM Операции WHERE Операции.НомерАбонента = '" + number + "'";
            }

            connection.Open();
            adapter1 = new SqlDataAdapter(sql1, connection);
            ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            connection.Close();
        }

        private void sortingServices_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Оплата раз в сутки")
            {
                sql2 = @"SELECT * FROM Услуги WHERE CHARINDEX('раз в сутки', Оплата) > 0";

            }
            else if (comboBox2.Text == "Оплата раз в месяц")
            {
                sql2 = @"SELECT * FROM Услуги WHERE CHARINDEX('раз в месяц', Оплата) > 0";
            }
            else
            {
                sql2 = @"SELECT * FROM Услуги";
            }

            connection.Open();
            adapter2 = new SqlDataAdapter(sql2, connection);
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            ds2.Tables[0].Columns.Add("Статус", typeof(string));
            dataGridView2.DataSource = ds2.Tables[0];
            connection.Close();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (string str in servicesArray)
                {
                    if (row.Cells["Номер"].Value.ToString() == str)
                    {
                        row.Cells["Статус"].Value = "+";
                    }
                }
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Статус"].Value?.ToString() != "+")
                {
                    row.Cells["Статус"].Value = "-";
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
