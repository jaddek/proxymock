using Microsoft.EntityFrameworkCore;
using Proxymock.API.Database;

namespace Proxymock.API.Domain.Project.Project;

public class ProjectRepository(DBContext dbContext)
{
    public virtual async Task<IEnumerable<Entities.Project>> FindAllAsync()
    {
        return await dbContext
            .Projects
            .AsNoTracking()
            .ToListAsync()
            ;
    }

    public virtual async Task CreateProject(Entities.Project project)
    {
        dbContext.Add(project);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateProject(Entities.Project project)
    {
        dbContext.Update(project);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task<Entities.Project?> FindOneAsync(Guid id)
    {
        return await dbContext.Projects.FindAsync(id);
    }
}