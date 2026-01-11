using Tabletopgenerator.Repository.Implementation;
using Tabletopgenerator.Repository.Interface;
using Tabletopgenerator.Repository.Interface.Login;

namespace Tabletopgenerator.Models
{
    public class ServiceCollector
    {
        public void AddServices(IServiceCollection service)
        {
            //service.AddScoped
            service.AddScoped<IFirstNameRepository,FirstNameRepository>()
                   .AddScoped<INameGeneratorRepository, NameGeneratorRepository>()
                   .AddScoped<IAccountService, IAccountService>()
                   .AddScoped<IEmailService, IEmailService>();
        }
    }
}
