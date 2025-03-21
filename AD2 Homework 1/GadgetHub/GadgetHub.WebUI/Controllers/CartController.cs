using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGadgetRepository repository;

        public CartController(IGadgetRepository repo)
        { 
            repository = repo;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int gadgetID, string returnUrl)
        { 
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.GadgetID == gadgetID);

            if (gadget != null)
            {
                cart.AddItem(gadget, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

		public RedirectToRouteResult RemoveFromCart(Cart cart, int gadgetID, string returnUrl)
		{
			Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.GadgetID == gadgetID);

			if (gadget != null)
			{
				cart.RemoveLine(gadget);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}