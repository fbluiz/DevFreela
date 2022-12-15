using iDev.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
