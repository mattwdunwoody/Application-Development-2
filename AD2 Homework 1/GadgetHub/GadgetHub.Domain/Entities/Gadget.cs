using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Entities
{
	public class Gadget
	{
		public int GadgetID { get; set; }
		public string GadgetName { get; set; }
		public string GadgetBrand { get; set; }
		public decimal GadgetPrice { get; set; }
		public string GadgetDesc { get; set; }
		public string GadgetCategory { get; set; }
	}
}
