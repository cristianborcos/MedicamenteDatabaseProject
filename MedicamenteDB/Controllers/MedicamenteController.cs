

using MedicamenteDB;

using MedicamenteDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicamenteDB
{
    public class MedicamenteController : Controller
    {
        
        public ActionResult List()
        {
            MedicamenteRepository r = new MedicamenteRepository();

            List<MedicamenteModel> myMedicamente = r.GetAll();

            return View(myMedicamente);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MedicamenteModel medicament)
        {
            
            MedicamenteRepository r = new MedicamenteRepository();

            r.Add(medicament);

            return View("SuccesfulAdd");
        }

       
        public ActionResult Delete(int id)
        {
            MedicamenteRepository r = new MedicamenteRepository();

            r.Delete(id);
            List<MedicamenteModel> myMedicamente = r.GetAll();



            return View("List", myMedicamente);

        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel searchData)
        {
            MedicamenteRepository r = new MedicamenteRepository();

            List<MedicamenteModel> foundMedicamente = r.Search(searchData.Text);

            return View("List", foundMedicamente);
        }

      
    }
}