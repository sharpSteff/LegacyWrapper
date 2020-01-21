using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyWrapper.Common.Serialization
{
    public interface ICallFormatter
    {
        T Deserialize<T>(PipeStream serializationStream);

        void Serialize(PipeStream serializationStream, object graph);
    }
}
