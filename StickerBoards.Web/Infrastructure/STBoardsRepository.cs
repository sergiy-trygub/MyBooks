using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using StickerBoards.Web.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Extensions.Configuration;

namespace StickerBoards.Web.Infrastructure
{
    public class STBoardsRepository : IBoardsRepository
    {
        private readonly IConfiguration _configuration;

        public STBoardsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task CreateBoardAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteBoardAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StickerNote>> GetBoardNotesAsync(Guid boardId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Board>> GetBoardsAsync()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("stickerboards_AzureStorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Get a reference to a table named "peopleTable"
            CloudTable boardsTable = tableClient.GetTableReference("boards");

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<BoardEntity> query = new TableQuery<BoardEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "default"));

            // Print the fields for each customer.
            TableContinuationToken token = null;

            var result = new List<Board>();

            do
            {
                TableQuerySegment<BoardEntity> resultSegment = await boardsTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (BoardEntity entity in resultSegment.Results)
                {                    
                    var item = new Board { Id = Guid.Parse(entity.RowKey), Name = entity.Name };
                    result.Add(item);
                }
            } while (token != null);

            return result;
        }

        private class BoardEntity : TableEntity
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }
}
