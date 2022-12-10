using iDev.Core.Entities;
using iDev.Infra.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IDevDbContext _dbcontext;
        public CreateProjectCommandHandler(IDevDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _dbcontext.Projects.AddAsync(project);
            await _dbcontext.SaveChangesAsync();

            return project.Id;
        }
    }
}
