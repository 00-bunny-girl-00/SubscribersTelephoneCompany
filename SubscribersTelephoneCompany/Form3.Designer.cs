namespace SubscribersTelephoneCompany
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.see = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.delete1 = new System.Windows.Forms.ToolStripMenuItem();
            this.add1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.save1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.import1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.экспортДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.word = new System.Windows.Forms.ToolStripMenuItem();
            this.excel = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортДанныхИзВсехТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.wordAll = new System.Windows.Forms.ToolStripMenuItem();
            this.excelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(17, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 426);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LavenderBlush;
            this.tabPage1.Controls.Add(this.search);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(759, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Абоненты";
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.LavenderBlush;
            this.search.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.search.Location = new System.Drawing.Point(6, 7);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(747, 22);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(747, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.see,
            this.toolStripSeparator1,
            this.delete1,
            this.add1,
            this.toolStripSeparator2,
            this.save1,
            this.toolStripSeparator3,
            this.import1,
            this.toolStripSeparator4,
            this.экспортДанныхToolStripMenuItem,
            this.экспортДанныхИзВсехТаблицToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(341, 224);
            // 
            // see
            // 
            this.see.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.see.Name = "see";
            this.see.Size = new System.Drawing.Size(340, 24);
            this.see.Text = "Просмотреть информацию абонента";
            this.see.Click += new System.EventHandler(this.see_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(337, 6);
            // 
            // delete1
            // 
            this.delete1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.delete1.Name = "delete1";
            this.delete1.Size = new System.Drawing.Size(340, 24);
            this.delete1.Text = "Удалить строку";
            this.delete1.Click += new System.EventHandler(this.delete1_Click);
            // 
            // add1
            // 
            this.add1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.add1.Name = "add1";
            this.add1.Size = new System.Drawing.Size(340, 24);
            this.add1.Text = "Сохранить новую строку";
            this.add1.Click += new System.EventHandler(this.add1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.PaleVioletRed;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripSeparator2.Size = new System.Drawing.Size(337, 6);
            // 
            // save1
            // 
            this.save1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.save1.Name = "save1";
            this.save1.Size = new System.Drawing.Size(340, 24);
            this.save1.Text = "Сохранить внесенные изменения";
            this.save1.Click += new System.EventHandler(this.save1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(337, 6);
            // 
            // import1
            // 
            this.import1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.import1.Name = "import1";
            this.import1.Size = new System.Drawing.Size(340, 24);
            this.import1.Text = "Импорт данных из Excel";
            this.import1.Click += new System.EventHandler(this.import1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(337, 6);
            // 
            // экспортДанныхToolStripMenuItem
            // 
            this.экспортДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.word,
            this.excel});
            this.экспортДанныхToolStripMenuItem.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.экспортДанныхToolStripMenuItem.Name = "экспортДанныхToolStripMenuItem";
            this.экспортДанныхToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.экспортДанныхToolStripMenuItem.Text = "Экспорт данных выбранной таблицы";
            // 
            // word
            // 
            this.word.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(224, 26);
            this.word.Text = "В Word";
            this.word.Click += new System.EventHandler(this.word_Click);
            // 
            // excel
            // 
            this.excel.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(224, 26);
            this.excel.Text = "В Excel";
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // экспортДанныхИзВсехТаблицToolStripMenuItem
            // 
            this.экспортДанныхИзВсехТаблицToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordAll,
            this.excelAll});
            this.экспортДанныхИзВсехТаблицToolStripMenuItem.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.экспортДанныхИзВсехТаблицToolStripMenuItem.Name = "экспортДанныхИзВсехТаблицToolStripMenuItem";
            this.экспортДанныхИзВсехТаблицToolStripMenuItem.Size = new System.Drawing.Size(340, 24);
            this.экспортДанныхИзВсехТаблицToolStripMenuItem.Text = "Экспорт данных всех таблиц";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LavenderBlush;
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(759, 397);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Услуги";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.textBox1.Location = new System.Drawing.Point(6, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(747, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Location = new System.Drawing.Point(6, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(747, 356);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView2.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LavenderBlush;
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(759, 397);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Тарифы";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox2.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.textBox2.Location = new System.Drawing.Point(6, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(747, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView3.Location = new System.Drawing.Point(6, 35);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(747, 356);
            this.dataGridView3.TabIndex = 1;
            this.dataGridView3.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView3.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView3.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LavenderBlush;
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.dataGridView4);
            this.tabPage5.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(759, 397);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Договора";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LavenderBlush;
            this.textBox3.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.textBox3.Location = new System.Drawing.Point(6, 7);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(747, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView4.Location = new System.Drawing.Point(6, 35);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(747, 356);
            this.dataGridView4.TabIndex = 1;
            this.dataGridView4.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView4.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wordAll
            // 
            this.wordAll.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.wordAll.Name = "wordAll";
            this.wordAll.Size = new System.Drawing.Size(224, 26);
            this.wordAll.Text = "В Word";
            this.wordAll.Click += new System.EventHandler(this.wordAll_Click);
            // 
            // excelAll
            // 
            this.excelAll.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.excelAll.Name = "excelAll";
            this.excelAll.Size = new System.Drawing.Size(224, 26);
            this.excelAll.Text = "В Excel";
            this.excelAll.Click += new System.EventHandler(this.excelAll_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form3";
            this.Text = "Просмотр и редактирование абонентской базы";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem import1;
        private System.Windows.Forms.ToolStripMenuItem delete1;
        private System.Windows.Forms.ToolStripMenuItem add1;
        private System.Windows.Forms.ToolStripMenuItem save1;
        private System.Windows.Forms.ToolStripMenuItem экспортДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem word;
        private System.Windows.Forms.ToolStripMenuItem excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem see;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem экспортДанныхИзВсехТаблицToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordAll;
        private System.Windows.Forms.ToolStripMenuItem excelAll;
    }
}