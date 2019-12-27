using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
namespace opalapi.data
{
   public interface IDocumentDBRepository<T> where T : class
    {
        Task<Document> CreateUserAsync(T item, string collectionId);

         Task<IEnumerable<T>> GetUserAsync(string collectionId);
        // Task<IEnumerable<T>> GetItemsAsync(string collectionId);
        Task<IEnumerable<T>> GetArticlesAsync(string searchkey);
       
        Task<Document> UpdateItemAsync(string id, T item, string collectionId);
        Task<IEnumerable<T>> Authenticate(string emailid, string password);
        Task<IEnumerable<T>> GetLoginUserAsync(string emailid, string password);
    }
}
