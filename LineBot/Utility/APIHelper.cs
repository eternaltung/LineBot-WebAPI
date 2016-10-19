using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LineBot.Models;
using Newtonsoft.Json;

namespace LineBot.Utility
{
    public class APIHelper
    {
        private readonly static string channelToken = "replace with your Channel Access Token";

        public static async Task<HttpResponseMessage> ReplyMessage(ReplyModel reply)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(reply);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelToken}");
                return await client.PostAsync("https://api.line.me/v2/bot/message/reply",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}