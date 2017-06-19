using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RMTS.Backend.Data.Mapping;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data
{
	public class RmtsContext : DbContext
	{
		//private const string CONNECTION_STRING = "data source=CP; initial catalog=RMTS_DB; integrated security=SSPI;";
	    private const string CONNECTION_STRING =
            "Server=10.213.112.114;Database=RMTS;User Id=RMTS;Password=Habibke01;Pooling=false;";
		//public const string CONNECTION_STRING = "Server=84.24.62.136;Database=RMTS;User Id=RMTS;Password=Habibke01;Pooling=false;";


        public DbSet<Action> Actions { get; set; }
		public DbSet<ActionType> ActionTypes { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Prospect> Prospects { get; set; }
		public DbSet<SocialLinks> SocialLinks { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<User> Users { get; set; }

		// Hier wordt de connectiestring gezet.
	    public RmtsContext() : base(CONNECTION_STRING)
	    {
	        var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
	    }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ActionMapping());
			modelBuilder.Configurations.Add(new ActionTypeMapping());
			modelBuilder.Configurations.Add(new ProspectMapping());
			modelBuilder.Configurations.Add(new StatusMapping());
			modelBuilder.Configurations.Add(new UserMapping());

			// Zorgt ervoor dat de tabellen niet in meervoud zijn.
			// Actions -> Action, Prospects -> Prospect etc.
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			base.OnModelCreating(modelBuilder);
		}
	}
}