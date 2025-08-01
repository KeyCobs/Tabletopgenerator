using Tabletopgenerator.Repository.Implementation;

namespace Tabletopgenerator.Models
{
    public class ServiceCollector
    {
        public void AddServices(IServiceCollection service)
        {
            //service.AddScoped
            service.AddScoped<IFirstNameRepository,FirstNameRepository>();
        }
    }
}
