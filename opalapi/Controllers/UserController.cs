using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opalapi.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using opalapi.data;
using System.Web.Http;


namespace opalapi.Controllers
{
    [RoutePrefix("api/[userinformation]")]
    public class UserController : ApiController
    {
        [System.Web.Http.HttpPost]
        public async Task<userinformation> CreateAsync([System.Web.Http.FromBody] userinformation userinfo)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<userinformation>.CreateUserAsync(userinfo);
                return userinfo;
            }
            return null;
        }
    }
}
