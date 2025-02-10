using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetRepository gadgetRepository;

        public GadgetController(IGadgetRepository gadgetRepository)
        {
            this.gadgetRepository = gadgetRepository;
        }

        public ViewResult List()
        {
            return View(gadgetRepository.Gadgets);
        }
    }
}