using Microsoft.EntityFrameworkCore;
using Proxymock.API.Database;

namespace Proxymock.API.Domain.Project.Endpoint;

public class EndpointRepository(DBContext dbContext)
{
    public virtual async Task<IEnumerable<Entities.Endpoint>> FindAllAsync()
    {
        return await dbContext
            .Endpoints
            .AsNoTracking()
            .ToListAsync()
            ;
    }

    public virtual async Task CreateAsync(Entities.Endpoint endpoint)
    {
        dbContext.Endpoints.Add(endpoint);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(Entities.Endpoint endpoint)
    {
        dbContext.Endpoints.Update(endpoint);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task<Entities.Endpoint?> FindOneAsync(Guid id)
    {
        return await dbContext.Endpoints.FindAsync(id);
    }

    public virtual async Task<Entities.Endpoint?> FindProjectEndpoint(Entities.Project project, Guid id)
    {
        return await dbContext.Endpoints
            .Where(e => 
                e.Id == id 
                && e.Project.Id == project.Id)
            .FirstOrDefaultAsync();
    }
}