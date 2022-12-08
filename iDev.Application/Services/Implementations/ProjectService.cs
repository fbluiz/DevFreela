using iDev.Application.InputModels;
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
    public class ProjectService : IProjectService
    {
        public ProjectService(IDevDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly IDevDbContext _dbContext;

        public List<ProjectViewModel> GetAll(string query)
        {
            throw new NotImplementedException();
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(NewProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Start(int id)
        {
            throw new NotImplementedException();
        }

        public void finish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
