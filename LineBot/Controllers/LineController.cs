﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineBot.Controllers
{
    public class LineController : ApiController
    {
        // GET: api/Line/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Line
        public void Post([FromBody]string value)
        {
        }        
    }
}
