using MediQuick.Data;
using MediQuick.Data.Contracts;
using MediQuick.Data.Repositories;
using MediQuick.Services;
using MediQuick.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MediQuick.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("MediQuickConnectionString");
            builder.Services.AddDbContext<MediQuickDbContext>(x => x.UseSqlServer(connectionString));
            builder.Services.AddScoped<IMediQuickDbContext, MediQuickDbContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAmbulanceRepository, AmbulanceRepository>();
            builder.Services.AddScoped<ICardiogramRepository, CardiogramRepository>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IAmbulanceService, AmbulanceService>();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}