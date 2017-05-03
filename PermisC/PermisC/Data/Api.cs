using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PermisC.Data
{
    class Api
    {
        private HttpClient Client = new HttpClient();
        private const string user = "client";
        private const string mdp = "6wdeuv";
        private static readonly Encoding encoding = Encoding.UTF8;

        public string GET(string test, string methode)
        {
            var timestamp = GetTimestamp();

            string sign = user + mdp + methode + timestamp;

            var code = Hashage(sign);

            Debug.WriteLine("Result : {0}", code);

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = Client.GetAsync("http://192.168.10.183/API/api.php?action="+test +"&user="+user+"&timestamp="+timestamp+"&signature="+code).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(json))
                {
                    return json;
                }

                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        static string GetTimestamp()
        {
            var timestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Debug.WriteLine("timestamp : {0}", timestamp.ToString());
            return timestamp.ToString();
        }

        static string Hashage(string sign)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(mdp)))
            {
                return ByteToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(sign)));
            }
        }

        static string ByteToString(IEnumerable<byte> data)
        {
            return string.Concat(data.Select(b => b.ToString("x2")));
        }
    }
}
