using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinCDWeb.Extensions
{
    public static class UriHelper
    {
        public static string GetUriAuthority(this HttpRequest request)
        {
            return request.Scheme + "://" + request.Host;
        }
    }
}
