using System;
using System.Linq;

namespace CRUDStudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new StudentContext())
            {
                context.Database.EnsureCreated();
                
                var repo = new StudentRepository(context);
                
//                1. Create new Student record
//                
                Console.WriteLine("Enter Student Information");
                
                 Console.WriteLine("Id:");
                var id = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("First Name:");
                 var firstName = Console.ReadLine();
                
                Console.WriteLine("Last Name:");
                var lastName = Console.ReadLine();
                
                Console.WriteLine("Phone:");
                var phone = Console.ReadLine();
                
                var student = repo.Create(id, firstName,lastName,phone);
                
                Console.WriteLine("Student Identified by Id "+ student.Id +" has been Added Successfully!");
                
                // 2. get Individual record
                Console.WriteLine("Enter Id of the record to retrieve");
                var idToRetrieve = Convert.ToInt32(Console.ReadLine());
                var getStudent = repo.GetStudentById(idToRetrieve);
                Console.WriteLine($"Record details: {getStudent.FirstName} {getStudent.LastName}");
                
                //2. Update record
                Console.WriteLine("Enter Id of the record to Update");
                var idToUpdate = Convert.ToInt32(Console.ReadLine());
                var studentUpdate = repo.GetStudentById(idToUpdate);
                if (studentUpdate != null)
                {
                    studentUpdate.FirstName = "Some new First Name";
                    studentUpdate.LastName= "Some new LastName";
                    studentUpdate.Phone = "Some new Phone";
                    repo.Update(studentUpdate);
                }
                
                // 3. Delete a record
                Console.WriteLine("Enter Id of the record to delete");
                var idToDelete = Convert.ToInt32(Console.ReadLine());
                var studentDelete = repo.GetStudentById(idToDelete);
                repo.Delete(studentDelete);

                //5. List all records
                Console.WriteLine("All the students");
                var students = repo.GetAllStudents.ToList();
                Console.WriteLine( "ID| First Name| Last Name | Phone");
                Console.WriteLine("=====================================");

                foreach (var stud in students)
                {
                    Console.WriteLine(stud.Id + " |"+ stud.FirstName+" |"+ stud.LastName+" |"+stud.Phone);
   
                }
            }
            // var context = new StudentContext("Data Source=StudentDB.db");
           
        }
    }
}