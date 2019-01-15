
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebApi.Functions
{
    public static class CosmosTrigger
    {
        [FunctionName("CosmosTrigger")]
        public static void Run([CosmosDBTrigger(
           "vinhdb",
           "Items",
            ConnectionStringSetting ="AzureCosmosDbConnectionString", LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true)] IReadOnlyList<Document>documents , ILogger log,[FromQuery] string name)
        {
            foreach (var doc in documents)
            {
                log.LogInformation($"Processing document with Id {doc.Id}");
              
            }
            
        }

      
    }
}
