using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{

 
    class Program
    {

        static void Main(string[] args) 
        {

            try
            {
            
                Employees EmployeesList = new Employees(Constants.SourcePath);

                EmployeesList.LoadEmployees();

                Console.WriteLine("\n\n");

                EmployeesList.PrintEmployeeData();

                Console.WriteLine("\n\n");

                EmployeesList.PrintFailed();


                Console.WriteLine("\n\n");


                var SortedListByName = EmployeesList.SortByName();


                Console.ForegroundColor = ConsoleColor.Green;

                EmployeesList.FormatHeader();

                Console.ResetColor();


                foreach (var Data in SortedListByName)
                {

                    object[] Output = { Data.FirstName, Data.MiddleName, Data.LastName, Data.Age, Data.Percent };
                    EmployeesList.FormatOutput(Output);

                   
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

          

         

            Console.ReadKey();
         


        }
    }
}
