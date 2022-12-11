using DevFreela.Application.Commands.FinishProject;
using iDev.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace iDev.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IDevDbContext _dbContext;
        public FinishProjectCommandHandler(IDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == request.Id);

            project.Finish();
            _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
