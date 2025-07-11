using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MovieTheaterBooker.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MovieTheaterBookerUser class
public class MovieTheaterBookerUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateOnly DateOfBirth {  get; set; }
}

