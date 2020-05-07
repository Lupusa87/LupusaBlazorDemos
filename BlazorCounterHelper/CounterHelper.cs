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


        static bool WebOrLocalMode = true;

        public static Uri WebApi_Uri
        {
            get
            {
                if (WebOrLocalMode)
                {
                    return new Uri("https://blazortodosfunctionsapi.azurewebsites.net/api/");
                }
                else
                {
                    return new Uri("http://localhost:7071/api/");
                }
            }
        }


        public static void Initialize()
        {


            httpClient1 = new HttpClient()
            {
                BaseAddress = WebApi_Uri,
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

            httpClient2 = new HttpClient()
            {
                BaseAddress = WebApi_Uri,
                Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite)
            };

        }

        public static async Task<List<TSReport1>> CmdGetReport1(bool EmptyBag, DateTime fromDate, DateTime toDate)
        {
            try
            {

                TSReport1 tsReport1 = new TSReport1();
                if (!EmptyBag)
                {
                    tsReport1.Source = ToUnixEpochDate(fromDate).ToString();
                    tsReport1.Action = ToUnixEpochDate(toDate).ToString();
                }
                else
                {
                    tsReport1.Source = "0";
                    tsReport1.Action = "0";
                }

               
                httpClient1.DefaultRequestHeaders.Accept.Clear();
                httpClient1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                httpClient1.DefaultRequestHeaders.Add("x-functions-key", "FIWvxFPsVvuFaq19MW6EYwO1X8z7XTaDk2aFKkBn9hMRRnMbuxvtDA==");

                List<TSReport1> result = await httpClient1.MyPostJsonGetJsonEnumAsync<List<TSReport1>, TSReport1>("Counter/getreport1", tsReport1);

                httpClient1.DefaultRequestHeaders.Remove("x-functions-key");
                httpClient1.DefaultRequestHeaders.Accept.Clear();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TSReport1>();
            }


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

                if (ParTSCounter.Source.Contains("localhost"))
                {
                    return "OK";
                }


                httpClient2.DefaultRequestHeaders.Accept.Clear();
                httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                ParTSCounter.Source = ParTSCounter.Source.Replace("https://", null);
                ParTSCounter.Source = ParTSCounter.Source.Replace("http://", null);

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


        public static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }


        public static DateTime ToUtcDate(DateTime date)
        {
            return date.AddMilliseconds((DateTime.UtcNow- DateTime.Now).TotalMilliseconds);
        }
  }
}
