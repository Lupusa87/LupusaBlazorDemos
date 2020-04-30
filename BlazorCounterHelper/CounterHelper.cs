using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;


namespace BlazorCounterHelper
{
    public static class CounterHelper
    {
        private static HttpClient httpClient1;
        private static HttpClient httpClient2;

        

        public static void Initialize()
        {


            httpClient1 = new HttpClient()
            {
                BaseAddress = new Uri("https://blazortodosfunctionsapi.azurewebsites.net/api/"),
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

            httpClient2 = new HttpClient()
            {
                BaseAddress = new Uri("https://blazortodosfunctionsapi.azurewebsites.net/api/"),
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

        }



        public static async Task<List<TSCounter>> CmdGetNewestCounters()
        {
            try
            {


                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient1.DefaultRequestHeaders.Add("x-functions-key", "SkyBlfY2527Dd2mV/wvdsc0L0F3rESZN3SJyJAr5WK9LeikQMUihew==");
                List<TSCounter> result = await httpClient1.GetFromJsonAsync<List<TSCounter>>("Counter/getall");
             
                httpClient1.DefaultRequestHeaders.Remove("x-functions-key");
                httpClient1.DefaultRequestHeaders.Accept.Clear();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TSCounter>();
            }


        }


        public static async Task<string> CmdAddCounter(TSCounter ParTSCounter)
        {
            try
            {


                httpClient2.DefaultRequestHeaders.Accept.Clear();
                httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                CmdTrimEntity(ParTSCounter);

                TSCounter tsCounterForSend = CopyObject<TSCounter>(ParTSCounter);

                httpClient2.DefaultRequestHeaders.Add("x-functions-key", "20bLI4NLXhjZ77Ud5XDiEM9UlDUCkSSAUgXZ53n6/NkcG3vWpXmUvA==");

                HttpResponseMessage response = await httpClient2.PostAsJsonAsync("Counter/add", tsCounterForSend);
                string result = await response.Content.ReadFromJsonAsync<string>();

                httpClient2.DefaultRequestHeaders.Remove("x-functions-key");
                httpClient2.DefaultRequestHeaders.Accept.Clear();


                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public static T CopyObject<T>(object objSource)
        {

            using (MemoryStream stream = new MemoryStream())
            {

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, objSource);

                stream.Position = 0;

                return (T)formatter.Deserialize(stream);

            }

        }

        public static void CmdTrimEntity<T>(T Par_entity)
        {

            string tmp_str = string.Empty;
            foreach (PropertyInfo item in typeof(T).GetProperties().Where(x => x.PropertyType == typeof(string)))
            {

                tmp_str = (string)item.GetValue(Par_entity);
                if (!string.IsNullOrEmpty(tmp_str))
                {
                    item.SetValue(Par_entity, tmp_str.Trim());
                }
            }
        }
    }
}
