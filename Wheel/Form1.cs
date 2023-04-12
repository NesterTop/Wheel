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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateData();
            dataGridView1.DataSource = Table.Agent;
        }

        public void UpdateData()
        {
            using(DataBase db = new DataBase())
            {
                Table.Agent = db.ExecuteSql("select * from Agent");
                Table.Material = db.ExecuteSql("select * from Material");
                Table.Product = db.ExecuteSql("select * from Product");
                Table.Supplier = db.ExecuteSql("select * from Supplier");
            }
        }

        public void SetSource(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Supplier);
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Material);
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Product);
        }

        private void агентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Agent);
        }
    }
}
