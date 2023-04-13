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
    public partial class AddMaterial : Form
    {
        public AddMaterial()
        {
            InitializeComponent();
        }

        private void AddMaterial_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pt = textBox1.Text;
            string kolvo = textBox2.Text;
            string unit = textBox3.Text;
            string stkolvo = textBox4.Text;
            string minkolvo = textBox5.Text;
            string description = textBox6.Text;
            string cost = textBox7.Text;
            string picture = textBox8.Text;
            string typematerial = textBox9.Text;
            using (DataBase db = new DataBase())
            {
                db.ExecuteNonQuery($"insert into Product values('{pt}', {kolvo}, '{unit}', {stkolvo}, {minkolvo}, '{description}', {cost}, '{picture}')");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    textBox8.Text = fd.FileName;
                    pictureBox1.Image = Image.FromFile(fd.FileName);
                }
            }
        }
    }
}
