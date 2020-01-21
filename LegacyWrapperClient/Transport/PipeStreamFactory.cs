using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegacyWrapper.Common.Token;

namespace LegacyWrapperClient.Transport
{
    internal class PipeStreamFactory
    {
        private const string LocalPipeUrl = ".";

        public virtual PipeStream GetConnectedPipeStream(PipeToken pipeToken, int timeout = System.Threading.Timeout.Infinite)
        {
            if (timeout == 0)
            {
                timeout = System.Threading.Timeout.Infinite;
            }

            NamedPipeClientStream pipe = new NamedPipeClientStream(LocalPipeUrl, pipeToken.Token, PipeDirection.InOut);
            pipe.Connect(timeout);
            pipe.ReadMode = PipeTransmissionMode.Message;

            return pipe;
        }
    }
}
