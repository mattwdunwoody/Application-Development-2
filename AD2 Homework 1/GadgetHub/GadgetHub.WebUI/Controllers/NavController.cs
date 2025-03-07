using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGadgetRepository repository;

        public NavController(IGadgetRepository repo)
        { 
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Gadgets.Select(x => x.GadgetCategory).Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}