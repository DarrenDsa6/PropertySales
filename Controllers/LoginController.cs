using Microsoft.AspNetCore.Mvc;
using PropertySales.Data;
using PropertySales.Models;
using PropertySales.Models.ViewModels;
using PropertySales.Models.Domain;

namespace PropertySales.Controllers
{
    public class LoginController : Controller
    {
        private readonly PropertySalesDbContext _context;

        public LoginController(PropertySalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View(new UserLoginValidation());
        }

        [HttpPost]
        public IActionResult UserLogin(UserLoginValidation model, string userType)
        {
            if (ModelState.IsValid)
            {
                if (userType == "Customer")
                {
                    var user = _context.Users
                        .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                    if (user != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    var user = _context.Brokers
                        .FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                    if (user != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model); // Return the view with the model to show validation messages
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(AddUser model, string UserType)
        {
            if (ModelState.IsValid)
            {
                if (UserType == "Customer")
                {
                    var user = new User
                    {
                        Name = model.Name,
                        UserName = model.UserName,
                        Password = model.Password,
                        ContactNumber = model.ContactNumber,
                        Address = model.Address,
                        Pincode = model.Pincode,
                        AdhaarCard = model.AdhaarCard
                    };
                    _context.Users.Add(user);
                }
                else
                {
                    var broker = new Broker
                    {
                        Name = model.Name,
                        UserName = model.UserName,
                        Password = model.Password,
                        ContactNumber = model.ContactNumber,
                        Address = model.Address,
                        Pincode = model.Pincode,
                        AdhaarCard = model.AdhaarCard
                    };
                    _context.Brokers.Add(broker);
                }
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
