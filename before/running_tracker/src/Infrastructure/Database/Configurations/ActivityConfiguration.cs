using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Training.Domain.Activities;
using Modules.Training.Domain.Workouts;
using Modules.Users.Domain.Users;

namespace Infrastructure.Database.Configurations;

internal sealed class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(e => e.Distance)
            .HasConversion(
                distance => distance.Meters,
                meters => new Distance(meters));

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.UserId);

        builder.HasOne<Workout>()
            .WithMany()
            .HasForeignKey(a => a.WorkoutId);
    }
}
