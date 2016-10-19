using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LineBot.Models;
using LineBot.Utility;
using Newtonsoft.Json;

namespace LineBot.Controllers
{
    public class LineController : ApiController
    {
        private string channelSecret = "replace with your channel secret";

        // GET: api/Line/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Line
        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                var signature = Request.Headers.GetValues("X-Line-Signature").FirstOrDefault();
                var body = await Request.Content.ReadAsStringAsync();
                var cryptoResult = SHA256Crypto(body);
                if (signature == cryptoResult)
                {
                    var value = JsonConvert.DeserializeObject<WebhookModel>(body);
                    var handler = Factory.CreateLineHandler();
                    await handler.ProcessMessage(value);
                }
                else
                {
                    // signature not valid
                }
            }
            catch (Exception ex)
            {
                // handle exception
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private string SHA256Crypto(string text)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(channelSecret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
