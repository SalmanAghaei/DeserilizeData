using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Toolkit.Serializer;

public class Serializer: ISerializer
{

    readonly IServiceProvider _serviceProvider;
    readonly HttpContext _httpContext;
    readonly ISerializeAdapter _serializeAdapter;
    public Serializer(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
    {
        _serviceProvider = serviceProvider;
        _httpContext = httpContextAccessor.HttpContext;
        _serializeAdapter = GetSerializer();
    }

    public Tout Desrialize<Tout>(string data)=>
        _serializeAdapter.Desrialize<Tout>(data);


    public string Serialize(object input)=>
         _serializeAdapter.Serialize(input);

    private ISerializeAdapter GetSerializer()
    {
        var services = _serviceProvider.GetServices<ISerializeAdapter>().ToList();
        return services.FirstOrDefault(x => x.DataType ==_httpContext.GetDataType());
    }
}
