using Tabletopgenerator.Repository.Implementation;
using Tabletopgenerator.Repository.Interface;

namespace Tabletopgenerator.Models
{
    public class ServiceCollector
    {
        public void AddServices(IServiceCollection service)
        {
            //service.AddScoped
            service.AddScoped<IFirstNameRepository,FirstNameRepository>()
                   .AddScoped<INameGeneratorRepository, NameGeneratorRepository>();
        }
    }
}
