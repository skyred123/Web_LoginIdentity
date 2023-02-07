using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_LoginIdentity.Areas.Identity.Data;

namespace Web_LoginIdentity.Data;

public class Web_LoginIdentityDBContext : IdentityDbContext<ApplicationUser>
{
    public Web_LoginIdentityDBContext(DbContextOptions<Web_LoginIdentityDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
