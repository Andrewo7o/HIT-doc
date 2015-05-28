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
    public partial class Records_of_consumption : Form
    {
        public Records_of_consumption()
        {
            InitializeComponent();
        }
        string idnumber;
        public Records_of_consumption(string name,string phone,string idnumber)
        {
            InitializeComponent();
            textBox3.Text = name;
            this.idnumber = idnumber;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Records_of_consumption_Load(object sender, EventArgs e)
        {
            List<Record> sumRecord = new List<Record>();
            string strTxt = "";
            StreamReader fileStream = null;
            string strFileName = "record.txt";
            fileStream = new StreamReader(strFileName, System.Text.Encoding.GetEncoding("GB2312"));
            while (!fileStream.EndOfStream)
            {
                strTxt = fileStream.ReadLine().Trim();//一行一行读取
                string[] information = strTxt.Split(' ');
                if (information[0].Equals(idnumber))
                {
                    Record record = new Record(information[0], information[1], information[2], information[3], information[4], information[5]);
                    sumRecord.Add(record);
                }

            }

            for (int index = 0; index < sumRecord.Count; index++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = sumRecord[index].Date;
                this.dataGridView1.Rows[index].Cells[1].Value = sumRecord[index].Money;
                this.dataGridView1.Rows[index].Cells[2].Value = sumRecord[index].Point;
                this.dataGridView1.Rows[index].Cells[3].Value = sumRecord[index].Style;
                this.dataGridView1.Rows[index].Cells[4].Value = sumRecord[index].Pay;

            }


            int sumMoney = 0, sumPay = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                sumMoney += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                sumPay += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            textBox1.Text = ""+sumMoney;
            textBox2.Text = ""+sumPay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strMessage = "0-100积分：9.8折"  + "\n";
            strMessage = strMessage + "100-500积分：9.5折"  + "\n"; ;
            strMessage = strMessage + "500-1000积分：9.0折" +"\n";
            strMessage = strMessage + "1000积分以上：8.5折" ;
            MessageBox.Show(strMessage, "折扣说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 FM = new Form1();
            FM.Visible = true;
            this.Close();
        }
    }
}
