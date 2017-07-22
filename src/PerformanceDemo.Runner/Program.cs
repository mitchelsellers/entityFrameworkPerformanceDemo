using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var badTest = new BadDataService();
            
            var result = test.CountOfCourseSessionsByDepartment("Marketing");

            var timer = new Stopwatch();
            timer.Start();
            //var schools = test.SearchSchools(null, null, 0, 25);
            badTest.SearchSchoolsReallyBad(null, "IA", 0, 25);
            //var limited = test.SearchSchools("Testing", "IA", 0, 25);
            //var withProject = test.SearchWithProjection("Testing", "IA", 0, 25);
            //PerfTestGood();
            //PerfTestBad();
            timer.Stop();
            Console.WriteLine($"Elapsed time: {timer.Elapsed}");

            Console.Read();
        }

        public static void PerfTestGood()
        {
            Console.WriteLine("Starting good test");
            var test = new GoodDataServices();
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 1; i < 200; i++)
            {
                test.SearchWithProjection(null, "IA", 0, 25);
            }
            timer.Stop();
            Console.WriteLine($"Elapsed time: {timer.Elapsed}");
        }

        public static void PerfTestBad()
        {
            Console.WriteLine("Starting bad test");
            var test = new BadDataService();
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 1; i < 200; i++)
            {
                test.SearchSchoolsReallyBad(null, "IA", 0, 25);
            }
            timer.Stop();
            Console.WriteLine($"Really Bad Elapsed time: {timer.Elapsed}");
        }
    }
}
