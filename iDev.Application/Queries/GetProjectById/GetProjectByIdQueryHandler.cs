using iDev.Application.ViewModels;
using iDev.Infra.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Queries.GetProjectById
{
    internal class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IDevDbContext _dbcontext;

        public GetProjectByIdQueryHandler(IDevDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project =  _dbcontext.Projects.SingleOrDefault(p => p.Id == request.Id);

            if(project == null) return null;

            var projectDetails = new ProjectDetailsViewModel
                (project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.FreeLancer.FullName);

            return projectDetails;
        
        }

    }
}
