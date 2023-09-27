using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Salaried : Employee
    {
        // Fields
        private double _salary;

        // Properties
        public double Salary { get => _salary; set => _salary = value; }

        // Constructors
        public Salaried() { }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
        {
            if (id[0] >= '0' && id[0] <= '4')
            {
                base.Id = id;
                base.Name = name;
                base.Address = address;
                base.Phone = phone;
                base.SIN = sin;
                base.Dob = dob;
                base.Dept = dept;
                this.Salary = salary;
            }

            else
            {
                throw new Exception("Salaried employees IDs must have the first digit in the 0--4 range!");
            }
        }

        public double getPay() { return this.Salary / 52; }

        public void toString()
        {
            string basicInfo = base.toString();
            Console.WriteLine(basicInfo + "\nYearly salary: ${0:.##}\nWeekly pay: ${1:.##}", this.Salary, this.getPay());
        }
    }
}
