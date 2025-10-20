using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Controllers
{
    public class InstructorController : Controller
    {
        IInstructorRepository instructorRepository;
        IDepartmentReposetory departmentRepository;
        ICourseRepository courseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InstructorController(IInstructorRepository _instructorRepository,
            IDepartmentReposetory _departmentReposetory,
            IWebHostEnvironment webHostEnvironment,
            ICourseRepository _courseRepository)
        {
            instructorRepository = _instructorRepository;
            departmentRepository = _departmentReposetory;
            _webHostEnvironment = webHostEnvironment;
            courseRepository = _courseRepository;
        }



        #region IndexAction

        public IActionResult Index(string? searchByName)
        {
            List<Instractore> instructores;
            if (searchByName == null)
            {


                instructores = instructorRepository.GetAll("Department,Course");


            }
            else
            {
                instructores = instructorRepository.SearchInstructorByName(searchByName);

            }
            return View(instructores);
        }

        
        #endregion
        #region DetailsAction
        public IActionResult Details(int id)
        {

            Instractore? instructore = instructorRepository.GetById(id, "Department,Course");
            if (instructore == null)
            {
                return NotFound();
            }
            return View(instructore);
        }
        #endregion

        #region AddAction
        public IActionResult Add()
        {
            InstructorWithDepartmentListWithCourseListViewModel instructor = new();
            instructor.DepartmentList = departmentRepository.GetAll();
            instructor.CourseList = courseRepository.GetAll();
            return View(instructor);
        }


        public IActionResult GetCoursesByDeptId(int deptId)
        {
            List<Course> courses = courseRepository.GetCoursesByDeptId(deptId);
            return Json(courses);
        }




        [HttpPost]
        public IActionResult SaveAdd(InstructorWithDepartmentListWithCourseListViewModel instructorFromReq) { 
            if (instructorFromReq.Name != null && instructorFromReq.Salary >= 0 && instructorFromReq.DepartmentId >= 0 && instructorFromReq.CourseId >= 0)
            {
                string uniqueFileName = null;

                if (instructorFromReq.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + instructorFromReq.Image.FileName; 
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        instructorFromReq.Image.CopyTo(fileStream);
                    }
                }



                Instractore instractoreToDB = new Instractore()
                {
                    Name = instructorFromReq.Name,
                    Salary = instructorFromReq.Salary,
                    imageUrl = "Images/"+uniqueFileName,
                    Address = instructorFromReq.Address,
                    DepartmentId = instructorFromReq.DepartmentId,
                    CourseId = instructorFromReq.CourseId
                };
                instructorRepository.Add(instractoreToDB);
                instructorRepository.SaveChangesToDB();
                return RedirectToAction("Index");
            }
            instructorFromReq.DepartmentList = departmentRepository.GetAll();
            instructorFromReq.CourseList = courseRepository.GetAll();
            return View("Add", instructorFromReq);
        }
        #endregion 
    }
}