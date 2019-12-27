using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opalapi.data;

namespace opalapi.Services
{
    public interface IUserService
    {
        Task<user> Authenticate(string username, string password);
        Task<IEnumerable<user>> GetAll();
    }
    public class UserService : IUserService
    {
        List<user> _users = new List<user>();
        public async Task<user> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.emailid == username && x.password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.password = null;
            return user;
        }

        public async Task<IEnumerable<user>> GetAll()
        {
            // return users without passwords
            return await Task.Run(() => _users.Select(x => {
                x.password = null;
                return x;
            }));
        }
    }
}
