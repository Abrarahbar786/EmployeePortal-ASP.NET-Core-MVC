using EmployeePortal.Data;
using EmployeePortal.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MVC
            builder.Services.AddControllersWithViews();

            // Enable Session
            builder.Services.AddSession();

            // Database
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            // Employee Service
            builder.Services.AddScoped<EmployeeService>();

            var app = builder.Build();

            // Configure HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // Enable Session
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=List}/{id?}");

            app.Run();
        }
    }
}