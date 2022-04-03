using Equinox.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.Mappings
{
    public class RelativeMap : IEntityTypeConfiguration<Relative>
    {
        public void Configure(EntityTypeBuilder<Relative> builder)
        {
            builder.Property(c => c.Id)
                 .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
