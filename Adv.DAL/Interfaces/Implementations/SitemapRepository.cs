using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Adv.DAL.Interfaces.Implementations
{
    public class SitemapRepository : ISitemapRepository
    {
        private static readonly string[] Scopes = { DriveService.Scope.Drive };
        private const string ApplicationName = "halupa.by";
        private const string SitemapId = "1I1ivMEMa8nbUwe_fq6j7j4M9d95rD5-C";
        private const string SitemapPath = @"clientapp/src/assets/sitemap.xml";
        public static DriveService GetService()
        {
            var directory = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(directory, @"credentials.json");
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            const string credPath = "token.json";
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,
                "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
        public async Task<XDocument> GetSitemapXmlAsync()
        {
            var service = GetService();
            var fileRequest = service.Files.Get(SitemapId);
            var path = Path.Combine(Directory.GetCurrentDirectory(), SitemapPath);
            var stream = new MemoryStream();
            fileRequest.MediaDownloader.ProgressChanged += progress =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Completed:
                    {
                        SaveStream(stream, path);
                        break;
                    }
                }
            };
            await fileRequest.DownloadAsync(stream, CancellationToken.None).ConfigureAwait(false);
            
            return await Task.Run(() => XDocument.Load(Path.Combine(path))).ConfigureAwait(false);
        }
        
        private static void SaveStream(MemoryStream stream, string filePath)
        {
            using var file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            stream.WriteTo(file);
        }
    }
}
