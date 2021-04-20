using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
   public class Employees
    {

        public List<EmployeeData> EmployeList;

        private List<EmployeeData> _failedEmployeeList;

        private string _source;


        public  Employees (string dataSource)
        {
            EmployeList = new List<EmployeeData>();
            _failedEmployeeList = new List<EmployeeData>();
            _source = dataSource;

        }


        public void LoadEmployees()
        {


            EmployeeData Employee;

            this.EmployeList = new List<EmployeeData>();

            _failedEmployeeList = new List<EmployeeData>();

            var Reader = new StreamReader(_source);


            while (!Reader.EndOfStream)
            {
                Employee = new EmployeeData();

                var Line = Reader.ReadLine();
                var Values = Line.Split(',');

                var SeperatedNames = Values[0].Trim().Split(' ');


                try
                {
                    Employee.Age = Convert.ToInt16(Values[1]);

                    if (Employee.Age < 18 || Employee.Age > 30)
                    {
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.AgeOutOFRangeException(Employee);

                    continue;

                }


                if (SeperatedNames.Length == 1)
                {
                    Employee.FirstName = SeperatedNames[0];
                    Employee.MiddleName = "";
                    Employee.LastName = "";
                }

                else if (SeperatedNames.Length == 2)
                {
                    Employee.FirstName = SeperatedNames[0];
                    Employee.MiddleName = "";
                    Employee.LastName = SeperatedNames[1];
                }


                else if (SeperatedNames.Length == 3)
                {
                    Employee.FirstName = SeperatedNames[0];
                    Employee.MiddleName = SeperatedNames[1];
                    Employee.LastName = SeperatedNames[2];
                }

                else if (SeperatedNames.Length > 3)
                {
                    string CollectedFirstname = "";

                    for (int i = 0; i < SeperatedNames.Length - 2; i++)
                    {
                        CollectedFirstname += SeperatedNames[i] + " ";

                    }

                    Employee.FirstName = CollectedFirstname.Trim();
                    Employee.MiddleName = SeperatedNames[SeperatedNames.Length - 2];
                    Employee.LastName = SeperatedNames[SeperatedNames.Length - 1];
                }



                try
                {
                    Employee.Percent = Convert.ToInt16(Values[2]);

             
                    if (Employee.Percent < 60)
                    {

                        _failedEmployeeList.Add(Employee);
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.MarksLessThan60Exception(Employee);

                   

                }

                this.EmployeList.Add(Employee);
            }

        }


        public List<EmployeeData> SortByName()
        {
            List<EmployeeData> SortedListByName = EmployeList.OrderBy(employee => employee.FirstName).ToList();

            return SortedListByName;

        }

        public List<EmployeeData> SortByAge()
        {

            List<EmployeeData> SortedListByAge = EmployeList.OrderBy(employee => employee.Age).ToList();

            return SortedListByAge;

        }


        public void FormatHeader()
        {

            string[] header = { "First Name", "Middle Name", "Last Name", "Age", "Percentage" };
            String FormattedOutput = String.Format("{0,-15} {1,-15} {2,-15} {3,-10} {4,-10}",header );
            Console.WriteLine(FormattedOutput);

        }

        public void FormatOutput(object [] output)
        {

            String FormattedOutput = String.Format("{0,-15} {1,-15} {2,-15} {3,-10} {4,-10}", output);
            Console.WriteLine(FormattedOutput);

        }

        public void PrintEmployeeData()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            this.FormatHeader();

            Console.ResetColor();

            for (int i = 0; i < EmployeList.Count; i++)
            {

                object[] Header = { EmployeList[i].FirstName, EmployeList[i].MiddleName, EmployeList[i].LastName, EmployeList[i].Age, EmployeList[i].Percent };

                FormatOutput(Header);

            }

        }

        public void PrintFailed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.FormatHeader();
            Console.ResetColor();

            for (int i = 0; i < _failedEmployeeList.Count; i++)
            {

                object[] Output = { _failedEmployeeList[i].FirstName, _failedEmployeeList[i].MiddleName, _failedEmployeeList[i].LastName, _failedEmployeeList[i].Age, _failedEmployeeList[i].Percent };
                FormatOutput(Output);
            }

        }


    }
}
