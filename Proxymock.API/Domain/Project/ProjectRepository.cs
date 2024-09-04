using Microsoft.EntityFrameworkCore;
using Proxymock.API.Database;

namespace Proxymock.API.Domain.Project;

public class ProjectRepository(DBContext dbContext)
{

    public virtual async Task<IEnumerable<Entities.Project>> FindProjects()
    {
        return await dbContext.Projects.ToListAsync();
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

    public virtual async Task<Entities.Project?> FindProject(Guid Id)
    {
        return await dbContext.Projects.FindAsync(Id);
    }
}