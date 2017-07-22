using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PerformanceDemo.Data;
using PerformanceDemo.Data.Models;
using PerformanceDemo.Runner.Projection;

namespace PerformanceDemo.Runner
{
    public class GoodDataServices
    {
        public int CountOfCourseSessionsByDepartment(string departmentName)
        {
            //Intro to Computers (Com Sci)
            // -January 2017 - in Room 217
            // -Feb 2017 - in Room 220
            //Intro to C# (Com Sci)
            // - March 2017 - in room 500

            using (var ctx = new SampleDbContext())
            {
                return ctx.Courses
                    .Where(c => c.Department.DepartmentName == departmentName) //Filter
                    .Select(c => c.Sessions.Count()) //Select
                    .Sum(); //Aggregate
            }
        }

        public List<School> SearchSchools(string schoolName, string state, int startRecord, int numberOfRecords)
        {
            using (var ctx = new SampleDbContext())
            {
                var query = ctx.Schools.AsQueryable().AsNoTracking(); //TO build the quey

                //Build out my query
                if (!string.IsNullOrEmpty(schoolName))
                    query = query.Where(s => s.SchoolName.StartsWith(schoolName));
                if (!string.IsNullOrEmpty(state))
                    query = query.Where(s => s.State.StateCode == state);

                //Order and page
                query = query.OrderBy(s => s.SchoolName);
                query = query.Skip(startRecord);
                query = query.Take(numberOfRecords);

                //Execute my query
                return query.ToList(); //Call the DB!
            }
        }

        public List<SchoolListModel> SearchWithProjection(string schoolName, string state, int startRecord, int numberOfRecords)
        {
            using (var ctx = new SampleDbContext())
            {
                var query = ActiveSchoolsForList(ctx);

                //Build out my query
                if (!string.IsNullOrEmpty(schoolName))
                    query = query.Where(s => s.SchoolName.StartsWith(schoolName));
                if (!string.IsNullOrEmpty(state))
                    query = query.Where(s => s.State.StateCode == state);

                //Order and page
                query = query.OrderBy(s => s.SchoolName).Skip(startRecord).Take(numberOfRecords);

                //Execute my query
                return query
                    .Select(s => new SchoolListModel
                    {
                        SchoolId = s.SchoolId,
                        SchoolName = s.SchoolName,
                        StateName = s.State.StateName
                    })
                    .ToList();
            }
        }

        public IQueryable<School> ActiveSchoolsForList(SampleDbContext ctx)
        {
            return ctx.Schools.AsNoTracking().Where(s => s.IsActive);
        }

    }
}
