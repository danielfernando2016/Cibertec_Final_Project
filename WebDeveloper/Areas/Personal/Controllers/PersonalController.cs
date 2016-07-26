using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [OutputCache(Duration = 0)]
        public ActionResult Index()
        {
            return View(_personRepository.GetListDto());
        }

        public PartialViewResult EmailList(int? id)
        {
            if (!id.HasValue) return null;
            return PartialView("_EmailList", _personRepository.EmailList(id.Value));
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create");
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
            return new HttpStatusCodeResult(HttpStatusCode.OK); //RedirectToAction("Index");
        }

        [OutputCache(Duration =0)]
        public ActionResult Edit(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return PartialView("_Edit", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 0)]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid) return PartialView("_Edit", person);
            _personRepository.Update(person);
            return RedirectToRoute("Personal_default");
        }

    }
}