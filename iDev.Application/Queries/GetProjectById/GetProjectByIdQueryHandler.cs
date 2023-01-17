using iDev.Application.ViewModels;
using iDev.Core.Repositories;
using iDev.Infra.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectrepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectrepository)
        {
            _projectrepository = projectrepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectrepository.GetByIdAsync(request.Id);

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
