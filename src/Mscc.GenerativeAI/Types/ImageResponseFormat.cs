using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Mscc.GenerativeAI.Types
{
    [JsonConverter(typeof(JsonStringEnumConverter<ImageResponseFormat>))]
    public enum ImageResponseFormat
    {
        [EnumMember(Value = "url")]
        [JsonStringEnumMemberName("url")]
        Url,
        [EnumMember(Value = "b64_json")]
        [JsonStringEnumMemberName("b64_json")]
        B64Json
    }
}