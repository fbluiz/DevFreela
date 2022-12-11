using iDev.Application.ViewModels;
using MediatR;

namespace iDev.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {

    }
}
