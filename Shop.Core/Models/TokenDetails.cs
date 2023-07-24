namespace Shop.Core.Models
{
	public class TokenDetails
	{
        public TokenDetails() {}

        public TokenDetails(string signingKey, string issuer, string audience)
        {
            SigningKey = signingKey;
            Issuer = issuer;
            Audience = audience;
        }

        public string SigningKey { get; private set; }
		public string Issuer { get; private set; }
		public string Audience { get; private set; }
	}
}
