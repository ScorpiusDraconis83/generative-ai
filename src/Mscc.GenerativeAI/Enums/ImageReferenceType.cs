#if NET472_OR_GREATER || NETSTANDARD2_0
using System.Text.Json.Serialization;
#endif

namespace Mscc.GenerativeAI
{
    /// <summary>
    /// The type of the reference image.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<ImageReferenceType>))]
    public enum ImageReferenceType
    {
        /// <summary>
        /// Raw reference type
        /// </summary>
        ReferenceTypeRaw,
        /// <summary>
        /// Mask reference type
        /// </summary>
        ReferenceTypeMask,
        /// <summary>
        /// Control reference type
        /// </summary>
        ReferenceTypeControl,
        /// <summary>
        /// Subject reference type
        /// </summary>
        ReferenceTypeSubject,
        /// <summary>
        /// Style reference type
        /// </summary>
        ReferenceTypeStyle
    }
}