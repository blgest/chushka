using Microsoft.AspNetCore.Identity;

namespace Chushka.Data.Models
{
    public class ChushkaUser:IdentityUser<string>
    {
        public string FullName { get; set; }
    }
}
