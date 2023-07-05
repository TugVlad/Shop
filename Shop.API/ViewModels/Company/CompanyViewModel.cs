﻿namespace Shop.API.ViewModels.Company
{
	public class CompanyViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<CompanyReviewViewModel> Reviews { get; set; }
	}
}
