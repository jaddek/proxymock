using Microsoft.EntityFrameworkCore;
using Proxymock.API.Database;

namespace Proxymock.API.Domain.Project;

public class ProjectRepository(DBContext dbContext)
{
    private readonly DBContext _dbContext = dbContext;

    public virtual async Task<IEnumerable<Entities.Project>> FindProjects()
    {
        return await _dbContext.Projects.ToListAsync();
    }

    public virtual async Task CreateProject(Entities.Project project)
    {
        _dbContext.Add(project);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateProject(Entities.Project project)
    {
        _dbContext.Update(project);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<Entities.Project?> FindProject(Guid Id)
    {
        return await _dbContext.Projects.FindAsync(Id);
    }
}