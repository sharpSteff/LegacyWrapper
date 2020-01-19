using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyWrapper.Common
{
    public class PipeTimeout
    {
        public PipeTimeout(int timeout)
        {
            Timeout = timeout;
        }

        public int Timeout { get; set; }
    }
}
