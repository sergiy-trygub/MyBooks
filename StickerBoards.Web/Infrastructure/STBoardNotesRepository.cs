using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StickerBoards.Web.Models;

namespace StickerBoards.Web.Infrastructure
{
    public class STBoardNotesRepository : IBoardNotesRepository
    {
        private readonly IConfiguration _configuration;

        public STBoardNotesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CreateAsync(StickerNote note)
        {
            CloudTable notesTable = GetNotesTable();

            // Create a new customer entity.
            StickerNoteEntity entity = new StickerNoteEntity();
            entity.PartitionKey = note.BoardId.ToString();
            entity.RowKey = note.Id.ToString();
            entity.Text = note.Text;
            entity.Severity = note.Severity;

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(entity);

            // Execute the insert operation.
            await notesTable.ExecuteAsync(insertOperation);
        }

        public Task DeleteAsync(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public Task<StickerNote> GetBoardNoteAsync(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StickerNote>> GetBoardNotesAsync(Guid boardId)
        {
            CloudTable notesTable = GetNotesTable();

            // Create the CloudTable if it does not exist
            await notesTable.CreateIfNotExistsAsync();

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<StickerNoteEntity> query = new TableQuery<StickerNoteEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, boardId.ToString()));

            // Print the fields for each customer.
            TableContinuationToken token = null;

            var result = new List<StickerNote>();

            do
            {
                TableQuerySegment<StickerNoteEntity> resultSegment = await notesTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (StickerNoteEntity entity in resultSegment.Results)
                {
                    var item = new StickerNote { Id = Guid.Parse(entity.RowKey), BoardId = Guid.Parse(entity.PartitionKey), Text = entity.Text, Severity = entity.Severity };
                    result.Add(item);
                }
            } while (token != null);

            return result;
        }

        private CloudTable GetNotesTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("stickerboards_AzureStorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Get a reference to a table named "peopleTable"
            CloudTable notesTable = tableClient.GetTableReference("notes");

            return notesTable;
        }

        private class StickerNoteEntity : TableEntity
        {
            public string Text { get; set; }

            public int Severity { get; set; }
        }

    }
}
