using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;
using Toolkit.Data;
using Toolkit.Serializer;
using System.Linq;

namespace Toolkit;

public static class Extensions
{
    public static IServiceCollection AddSerializers(this IServiceCollection services) =>
        services
           .AddScoped<ISerializeAdapter, JsonSerialize>()
           .AddScoped<ISerializeAdapter, CustomSerialize>()
           .AddScoped<ISerializeAdapter, XmlSerialize>()
           .AddScoped<ISerializer, Toolkit.Serializer.Serializer>()
           .AddScoped<IDapper, Toolkit.Data.Dapper>()
           .AddSingleton<IRequestDataType, RequestDataType>();

}
public static class HttpContextExtensions
{
    public static DataType GetDataType(this HttpContext httpContext)
    {
        var requestPath = httpContext.Request.Path.ToString();
        var requestPathArray = requestPath.Split("/");

        var datatypes = Enum.GetValues(typeof(DataType)).Cast<DataType>().ToList();
        var datatypesStr = datatypes.Select(c => c.ToString().ToLower()).ToList();
        var requestDataTypeIndex = requestPathArray.FirstOrDefault(x => datatypes.Select(c => c.ToString().ToLower()).Contains(x.ToLower()));
        return datatypes.FirstOrDefault(x => x.ToString().ToLower() == requestDataTypeIndex.ToLower());
    }

}
