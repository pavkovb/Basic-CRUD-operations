using System.Collections.Generic;
using StudentWebApi.Models;

namespace StudentWebApi.Repository
{
    interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int? studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void EditStudent(Student student);
        void Save();
    }
}
