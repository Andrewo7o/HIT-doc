using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member_management_system_integration
{
    public class Node//链表数据域
    {
        public string name;
        public string sex;
        public string idnumber;
        public string telephone;
        public string live;

        public Node()
        {

        }

        public Node(string value1, string value2, string value3, string value4, string value5)
        {
            name = value1;
            sex = value2;
            idnumber = value3;
            telephone = value4;
            live = value5;
        }

        public Node(Node elem)
        {
            this.name = elem.name;
            this.sex = elem.sex;
            this.idnumber = elem.idnumber;
            this.telephone = elem.telephone;
            this.live = elem.live;
        }

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
        public string IDnumber
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


    public class list//链表
    {
        public Node data;
        public list link;
        public list()
        {
            this.data = null;
            this.link = null;
        }
        public list(Node elem)
        {
            this.data = new Node(elem);
            this.link = null;
        }
    }

    public class Linklist
    {
        public list head;
        public Linklist()
        {
            head = new list();
            head.link = null;
        }
        public list Find(Node elem)
        {
            list current = new list(elem);
            current = head;
            while (current.data != elem)
            {
                current = current.link;
            }
            return current;
        }
        public void Add(Node newElem)
        {
            list newNode = new list(newElem);
            newNode.link = head.link;
            head.link = newNode;
        }
        public list findPrevious(Node elem)
        {
            list current = head;
            while (current.link.data != elem && current.link.data != null)
            {
                current = current.link;
            }
            return current;
        }
        public void Remove(Node elem)
        {
            list p = findPrevious(elem);
            if (p.link != null)
                p.link = p.link.link;
        }
    }
}
