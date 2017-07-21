using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceDemo.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test =  new GoodDataServices();
            //var result = test.CountOfCourseSessionsByDepartment("Testing");
            var schools = test.SearchSchools(null, null, 0, 25);
            var limited = test.SearchSchools("Testing", "IA", 0, 25);
            var withProject = test.SearchWithProjection("Testing", "IA", 0, 25);
            Console.Read();
        }
    }
}
