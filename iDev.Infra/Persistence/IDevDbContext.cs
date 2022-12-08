using iDev.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Infra.Persistence
{
    public class IDevDbContext
    {
        public IDevDbContext()
        {
            
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; private set; }
    }
}
