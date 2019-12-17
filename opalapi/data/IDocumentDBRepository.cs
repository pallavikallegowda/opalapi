using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
namespace opalapi.data
{
   public interface IDocumentDBRepository<T> where T : class
    {
        Task<Document> CreateUserAsync(T item, string collectionId);
        Task<IEnumerable<T>> GetItemsAsync(string collectionId);
        // Task<IEnumerable<T>> GetItemsAsync(string collectionId);
        Task<IEnumerable<T>> GetArticlesAsync(string searchkey);
    }
}
