using Newtonsoft.Json;
using NorthDallas.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NorthDallas.Contacts.Services
{
    public class UserService
    {
        public async Task<List<Result>> GetUsersAsync(int count)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"https://randomuser.me/api/?results={count}&seed=northdallas");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<RootObject>(json);

                return results.results;
            }

            throw new Exception("API call failed!");
        }
    }
}
