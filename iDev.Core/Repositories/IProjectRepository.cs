using iDev.Core.Entities;

namespace iDev.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddCommentAsync(ProjectComment comment);
        Task AddProjectAsync(Project project);
        Task SaveChangesAsync();
    }
}
