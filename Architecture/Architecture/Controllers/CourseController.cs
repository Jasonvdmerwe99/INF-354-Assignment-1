using Architecture.Models;
using Architecture.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly AppDbContext _appDbContext;


        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var results = await _courseRepository.GetAllCourseAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500,"Internal Server Error. Please contact support.");
            }
        }

        [HttpPost]
        [Route("CourseAdd")]
        public async Task<IActionResult> AddCourse([FromBody] Course CourseAdd)
        {
            try
            {
                var results = await _courseRepository.AddCourseAsync(CourseAdd);
                return Ok(results);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
                throw;
            }
        }

        [HttpGet]
        [Route("CourseEdit{id}")]

        public async Task<IActionResult> GetEmployeeByID([FromRoute] int id)
        {
            try
            {
                var result = await _courseRepository.GetCoursesAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
                throw;
            }
        }

        [HttpPut]
        [Route("CourseEditSave{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int id, Course UpdateCourseRequest)
        {
            var result = await _courseRepository.UpdateCourseAsync(id, UpdateCourseRequest);
            return Ok(result);
        }

        [HttpDelete]
        [Route("CourseDelete{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            var result = await _courseRepository.DeleteCourseAsync(id);
            return Ok(result);
        }


    }
}
