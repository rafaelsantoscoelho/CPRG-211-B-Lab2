using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Employee
    {
        // Fields
        private string _name;
        private string _id;
        private string _address;
        private string _phone;
        private string _dob;
        private string _dept;
        private long _sin;

        // Properties
        public string Name { get =>  _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Dob { get => _dob; set => _dob = value; }
        public string Dept { get => _dept; set => _dept = value; }
        public long SIN { get => _sin; set => _sin = value; }

        // Constructors
        public Employee() { }
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.SIN = sin;
            this.Dob = dob;
            this.Dept = dept;
        }

        public string toString()
        {
            return string.Format("ID: {0}\nName: {1}\nAddress: {2}\nPhone: {3}\nSIN: {4}\nDob: {5}\nDepartment: {6}", this.Id, this.Name, this.Address, this.Phone, this.SIN, this.Dob, this.Dept);
        }
    }
}
