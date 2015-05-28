using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member_management_system_integration
{
    class Record
    {
        string idnumber;

        public string Idnumber
        {
            get { return idnumber; }
            set { idnumber = value; }
        }
        string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        string money;

        public string Money
        {
            get { return money; }
            set { money = value; }
        }
        string point;

        public string Point
        {
            get { return point; }
            set { point = value; }
        }
        string style;

        public string Style
        {
            get { return style; }
            set { style = value; }
        }
        string pay;

        public string Pay
        {
            get { return pay; }
            set { pay = value; }
        }
        public Record(string idnumber, string date, string money, string point, string style, string pay)
        {
            this.idnumber = idnumber;
            this.date = date;
            this.money = money;
            this.point = point;
            this.style = style;
            this.pay = pay;
        }
        
    }
}
