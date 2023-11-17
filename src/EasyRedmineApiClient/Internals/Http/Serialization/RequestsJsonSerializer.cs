using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyRedmineApiClient.Internals.Http.Serialization;

internal sealed class RequestJsonSerializer
{
    private static readonly JsonSerializerSettings Settings;

    static RequestJsonSerializer()
        => Settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new EmptyCollectionContractResolver(),
            Converters = { new StringEnumConverter() }
        };

    public string Serialize(object obj) => JsonConvert.SerializeObject(obj, Settings);

    public T Deserialize<T>(string serializeJson) => JsonConvert.DeserializeObject<T>(serializeJson, Settings);
}