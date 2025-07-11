using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieTheaterBooker.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "59756ceb-3b8c-4467-9af5-0fed41b388cc",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b6aed041-08b2-4530-a41c-ccdaecffeb5a",
                    Name = "User",
                    NormalizedName = "USER"
                }
                );
        }
    }
}
