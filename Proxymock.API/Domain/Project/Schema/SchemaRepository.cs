using Microsoft.EntityFrameworkCore;
using Proxymock.API.Database;

namespace Proxymock.API.Domain.Project.Schema;

public class SchemaRepository(DBContext dbContext)
{
    public virtual async Task<IEnumerable<Entities.Schema>> FindAllAsync()
    {
        return await dbContext
            .Schemas
            .AsNoTracking()
            .ToListAsync()
            ;
    }

    public virtual async Task CreateAsync(Entities.Schema schema)
    {
        dbContext.Schemas.Add(schema);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(Entities.Schema schema)
    {
        dbContext.Schemas.Update(schema);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task<Entities.Schema?> FindOneAsync(Guid id)
    {
        return await dbContext.Schemas.FindAsync(id);
    }

    public virtual async Task<Entities.Schema?> FindEndpointSchema(
        Entities.Endpoint endpoint,
        Guid id)
    {
        return await dbContext.Schemas
            .Where(e => 
                e.Id == id 
                && e.Endpoint.Id == endpoint.Id)
            .FirstOrDefaultAsync();
    }
}