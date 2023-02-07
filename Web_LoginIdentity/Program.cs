using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web_LoginIdentity.Areas.Identity.Data;
using Web_LoginIdentity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Web_LoginIdentityDBContextConnection") ?? throw new InvalidOperationException("Connection string 'Web_LoginIdentityDBContextConnection' not found.");

builder.Services.AddDbContext<Web_LoginIdentityDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
                                                                    options.SignIn.RequireConfirmedAccount = false;
                                                                    options.Password.RequireUppercase = false;
                                                                    options.Password.RequireLowercase= false;
                                                                }
                                                    ).AddEntityFrameworkStores<Web_LoginIdentityDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    }
                 );
app.Run();
