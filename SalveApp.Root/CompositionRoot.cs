using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalveApp.BusinessLogic.Services;
using SalveApp.BusinessLogic.Services.Impl;
using SalveApp.DAL;
using SalveApp.DAL.Repositories;
using SalveApp.DAL.Repositories.Impl;

namespace SalveApp.Root
{
    public static class CompositionRoot
    {
        public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
        {
            services.AddTransient<DbContext, EFContext>();

            services.AddDbContext<EFContext>(opts => opts.UseInMemoryDatabase("database"));

            services.AddTransient(typeof(IRepository<,>), typeof(BaseRepository<,>));
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient(typeof(IService<,>), typeof(BaseService<,>));
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
