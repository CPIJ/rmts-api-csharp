using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RMTS.Backend.Data.Mapping;
using RMTS.Backend.Models;

namespace RMTS.Backend.Data
{
    public class RmtsContext : DbContext
    {
        public DbSet<Action> Actions { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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