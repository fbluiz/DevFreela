using iDev.Application.ViewModels;
using iDev.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery,List<ProjectViewModel>>
    {
        private readonly IDevDbContext _dbContext;

        public GetAllProjectsQueryHandler(IDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = await projects
                .Select(c => new ProjectViewModel(c.Id, c.Title, c.CreatedAt))
                .ToListAsync();

            return projectsViewModel;
        }
    }
}
