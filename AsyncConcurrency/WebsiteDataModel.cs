using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConcurrency
{
    class WebsiteDataModel
    {


        public string WebsiteUrl { get; set; } = "";

        public string WebsiteData { get; set; } = "";

        public long TotalMilliseconds { get; set; } = 0;


    }
}
