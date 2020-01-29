using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Infrastructure
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly NavigationManager navigationManager;

        public RequestService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.navigationManager = navigationManager;
            //this.httpClient.MaxResponseContentBufferSize = 256000;
        }

        private async Task AddHeader()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", token);
            }

            httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
        }

        public async Task<TResult> GetAsync<TResult>(string uri) where TResult : new()
        {
            await AddHeader();

            var responseData = new TResult();
            var response = await httpClient.GetAsync(new Uri(string.Format(uri)));
            if (response.IsSuccessStatusCode)
                responseData = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());

            return responseData;
        }

        public async Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            await AddHeader();

            var response = await httpClient.PostAsync(new Uri(string.Format(uri)), SerializeContentString(data));
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            await AddHeader();

            var response = await httpClient.PostAsync(new Uri(string.Format(uri)), SerializeContentString(data));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            await AddHeader();

            var response = await httpClient.PutAsync(new Uri(string.Format(uri)), SerializeContentString(data));
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            await AddHeader();

            var response = await httpClient.PutAsync(new Uri(string.Format(uri)), SerializeContentString(data));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> DeleteAsync<TResult>(string uri)
        {
            await AddHeader();

            var response = await httpClient.DeleteAsync(new Uri(string.Format(uri)));
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public StringContent SerializeContentString(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }

        public async Task<TModel> DeserializeContentStringAsync<TModel>(HttpResponseMessage model)
        {
            var contentString = await model.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(contentString);
        }


    }
}
