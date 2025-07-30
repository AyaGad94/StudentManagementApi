///Represent Exception Handling and it's done using custom exceptions to handle specific error cases in the service layer.
using StudentManagementApi.Models;
using StudentManagementApi.Exceptions;
using StudentManagementApi.Data;

namespace StudentManagementApi.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StudentService> _logger;// Declares a logger to log information (for debugging, tracking events)
        //ILogger is built in interface for logging


        public StudentService(AppDbContext context, ILogger<StudentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Student> GetAll() => _context.Students.ToList();

        public Student GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                throw new NotFoundException($"Student with ID {id} not found");
            return student;
        }

        public Student Add(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FullName))//This method checks if a string is null or empty string or  contains only whitespace characters
                throw new BadRequestException("Full name is required");

            _context.Students.Add(student);
            _context.SaveChanges();

            _logger.LogInformation("Student added: {Name}", student.FullName);
            return student;
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                throw new BadRequestException($"Cannot delete. Student with ID {id} does not exist.");

            _context.Students.Remove(student);
            _context.SaveChanges();

            _logger.LogInformation("Student deleted: {Id}", id);
        }

    }
}
