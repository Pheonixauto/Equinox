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
    public class EmployeeSkillMap : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasKey(t => new { t.EmployeeId, t.SkillId });
            builder.HasOne(o => o.Employee).WithMany(o => o.EmployeeSkills).HasForeignKey(k => k.EmployeeId);
            builder.HasOne(o => o.Skill).WithMany(o => o.EmployeeSkills).HasForeignKey(k => k.SkillId);

        }
    }
}
