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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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

            string constr = "server=localhost;User Id=root;password=123;Database=info";
            MySqlConnection connection = new MySqlConnection(constr);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "insert into user(name,IDcard,phone,address)values(@name,@IDcard,@phone,@address)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@IDcard", id);
                cmd.Parameters.AddWithValue("@phone", int.Parse(phone));
                cmd.Parameters.AddWithValue("@address", address);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    //LoadData();
                }
            }

            MessageBox.Show("您已注册成功");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
