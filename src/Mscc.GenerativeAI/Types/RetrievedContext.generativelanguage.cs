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
using System.Collections.Generic;

// *** AUTO-GENERATED FILE - DO NOT EDIT MANUALLY *** //

namespace Mscc.GenerativeAI.Types
{
	/// <summary>
	/// Chunk from context retrieved by the file search tool.
	/// </summary>
	public sealed partial class RetrievedContext
	{
		/// <summary>
		/// Optional. User-provided metadata about the retrieved context.
		/// </summary>
		public List<GroundingChunkCustomMetadata>? CustomMetadata { get; set; }
		/// <summary>
		/// Optional. Name of the <c>FileSearchStore</c> containing the document. Example: <c>fileSearchStores/123</c>
		/// </summary>
		public string? FileSearchStore { get; set; }
		/// <summary>
		/// Optional. Text of the chunk.
		/// </summary>
		public string? Text { get; set; }
		/// <summary>
		/// Optional. Title of the document.
		/// </summary>
		public string? Title { get; set; }
		/// <summary>
		/// Optional. URI reference of the semantic retrieval document.
		/// </summary>
		public string? Uri { get; set; }
    }
}