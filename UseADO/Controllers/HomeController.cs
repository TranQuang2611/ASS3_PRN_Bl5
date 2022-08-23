using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UseADO.DataAccess;
using UseADO.Modals;

namespace UseADO.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Show()
        {
            List<Customer> data = new List<Customer>();
            List<Customer> list = new List<Customer>();
            Customer customer = new Customer();
            data = CustomerDAO.GetAllCustomer();
            list = CustomerDAO.GetAllCustomer();
            ViewBag.cus = customer;
            ViewBag.data = data;
            return View(list);
        }

        [HttpPost]
        public IActionResult Show(string code, string name, string filterName, string update, int gender, string address, string dob)
        {
            List<Customer> list = new List<Customer>();
            list = CustomerDAO.GetAllCustomer();
            
            Customer customer = new Customer();
            customer = CustomerDAO.GetCustomerById(code);

            List<Customer> data = new List<Customer>();
            if(code != "0")
            {               
                if (!string.IsNullOrEmpty(update))
                {
                    int k = CustomerDAO.updateCus(code, name, address, dob, gender);
                    customer = CustomerDAO.GetCustomerById(code);
                }
                data = CustomerDAO.GetListCustomerById(code);
            }
            else
            {
                data = CustomerDAO.GetAllCustomer();
            }

            if (!string.IsNullOrEmpty(filterName))
            {
                data = CustomerDAO.GetListCustomerByname(name);
            }
            
            ViewBag.cus = customer;
            ViewBag.data = data;
            ViewBag.code = code;
            return View(list);
        }
    }
}
