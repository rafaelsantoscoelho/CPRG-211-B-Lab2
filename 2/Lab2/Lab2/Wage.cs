using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Wage : Employee
    {
        // Fields
        private double _rate;
        private double _hours;

        // Properties
        private double Rate { get => _rate; set => _rate = value; }
        private double Hours { get => _hours; set => _hours = value; }

        // Constructors
        public Wage() { }
        public Wage(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            if (id[0] >= '5' && id[0] <= '7')
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
                throw new Exception("Wage employees IDs must have the first digit in the  5--7 range!");
            }
        }

        // Methods
        public double getPay()
        {
            return ((this.Hours > 40.0) ? 40.0 * this.Rate + (this.Hours - 40.0) * this.Rate * 1.5 : this.Hours * this.Rate);
        }

        public void toString()
        {
            string basicInfo = base.toString();
            Console.WriteLine(basicInfo + "\nWeekly pay: ${0:.##}", this.getPay());
        }
    }
 }
