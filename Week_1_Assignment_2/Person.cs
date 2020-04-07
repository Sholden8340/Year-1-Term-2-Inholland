using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    enum GenderType
    {
        Male, Female
    }
    struct Person
    {
        public string FirstName, LastName, City;
        public int Age;
        public GenderType Gender;
    }
}