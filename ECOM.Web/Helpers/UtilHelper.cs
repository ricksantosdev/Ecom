using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECOM.Web.Helpers
{
    public static class UtilHelper
    {
        public static string RetornaFromByteToImageString(byte[] image)
        {
            string imgBas64 = Convert.ToBase64String(image);
            if (image is null || image.Length == 0)
                return string.Empty;
            else
                return string.Format("data:image/png;base64,{0}", imgBas64);
        }

    }
}