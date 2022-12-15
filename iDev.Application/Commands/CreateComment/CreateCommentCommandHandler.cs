using iDev.Core.Entities;
using iDev.Core.Repositories;
using iDev.Infra.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        readonly private IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content,request.IdProject,request.IdUser);

           await _projectRepository.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}
