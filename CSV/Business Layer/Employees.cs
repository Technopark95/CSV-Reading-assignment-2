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


            EmployeeData Emps;

            List<EmployeeData> Emplists = new List<EmployeeData>();

            _FailedEmployeeList = new List<EmployeeData>();

            var Reader = new StreamReader(Source);


            while (!Reader.EndOfStream)
            {
                Emps = new EmployeeData();

                var Line = Reader.ReadLine();
                var Values = Line.Split(',');

                var SepeartedNames = Values[0].Trim().Split(' ');


                try
                {
                    Emps.Age = Convert.ToInt16(Values[1]);

                    if (Emps.Age < 18 || Emps.Age > 30)
                    {
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.AgeOutOFRangeException(Emps);

                    continue;

                }


                if (SepeartedNames.Length == 1)
                {
                    Emps.FirstName = SepeartedNames[0];
                    Emps.MiddleName = "";
                    Emps.LastName = "";
                }

                else if (SepeartedNames.Length == 2)
                {
                    Emps.FirstName = SepeartedNames[0];
                    Emps.MiddleName = "";
                    Emps.LastName = SepeartedNames[1];
                }


                else if (SepeartedNames.Length == 3)
                {
                    Emps.FirstName = SepeartedNames[0];
                    Emps.MiddleName = SepeartedNames[1];
                    Emps.LastName = SepeartedNames[2];
                }

                else if (SepeartedNames.Length > 3)
                {
                    string CollectedFirstname = "";

                    for (int i = 0; i < SepeartedNames.Length - 2; i++)
                    {
                        CollectedFirstname += SepeartedNames[i] + " ";

                    }

                    Emps.FirstName = CollectedFirstname.Trim();
                    Emps.MiddleName = SepeartedNames[SepeartedNames.Length - 2];
                    Emps.LastName = SepeartedNames[SepeartedNames.Length - 1];
                }



                try
                {
                    Emps.Percent = Convert.ToInt16(Values[2]);

                    if (Emps.Percent < 60)
                    {
                        throw new HandleException();
                    }

                }
                catch (HandleException except)
                {
                    except.MarksLessThan60Exception(Emps);

                    _FailedEmployeeList.Add(Emps);

                }

                Emplists.Add(Emps);
            }

            this.EmployeList = Emplists;

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
