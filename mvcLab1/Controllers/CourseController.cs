using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        IDepartmentReposetory departmentRepository;
        public CourseController(ICourseRepository _courseRepository, IDepartmentReposetory _departmentReposetory)
        {
            courseRepository = _courseRepository;
            departmentRepository = _departmentReposetory;
        }

        //ITIDBContext context = new ITIDBContext();

        public IActionResult Index()
        {
            List<Course> courses = courseRepository.GetAll("Department");
            return View(courses);
        }

        public JsonResult CheckMinDegree(int MinDegree, int Degree)
        {
            if (MinDegree < Degree)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult Add()
        {
            CourseDataViewModel courseData = new CourseDataViewModel();
            courseData.departmentList = departmentRepository.GetAll();
            return View(courseData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(CourseDataViewModel CourseDaraFromReq)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course();
                course.Name = CourseDaraFromReq.Name;
                course.Degree = CourseDaraFromReq.Degree;
                course.MinDegree = CourseDaraFromReq.MinDegree;
                course.Hours = CourseDaraFromReq.Hours;
                course.DepartmentId = CourseDaraFromReq.DepartmentId;

                courseRepository.Add(course);
                try
                {
                    courseRepository.SaveChangesToDB();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DepartmentId", "You must choose Department");
                    CourseDaraFromReq.departmentList = departmentRepository.GetAll();
                    return View("Add", CourseDaraFromReq);
                }

                return RedirectToAction("Index");
            }
            else
            {
                CourseDaraFromReq.departmentList = departmentRepository.GetAll();
                return View("Add", CourseDaraFromReq);
            }

        }
    }
}
