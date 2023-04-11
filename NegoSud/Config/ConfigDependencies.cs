using Buisness;
using DataAccess.dbContext;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Service;

namespace NegoSud.Config
{
    public static class ConfigDependencies
    {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IRepository<Family>, FamilyRepository>();

            services.AddScoped<IFournisseurService, FournisseurService>();
            services.AddScoped<IRepository<Fournisseur>, FournisseurRepository>();
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepository<Product>, ProductRepository>();

            services.AddScoped<IPanierService, PanierService>();
            services.AddScoped<IRepository<Panier>, PanierRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<NegoSudDBContext>();
            services.AddDbContext<NegoSudDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("wmgDb")));
        }
    }
}
