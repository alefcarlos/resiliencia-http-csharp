using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ApiService
    {
        private readonly HttpClient _client;
        public ApiService(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.BaseAddress = new System.Uri("https://localhost:44354/api/");
        }

        public async Task TimeoutAsync(int timeoutSeconds, int retrySuccess)
        {
            //_client.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
            var response = await _client.GetAsync($"example/timeout/{timeoutSeconds + 5}/complete/{retrySuccess}");
        }

        public async Task ErrorAsync(int errorCode, int retrySuccess)
        {
            var response = await _client.GetAsync($"example/error/{errorCode}/complete/{retrySuccess}");
        }

        public async Task SuccessAsync()
        {
            var response = await _client.GetAsync("example/success/");
        }
    }
}