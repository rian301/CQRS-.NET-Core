using Adm.Domain.Models;
using Adm.Infra.CrossCutting.Identity;
using Adm.Infra.CrossCutting.Identity.Models;
using Adm.Infra.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adm.Infra.Context
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CusomerMap());
        }
    }
}
