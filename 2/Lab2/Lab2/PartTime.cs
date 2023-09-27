using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PartTime : Employee
    {
        // Fields
        private double _rate;
        private double _hours;

        // Properties
        public double Rate { get => _rate; set => _rate = value; }
        public double Hours { get => _hours; set => _hours = value; }

        // Constructors
        public PartTime() { }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            if (id[0] >= '8' && id[0] <= '9')
            {
                base.Id = id;
                base.Name = name;
                base.Address = address;
                base.Phone = phone;
                base.SIN = sin;
                base.Dob = dob;
                base.Dept = dept;
                this.Rate = rate;
                this.Hours = hours;
            }

            else
            {
                throw new Exception("Part-time employee IDs must have the first digit in the 8--9 range!");
            }
        }

        // Methods
        public double getPay()
        {
            return this.Hours * this.Rate;
        }

        public void toString()
        {
            string basicInfo = base.toString();
            Console.WriteLine(basicInfo + "\nWeekly pay: ${0:.##}", this.getPay());
        }
    }
}
