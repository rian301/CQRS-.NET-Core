using Adm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adm.Infra.Map
{
    public class CusomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(80);
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
