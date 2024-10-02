﻿using Microsoft.AspNetCore.Mvc;
using PropertySales.Data;
using PropertySales.Models;
using PropertySales.Models.Domain;
using PropertySales.Models.ViewModels;

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
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Login");
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
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}
