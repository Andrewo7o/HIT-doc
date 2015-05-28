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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)//管理员登录
        {
            Administrator_login AL = new Administrator_login();
            AL.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//新会员注册
        {
            The_new_member_registration NMR = new The_new_member_registration();
            NMR.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)//关于我们
        {
            About_us AU = new About_us();
            AU.Show();
            this.Visible = false;
        }
    }
    public class Person//人物超类
    {
        private string name;//姓名
        private string sex;//性别
        private double idnumber;//身份证号码
        private string telephone;//联系方式
        private string live;//现居住地


        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        public double IDnumber
        {
            set { idnumber = value; }
            get { return idnumber; }
        }
        public string Telephone
        {
            set { telephone = value; }
            get { return telephone; }
        }
        public string Live
        {
            set { live = value; }
            get { return live; }
        }
    }
    public class TheNewMemberRegistration : Person//新会员子类
    {
        public void submit(string path, string name, string sex, int idnumber, string live,  string telephone)
        {
            try//将新会员的信息存入文件中
            {
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(name + '\t' + sex + '\t' + '\t' + idnumber + '\t'+live + '\t' + telephone);
                sw.Close();
                MessageBox.Show("提交成功，请耐心等待答复！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("提交失败！");
            }
        }
    }
    public class AdministratorLogin : Person//管理员子类
    {

        public list addToList()//将文件中已有的简历信息存入链表
        {
            FileStream fs = new FileStream("newMember.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            list resumeList = new list();
            list temp;
            string[] line;
            try
            {
                while (!sr.EndOfStream)
                {
                    Node a = new Node();
                    temp = new list(a);
                    line = sr.ReadLine().Split('\t');//以'\t'为分隔符读取
                    temp.data.name = line[0];
                    temp.data.sex = line[1];
                    temp.data.idnumber = line[2];
                    temp.data.live = line[7];
                    temp.data.telephone = line[9];
                    temp.link = resumeList.link;
                    resumeList.link = temp;
                }
            }
            catch (IOException)
            {
                MessageBox.Show("文件问题！");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("空指向问题！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("出错了！");
            }
            return resumeList;
        }
    }
}