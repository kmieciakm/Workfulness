using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Workfulness.Client.Helpers;

namespace Workfulness.Client.Services.Auth
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private HttpClient _HttpClient { get; }
        private ILocalStorageService _LocalStorage { get; }

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _HttpClient = httpClient;
            _LocalStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _LocalStorage.GetItemAsync<string>("UserToken");
            if (token != null && token != string.Empty)
            {
                _HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var claims = JwtParser.ParseClaimsFromJwt(token);
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType")));
            }
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
