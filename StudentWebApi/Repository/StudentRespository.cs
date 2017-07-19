using System.Collections.Generic;
using System.Linq;
using StudentWebApi.Models;
using System.Data.Entity;

namespace StudentWebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields

        private StudentDbContext context;

        #endregion

        #region Constructor

        public StudentRepository(StudentDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        public Student GetStudentByID(int? studentID)
        {
            return GetStudents().FirstOrDefault(x => x.StudentID == studentID);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = GetStudentByID(studentID);
            context.Students.Remove(student);
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        #endregion
    }
}