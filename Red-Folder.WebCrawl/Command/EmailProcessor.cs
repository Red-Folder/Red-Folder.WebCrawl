using Red_Folder.WebCrawl.Helpers;
using Red_Folder.WebCrawl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Folder.WebCrawl.Command
{
    public class EmailProcessor : BaseProcessor
    {
        private IList<string> _knownEmails;

        public EmailProcessor()
        {
            _knownEmails = PopulateKnownEmails();
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
            if (_knownEmails.Contains(url)) return true;

            return false;
        }

        private IUrlInfo Handle(string url)
        {
            return new EmailUrlInfo(url);
        }

        private IList<string> PopulateKnownEmails()
        {
            return new List<string>
            {
                @"mailto:mark@red-folder.com"
            };
        }
    }
}
