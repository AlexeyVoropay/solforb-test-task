using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolforbTestTask.Data.Models;

namespace SolforbTestTask.Data
{
    public interface IReceiptsService
    {
        Task<Root?> GetReceiptsAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    }

    public class ReceiptsService : IReceiptsService
    {
        /*
         * http://193.32.203.182:8081/Warehouse/Receipt/List
         * payload
         * {"start":"2025-08-05T00:00:00+03:00","end":"2025-08-19T00:00:00+03:00","numbers":[],"resourceGuids":[],"measureUnitGuids":[]}
         */
        public async Task<Root?> GetReceiptsAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            using var httpClient = new HttpClient();
            try
            {
                //var payload = $"{{\"start\":\"2025-08-05T00:00:00+03:00\",\"end\":\"2025-08-19T00:00:00+03:00\",\"numbers\":[],\"resourceGuids\":[],\"measureUnitGuids\":[]}}";
                var payload = $"{{\"start\":\"{startDate.ToString("yyyy-MM-ddTHH:mm:sszzz")}\",\"end\":\"{endDate.ToString("yyyy-MM-ddTHH:mm:sszzz")}\",\"numbers\":[],\"resourceGuids\":[],\"measureUnitGuids\":[]}}";
                var content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://193.32.203.182:8081/Warehouse/Receipt/List", content);
                if (!response.IsSuccessStatusCode)
                    return null;

                var jsonData = await response.Content.ReadAsStringAsync();
                return string.IsNullOrEmpty(jsonData)
                    ? null
                    : JsonConvert.DeserializeObject<Root>(jsonData);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
