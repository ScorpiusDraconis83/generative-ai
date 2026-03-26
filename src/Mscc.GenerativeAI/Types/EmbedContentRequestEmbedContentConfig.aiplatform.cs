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
	/// <summary>
	/// Configurations for the EmbedContent API.
	/// </summary>
	public partial class EmbedContentRequestEmbedContentConfig
	{
		/// <summary>
		/// Optional. Whether to extract audio from video content.
		/// </summary>
		public bool? AudioTrackExtraction { get; set; }
		/// <summary>
		/// Optional. Whether to silently truncate the input content if it&apos;s longer than the maximum sequence length. Only applicable to text-only embedding models.
		/// </summary>
		public bool? AutoTruncate { get; set; }
		/// <summary>
		/// Optional. Whether to enable OCR for document content.
		/// </summary>
		public bool? DocumentOcr { get; set; }
		/// <summary>
		/// Optional. Reduced dimension for the output embedding. If set, excessive values in the output embedding are truncated from the end.
		/// </summary>
		public int? OutputDimensionality { get; set; }
		/// <summary>
		/// Optional. The task type of the embedding. Only applicable to text-only embedding models.
		/// </summary>
		public EmbedContentRequestEmbedContentConfigTaskType? TaskType { get; set; }
		/// <summary>
		/// Optional. The title for the text. Only applicable to text-only embedding models.
		/// </summary>
		public string? Title { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter<EmbedContentRequestEmbedContentConfigTaskType>))]
		public enum EmbedContentRequestEmbedContentConfigTaskType
		{
			/// <summary>
			/// Unset value, which will default to one of the other enum values.
			/// </summary>
			Unspecified,
			/// <summary>
			/// Specifies the given text is a query in a search/retrieval setting.
			/// </summary>
			RetrievalQuery,
			/// <summary>
			/// Specifies the given text is a document from the corpus being searched.
			/// </summary>
			RetrievalDocument,
			/// <summary>
			/// Specifies the given text will be used for STS.
			/// </summary>
			SemanticSimilarity,
			/// <summary>
			/// Specifies that the given text will be classified.
			/// </summary>
			Classification,
			/// <summary>
			/// Specifies that the embeddings will be used for clustering.
			/// </summary>
			Clustering,
			/// <summary>
			/// Specifies that the embeddings will be used for question answering.
			/// </summary>
			QuestionAnswering,
			/// <summary>
			/// Specifies that the embeddings will be used for fact verification.
			/// </summary>
			FactVerification,
			/// <summary>
			/// Specifies that the embeddings will be used for code retrieval.
			/// </summary>
			CodeRetrievalQuery,
		}
    }
}