using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Workfulness.Client.Models;
using Workfulness.Client.Models.Exceptions;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    public class ToDoService : IToDoService
    {
        private HttpClient _HttpClient { get; }

        public ToDoService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<List<ToDoList>> GetToDoListsAsync()
        {
            return await _HttpClient.GetFromJsonAsync<List<ToDoList>>($"api/todo");
        }

        public async Task CreateToDoList(string name)
        {
            var response = await _HttpClient.PostAsync($"api/todo/{name}", null);

            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.InternalServerError)
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new ServiceException(err);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ServiceException("Unexpected error has occured.");
            }
        }

        public async Task DeleteToDoList(string name)
        {
            var response = await _HttpClient.DeleteAsync($"api/todo/{name}");

            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.InternalServerError)
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new ServiceException(err);
            }

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ServiceException("Unexpected error has occured.");
            }
        }
    }
}
