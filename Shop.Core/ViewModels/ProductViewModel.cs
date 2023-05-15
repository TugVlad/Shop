using Shop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
	public class ProductViewModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public ProductTypeEnum Type { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }
	}
}
