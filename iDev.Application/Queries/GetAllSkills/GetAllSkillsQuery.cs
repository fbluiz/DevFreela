using iDev.Application.ViewModels;
using iDev.Core.DTOs;
using MediatR;

namespace iDev.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {

    }
}
