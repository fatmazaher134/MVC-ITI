using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace mvcLab1.Controllers
{
    public class TraineeController : Controller
    {
        ITraineeRepository traineeRepository; 
        ICourseRepository courseRepository;
        public TraineeController(ITraineeRepository _traineeRepository, ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
            traineeRepository = _traineeRepository;
        }
        [HttpGet("trainee/{TrID}/{CId}")]
        public IActionResult Result(int TrId, int CId)
        {

            TraineeNameWithCourseNameDegreeStatus traineeResult = new();
            CrsResult TraineeFromRepo = traineeRepository.GetCrsResultByTraineeIdAndCourseId(TrId, CId);


            traineeResult.TraineeName = TraineeFromRepo.Trainee.Name;

            traineeResult.CourseName = TraineeFromRepo.Course.Name;
            traineeResult.Degree = TraineeFromRepo.Degree;
            

            traineeResult.Status = (traineeResult.Degree >= TraineeFromRepo.Course.MinDegree? "Pass" : "Fail");

            traineeResult.Color = (traineeResult.Status == "Pass") ? "Green" : "Red";

            return View(traineeResult);
        }
        public IActionResult GetTraineesByCourse(int CId)
        {
            List<Trainee> trainees = traineeRepository.GetTraineesByCourseID(CId);
            List<TraineeNameWithCourseNameDegreeStatus> data = new ();
            foreach (var trainee in trainees)
            {
                CrsResult crsResult = traineeRepository.GetCrsResultByTraineeIdAndCourseId(trainee.Id, CId);
                TraineeNameWithCourseNameDegreeStatus traineeResult = new()
                {
                    TraineeName = trainee.Name,
                    CourseName = crsResult.Course.Name,
                    Degree = crsResult.Degree,
                    Status = (crsResult.Degree >= crsResult.Course.MinDegree) ? "Pass" : "Fail",
                    Color = (crsResult.Degree >= crsResult.Course.MinDegree) ? "green" : "red"
                };
                data.Add(traineeResult);
            }

           
            return View(data);
        }

        public IActionResult GetCoursesByTrainee(int TrId)
        {
            List<Course> courses = courseRepository.GetCoursesByTraineeId(TrId);
            List<TraineeNameWithCourseNameDegreeStatus> data = new();
            foreach (var course in courses)
            {
                CrsResult crsResult = traineeRepository.GetCrsResultByTraineeIdAndCourseId(TrId, course.Id);
                TraineeNameWithCourseNameDegreeStatus traineeResult = new()
                {
                    TraineeName = crsResult.Trainee.Name,
                    CourseName = course.Name,
                    Degree = crsResult.Degree,
                    Status = (crsResult.Degree >= crsResult.Course.MinDegree) ? "Pass" : "Fail",
                    Color = (crsResult.Degree >= crsResult.Course.MinDegree) ? "green" : "red"
                };
                data.Add(traineeResult);
            }


            return View(data);
        }




    }
}
