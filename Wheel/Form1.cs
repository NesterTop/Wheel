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

namespace Wheel
{
    public partial class Form1 : Form
    {
        int v = 0;
        SqlDataAdapter ma;
        SqlDataAdapter pr;
        SqlDataAdapter su;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBase db = new DataBase();

            ma = new SqlDataAdapter("select * from Material", db._connection);
            pr = new SqlDataAdapter("select * from Product", db._connection);
            su = new SqlDataAdapter("select * from Supplier", db._connection);

            ma.UpdateCommand = new SqlCommandBuilder(ma).GetUpdateCommand();
            pr.UpdateCommand = new SqlCommandBuilder(pr).GetUpdateCommand();
            su.UpdateCommand = new SqlCommandBuilder(su).GetUpdateCommand();

            ma.Fill(Table.Material);
            pr.Fill(Table.Product);
            su.Fill(Table.Supplier);

            SetSource(Table.Material);

            db.Dispose();
        }

        public bool SetSource(DataTable dt)
        {
            try
            {
                dataGridView1.DataSource = dt;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Supplier);
        }

        private void материалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v = 2;
            SetSource(Table.Material);
            
        }

        private void продукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Product);
            v = 1;
        }

        private void агентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSource(Table.Agent);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddSupplier().Show();
        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new AddProduct().Show();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AddMaterial().Show();
        }
        public bool UpdateTables()
        {
            try
            {
                ma.Update(Table.Material);
                pr.Update(Table.Product);
                su.Update(Table.Supplier);

                SetSource(Table.Material);

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTables();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string path = @"C:\Users\solov\Desktop\products\";

            if(v == 1)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(path + dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                }
                catch
                {
                    pictureBox2.Image = Image.FromFile($@"{path}picture.png");
                }
            }
            
            else if(v == 2)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(path + dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
                }
                catch
                {
                    pictureBox2.Image = Image.FromFile($@"{path}picture.png");
                }
            }
            
        }
    }
}
