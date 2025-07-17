using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingLog.DBUtility
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class WebConfigReader
    {

        public static string GetConfigAsync()
        {
            var url = "http://192.168.0.169/connect.json";
            HttpClient _httpClient = new HttpClient();
            var response = _httpClient.GetAsync(url).Result; 
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (dict != null && dict.ContainsKey("MysqlDb"))
                {
                    return dict["MysqlDb"];
                }
                else
                {
                    throw new Exception("Error Connect");
                } 
            }
            else
            {
                throw new Exception($"Failed to fetch config. StatusCode: {response.StatusCode}");
            }
        }
    }

}
