﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaGroup.Data;
using PizzaGroup.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace PizzaGroup.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index(int PizzaId)
        {
            var defaultPizzas = _context.Pizzas.Select(p => p.PizzaID == PizzaId);

            return View(defaultPizzas);
        }

        public IActionResult ViewOrder() {
            List<Order> pOrder = _context.Orders.ToList();
            return View(pOrder);
        }
        public IActionResult Edit(int Id)
        {
            var eInfo = _context.Orders.Find(Id);
            return View(eInfo);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("ViewOrder");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Pizza pizza, int id) {
            //Use this to add to Orders in the Database

            Order? oTemp = _context.Orders.Where(o => o.CustomerID == id).FirstOrDefault();

            if (oTemp == null)
            {
                //o.CustomerID =;
                //o.EmployeeID = 1;
                //o.OrderStatus = "NOT YET";
                oTemp.Pizzas.Add(pizza);

            }

            else oTemp.Pizzas.Add(pizza);
            _context.Orders.Add(o);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");

        }



    }
}
