using Newtonsoft.Json;
using SolforbTestTask.Data.Models;

namespace SolforbTestTask.Data;

public interface IClientService
{
    Task<Guid?> ChangeConditionClientAsync(Guid clientId);
    Task<Guid?> DeleteClientAsync(Guid clientId);
    Task<Client?> GetClientAsync(Guid clientId);
    Task<Client[]?> GetClientsAsync(int condition);
    Task<string?> SaveClientAsync(Client client);
}

public class ClientService : IClientService
{
    public async Task<Client[]?> GetClientsAsync(int condition)
    {
        using var httpClient = new HttpClient();
        try
        {
            var content = new StringContent($"{{\"condition\":{condition}}}", System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Client/List", content);
            if (!response.IsSuccessStatusCode)
                return Array.Empty<Client>();

            var jsonData = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(jsonData)
                ? Array.Empty<Client>()
                : JsonConvert.DeserializeObject<Client[]>(jsonData);
        }
        catch (Exception)
        {
            return Array.Empty<Client>();
        }
    }

    public async Task<Client?> GetClientAsync(Guid clientId)
    {
        using var httpClient = new HttpClient();
        /*
         http://193.32.203.182:8081/Directories/Client/Form
        {"guid":"0198768c-ee3f-7f57-8b99-29cc65dcac30"}
         */
        try
        {
            var content = new StringContent($"{{\"guid\":\"{clientId}\"}}", System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Client/Form", content);
            if (!response.IsSuccessStatusCode)
                return null;

            var jsonData = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(jsonData)
                ? null
                : JsonConvert.DeserializeObject<Client>(jsonData);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<string?> SaveClientAsync(Client client)
    {
        using var httpClient = new HttpClient();
        /*
         http://193.32.203.182:8081/Directories/Client/Form
        {"guid":"0198768c-ee3f-7f57-8b99-29cc65dcac30"}
         */
        try
        {
            var content = new StringContent(JsonConvert.SerializeObject(client), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Client/Save", content);
            if (!response.IsSuccessStatusCode)
                return null;

            var jsonData = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(jsonData)
                ? null
                : jsonData;
            //409
            /*
             {
    "Message": "В системе уже зарегистрирован клиент с таким наименованием"
}
             * */
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Guid?> DeleteClientAsync(Guid clientId)
    {
        using var httpClient = new HttpClient();
        /*
         http://193.32.203.182:8081/Directories/Client/Form
        {"guid":"0198768c-ee3f-7f57-8b99-29cc65dcac30"}
         */
        try
        {
            var content = new StringContent($"{{\"guid\":\"{clientId}\"}}", System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Client/Delete", content);
            if (!response.IsSuccessStatusCode)
                return null;

            return clientId;
            //var jsonData = await response.Content.ReadAsStringAsync();
            //return string.IsNullOrEmpty(jsonData)
            //    ? null
            //    : JsonConvert.DeserializeObject<Client>(jsonData);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Guid?> ChangeConditionClientAsync(Guid clientId)
    {
        using var httpClient = new HttpClient();
        /*
         http://193.32.203.182:8081/Directories/Client/Form
        {"guid":"0198768c-ee3f-7f57-8b99-29cc65dcac30"}
         */
        try
        {
            var content = new StringContent($"{{\"guid\":\"{clientId}\"}}", System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://193.32.203.182:8081/Directories/Client/ChangeCondition", content);
            if (!response.IsSuccessStatusCode)
                return null;

            return clientId;
            //var jsonData = await response.Content.ReadAsStringAsync();
            //return string.IsNullOrEmpty(jsonData)
            //    ? null
            //    : JsonConvert.DeserializeObject<Client>(jsonData);
        }
        catch (Exception)
        {
            return null;
        }
    }
}