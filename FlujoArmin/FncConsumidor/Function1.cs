using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FncConsumidor
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("cola1", Connection = "Endpoint=sb://queuesarah.servicebus.windows.net/;SharedAccessKeyName=Escuchar;SharedAccessKey=KLt9cV2XXXMJUVbDSV+21pN9BG6OG/ROYH9mU5CsHfU=;EntityPath=cola1")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
