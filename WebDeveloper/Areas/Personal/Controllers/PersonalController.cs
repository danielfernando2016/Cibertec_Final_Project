using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;


namespace WebDeveloper.Areas.Personal.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        private readonly PersonRepository _personRepository;
        public PersonalController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            return View(_personRepository.GetListDto());
        }

        public PartialViewResult EmailList(int? id)
        {
            if(!id.HasValue) return null;
            return PartialView("_EmailList",_personRepository.EmailList(id.Value));
        }

        public PartialViewResult Create()
        {
            //Person persondf = new Person();
            //persondf.rowguid = Guid.NewGuid();
            //persondf.BusinessEntityID = 1;
            //if (Request.IsAjaxRequest())
            //{
            //    ViewBag.IsUpdate = false;
            //    return PartialView("_Create", persondf);
            //}
            return PartialView("_Create");
            //return PartialView("_Create", new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Create", person);
            person.rowguid = Guid.NewGuid();
            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };

            _personRepository.Add(person);
            return RedirectToAction("Index");
            //{
            //    //person.rowguid = Guid.NewGuid();
            //    _personRepository.Add(person);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return PartialView("_Create", person);
            //}
            //return PartialView("_Create");

        }



    }
}