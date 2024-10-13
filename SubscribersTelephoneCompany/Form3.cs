using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Table = Xceed.Document.NET.Table;
using NPOI.XWPF.UserModel;

namespace SubscribersTelephoneCompany
{
    public partial class Form3 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-RG9TH49K\SQLEXPRESS; Initial Catalog = subscribersTelephoneCompany; Integrated Security = True");

        string sql1 = @"SELECT * FROM Абоненты";
        string sql2 = @"SELECT * FROM Услуги";
        string sql3 = @"SELECT * FROM Тарифы";
        string sql4 = @"SELECT * FROM Договора";
        string sql5 = @"SELECT * FROM ИнформацияАбонентов";

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

        SqlDataAdapter adapter5;
        DataSet ds5;

        Boolean newRowAdding1 = false;
        Boolean newRowAdding2 = false;
        Boolean newRowAdding3 = false;

        string errorMessage;

        public Form3()
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

            adapter5 = new SqlDataAdapter(sql5, connection);
            ds5 = new DataSet();
            adapter5.Fill(ds5);

            connection.Close();
        }

        private void ReloadData()
        {
            connection.Open();

            ds1.Tables[0].Clear();
            adapter1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            ds2.Tables[0].Clear();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            ds3.Tables[0].Clear();
            adapter3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];

            ds4.Tables[0].Clear();
            adapter4.Fill(ds4);
            dataGridView4.DataSource = ds4.Tables[0];

            connection.Close();
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
                connection.Close();
            }
        }

        public void DeleteRow(DataGridView dataGridViewN, DataSet dsN, DataAdapter adapterN, int i)
        {
            dataGridViewN.Rows.RemoveAt(i);
            dsN.Tables[0].Rows[i].Delete();
            adapterN.Update(dsN);
        }

        private void Form3_Load(object sender, EventArgs e)
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

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0) { newRowAdding1 = true; }
            else if (tabControl1.SelectedIndex == 1) { newRowAdding2 = true; }
            else if (tabControl1.SelectedIndex == 2) { newRowAdding3 = true; }
        }

        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (dataGridView1.SelectedCells[0].RowIndex == dataGridView1.RowCount - 2 && newRowAdding1) { add1.Visible = true; }
                    else { add1.Visible = false; }
                    delete1.Visible = true;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    if (dataGridView2.SelectedCells[0].RowIndex == dataGridView2.RowCount - 2 && newRowAdding2) { add1.Visible = true; }
                    else { add1.Visible = false; }
                    delete1.Visible = true;
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    if (dataGridView3.SelectedCells[0].RowIndex == dataGridView3.RowCount - 2 && newRowAdding3) { add1.Visible = true; }
                    else { add1.Visible = false; }
                    delete1.Visible = true;
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    add1.Visible = false;
                    delete1.Visible = false;
                }
            }
        }

        private void import1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel files(*.xlsx)|*.xlsx";
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                string path = openFileDialog1.FileName;

                using (FileStream xlsxFile = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(xlsxFile);

                    if (tabControl1.SelectedIndex == 0)
                    {
                        ISheet matrixExcel = hssfwb.GetSheet("Абоненты");
                        for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                        {
                            dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[i + 1].Value = Convert.ToString(matrixExcel.GetRow(0).GetCell(i));
                        }
                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {
                        ISheet matrixExcel = hssfwb.GetSheet("Услуги");
                        for (int i = 0; i < dataGridView2.ColumnCount - 1; i++)
                        {
                            dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[i + 1].Value = Convert.ToString(matrixExcel.GetRow(0).GetCell(i));
                        }
                    }
                    else if (tabControl1.SelectedIndex == 2)
                    {
                        ISheet matrixExcel = hssfwb.GetSheet("Тарифы");
                        for (int i = 0; i < dataGridView3.ColumnCount - 1; i++)
                        {
                            dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[i + 1].Value = Convert.ToString(matrixExcel.GetRow(0).GetCell(i));
                        }
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Нечитаемые данные!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Некоторые ячейки пусты!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Произошла какая-то ошибка!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteRow(dataGridView4, ds4, adapter4, dataGridView1.SelectedCells[0].RowIndex);

                    ds5.Tables[0].Rows[dataGridView1.SelectedCells[0].RowIndex].Delete();
                    adapter5.Update(ds5);

                    DeleteRow(dataGridView1, ds1, adapter1, dataGridView1.SelectedCells[0].RowIndex);

                    ReloadData();
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteRow(dataGridView2, ds2, adapter2, dataGridView2.SelectedCells[0].RowIndex);
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteRow(dataGridView3, ds3, adapter3, dataGridView3.SelectedCells[0].RowIndex);
                }
            }
        }

        private void add1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (newRowAdding1)
                {
                    if (MessageBox.Show("Добавить эту строку?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Form5 form = new Form5();
                        form.ShowDialog();

                        int rowIndex = dataGridView1.Rows.Count - 2;

                        NewRow(ds2, @"INSERT into Абоненты (ФИО, ДатаРождения, НомерТелефона, АдресПроживания) VALUES"
                            + "('" + dataGridView1.Rows[rowIndex].Cells["ФИО"].Value
                            + "', '" + dataGridView1.Rows[rowIndex].Cells["ДатаРождения"].Value
                            + "', '" + dataGridView1.Rows[rowIndex].Cells["НомерТелефона"].Value
                            + "', '" + dataGridView1.Rows[rowIndex].Cells["АдресПроживания"].Value + "')");

                        newRowAdding1 = false;

                        ReloadData();
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (newRowAdding2)
                {
                    if (MessageBox.Show("Добавить эту строку?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = dataGridView2.Rows.Count - 2;

                        NewRow(ds2, @"INSERT into Услуги (Наименование, Стоимость, Оплата, ИнформацияОбУслуге) VALUES"
                            + "('" + dataGridView2.Rows[rowIndex].Cells["Наименование"].Value
                            + "', '" + dataGridView2.Rows[rowIndex].Cells["Стоимость"].Value
                            + "', '" + dataGridView2.Rows[rowIndex].Cells["Оплата"].Value
                            + "', '" + dataGridView2.Rows[rowIndex].Cells["ИнформацияОбУслуге"].Value + "')");

                        newRowAdding2 = false;

                        ReloadData();
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (newRowAdding3)
                {
                    if (MessageBox.Show("Добавить эту строку?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int rowIndex = dataGridView3.Rows.Count - 2;

                        NewRow(ds2, @"INSERT into Тарифы (Наименование, Стоимость, КоличествоМинут, КоличествоСМС, Интернет) VALUES"
                            + "('" + dataGridView3.Rows[rowIndex].Cells["Наименование"].Value
                            + "', '" + dataGridView3.Rows[rowIndex].Cells["Стоимость"].Value
                            + "', '" + dataGridView3.Rows[rowIndex].Cells["КоличествоМинут"].Value
                            + "', '" + dataGridView3.Rows[rowIndex].Cells["КоличествоСМС"].Value
                            + "', '" + dataGridView3.Rows[rowIndex].Cells["Интернет"].Value + "')");

                        dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells["Команда"].Value = "Удалить";
                        newRowAdding3 = false;

                        ReloadData();
                    }
                }
            }
        }

        private void save1_Click(object sender, EventArgs e)
        {
            string query1 = @"INSERT INTO Абоненты (ФИО, ДатаРождения, НомерТелефона, АдресПроживания) VALUES (@fullName, @dateOfBirth, @phoneNumber, @residentialAddress)";
            string query2 = @"INSERT INTO Услуги (Наименование, Стоимость, Оплата, ИнформацияОбУслуге) VALUES (@name, @cost, @payment, @info)";
            string query3 = @"INSERT INTO Тарифы (Наименование, Стоимость, КоличествоМинут, КоличествоСМС, Интернет) VALUES (@name, @cost, @minutes, @sms, @internet)";

            connection.Open();
            if (tabControl1.SelectedIndex == 0)
            {
                SqlCommand sqlCommand = new SqlCommand(query1, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.NVarChar, 200, "ФИО"));
                sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.Date, 0, "ДатаРождения"));
                sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", SqlDbType.NVarChar, 30, "НомерТелефона"));
                sqlCommand.Parameters.Add(new SqlParameter("@residentialAddress", SqlDbType.NVarChar, 200, "АдресПроживания"));
                adapter1.InsertCommand = sqlCommand;
                adapter1.Update(ds1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                SqlCommand sqlCommand = new SqlCommand(query2, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 200, "Наименование"));
                sqlCommand.Parameters.Add(new SqlParameter("@cost", SqlDbType.Int, 0, "Стоимость"));
                sqlCommand.Parameters.Add(new SqlParameter("@payment", SqlDbType.NVarChar, 50, "Оплата"));
                sqlCommand.Parameters.Add(new SqlParameter("@info", SqlDbType.NVarChar, 200, "ИнформацияОбУслуге"));
                adapter2.InsertCommand = sqlCommand;
                adapter2.Update(ds2);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                SqlCommand sqlCommand = new SqlCommand(query3, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 200, "Наименование"));
                sqlCommand.Parameters.Add(new SqlParameter("@cost", SqlDbType.Int, 0, "Стоимость"));
                sqlCommand.Parameters.Add(new SqlParameter("@minutes", SqlDbType.Int, 0, "КоличествоМинут"));
                sqlCommand.Parameters.Add(new SqlParameter("@sms", SqlDbType.Int, 0, "КоличествоСМС"));
                sqlCommand.Parameters.Add(new SqlParameter("@internet", SqlDbType.NVarChar, 50, "Интернет"));
                adapter3.InsertCommand = sqlCommand;
                adapter3.Update(ds3);
            }
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (search.Text.Length == 0)
            {
                sql1 = @"SELECT * FROM Абоненты";
            }
            else
            {
                sql1 = @"SELECT * FROM Абоненты " +
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

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if(tabControl1.SelectedIndex == 0)
            {
                errorMessage = "Error with " + dataGridView1.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                errorMessage = "Error with " + dataGridView2.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                errorMessage = "Error with " + dataGridView3.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                errorMessage = "Error with " + dataGridView4.Columns[e.ColumnIndex].HeaderText + "\n\n" + e.Exception.Message;
            }
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            e.Cancel = false;
        }
    }
}
