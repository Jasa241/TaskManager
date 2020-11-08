using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Manager.Models;
using System.IO;
using Newtonsoft.Json;

namespace Task_Manager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataFile = Server.MapPath("~/Content/Task.txt");
            if (System.IO.File.Exists(dataFile))
            {
                return View(ReadTasks(dataFile));
            }
            else { return View(); }

        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                var dataFile = Server.MapPath("~/Content/Task.txt");
                if (System.IO.File.Exists(dataFile))
                {
                    var tasks = ReadTasks(dataFile);
                    tasks.Add(task);

                    WriteTasks(dataFile,tasks);
                }
                else
                {
                    List<Task> tasks = new List<Task> { task };
                    WriteTasks(dataFile, tasks);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Task task)
        {
            var dataFile = Server.MapPath("~/Content/Task.txt");
            var tasks = ReadTasks(dataFile);

            foreach (var item in tasks)
            {
                if (item.Tittle == task.Tittle && item.Content == task.Content)
                {
                    tasks.Remove(item);
                    break;
                }
            }

            WriteTasks(dataFile, tasks);

            return RedirectToAction("Index");
        }

        public List<Task> ReadTasks(string dataFile) 
        {
            TextReader reader = new StreamReader(dataFile);
            string Json = reader.ReadToEnd().ToString();
            List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(Json);
            reader.Close();

            return tasks;
        }

        public void WriteTasks(string dataFile, List<Task> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks);
            TextWriter writer = new StreamWriter(dataFile);
            writer.WriteLine(json);
            writer.Close();
        }
    }
}