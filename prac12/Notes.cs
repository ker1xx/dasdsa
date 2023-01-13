using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac12
{
    internal class Notes
    {
        public Notes(string a,string b, DateTime c)
        {
            name = a;
            description = b;
            date = c;
        }
        public string name;
        public string description;
        public DateTime date;
    }
}
