namespace Shop.Core.Models
{
	public class Account : BaseClass
	{
		public Account(string userName, string email, string password, string phoneNumber, string address)
		{
			SetBaseCreationInfo();
			Id = new Guid();
			UserName = userName;
			Email = email;
			EncryptPassword(password);
			PhoneNumber = phoneNumber;
			Address = address;
		}

		public Guid Id { get; private set; }
		public string UserName { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public string? PhoneNumber { get; private set; }
		public string Address { get; private set; }
		public List<Order> Orders { get; private set; } = new();

		private void EncryptPassword(string password)
		{
			//TODO Encrypt password
			Password = password;
		}

		public bool CheckPassword(string password, string encryptedPassword)
		{
			return password.Equals(encryptedPassword);
		}
	}
}
