namespace Toolkit.Serializer;

public interface ISerializer
{
    Tout Desrialize<Tout>(string data);
    string Serialize(object input);

}
