using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LegacyWrapper.Common.Serialization
{
    public class BinaryCallFormatter : ICallFormatter
    {
        private IFormatter _formatter;

        public BinaryCallFormatter(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public T Deserialize<T>(PipeStream serializationStream)
        {
            return (T)_formatter.Deserialize(serializationStream);
        }

        public void Serialize(PipeStream serializationStream, object graph)
        {
            _formatter.Serialize(serializationStream, graph);
        }
    }
}
