using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetRepository gadgetRepository;

        public GadgetController(IGadgetRepository gadgetRepository)
        {
            this.gadgetRepository = gadgetRepository;
        }

        public int PageSize = 4;

        public ViewResult List(string category, int page = 1)
        {
            GadgetsListViewModel model = new GadgetsListViewModel
            {
                Gadgets = gadgetRepository.Gadgets.Where(g => category == null || g.GadgetCategory == category).OrderBy(g => g.GadgetID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,

                    //TotalItems = gadgetRepository.Gadgets.Count()

                    TotalItems = category == null ? gadgetRepository.Gadgets.Count() : gadgetRepository.Gadgets.Where(e => e.GadgetCategory == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int gadgetId)
        {
            Gadget _gadget = gadgetRepository.Gadgets.FirstOrDefault(g => g.GadgetID == gadgetId);

            if (_gadget != null)
            {
                return File(_gadget.ImageData, _gadget.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}