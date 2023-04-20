///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NovumArcanum.Aegis
{
    public class ArcanumAegisDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private IConfiguration Configuration { get; }

        public ArcanumAegisDbContext(IConfiguration configuration, DbContextOptions<ArcanumAegisDbContext> options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedRoles(modelBuilder);

            var adminName = Configuration["SuperAdmin:UserName"];
            var adminPass = Configuration["SuperAdmin:Password"];
            var userId = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = userId,
                    UserName = adminName,
                    NormalizedUserName = adminName.ToUpper(),
                    Email = "scottfalboart@gmail.com",
                    NormalizedEmail = "scottfalboart@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, adminPass),
                    SecurityStamp = string.Empty
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = WizardRole.Id.MagusArchitect,
                    UserId = userId,
                });
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = WizardRole.Id.MagusArchitect,
                    Name = WizardRole.MagusArchitect,
                    NormalizedName = WizardRole.MagusArchitect.ToUpper(),
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = WizardRole.Id.MagusPrimus,
                    Name = WizardRole.MagusPrimus,
                    NormalizedName = WizardRole.MagusPrimus.ToUpper(),
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = WizardRole.Id.MagusMagister,
                    Name = WizardRole.MagusMagister,
                    NormalizedName = WizardRole.MagusMagister.ToUpper(),
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = WizardRole.Id.MagusAdeptus,
                    Name = WizardRole.MagusAdeptus,
                    NormalizedName = WizardRole.MagusAdeptus.ToUpper(),
                });
        }
    }
}