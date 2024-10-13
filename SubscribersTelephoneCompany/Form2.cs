using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace SubscribersTelephoneCompany
{
    public partial class Form2 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-RG9TH49K\SQLEXPRESS; Initial Catalog = subscribersTelephoneCompany; Integrated Security = True");

        string sql1 = @"SELECT * FROM Абоненты";
        string sql2 = @"SELECT * FROM Услуги";
        string sql3 = @"SELECT * FROM Тарифы";
        string sql4 = @"SELECT * FROM Договора";

        DataGridView[] data = new DataGridView[4];

        SqlCommandBuilder commandBuilder1;
        SqlDataAdapter adapter1;
        DataSet ds1;

        SqlCommandBuilder commandBuilder2;
        SqlDataAdapter adapter2;
        DataSet ds2;

        SqlCommandBuilder commandBuilder3;
        SqlDataAdapter adapter3;
        DataSet ds3;

        SqlCommandBuilder commandBuilder4;
        SqlDataAdapter adapter4;
        DataSet ds4;

        public Form2()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            connection.Open();

            adapter1 = new SqlDataAdapter(sql1, connection);
            commandBuilder1 = new SqlCommandBuilder(adapter1);
            commandBuilder1.GetInsertCommand();
            commandBuilder1.GetUpdateCommand();
            commandBuilder1.GetDeleteCommand();
            ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            adapter2 = new SqlDataAdapter(sql2, connection);
            commandBuilder2 = new SqlCommandBuilder(adapter2);
            commandBuilder2.GetInsertCommand();
            commandBuilder2.GetUpdateCommand();
            commandBuilder2.GetDeleteCommand();
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            adapter3 = new SqlDataAdapter(sql3, connection);
            commandBuilder3 = new SqlCommandBuilder(adapter3);
            commandBuilder3.GetInsertCommand();
            commandBuilder3.GetUpdateCommand();
            commandBuilder3.GetDeleteCommand();
            ds3 = new DataSet();
            adapter3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];

            adapter4 = new SqlDataAdapter(sql4, connection);
            commandBuilder4 = new SqlCommandBuilder(adapter4);
            commandBuilder4.GetInsertCommand();
            commandBuilder4.GetUpdateCommand();
            commandBuilder4.GetDeleteCommand();
            ds4 = new DataSet();
            adapter4.Fill(ds4);
            dataGridView4.DataSource = ds4.Tables[0];

            connection.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            data[0] = dataGridView1;
            data[1] = dataGridView2;
            data[2] = dataGridView3;
            data[3] = dataGridView4;

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

            LoadData();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if(search.Text.Length == 0)
            {
                sql1 = @"SELECT *, 'Просмотреть' as [Информация об абоненте] FROM Абоненты";
            }
            else
            {
                sql1 = @"SELECT *, 'Просмотреть' as [Информация об абоненте] FROM Абоненты " +
                        "WHERE (CHARINDEX('" + search.Text + "', ФИО) > 0) " +
                        "OR (CHARINDEX('" + search.Text + "', ДатаРождения) > 0) " +
                        "OR (CHARINDEX('" + search.Text + "', НомерТелефона) > 0) " +
                        "OR (CHARINDEX('" + search.Text + "', АдресПроживания) > 0)";
            }

            connection.Open();
            adapter1 = new SqlDataAdapter(sql1, connection);
            ds1 = new DataSet();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                sql2 = @"SELECT * FROM Услуги";
            }
            else
            {
                sql2 = @"SELECT * FROM Услуги " +
                        "WHERE (CHARINDEX('" + textBox1.Text + "', Наименование) > 0) " +
                        "OR (CHARINDEX('" + textBox1.Text + "', Стоимость) > 0) " +
                        "OR (CHARINDEX('" + textBox1.Text + "', Оплата) > 0) " +
                        "OR (CHARINDEX('" + textBox1.Text + "', ИнформацияОбУслуге) > 0)";
            }

            connection.Open();
            adapter2 = new SqlDataAdapter(sql2, connection);
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            connection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                sql3 = @"SELECT * FROM Тарифы";
            }
            else
            {
                sql3 = @"SELECT * FROM Тарифы " +
                        "WHERE (CHARINDEX('" + textBox2.Text + "', Наименование) > 0) " +
                        "OR (CHARINDEX('" + textBox2.Text + "', Стоимость) > 0) " +
                        "OR (CHARINDEX('" + textBox2.Text + "', КоличествоМинут) > 0) " +
                        "OR (CHARINDEX('" + textBox2.Text + "', КоличествоСМС) > 0) " +
                        "OR (CHARINDEX('" + textBox2.Text + "', Интернет) > 0)";
            }

            connection.Open();
            adapter3 = new SqlDataAdapter(sql3, connection);
            ds3 = new DataSet();
            adapter3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
            connection.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                sql4 = @"SELECT * FROM Договора";
            }
            else
            {
                sql4 = @"SELECT * FROM Договора " +
                        "WHERE (CHARINDEX('" + textBox3.Text + "', ДатаЗаключения) > 0) " +
                        "OR (CHARINDEX('" + textBox3.Text + "', МестоЗаключения) > 0) " +
                        "OR (CHARINDEX('" + textBox3.Text + "', КодовоеСлово) > 0) " +
                        "OR (CHARINDEX('" + textBox3.Text + "', Тариф) > 0)";
            }

            connection.Open();
            adapter4 = new SqlDataAdapter(sql4, connection);
            ds4 = new DataSet();
            adapter4.Fill(ds4);
            dataGridView4.DataSource = ds4.Tables[0];
            connection.Close();
        }

        private void word_Click(object sender, EventArgs e)
        {
            wordExportFile(false);
        }

        private void excel_Click(object sender, EventArgs e)
        {
            excelExportFile(false);
        }

        private void wordAll_Click(object sender, EventArgs e)
        {
            wordExportFile(true);
        }

        private void excelAll_Click(object sender, EventArgs e)
        {
            excelExportFile(true);
        }

        private void ExportTableWord(DocX document, string nameParagraph, DataGridView dataGridView)
        {
            document.InsertParagraph(nameParagraph).Font("Times New Roman").FontSize(14).CapsStyle(CapsStyle.caps).Alignment = Alignment.center;
            Xceed.Document.NET.Table table = document.AddTable(dataGridView.Rows.Count + 1, dataGridView.ColumnCount);

            Row row0 = table.Rows[0];
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                row0.Cells[i].Paragraphs[0].FontSize(10).Append(dataGridView.Columns[i].HeaderText).Alignment = Alignment.center;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                Row row = table.Rows[i + 1];
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    row.Cells[j].Paragraphs[0].FontSize(10).Append(dataGridView.Rows[i].Cells[j].Value?.ToString()).Alignment = Alignment.center;
                }
            }

            document.InsertParagraph().InsertTableAfterSelf(table);
            document.InsertParagraph();
        }

        private void wordExportFile(bool allOrNo)
        {
            try
            {
                saveFileDialog1.Filter = "Word files(*.docx)|*.docx";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                string fileName = saveFileDialog1.FileName;

                DocX document = DocX.Create(fileName);

                if (!allOrNo)
                {
                    if (tabControl1.SelectedIndex == 0) { ExportTableWord(document, "Абоненты", dataGridView1); }
                    else if (tabControl1.SelectedIndex == 1) { ExportTableWord(document, "Услуги", dataGridView2); }
                    else if (tabControl1.SelectedIndex == 2) { ExportTableWord(document, "Тарифы", dataGridView3); }
                    else if (tabControl1.SelectedIndex == 3) { ExportTableWord(document, "Договора", dataGridView4); }
                }
                else
                {
                    ExportTableWord(document, "Абоненты", dataGridView1);
                    ExportTableWord(document, "Услуги", dataGridView2);
                    ExportTableWord(document, "Тарифы", dataGridView3);
                    ExportTableWord(document, "Договора", dataGridView4);
                }

                document.Save();
                MessageBox.Show("Экспорт прошел успешно!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void excelExportFile(bool allOrNo)
        {
            try
            {
                saveFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                string fileName = saveFileDialog1.FileName;

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    IWorkbook wb = new XSSFWorkbook();

                    if (!allOrNo)
                    {
                        if (tabControl1.SelectedIndex == 0) { ExportTableExcel(wb, "Абоненты", dataGridView1); }
                        else if (tabControl1.SelectedIndex == 1) { ExportTableExcel(wb, "Услуги", dataGridView2); }
                        else if (tabControl1.SelectedIndex == 2) { ExportTableExcel(wb, "Тарифы", dataGridView3); }
                        else if (tabControl1.SelectedIndex == 3) { ExportTableExcel(wb, "Договора", dataGridView4); }
                    }
                    else
                    {
                        ExportTableExcel(wb, "Абоненты", dataGridView1);
                        ExportTableExcel(wb, "Услуги", dataGridView2);
                        ExportTableExcel(wb, "Тарифы", dataGridView3);
                        ExportTableExcel(wb, "Договора", dataGridView4);
                    }

                    wb.Write(fileStream, true);
                    MessageBox.Show("Экспорт прошел успешно!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void ExportTableExcel(IWorkbook wb, string nameList, DataGridView dataGridView)
        {
            ISheet ws = wb.CreateSheet(nameList);

            IRow row0 = ws.CreateRow(0);
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                row0.CreateCell(i).SetCellValue(dataGridView.Columns[i].HeaderText);
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                IRow row = ws.CreateRow(i + 1);
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    row.CreateCell(j).SetCellValue(dataGridView.Rows[i].Cells[j].Value?.ToString());
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) { see.Visible = true; toolStripSeparator1.Visible = true; }
            else { see.Visible = false; toolStripSeparator1.Visible = false; }
        }

        private void see_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Номер"].Value.ToString());
            form.ShowDialog();
        }
    }
}
