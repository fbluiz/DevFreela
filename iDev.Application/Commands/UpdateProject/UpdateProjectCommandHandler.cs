using iDev.Application.Commands.UpdateProject;
using iDev.Core.Repositories;
using iDev.Infra.Persistence;
using MediatR;

namespace iDev.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
