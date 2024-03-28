using Shop.Application.Strategies.Interfaces;

namespace Shop.Application.Strategies.Implementation
{
	public class GiftCardPaymentStrategy : IPaymentStrategy
	{
		public bool Execute()
		{
			return false;
		}
	}
}
