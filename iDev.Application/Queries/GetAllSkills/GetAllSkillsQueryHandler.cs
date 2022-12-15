using Dapper;
using iDev.Application.ViewModels;
using iDev.Core.DTOs;
using iDev.Core.Repositories;
using iDev.Infra.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillRepository _skillrepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillrepository)
        {
            _skillrepository = skillrepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return  await _skillrepository.GetAllAsync();
            
        }
    }
}
