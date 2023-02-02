using Newtonsoft.Json;
using System;

namespace Toolkit.Serializer;

public class JsonSerialize : ISerializeAdapter
{
    public DataType DataType => DataType.Json;

    public string Serialize(object input)
    {
        throw new NotImplementedException();
    }


    public Tout Desrialize<Tout>(string data)
    {
        return JsonConvert.DeserializeObject<Tout>(data);
    }

}
