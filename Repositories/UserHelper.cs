using WebApplicationStore.Controllers;
using WebApplicationStore.Models.Contexts;

namespace WebApplicationStore.Repositories
{
    public class UserHelper
    {
        private readonly officia1_StoreContext _context;
        private readonly ILogger<HomeController> _logger;

        public UserHelper(ILogger<HomeController> logger, officia1_StoreContext context)
        {
            _context = context;
            _logger = logger;
        }
        public int getUserId(String userName) {
            return 1;
        }
    }
}
