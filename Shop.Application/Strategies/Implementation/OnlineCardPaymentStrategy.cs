using Shop.Application.Strategies.Interfaces;

namespace Shop.Application.Strategies.Implementation
{
	public class OnlineCardPaymentStrategy : IPaymentStrategy
	{
		public bool Execute()
		{
			return false;
		}
	}
}
