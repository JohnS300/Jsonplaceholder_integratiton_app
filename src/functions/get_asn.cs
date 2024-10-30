using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CoreConsole
{
    public class GetASNs
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private const string AsnEndpoint = "https://customer-api.com/asns";

        [FunctionName("GetASNs")]
        public async Task Run([TimerTrigger("0 */2 * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation("Fetching ASNs...");

            string jsonResponse = await _apiClient.GetAsync(AsnEndpoint);
            var asns = JsonConvert.DeserializeObject<List<ASN>>(jsonResponse);

            foreach (var asn in asns)
            {
                await DatabaseService.UpdateOrderStatus(asn.OrderId, "ASNReceived");

                if (await DatabaseService.IsOrderComplete(asn.OrderId))
                {
                    await DatabaseService.DeleteOrder(asn.OrderId);
                }
            }

            log.LogInformation("ASN processing complete.");
        }
    }
}
