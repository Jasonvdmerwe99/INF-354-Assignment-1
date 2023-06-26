using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Models
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }
        public async Task<Course[]> GetAllCourseAsync()
        {
            IQueryable<Course> query = _appDbContext.Courses;
            return await query.ToArrayAsync();
        }

        public async Task<Course[]> AddCourseAsync(Course CourseAdd)
        {
            await _appDbContext.Courses.AddAsync(CourseAdd);
            await _appDbContext.SaveChangesAsync();

            return new Course[] { CourseAdd };
        }

        public async Task<Course> GetCoursesAsync (int id)
        {
            Course course = await _appDbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);


            return course;
        }

        public async Task<Course> UpdateCourseAsync(int id, Course Request)
        {
           var Course = await _appDbContext.Courses.FindAsync(id);

            Course.Name = Request.Name;
            Course.Description = Request.Description;
            Course.Duration = Request.Duration;

            await _appDbContext.SaveChangesAsync();

            return Course;
        }

        public async Task<Course> DeleteCourseAsync(int id)
        {
            var employeetodelete = await _appDbContext.Courses.FindAsync(id);
            _appDbContext.Courses.Remove(employeetodelete);
            await _appDbContext.SaveChangesAsync();

            return employeetodelete;
        }
    }
}
