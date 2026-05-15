using DS.Domain.Relation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgresql.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    { 
        builder.ToTable("department_locations");
        
        builder.HasKey(dl => dl.Id)
            .HasName("pk_department_locations");

        builder.Property(dl => dl.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dl => dl.LocationId)
            .HasColumnName("location_id")
            .IsRequired();

        builder.HasOne(d => d.Department)
            .WithMany(d => d.Locations)
            .HasForeignKey(d => d.DepartmentId)
            .HasConstraintName("fk_department_locations_department_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasOne(d => d.Location)
            .WithMany(d => d.Departments)
            .HasForeignKey(d => d.LocationId)
            .HasConstraintName("fk_department_locations_location_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasIndex(dl => new { dl.DepartmentId, dl.LocationId })
            .IsUnique()
            .HasDatabaseName("ix_department_locations_department_id_location_id");

    }
}