///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NovumArcanum.Aegis
{
    public class ArcanumAegisDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ArcanumAegisDbContext(DbContextOptions<ArcanumAegisDbContext> options) : base(options)
        {
        }
    }
}
