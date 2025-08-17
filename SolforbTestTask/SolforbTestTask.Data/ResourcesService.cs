using Newtonsoft.Json;
using SolforbTestTask.Data.Models;

namespace SolforbTestTask.Data
{
    public interface IResourcesService
    {
        Task<Resource[]?> GetResourcesAsync(int condition);
    }

    //http://193.32.203.182:8081/Directories/MeasureUnit/List
    //Единица измерения (идентификатор, наименование, состояние)

    public class ResourcesService : IResourcesService
    {
        public async Task<Resource[]?> GetResourcesAsync(int condition)
        {
            using var httpClient = new HttpClient();
            try
            {
                var content = new StringContent($"{{\"condition\":{condition}}}", System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Resource/List", content);
                if (!response.IsSuccessStatusCode)
                    return Array.Empty<Resource>();

                var jsonData = await response.Content.ReadAsStringAsync();
                var result = string.IsNullOrEmpty(jsonData)
                    ? Array.Empty<Resource>()
                    : JsonConvert.DeserializeObject<Resource[]>(jsonData);
                
                return result;
            }
            catch (Exception)
            {
                return Array.Empty<Resource>();
            }
        }
    }
}
