using System.Collections.Generic;

namespace CRUDStudentApp
{
    public interface IStudentRepository
    {
        Student GetStudentById(int id);
        Student Create(int id, string firstName, string lastName, string phone);
        Student Update(Student student);
        Student Delete(Student student);

        IEnumerable<Student> GetAllStudents { get; }
    }
}