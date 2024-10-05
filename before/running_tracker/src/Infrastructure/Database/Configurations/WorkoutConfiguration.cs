using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Training.Domain.Workouts;
using Modules.Users.Domain.Users;

namespace Infrastructure.Database.Configurations;

internal sealed class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(w => w.UserId)
            .IsRequired();

        builder.HasMany(w => w.Exercises)
            .WithOne()
            .HasForeignKey(e => e.WorkoutId)
            .IsRequired();
    }
}
