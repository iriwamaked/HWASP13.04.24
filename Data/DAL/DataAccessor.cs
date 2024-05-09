using ASP1.Services.Kdf;
using HWASP.Data.Context;

namespace HWASP.Data.DAL
{
    public class DataAccessor
    {
        public DataContext _context;
        private readonly IKdfService _kdfService;
        private readonly Object _dbLocker = new();
        public UserDao UserDao { get; private set; }
        public ServicesShopDao ServicesShopDao { get; private set; }
        public DataAccessor(DataContext context, IKdfService kdfService)
        {
            _context = context;
            _kdfService = kdfService; 
            UserDao = new(_context, _kdfService, _dbLocker);
            ServicesShopDao = new(_context, _dbLocker);
           
        }
    }
}
