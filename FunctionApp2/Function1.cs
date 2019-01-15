using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([CosmosDBTrigger(
            databaseName: "databaseName",
            collectionName: "collectionName",
            ConnectionStringSetting = "AccountEndpoint=https://devulurudocsstore.documents.azure.com:443/;AccountKey=opBSNRQaYNRRA7Ba8L0QjeYLu21FiSkBpsyml86cpDssBmoGOMlu66F1pxjG1xHGJwVpPMpaogqv1VdKGgRiFw==;",
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
