using DB_Layer.DbOperation;
using Models_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Tier_Crud.Controllers
{
    public class HomeController : Controller
    {
        EmployeesRepository Repository = null;

        public HomeController()
        {
           Repository = new EmployeesRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                int id = Repository.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.msg = "Data saved Succesfully";
                }
                return RedirectToAction("GetAllRecord");
            }

            return View();
        }

        public ActionResult GetAllRecord()
        {
            var result = Repository.GetAllEmployees();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = Repository.GetEmployees(id);
            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var result = Repository.GetEmployees(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateEmployee(model.Id, model);
                return RedirectToAction("GetAllRecord");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Repository.DeleteEmployee(id);
            return RedirectToAction("GetAllRecord");
        }
    }
}