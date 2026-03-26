/*
 * Copyleft 2024-2025 Jochen Kirstätter and contributors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System.Text.Json.Serialization;

// *** AUTO-GENERATED FILE - DO NOT EDIT MANUALLY *** //

namespace Mscc.GenerativeAI.Types
{

	[JsonConverter(typeof(JsonStringEnumConverter<ToolType>))]
	public enum ToolType
	{
		/// <summary>
		/// Unspecified tool type.
		/// </summary>
		ToolTypeUnspecified,
		/// <summary>
		/// Google search tool, maps to Tool.google_search.search_types.web_search.
		/// </summary>
		GoogleSearchWeb,
		/// <summary>
		/// Image search tool, maps to Tool.google_search.search_types.image_search.
		/// </summary>
		GoogleSearchImage,
		/// <summary>
		/// URL context tool, maps to Tool.url_context.
		/// </summary>
		UrlContext,
		/// <summary>
		/// Google maps tool, maps to Tool.google_maps.
		/// </summary>
		GoogleMaps,
		/// <summary>
		/// File search tool, maps to Tool.file_search.
		/// </summary>
		FileSearch,
	}
}