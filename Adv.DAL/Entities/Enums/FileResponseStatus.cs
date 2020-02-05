

namespace Adv.DAL.Entities.Enums
{
    public class FileResponseStatus
    {
        public Response Status { get; set; }
        public enum Response
        {
            Success,
            Failure
        }
    }
}
