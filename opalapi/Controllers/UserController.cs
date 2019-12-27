using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opalapi.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace opalapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDocumentDBRepository<user> Respository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly string CollectionId;
        //articleinformation article = new articleinformation();
        public UserController(
            IDocumentDBRepository<user> Respository,
            IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
            this.Respository = Respository;
            CollectionId = "userContainer";
        }
        [HttpGet]
        public async Task<IEnumerable<user>> Get()
        {
            return await Respository.GetUserAsync(CollectionId);
        }

         [HttpPost]
        public async Task<bool> Post([FromBody]user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.id = null;
                    await Respository.CreateUserAsync(user, CollectionId);
                    await _hubContext.Clients.All.BroadcastMessage();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        [HttpPut]
        public async Task<bool> Put([FromBody]user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Respository.UpdateItemAsync(user.id, user, CollectionId);
                    await _hubContext.Clients.All.BroadcastMessage();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
