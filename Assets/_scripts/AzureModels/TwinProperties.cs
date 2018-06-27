using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._scripts.AzureModels
{
    public class TwinProperties
    {
        public TwinCollection Desired { get; set; }
        public TwinCollection Reported { get; set; }
    }
}
