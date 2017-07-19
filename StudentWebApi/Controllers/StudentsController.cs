using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using StudentWebApi.Repository;
using StudentWebApi.Models;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace StudentWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        #region Fields

        IStudentRepository studentRep;

        #endregion

        #region Constructor

        public StudentsController()
        {
            this.studentRep = new StudentRepository(new StudentDbContext());
        }

        #endregion

        #region Actions

        #region GetList

        // GET: api/Students
        public IEnumerable<Student> GetStudents()
        {
            return studentRep.GetStudents();
        }

        #endregion

        #region GetById

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = studentRep.GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student); 
        }

        #endregion

        #region Edit

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID)
            {
                return BadRequest();
            }

            studentRep.EditStudent(student);
            try
            {
                studentRep.Save();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
       
            return StatusCode(HttpStatusCode.OK); 
        }

        private bool StudentExists(int id)
        {
            Student student = studentRep.GetStudentByID(id);
            bool result = false;
            if (student != null)
            {
                result = true;
            }
            return result;
        }

        #endregion

        #region Create

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            studentRep.InsertStudent(student);
            studentRep.Save();
            return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student); 
        }

        #endregion

        #region Delete

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = studentRep.GetStudentByID(id);
            if (student == null)
            {
                return NotFound();
            }

            studentRep.DeleteStudent(id);
            studentRep.Save();
          
            return Ok(student); 
        }

        #endregion

        #endregion
    }
}
