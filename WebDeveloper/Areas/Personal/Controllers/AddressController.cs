using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;

namespace WebDeveloper.Areas.Personal.Controllers
{
    public class AddressController : Controller
    {
        //Inyeccion del repositorio en el controlador
        private readonly AddressRepository _addressRepository;
        public AddressController(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        //Fin Inyeccion del repositorio en el controlador

        // GET: Personal/Address
        public ActionResult Index()
        {
            return View(_addressRepository.GetListDto());
        }
    }
}