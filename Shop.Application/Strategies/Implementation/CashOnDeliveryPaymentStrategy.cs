using Shop.Application.Strategies.Interfaces;

namespace Shop.Application.Strategies.Implementation
{
	public class CashOnDeliveryPaymentStrategy : IPaymentStrategy
	{
		public bool Execute()
		{
			return false;
		}
	}
}
