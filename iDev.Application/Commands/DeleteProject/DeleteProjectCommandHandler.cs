using iDev.Infra.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand,Unit>
    {
        private readonly IDevDbContext _dbContext;
        public DeleteProjectCommandHandler(IDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Cancel();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
