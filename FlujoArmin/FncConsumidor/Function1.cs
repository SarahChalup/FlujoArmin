

namespace FncConsumidor
{
    using System;
    using System.Threading.Tasks;
    using FncConsumidor.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
            [ServiceBusTrigger(
                "cola1", 
                Connection = "MyConn"
            )]string myQueueItem, 
            [CosmosDB(
                databaseName: "DBUbicua",
                collectionName:"eventos",
                ConnectionStringSetting ="myConStringSetting"
            )]IAsyncCollector<object> datos,
            ILogger log)
        {
            try
            {


                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible inserttar datos :C : {ex.Message}");
            }
        }
    }
}
