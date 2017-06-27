namespace RMTS.API.Models
{
	public class ProposalForm
	{
		public ProposalForm(string content)
		{
			Content = content;
		}

		public string Content { get; private set; }

	}
}