using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Workfulness.Client.Models.Auth;

namespace Workfulness.Client.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private HttpClient _HttpClient { get; }
        private ILocalStorageService _LocalStorage { get; }

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _HttpClient = httpClient;
            _LocalStorage = localStorage;
        }

        public async Task RegisterUser(RegisterRequest registerRequest)
        {
            var content = JsonSerializer.Serialize(registerRequest);
            var body = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _HttpClient.PostAsync("api/authentication/register", body);

            if (!response.IsSuccessStatusCode)
            {
                // TODO: throw exception
            }
        }

        public async Task LoginUser(LoginRequest loginRequest)
        {
            var content = JsonSerializer.Serialize(loginRequest);
            var body = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _HttpClient.PostAsync("api/authentication/login", body);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                await _LocalStorage.SetItemAsync("UserToken", token);
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new AuthenticationException(err);
            }
        }

        public async Task Logout()
        {
            await _LocalStorage.RemoveItemAsync("UserToken");
            _HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
