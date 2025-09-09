﻿#if NET472_OR_GREATER || NETSTANDARD2_0
using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
#endif

namespace Mscc.GenerativeAI
{
    /// <summary>
    /// The Schema object allows the definition of input and output data types. These types can be objects, but also primitives and arrays. Represents a select subset of an OpenAPI 3.0 schema object.
    /// </summary>
    public partial class Schema
    {
        /// <summary>
        /// Required. Data type.
        /// </summary>
        public ParameterType? Type { get; set; }

        /// <summary>
        /// Optional. The title of the schema.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Optional. The format of the data.
        /// This is used only for primitive datatypes.
        /// Supported formats:
        /// for NUMBER type: float, double
        /// for INTEGER type: int32, int64
        /// for STRING type: enum, date-time
        /// </summary>
        public string Format { get; set; } = "";

        /// <summary>
        /// Optional. A brief description of the parameter. This could contain examples of use. Parameter description may be formatted as Markdown.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Optional. Indicates if the value may be null.
        /// </summary>
        public bool? Nullable { get; set; }

        /// <summary>
        /// Optional. Schema of the elements of Type.ARRAY.
        /// </summary>
        public Schema? Items { get; set; }

        /// <summary>
        /// Optional. Maximum number of the elements for Type.ARRAY.
        /// </summary>
        public long? MaxItems { get; set; }

        /// <summary>
        /// Optional. Minimum number of the elements for Type.ARRAY.
        /// </summary>
        public long? MinItems { get; set; }

        /// <summary>
        /// Optional. Possible values of the element of Type.STRING with enum format.
        /// For example we can define an Enum Direction as :
        /// {type:STRING, format:enum, enum:["EAST", NORTH", "SOUTH", "WEST"]}
        /// </summary>
        public List<string>? Enum { get; set; }

        /// <summary>
        /// Optional. Properties of Type.OBJECT.
        /// An object containing a list of "key": value pairs. Example: { "name": "wrench", "mass": "1.3kg", "count": "3" }.
        /// </summary>
        public object? Properties { get; set; }

        /// <summary>
        /// Optional. The order of the properties. Not a standard field in open api spec. Used to determine the order of the properties in the response.
        /// </summary>
        public List<string>? PropertyOrdering { get; set; }

        /// <summary>
        /// Optional. Required properties of Type.OBJECT.
        /// </summary>
        public List<string>? Required { get; set; }

        /// <summary>
        /// Optional. The value should be validated against any (one or more) of the subschemas in the list.
        /// </summary>
        public List<Schema>? AnyOf { get; set; }

        /// <summary>
        /// Optional. Maximum value of the Type.INTEGER and Type.NUMBER
        /// </summary>
        /// <remarks>SCHEMA FIELDS FOR TYPE INTEGER and NUMBER</remarks>
        public long? Maximum { get; set; }

        /// <summary>
        /// Optional. Minimum value of the Type.INTEGER and Type.NUMBER
        /// </summary>
        /// <remarks>SCHEMA FIELDS FOR TYPE INTEGER and NUMBER</remarks>
        public long? Minimum { get; set; }

        /// <summary>
        /// Optional. Default value of the field.
        /// Per JSON Schema, this field is intended for documentation generators and doesn't affect validation. Thus it's included here and ignored so that developers who send schemas with a `default` field don't get unknown-field errors.
        /// </summary>
        public object? Default { get; set; }

        /// <summary>
        /// Optional. Example of the object. Will only populated when the object is the root.
        /// </summary>
        public object? Example { get; set; }

        /// <summary>
        /// Optional. Maximum length of the Type.STRING
        /// </summary>
        public string? MaxLength { get; set; }

        /// <summary>
        /// Optional. Minimum length of the Type.STRING
        /// </summary>
        public string? MinLength { get; set; }

        /// <summary>
        /// Optional. Maximum number of the properties for Type.OBJECT.
        /// </summary>
        public string? MaxProperties { get; set; }

        /// <summary>
        /// Optional. Minimum number of the properties for Type.OBJECT.
        /// </summary>
        public string? MinProperties { get; set; }

        /// <summary>
        /// Optional. Pattern of the Type.STRING to restrict a string to a regular expression.
        /// </summary>
        public string? Pattern { get; set; }
    }
}