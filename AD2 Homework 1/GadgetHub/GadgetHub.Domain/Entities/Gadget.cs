using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GadgetHub.Domain.Entities
{
	public class Gadget
	{
		[HiddenInput (DisplayValue = false)]
		public int GadgetID { get; set; }

		[Display(Name = "Name")]
		[Required(ErrorMessage = "Please enter a product name")]
		public string GadgetName { get; set; }

		[Display(Name = "Brand")]
		[Required(ErrorMessage = "Please enter a Brand")]
		public string GadgetBrand { get; set; }

		[Display(Name = "Price")]
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
		public decimal GadgetPrice { get; set; }

		[DataType(DataType.MultilineText)]
		[Display(Name = "Description")]
		[Required(ErrorMessage = "Please enter a description")]
		public string GadgetDesc { get; set; }

		[Display(Name = "Category")]
		[Required(ErrorMessage = "Please enter a category")]
		public string GadgetCategory { get; set; }
	}
}
