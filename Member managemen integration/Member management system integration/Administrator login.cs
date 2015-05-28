using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Member_management_system_integration
{
    public partial class Administrator_login : Form
    {
        public Administrator_login()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            try//从文件中读出密码，判断是否与输入的密码相同
            {
                FileStream fs = new FileStream("Administrator.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                if (line.Equals(password))
                {
                    Membership_information MI = new Membership_information();
                    MI.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("密码错误！");//提示密码错误
                    textBox1.Clear();//清空密码框
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 FM = new Form1();
            FM.Visible = true;
            this.Close();
        }

        private void Administrator_login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
