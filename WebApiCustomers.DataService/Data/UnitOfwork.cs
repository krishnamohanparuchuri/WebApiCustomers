using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApiCustomers.DataService.IConfiguration;
using WebApiCustomers.DataService.IRepository;
using WebApiCustomers.DataService.Repository;

namespace WebApiCustomers.Dataservice
{
    public class UnitOfwork : IUnitOfWork,IDisposable
    {
        private readonly AppDbContext _context;
        
        private readonly ILogger _logger;
        public IUsersRepository Users { get; private set; }
        

        public UnitOfwork(AppDbContext context,ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");
            Users = new UsersRepository(_context, _logger);
        }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}