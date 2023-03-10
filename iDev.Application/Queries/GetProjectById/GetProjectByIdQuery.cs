using iDev.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel> 
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
