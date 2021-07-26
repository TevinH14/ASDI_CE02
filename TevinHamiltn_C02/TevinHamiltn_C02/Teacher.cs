using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TevinHamiltn_C02
{
    class Teacher : Person
    {
        public string[] Background { get; set; }

        public Teacher(string name ,int age,string[] background):base(name,age)
        {

            Background = background;
        }
    }
}
