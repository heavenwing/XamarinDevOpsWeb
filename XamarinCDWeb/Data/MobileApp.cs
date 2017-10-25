using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinCDWeb.Data
{
    public class MobileApp
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ApkVersion { get; set; }

        public string IpaVersion { get; set; }
    }
}
