using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opalapi.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace opalapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IDocumentDBRepository<articleinformation> Respository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly string CollectionId;
        //articleinformation article = new articleinformation();
        public ArticleController(
            IDocumentDBRepository<articleinformation> Respository,
            IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
            this.Respository = Respository;
            CollectionId = "opalContainer";
        }
        /* [HttpGet]
         public async Task<IEnumerable<articleinformation>> Get()
         {
             return await Respository.GetItemsAsync(CollectionId);
         }*/
        /*   [HttpGet("{articletitle}")]
           public async Task<articleinformation> Get(string articletitle)
           {
               var articles = await Respository.GetItemsAsync(d => d.articletitle == articletitle, CollectionId);
               articleinformation article = new articleinformation();
               foreach (var art in articles)
               {
                   article = art;
                   break;
               }
               return article;
           }  */
        [HttpGet("{searchkey}")]
        public async Task<IEnumerable<articleinformation>> Get(string searchkey)
        {
            var articles = await Respository.GetUserAsync(CollectionId);
            List<articleinformation> article = new List<articleinformation>();
            searchkey = searchkey.ToLower();
            foreach (var art in articles)
            {
                if (art.articletitle.ToLower().Contains(searchkey) || art.summary.ToLower().Contains(searchkey) || art.author.ToLower().Contains(searchkey) || art.category.ToLower().Contains(searchkey))
                {
                    article.Add(art);
                }
            }
            return article;
        }

        
    }
}
