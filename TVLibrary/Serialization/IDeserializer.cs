using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVLibrary.Serialization;

public interface IDeserializer
{
    static IDeserializer? Instance { get; }

    T? Deserialize<T>(string stream);
}
