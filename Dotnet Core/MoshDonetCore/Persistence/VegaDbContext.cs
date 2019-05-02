using Microsoft.EntityFrameworkCore;

namespace MoshDonetCore.Persistence {
    public class VegaDbContext : DbContext {
        public VegaDbContext (DbContextOptions<VegaDbContext> options) 
            : base (options) {
                
        }
    }
}