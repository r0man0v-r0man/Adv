using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailRuCloudClient;

namespace Adv.DAL.Interfaces.Implementations
{
    public class SitemapRepository : ISitemapRepository
    {
        private static readonly CloudClient cloudClient = new CloudClient("romanovmailbox", "XUD3Sr0man0v");

        public async Task GetSitemapXmlAsync()
        {
            await cloudClient.Account.Login().ConfigureAwait(false);
            var doc = await cloudClient.DownloadFile("sitemap.xml").ConfigureAwait(false);
            
        }
    }
}
