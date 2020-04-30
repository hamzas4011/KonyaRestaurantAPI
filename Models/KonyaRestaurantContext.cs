
using Microsoft.EntityFrameworkCore;

// her henter jeg alle models klassene(tabellene)

namespace KonyaRestaurantAPI.Models {
    public class KonyaRestaurantContext : DbContext { 
        
         public KonyaRestaurantContext(DbContextOptions<KonyaRestaurantContext>
         options):base(options){}

         public DbSet<Matrett> Matrett {get; set;}

         public DbSet<Dessert> Dessert {get; set;}

         public DbSet<Drikke> Drikke {get; set;}

    }
}
