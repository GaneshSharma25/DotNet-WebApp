using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string firstName, string lastName, string email, string password, double salary) {

            Employee emp = new Employee(firstName, lastName, email, password, salary);
            List<Employee> empList = new List<Employee>();
            string filePath = "C:\\Users\\ganes\\Desktop\\list.txt";
            string jsonString = System.IO.File.ReadAllText(filePath);
            if (System.IO.File.Exists(filePath))
            {
                if (jsonString.Length != 0)
                {
                    empList = JsonSerializer.Deserialize<List<Employee>>(jsonString)!;
                }
            }
            else
            {
                throw new IOException("Invalid FilePath");
            }
            empList.Add(emp);
            jsonString = JsonSerializer.Serialize(empList);
            System.IO.File.WriteAllText(filePath, jsonString);
            // return RedirectToAction("EmpList");
            return View("Login");
        }

        
              
                public IActionResult EmpList()
                {
                   
                    List<Employee> empList = new List<Employee>();
                    string filePath = "C:\\Users\\ganes\\Desktop\\list.txt";
                    string jsonString = System.IO.File.ReadAllText(filePath);
                    if (System.IO.File.Exists(filePath))
                    {
                        if (jsonString.Length != 0)
                        {
                            empList = JsonSerializer.Deserialize<List<Employee>>(jsonString)!;
                        }
                    }
                    else
                    {
                        throw new IOException("Invalid FilePath");
            }
                    return View("EmpList", empList);
                }

        [HttpPost]
        public IActionResult Welcome(string email, string password)
        {
            if(email == null)
            {
                Console.WriteLine("Email is null..");
            }
            Console.WriteLine(email); 
            Console.WriteLine(password);
           
            List<Employee> empList = new List<Employee>();
            string filePath = "C:\\Users\\ganes\\Desktop\\list.txt";
            string jsonString = System.IO.File.ReadAllText(filePath);
            if (System.IO.File.Exists(filePath))
            {
                if (!string.IsNullOrEmpty(jsonString))
                {
                    empList = JsonSerializer.Deserialize<List<Employee>>(jsonString)!;
                }
            }
            else
            {
                throw new IOException("Invalid FilePath");
            }
            Console.WriteLine(empList.ToString());

            bool flag = false;
            Employee matchedEmployee = null;

            /*  empList.ForEach(delegate(Employee emp)
              {
                  if (emp.Email.Equals(email) && emp.Password.Equals(password))
                  {
                      Console.WriteLine(emp);
                      flag = true;
                      return;
                  }
              });*/
            foreach (Employee emp in empList)
            {
                if (emp.Email == email && emp.Password == password)
                {
                    flag = true;
                    matchedEmployee = emp;
                    break;
                }
            }

            if (flag)
            {
                return View("Welcome", matchedEmployee);
            }
            else
            {
                // throw new Exception("Invalid Details");
                Console.WriteLine("Invalid Details");
                return RedirectToAction("Login");
            }
           

        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}