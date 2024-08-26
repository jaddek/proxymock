using Calendario.API.Database;
using Microsoft.EntityFrameworkCore;

namespace Calendario.API.Domain.Project;

public class ProjectRepository(DBContext dbContext)
{
    private readonly DBContext _dbContext = dbContext;

    public async virtual Task<IEnumerable<Entities.Project>> FindProjects()
    {
        return await _dbContext.Projects.ToListAsync();
    }

    public async virtual Task CreateProject(Entities.Project project)
    {
        _dbContext.Add(project);
        await _dbContext.SaveChangesAsync();
    }

    public async virtual Task UpdateProject(Entities.Project project)
    {
        _dbContext.Update(project);
        await _dbContext.SaveChangesAsync();
    }

    public async virtual Task<Entities.Project?> FindProject(Guid Id)
    {
        return await _dbContext.Projects.FindAsync(Id);
    }
}