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
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(c => c.Name)
               .HasColumnType("nvarchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.HasData(new Department { Id= new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), Name="Hành Chính Nhân Sự"});
        }
    }
}
