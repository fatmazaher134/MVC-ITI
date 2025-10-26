using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcLab1.Models
{
    public class ITIDBContext : IdentityDbContext<ApplicationIdentity>
    {
        public DbSet<Instractore> Instractores { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        public ITIDBContext (DbContextOptions<ITIDBContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ABVC8PJ;Initial Catalog=ITIDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrsResult>()
                        .HasKey(cr => new { cr.TraineeId, cr.CourseId });

           
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "Software Development", Manager = "Ahmed Ali" },
                new Department() { Id = 2, Name = "Operating Systems", Manager = "Mona Saleh" }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Name = "C#", Degree = 100, MinDegree = 60, DepartmentId = 1 },
                new Course() { Id = 2, Name = "MVC", Degree = 100, MinDegree = 60, DepartmentId = 1 },
                new Course() { Id = 3, Name = "Angular", Degree = 100, MinDegree = 60, DepartmentId = 2 }
            );

            modelBuilder.Entity<Instractore>().HasData(
                new Instractore() { Id = 1, Name = "Fatma", Salary = 15000,imageUrl = "Images/girl.jpg", Address = "Cairo", DepartmentId = 1 , CourseId = 2},
                new Instractore() { Id = 2, Name = "Hassan",Salary = 16000, imageUrl = "Images/man.jpg", Address = "Alex", DepartmentId = 2 , CourseId = 1 },
                new Instractore() { Id = 3, Name = "Salma", Salary = 13000, imageUrl = "Images/girl.jpg", Address = "Giza", DepartmentId = 1 , CourseId = 3 },
                new Instractore() { Id = 4, Name = "Ahmed", Salary = 12000, imageUrl = "Images/man.jpg", Address = "Assuit", DepartmentId = 1, CourseId = 2 },
                new Instractore() { Id = 5, Name = "Naira", Salary = 10000, imageUrl = "Images/girl.jpg", Address = "Giza", DepartmentId = 2, CourseId = 1 }

                );

            
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee() { Id = 1, Name = "Omar", imageUrl= "Images/man.jpg", Address = "Cairo", grade = 1, DepartmentId = 1 },
                new Trainee() { Id = 2, Name = "Fatma", imageUrl = "Images/girl.jpg", Address = "Mansoura", grade = 2, DepartmentId = 2 },
                new Trainee() { Id = 3, Name = "Youssef", imageUrl = "Images/man.jpg", Address = "Tanta", grade = 1, DepartmentId = 1 }
            );

            
            modelBuilder.Entity<CrsResult>().HasData(
                new CrsResult() {  Degree = 95, CourseId = 1, TraineeId = 1 }, 
                new CrsResult() {  Degree = 85, CourseId = 2, TraineeId = 1 }, 
                new CrsResult() {  Degree = 92, CourseId = 3, TraineeId = 2 }, 
                new CrsResult() {  Degree = 88, CourseId = 1, TraineeId = 3 }  
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
