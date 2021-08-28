using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StudentDetails.Models;
using System.Collections.Generic;
using System.Linq;
using StudentDetails.Service;
using System.Text.Json.Serialization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace StudentDetails.Controllers
{
    public class HomeController : Controller
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            JSONReadWrite readWrite = new JSONReadWrite(WebHostEnvironment);
            List<StudentModel>  people = JsonSerializer.Deserialize<List<StudentModel>>(readWrite.Read());

            return View(people);
        }

        [HttpPost]
        public IActionResult Index(StudentModel personModel)
        {
            JSONReadWrite readWrite = new JSONReadWrite(WebHostEnvironment);
            List<StudentModel> people = JsonSerializer.Deserialize<List<StudentModel>>(readWrite.Read());

            StudentModel person = people.FirstOrDefault(x => x.RollNo == personModel.RollNo);

            if (person == null)
            {
                people.Add(personModel);
            }
            else
            {
                int index = people.FindIndex(x => x.RollNo == personModel.RollNo);
                people[index] = personModel;
            }

            string jSONString = JsonSerializer.Serialize(people);
            readWrite.Write(jSONString);

            return View(people);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
             
            JSONReadWrite readWrite = new JSONReadWrite(WebHostEnvironment);
            List<StudentModel> people = JsonSerializer.Deserialize<List<StudentModel>>(readWrite.Read());

            int index = people.FindIndex(x => x.RollNo == id);
            people.RemoveAt(index);

            string jSONString = JsonSerializer.Serialize(people);
            readWrite.Write(jSONString);

            return RedirectToAction("index", "Home");
        }
    }

    
}
