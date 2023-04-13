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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string pt = textBox2.Text;
            string articul = textBox3.Text;
            string description = textBox4.Text;
            string picture = textBox5.Text;
            string kh = textBox6.Text;
            string nc = textBox7.Text;
            string cost = textBox8.Text;

            using(DataBase db = new DataBase())
            {
                db.ExecuteNonQuery($"insert into Product values('{title}', '{articul}', '{description}', '{picture}', {kh}, '{nc}', {cost})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog fd = new OpenFileDialog())
            {
                if(fd.ShowDialog() == DialogResult.OK)
                {
                    textBox5.Text = fd.FileName;
                    pictureBox1.Image = Image.FromFile(fd.FileName);
                }
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
