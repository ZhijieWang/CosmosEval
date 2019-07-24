using System;

namespace Cosmos { 
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;
    using System.Collections.Generic;
    using System.Configuration;


    public class Common
    {
        public static List<Model.CustomerEntity> customers = new List<CustomerEntity>() {
            new CustomerEntity("Harp", "Walter1"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter2"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter3"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter4"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter5"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter6"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter7"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter8"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter9"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },
            new CustomerEntity("Harp", "Walter10"){
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            },

        };
        public static CloudTable GetTable(string tableName)
        {
            CloudStorageAccount storageAccount =CloudStorageAccount.Parse(AppSettings.LoadAppSettings().StorageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference(tableName);
            return table;
        }
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

        public static async Task<CloudTable> CreateTableAsync(string tableName)
        {
            string storageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"];

            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);

            // Create a table client for interacting with the table service
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            Console.WriteLine("Create a Table for the demo");

            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            if (await table.CreateIfNotExistsAsync())
            {
                Console.WriteLine("Created Table named: {0}", tableName);
            }
            else
            {
                Console.WriteLine("Table {0} already exists", tableName);
            }

            Console.WriteLine();
            return table;
        }

        public static async Task<CloudTable> CreateTableAsync(CloudTableClient tableClient, string tableName)
        {
            Console.WriteLine("Create a Table for the demo");

            // Create a table client for interacting with the table service 
            CloudTable table = tableClient.GetTableReference(tableName);
            try
            {
                if (await table.CreateIfNotExistsAsync())
                {
                    Console.WriteLine("Created Table named: {0}", tableName);
                }
                else
                {
                    Console.WriteLine("Table {0} already exists", tableName);
                }
            }
            catch (StorageException)
            {
                Console.WriteLine(
                    "If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                Console.ReadLine();
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            return table;
        }
    }
}
