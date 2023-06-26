using Microsoft.AspNetCore.Mvc;

namespace Architecture.Models
{
    public interface ICourseRepository
    {
        // Course
        Task<Course[]> GetAllCourseAsync();
        Task<Course[]> AddCourseAsync(Course CourseAdd);
        Task<Course> GetCoursesAsync(int ID);
        Task<Course> UpdateCourseAsync(int id, Course Request);
        Task<Course> DeleteCourseAsync(int id);

    }
}
