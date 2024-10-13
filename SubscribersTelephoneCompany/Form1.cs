using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubscribersTelephoneCompany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (log.Text == "админ" && pas.Text == "1234")
            {
                Form3 form = new Form3();
                form.ShowDialog();
            }
            else if (log.Text == "клиент" && pas.Text == "1234")
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин либо пароль!", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
