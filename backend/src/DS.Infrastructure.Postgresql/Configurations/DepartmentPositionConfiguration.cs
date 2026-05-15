using DS.Domain.Relation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Infrastructure.Postgresql.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    { 
        builder.ToTable("department_positions");
        
        builder.HasKey(dp => dp.Id)
            .HasName("pk_department_positions");

        builder.Property(dp => dp.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        
        builder.Property(dp => dp.PositionId)
            .HasColumnName("position_id")
            .IsRequired();

        builder.HasOne(dp => dp.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(dp => dp.DepartmentId)
            .HasConstraintName("fk_department_positions_department_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasOne(dp => dp.Position)
            .WithMany(p => p.Departments)
            .HasForeignKey(dp => dp.PositionId)
            .HasConstraintName("fk_department_positions_position_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder.HasIndex(dp => new { dp.DepartmentId, dp.PositionId })
            .IsUnique()
            .HasDatabaseName("ix_department_positions_department_id_position_id");
    }
}