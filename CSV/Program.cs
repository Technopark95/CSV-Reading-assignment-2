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


            string DataFileSource = "data.csv";

      
            Employees emplists = new Employees(DataFileSource);

            Console.WriteLine("\n\n");

            emplists.PrintEmployeeData();

            Console.WriteLine("\n\n");

            emplists.PrintFailed();

            

            Console.WriteLine("\n\n");


            var Sortbyname = emplists.SortByName();


            foreach (var data in Sortbyname)
            {

                Console.WriteLine($"{data.FirstName,10}" + $"{data.MiddleName,15}" + $"{data.LastName,15}" + $"{data.Age,10}" + $"{data.Percent,10}");

            }



            Console.ReadKey();
         


        }
    }
}
