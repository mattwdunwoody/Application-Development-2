using System.Collections.Generic;
using GadgetHub.Domain.Entities;

namespace GadgetHub.WebUI.Models
{
	public class GadgetsListViewModel
	{
		public IEnumerable<Gadget> Gadgets { get; set; }
		public PagingInfo PagingInfo { get; set; }

		public string CurrentCategory { get; set; }
	}
}