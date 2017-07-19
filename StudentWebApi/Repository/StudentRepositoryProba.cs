using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentWebApi.Models;

namespace StudentWebApi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private StudentDbContext db = new StudentDbContext();

        public IEnumerable<Student> GetList()
        {
            
                return db.Students;
            
        }

        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Student FindById(int id)
        {
           
            return db.Students.Find(id);
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}