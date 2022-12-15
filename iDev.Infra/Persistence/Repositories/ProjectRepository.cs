using Azure.Core;
using iDev.Core.Entities;
using iDev.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace iDev.Infra.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDevDbContext _dbcontext;
        private readonly string _connectionString;
        public ProjectRepository(IDevDbContext dbContext, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _connectionString = configuration.GetConnectionString("iDevCs");
        }

        public async Task AddCommentAsync(ProjectComment comment)
        {
            await _dbcontext.ProjectComments.AddAsync(comment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task AddProjectAsync(Project project)
        {
            await _dbcontext.Projects.AddAsync(project);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task <List<Project>> GetAllAsync()
        {
            return await _dbcontext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbcontext.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
