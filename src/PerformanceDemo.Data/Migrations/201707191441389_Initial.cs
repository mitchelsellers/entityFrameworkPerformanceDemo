namespace PerformanceDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 500),
                        CourseAcronym = c.String(nullable: false, maxLength: 10),
                        CourseDescription = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseName, unique: true)
                .Index(t => t.CourseAcronym, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolTypeId = c.Int(nullable: false),
                        SchoolName = c.String(nullable: false, maxLength: 500),
                        Address = c.String(nullable: false, maxLength: 200),
                        Address2 = c.String(maxLength: 200),
                        City = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.SchoolId)
                .ForeignKey("dbo.SchoolTypes", t => t.SchoolTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AddressStates", t => t.StateId, cascadeDelete: true)
                .Index(t => t.SchoolTypeId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        Roomname = c.String(nullable: false),
                        MaxStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomId)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.CourseSessions",
                c => new
                    {
                        CourseSessionId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        SessionIdentifier = c.String(nullable: false, maxLength: 50),
                        RegistrationOpens = c.DateTime(nullable: false),
                        RegistrationCloses = c.DateTime(nullable: false),
                        ClassStarts = c.DateTime(nullable: false),
                        ClassEnds = c.DateTime(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        Instructor_FacultyMemberId = c.Int(),
                        Classroom_ClassroomId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseSessionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.FacultyMembers", t => t.Instructor_FacultyMemberId)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => t.Classroom_ClassroomId)
                .Index(t => t.CourseId)
                .Index(t => t.SchoolId)
                .Index(t => t.Instructor_FacultyMemberId)
                .Index(t => t.Classroom_ClassroomId);
            
            CreateTable(
                "dbo.FacultyMembers",
                c => new
                    {
                        FacultyMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 500),
                        School_SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.FacultyMemberId)
                .ForeignKey("dbo.Schools", t => t.School_SchoolId)
                .Index(t => t.School_SchoolId);
            
            CreateTable(
                "dbo.SchoolTypes",
                c => new
                    {
                        SchoolTypeId = c.Int(nullable: false, identity: true),
                        SchoolTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolTypeId);
            
            CreateTable(
                "dbo.AddressStates",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateCode = c.String(maxLength: 2),
                        StateName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.SchoolCourses",
                c => new
                    {
                        School_SchoolId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.School_SchoolId, t.Course_CourseId })
                .ForeignKey("dbo.Schools", t => t.School_SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.School_SchoolId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schools", "StateId", "dbo.AddressStates");
            DropForeignKey("dbo.Schools", "SchoolTypeId", "dbo.SchoolTypes");
            DropForeignKey("dbo.SchoolCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.SchoolCourses", "School_SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Classrooms", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.CourseSessions", "Classroom_ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.CourseSessions", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.CourseSessions", "Instructor_FacultyMemberId", "dbo.FacultyMembers");
            DropForeignKey("dbo.FacultyMembers", "School_SchoolId", "dbo.Schools");
            DropForeignKey("dbo.CourseSessions", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.SchoolCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.SchoolCourses", new[] { "School_SchoolId" });
            DropIndex("dbo.FacultyMembers", new[] { "School_SchoolId" });
            DropIndex("dbo.CourseSessions", new[] { "Classroom_ClassroomId" });
            DropIndex("dbo.CourseSessions", new[] { "Instructor_FacultyMemberId" });
            DropIndex("dbo.CourseSessions", new[] { "SchoolId" });
            DropIndex("dbo.CourseSessions", new[] { "CourseId" });
            DropIndex("dbo.Classrooms", new[] { "SchoolId" });
            DropIndex("dbo.Schools", new[] { "StateId" });
            DropIndex("dbo.Schools", new[] { "SchoolTypeId" });
            DropIndex("dbo.Courses", new[] { "CourseAcronym" });
            DropIndex("dbo.Courses", new[] { "CourseName" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.SchoolCourses");
            DropTable("dbo.AddressStates");
            DropTable("dbo.SchoolTypes");
            DropTable("dbo.FacultyMembers");
            DropTable("dbo.CourseSessions");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Schools");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
