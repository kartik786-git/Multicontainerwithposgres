using Multicontainerwithposgres.Entity;

namespace Multicontainerwithposgres.Data
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(TeacherDbcontext teacherDbContext)
        {
            if (teacherDbContext.Teachers.Any())
                return;

            var teaherOne = new Teacher
            {
                FirstName = "jhon",
                LastName = "ddd",
                Subject = "first",
                Address = "uk",

            };
            var teacherTwo = new Teacher
            {
                FirstName = "peter",
                LastName = "ddd",
                Subject = "first",
                Address = "uk",

            };
            var teacherThree = new Teacher
            {
                FirstName = "nedar",
                LastName = "ddd",
                Subject = "first",
                Address = "uk",

            };

            teacherDbContext.Teachers.Add(teaherOne);
            teacherDbContext.Teachers.Add(teacherTwo);
            teacherDbContext.Teachers.Add(teacherThree);
            teacherDbContext.SaveChanges();
        }
    }
}
