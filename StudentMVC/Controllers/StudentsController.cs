using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using StudentMVC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace StudentMVC.Controllers
{
    public class StudentsController : Controller
    {
        #region Fields

        private string baseUri = "http://localhost:7739/api/students";
        HttpClient client;

        #endregion

        #region Constructor

        public StudentsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }

        #endregion

        #region GetList

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMsg = await client.GetAsync(baseUri);
            if (responseMsg.IsSuccessStatusCode)
            {
                string responseData = responseMsg.Content.ReadAsStringAsync().Result;
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(responseData);
                return View(students);
            }
            return View("Error");
        }

        #endregion

        #region GetByID

        public async Task<ActionResult> Details(int? id)
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                Student student = await response.Content.ReadAsAsync<Student>();
                return View(student);
            }
            return View("Error");
        }

        #endregion

        #region AddNew

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            HttpResponseMessage responseMsg = await client.PostAsJsonAsync(baseUri, student);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        #endregion

        #region Edit

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMsg = await client.GetAsync(baseUri + "/" + id.ToString());
            if (responseMsg.IsSuccessStatusCode)
            {
                string responseData = responseMsg.Content.ReadAsStringAsync().Result;
                Student student = JsonConvert.DeserializeObject<Student>(responseData);
                return View(student);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            HttpResponseMessage responseMsg = await client.PutAsJsonAsync(baseUri + "/" + id, student);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        #endregion

        #region Delete

        public async Task<ActionResult> Delete(int? id)
        {
            HttpResponseMessage responseMsg = await client.GetAsync(baseUri + "/" + id.ToString());
            if (responseMsg.IsSuccessStatusCode)
            {
                string responseData = responseMsg.Content.ReadAsStringAsync().Result;
                Student student = JsonConvert.DeserializeObject<Student>(responseData);
                return View(student);
            }
            return View("Error");
        }

        //PUT
        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int id, Student student)
        {
            HttpResponseMessage responseMsg = await client.DeleteAsync(baseUri + "/" + id);
            if (responseMsg.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        #endregion
    }
}