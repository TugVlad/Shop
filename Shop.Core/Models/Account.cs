namespace Shop.Core.Models
{
	public class Account : BaseClass
	{
		public Account(string userName, string identityId, string email, string phoneNumber, string address)
		{
			SetBaseCreationInfo();
			Id = new Guid();
			IdentityUserId = identityId;
			UserName = userName;
			Email = email;
			PhoneNumber = phoneNumber;
			Address = address;
			Cart = new Cart(Id);
		}

        public Account() {}

        public Guid Id { get; private set; }
		public string IdentityUserId { get; private set; }
		public string UserName { get; private set; }
		public string Email { get; private set; }
		public string? PhoneNumber { get; private set; }
		public string Address { get; private set; }
		public bool IsAdmin { get; private set; }
		public List<Order> Orders { get; private set; } = new();
		public Cart Cart { get; private set; }
	}
}
