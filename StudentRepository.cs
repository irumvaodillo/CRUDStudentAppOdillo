using System.Collections.Generic;
using System.Linq;

namespace CRUDStudentApp
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        
        
        public Student GetStudentById(int id)  
        /*
         * var obj = new StudentRepository(context)
         * obj.GetStudentById(23242545466)
         */
        {
            return _studentContext.Students.FirstOrDefault(e => e.Id == id);
        }

        public Student Create(int id, string firstName, string lastName, string phone)
        {
            var result = _studentContext.Add(new Student
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone
            });
            _studentContext.SaveChanges();
            return result.Entity;
        }

        public Student Update(Student student)
        {
            var result = _studentContext.Update(student);
            _studentContext.SaveChanges();
            return result.Entity;
        }
        
        // deleting student record
        public Student Delete(Student student)
        {
            var result = _studentContext.Remove(student);
            _studentContext.SaveChanges(); 
            return result.Entity;
        }

        public IEnumerable<Student> GetAllStudents
        {
            get { return _studentContext.Students; }
        }
    }
}