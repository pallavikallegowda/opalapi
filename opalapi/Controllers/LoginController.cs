using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using opalapi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using opalapi.Services;
using opalapi.data;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace opalapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IDocumentDBRepository<user> Respository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly string CollectionId;
        public LoginController(IDocumentDBRepository<user> Respository,IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
            this.Respository = Respository;
            CollectionId = "userContainer";
        }
        /*   [HttpGet("{emailid}/{password}")]
           public async Task<IEnumerable<user>> Get(string emailid, string password)
           {
               var loggedin = await Respository.GetLoginUserAsync(CollectionId);
               List<user> article = new List<user>();
               //user logiuser = new user();
               foreach (var userlogin in loggedin)
               {
                   if (userlogin.emailid.Contains(emailid) && userlogin.password.Contains(password))
                   {
                       article.Add(userlogin);
                   }
               }
               return article;
           }*/

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([System.Web.Http.FromBody]user userParam)
        {
            var user = await Respository.Authenticate(userParam.emailid, userParam.password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
