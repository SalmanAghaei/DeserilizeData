using Newtonsoft.Json;
using System;
using System.Linq;

namespace Toolkit.Serializer;

public class CustomSerialize : ISerializeAdapter
{
    public DataType DataType => DataType.Custom;

    public Tout Desrialize<Tout>(string data)
    {
        try
        {
            var split = data.Split("\n");
            var line1Split = split.First().Split("/");
            var line2Split = split.Last().Split("/");
            if (line1Split.Count() != line2Split.Count())
                throw new Exception();
            string json = "{";
            for (int i = 0; i < line1Split.Length; i++)
            {
                json += $"\"{line1Split[i]}\":\"{line2Split[i]}\",";
            }
            json += "}";
            var perjson = JsonConvert.DeserializeObject<Tout>(json);
            return perjson;
        }
        catch(JsonReaderException exception)
        {
            throw new FormatException(exception.Message);
        }
        catch(Exception exception) 
        {
            throw new Exception(exception.Message);
        }

        
    }

    public string Serialize(object input)
    {
        throw new NotImplementedException();
    }
}
