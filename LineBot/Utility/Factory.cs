using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LineBot.BLL;

namespace LineBot.Utility
{
    public class Factory
    {
        public static ILineHandler CreateLineHandler() => new LineHandler();
    }
}