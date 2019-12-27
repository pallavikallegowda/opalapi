using System.Threading.Tasks;

namespace opalapi.Controllers
{
    internal interface IUserService
    {
        Task Authenticate(string emailid, string password);
    }
}