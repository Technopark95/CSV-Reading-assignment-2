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


           const string DataFileSource = "data.csv";

            try
            {
                Employees Emplists = new Employees(DataFileSource);

                Emplists.LoadEmployees();

                Console.WriteLine("\n\n");

                Emplists.PrintEmployeeData();

                Console.WriteLine("\n\n");

                Emplists.PrintFailed();


                Console.WriteLine("\n\n");


                var Sortbyname = Emplists.SortByName();


                foreach (var data in Sortbyname)
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
