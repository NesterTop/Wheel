using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wheel
{
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string INN = textBox2.Text;
            string date = textBox3.Text;
            string qa = textBox4.Text;
            string type = textBox5.Text;

            using(DataBase db = new DataBase())
            {
                db.ExecuteNonQuery($"insert into Supplier values('{title}', '{INN}', '{date}', '{qa}', '{type}')");
            }

            this.Close();
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            textBox3.Text = monthCalendar1.TodayDate.ToShortDateString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = e.Start.ToShortDateString();
        }
    }
}
