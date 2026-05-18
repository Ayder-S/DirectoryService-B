using DS.Domain.Entities;
using DS.Domain.Relation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgresql.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    { 
        builder.ToTable("department_locations");
        
        builder.HasKey(dl => dl.DepartmentLocationId)
            .HasName("pk_department_locations");

        builder.Property(dl => dl.DepartmentLocationId)
            .HasColumnName("id");

        builder.Property(dl => dl.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dl => dl.LocationId)
            .HasColumnName("location_id")
            .IsRequired();

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(dl => dl.DepartmentId)
            .HasConstraintName("fk_department_locations_department_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .HasConstraintName("fk_department_locations_location_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasIndex(dl => new { dl.DepartmentId, dl.LocationId })
            .IsUnique()
            .HasDatabaseName("ix_department_locations_department_id_location_id");

    }
}