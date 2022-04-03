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
    public class EmployeeLearningMap : IEntityTypeConfiguration<EmployeeLearning>
    {
        public void Configure(EntityTypeBuilder<EmployeeLearning> builder)
        {
            builder.HasKey(t => new { t.EmployeeId, t.LearningId });
            builder.HasOne(o => o.Employee).WithMany(o => o.EmployeeLearnings).HasForeignKey(k => k.EmployeeId);
            builder.HasOne(o => o.Learning).WithMany(o => o.EmployeeLearnings).HasForeignKey(k => k.LearningId);
        }
    }
}
