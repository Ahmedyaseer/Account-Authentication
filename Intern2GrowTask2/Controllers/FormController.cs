using Intern2GrowTask2.Data;
using Intern2GrowTask2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intern2GrowTask2.Controllers
{
    public class FormController : Controller
    {
        UserDb db = new UserDb();

        // show main view 
        public IActionResult Index()
        {
            return View();
        }

        // show form to create a new account 
        public IActionResult signup()
        {
            return View();
        }


        // get data from user and make a backend validation 
        [HttpPost]
        public IActionResult signup (User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
            return RedirectToAction("index");
            }
            else
            {
                return View(user);
            }
        }

        // view form to user asking him to fill username and password
        public IActionResult login()
        {
            return View();
        }


        // get username and password
        // vaildate if the user is already exist 
        // if true redirectToAction with the squence
        // if flase (user not exist show not found error)
        [HttpPost]
        public IActionResult login(string username, string password)
        {
            User existUser = (from u in db.users
                             where u.UserName ==username && u.Password == password
                             select u).FirstOrDefault();

            if(existUser != null)
            {
                return RedirectToAction( "userin" , existUser);
            }
            else
            {
                return NotFound();
            }
        }

        // show profile with data from login action
        public IActionResult userin(User user)
        {
            return View(user);
        }
    }
}
