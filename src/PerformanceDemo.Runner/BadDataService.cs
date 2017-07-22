using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceDemo.Data;
using PerformanceDemo.Data.Models;

namespace PerformanceDemo.Runner
{
    public class BadDataService
    {
        public List<School> SearchSchools(string schoolName, int startRecord, int numberOfRecords)
        {
            using (var ctx = new SampleDbContext())
            {
                //Get entire schools table here
                var query = ctx.Schools.ToList(); //Grabs the entire schools table

                //Filtering - ALL in Memory
                if (!string.IsNullOrEmpty(schoolName))
                    query = query.Where(s => s.SchoolName.StartsWith(schoolName)).ToList();

                //Order and page
                query = query.OrderBy(s => s.SchoolName).ToList();
                query = query.Skip(startRecord).ToList();
                query = query.Take(numberOfRecords).ToList();

                //Execute my query
                return query.ToList(); //Call the DB!
            }
        }

        public List<School> SearchSchoolsReallyBad(string schoolName, string state, int startRecord, int numberOfRecords)
        {
            using (var ctx = new SampleDbContext())
            {
                //Get entire schools table here
                var query = ctx.Schools.AsNoTracking().Include(s => s.State).ToList(); //Grabs the entire schools table

                //Filtering - ALL in Memory
                if (!string.IsNullOrEmpty(schoolName))
                    query = query.Where(s => s.SchoolName.StartsWith(schoolName)).ToList();
                if (!string.IsNullOrEmpty(state))
                    //1 DB Call Per POSSIBLE record
                    query = query.Where(s => s.State.StateCode == state).ToList(); 

                //Order and page
                query = query.OrderBy(s => s.SchoolName).ToList();
                query = query.Skip(startRecord).ToList();
                query = query.Take(numberOfRecords).ToList();

                //Execute my query
                return query.ToList(); //Call the DB!
            }
        }
    }
}
