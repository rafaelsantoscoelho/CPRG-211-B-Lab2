namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Task #1 : Fill a list with objects based on the supplied data file");
            Console.WriteLine("Reading data from file employees.txt");
            List<Employee> employees = FillList("employees.txt");
            Console.WriteLine("-----------------------------------\n");

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Task #2 : Calculate and return the average weekly pay for all employees");
            Console.WriteLine("Average weekly pay for all wage employees = ${0:.##}", AverageWeeklyPay(employees));
            Console.WriteLine("-----------------------------------\n");

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Task #3 : Calculate and return the highest weekly pay for the wage employees, including the name of the employee");
            Tuple<double, Wage> highWeeklyPayWage = HighestWeeklyPayWage(employees);
            Console.WriteLine("{0} is the wage employee with the highest weekly pay", highWeeklyPayWage.Item2.Name, highWeeklyPayWage.Item1);
            highWeeklyPayWage.Item2.toString();
            Console.WriteLine("-----------------------------------\n");

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Task #4 : Calculate and return the lowest salary for the salaried employees, including the name of the employee");
            Tuple<double, Salaried> lowSalarySalaried = LowestSalarySalaried(employees);
            Console.WriteLine("{0} is the salaried employee with the lowest salary", lowSalarySalaried.Item2.Name, lowSalarySalaried.Item1);
            lowSalarySalaried.Item2.toString();
            Console.WriteLine("-----------------------------------\n");

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Task #5 : What percentage of the company’s employees fall into each employee category?");
            CalculateAndShowPercentages(employees);
            Console.WriteLine("-----------------------------------");
        }

        static List<Employee> FillList(string filename)
        {

            List<Employee> list = new List<Employee>();
            IEnumerable<string> lines = File.ReadLines(filename);

            foreach (string line in lines)
            {
                // Console.WriteLine(line);

                string[] fields = line.Split(':');

                string id = fields[0];
                string name = fields[1];
                string address = fields[2];
                string phone = fields[3];
                long sin = long.Parse(fields[4]);
                string dob = fields[5];
                string dept = fields[6];

                if (id[0] >= '0' && id[0] <= '4')
                {
                    double salary = double.Parse(fields[^1]);
                    list.Add(new Salaried(id, name, address, phone, sin, dob, dept, salary));
                }

                else if (id[0] >= '5' && id[0] <= '7')
                {
                    double rate = double.Parse(fields[^2]);
                    double hours = double.Parse(fields[^1]);
                    list.Add(new Wage(id, name, address, phone, sin, dob, dept, rate, hours));
                }

                else
                {
                    double rate = double.Parse(fields[^2]);
                    double hours = double.Parse(fields[^1]);
                    list.Add(new PartTime(id, name, address, phone, sin, dob, dept, rate, hours));
                }
            }

            return list;
        }

        static double AverageWeeklyPay(List<Employee> employees)
        {
            double sum = 0.0;

            foreach (Employee employee in employees)
            {
                if (employee.Id[0] >= '0' && employee.Id[0] <= '4')
                {
                    Salaried salaried = (Salaried) employee;
                    sum += salaried.getPay();
                }

                else if (employee.Id[0] >= '5' && employee.Id[0] <= '7')
                {
                    Wage wage = (Wage) employee;
                    sum += wage.getPay();
                }

                else
                {
                    PartTime partTime = (PartTime) employee;
                    sum += partTime.getPay();
                }
            }

            return sum / ((double) employees.Count);
        }

        static Tuple<double, Wage> HighestWeeklyPayWage(List<Employee> employees)
        {
            double sum = double.MinValue;
            Wage wageResult = null;

            foreach (Employee employee in employees)
            {
                if (employee.Id[0] >= '5' && employee.Id[0] <= '7')
                {
                    Wage wage = (Wage) employee;

                    if (wage.getPay() > sum)
                    {
                        sum = wage.getPay();
                        wageResult = wage;
                    }
                }
            }

            return new Tuple<double, Wage>(sum, wageResult);
        }

        static Tuple<double, Salaried> LowestSalarySalaried(List<Employee> employees)
        {
            double sum = double.MaxValue;
            Salaried salariedResult = null;

            foreach (Employee employee in employees)
            {
                if (employee.Id[0] >= '0' && employee.Id[0] <= '4')
                {
                    Salaried salaried = (Salaried) employee;

                    if (salaried.Salary < sum)
                    {
                        sum = salaried.Salary;
                        salariedResult = salaried;
                    }
                }
            }

            return new Tuple<double, Salaried>(sum, salariedResult);
        }

        static void CalculateAndShowPercentages(List<Employee> employees)
        {
            int countSalaried = 0;
            int countWage = 0;
            int countPartTime = 0;

            foreach (Employee employee in employees)
            {
                if (employee.Id[0] >= '0' && employee.Id[0] <= '4')
                {
                    countSalaried++;
                }

                else if (employee.Id[0] >= '5' && employee.Id[0] <= '7')
                {
                    countWage++;
                }
            }

            double percentageSalaried = (countSalaried == 0) ? 0 : ((double) countSalaried) / ((double) employees.Count);
            double percentageWage = (countWage == 0) ? 0 : ((double) countWage) / ((double) employees.Count);
            double percentagePartTime = 1.0 - (percentageSalaried + percentageWage);

            Console.WriteLine("Salaried employees = {0:.##}%\nWage employees = {1:.##}%\nPart-time employees = {2:.##}%", percentageSalaried * 100.0, percentageWage * 100.0, percentagePartTime * 100.0);
        }
    }
}
