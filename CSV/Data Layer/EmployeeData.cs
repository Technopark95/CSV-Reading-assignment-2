using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class EmployeeData
    {

        public EmployeeData()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Age = 0;
            Percent = 0.0;

        }

        public string FirstName { get; set; }


        public string MiddleName { get; set; }

        public string LastName { get; set; }


        public int Age { get; set; }

        public double Percent { get; set; }



    }
}
