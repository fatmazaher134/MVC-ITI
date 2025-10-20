using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace mvcLab1.Controllers
{
    public class TraineeController : Controller
    {
        ITIDBContext context;
        public TraineeController(ITIDBContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Result(int TrId, int CId)
        {

            TraineeNameWithCourseNameDegreeStatus traineeResult = new();

            traineeResult.TraineeName = context.Trainees
                                              .FirstOrDefault(t => t.Id == TrId).Name;

            traineeResult.CourseName = context.Courses
                                                .FirstOrDefault(c => c.Id == CId).Name;
            traineeResult.Degree = context.CrsResults
                                          .FirstOrDefault(cr => cr.TraineeId == TrId && cr.CourseId == CId).Degree;

            traineeResult.Status = (traineeResult.Degree >= context.Courses
                                                            .FirstOrDefault(c => c.Id == CId).MinDegree) ? "Pass" : "Fail";

            traineeResult.Color = (traineeResult.Status == "Pass") ? "Green" : "Red";

            return View(traineeResult);
        }
        public IActionResult GetTraineesByCourse(int CId)
        {

            List <TraineeNameWithCourseNameDegreeStatus> data = context.CrsResults
                                .Where(cr => cr.CourseId == CId)
                                .Include(cr => cr.Trainee)
                                .Include(cr => cr.Course)
                                .Select(cr => new TraineeNameWithCourseNameDegreeStatus
                                {
                                    TraineeName = cr.Trainee.Name,
                                    CourseName = cr.Course.Name,
                                    Degree = cr.Degree,
                                    Status = (cr.Degree >= cr.Course.MinDegree) ? "Pass" : "Fail",
                                    Color = (cr.Degree >= cr.Course.MinDegree) ? "green" : "red"
                                }).ToList();


            return View(data);
        }

        public IActionResult GetCoursesByTrainee(int TrId)
        {

            List<TraineeNameWithCourseNameDegreeStatus> data = context.CrsResults
                                .Where(cr => cr.TraineeId == TrId)
                                .Include(cr => cr.Trainee)
                                .Include(cr => cr.Course)
                                .Select(cr => new TraineeNameWithCourseNameDegreeStatus
                                {
                                    TraineeName = cr.Trainee.Name,
                                    CourseName = cr.Course.Name,
                                    Degree = cr.Degree,
                                    Status = (cr.Degree >= cr.Course.MinDegree) ? "Pass" : "Fail",
                                    Color = (cr.Degree >= cr.Course.MinDegree) ? "green" : "red"
                                }).ToList();


            return View(data);
        }




    }
}
