using iDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Infra.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasOne(p => p.FreeLancer)
                .WithMany(f => f.FreeLanceProjects)
                .HasForeignKey(p => p.IdFreeLancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(p => p.Client)
             .WithMany(f => f.OwnedProjects)
             .HasForeignKey(p => p.IdCliente)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
