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
    public partial class Membership_information : Form
    {
        list resumeList;
        public Membership_information()
        {
            InitializeComponent();
            resumeList = new list();
        }
        //Membership_information adm = new Membership_information();
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Membership_information_Load(object sender, EventArgs e)
        {
            list head = resumeList;
            string strTxt = "";
            StreamReader fileStream = null;
            string strFileName = "member.txt" ;
            fileStream = new StreamReader(strFileName, System.Text.Encoding.GetEncoding("GBK"));
            while (!fileStream.EndOfStream)                
            {
                strTxt = fileStream.ReadLine().Trim();//一行一行读取
                
                
                string[] information = strTxt.Split(' ');
                Node node = new Node(information[0], information[1], information[2], information[3], information[4]);
                list l = new list();
                l.data = node;
                head.link = l;
                head = head.link;
            }
            fileStream.Close();






            this.dataGridView1.DefaultCellStyle.Font = new Font("宋体", 9);
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "姓名";
            dataGridView1.Columns[1].Name = "性别";
            dataGridView1.Columns[2].Name = "身份证号";
            dataGridView1.Columns[3].Name = "联系方式";
            dataGridView1.Columns[4].Name = "居住地";
            list temp = resumeList.link;//链表头为空，从第二个节点开始查找
            while (temp != null)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = temp.data.name;
                this.dataGridView1.Rows[index].Cells[1].Value = temp.data.sex;
                this.dataGridView1.Rows[index].Cells[2].Value = temp.data.idnumber;
                this.dataGridView1.Rows[index].Cells[3].Value = temp.data.telephone;
                this.dataGridView1.Rows[index].Cells[4].Value = temp.data.live;
                temp = temp.link;
            }
        }
        private void form_close(object sender, FormClosedEventArgs e)
        {
           Form1 erm = new Form1();
           erm.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("member.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string temp = string.Empty;//暂存每一行的内容
                string str = string.Empty;//保存删除后文件内容的字符串
                while ((temp = sr.ReadLine()) != null)//读文件中的每一行
                {//如果该行中的姓名信息跟选中行的姓名信息匹配，则删除之，否则将该行加入str
                    if (!temp.Contains(this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()))
                        str += temp + "\n";
                }
                fs.SetLength(0);//将文件长度置0
                sw.Write(str);//将新信息写入
                sw.Close();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);//在datagridview中删除该行信息
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Linklist ls = new Linklist();
            //resumeList.link = null;
            //ls.head = resumeList.link;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Node l = new Node();
                l.name = (string)dataGridView1.Rows[i].Cells[0].Value;
                l.sex = (string)dataGridView1.Rows[i].Cells[1].Value;
                l.idnumber = (string)dataGridView1.Rows[i].Cells[2].Value;
                l.telephone = (string)dataGridView1.Rows[i].Cells[3].Value;
                l.live = (string)dataGridView1.Rows[i].Cells[4].Value;
                ls.Add(l);
            }
            try
            {
                FileStream fs = new FileStream("member.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                list l = ls.head.link.link;
                fs.SetLength(0);//将文件长度置0
                while (l != null)
                {
                    string data = l.data.name + " " + l.data.sex + " " + l.data.idnumber + " " + l.data.telephone + " " + l.data.live;
                    sw.WriteLine(data);
                    l = l.link;
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cell_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //连接
            int index = dataGridView1.CurrentRow.Index;
            string name = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string sex = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string idnumber = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string telephone = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string live = dataGridView1.Rows[index].Cells[4].Value.ToString();
            


       
            this.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 FM = new Form1();
            FM.Visible = true;
            this.Close();
        }
    }
}
