namespace Shop.API.ViewModels.Account
{
	public class CreateAccountViewModel
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string? PhoneNumber { get; set; }
		public string Address { get; set; }
	}
}
