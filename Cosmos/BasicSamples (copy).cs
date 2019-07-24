using System;

namespace Cosmos
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;
    

    class Reference
    {
       
        public async Task RunSamples()
        {
            Console.WriteLine("Azure Cosmos DB Table - Basic Samples\n");
            Console.WriteLine();

            string tableName = "TestIO";

            // Create or reference an existing table
            CloudTable table = Common.GetTable(tableName);

            try
            {
                // Demonstrate basic CRUD functionality 
                await BasicDataOperationsAsync(table);
            }
            finally
            {
                // Delete the table
                //await table.DeleteIfExistsAsync();
            }
        }

        private static async Task BasicDataOperationsAsync(CloudTable table)
        {
            // Create an instance of a customer entity. See the Model\CustomerEntity.cs for a description of the entity.

            for (int i = 0; i < 10; i++)
            {
                CustomerEntity customer = Common.customers[i];
                string pk = customer.PartitionKey;
                string rk = customer.RowKey;
                // Demonstrate how to insert the entity
                Console.WriteLine("Insert an Entity.");
                customer = await SamplesUtils.InsertOrMergeEntityAsync(table, customer);

                // Demonstrate how to Update the entity by changing the phone number
                Console.WriteLine("Update an existing Entity using the InsertOrMerge Upsert Operation.");
                customer.PhoneNumber = "425-555-0105";
                await SamplesUtils.InsertOrMergeEntityAsync(table, customer);
                Console.WriteLine();

                // Demonstrate how to Read the updated entity using a point query 
                Console.WriteLine("Reading the updated Entity.");
                customer = await SamplesUtils.RetrieveEntityUsingPointQueryAsync(table, pk, rk);
                Console.WriteLine();

                // Demonstrate how to Delete an entity
                Console.WriteLine("Delete the entity. ");
                await SamplesUtils.DeleteEntityAsync(table, customer);
                Console.WriteLine();
            }
        }
    }
}
