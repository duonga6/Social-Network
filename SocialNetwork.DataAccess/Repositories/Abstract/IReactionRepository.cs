using SocialNetwork.DataAccess.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Repositories.Abstract
{
    public interface IReactionRepository : IGenericRepository<Reaction, int>
    {
    }
}
