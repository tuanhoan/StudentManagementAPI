using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.FullName).HasMaxLength(255);
            builder.Property(x => x.Birthday).IsRequired();
            builder.HasOne<Teachers>(x => x.TeacherNavigation)
                .WithOne(x => x.AppUser)
                .HasForeignKey<Teachers>(x => x.AppUserId);
            builder.HasOne<Students>(x => x.StudentNavigation)
                .WithOne(x => x.AppUser)
                .HasForeignKey<Students>(x => x.AppUserId);
        }
    }
}
