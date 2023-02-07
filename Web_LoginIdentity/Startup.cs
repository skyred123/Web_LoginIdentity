using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
namespace Web_LoginIdentity
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }
        //sử dụng phương thức này để thêm dịch vụ vào vùng chứa
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        //sử dụng phương pháp này để định cấu hình đường dẫn yêu cầu http
        public void Configure(IApplicationBuilder app, IWebHostEnvironment wed)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (wed.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
               
        }
    }
}
