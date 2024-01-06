using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace MehmetUtkuGunduz.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
