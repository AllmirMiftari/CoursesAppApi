using Microsoft.AspNetCore.Identity;

namespace OnlineCoursesApi.Models
{
    public class User: IdentityUser
    {

        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}