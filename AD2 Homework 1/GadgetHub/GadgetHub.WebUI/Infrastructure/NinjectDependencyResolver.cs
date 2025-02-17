using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.Domain.Concrete;

namespace GadgetHub.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;

		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType); 
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}

		public void AddBindings()
		{
			/*Mock<IGadgetRepository> mock = new Mock<IGadgetRepository>();
			mock.Setup(m => m.Gadgets).Returns(new List<Gadget> {
				new Gadget{ GadgetName = "MacBook Air", GadgetBrand = "Apple", GadgetPrice = 200, GadgetDesc = "A simple no-frills work laptop.", GadgetCategory = "Computers" },
				new Gadget{ GadgetName = "Fenix 7", GadgetBrand = "Garmin", GadgetPrice = 500, GadgetDesc = "A GPS-Enable smartwatch. Charges with solar power.", GadgetCategory = "Wearables" },
				new Gadget{ GadgetName = "Beats 7", GadgetBrand = "Dr. Dre", GadgetPrice = 100, GadgetDesc = "High-Fidelity over-ear headphones.", GadgetCategory = "Audio" }
			});
			kernel.Bind<IGadgetRepository>().ToConstant(mock.Object);*/
			kernel.Bind<IGadgetRepository>().To<EFGadgetRepository>();
		}
	}
}