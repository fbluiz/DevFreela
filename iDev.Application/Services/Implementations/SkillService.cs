using iDev.Application.Services.Interfaces;
using iDev.Application.ViewModels;
using iDev.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Services.Implementations
{
    public class SkillService : ISkillService 
    {
        public SkillService(IDevDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        private readonly IDevDbContext _dbcontext;
        public List<SkillViewModel> GetAll()
        {
            var skills = _dbcontext.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
