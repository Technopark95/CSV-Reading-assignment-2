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

        private List<EmployeeData> _FailedEmployeeList;

        private string Source;


        public  Employees (string DataSource)
        {
            Source = DataSource;

        }


        public void LoadEmployees()
        {


            EmployeeData emps;

            List<EmployeeData> emplists = new List<EmployeeData>();

            _FailedEmployeeList = new List<EmployeeData>();

            var reader = new StreamReader(Source);


            while (!reader.EndOfStream)
            {
                emps = new EmployeeData();

                var line = reader.ReadLine();
                var values = line.Split(',');

                var SepeartedNames = values[0].Trim().Split(' ');


                try
                {
                    emps.Age = Convert.ToInt16(values[1]);

                    if (emps.Age < 18 || emps.Age > 30)
                    {
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.AgeOutOFRangeException(emps);

                    continue;

                }


                if (SepeartedNames.Length == 1)
                {
                    emps.FirstName = SepeartedNames[0];
                    emps.MiddleName = "";
                    emps.LastName = "";
                }

                else if (SepeartedNames.Length == 2)
                {
                    emps.FirstName = SepeartedNames[0];
                    emps.MiddleName = "";
                    emps.LastName = SepeartedNames[1];
                }


                else if (SepeartedNames.Length == 3)
                {
                    emps.FirstName = SepeartedNames[0];
                    emps.MiddleName = SepeartedNames[1];
                    emps.LastName = SepeartedNames[2];
                }

                else if (SepeartedNames.Length > 3)
                {
                    string CollectedFirstname = "";

                    for (int i = 0; i < SepeartedNames.Length - 2; i++)
                    {
                        CollectedFirstname += SepeartedNames[i] + " ";

                    }

                    emps.FirstName = CollectedFirstname.Trim();
                    emps.MiddleName = SepeartedNames[SepeartedNames.Length - 2];
                    emps.LastName = SepeartedNames[SepeartedNames.Length - 1];
                }



                try
                {
                    emps.Percent = Convert.ToInt16(values[2]);

                    if (emps.Percent < 60)
                    {
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.MarksLessThan60Exception(emps);

                    _FailedEmployeeList.Add(emps);

                }

                emplists.Add(emps);
            }

            this.EmployeList = emplists;

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


        public void PrintEmployeeData()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"First Name",10}" + $"{"Middle Name",15}" + $"{"Last Name",15}" + $"{"Age",11}" + $"{"Percentage",17}");

            Console.ResetColor();

            for (int i = 0; i < EmployeList.Count; i++)
            {

                Console.WriteLine($"{EmployeList[i].FirstName,10}" + $"{EmployeList[i].MiddleName,15}" + $"{EmployeList[i].LastName,15}" + $"{EmployeList[i].Age,10}" + $"{EmployeList[i].Percent,10}");

            }

        }



        public void PrintFailed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"First Name",10}" + $"{"Middle Name",15}" + $"{"Last Name",15}" + $"{"Age",11}" + $"{"Percentage",17}");
            Console.ResetColor();

            for (int i = 0; i < _FailedEmployeeList.Count; i++)
            {

                Console.WriteLine($"{_FailedEmployeeList[i].FirstName,10}" + $"{_FailedEmployeeList[i].MiddleName,15}" + $"{_FailedEmployeeList[i].LastName,15}" + $"{_FailedEmployeeList[i].Age,10}" + $"{_FailedEmployeeList[i].Percent,10}");

            }

        }



    }
}
