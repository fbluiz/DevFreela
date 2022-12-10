using Dapper;
using iDev.Application.Services.Interfaces;
using iDev.Application.ViewModels;
using iDev.Infra.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Services.Implementations
{
    public class SkillService : ISkillService 
    {
        private readonly IDevDbContext _dbcontext;
        private readonly string _connectionString;
        public SkillService(IDevDbContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("iDevCs");
        }

        public List<SkillViewModel> GetAll()
        {
            //var skills = _dbcontext.Skills;

            //var skillsViewModel = skills
              //  .Select(s => new SkillViewModel(s.Id, s.Description))
               // .ToList();

           // return skillsViewModel;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
        }
    }
}
