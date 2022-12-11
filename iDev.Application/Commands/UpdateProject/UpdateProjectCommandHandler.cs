using iDev.Application.Commands.UpdateProject;
using iDev.Infra.Persistence;
using MediatR;

namespace iDev.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IDevDbContext _dbContext;
        public UpdateProjectCommandHandler(IDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
