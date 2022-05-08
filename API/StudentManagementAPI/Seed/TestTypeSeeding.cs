using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Seed
{
    public class TestTypeSeeding : IEntityTypeConfiguration<TestType>
    {
        public void Configure(EntityTypeBuilder<TestType> builder)
        {
            builder.HasData(
                new TestType
                {
                    Id = 1,
                    TestName = "15P",
                    ScoreFactor = 1
                },
                new TestType
                {
                    Id = 2,
                    TestName = "60P",
                    ScoreFactor = 2
                },
                new TestType
                {
                    Id = 3,
                    TestName = "Học Kì",
                    ScoreFactor = 3
                }
            );
        }
    }
}
