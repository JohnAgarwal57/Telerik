using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Continents.Data;

namespace Continents.Console
{
    class Program
    { 
        static void Main(string[] args)
        {
            var context = new ContinentsDbContext();
            context.Continents.FirstOrDefault();
        }
    }
}
