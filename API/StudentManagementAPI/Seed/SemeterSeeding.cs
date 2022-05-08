using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementAPI.Models;
using System;

namespace StudentManagementAPI.Seed
{
    public class SemeterSeeding : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasData(
                new Semester
                {
                    Id = 1,
                    Name = "Học Kì 1",
                    TimeStart = new DateTime(2022, 09, 04).ToString(),
                    TimeEnd = new DateTime(2023, 02, 15).ToString(),
                },
               new Semester
               {
                   Id = 2,
                   Name = "Học Kì 2",
                   TimeStart = new DateTime(2023, 02, 20).ToString(),
                   TimeEnd = new DateTime(2023, 06, 05).ToString(),
               }
            );
        }
    }
}
