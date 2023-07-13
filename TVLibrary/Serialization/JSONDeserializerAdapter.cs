using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TVLibrary.Serialization;

public class JSONDeserializerAdapter : IDeserializer
{
    static IDeserializer? instance;

    public static IDeserializer Instance
    {
        get 
        {
            instance ??= new JSONDeserializerAdapter();
            return instance;
        }
        private set 
        {
            instance = value;
        }
    }

    public T? Deserialize<T>(string stream)
    {
        return JsonSerializer.Deserialize<T>(stream);
    }
}
