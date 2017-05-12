using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace PermisC.Data
{
    class Api
    {
        private HttpClient Client = new HttpClient();
        private string user = "";
        private string mdp = "";
        private static readonly Encoding encoding = Encoding.UTF8;

        public string GET(string test, string methode,Boolean isConnect,Boolean go = false)
        {
            if (isConnect)
            {
                if (!string.IsNullOrWhiteSpace(user) || go)
                { 
                    var timestamp = GetTimestamp();

                    string sign = user + mdp + methode + timestamp;

                    var code = Hashage(sign, mdp);


                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = Client.GetAsync("http://192.168.10.183/API/api.php?action=" + test + "&user=" + user + "&timestamp=" + timestamp + "&signature=" + code).Result;
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
            var timestamp = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
            return timestamp.ToString();
        }

        static string Hashage(string sign,string mdp)
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

        public void connect(String _user, String _mdp)
        {
            user = _user;
            mdp = _mdp;
        }
    }
}
