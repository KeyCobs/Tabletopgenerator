using Tabletopgenerator.Models;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Repository
{
    public abstract class BaseRepository
    {
        protected readonly MyDbContext _dbContext;
        protected BaseRepository(MyDbContext dbContext)
        {
            Guard.AgainstNull(dbContext, nameof(dbContext));
            _dbContext = dbContext;
        }
    }
}
