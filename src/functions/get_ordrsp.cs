using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CoreConsole
{
    public class GetOrderResponses
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private const string OrderResponseEndpoint = "https://customer-api.com/orderresponses";

        [FunctionName("GetOrderResponses")]
        public async Task Run([TimerTrigger("0 */2 * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation("Fetching Order Responses...");

            string jsonResponse = await _apiClient.GetAsync(OrderResponseEndpoint);
            var orderResponses = JsonConvert.DeserializeObject<List<OrderResponse>>(jsonResponse);

            foreach (var orderResponse in orderResponses)
            {
                await DatabaseService.UpdateOrderStatus(orderResponse.OrderId, "OrderResponseReceived");

                if (await DatabaseService.IsOrderComplete(orderResponse.OrderId))
                {
                    await DatabaseService.DeleteOrder(orderResponse.OrderId);
                }
            }

            log.LogInformation("Order Response processing complete.");
        }
    }
}
