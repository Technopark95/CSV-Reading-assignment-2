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
            
                Employees EmpLists = new Employees(Constants.SourcePath);

                EmpLists.LoadEmployees();

                Console.WriteLine("\n\n");

                EmpLists.PrintEmployeeData();

                Console.WriteLine("\n\n");

                EmpLists.PrintFailed();


                Console.WriteLine("\n\n");


                var SortedListByName = EmpLists.SortByName();


                Console.ForegroundColor = ConsoleColor.Green;
                EmpLists.FormatHeader();

                Console.ResetColor();


                foreach (var data in SortedListByName)
                {

                    Console.WriteLine($"{data.FirstName,10}" + $"{data.MiddleName,15}" + $"{data.LastName,15}" + $"{data.Age,10}" + $"{data.Percent,10}");

                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

          

         

            Console.ReadKey();
         


        }
    }
}
