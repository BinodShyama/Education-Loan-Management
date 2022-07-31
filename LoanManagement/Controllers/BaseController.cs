using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class BaseController : Controller
    {
        protected HttpClient Client;
        public BaseController()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        protected async Task<T> GetAsync<T>(string url)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<T>(responseString);
                    return model;
                }

                return default(T);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<T> PostAsync<T>(string url, object model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

                HttpResponseMessage response = await Client.PostAsync(url, stringContent);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(apiResponse);
                return data;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        protected async Task<T> PutAsync<T>(string url, object model)
        {
            try
            {
                string json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

                HttpResponseMessage response = await Client.PutAsync(url, stringContent);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(apiResponse);
                return data;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<T> DeleteAsync<T>(string url)
        {
            HttpResponseMessage response = await Client.DeleteAsync(url);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(apiResponse);
            return data;
        }
    }
}
