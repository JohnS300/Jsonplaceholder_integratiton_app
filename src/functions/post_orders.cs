using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CoreConsole
{
    public class PostOrder
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private const string OrderEndpoint = "https://customer-api.com/orders";

        [FunctionName("PostOrder")]
        public async Task Run([QueueTrigger("new-orders")] Order order, ILogger log)
        {
            log.LogInformation($"Posting new order: {order.OrderId}");

            // Send POST request to the customer's API
            string response = await _apiClient.PostAsync(OrderEndpoint, order);

            // Update your Azure Database with the new order status
            await DatabaseService.AddOrder(order.OrderId, status: "Pending");

            log.LogInformation($"Order posted successfully: {order.OrderId}");
        }
    }
}
