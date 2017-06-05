namespace RMTS.Backend.Models
{
	public class SocialLinks
	{
		public int Id { get; set; }
		public string Facebook { get; set; }
		public string Twitter { get; set; }
		public string LinkedIn { get; set; }

		public SocialLinks(string facebook, string twitter, string linkedIn)
		{
			Facebook = facebook;
			Twitter = twitter;
			LinkedIn = linkedIn;
		}
	}
}