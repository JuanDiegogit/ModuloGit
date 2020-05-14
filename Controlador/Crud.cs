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

        public static async Task <HttpResponseMessage> Get (string url) {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();
            Respuesta = await client.GetAsync(url);
            
            return Respuesta;
          
        }
        public static async Task<HttpResponseMessage> Get(string url, int ID) {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();

           return await client.GetAsync(String.Format("{0}/{1}",url,ID));

           


        }

        public static async Task<HttpResponseMessage> Post<T>(string url, T entidad)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(string.Format("{0}",URL_LOCAL +url)));
            httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entidad), Encoding.UTF8, "Application/json");

            return await client.PostAsync(URL_LOCAL+ url, httpRequestMessage.Content);
        }

        public static async Task<HttpResponseMessage> Put<T>(string url,int id, T entidad)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, new Uri(string.Format("{0}/{1}", URL_LOCAL + url,id)));
            httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entidad), Encoding.UTF8, "Application/json");

            return await client.PutAsync(string.Format("{0}/{1}", URL_LOCAL+ url,id), httpRequestMessage.Content);
        }

        public static async Task<HttpResponseMessage> Delete(string url, int ID)
        {

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL_LOCAL)
            };
            HttpResponseMessage Respuesta = new HttpResponseMessage();

           return await client.DeleteAsync(String.Format("{0}/{1}", URL_LOCAL+ url, ID));

          


        }

    }
}
