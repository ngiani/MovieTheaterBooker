using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheaterBooker.Areas.Identity.Data;


namespace MovieTheaterBooker.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<MovieTheaterBookerUser>
    {
        public void Configure(EntityTypeBuilder<MovieTheaterBookerUser> builder)
        {
            var hasher = new PasswordHasher<MovieTheaterBookerUser>();
            builder.HasData(new MovieTheaterBookerUser
            {

                Id = "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d",
                Email = "admina@localhost.com",
                NormalizedEmail = "ADMINA@LOCALHOST.COM",
                NormalizedUserName = "ADMINA@LOCALHOST.COM",
                UserName = "admina@localhost.com",
                PasswordHash = hasher.HashPassword(null, "WkPlLvQE(l^j"),
                EmailConfirmed = true,
                FirstName = "Default",
                LastName = "Admin",
                DateOfBirth = new DateOnly(12, 12, 11)

            });
        }
    }
}