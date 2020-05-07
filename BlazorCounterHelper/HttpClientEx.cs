using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorCounterHelper
{
    public static class HttpClientEx
    {

        static JsonSerializerOptions opt = new JsonSerializerOptions
        {

            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        public static async Task<U> MyPostJsonGetJsonEnumAsync<U, T>(this HttpClient client, string requestUri, T content) where U : IEnumerable<T>
        {
            if (client is HttpClient)
            {

                return await SendJsonGetJsonEnumAsync<U, T>(client, HttpMethod.Post, requestUri, content);

            }
            else
            {
                throw new InvalidOperationException();
            }
        }


        private static async Task<U> SendJsonGetJsonEnumAsync<U, T>(HttpClient httpClient, HttpMethod method, string requestUri, object content) where U : IEnumerable<T>
        {

            var response = await httpClient.SendAsync(new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content, opt), Encoding.UTF8, "application/json")
            });

            string a = await response.Content.ReadAsStringAsync();

            Console.WriteLine(a);

            return JsonSerializer.Deserialize<U>(await response.Content.ReadAsStringAsync(), opt);

            //var stringContent = await response.Content.ReadFromJsonAsync<string>();

            //JsonDocument document = JsonDocument.Parse(stringContent);

            //return JsonSerializer.Deserialize<U>(document.RootElement.GetProperty("value").GetRawText(), opt);



        }

    }
}
