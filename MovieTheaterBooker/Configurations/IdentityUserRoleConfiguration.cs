using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                new IdentityUserRole<string>
                {
                    RoleId = "59756ceb-3b8c-4467-9af5-0fed41b388cc",
                    UserId = "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d"
                }
            );
        }
    }
}