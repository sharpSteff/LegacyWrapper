using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LegacyWrapper.Common.Serialization
{
    public class JsonCallFormatter : ICallFormatter
    {
        public T Deserialize<T>(PipeStream pipe)
        {
            var serializer = new JsonSerializer();

            T result;
            using (var sr = new StreamReader(pipe, Encoding.UTF8, true, 1024, true))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    result = serializer.Deserialize<T>(jsonTextReader);
                }
            }

            return result;
        }

        public void Serialize(PipeStream serializationStream, object graph)
        {
            var serializer = new JsonSerializer();
            using (var sr = new StreamWriter(serializationStream, Encoding.UTF8, 1024, true))
            {
                serializer.Serialize(sr, graph);
            }
        }
    }
}
