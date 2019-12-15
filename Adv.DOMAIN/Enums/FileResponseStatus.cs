using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DOMAIN.Enums
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
