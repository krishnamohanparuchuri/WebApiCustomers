using System.Threading.Tasks;
using WebApiCustomers.Entities.DbSet;

namespace WebApiCustomers.DataService.IRepository
{
    public interface IUsersRepository :IGenericRepository<User>
    {
        Task<User> GetUserPerEmailAddress(string email);
    }
}