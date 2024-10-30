using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CoreConsole
{
    public class GetInvoices
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private const string InvoiceEndpoint = "https://customer-api.com/invoices";

        [FunctionName("GetInvoices")]
        public async Task Run([TimerTrigger("0 */2 * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation("Fetching invoices...");

            // Fetch invoices from the API
            string jsonResponse = await _apiClient.GetAsync(InvoiceEndpoint);
            var invoices = JsonConvert.DeserializeObject<List<Invoice>>(jsonResponse);

            foreach (var invoice in invoices)
            {
                // Update each order's status in the database
                await DatabaseService.UpdateOrderStatus(invoice.OrderId, "InvoiceReceived");

                // Check if all message types are received and delete order if complete
                if (await DatabaseService.IsOrderComplete(invoice.OrderId))
                {
                    await DatabaseService.DeleteOrder(invoice.OrderId);
                }
            }

            log.LogInformation("Invoice processing complete.");
        }
    }
}
