using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Member_management_system_integration
{
    public partial class The_new_member_registration : Form
    {
        public The_new_member_registration()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)//取消
        {
            Form1 FM = new Form1();
            FM.Visible = true;
            this.Close();
        }

        private void The_new_member_registration_Load(object sender, EventArgs e)
        {

        }
    
        private void button1_click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string sex = comboBox1.Text;
            string id = textBox2.Text;
            string address = textBox3.Text;
            string phone = textBox4.Text;
            StreamWriter sw = new StreamWriter("member.txt", true, System.Text.Encoding.Default); //File.AppendText("member.txt");
            
            sw.WriteLine(name + " " + sex + " " + id + " " + phone + " " +address);
            sw.Flush();
            sw.Close(); 

            MessageBox.Show("您已注册成功");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
