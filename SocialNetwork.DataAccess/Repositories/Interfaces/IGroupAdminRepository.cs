using SocialNetwork.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Repositories.Interfaces
{
    public interface IGroupAdminRepository : IGenericRepository<GroupAdministrator, Guid>
    {
    }
}
