using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class Crud
    {
       private const string  URL_LOCAL = "http://localhost:56593/"; 

        public async Task <HttpResponseMessage> Get <T>(string url) {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();
            Respuesta = await client.GetAsync(url);
            
            return Respuesta;
          
        }
        public async Task<HttpResponseMessage> Get<T>(string url, int ID) {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();

           return await client.GetAsync(String.Format("{0}/{1}",url,ID));

           


        }

        public async Task<HttpResponseMessage> Post<T>(string url, T entidad)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(string.Format("{0}", url)));
            httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entidad), Encoding.UTF8, "Application/json");

            return await client.PostAsync(url, httpRequestMessage.Content);
        }

        public async Task<HttpResponseMessage> Put<T>(string url,int id, T entidad)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(string.Format("{0}/{1}",id, url)));
            httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entidad), Encoding.UTF8, "Application/json");

            return await client.PutAsync(string.Format("{0}/{1}", id, url), httpRequestMessage.Content);
        }

        public async Task<HttpResponseMessage> Delete<T>(string url, int ID)
        {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();

           return await client.DeleteAsync(String.Format("{0}/{1}", url, ID));

          


        }

    }
}
