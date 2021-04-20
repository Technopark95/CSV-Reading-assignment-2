using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class HandleException :Exception
    {


        public void AgeOutOFRangeException(EmployeeData person)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"AgeOutOFRangeExcetion : Age : {person.Age} is not in range, Ignoring the row.");

            Console.ResetColor();

        }


        public void MarksLessThan60Exception(EmployeeData person)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"MarksLessThan60Exception : Percentage : {person.Percent}% is less than 60%, Added in Failed List.");

            Console.ResetColor();
        }

    }
}
