using Dapper;
using iDev.Application.Commands.StartProject;
using iDev.Core.Repositories;
using iDev.Infra.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace iDev.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository_;
        public StartProjectCommandHandler(IProjectRepository projectRepository_)
        {
            _projectRepository_ = projectRepository_;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository_.GetByIdAsync(request.Id);

            project.Start();

            await _projectRepository_.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
