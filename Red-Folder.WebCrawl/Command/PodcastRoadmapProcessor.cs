using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red_Folder.WebCrawl.Models;
using Red_Folder.WebCrawl.Helpers;

namespace Red_Folder.WebCrawl.Command
{
    public class PodcastRoadmapProcessor : HttpClientBaseProcessor
    {
        public PodcastRoadmapProcessor(IClientWrapper httpClient) : base(httpClient)
        {
        }

        public override IUrlInfo Process(string url)
        {
            if (CanBeHandled(url))
            {
                return Handle(url);
            }
            else
            {
                return base.Process(url);
            }
        }

        private bool CanBeHandled(string url)
        {
            return url.Contains("/podcasts/roadmap");
        }

        private IUrlInfo Handle(string url)
        {
            HttpGet(url);
            if (LastHttpStatusCode == System.Net.HttpStatusCode.Redirect)
            {
                return new PageUrlInfo(url);
            }
            else
            {
                return new PageUrlInfo(url, String.Format("Unexpected Status code: {0}", LastHttpStatusCode));
            }
        }
    }
}
