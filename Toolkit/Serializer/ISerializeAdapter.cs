namespace Toolkit.Serializer;
public interface ISerializeAdapter
{
    DataType DataType { get; }
    Tout Desrialize<Tout>(string data);
    string Serialize(object input);
}
