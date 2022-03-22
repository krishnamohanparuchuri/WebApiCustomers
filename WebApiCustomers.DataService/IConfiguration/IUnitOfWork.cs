using System.Threading.Tasks;
using WebApiCustomers.DataService.IRepository;

namespace WebApiCustomers.DataService.IConfiguration
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }

        Task CompleteAsync();
    }
}