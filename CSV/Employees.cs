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


        public void FormatHeader()
        {

            string[] header = { "First Name", "Middle Name", "Last Name", "Age", "Percentage" };
            String FormattedOutput = String.Format("{0,-15} {1,-15} {2,-15} {3,-10} {4,-10}",header );
            Console.WriteLine(FormattedOutput);

        }

        public void FormatOutput(object [] header)
        {

    
            String FormattedOutput = String.Format("{0,-15} {1,-15} {2,-15} {3,-10} {4,-10}", header);
            Console.WriteLine(FormattedOutput);

        }

        public void PrintEmployeeData()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            this.FormatHeader();

            Console.ResetColor();

            for (int i = 0; i < EmployeList.Count; i++)
            {

                object[] header = { EmployeList[i].FirstName, EmployeList[i].MiddleName, EmployeList[i].LastName, EmployeList[i].Age, EmployeList[i].Percent };

                FormatOutput(header);

            }

        }



        public void PrintFailed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.FormatHeader();
            Console.ResetColor();

            for (int i = 0; i < _FailedEmployeeList.Count; i++)
            {

                object[] header = { EmployeList[i].FirstName, EmployeList[i].MiddleName, EmployeList[i].LastName, EmployeList[i].Age, EmployeList[i].Percent };
                FormatOutput(header);
            }

        }



    }
}
