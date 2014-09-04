using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnockoutPanelsExample.Models {

    public class PlayerContext : DbContext {

        public PlayerContext()
            : base("PlayerContextDbString") {
            Database.SetInitializer<PlayerContext>(new CreateDatabaseIfNotExists<PlayerContext>());
        }

        public DbSet<Player> Players { get; set; }
    }
}