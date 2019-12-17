using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace opalapi.data
{
    public class DocumentDBRepository<T> : IDocumentDBRepository<T> where T : class
    {
        private readonly string Endpoint = "https://localhost:8081/";
        private readonly string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly string DatabaseId = "opalDatabase";

        internal static Task CreateUserAsync(userinformation userinfo)
        {
            throw new NotImplementedException();
        }

        private readonly DocumentClient client;

        public DocumentDBRepository()
        {
            client = new DocumentClient(new Uri(Endpoint), Key);
        }
        public async Task<IEnumerable<T>> GetItemsAsync(string collectionId)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId),
                new FeedOptions
                {
                    PopulateQueryMetrics = true,
                    MaxItemCount = -1,
                    MaxDegreeOfParallelism = -1,
                    EnableCrossPartitionQuery = true
                }).AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }
        public async Task<IEnumerable<T>> GetArticlesAsync(string searchkey)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, searchkey),
                "SELECT * FROM c WHERE CONTAINS(LOWER(c.articletitle), LOWER('challenges'))",
                new FeedOptions
                {
                    PopulateQueryMetrics = true,
                    MaxItemCount = -1,
                    MaxDegreeOfParallelism = -1,
                    EnableCrossPartitionQuery = true
                }).AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<Document> CreateUserAsync(T item, string collectionId)
        {
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, collectionId), item);
        }

       
    }
}

