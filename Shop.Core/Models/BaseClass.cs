namespace Shop.Core.Models
{
	public class BaseClass
	{
		public DateTime CreatedAt { get; protected set; }
		public DateTime? UpdatedAt { get; protected set; }
		public Guid? CreatedBy { get; protected set; }
		public Guid? UpdatedBy { get; protected set; }

		protected void SetBaseCreationInfo()
		{
			CreatedAt = DateTime.Now;
		}

		protected void SetBaseCreationInfo(Guid userId)
		{
			CreatedBy = userId;
			CreatedAt = DateTime.Now;
		}

		protected void UpdateBaseInfo()
		{
			UpdatedAt = DateTime.Now;
		}

		protected void UpdateBaseInfo(Guid userId)
		{
			UpdatedBy = userId;
			UpdatedAt = DateTime.Now;
		}
	}
}
