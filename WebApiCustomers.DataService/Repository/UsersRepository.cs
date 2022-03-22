using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiCustomers.Dataservice;
using WebApiCustomers.DataService.IRepository;
using WebApiCustomers.Entities.DbSet;

namespace WebApiCustomers.DataService.Repository
{
    public class UsersRepository : GenricRepository<User>,IUsersRepository
    {
        public UsersRepository(AppDbContext context,ILogger logger) :base(context,logger)
        { }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet
                    .Where(x => x.Status == 1)
                    .AsNoTracking()
                    .ToListAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e,"{Repo} All Method generated an error",typeof(UsersRepository) );
                return new List<User>();
            }
            
        }

        public Task<User> GetUserPerEmailAddress(string email)
        {
            throw new NotImplementedException();
        }
    }
}