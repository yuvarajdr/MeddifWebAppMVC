using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.Service
{
    public class JSONReadWrite
    {

        public JSONReadWrite(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public string Read()
        {
            string jsonResult;
            string path = Path.Combine(WebHostEnvironment.WebRootPath, "data", "Students.json");

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }

        public void Write(string jSONString)
        {

            string path = Path.Combine(WebHostEnvironment.WebRootPath, "data", "Students.json");

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jSONString);
            }
        }
    }
}
